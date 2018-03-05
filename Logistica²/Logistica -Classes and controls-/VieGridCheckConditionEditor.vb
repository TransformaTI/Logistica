
Public Class frmVieGridCheckConditionEditor
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef CheckCondition As Object)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        If Not CheckCondition Is Nothing Then
            Dim Condition As ViewGridCheckCondition
            Dim index As Integer
            _CheckCondition = CType(CheckCondition, ViewGridCheckCondition())
            For Each Condition In _CheckCondition
                lstMembers.Items.Add("CheckCondition" & index.ToString)
                index += 1
            Next
        End If
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblProperties As System.Windows.Forms.Label
    Friend WithEvents lblMembers As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grpBotones As System.Windows.Forms.GroupBox
    Friend WithEvents pnlProperties As System.Windows.Forms.Panel
    Friend WithEvents gpnlProperties As GroupPanel
    Friend WithEvents txtColumnName As System.Windows.Forms.TextBox
    Friend WithEvents lblColumName As System.Windows.Forms.Label
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lstMembers As System.Windows.Forms.ListBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents lblComparison As System.Windows.Forms.Label
    Friend WithEvents cboComparison As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblProperties = New System.Windows.Forms.Label()
        Me.lblMembers = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlProperties = New System.Windows.Forms.Panel()
        Me.gpnlProperties = New GroupPanel()
        Me.txtColumnName = New System.Windows.Forms.TextBox()
        Me.lblColumName = New System.Windows.Forms.Label()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lstMembers = New System.Windows.Forms.ListBox()
        Me.grpBotones = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.lblComparison = New System.Windows.Forms.Label()
        Me.cboComparison = New System.Windows.Forms.ComboBox()
        Me.pnlHeader.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlProperties.SuspendLayout()
        Me.gpnlProperties.SuspendLayout()
        Me.grpBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblProperties, Me.lblMembers})
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(498, 24)
        Me.pnlHeader.TabIndex = 1
        '
        'lblProperties
        '
        Me.lblProperties.AutoSize = True
        Me.lblProperties.Location = New System.Drawing.Point(216, 5)
        Me.lblProperties.Name = "lblProperties"
        Me.lblProperties.Size = New System.Drawing.Size(58, 14)
        Me.lblProperties.TabIndex = 0
        Me.lblProperties.Text = "Properties:"
        '
        'lblMembers
        '
        Me.lblMembers.AutoSize = True
        Me.lblMembers.Location = New System.Drawing.Point(8, 5)
        Me.lblMembers.Name = "lblMembers"
        Me.lblMembers.Size = New System.Drawing.Size(54, 14)
        Me.lblMembers.TabIndex = 0
        Me.lblMembers.Text = "Members:"
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlProperties, Me.btnRemove, Me.btnAdd, Me.lstMembers})
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(498, 394)
        Me.Panel1.TabIndex = 2
        '
        'pnlProperties
        '
        Me.pnlProperties.BackColor = System.Drawing.Color.White
        Me.pnlProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProperties.Controls.AddRange(New System.Windows.Forms.Control() {Me.gpnlProperties})
        Me.pnlProperties.Location = New System.Drawing.Point(217, 9)
        Me.pnlProperties.Name = "pnlProperties"
        Me.pnlProperties.Size = New System.Drawing.Size(272, 328)
        Me.pnlProperties.TabIndex = 8
        '
        'gpnlProperties
        '
        Me.gpnlProperties.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboComparison, Me.txtColumnName, Me.lblColumName, Me.lblValue, Me.txtValue, Me.lblComparison})
        Me.gpnlProperties.DividerColor = System.Drawing.SystemColors.Control
        Me.gpnlProperties.GroupPanelState = GroupPanel.PanelState.Expanded
        Me.gpnlProperties.Location = New System.Drawing.Point(8, 8)
        Me.gpnlProperties.Name = "gpnlProperties"
        Me.gpnlProperties.PanelStateEffect = GroupPanel.MovementEffect.MoveAlignedControls
        Me.gpnlProperties.Size = New System.Drawing.Size(248, 120)
        Me.gpnlProperties.TabIndex = 0
        Me.gpnlProperties.Title = "Properties"
        Me.gpnlProperties.TitleBackColor = System.Drawing.SystemColors.Control
        Me.gpnlProperties.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpnlProperties.TitleForeColor = System.Drawing.SystemColors.ControlText
        Me.gpnlProperties.Visible = False
        '
        'txtColumnName
        '
        Me.txtColumnName.Location = New System.Drawing.Point(111, 29)
        Me.txtColumnName.Name = "txtColumnName"
        Me.txtColumnName.Size = New System.Drawing.Size(122, 21)
        Me.txtColumnName.TabIndex = 1
        Me.txtColumnName.Text = ""
        '
        'lblColumName
        '
        Me.lblColumName.AutoSize = True
        Me.lblColumName.Location = New System.Drawing.Point(26, 32)
        Me.lblColumName.Name = "lblColumName"
        Me.lblColumName.Size = New System.Drawing.Size(77, 14)
        Me.lblColumName.TabIndex = 0
        Me.lblColumName.Text = "&Column name:"
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Location = New System.Drawing.Point(26, 60)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(36, 14)
        Me.lblValue.TabIndex = 1
        Me.lblValue.Text = "&Value:"
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(111, 57)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(122, 21)
        Me.txtValue.TabIndex = 2
        Me.txtValue.Text = ""
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(109, 297)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.TabIndex = 7
        Me.btnRemove.Text = "Remove"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(21, 297)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "Add"
        '
        'lstMembers
        '
        Me.lstMembers.Location = New System.Drawing.Point(9, 9)
        Me.lstMembers.Name = "lstMembers"
        Me.lstMembers.Size = New System.Drawing.Size(192, 277)
        Me.lstMembers.TabIndex = 5
        '
        'grpBotones
        '
        Me.grpBotones.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnOk})
        Me.grpBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpBotones.Location = New System.Drawing.Point(0, 362)
        Me.grpBotones.Name = "grpBotones"
        Me.grpBotones.Size = New System.Drawing.Size(498, 56)
        Me.grpBotones.TabIndex = 3
        Me.grpBotones.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(408, 20)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New System.Drawing.Point(320, 20)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.TabIndex = 8
        Me.btnOk.Text = "Ok"
        '
        'lblComparison
        '
        Me.lblComparison.AutoSize = True
        Me.lblComparison.Location = New System.Drawing.Point(26, 88)
        Me.lblComparison.Name = "lblComparison"
        Me.lblComparison.Size = New System.Drawing.Size(67, 14)
        Me.lblComparison.TabIndex = 2
        Me.lblComparison.Text = "C&omparison:"
        '
        'cboComparison
        '
        Me.cboComparison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboComparison.Items.AddRange(New Object() {"Equal", "Lower", "Higher", "Diferent", "StartsWith", "EndsWith", "Contains"})
        Me.cboComparison.Location = New System.Drawing.Point(111, 85)
        Me.cboComparison.Name = "cboComparison"
        Me.cboComparison.Size = New System.Drawing.Size(122, 21)
        Me.cboComparison.TabIndex = 3
        '
        'frmVieGridCheckConditionEditor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(498, 418)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpBotones, Me.Panel1, Me.pnlHeader})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmVieGridCheckConditionEditor"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VieGrid CheckCondition Editor"
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlProperties.ResumeLayout(False)
        Me.gpnlProperties.ResumeLayout(False)
        Me.grpBotones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public _CheckCondition() As ViewGridCheckCondition

    Private Sub lstMembers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMembers.SelectedIndexChanged
        If lstMembers.SelectedIndex >= 0 Then
            gpnlProperties.Visible = True
            If Not _CheckCondition(lstMembers.SelectedIndex).ColumnName Is Nothing Then
                txtColumnName.Text = _CheckCondition(lstMembers.SelectedIndex).ColumnName
            End If
            If Not _CheckCondition(lstMembers.SelectedIndex).Value Is Nothing Then
                txtValue.Text = _CheckCondition(lstMembers.SelectedIndex).Value
            End If
            cboComparison.SelectedIndex = CInt(_CheckCondition(lstMembers.SelectedIndex).Comparison)
        Else
            gpnlProperties.Visible = False
        End If
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim index As Integer
        If Not _CheckCondition Is Nothing Then
            ReDim Preserve _CheckCondition(_CheckCondition.Length)
        Else
            ReDim Preserve _CheckCondition(0)
        End If
        For index = 0 To lstMembers.Items.Count - 1
            If lstMembers.Items.IndexOf("CheckCondition" & index.ToString) < 0 Then
                Exit For
            End If
        Next
        lstMembers.SelectedItem = lstMembers.Items.Add("CheckCondition" & index.ToString)
        _CheckCondition(lstMembers.Items.Count - 1) = New ViewGridCheckCondition()
        _CheckCondition(lstMembers.Items.Count - 1).Comparison = 0
    End Sub
    Private Sub txtColumnName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtColumnName.Leave
        _CheckCondition(lstMembers.SelectedIndex).ColumnName = txtColumnName.Text
    End Sub
    Private Sub txtValue_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValue.Leave
        _CheckCondition(lstMembers.SelectedIndex).Value = txtValue.Text
    End Sub
    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If lstMembers.SelectedIndex >= 0 Then
            Dim index As Integer
            Dim indexb As Integer
            If _CheckCondition.Length > 1 Then
                index = _CheckCondition.Length - 2
            Else
                Dim tempArray() As ViewGridCheckCondition = Nothing
                _CheckCondition = tempArray
                lstMembers.Items.RemoveAt(lstMembers.SelectedIndex)
                Exit Sub
            End If
            Dim tempArrayB(index) As ViewGridCheckCondition
            For index = 0 To _CheckCondition.Length - 1
                If index <> lstMembers.SelectedIndex Then
                    tempArrayB(indexb) = _CheckCondition(index)
                    indexb += 1
                End If
            Next
            _CheckCondition = tempArrayB
            lstMembers.Items.RemoveAt(lstMembers.SelectedIndex)
        End If
    End Sub


    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cboComparison_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboComparison.SelectedIndexChanged
        If cboComparison.SelectedIndex >= 0 Then
            _CheckCondition(lstMembers.SelectedIndex).Comparison = CType(cboComparison.SelectedIndex, ViewGridCheckCondition.ViewGridCheckConditionComparison)
        End If
    End Sub
End Class
