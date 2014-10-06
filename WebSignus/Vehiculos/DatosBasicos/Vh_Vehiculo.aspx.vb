Imports System.Data
Imports Signus

Partial Class Vehiculos_DatosBasicos_Vh_Vehiculo
    Inherits PaginaComun



    Protected Sub btBuscaMarca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btBuscaMarca.Click


        ModalPopupConVhMarca.Show()
    End Sub

    Protected Sub CtrlConVhMarca1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlConVhMarca1.SelClicked
        tbMarca.Text = CtrlConVhMarca1.NomMarca
        hfIdMarca.Value = CtrlConVhMarca1.IdMarca
        ModalPopupConVhMarca.Hide()
    End Sub

    Protected Sub btBuscaLinea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btBuscaLinea.Click
        CtrlConVhLinea1.IdMarca = hfIdMarca.Value
        ModalPopupConVhLinea.Show()
    End Sub

    Protected Sub CtrlConVhLinea1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlConVhLinea1.SelClicked
        tbLinea.Text = CtrlConVhLinea1.NomLinea
        ModalPopupConVhLinea.Hide()
    End Sub

    Protected Sub btBuscaColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btBuscaColor.Click
        ModalPopupVhColor.Show()
    End Sub

    Protected Sub CtrlConVhColor1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlConVhColor1.SelClicked
        tbColor.Text = CtrlConVhColor1.NomColor
        ModalPopupVhColor.Hide()
    End Sub

    Protected Sub CtrlConVhCarroceria1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlConVhCarroceria1.SelClicked
        tbCarroceria.Text = CtrlConVhCarroceria1.NomCarroceria
        ModalPopupVhCarroceria.Hide()
    End Sub

    Protected Sub btBuscaCarroceria_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btBuscaCarroceria.Click
        ModalPopupVhCarroceria.Show()
    End Sub

    Protected Sub btBuscarInstituto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btBuscarInstituto.Click
        modalPopupConVhInstituto.Show()
    End Sub

    Protected Sub CtrlConVhInstituto1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlConVhInstituto1.SelClicked
        tbInstituto.Text = CtrlConVhInstituto1.NomInstituto
        hfCodInstTran.Value = CtrlConVhInstituto1.IdInstituto
        modalPopupConVhInstituto.Hide()
    End Sub

    Protected Sub btBuscaTer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btBuscaTer.Click
        ModalPopupConTercero.Show()
    End Sub

    Protected Sub CtrlConTercero2_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlConTercero2.SelClicked
        Dim oTer As New Terceros
        Dim dtConsulta As New DataTable
        tbNit.Text = CtrlConTercero2.Nit
        tbDv.Text = CtrlConTercero2.Dv
        tbRazonSocial.Text = CtrlConTercero2.Nombre
        dtConsulta = oTer.GetByIde(tbNit.Text)
        If dtConsulta.Rows.Count > 0 Then
            tbDireccion.Text = dtConsulta.Rows(0)("TER_DIR")
            tbMunicipio.Text = dtConsulta.Rows(0)("MUN_NOM")
        End If
        ModalPopupConTercero.Hide()
    End Sub

    Protected Sub btMatricular_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btMatricular.Click
        Habilitar_Deshabilitar(True)
        limpiarTextos()
        lTransaccion.Text = "MATRICULANDO VEHICULO"
        hfTransaccion.Value = "N"
        lestado.Text = "ACTIVO"
    End Sub

    Protected Sub btGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btGuardar.Click
        Dim oVh As New Vh_ParqueAutomotor
        oVh.ANTIGUO = cmbClasico.SelectedValue
        oVh.BLINDADO = cmbBlindado.SelectedValue
        oVh.CARROCERIA = tbCarroceria.Text
        oVh.CATEGORIA = cmbCategoria.SelectedValue
        oVh.CHASIS = tbChasis.Text
        oVh.CILINDRAJE = tbCilindraje.Text
        oVh.CLASE = cmbClase.SelectedValue
        oVh.COLOR = tbColor.Text
        oVh.ESTADO = "AC"
        oVh.FEC_EXP_TP = tbFecExpTP.Text
        oVh.FECHA_COMPRA = tbFechaCompra.Text
        oVh.FECHA_INGRESO = tbFechaMatricula.Text
        oVh.FECHA_MAT = tbFechaMatricula.Text
        oVh.IMPORTADO = cmbImportado.SelectedValue
        oVh.LINEA = tbLinea.Text
        oVh.MARCA = tbMarca.Text
        oVh.MODELO = tbModelo.Text
        oVh.MOTOR = tbMotor.Text
        oVh.MUN_MATRICULA = cmbMunMat.SelectedValue
        oVh.MUN_OPERACION = cmbMunOper.SelectedValue
        oVh.NIT = tbNit.Text
        oVh.PLACA = tbPlaca.Text
        oVh.TIPO_MATRICULA = cmbTipoMat.SelectedValue
        oVh.TONELAJE = tbTonelaje.Text
        oVh.USO = cmbUso.SelectedValue
        oVh.VALOR_FACT = tbValorCompra.Text
        oVh.VINS_CODIGO = hfCodInstTran.Value
        If hfTransaccion.Value = "N" Then
            MsgResult.Text = oVh.Insert()
            Dim oAseg As New Vh_Aseg_Parque
            oAseg.Placa = tbPlaca.Text
            oAseg.Poliza = tbNumPoliza.Text
            oAseg.Vencimiento = tbFecVenc.Text
            oAseg.Cod_Aseg = hfCodAseg.Value
            oAseg.Insert()
        End If
        If hfTransaccion.Value = "T" Then
            oVh.ESTADO = "IN"
            MsgResult.Text = oVh.Traslado()
        End If
        If hfTransaccion.Value = "MT" Then
            oVh.ESTADO = "AC"
            MsgResult.Text = oVh.Traslado()
        End If
        If hfTransaccion.Value = "M" Then
            oVh.ESTADO = hfEstadoVeh.Value
            MsgResult.Text = oVh.Update
        End If
        MsgBox1(MsgResult, oVh.lErrorG)
        If Not oVh.lErrorG Then
            lTransaccion.Text = ""
            Habilitar_Deshabilitar(False)
        End If
    End Sub

    Protected Sub btTraslado_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btTraslado.Click
        lTransaccion.Text = "REGISTRANDO TRASLADO DE VEHICULO A OTRO DEPARTAMENTO"
        hfTransaccion.Value = "T"
        lestado.Text = "INACTIVO"
        Habilitar_Deshabilitar(False)
        tbPlaca.Enabled = True
        cmbDptoMat.Enabled = True
        cmbDptoOper.Enabled = True
        cmbMunMat.Enabled = True
        cmbMunOper.Enabled = True
        btGuardar.Enabled = True
        btCancelar.Enabled = True
        limpiarTextos()
        cmbTipoMat.SelectedValue = "T"
    End Sub

    Protected Sub btCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btCancelar.Click
        lTransaccion.Text = ""
        lestado.Text = ""
        Habilitar_Deshabilitar(False)
        limpiarTextos()
    End Sub
    Sub Habilitar_Deshabilitar(ByVal habilitar As Boolean)
        tbChasis.Enabled = habilitar
        tbCilindraje.Enabled = habilitar
        tbFecExpTP.Enabled = habilitar
        tbFechaCompra.Enabled = habilitar
        tbFechaMatricula.Enabled = habilitar
        tbFecVenc.Enabled = habilitar
        tbModelo.Enabled = habilitar
        tbMotor.Enabled = habilitar
        tbNumPoliza.Enabled = habilitar
        tbPasajeros.Enabled = habilitar
        tbPlaca.Enabled = habilitar
        tbTonelaje.Enabled = habilitar
        tbValorCompra.Enabled = habilitar
        btBuscaAseguradora.Enabled = habilitar
        btBuscaCarroceria.Enabled = habilitar
        btBuscaColor.Enabled = habilitar
        btBuscaLinea.Enabled = habilitar
        btBuscaMarca.Enabled = habilitar
        btBuscaPlaca.Enabled = habilitar
        btBuscarInstituto.Enabled = habilitar
        btBuscaTer.Enabled = habilitar
        cmbBlindado.Enabled = habilitar
        cmbCategoria.Enabled = habilitar
        cmbClase.Enabled = habilitar
        cmbClasico.Enabled = habilitar
        cmbDptoMat.Enabled = habilitar
        cmbDptoOper.Enabled = habilitar
        cmbImportado.Enabled = habilitar
        cmbMunMat.Enabled = habilitar
        cmbMunOper.Enabled = habilitar
        cmbTipoMat.Enabled = habilitar
        cmbUso.Enabled = habilitar
        btGuardar.Enabled = habilitar
        btCancelar.Enabled = habilitar
    End Sub

    Protected Sub tbPlaca_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPlaca.TextChanged
        BuscarPlaca()
    End Sub

    Sub BuscarPlaca()
        If hfTransaccion.Value = "MT" Then
            hfTransaccion.Value = "N"
        End If
        If Not String.IsNullOrEmpty(tbPlaca.Text) Then
            Dim oVh As New Vh_ParqueAutomotor
            Dim dt As New DataTable
            dt = oVh.GetPorPlaca(tbPlaca.Text)
            If dt.Rows.Count > 0 Then
                tbCarroceria.Text = dt.Rows(0)("CARROCERIA").ToString
                tbChasis.Text = dt.Rows(0)("CHASIS").ToString
                tbCilindraje.Text = dt.Rows(0)("CILINDRAJE").ToString
                tbColor.Text = dt.Rows(0)("COLOR").ToString
                tbDireccion.Text = dt.Rows(0)("TER_DIR").ToString
                tbDv.Text = dt.Rows(0)("TER_DVER").ToString
                If Not String.IsNullOrEmpty(dt.Rows(0)("FEC_EXP_TP").ToString) Then
                    tbFecExpTP.Text = dt.Rows(0)("FEC_EXP_TP").ToString.Substring(0, 10)
                Else
                    tbFecExpTP.Text = ""
                End If
                If Not String.IsNullOrEmpty(dt.Rows(0)("FECHA_COMPRA").ToString) Then
                    tbFechaCompra.Text = dt.Rows(0)("FECHA_COMPRA").ToString.Substring(0, 10)
                Else
                    tbFechaCompra.Text = ""
                End If
                If Not String.IsNullOrEmpty(dt.Rows(0)("FECHA_MAT").ToString) Then
                    tbFechaMatricula.Text = dt.Rows(0)("FECHA_MAT").ToString.Substring(0, 10)
                Else
                    tbFechaMatricula.Text = ""
                End If
                tbInstituto.Text = dt.Rows(0)("VINS_DESCRIPCION").ToString
                tbLinea.Text = dt.Rows(0)("LINEA").ToString
                tbMarca.Text = dt.Rows(0)("MARCA").ToString
                tbModelo.Text = dt.Rows(0)("MODELO").ToString
                tbMotor.Text = dt.Rows(0)("MOTOR").ToString
                tbMunicipio.Text = dt.Rows(0)("MUN_NOM").ToString
                tbNit.Text = dt.Rows(0)("TER_NIT").ToString
                'tbFecVenc.Text = Pendiente fecha de vencimiento del soat
                'tbNomAseguradora.Text = HACER LEFT JOIN
                'tbNumPoliza.Text = HACER LEFT JOIN
                tbPasajeros.Text = dt.Rows(0)("PASAJEROS").ToString
                tbPlaca.Text = dt.Rows(0)("PLACA").ToString
                tbRazonSocial.Text = dt.Rows(0)("TER_NOM").ToString
                tbTonelaje.Text = dt.Rows(0)("TONELAJE").ToString
                cmbClasico.SelectedValue = dt.Rows(0)("ANTIGUO").ToString
                cmbClase.SelectedValue = dt.Rows(0)("CLASE").ToString
                If Not String.IsNullOrEmpty(dt.Rows(0)("CATEGORIA").ToString) Then
                    cmbCategoria.SelectedValue = dt.Rows(0)("CATEGORIA").ToString
                End If
                cmbBlindado.SelectedValue = dt.Rows(0)("BLINDADO").ToString
                cmbUso.SelectedValue = dt.Rows(0)("USO").ToString
                cmbDptoMat.SelectedValue = dt.Rows(0)("MUN_MATRICULA").ToString.Substring(0, 2)
                cmbDptoOper.SelectedValue = dt.Rows(0)("MUN_OPERACION").ToString.Substring(0, 2)
                cmbMunMat.DataBind()
                cmbMunOper.DataBind()
                cmbMunMat.SelectedValue = dt.Rows(0)("MUN_MATRICULA").ToString
                cmbMunOper.SelectedValue = dt.Rows(0)("MUN_OPERACION").ToString
                tbValorCompra.Text = dt.Rows(0)("VALOR_FACT").ToString
                hfEstadoVeh.Value = dt.Rows(0)("ESTADO").ToString
                MsgBoxLimpiar(MsgResult)
                If hfTransaccion.Value = "N" And hfEstadoVeh.Value = "IN" Then
                    MsgResult.Text = "La Placa digitada ya Existe. Llega Vehiculo - MATRICULA POR TRASLADO"
                    MsgBoxAlert(MsgResult, True)
                    hfTransaccion.Value = "MT"
                End If
                If hfEstadoVeh.Value = "AC" And hfTransaccion.Value = "N" Then
                    MsgResult.Text = "La Placa digitada ya Existe. El Vehiculo esta ACTIVO. No Puede Matricularlo Nuevamente "
                    MsgBoxAlert(MsgResult, True)
                    Habilitar_Deshabilitar(False)
                End If
                If hfTransaccion.Value = "M" And hfEstadoVeh.Value = "IN" Then
                    lestado.Text = "INACTIVO"
                    MsgResult.Text = "El vehiculo esta INACTIVO"
                    MsgBoxAlert(MsgResult, True)
                End If
                If hfTransaccion.Value = "M" And hfEstadoVeh.Value = "AC" Then
                    lestado.Text = "ACTIVO"
                End If
            End If
        End If
    End Sub

    Protected Sub btModificar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btModificar.Click
        hfTransaccion.Value = "M"
        lestado.Text = "ACTIVO"
        lTransaccion.Text = "REGISTRANDO MODIFICACIONES DE VEHICULO"
        limpiarTextos()
        Habilitar_Deshabilitar(True)
        cmbTipoMat.Enabled = False
    End Sub

    Protected Sub btBuscaAseguradora_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btBuscaAseguradora.Click
        ModalPopupConVhAseguradora.Show()
    End Sub

    Protected Sub CtrlConVhAseguradora1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlConVhAseguradora1.SelClicked
        tbNomAseguradora.Text = CtrlConVhAseguradora1.NomAseguradora
        hfCodAseg.Value = CtrlConVhAseguradora1.CodAseguradora
        ModalPopupConVhAseguradora.Hide()
    End Sub
    Sub limpiarTextos()
        tbCarroceria.Text = ""
        tbChasis.Text = ""
        tbCilindraje.Text = ""
        tbColor.Text = ""
        tbDireccion.Text = ""
        tbDv.Text = ""
        tbFecExpTP.Text = ""
        tbFechaCompra.Text = ""
        tbFechaMatricula.Text = ""
        tbFecVenc.Text = ""
        tbMarca.Text = ""
        tbModelo.Text = ""
        tbMotor.Text = ""
        tbMunicipio.Text = ""
        tbNit.Text = ""
        tbNomAseguradora.Text = ""
        tbNumPoliza.Text = ""
        tbLinea.Text = ""
        tbPasajeros.Text = ""
        tbPlaca.Text = ""
        tbRazonSocial.Text = ""
        tbTonelaje.Text = ""
        tbValorCompra.Text = ""
        tbInstituto.Text = ""
        MsgBoxLimpiar(MsgResult)
    End Sub
End Class
