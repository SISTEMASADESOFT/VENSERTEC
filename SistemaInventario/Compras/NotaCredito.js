var AppSession = "../Compras/NotaCredito.aspx";
var CodigoMenu = 3000; var CodigoInterno = 3;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#MainContent_txtCliente').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 2 + "','CodTipoCliente':'" + 0 + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2]
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodCtaCte').val(i.item.val);
        },
        minLength: 3
    });

    $('#MainContent_txtClienteConsulta').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 2 + "','CodTipoCliente':'" + 0 + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2]
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodCtaCteConsulta').val(i.item.val);
        },
        minLength: 3
    });

    $('.Jq-ui-dtp').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy',
        maxDate: '0'
    });

    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
    $('.Jq-ui-dtp').datepicker('setDate', new Date());

    $('#divTabs').tabs();

    $('#MainContent_txtDesde').datepicker({ onSelect: function () {
        var date = $(this).datepicker('getDate');
        if (date) {
            date.setDate(1);
            $(this).datepicker('setDate', date);
        }
    }
    });

    $('#MainContent_txtDesde').datepicker({ beforeShowDay: function (date) {
        return [date.getDate() == 1, ''];
    }
    });

    $('#MainContent_imgBuscar').click(function () {
        try {
            var cadena = "Ingresar los sgtes. campos :";
            if ($('#MainContent_txtArticulo').val == "")
                cadena = cadena + "\n" + "Articulo"

            if ($('#MainContent_ddlMoneda option').size() == 0)
            { cadena = cadena + "\n" + "Moneda"; }
            else {
                if ($('#MainContent_ddlMoneda').val() == "-1")
                    cadena = cadena + "\n" + "Moneda";
            }

            if (cadena != "Ingresar los sgtes. campos :") {
                alertify.log(cadena);
                return false;
            }

            F_Buscar_Productos()
        }
        catch (e) {

            alertify.log("Error Detectado: " + e);
        }


        return false;

    });

    $('#MainContent_btnBuscarConsulta').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_Buscar();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnAgregar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (F_ValidarAgregar() == false)
                return false;

            F_AgregarTemporal();
            $('#MainContent_txtArticulo').focus();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnGrabar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (!F_ValidarGrabarDocumento())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR LA NOTA DE CREDITO"))
                F_GrabarDocumento();

            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnNuevo').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_Nuevo();

            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEliminar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (F_ValidarEliminar() == false)
                return false;

            if (confirm("Esta seguro de eliminar los productos seleccionado"))
                F_EliminarTemporal();

            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnGrabarEdicion').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {

            F_EditarTemporal();

            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnFactura').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
    if (F_PermisoOpcion(CodigoMenu, '777002', '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

        $('#div_Factura').dialog({
            resizable: false,
            modal: true,
            title: "Factura",
            title_html: true,
            height: 80,
            width: 370,
            autoOpen: false
        });
        var Contenedor = '#MainContent_';
        $(Contenedor + 'txtCodFactura').val('');
        $('#div_Factura').dialog('open');

        return false;

    });

    $('#MainContent_btnFacturarNotaCredito').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_FacturaNotaCredito();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_txtEmision').on('change', function (e) {
        F_TipoCambio();
    });

    $('#MainContent_txtNumero').blur(function () {
        if ($.trim($('#MainContent_txtNumero').val()) == '')
            return false;
        var id = '00000000' + $('#MainContent_txtNumero').val();
        $('#MainContent_txtNumero').val(id.substr(id.length - 8));
        return false;
    });

    $("#MainContent_txtPrecio").blur(function () {

        if ($("#MainContent_txtPrecio") == '')
            return false;

        $("#MainContent_txtImporte").val(parseFloat($("#MainContent_txtPrecio").val() * $("#MainContent_txtCantidad").val()).toFixed(2));


        return false;

    });

    $("#MainContent_txtCantidad").blur(function () {

        if ($("#MainContent_txtCantidad") == '')
            return false;

        $("#MainContent_txtImporte").val(parseFloat($("#MainContent_txtPrecio").val() * $("#MainContent_txtCantidad").val()).toFixed(2));


        return false;

    });

    F_Controles_Inicializar();

    $('#MainContent_txtEmision').css('background', '#FFFFE0');

    $('#MainContent_txtCliente').css('background', '#FFFFE0');

    $('#MainContent_txtClienteConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtSubTotal').css('background', '#FFFFE0');

    $('#MainContent_txtIgv').css('background', '#FFFFE0');

    $('#MainContent_txtTotal').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtNumero').css('background', '#FFFFE0');

    $('#MainContent_txtSerie').css('background', '#FFFFE0');

    $('#MainContent_txtDesde').css('background', '#FFFFE0');

    $('#MainContent_txtHasta').css('background', '#FFFFE0');

    $('#MainContent_txtCodFactura').css('background', '#FFFFE0');

    $('#MainContent_txtImporte').css('background', '#FFFFE0');

    $('#MainContent_txtPrecio').css('background', '#FFFFE0');

    $('#MainContent_txtUM').css('background', '#FFFFE0');

    $('#MainContent_txtCantidad').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcion').css('background', '#FFFFE0');

    $('#MainContent_txtCodigo').css('background', '#FFFFE0');

    $('#MainContent_txtVencimiento').css('background', '#FFFFE0');

    $('#MainContent_txtObservacion').css('background', '#FFFFE0');

    $("#MainContent_txtNumero").ForceNumericOnly();

    //    $('#MainContent_txtNumero').blur(function () {
    //        var id = '0000000' + $('#MainContent_txtNumero').val();
    //        $('#MainContent_txtNumero').val(id.substr(id.length - 7));
    //        return false;
    //    });

    //    $('#MainContent_txtSerie').blur(function () {
    //        var id = '000' + $('#MainContent_txtSerie').val();
    //        $("#MainContent_txtSerie").val(id.substr(id.length - 3));
    //        return false;
    //    });

    $('#div_SerieDetalle').bind('dialogclose', function (event) {
        F_BuscarTemporal();
        return false;
    });

    $('#MainContent_txtNumeroConsulta').blur(function () {
        var id = '0000000' + $('#MainContent_txtNumeroConsulta').val();
        $('#MainContent_txtNumeroConsulta').val(id.substr(id.length - 7));
        return false;
    });

});

$().ready(function () {

    $(document).everyTime(600000, function () {
        if (!F_ValidaSesionActiva(AppSession)) return false;
    });


});

$(document).unbind('keydown').bind('keydown', function (event) {
    var doPrevent = false;
    if (event.keyCode === 8) {
        var d = event.srcElement || event.target;
        if ((d.tagName.toUpperCase() === 'INPUT' && (d.type.toUpperCase() === 'TEXT' || d.type.toUpperCase() === 'PASSWORD' || d.type.toUpperCase() === 'FILE' || d.type.toUpperCase() === 'EMAIL'))
             || d.tagName.toUpperCase() === 'TEXTAREA') {
            doPrevent = d.readOnly || d.disabled;
        }
        else {
            doPrevent = true;
        }
    }

    if (doPrevent) {
        event.preventDefault();
    }
});

function VerifySessionState(result) { }

function F_Controles_Inicializar() {

    var arg;

    try {
        var objParams =
            {
                Filtro_Fecha: $('#MainContent_txtEmision').val(),
                Filtro_CodDoc: 3
            };


        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        F_Controles_Inicializar_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion == "1") {

                        F_Update_Division_HTML('div_moneda', result.split('~')[2]);
                        F_Update_Division_HTML('div_TipoOperaciones', result.split('~')[4]);
                        F_Update_Division_HTML('div_igv', result.split('~')[8]);
                        F_Update_Division_HTML('div_formapago', result.split('~')[9]);
                        F_Update_Division_HTML('div_CajaFisica', result.split('~')[10]);
                        CodCajaFisica = result.split('~')[11];

                        $('#MainContent_ddlCajaFisica').val(CodCajaFisica);
                        $('#MainContent_ddlMoneda').val('1');
                        $('#MainContent_ddlCajaFisica').val('2');
                        $('#MainContent_lblTC').text(result.split('~')[7]);
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                        $('#MainContent_ddlMedioPago').css('background', '#FFFFE0');
                        $('#MainContent_ddlTipoOperaciones').css('background', '#FFFFE0');
                        $('#MainContent_ddlIgv').css('background', '#FFFFE0');
                        $('#MainContent_ddlFormaPago').css('background', '#FFFFE0');
                        $('#MainContent_ddlCajaFisica').css('background', '#FFFFE0');
                        $('#MainContent_ddlFormaPago').val(1);
                    }

                    else {

                        alertify.log(str_mensaje_operacion);

                    }


                }
            );

    } catch (mierror) {

        alertify.log("Error detectado: " + mierror);

    }

}

function F_MostrarTotales() {

    var lblimporte_grilla = '';
    var chkDel = '';
    var Total = 0;
    var Igv = 0;
    var Subtotal = 0;
    $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
        chkDel = '#' + this.id;
        lblimporte_grilla = chkDel.replace('chkEliminar', 'lblimporte');
        Total += parseFloat($(lblimporte_grilla).text());
    });
    var Cuerpo = '#MainContent_'
    $(Cuerpo + 'txtTotal').val(Total.toFixed(2));
    $(Cuerpo + 'txtIgv').val((Total * parseFloat($(Cuerpo + 'ddligv').val())).toFixed(2));
    $(Cuerpo + 'txtSubTotal').val((Total / (1 + parseFloat($(Cuerpo + 'ddligv').val()))).toFixed(2));

}

function F_ValidarGrabarDocumento() {

    try {

        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtCliente').val() == '' || $('#hfCodCtaCte').val() == 0)
            Cadena = Cadena + '<p></p>' + 'Razon Social';

        if ($(Cuerpo + 'txtTC').val() == '0')
            Cadena = Cadena + '<p></p>' + 'Tipo de Cambio';

        if ($(Cuerpo + 'txtTC').val() == '')
            Cadena = Cadena + '<p></p>' + 'Tipo de Cambio';

        if ($(Cuerpo + 'txtEmision').val() == '')
            Cadena = Cadena + '<p></p>' + 'Emision';

        if ($(Cuerpo + 'txtSubTotal').val() == '0.00')
            Cadena = Cadena + '<p></p>' + 'Ingrese Factura';

        if ($(Cuerpo + 'txtObservacion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Observacion';


        if (Cadena != 'Ingresar los sgtes. Datos:') {
            alertify.log(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        alertify.log("Error Detectado: " + e);
    }
}

function F_GrabarDocumento() {
    try {
        var FlagIgv = '1';
        var Contenedor = '#MainContent_';
        var Index = $('#MainContent_txtCliente').val().indexOf('-');
        var RazonSocial = $('#MainContent_txtCliente').val();

        if (Index == -1)
            $('#hfCodCtaCte').val('0');
        else
            RazonSocial = RazonSocial.substr(RazonSocial.length - (RazonSocial.length - (Index + 2)));


        var objParams = {
            Filtro_CodTipoDoc: "3",
            Filtro_SerieDoc: $(Contenedor + 'txtSerie').val(),
            Filtro_NumeroDoc: $(Contenedor + 'txtNumero').val(),
            Filtro_FechaEmision: $(Contenedor + 'txtEmision').val(),
            Filtro_Vencimiento: $(Contenedor + 'txtVencimiento').val(),
            Filtro_CodCliente: $('#hfCodCtaCte').val(),
            Filtro_CodEstado: 6,
            Filtro_CodFormaPago: $(Contenedor + 'ddlFormaPago').val(),
            Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
            Filtro_TipoCambio: $(Contenedor + 'lblTC').text(),
            Filtro_SubTotal: $(Contenedor + 'txtSubTotal').val() * -1,
            Filtro_Igv: $(Contenedor + 'txtIgv').val() * -1,
            Filtro_Total: $(Contenedor + 'txtTotal').val() * -1,
            Filtro_FlagIgv: FlagIgv,
            Filtro_Cliente: RazonSocial,
            Filtro_CodTasa: $(Contenedor + 'ddlIgv').val(),
            Filtro_CodDetalle: $('#hfCodigoTemporal').val(),
            Filtro_CodTipoOperacion: 6,
            Filtro_CodTipoOperacionNC: $(Contenedor + 'ddlTipoOperaciones').val(),
            Filtro_CodFactura_Asociada: $('#hfCodDocumentoVenta').val(),
            Filtro_Observacion: $(Contenedor + 'txtObservacion').val(),
            Filtro_CodCajaFisica: $(Contenedor + 'ddlCajaFisica').val(),

        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_GrabarDocumento_NET(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Se grabo correctamente') {
                    alertify.log('Se grabo correctamente');

                    F_Nuevo();

                }
                else {
                    alertify.log(str_mensaje_operacion);
                    return false;
                }

            }
            else {
                alertify.log(result.split('~')[1]);
                return false;
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function F_NuevoEdicion() {
    var Contenedor = '#MainContent_';
    $(Contenedor + 'txtCodigo').val('');
    $(Contenedor + 'txtDescripcion').val('');
    $(Contenedor + 'txtCantidad').val('');
    $(Contenedor + 'txtUM').val('');
    $(Contenedor + 'txtImporte').val(''),
    $(Contenedor + 'txtPrecio').val('');
    $(Contenedor + 'txtObservacion').val('');
}

function F_Nuevo() {

    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
    $('.Jq-ui-dtp').datepicker('setDate', new Date());
    $('#hfCodDocumentoVenta').val(0);
    $('#hfCodCtaCte').val('0');
    $('#MainContent_ddlMoneda').val(1);
    $('#hfCodigoTemporal').val('0');
    $('#MainContent_txtCliente').val('');
    $('#MainContent_txtPlaca').val('');
    $('#MainContent_txtSerie').val('');
    $('#MainContent_txtNumero').val('');
    $('#MainContent_txtDistrito').val('');
    $('#MainContent_txtDireccion').val('');
    $('#MainContent_txtSubTotal').val('0.00');
    $('#MainContent_txtIgv').val('0.00');
    $('#MainContent_txtTotal').val('0.00');
    $('#MainContent_txtDestino').val('');
    $('#MainContent_txtVencimiento').val($('#MainContent_txtEmision').val());
    $('#MainContent_txtArticulo').val('');
    $('#MainContent_txtNroRuc').val('');
    $('#MainContent_txtCliente').focus();
    $('#MainContent_txtObservacion').val('');
    $('#MainContent_ddlCajaFisica').val('2');

    try {
        var objParams = {
            Filtro_CodDoc: 3
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_Nuevo_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[3]);
            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }

}

function F_Buscar() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var chkNumero = '0';
        var chkFecha = '0';
        var chkCliente = '0';

        if ($('#MainContent_chkNumero').is(':checked'))
            chkNumero = '1';

        if ($('#MainContent_chkRango').is(':checked'))
            chkFecha = '1';

        if ($('#MainContent_chkCliente').is(':checked'))
            chkCliente = '1';

        var objParams = {
            Filtro_Serie: $("#MainContent_ddlSerieConsulta option:selected").text(),
            Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
            Filtro_Desde: $('#MainContent_txtDesde').val(),
            Filtro_Hasta: $('#MainContent_txtHasta').val(),
            Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
            Filtro_CodTipoDoc: '3',
            Filtro_ChkNumero: chkNumero,
            Filtro_ChkFecha: chkFecha,
            Filtro_ChkCliente: chkCliente

        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_Buscar_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                        $('#lblconsulta').text(F_Numerar_Grilla("grvConsulta", 'lblnumero'));
                if (str_mensaje_operacion != '')
                    alertify.log(str_mensaje_operacion);

            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }

}

function imgMas_Click(Control) {
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {
        $(Control).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Control).next().html() + '</td></tr>');
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }

    return false;
}

function F_AnularRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var lblCodigo = '#' + imgID.replace('imgAnularDocumento', 'lblcodigo');
        var lblCodigo_Factura = '#' + imgID.replace('imgAnularDocumento', 'hfcodfactura');
        var lblnumero_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblnumero');
        var lblcliente_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblcliente');

        if (!confirm("ESTA SEGURO DE ELIMINAR LA NOTA DE CREDITO : " + $(lblnumero_grilla).text() + "\nDEL PROVEEDOR " + $(lblcliente_grilla).text()))
            return false;

        var chkNumero = '0';
        var chkFecha = '0';
        var chkCliente = '0';
        var chkSerie = '0';

        if ($('#MainContent_chkNumero').is(':checked'))
            chkNumero = '1';

        if ($('#MainContent_chkRango').is(':checked'))
            chkFecha = '1';

        if ($('#MainContent_chkCliente').is(':checked'))
            chkCliente = '1';

        if ($('#MainContent_chkSerie').is(':checked'))
            chkSerie = '1';

        var objParams = {
            Filtro_CodMovimiento: $(lblCodigo).val(),
            Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
            Filtro_Desde: $('#MainContent_txtDesde').val(),
            Filtro_Hasta: $('#MainContent_txtHasta').val(),
            Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
            Filtro_ChkNumero: chkNumero,
            Filtro_ChkFecha: chkFecha,
            Filtro_ChkCliente: chkCliente,
            Filtro_ChkSerie: chkSerie
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        F_AnularRegistro_Net(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                alertify.log(result.split('~')[1]);
            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;
        });

    }

    catch (e) {

        alertify.log("Error Detectado: " + e);
        return false;
    }


}

function getContentTab() {

    var date = new Date();
    date.setMonth(date.getMonth(), 1);

    $('#MainContent_txtDesde').val(date.format("dd/MM/yyyy"));
    $('#MainContent_chkRango').prop('checked', true);
    F_Buscar();
    return false;

}

function F_TipoCambio() {
    try {
        var objParams = {
            Filtro_Emision: $("#MainContent_txtEmision").val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_TipoCambio_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1")
                $('#MainContent_lblTC').text(result.split('~')[2]);
            else
                alertify.log(result.split('~')[1]);

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }

}

function MostrarEspera(pboolMostrar) {
    if (pboolMostrar) {
        $('#dlgWait').dialog({
            autoOpen: false,
            modal: true,
            height: 'auto',
            resizable: false,
            dialogClass: 'alert'
        });

        $('.alert div.ui-dialog-titlebar').hide();
        //        $('.ui-button').remove();
        $('#dlgWait').dialog('open');
    }
    else {
        $('#dlgWait').dialog('close');
    }
}

function F_FacturaNotaCredito() {
    var Contenedor = '#MainContent_';
    var Mensaje = "Ingrese los sgtes datos: ";

    if ($('#hfCodCtaCte').val() == "0")
        Mensaje = Mensaje + "\n" + "Proveedor";

    if ($(Contenedor + 'txtCodFactura').val() == "")
        Mensaje = Mensaje + "\n" + "Numero Factura";

    if (Mensaje != "Ingrese los sgtes datos: ") {
        alertify.log(Mensaje);
        return false;
    }
    var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

    try {
        var objParams = {
            Filtro_CodDocumentoVenta: $(Contenedor + 'txtCodFactura').val(),
            Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
            Filtro_TasaIgv: tasaigv,
            Filtro_NotaPedido: '0'
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_FacturacionNotaCredito_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_mensaje_operacion == "") {
                $('#hfCodigoTemporal').val(result.split('~')[2]);
                $('#hfCodCtaCte').val(result.split('~')[3]);
                $('#MainContent_ddlMoneda').val(result.split('~')[4]);
                $('#MainContent_txtSubTotal').val(parseFloat(result.split('~')[5]).toFixed(2));
                $('#MainContent_txtIgv').val(parseFloat(result.split('~')[6]).toFixed(2));
                $('#MainContent_txtTotal').val(parseFloat(result.split('~')[7]).toFixed(2));
                $('#MainContent_txtCliente').val(result.split('~')[8]);
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[9]);
                        $('#lblgrilladetalle').text(F_Numerar_Grilla("grvDetalleArticulo", 'lblCodigo'));
                $('#hfCodDocumentoVenta').val(result.split('~')[10]);
                $('#div_Factura').dialog('close');
                return false;
            }
            else {
                alertify.log(str_mensaje_operacion);
                return false;

            }
        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function F_EliminarTemporal() {

    try {
        var chkSi = '';
        var arrDetalle = new Array();
        var lblID = '';


        $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblID = chkSi.replace('chkEliminar', 'hfCodDetalle');

            if ($(chkSi).is(':checked')) {
                var objDetalle = {

                    CodDetalle: $(lblID).val()
                };

                arrDetalle.push(objDetalle);
            }
        });


        var Contenedor = '#MainContent_';
        var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
        var objParams = {
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_TasaIgv: tasaigv,
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_EliminarTemporal_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                if (result.split('~')[5] == '0') {
                    $('#MainContent_txtTotal').val('0.00');
                    $('#MainContent_txtIgv').val('0.00');
                    $('#MainContent_txtSubTotal').val('0.00');
                }
                else {
                    $('#MainContent_txtTotal').val(result.split('~')[5]);
                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                }

                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                if (result.split('~')[2] == 'Se han eliminado los productos correctamente.')
                    alertify.log('Se han eliminado los productos correctamente.');
            }
            else {
                alertify.log(result.split('~')[2]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
    }
}

function F_ValidarEliminar() {

    try {
        var Contenedor = '#MainContent_';

        if ($(Contenedor + 'ddlTipoOperaciones').val() == 2) {
            alertify.log("No se puede eliminar productos, si la operacion es anulacion");
            return false;
        }

        var chkSi = '';
        var x = 0;

        $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;

            if ($(chkSi).is(':checked'))
                x = 1;

        });

        if (x == 0) {
            alertify.log("Seleccione un articulo para eliminar");
            return false;
        }
        else
        { return true; }

    }

    catch (e) {

        alertify.log("Error Detectado: " + e);
    }
}

function F_EditarRegistro(Fila) {

    try {
        var Contenedor = '#MainContent_';

        if ($(Contenedor + 'ddlTipoOperaciones').val() == 2)
            return false;

        $("#div_Mantenimiento").dialog({
            resizable: false,
            modal: true,
            title: "Edicion Registro",
            title_html: true,
            height: 200,
            width: 450,
            autoOpen: false
        });

        F_NuevoEdicion();


        var imgID = Fila.id;

        var lblCodigo = '#' + imgID.replace('imgEditarRegistro', 'lblCodigo');
        var lblProducto = '#' + imgID.replace('imgEditarRegistro', 'lblProducto');
        var lblCantidad = '#' + imgID.replace('imgEditarRegistro', 'lblCantidad');
        var hfCantidad = '#' + imgID.replace('imgEditarRegistro', 'hfCantidad');
        var lblUM = '#' + imgID.replace('imgEditarRegistro', 'lblUM');
        var lblPrecio = '#' + imgID.replace('imgEditarRegistro', 'lblPrecio');
        var lblImporte = '#' + imgID.replace('imgEditarRegistro', 'lblImporte');
        var lblID = '#' + imgID.replace('imgEditarRegistro', 'hfCodDetalle');

        $(Contenedor + 'txtCodigo').val($(lblCodigo).text());
        $(Contenedor + 'txtDescripcion').val($(lblProducto).text());
        $(Contenedor + 'txtCantidad').val($(lblCantidad).text());
        $(Contenedor + 'txtUM').val($(lblUM).text());
        $(Contenedor + 'txtPrecio').val($(lblPrecio).text());
        $(Contenedor + 'txtImporte').val($(lblImporte).text());
        $('#hfCodDetalle').val($(lblID).val());
        $('#hfCantidad').val($(hfCantidad).val());
        $('#hfPrecio').val($(lblPrecio).text());



        if ($(Contenedor + 'ddlTipoOperaciones').val() == 6) {
            $(Contenedor + 'txtPrecio').prop('readonly', true);
            $(Contenedor + 'txtCantidad').prop('readonly', false);
        }
        else {
            $(Contenedor + 'txtPrecio').prop('readonly', false);
            $(Contenedor + 'txtCantidad').prop('readonly', true);
        }
        $('#div_Mantenimiento').dialog('open');

        return false;


    }

    catch (e) {

        alertify.log("Error Detectado: " + e);
        return false;
    }

}

function F_EditarTemporal() {

    var Contenedor = '#MainContent_';

    if (Number($('#hfCantidad').val()) < Number($(Contenedor + 'txtCantidad').val())) {
        alertify.log('LA CANTIDAD NO PUEDE SER MAYOR A LA CANTIDAD DE LA FACTURA');
        return false;
    }


    try {
        var chkSi = '';
        var arrDetalle = new Array();
        var lblcoddetalle_grilla = '';



        var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

        var objParams = {
            Filtro_Cantidad: $(Contenedor + 'txtCantidad').val(),
            Filtro_Precio: $(Contenedor + 'txtPrecio').val() / tasaigv,
            Filtro_CodDetDocumentoVenta: $('#hfCodDetalle').val(),
            Filtro_TasaIgv: tasaigv,
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_EditarTemporal_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                if (result.split('~')[5] == '0') {
                    $('#MainContent_txtTotal').val('0.00');
                    $('#MainContent_txtIgv').val('0.00');
                    $('#MainContent_txtSubTotal').val('0.00');
                }
                else {

                    $('#MainContent_txtSubTotal').val(parseFloat(result.split('~')[7]).toFixed(2));
                    $('#MainContent_txtIgv').val(parseFloat(result.split('~')[6]).toFixed(2));
                    $('#MainContent_txtTotal').val(parseFloat(result.split('~')[5]).toFixed(2))
                }

                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('#div_Mantenimiento').dialog('close');
            }
            else {
                alertify.log(result.split('~')[2]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
    }
}

function F_VerSeries(HlkControlID) {

    var CodDetalle = '';

    CodDetalle = $('#' + HlkControlID).text();

    try {
        var objParams = {
            Filtro_CodDetalle: CodDetalle
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_VerSeries_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

                F_Update_Division_HTML('div_GrillaSerieDetalle', result.split('~')[2]);
                if (str_mensaje_operacion != "") {
                    alertify.log(str_mensaje_operacion);
                }
                else {

                    $('#div_SerieDetalle').dialog({
                        resizable: false,
                        modal: true,
                        title: "Series",
                        title_html: true,
                        height: 320,
                        width: 400,
                        autoOpen: false
                    });

                    $('#div_SerieDetalle').dialog('open');
                }

                return false;
            }

            else {
                alertify.log(result.split('~')[1]);
            }
            return false;
        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }

}

function F_EliminarSerie(Fila) {
    try {
        var imgID = Fila.id;
        var lblID = '#' + imgID.replace('imgEliminar', 'hfCodDetalle');
        var hfCodDetDocumentoVenta = '#' + imgID.replace('imgEliminar', 'hfCodDetDocumentoVenta');
        var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

        var objParams = {
            Filtro_CodTemporalSerializacionDet: $(lblID).val(),
            Filtro_CodDetDocumentoVenta: $(hfCodDetDocumentoVenta).val(),
            Filtro_CodDetalle: $(hfCodDetDocumentoVenta).val()

        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EliminarSerie_Net(arg, function (result) {
            MostrarEspera(false);
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                $('#hfSerie').val(1);
                F_Update_Division_HTML('div_GrillaSerieDetalle', result.split('~')[3]);
                return false;
            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;
        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }


}

function F_BuscarTemporal() {

    try {
        if ($('#hfSerie').val() == 0)
            return false;

        var Contenedor = '#MainContent_';
        var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
        var objParams = {
            Filtro_TasaIgv: tasaigv,
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
            Filtro_NotaPedido: 0
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_BuscarTemporal_NET(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                $('#MainContent_txtTotal').val(result.split('~')[5]);
                $('#MainContent_txtIgv').val(result.split('~')[6]);
                $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                F_Update_Division_HTML('div_GrillaSerieDetalle', result.split('~')[8]);
                $('#hfSerie').val(0);
            }
            else {
                alertify.log(result.split('~')[2]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
    }
}


var CtlgvAuditoria;
var HfgvAuditoria;
function imgMas_Click_Auditoria(Control) {
    CtlgvAuditoria = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {

        var grid = $(Control).next();
        F_LlenarGridDetalle_Auditoria(grid.attr('id'));
        //$(Control).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Control).next().html() + '</td></tr>');
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }

    return false;
}

function F_LlenarGridDetalle_Auditoria(Fila){
  try 
        {             
                var nmrow = 'MainContent_grvConsulta_pnlOrdersAuditoria_0';
                var Col = Fila.split('_')[3];
                var Codigo = $('#' + Fila.replace('pnlOrdersAuditoria', 'lblcodigo')).val();
                var CodTipoDoc = $('#' + Fila.replace('pnlOrdersAuditoria', 'hfCodTipoDoc')).val();
                var grvNombre = 'MainContent_grvConsulta_grvDetalleAuditoria_' + Col;
                HfgvAuditoria = '#' + Fila.replace('pnlOrdersAuditoria', 'hfDetalleCargado');

                if ($(HfgvAuditoria).val() === "1")
                {
                    $(CtlgvAuditoria).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvAuditoria).next().html() + '</td></tr>');
                }
                else 
                {
                                                                                                                                                                                                                        {
                        var objParams = 
                        {
                            Filtro_Col: Col,
                            Filtro_Codigo: Codigo,
                            Filtro_CodTipoDoc: CodTipoDoc,
                            Filtro_grvNombre: grvNombre
                        };

                        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                        MostrarEspera(true);
                        F_LlenarGridDetalle_Auditoria_NET(arg, function (result) {
                
                        MostrarEspera(false);

                        var str_resultado_operacion = result.split('~')[0];
                        var str_mensaje_operacion = result.split('~')[1];

                        if (str_resultado_operacion === "0")
                        {
                            var p = $('#' + result.split('~')[3]).parent();
                            $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                            F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);

                            $(CtlgvAuditoria).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvAuditoria).next().html() + '</td></tr>');
//                            $(HfgvAuditoria).val('1');
                        }
                        else
                        {
                            alertify.log(str_mensaje_operacion);
                        }

                        return false;

                        });
        
                }

                }

        }
        catch (e) 
        {
              MostrarEspera(false);
            alertify.log("ERROR DETECTADO: " + e);
            return false;
        }

        return true;
}


var CtlgvObservacion;
var HfgvObservacion;
function imgMas_Click_Observacion(Control) {
    CtlgvObservacion = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {

        var grid = $(Control).next();
        F_LlenarGridDetalle_Observacion(grid.attr('id'));
        //$(Control).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Control).next().html() + '</td></tr>');
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }

    return false;
}

function F_LlenarGridDetalle_Observacion(Fila){
  try 
        {             
                var nmrow = 'MainContent_grvConsulta_pnlOrdersObservacion_0';
                var Col = Fila.split('_')[3];
                var Codigo = $('#' + Fila.replace('pnlOrdersObservacion', 'lblcodigo')).val();
                var CodTipoDoc = $('#' + Fila.replace('pnlOrdersObservacion', 'hfCodTipoDoc')).val();
                var grvNombre = 'MainContent_grvConsulta_grvDetalleObservacion_' + Col;
                HfgvObservacion = '#' + Fila.replace('pnlOrdersObservacion', 'hfDetalleCargado');

                if ($(HfgvObservacion).val() === "1")
                {
                    $(CtlgvObservacion).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvObservacion).next().html() + '</td></tr>');
                }
                else 
                {
                                                                                                                                                                                                                        {
                        var objParams = 
                        {
                            Filtro_Col: Col,
                            Filtro_Codigo: Codigo,
                            Filtro_CodTipoDoc: CodTipoDoc,
                            Filtro_grvNombre: grvNombre
                        };

                        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                        MostrarEspera(true);
                        F_LlenarGridDetalle_Observacion_NET(arg, function (result) {
                
                        MostrarEspera(false);

                        var str_resultado_operacion = result.split('~')[0];
                        var str_mensaje_operacion = result.split('~')[1];

                        if (str_resultado_operacion === "0")
                        {
                            var p = $('#' + result.split('~')[3]).parent();
                            $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                            F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);

                            $(CtlgvObservacion).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvObservacion).next().html() + '</td></tr>');
//                            $(HfgvAuditoria).val('1');
                        }
                        else
                        {
                            alertify.log(str_mensaje_operacion);
                        }

                        return false;

                        });
        
                }

                }

        }
        catch (e) 
        {
              MostrarEspera(false);
            alertify.log("ERROR DETECTADO: " + e);
            return false;
        }

        return true;
}
