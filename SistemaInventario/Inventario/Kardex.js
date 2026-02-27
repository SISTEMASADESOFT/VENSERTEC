var AppSession = "../Inventario/Kardex.aspx";
var CodigoMenu = 2000; var CodigoInterno = 1;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    $('#MainContent_txtRazonSocial').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 0 + "','CodTipoCliente':'" + 0 + "'}",
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

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#MainContent_txtArticulo').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_LGProductos_Select',
                data: "{'Descripcion':'" + request.term + "','CodAlmacen':'" + $('#hfCodSede').val() + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Stock: item.split(',')[2],
                            Costo: item.split(',')[3],
                            Moneda: item.split(',')[4],
                            Marca: item.split(',')[6]
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
            $('#MainContent_lblStock').text(i.item.Stock);
            $('#MainContent_lblCosto').text(i.item.Costo);
            $('#MainContent_lblMoneda').text(i.item.Moneda);
            $('#MainContent_txtMarca').val(i.item.Marca);
        },
        minLength: 3
    });

    $('.Jq-ui-dtp').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy'
    });

    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
    $('.Jq-ui-dtp').datepicker('setDate', new Date());

    $('#MainContent_btnBuscar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (F_Validar() == false)
                return false;

            F_Buscar();
            $('#MainContent_txtArticulo').focus();
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

    $('#MainContent_btnEdicion').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {

            if (Number($('#MainContent_txtStockFinal').val()) < 0) {
                alertify.log('el stock final resultante de la operacion, no puede ser negativo');
                return false;
            };


            if (confirm("¿ESTA SEGURO DE MODIFICAR EL SALDO INICIAL?"))
                F_EdicionSaldoInicial();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });


    $('#MainContent_txtDesde').val('22/03/2019');

    $('#MainContent_txtArticulo').focus();

    $('#MainContent_txtArticulo').css('background', '#FFFFE0');

    $('#MainContent_txtRazonSocial').css('background', '#FFFFE0');

    $('#MainContent_txtDesde').css('background', '#FFFFE0');

    $('#MainContent_txtHasta').css('background', '#FFFFE0');

    $('#MainContent_txtMarca').css('background', '#FFFFE0');

    $('#MainContent_txtStockActual').css('background', '#FFFFE0');

    $('#MainContent_txtIngreso').css('background', '#FFFFE0');

    $('#MainContent_txtStockFinal').css('background', '#FFFFE0');

    F_Controles_Inicializar();



    $("#MainContent_txtIngreso").bind("propertychange change keyup paste input", function () {

        try {
            if (isNaN($("#MainContent_txtIngreso").val()) | $("#MainContent_txtIngreso").val().trim() === '') {
                alertify.log('NUMERO INVALIDO');
                $("#MainContent_txtIngreso").val($('#hfSaldoInicial').val());
                $("#MainContent_txtIngreso").select();
                return false;
            }

            if (Number($("#MainContent_txtIngreso").val()) < 0) {
                alertify.log('DEBE SER MAYOR A CERO (0)');
                $("#MainContent_txtIngreso").val($('#hfSaldoInicial').val());
                $("#MainContent_txtIngreso").select();
                return false;
            }

            $('#MainContent_txtStockFinal').val(Number($('#hfStockSinSaldoInicial').val()) + Number($("#MainContent_txtIngreso").val()));



        } catch (e) {

        }

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
                Filtro_CodSerie: 52
            };


        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        F_Controles_Inicializar_NET
            (
                arg,
                function (result) {
                    if (result.split('~')[1] == "") {
                        $('#hfCodSede').val(result.split('~')[2]);
                        $('#MainContent_txtDesde').val(result.split('~')[3]);
                    }
                    else {
                        alertify.log(result.split('~')[1]);
                    }

                    
                }
            );

    } catch (mierror) {

        alertify.log("Error detectado: " + mierror);

    }

}

function F_Buscar() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    var arg;

    try {
        if ($('#MainContent_txtRazonSocial').val() == '')
            $('#hfCodCtaCteConsulta').val('0');

        var objParams =
            {
                Filtro_Desde: $('#MainContent_txtDesde').val(),
                Filtro_Hasta: $('#MainContent_txtHasta').val(),
                Filtro_CodAlterno: $('#hfCodCtaCte').val(),
                Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val()
            };


        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Buscar_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") {
                        F_Update_Division_HTML('div_grvKardex', result.split('~')[2]);
                        $('#MainContent_lblStock').text(result.split('~')[3]);
                        $('#MainContent_lblCosto').text(result.split('~')[4]);
                        if (str_mensaje_operacion != '')
                            alertify.log(str_mensaje_operacion);
                    }
                    else {
                        alertify.log(str_mensaje_operacion);
                    }


                }
            );

    } catch (mierror) {
        MostrarEspera(false);
        alertify.log("Error detectado: " + mierror);

    }

}

function F_Nuevo() {


    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
    $('.Jq-ui-dtp').datepicker('setDate', new Date());
    $('#hfCodCtaCte').val('0');
    $('#MainContent_txtArticulo').val('');
    $('#MainContent_lblStock').text('0.00');
    $('#MainContent_lblCosto').text('0.00');
    $('#MainContent_lblMoneda').text('dolares');
    $('#MainContent_txtDesde').val('22/03/2019');
    $('#MainContent_txtArticulo').focus();

    try {
        var objParams = {};



        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_Nuevo_NET(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

                F_Update_Division_HTML('div_grvKardex', result.split('~')[2]);

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

function F_Validar() {

    var Cadena = "Ingrese los sgtes. campos: ";
    if ($('#MainContent_txtArticulo').val() == "")
        Cadena = Cadena + "\n" + "Articulo";

    if ($('#MainContent_txtDesde').val() == "")
        Cadena = Cadena + "\n" + "Desde";

    if ($('#MainContent_txtHasta').val() == "")
        Cadena = Cadena + "\n" + "Hasta";

    if (Cadena != "Ingrese los sgtes. campos: ") {
        alertify.log(Cadena);
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

function F_EliminarRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var hfCodigo = '#' + imgID.replace('imgAnularDocumento', 'hfCodigo');
        var hfCodTipoOperacion = '#' + imgID.replace('imgAnularDocumento', 'hfCodTipoOperacion');

        if ($(hfCodTipoOperacion).val()!='17')
        {
        alertify.log("OPCION VALIDA SOLO PARA LOS AJUSTES");
        return false;
        }

        if (!confirm("ESTA SEGURO DE ELIMINAR EL AJUSTE"))
            return false;

        var objParams = {
            Filtro_CodMovimiento: $(hfCodigo).val(),
            Filtro_Desde: $('#MainContent_txtDesde').val(),
            Filtro_Hasta: $('#MainContent_txtHasta').val(),
            Filtro_CodAlterno: $('#hfCodCtaCte').val(),
            Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EliminarRegistro_Net(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_grvKardex', result.split('~')[2]);
                $('#MainContent_lblStock').text(result.split('~')[3]);
                $('#MainContent_lblCosto').text(result.split('~')[4]);
                if (str_mensaje_operacion != '')
                    alertify.log(str_mensaje_operacion);
            }
            else {
                alertify.log(str_mensaje_operacion);
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

function F_EditarSaldoInicial(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var hfCodigo = '#' + imgID.replace('imgEditarDocumento', 'hfCodigo');
        var hfCodTipoOperacion = '#' + imgID.replace('imgEditarDocumento', 'hfCodTipoOperacion');
        var lblInicial = '#' + imgID.replace('imgEditarDocumento', 'lblInicial');
        var Cuerpo = '#MainContent_';

        if ($(hfCodTipoOperacion).val() != '16') {
            alertify.log("OPCION VALIDA SOLO SALDO INICIAL");
            return false;
        }

        $('#hfCodMovimiento').val($(hfCodigo).val());
        $('#MainContent_txtStockActual').val($('#MainContent_lblStock').text());
        $('#MainContent_txtIngreso').val($(lblInicial).text());
        $('#hfSaldoInicial').val($(lblInicial).text());
        $('#hfStockSinSaldoInicial').val(Number($('#MainContent_lblStock').text()) - Number($(lblInicial).text()));
        $('#MainContent_txtStockFinal').val($('#MainContent_lblStock').text());
        
        $("#divEdicionRegistro").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de Saldo Inicial",
            title_html: true,
            height: 200,
            width: 250,
            autoOpen: false
        });
        
        $('#divEdicionRegistro').dialog('open');
           
    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function F_EdicionSaldoInicial() {

    try {
        var Contenedor = '#MainContent_';
        var Aro = '0';
        var Medida = '0';
        var Seccion = '0';


        //        if ($(Contenedor + 'txtAroEdicion').val()!='')
        //            Aro=$(Contenedor + 'txtAroEdicion').val();

        //        if ($(Contenedor + 'txtMedidaEdicion').val()!='')
        //            Medida=$(Contenedor + 'txtMedidaEdicion').val();

        //        if ($(Contenedor + 'txtSeccionEdicion').val()!='')
        //            Seccion=$(Contenedor + 'txtSeccionEdicion').val();

        var objParams = {
            Filtro_CodMovimiento: $('#hfCodMovimiento').val(),
            Filtro_CantidadIngreso: $('#MainContent_txtIngreso').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EdicionSaldoInicial_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == '') {
                    alertify.log('SE MODIFICO CORRECTAMENTE EL SALDO INICIAL');
                    $('#divEdicionRegistro').dialog('close');
                    F_Buscar();
                } else {
                    alertify.log(result.split('~')[1]);
                }
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

function F_ValidarEdicionDocumento() {

    try {

        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtDescripcionEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Descripcion';

        if ($(Cuerpo + 'txtTcEdicion').val() == '0')
            Cadena = Cadena + '<p></p>' + 'Tipo de Cambio';

        if ($(Cuerpo + 'txtFactorEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Factor';

        if (($(Cuerpo + 'ddlCompraEdicion').val() != $(Cuerpo + 'ddlVentaEdicion').val()) && ($(Cuerpo + 'txtFactorEdicion').val() == '1' | $(Cuerpo + 'txtFactorEdicion').val() == '1.00'))
            Cadena = Cadena + '<p></p>' + 'La unidad de compra y venta son distintas,el Factor no puede ser 1.';

        //        if (($(Cuerpo + 'ddlFamiliaEdicion').val() == '001' | $(Cuerpo + 'ddlFamiliaEdicion').val() == '003'  | $(Cuerpo + 'ddlFamiliaEdicion').val() == '007'  | $(Cuerpo + 'ddlFamiliaEdicion').val() == '008'  | $(Cuerpo + 'ddlFamiliaEdicion').val() == '006') && $(Cuerpo + 'txtAroEdicion').val()=='')
        //                Cadena=Cadena + '<p></p>' + 'Aro/Peso/Placas';

        //        if (($(Cuerpo + 'ddlFamiliaEdicion').val() == '001' | $(Cuerpo + 'ddlFamiliaEdicion').val() == '003'  | $(Cuerpo + 'ddlFamiliaEdicion').val() == '007') && $(Cuerpo + 'txtMedidaEdicion').val()=='')
        //                Cadena=Cadena + '<p></p>' + 'Medida';

        //        if (($(Cuerpo + 'ddlFamiliaEdicion').val() == '001' | $(Cuerpo + 'ddlFamiliaEdicion').val() == '003'  | $(Cuerpo + 'ddlFamiliaEdicion').val() == '007') && $(Cuerpo + 'txtSeccionEdicion').val()=='')
        //                Cadena=Cadena + '<p></p>' + 'Seccion';

        if ($(Cuerpo + 'txtCostoConIgvEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Costo';

        if ($(Cuerpo + 'txtPrecio1Edicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Precio 1';

        if ($(Cuerpo + 'txtPrecio2Edicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Precio 2';

        if ($(Cuerpo + 'txtPrecio3Edicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Precio 3';


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



var Ctlgv;
var Hfgv;

function imgMas_Click(Control) {
    Ctlgv = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {

        var grid = $(Control).next();
        F_LlenarGridDetalle(grid.attr('id'));
        //$(Control).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Control).next().html() + '</td></tr>');
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }

    return false;
}


function F_LlenarGridDetalle(Fila) {
    try {
        var nmrow = 'MainContent_grvKardex_pnlOrders_0';
        var Col = Fila.split('_')[3];
        var Codigo = $('#' + Fila.replace('pnlOrders', 'lblCodigo')).val();
        //var CodTipoDoc = $('#' + Fila.replace('pnlOrders', 'hfCodTipoDoc')).val();
        var Observacion = $('#' + Fila.replace('pnlOrders', 'hfObservacion')).val();
        var grvNombre = 'MainContent_grvKardex_grvDetalle_' + Col;
        Hfgv = '#' + Fila.replace('pnlOrders', 'hfDetalleCargado');

        if ($(Hfgv).val() === "1") {
            $(Ctlgv).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Ctlgv).next().html() + '</td></tr>');
        }
        else {
            {
                var objParams =
                        {
                            Filtro_Col: Col,
                            Filtro_Codigo: Codigo,
                            Filtro_Observacion: Observacion,
                            Filtro_grvNombre: grvNombre
                        };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);
                F_LlenarGridDetalle_NET(arg, function (result) {

                    MostrarEspera(false);

                    var str_resultado_operacion = result.split('~')[0];
                    var str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion === "0") {
                        var p = $('#' + result.split('~')[3]).parent();
                        $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                        F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);

                        $(Ctlgv).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Ctlgv).next().html() + '</td></tr>');
                        $(Hfgv).val('1');
                    }
                    else {
                        alertify.log(str_mensaje_operacion);
                    }

                    return false;

                });

            }

        }

    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("ERROR DETECTADO: " + e);
        return false;
    }

    return true;
}

