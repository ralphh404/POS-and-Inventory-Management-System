Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient
Imports Windows.Win32.System

Public Class frmInterface
    Public Shared loggedInUsername As String
    Public Shared loggedInType As String

    ' ✅ Flag to know if returning from Inventory
    Public Shared ReturningFromInventory As Boolean = False

    ' Store reused forms to avoid flicker
    Private dashboardForm As Dashboard
    Private accountsForm As frmAccounts
    Private logsForm As frmLogs
    Private archivesForm As IntArch
    Private posForm As POSmain


    ' Track currently active button
    Private activeButton As Button = Nothing

    ' ✅ Round profile picture
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

    ' ✅ Double buffering for smooth UI
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            Return cp
        End Get
    End Property

    Private Sub EnableDoubleBuffering(ctrl As Control)
        Dim prop As Reflection.PropertyInfo =
            GetType(Control).GetProperty("DoubleBuffered",
                                         Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
        prop.SetValue(ctrl, True, Nothing)
    End Sub

    ' ✅ Load Event
    Private Sub frmInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        EnableDoubleBuffering(mainPanel)

        ' Profile picture
        Try
            PictureBox1.Image = My.Resources.silver_membership_icon_default_avatar_profile_icon_membership_icon_social_media_user_image_illustration_vector
            MakePictureRound(PictureBox1)
        Catch ex As Exception
            MessageBox.Show("Failed to load profile picture: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        ' Preload forms
        dashboardForm = New Dashboard()
        accountsForm = New frmAccounts()
        logsForm = New frmLogs()
        archivesForm = New IntArch()

        ' ✅ Restrict STAFF (hide buttons instead of disabling)
        If loggedInType.Trim().ToLower() = "staff" Then
            btnAccounts.Visible = False
            btnLogs.Visible = False
            btnArch.Visible = False
            btnData.Visible = False
            btnSales.Visible = False
            ' Staff only keeps Dashboard, POS, Logout, Exit
        End If

        ' Load default dashboard
        LoadFormIntoPanel(dashboardForm)
        HighlightActiveButton(btnDashboard)

        FadeInForm(Me)

        ResizeButtonImages()

        btnData.Visible = False
    End Sub

    Private Sub ResizeButtonImages()
        Dim sidebarButtons As Button() = {
        btnDashboard, btnInventory, btnPOS,
        btnAccounts, btnArch, btnData,
        btnLogs, btnSales, btnExit, btnLogOut
    }

        For Each btn As Button In sidebarButtons
            If btn.Image IsNot Nothing Then
                Dim resizedImage As New Bitmap(btn.Image, New Size(40, 40)) ' force 20x20 icons
                btn.Image = resizedImage
                btn.ImageAlign = ContentAlignment.MiddleLeft
                btn.TextImageRelation = TextImageRelation.ImageBeforeText
                btn.Padding = New Padding(5, 0, 0, 0)
            End If
        Next
    End Sub

    Public Sub ReturnToDashboard()
        LoadFormIntoPanel(dashboardForm)
        HighlightActiveButton(btnDashboard)

        ' ✅ Refresh dashboard content
        If dashboardForm IsNot Nothing AndAlso Not dashboardForm.IsDisposed Then
            dashboardForm.DashboardLoad()
        End If
    End Sub

    ' ✅ Fade-in effect
    Public Sub FadeInForm(targetForm As Form, Optional interval As Integer = 10, Optional stepSize As Double = 0.1)
        targetForm.Opacity = 0
        Dim fadeTimer As New Timer With {.Interval = interval}
        AddHandler fadeTimer.Tick,
        Sub()
            If targetForm.Opacity < 1 Then
                targetForm.Opacity += stepSize
            Else
                fadeTimer.Stop()
                fadeTimer.Dispose()
            End If
        End Sub
        fadeTimer.Start()
    End Sub

    ' ✅ Handle returning from Inventory
    Private Sub frmInterface_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If ReturningFromInventory Then
            LoadFormIntoPanel(dashboardForm)
            HighlightActiveButton(btnDashboard)
            ReturningFromInventory = False
        End If
    End Sub

    ' ✅ Load child form into panel
    Public Sub LoadFormIntoPanel(childForm As Form)
        mainPanel.SuspendLayout()
        For Each ctrl As Control In mainPanel.Controls
            ctrl.Hide()
        Next
        If Not mainPanel.Controls.Contains(childForm) Then
            childForm.TopLevel = False
            childForm.FormBorderStyle = FormBorderStyle.None
            childForm.Dock = DockStyle.Fill
            mainPanel.Controls.Add(childForm)
        End If
        childForm.Show()
        mainPanel.ResumeLayout()
    End Sub

    ' ✅ Highlight active button
    Private Sub HighlightActiveButton(clickedButton As Button)
        If activeButton IsNot Nothing AndAlso
           activeButton IsNot btnLogOut AndAlso
           activeButton IsNot btnExit AndAlso
           activeButton IsNot btnInventory Then

            activeButton.BackColor = Color.LightSlateGray
            activeButton.ForeColor = Color.White
        End If

        If clickedButton IsNot btnLogOut AndAlso
           clickedButton IsNot btnExit AndAlso
           clickedButton IsNot btnInventory Then

            clickedButton.BackColor = Color.SlateGray
            clickedButton.ForeColor = Color.White
            activeButton = clickedButton
        End If
    End Sub

    ' ===== BUTTON HANDLERS =====
    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        LoadFormIntoPanel(dashboardForm)
        HighlightActiveButton(btnDashboard)

        dashboardForm.RefreshDashboard()
    End Sub

    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click
        Dim inventoryForm As New InventoryPOS()
        ReturningFromInventory = True
        inventoryForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnPOS_Click(sender As Object, e As EventArgs) Handles btnPOS.Click
        If posForm Is Nothing OrElse posForm.IsDisposed Then
            posForm = New POSmain()
        End If

        Me.Hide()
        FadeInForm(posForm)
        posForm.Show()
    End Sub

    Private Sub btnAccounts_Click(sender As Object, e As EventArgs) Handles btnAccounts.Click
        If loggedInType = "Staff" Then
            MessageBox.Show("Access Denied. Staff cannot open Accounts.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        LoadFormIntoPanel(accountsForm)
        HighlightActiveButton(btnAccounts)
    End Sub

    Private Sub btnArch_Click(sender As Object, e As EventArgs) Handles btnArch.Click
        If loggedInType = "Staff" Then
            MessageBox.Show("Access Denied. Staff cannot open Archives.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        LoadFormIntoPanel(archivesForm)
        HighlightActiveButton(btnArch)
    End Sub

    Private Sub btnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        If loggedInType = "Staff" Then
            MessageBox.Show("Access Denied. Staff cannot open Logs.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        LoadFormIntoPanel(logsForm)
        HighlightActiveButton(btnLogs)
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?",
                                                 "Logout",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            InsertLog(loggedInUsername, "Logout", "Logged out successfully")

            ' ✅ Close all other open forms (prevents duplicates like POS)
            For Each f As Form In Application.OpenForms.OfType(Of Form).ToList()
                If Not TypeOf f Is frmLogin Then f.Close()
            Next

            ' ✅ Open login form cleanly
            Dim loginForm As New frmLogin()
            loginForm.Show()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim accountType As String = loggedInType

            Using cmdLog As New MySqlCommand("INSERT INTO log_historyPOS (Username, Action, Details, LogTime) VALUES (@Username, @Action, @Details, NOW())", conn)
                cmdLog.Parameters.AddWithValue("@Username", loggedInUsername)
                cmdLog.Parameters.AddWithValue("@Action", "Exit")
                cmdLog.Parameters.AddWithValue("@Details", "Exited: " & accountType)
                cmdLog.ExecuteNonQuery()
            End Using
            conn.Close()
            Application.Exit()
        Catch ex As Exception
            MessageBox.Show("Error logging exit: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSales_Click(sender As Object, e As EventArgs) Handles btnSales.Click
        Me.Hide()
        Dim saleForm As New SaleRep()
        AddHandler saleForm.FormClosed,
            Sub()
                FadeInForm(Me)
                ReturnToDashboard()
                Me.Show()
            End Sub
        FadeInForm(saleForm)
        saleForm.Show()
    End Sub

End Class
