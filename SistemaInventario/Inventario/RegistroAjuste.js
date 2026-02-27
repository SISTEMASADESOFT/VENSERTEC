var AppSession = "../Inventario/RegistroAjuste.aspx";
var CodigoMenu = 2000; var CodigoInterno = 2;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#MainContent_btnBuscar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        
        try {
            var cadena = "Ingresar los sgtes. campos :";
            if ($('#MainContent_txtArticulo').val == "")
                cadena = cadena + "\n" + "Articulo"


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

    $('#MainContent_btnAgregar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (!F_ValidarAgregar())
                return false;
            if (!confirm("ESTA SEGURO DE GRABAR EL AJUSTE"))
                return false;
            F_AgregarTemporal();

            $('#MainContent_txtArticulo').focus();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

//    $('#MainContent_txtArticulo').blur(function () {
//        try {

//            var cadena = "Ingresar los sgtes. campos :";
//            if ($('#MainContent_txtArticulo').val == "" | $('#MainContent_txtArticulo').val().length < 3)
//                cadena = cadena + "\n" + "Articulo (Minimo 3 Caracteres)"

//            if (cadena != "Ingresar los sgtes. campos :") {
//                alertify.log(cadena);
//                return false;
//            }

//            F_Buscar_Productos()
//        }
//        catch (e) {

//            alertify.log("Error Detectado: " + e);
//        }


//        return false;
//    });

    $('#MainContent_txtArticulo').css('background', '#FFFFE0');

    $('.ccsestilo').css('background', '#FFFFE0');

    $("#MainContent_txtArticulo").blur(function () {
        F_Buscar_Productos();
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

function F_Buscar_Productos() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    var arg;

    try {
        var objParams =
            {
                Filtro_DscProducto: $('#MainContent_txtArticulo').val(),
                Filtro_CodTipoProducto: 2,
                Filtro_CodTipoDoc: 0,
                Filtro_CodCliente: 0,
                Filtro_CodFamilia: 0
            };


        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Buscar_Productos_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") {
                        F_Update_Division_HTML('div_grvConsultaArticulo', result.split('~')[2]);
                        $('.ccsestilo').css('background', '#FFFFE0');
                        $('#lblGrillaConsulta').text(F_Numerar_Grilla("grvConsultaArticulo", 'lblCodigoProducto'));
                        if (str_mensaje_operacion == 'No se encontraron registros')
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

function F_ValidarAgregar() {

    try {
        var chkSi = '';
        var chkDel = '';
        var txtcantidad_grilla = '';
        var txtObservacion = '';
        var txtprecio_grilla = '';
        var cadena = "Ingrese los sgtes. campos: ";
        var hfCodProducto = '';
        var hfcodarticulodetalle_grilla = '';
        var lbldscproducto_grilla = '';
        var lblCodigoProducto = '';
        var x = 0;

        $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
            chkSi = '#' + this.id;
            txtprecio_grilla = chkSi.replace('chkOK', 'txtPrecioLibre');
            txtcantidad_grilla = chkSi.replace('chkOK', 'txtCantidad');
            hfCodProducto = chkSi.replace('chkOK', 'hfCodProducto');
            txtObservacion = chkSi.replace('chkOK', 'txtObservacion');
            lblCodigoProducto = chkSi.replace('chkOK', 'lblCodigoProducto');

            if ($(chkSi).is(':checked')) {
                if ($(txtprecio_grilla).val() == '')
                    cadena = cadena + "\n" + "Precio para el Codigo " + $(lblCodigoProducto).text();

                if ($(txtcantidad_grilla).val() == '')
                    cadena = cadena + "\n" + "Cantidad para el Codigo " + $(lblCodigoProducto).text();

                if ($(txtObservacion).val() == '')
                    cadena = cadena + "\n" + "Observacion para el Codigo " + $(lblCodigoProducto).text();

                x = 1;
            }
        });

        if (x == 0)
            cadena = "No ha seleccionado ningun producto";

        if (cadena != "Ingrese los sgtes. campos: ") {
            alertify.log(cadena);
            return false;
        }
        else {
            cadena = "Los sgtes. productos se encuentran agregados : ";
            $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
                chkSi = '#' + this.id;
                lblcodproducto_grilla = chkSi.replace('chkOK', 'lblcodproducto');

                if ($(chkSi).is(':checked')) {
                    $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
                        chkDel = '#' + this.id;
                        hfcodarticulodetalle_grilla = chkDel.replace('chkEliminar', 'hfcodarticulo');
                        lbldscproducto_grilla = chkDel.replace('chkEliminar', 'lblproducto');

                        if ($(lblcodproducto_grilla).text() == $(hfcodarticulodetalle_grilla).val()) {
                            cadena = cadena + "\n" + $(lbldscproducto_grilla).text();
                        }

                    });
                }
            });
        }

        if (cadena != "Los sgtes. productos se encuentran agregados : ") {
            alertify.log(cadena);
            return false;
        }
        else {
            return true;
        }
    }

    catch (e) {

        alertify.log("Error Detectado: " + e);
    }
}

function F_AgregarTemporal() {
    try {
        var lblcodproducto_grilla = '';
        var hfStock = '';
        var hfCodUnidadCompra_grilla = '';
        var hfCodUnidadVenta_grilla = '';
        var hfFactor_grilla = '';
        var txtcantidad_grilla = '';
        var chkSi = '';
        var txtObservacion = '';
        var arrDetalle = new Array();
        
        $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
            chkSi = '#' + this.id;
            hfCodProducto = chkSi.replace('chkOK', 'hfCodProducto');
            txtcantidad_grilla = chkSi.replace('chkOK', 'txtCantidad');
            hfStock = chkSi.replace('chkOK', 'lblChala1');
            hfCodUnidadCompra_grilla = chkSi.replace('chkOK', 'hfCodUnidadCompra');
            hfCodUnidadVenta_grilla = chkSi.replace('chkOK', 'hfCodUnidadVenta');
            hfFactor_grilla = chkSi.replace('chkOK', 'hfFactor');
            txtObservacion = chkSi.replace('chkOK', 'txtObservacion');

            if ($(chkSi).is(':checked')) {
                var objDetalle = {
                    CodProducto: $(hfCodProducto).val(),
                    Cantidad: $(txtcantidad_grilla).val(),
                    Ajuste: $(txtcantidad_grilla).val() - $(hfStock).text(),
                    CodUnidadCompra: $(hfCodUnidadCompra_grilla).val(),
                    CodUnidadVenta: $(hfCodUnidadVenta_grilla).val(),
                    Factor: $(hfFactor_grilla).val(),
                    Observacion: $(txtObservacion).val()
                };

                arrDetalle.push(objDetalle);
            }
        });
        
        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_DscProducto: $('#MainContent_txtArticulo').val(),
            Filtro_CodTipoProducto: 2,
            Filtro_CodTipoDoc: 0,
            Filtro_CodCliente: 0,
            Filtro_CodFamilia: 0
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_AgregarTemporal_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_mensaje_operacion == "Se Grabo Correctamente") {
                F_Update_Division_HTML('div_grvConsultaArticulo', result.split('~')[2]);
                $('.ccsestilo').css('background', '#FFFFE0');
                $('#lblGrillaConsulta').text(F_Numerar_Grilla("grvConsultaArticulo", 'lblCodigoProducto'));
                alertify.log('Se Grabo Correctamente');
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

function F_ValidarCheck(ControlID) {
    var txtObservacion = '';
    var txtprecio_Grilla = '';
    var ddlLista_grilla = '';
    var txtcant_grilla = '';
    var txtprecio_grilla = '';
    var boolEstado = false;
    var chkok_grilla = '';
    var cadena = 'Ingrese los sgtes. campos: '

    chkok_grilla = '#' + ControlID;
    txtprecio_grilla = chkok_grilla.replace('chkOK', 'txtPrecioLibre');
    txtcant_grilla = chkok_grilla.replace('chkOK', 'txtCantidad');
    ddlLista_grilla = chkok_grilla.replace('chkOK', 'ddlLista');
    txtObservacion = chkok_grilla.replace('chkOK', 'txtObservacion');

    boolEstado = $(chkok_grilla).is(':checked');
    if (boolEstado) {
        $(txtcant_grilla).prop('disabled', false);
        $(txtObservacion).prop('disabled', false);
        var i = 0;
        if ($(txtprecio_grilla).val() == "") {
            $(txtprecio_grilla).focus();
            i = 1
        }

        if (i == 0 && $(txtcant_grilla).val() == "")
        { $(txtcant_grilla).focus(); }
    }
    else {
        $(txtprecio_Grilla).val('');
        $(txtcant_grilla).val('');
        $(ddlLista_grilla).val('4');
        $(txtcant_grilla).prop('disabled', true);
        $(txtObservacion).prop('disabled', true);
    }
    return true;
}