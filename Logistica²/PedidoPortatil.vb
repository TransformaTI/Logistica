Imports System.Data.SqlClient
Imports System.Configuration

Public Class frmPedidoPortatil
    Inherits System.Windows.Forms.Form    



#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Cliente As Integer, ByVal Pedido As Integer, ByVal Remision As String, Optional ByVal PermitirCambios As Boolean = False)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Dim daCallCenter As New SqlDataAdapter("spCCConsultaProductosPtl @ZonaEconomica = " & ZonaEconomica, cnSigamet)

        _Cliente = Cliente
        _Pedido = Pedido

        Me.Text = "Pedido portátil: " & Pedido & " " & Remision & " Cliente: " & Cliente
        Try
            daCallCenter.Fill(dtProducto)
            grdDetalle.DataSource = dtProducto
            maxProducto = dtProducto.Rows.Count
            CargaDatos(PermitirCambios)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
    Friend WithEvents grpPedido As System.Windows.Forms.GroupBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblFAlta As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lblFCompromiso As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents txtFAlta As System.Windows.Forms.TextBox
    Friend WithEvents dtpFCompromiso As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents tbsDetalle As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colProducto As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCantidad As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents grdDetalle As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidoPortatil))
        Me.grpPedido = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFCompromiso = New System.Windows.Forms.DateTimePicker()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblFAlta = New System.Windows.Forms.Label()
        Me.lblFCompromiso = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtFAlta = New System.Windows.Forms.TextBox()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.grpDetalle = New System.Windows.Forms.GroupBox()
        Me.grdDetalle = New System.Windows.Forms.DataGrid()
        Me.tbsDetalle = New System.Windows.Forms.DataGridTableStyle()
        Me.colProducto = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCantidad = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.grpPedido.SuspendLayout()
        Me.grpDetalle.SuspendLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpPedido
        '
        Me.grpPedido.Controls.Add(Me.txtObservaciones)
        Me.grpPedido.Controls.Add(Me.Label1)
        Me.grpPedido.Controls.Add(Me.dtpFCompromiso)
        Me.grpPedido.Controls.Add(Me.lblCliente)
        Me.grpPedido.Controls.Add(Me.lblFAlta)
        Me.grpPedido.Controls.Add(Me.lblFCompromiso)
        Me.grpPedido.Controls.Add(Me.txtCliente)
        Me.grpPedido.Controls.Add(Me.txtFAlta)
        Me.grpPedido.Controls.Add(Me.txtRuta)
        Me.grpPedido.Controls.Add(Me.lblRuta)
        Me.grpPedido.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpPedido.Location = New System.Drawing.Point(3, 0)
        Me.grpPedido.Name = "grpPedido"
        Me.grpPedido.Size = New System.Drawing.Size(425, 183)
        Me.grpPedido.TabIndex = 0
        Me.grpPedido.TabStop = False
        Me.grpPedido.Text = "Pedido"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Obs. cancelación:"
        '
        'dtpFCompromiso
        '
        Me.dtpFCompromiso.Enabled = False
        Me.dtpFCompromiso.Location = New System.Drawing.Point(112, 111)
        Me.dtpFCompromiso.Name = "dtpFCompromiso"
        Me.dtpFCompromiso.Size = New System.Drawing.Size(200, 21)
        Me.dtpFCompromiso.TabIndex = 1
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(8, 24)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(44, 13)
        Me.lblCliente.TabIndex = 0
        Me.lblCliente.Text = "Cliente:"
        '
        'lblFAlta
        '
        Me.lblFAlta.AutoSize = True
        Me.lblFAlta.Location = New System.Drawing.Point(8, 54)
        Me.lblFAlta.Name = "lblFAlta"
        Me.lblFAlta.Size = New System.Drawing.Size(76, 13)
        Me.lblFAlta.TabIndex = 0
        Me.lblFAlta.Text = "Fecha de alta:"
        '
        'lblFCompromiso
        '
        Me.lblFCompromiso.AutoSize = True
        Me.lblFCompromiso.Location = New System.Drawing.Point(8, 114)
        Me.lblFCompromiso.Name = "lblFCompromiso"
        Me.lblFCompromiso.Size = New System.Drawing.Size(99, 13)
        Me.lblFCompromiso.TabIndex = 0
        Me.lblFCompromiso.Text = "&Fecha compromiso:"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente.Location = New System.Drawing.Point(112, 21)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(296, 21)
        Me.txtCliente.TabIndex = 1
        Me.txtCliente.TabStop = False
        '
        'txtFAlta
        '
        Me.txtFAlta.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFAlta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFAlta.Location = New System.Drawing.Point(112, 51)
        Me.txtFAlta.Name = "txtFAlta"
        Me.txtFAlta.ReadOnly = True
        Me.txtFAlta.Size = New System.Drawing.Size(200, 21)
        Me.txtFAlta.TabIndex = 1
        Me.txtFAlta.TabStop = False
        '
        'txtRuta
        '
        Me.txtRuta.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuta.Location = New System.Drawing.Point(112, 81)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.Size = New System.Drawing.Size(48, 21)
        Me.txtRuta.TabIndex = 1
        Me.txtRuta.TabStop = False
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Location = New System.Drawing.Point(8, 84)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(34, 13)
        Me.lblRuta.TabIndex = 0
        Me.lblRuta.Text = "Ruta:"
        '
        'grpDetalle
        '
        Me.grpDetalle.Controls.Add(Me.grdDetalle)
        Me.grpDetalle.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpDetalle.Location = New System.Drawing.Point(3, 183)
        Me.grpDetalle.Name = "grpDetalle"
        Me.grpDetalle.Size = New System.Drawing.Size(425, 155)
        Me.grpDetalle.TabIndex = 1
        Me.grpDetalle.TabStop = False
        Me.grpDetalle.Text = "Detalle"
        '
        'grdDetalle
        '
        Me.grdDetalle.AllowSorting = False
        Me.grdDetalle.AlternatingBackColor = System.Drawing.Color.Lavender
        Me.grdDetalle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdDetalle.BackgroundColor = System.Drawing.Color.LightGray
        Me.grdDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdDetalle.CaptionBackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDetalle.CaptionForeColor = System.Drawing.Color.MidnightBlue
        Me.grdDetalle.CaptionVisible = False
        Me.grdDetalle.DataMember = ""
        Me.grdDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDetalle.FlatMode = True
        Me.grdDetalle.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.grdDetalle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.grdDetalle.GridLineColor = System.Drawing.Color.Gainsboro
        Me.grdDetalle.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.grdDetalle.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.grdDetalle.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.grdDetalle.HeaderForeColor = System.Drawing.Color.WhiteSmoke
        Me.grdDetalle.LinkColor = System.Drawing.Color.Teal
        Me.grdDetalle.Location = New System.Drawing.Point(3, 17)
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.ParentRowsBackColor = System.Drawing.Color.Gainsboro
        Me.grdDetalle.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.grdDetalle.RowHeaderWidth = 5
        Me.grdDetalle.SelectionBackColor = System.Drawing.Color.CadetBlue
        Me.grdDetalle.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.grdDetalle.Size = New System.Drawing.Size(419, 135)
        Me.grdDetalle.TabIndex = 0
        Me.grdDetalle.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.tbsDetalle})
        '
        'tbsDetalle
        '
        Me.tbsDetalle.AlternatingBackColor = System.Drawing.Color.Lavender
        Me.tbsDetalle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbsDetalle.DataGrid = Me.grdDetalle
        Me.tbsDetalle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.tbsDetalle.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colProducto, Me.colCantidad})
        Me.tbsDetalle.GridLineColor = System.Drawing.Color.Gainsboro
        Me.tbsDetalle.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.tbsDetalle.HeaderForeColor = System.Drawing.Color.WhiteSmoke
        Me.tbsDetalle.LinkColor = System.Drawing.Color.Teal
        Me.tbsDetalle.SelectionBackColor = System.Drawing.Color.CadetBlue
        Me.tbsDetalle.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        '
        'colProducto
        '
        Me.colProducto.Format = ""
        Me.colProducto.FormatInfo = Nothing
        Me.colProducto.HeaderText = "Producto"
        Me.colProducto.MappingName = "Descripcion"
        Me.colProducto.ReadOnly = True
        Me.colProducto.Width = 325
        '
        'colCantidad
        '
        Me.colCantidad.Format = ""
        Me.colCantidad.FormatInfo = Nothing
        Me.colCantidad.HeaderText = "Cantidad"
        Me.colCantidad.MappingName = "Cantidad"
        Me.colCantidad.NullText = "0"
        Me.colCantidad.Width = 70
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(112, 365)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(224, 365)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(112, 145)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(296, 21)
        Me.txtObservaciones.TabIndex = 3
        '
        'frmPedidoPortatil
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(431, 401)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.grpDetalle)
        Me.Controls.Add(Me.grpPedido)
        Me.Controls.Add(Me.btnCancelar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPedidoPortatil"
        Me.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.grpPedido.ResumeLayout(False)
        Me.grpPedido.PerformLayout()
        Me.grpDetalle.ResumeLayout(False)
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables globales"
    Private _Cliente, _Pedido As Integer
    Private _Remision As String
    Private dtProducto As New DataTable()
    Private dtProductoOriginal As New DataTable()
    Private maxProducto As Integer
    Private ZonaEconomica As Short
#End Region
#Region "Rutinas de carga de datos"
    Private Sub CargaDatos(ByVal PermitirCambios As Boolean)
        Dim cmdCallCenter As New SqlCommand("exec spCCDatosPedidoPortatil @Cliente, @Pedido", cnSigamet)
        Dim daCallCenter As New SqlDataAdapter(cmdCallCenter)
        Dim rdPedido As SqlDataReader
        cmdCallCenter.Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
        cmdCallCenter.Parameters.Add("@Pedido", SqlDbType.Int).Value = _Pedido
        Try
            AbreConexion()
            rdPedido = cmdCallCenter.ExecuteReader
            rdPedido.Read()
            txtCliente.Text = CStr(rdPedido("Nombre"))
            txtRuta.Text = CStr(rdPedido("Ruta"))

            _Pedido = CInt(rdPedido("PedidoPortatil"))
            txtFAlta.Text = CStr(rdPedido("FAlta"))
            dtpFCompromiso.Value = CDate(rdPedido("FCompromiso"))

            If Not Microsoft.VisualBasic.IsDBNull(rdPedido("ZonaEconomica")) Then
                ZonaEconomica = CShort(CInt(rdPedido("ZonaEconomica")))
            End If
            cmdCallCenter.CommandText = "exec spCCDetallePedidoPortatilAtendido @Pedido,@ZonaEconomica"
            cmdCallCenter.Parameters("@Pedido").Value = _Pedido
            cmdCallCenter.Parameters.Add("@ZonaEconomica", SqlDbType.TinyInt).Value = ZonaEconomica
            rdPedido.Close()
            dtProducto.Clear()
            daCallCenter.Fill(dtProducto)
            grdDetalle.DataSource = dtProducto
            maxProducto = dtProducto.Rows.Count

            If dtProducto.Rows.Count > 0 Then
                dtProductoOriginal = dtProducto.Copy()
            End If



            If Not PermitirCambios Then
                grdDetalle.Enabled = False
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CierraConexion()
        End Try
    End Sub
#End Region

    Private Sub grdDetalle_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDetalle.CurrentCellChanged
        On Error Resume Next
        If grdDetalle.CurrentCell.RowNumber < maxProducto Then
            grdDetalle.Select(grdDetalle.CurrentCell.RowNumber)
        Else
            dtProducto.AcceptChanges()
            grdDetalle.DataSource = dtProducto
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim Row, Row2 As DataRow
        Dim Modificar As Boolean = False
        Dim Cancelar As Boolean = 0
        Dim Msj As String

        For Each Row In dtProducto.Rows
            If Microsoft.VisualBasic.IsDBNull(Row("Cantidad")) Then
                Row("Cantidad") = 0
            End If
            For Each Row2 In dtProductoOriginal.Rows
                If Row("Producto") = Row2("Producto") And Row("Cantidad") <> Row2("Cantidad") Then
                    Modificar = True
                End If
            Next
        Next
        dtProducto.AcceptChanges()
        If Convert.ToInt32(dtProducto.Compute("Sum(Cantidad)", "")) > 0 Then
            Msj = "¿Desea cambiar el detalle del pedido " & _Pedido & " " & _Remision & "?"
        Else
            Msj = "El detalle del pedido quedó en ceros ¿Desea cancelar el pedido " & _Pedido & " " & _Remision & "?"
            Cancelar = True
        End If


        If Modificar Then
            If MessageBox.Show(Msj, "Soporte móvil", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                Dim cmdCallCenter As New SqlCommand("", cnSigamet)
                Try
                    AbreConexion()
                    cmdCallCenter.CommandText = "Delete PedidoportatilAtendido Where PedidoPortatil = @PedidoPortatil"
                    cmdCallCenter.Transaction = cnSigamet.BeginTransaction()
                    cmdCallCenter.Parameters.Add("@PedidoPortatil", SqlDbType.Int).Value = _Pedido
                    cmdCallCenter.ExecuteNonQuery()


                    cmdCallCenter.CommandText = "spCCRegistraBitacoraPedidoPortatilAtendido"
                    cmdCallCenter.CommandType = CommandType.StoredProcedure
                    cmdCallCenter.Parameters.Add("@FModificacion", SqlDbType.DateTime).Value = Now()
                    cmdCallCenter.Parameters.Add("@Producto", SqlDbType.SmallInt)
                    cmdCallCenter.Parameters.Add("@Cantidad", SqlDbType.TinyInt)
                    cmdCallCenter.Parameters.Add("@UsuarioModifico", SqlDbType.VarChar).Value = _Usuario
                    For Each Row2 In dtProductoOriginal.Rows
                        If Not Microsoft.VisualBasic.IsDBNull(Row2("Cantidad")) AndAlso CInt(Row2("Cantidad")) > 0 Then
                            cmdCallCenter.Parameters("@Producto").Value = CInt(Row2("Producto"))
                            cmdCallCenter.Parameters("@Cantidad").Value = CInt(Row2("Cantidad"))
                            cmdCallCenter.ExecuteNonQuery()
                        End If
                    Next

                    cmdCallCenter.Parameters.Clear()


                    If Not Cancelar Then
                        cmdCallCenter.CommandText = "spCCInsertaPedidoPortatilAtendido"

                        cmdCallCenter.Parameters.Add("@PedidoPortatil", SqlDbType.Int).Value = _Pedido
                        cmdCallCenter.Parameters.Add("@Producto", SqlDbType.SmallInt)
                        cmdCallCenter.Parameters.Add("@Cantidad", SqlDbType.TinyInt)
                        For Each Row In dtProducto.Rows
                            If Not Microsoft.VisualBasic.IsDBNull(Row("Cantidad")) AndAlso CInt(Row("Cantidad")) > 0 Then
                                cmdCallCenter.Parameters("@Producto").Value = CInt(Row("Producto"))
                                cmdCallCenter.Parameters("@Cantidad").Value = CInt(Row("Cantidad"))
                                cmdCallCenter.ExecuteNonQuery()
                            End If
                        Next
                    Else
                        cmdCallCenter.CommandText = "spCCPedidoPortatilCancela"
                        cmdCallCenter.Parameters.Add("@Pedido", SqlDbType.Int).Value = _Pedido
                        'El motivocancelacion = 908 corresponde a Operación incorrecta móvil
                        cmdCallCenter.Parameters.Add("@MotivoCancelacion", SqlDbType.Int).Value = 908
                        cmdCallCenter.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = txtObservaciones.Text
                        cmdCallCenter.Parameters.Add("@StatusMG", SqlDbType.VarChar).Value = "CANCELADO"                        

                        cmdCallCenter.ExecuteNonQuery()
                    End If

                    cmdCallCenter.Transaction.Commit()

                    If Not Cancelar Then
                        MessageBox.Show("El detalle del pedido fué modificado.", "Soporte móvil.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("El pedido se canceló.", "Soporte móvil.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If


                    Me.Close()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Catch ex As Exception
                    cmdCallCenter.Transaction.Rollback()
                    MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    CierraConexion()
                End Try
            Else
                Exit Sub
            End If
        Else
            MessageBox.Show("No se han realizado cambios al pedido.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
            grdDetalle.Focus()
        End If
    End Sub

    Private Sub grdDetalle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles grdDetalle.KeyDown
    End Sub

    Private Sub grdDetalle_PreviewKeyDown(sender As System.Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles grdDetalle.PreviewKeyDown
        If e.KeyCode = 46 Then
            grdDetalle.ReadOnly = True
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey( _
               ByRef msg As Message, _
               ByVal keyData As Keys) As Boolean

        ' Si el control DataGrid no tiene el foco, abandonamos la función.
        '
        If (Not (m_IsDataGridFocused)) Then
            Return False
        End If


        ' Si se ha pulsado la tecla Supr, abandonamos la función.
        If (keyData = Keys.Delete) Then
            Return True
        Else
            grdDetalle.ReadOnly = False
            Return False
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)

    End Function

    Private m_IsDataGridFocused As Boolean

    Private Sub grdDetalle_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles grdDetalle.Enter

        m_IsDataGridFocused = True

    End Sub

    Private Sub grdDetalle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles grdDetalle.MouseClick

        m_IsDataGridFocused = True

    End Sub

    Private Sub grdDetalle_MousseDown(ByVal sender As Object, ByVal e As EventArgs) Handles grdDetalle.MouseDown

        m_IsDataGridFocused = True

    End Sub
    Private Sub grdDetalle_MoussUp(ByVal sender As Object, ByVal e As EventArgs) Handles grdDetalle.MouseUp

        m_IsDataGridFocused = True

    End Sub

    Private Sub grdDetalle_MoussDoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles grdDetalle.MouseDoubleClick


        m_IsDataGridFocused = True

    End Sub

    Private Sub grdDetalle_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles grdDetalle.Leave

        m_IsDataGridFocused = False

    End Sub


    Public Sub AbreConexion()
        If Not cnSigamet Is Nothing Then
            If cnSigamet.State = ConnectionState.Closed Then
                cnSigamet.Open()
            End If
        End If
    End Sub

    Public Sub CierraConexion()
        If Not cnSigamet Is Nothing Then
            If cnSigamet.State = ConnectionState.Open Then
                cnSigamet.Close()
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub frmPedidoPortatil_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub grpPedido_Enter(sender As System.Object, e As System.EventArgs) Handles grpPedido.Enter

    End Sub
End Class
