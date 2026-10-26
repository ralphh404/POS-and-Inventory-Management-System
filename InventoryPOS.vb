Public Class InventoryPOS
    Public callingForm As frmInterface
    Private isExpanding As Boolean
    Private stockSubMenuHeight As Integer
    Private categorySubMenuHeight As Integer
    Private currentButton As Button = Nothing
    Private currentSubButton As Button = Nothing

    Private Sub MakePictureRound(pic As PictureBox)
        If pic.Image Is Nothing Then Exit Sub
        Dim diameter As Integer = Math.Min(pic.Width, pic.Height)
        Dim bmp As New Bitmap(diameter, diameter)

        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Dim gp As New Drawing2D.GraphicsPath()
            gp.AddEllipse(0, 0, diameter, diameter)
            g.SetClip(gp)
            g.Clear(Color.Transparent)
            g.DrawImage(pic.Image, New Rectangle(0, 0, diameter, diameter),
                            New Rectangle(0, 0, pic.Image.Width, pic.Image.Height), GraphicsUnit.Pixel)
        End Using

        pic.Image = bmp
        Dim regionPath As New Drawing2D.GraphicsPath()
        regionPath.AddEllipse(0, 0, diameter, diameter)
        pic.Region = New Region(regionPath)
    End Sub

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            Return cp
        End Get
    End Property

    Private Sub InventoryPOS(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            PictureBox2.Image = My.Resources.silver_membership_icon_default_avatar_profile_icon_membership_icon_social_media_user_image_illustration_vector
            MakePictureRound(PictureBox2)
        Catch ex As Exception
            MessageBox.Show("Failed to load profile picture: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        If frmInterface.loggedInType = "Staff" Then
            btnCategories.Visible = False
            btnSuppliers.Visible = False
            btnStocks.Visible = False
            btnDefects.Visible = False
            btnArchive.Visible = False
        End If

        DoubleBuffered = True

        Opacity = 0
        Dim fadeTimer As New Timer With {.Interval = 10}
        AddHandler fadeTimer.Tick, Sub()
                                       If Opacity < 1 Then
                                           Opacity += 0.1
                                       Else
                                           fadeTimer.Stop()
                                       End If
                                   End Sub
        fadeTimer.Start()
        stockSubMenuHeight = submenupanel.Height
        submenupanel.Height = 0

        AssignButtonClick(Me)

        LoadChildForm(New ProductsPOS(), btnProducts)
        ResizeButtonImages()

        btnDefects.Visible = False

    End Sub

    Private Sub ResizeButtonImages()
        Dim sidebarButtons As Button() = {
        btnHome, btnProducts, btnCategories,
        btnSuppliers, btnStocks, btnStockIn, btnStockOut,
        btnDefects, btnArchive
    }

        For Each btn As Button In sidebarButtons
            If btn.Image IsNot Nothing Then
                Dim resizedImage As New Bitmap(btn.Image, New Size(40, 40))
                btn.Image = resizedImage
                btn.ImageAlign = ContentAlignment.MiddleLeft
                btn.TextImageRelation = TextImageRelation.ImageBeforeText
                btn.Padding = New Padding(5, 0, 0, 0)
            End If
        Next
    End Sub

    ' Keeps sub buttons in the right colors, restoring the selected one
    Private Sub RecolorSubmenu()
        For Each ctrl As Control In submenupanel.Controls
            If TypeOf ctrl Is Button Then
                Dim b = DirectCast(ctrl, Button)
                If currentSubButton IsNot Nothing AndAlso b Is currentSubButton Then
                    b.BackColor = Color.SkyBlue   ' selected sub-button
                    b.ForeColor = Color.White
                Else
                    b.BackColor = Color.LightSteelBlue  ' default sub-button
                    b.ForeColor = Color.White
                End If
            End If
        Next
    End Sub


    Private Sub Button_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)

        ' Reset the previous highlighted button
        If currentButton IsNot Nothing Then
            currentButton.BackColor = Color.LightSlateGray
        End If

        ' Highlight the clicked button
        btn.BackColor = Color.SlateGray

        ' Update current highlighted button
        currentButton = btn
    End Sub

    Private Sub AssignButtonClick(parent As Control)
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is Button Then
                ' Exclude specific buttons
                If ctrl.Name <> "btnHome" AndAlso ctrl.Name <> "btnStockIn" AndAlso ctrl.Name <> "btnStockOut" Then
                    AddHandler ctrl.Click, AddressOf Button_Click
                End If
            End If

            ' Recursively check child controls
            If ctrl.HasChildren Then
                AssignButtonClick(ctrl)
            End If
        Next
    End Sub


    Private Sub HideAllSubMenus()
        ' Smoothly collapse instead of instantly hiding
        isExpanding = False
        btnStocks.Text = "Stocks" ' Remove arrow
        If submenupanel.Height > 0 Then
            Boom.Start() ' Trigger collapse animation
        End If

    End Sub


    Public Sub LoadChildForm(childForm As Form, Optional assignedBtn As Button = Nothing)
        InvPanel.Controls.Clear()
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        InvPanel.Controls.Add(childForm)
        childForm.Show()

        InvPanel.Controls.Add(childForm)
        childForm.Show()
        childForm.BringToFront()

        Me.BeginInvoke(New MethodInvoker(Sub()
                                             childForm.Focus()
                                             childForm.Select()
                                             childForm.Activate()
                                         End Sub))

        If assignedBtn IsNot Nothing Then
            If assignedBtn Is btnStockIn OrElse assignedBtn Is btnStockOut Then
                ' Submenu: highlight with sub style
                HighlightSubButton(assignedBtn)
            Else
                ' Main menu: highlight and collapse submenu
                HighlightButton(assignedBtn)
                HideAllSubMenus()

                ' 🔑 Reset sub highlight when switching to another main form
                currentSubButton = Nothing
                RecolorSubmenu()
            End If
        End If
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        ' Hide this form (e.g., InventoryPOS)
        Me.Hide()

        ' Reopen frmInterface (always the same instance)
        Dim interfaceForm As frmInterface = Application.OpenForms.OfType(Of frmInterface).FirstOrDefault()

        If interfaceForm Is Nothing Then
            interfaceForm = New frmInterface()
        End If

        interfaceForm.Opacity = 0
        interfaceForm.Show()
        interfaceForm.BringToFront()

        ' Load Dashboard inside main panel
        interfaceForm.LoadFormIntoPanel(New Dashboard())

        ' Smooth fade-in (fast, not laggy)
        Dim fadeTimer As New Timer With {.Interval = 15}
        AddHandler fadeTimer.Tick,
        Sub()
            If interfaceForm.Opacity < 1 Then
                interfaceForm.Opacity += 0.2
            Else
                fadeTimer.Stop()
                fadeTimer.Dispose()
            End If
        End Sub
        fadeTimer.Start()

        ' Fully close this form so it doesn’t sit in memory
        Me.Close()

    End Sub

    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        LoadChildForm(New ProductsPOS(), btnProducts)
    End Sub

    Private Sub btnCategories_Click(sender As Object, e As EventArgs) Handles btnCategories.Click
        LoadChildForm(New Categories(), btnCategories)
    End Sub

    Private Sub btnArchive_Click(sender As Object, e As EventArgs) Handles btnArchive.Click
        LoadChildForm(New InvArchive(), btnArchive)
    End Sub

    Private Sub btnSuppliers_Click(sender As Object, e As EventArgs) Handles btnSuppliers.Click
        LoadChildForm(New Suppliers(), btnSuppliers)
    End Sub

    Private Sub btnStocks_Click(sender As Object, e As EventArgs) Handles btnStocks.Click
        If submenupanel.Height = 0 Then
            isExpanding = True
            btnStocks.Text = "Stocks                   ▼" ' Show arrow
            HighlightButton(btnStocks)
        Else
            isExpanding = False
            btnStocks.Text = "Stocks" ' Remove arrow
        End If
        Boom.Start()

    End Sub


    ' Function to highlight a button
    Private Sub HighlightButton(btn As Button)
        ' Remove highlight from previous button
        If currentButton IsNot Nothing AndAlso currentButton IsNot btn Then
            currentButton.BackColor = Color.LightSlateGray
        End If

        ' Highlight the clicked button
        btn.BackColor = Color.SlateGray
        currentButton = btn

    End Sub

    Private Sub HighlightSubButton(clickedBtn As Button)
        currentSubButton = clickedBtn
        RecolorSubmenu()
    End Sub

    ' Function to remove highlight
    Private Sub RemoveHighlight(btn As Button)
        If currentButton Is btn Then
            btn.BackColor = Color.LightSlateGray
            currentButton = Nothing
        End If
    End Sub

    Private Sub Boom_Tick(sender As Object, e As EventArgs) Handles Boom.Tick
        Dim maxHeight As Integer = 120 ' Adjust depending on submenu size

        If isExpanding Then
            If submenupanel.Height < maxHeight Then
                submenupanel.Height += 10 ' Speed of expansion
            Else
                submenupanel.Height = maxHeight
                Boom.Stop()
                RecolorSubmenu()
            End If
        Else
            If submenupanel.Height > 0 Then
                submenupanel.Height -= 10 ' Speed of collapse
            Else
                submenupanel.Height = 0
                Boom.Stop()
                RemoveHighlight(btnStocks)
            End If
        End If
    End Sub

    Private Sub btnStockIn_Click(sender As Object, e As EventArgs) Handles btnStockIn.Click
        LoadChildForm(New StockIn(), btnStockIn)
    End Sub

    Private Sub btnStockOut_Click(sender As Object, e As EventArgs) Handles btnStockOut.Click
        LoadChildForm(New StockOut(), btnStockOut)
    End Sub
End Class