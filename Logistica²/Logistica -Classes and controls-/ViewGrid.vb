
''''''''''''''''''''''''''''''''''''''''''''''''
'   ListView adaptado para funcionar como grid  '
'Autor: Manuel Ruiz                             '
'Fecha: 26 de marzo de 2004                     '
'Descripción: Este control facilita el uso de   '
'             un control ListView como grid     '
'                                               '
'''''''''''''''''''''''''''''''''''''''''''''''''

Imports System.ComponentModel
Imports System.Windows.Forms.Design
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design

Class CheckConditionEditor
    Inherits UITypeEditor
    Overloads Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As UITypeEditorEditStyle
        If Not context Is Nothing AndAlso Not (context.Instance Is Nothing) Then
            Return UITypeEditorEditStyle.Modal
        Else
            Return MyBase.GetEditStyle
        End If
    End Function

    Dim wfes As IWindowsFormsEditorService

    Overloads Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object
        If (context Is Nothing) OrElse (context.Instance Is Nothing) OrElse (provider Is Nothing) Then
            Return value
        End If
        wfes = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
        If wfes Is Nothing Then
            Return value
        End If
        Dim frmVieGridCheckConditionEditor As New frmVieGridCheckConditionEditor(value)
        If wfes.ShowDialog(frmVieGridCheckConditionEditor) = DialogResult.OK Then
            value = frmVieGridCheckConditionEditor._CheckCondition
            frmVieGridCheckConditionEditor.Dispose()
        End If
        Return value
    End Function
End Class

<LicenseProvider(GetType(ECRALicenseProvider)), Serializable()> _
Public Class ViewGrid
    Inherits System.Windows.Forms.ListView

#Region " Windows Form Designer generated code "

    Private license As license = Nothing

    Public Sub New()
        MyBase.New()
        license = LicenseManager.Validate(GetType(ViewGrid), Me)

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'DataGridListView
        '
        Me.FullRowSelect = True
        Me.GridLines = True
        Me.View = System.Windows.Forms.View.Details

    End Sub

#End Region


#Region "Global variables"
    Private _CheckCondition() As ViewGridCheckCondition
    Private _DataSource As Object
    Private _NullText As String = "Null"
    Private _AlternativeBackColor As Color = Color.Gainsboro
    Private _HidedColumnNames(0) As String
    Private _SourceViewColumnCorrespondence() As Integer
    Private _PKColumnsNames() As String
    Private _HighlightBackColor As Color = Color.Red
    Private _HighlightForeColor As Color = Color.White
#End Region

#Region "Properties"
    <Description("Especifies the conditions for a row to be checked."), Category("Behavior"), _
       Editor(GetType(CheckConditionEditor), GetType(UITypeEditor))> _
    Property CheckCondition() As ViewGridCheckCondition()
        Get
            Return _CheckCondition
        End Get
        Set(ByVal Value As ViewGridCheckCondition())
            _CheckCondition = Value
        End Set
    End Property
    <Description("The table containing the data to be shown"), Category("Data")> _
        Property DataSource() As Object
        Get
            Return _DataSource
        End Get
        Set(ByVal Value As Object)
            _DataSource = Value
            ChangeSource()
        End Set
    End Property
    <Description("The text to be shown when a null value is found"), Category("Appearence"), _
     DefaultValue("Null")> _
    Property NullText() As String
        Get
            Return _NullText
        End Get
        Set(ByVal Value As String)
            _NullText = Value
            If Not _DataSource Is Nothing Then
                ChangeSource()
            End If
        End Set
    End Property
    <Description("The color to be shown between row and row"), Category("Appearence")> _
    Property AlternativeBackColor() As Color
        Get
            Return _AlternativeBackColor
        End Get
        Set(ByVal Value As Color)
            _AlternativeBackColor = Value
            If Not _DataSource Is Nothing Then
                ChangeSource()
            End If
        End Set
    End Property
    <Description("Contains the list of the column names to be hided"), Category("Behavior")> _
    Property HidedColumnNames() As String()
        Get
            Return _HidedColumnNames
        End Get
        Set(ByVal Value As String())
            _HidedColumnNames = Value
            If Not _DataSource Is Nothing Then
                ChangeSource()
            End If
        End Set
    End Property
    <Description("Contains the list of the PK column names"), Category("Behavior")> _
 Property PKColumnNames() As String()
        Get
            Return _PKColumnsNames
        End Get
        Set(ByVal Value As String())
            _PKColumnsNames = Value
        End Set
    End Property
    <Browsable(False), Description("Returns the current selected row"), Category("Data")> _
    ReadOnly Property CurrentRow() As DataRow
        Get
            If Me.SelectedItems.Count > 0 Then
                Return CType(Me.SelectedItems(0).Tag, DataRow)
            End If
        End Get
    End Property
    <Browsable(False)> _
    ReadOnly Property CurrentPK() As Object
        Get
            If Me.SelectedItems.Count > 0 And Not _PKColumnsNames Is Nothing Then
                Dim PK(_PKColumnsNames.Length - 1) As Object
                Dim ColumnName As String
                Dim index As Integer
                For Each ColumnName In _PKColumnsNames

                    PK(index) = CType(Me.SelectedItems(0).Tag, DataRow).Item(ColumnName)
                    index += 1
                Next
                Return PK
            End If
        End Get
    End Property

#End Region

#Region "Overloaded properties"
    <Browsable(False)> _
             Shadows ReadOnly Property AllowColumnReorder() As Boolean
        Get
            Return False
        End Get
    End Property
    <Browsable(False)> _
             Shadows ReadOnly Property AutoArrange() As Boolean
        Get
            Return False
        End Get
    End Property
    <Browsable(False)> _
      Shadows ReadOnly Property HeaderStyle() As ColumnHeaderStyle
        Get
            Return ColumnHeaderStyle.Clickable
        End Get
    End Property
    <Browsable(False)> _
        Shadows ReadOnly Property LabelEdit() As Boolean
        Get
            Return False
        End Get
    End Property
    <Browsable(False)> _
        Shadows ReadOnly Property LargeImageList() As ImageList
        Get
            Return Nothing
        End Get
    End Property
    <Browsable(False)> _
        Shadows ReadOnly Property SmallImageList() As ImageList
        Get
            Return Nothing
        End Get
    End Property
    <Browsable(False)> _
        Shadows ReadOnly Property StateImageList() As ImageList
        Get
            Return Nothing
        End Get
    End Property

#End Region

#Region "Privated sub's and functions"
    Private Sub ChangeSource()
        Me.Items.Clear()
        Me.Columns.Clear()
        If Not _DataSource Is Nothing Then
            Select Case _DataSource.GetType.Name
                Case "DataTable"
                    LoadFromTable()
                Case "DataView"
                    ConvertToTable()
                    LoadFromTable()
                Case Else
                    Dim ex As New Exception("Wrong data source type")
                    Throw ex
            End Select
        End If
    End Sub
    Private Sub LoadFromTable()
        Dim Column As DataColumn
        Dim Row As DataRow
        Dim index As Integer = -1
        Dim ColumnWidth As Integer
        Dim ABackColor As Color = Me.BackColor
        Dim ParentItem As ListViewItem
        Dim pointer As Integer
        Dim Condition As ViewGridCheckCondition
        Dim Source As DataTable = CType(_DataSource, DataTable)
        For Each Column In Source.Columns
            If Array.IndexOf(_HidedColumnNames, Column.ColumnName) >= 0 Then
                ColumnWidth += 1
            End If
        Next
        ReDim Preserve _SourceViewColumnCorrespondence(Source.Columns.Count - ColumnWidth - 1)
        ColumnWidth = CInt((Me.Width - 20) / (Source.Columns.Count - ColumnWidth))

        For Each Column In Source.Columns
            If Not Array.IndexOf(_HidedColumnNames, Column.ColumnName) >= 0 Then
                Me.Columns.Add(Column.Caption, ColumnWidth, HorizontalAlignment.Left)
                _SourceViewColumnCorrespondence(pointer) = Source.Columns.IndexOf(Column)
                pointer += 1
                If index = -1 Then
                    index = Source.Columns.IndexOf(Column)
                End If
            End If
        Next
        ColumnWidth = index
        For Each Row In Source.Rows
            ParentItem = Me.Items.Add("")
            ParentItem.Tag = Row
            If ABackColor.ToArgb = Me.BackColor.ToArgb Then
                ABackColor = _AlternativeBackColor
            Else
                ABackColor = Me.BackColor
            End If

            For index = ColumnWidth To Source.Columns.Count - 1
                Dim Item As String
                If Array.IndexOf(_HidedColumnNames, Source.Columns(index).ColumnName) < 0 Then
                    If Not Microsoft.VisualBasic.IsDBNull(Row(index)) Then
                        If CStr(Row(index)) = "True" Then
                            Item = "Sí"
                        ElseIf CStr(Row(index)) = "False" Then

                            Item = "No"
                        Else
                            Item = CStr(Row(index))
                        End If
                    Else
                        Item = _NullText
                    End If
                    ParentItem.SubItems.Add(Item).BackColor = ABackColor
                End If
            Next
            If Me.CheckBoxes AndAlso Not _CheckCondition Is Nothing Then
                For Each Condition In _CheckCondition
                    If CStr(Row(Condition.ColumnName)) = Condition.Value Then
                        ParentItem.Checked = True
                    End If
                Next
            End If
            ParentItem.SubItems.RemoveAt(0)
            ParentItem.UseItemStyleForSubItems = False
        Next
    End Sub
    Private Sub ConvertToTable()
        Dim dtSource As New DataTable()
        Dim RowIndex, ColumnIndex As Integer
        Dim IArray(CType(_DataSource, DataView).Table.Columns.Count - 1) As Object
        dtSource = CType(_DataSource, DataView).Table.Clone
        For RowIndex = 0 To CType(_DataSource, DataView).Count - 1
            For ColumnIndex = 0 To CType(_DataSource, DataView).Table.Columns.Count - 1
                IArray(ColumnIndex) = CType(_DataSource, DataView).Item(RowIndex)(ColumnIndex)
            Next
            dtSource.Rows.Add(IArray)
        Next
        _DataSource = dtSource
    End Sub



    Private Sub DataGridListView_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles MyBase.ColumnClick
        If _DataSource Is Nothing Then
            Exit Sub
        End If
        If Me.Sorting = SortOrder.Ascending Then
            CType(_DataSource, DataTable).DefaultView.Sort = CType(_DataSource, DataTable).Columns(_SourceViewColumnCorrespondence(e.Column)).ColumnName & " DESC"
            Me.Sorting = SortOrder.Descending
        Else
            CType(_DataSource, DataTable).DefaultView.Sort = CType(_DataSource, DataTable).Columns(_SourceViewColumnCorrespondence(e.Column)).ColumnName & " ASC"
            Me.Sorting = SortOrder.Ascending
        End If
        _DataSource = CType(_DataSource, DataTable).DefaultView
        ChangeSource()
    End Sub
#End Region

#Region "Public sub's and functions"
    Public Sub ClearHighlights()
        ChangeSource()
    End Sub
    Public Sub HighlightRow(ByVal RowIndex As Integer, ByVal HBackColor As Color, ByVal HForeColor As Color)
        Me.Items(RowIndex).BackColor = HBackColor
        Me.Items(RowIndex).ForeColor = HForeColor
    End Sub
    Public Sub HighlightColumn(ByVal CellIndex As Integer, ByVal HBackColor As Color, ByVal HForeColor As Color)
        Dim item As ListViewItem
        For Each item In Me.Items
            item.SubItems(CellIndex).BackColor = HBackColor
            item.SubItems(CellIndex).ForeColor = HForeColor
        Next
    End Sub
    Public Sub HighlightItem(ByVal RowIndex As Integer, ByVal CellIndex As Integer, ByVal HBackColor As Color, ByVal HForeColor As Color)
        Me.Items(RowIndex).SubItems(CellIndex).BackColor = HBackColor
        Me.Items(RowIndex).SubItems(CellIndex).ForeColor = HForeColor
    End Sub
    Public Function FindFirst(ByVal ColumnName As String, ByVal Value As String, Optional ByVal HighLight As Boolean = True) As Integer
        Dim Row As DataRow
        Dim item As ListViewItem
        For Each Row In CType(_DataSource, DataTable).Rows
            If CStr(Row(ColumnName)) = Value Then
                For Each item In Me.Items
                    If CType(item.Tag, DataRow) Is Row Then
                        If HighLight Then
                            item.Selected = True
                        End If
                        Return item.Index
                    End If
                Next
            End If
        Next
        Return -1
    End Function
#End Region


End Class

