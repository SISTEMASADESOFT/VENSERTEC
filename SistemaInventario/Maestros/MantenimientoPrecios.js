var AppSession = "../Maestros/MantenimientoPrecios.aspx";
var CodigoMenu = 1000; var CodigoInterno = 8;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#MainContent_btnBuscar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

        try {
            F_Buscar_Productos()
        }
        catch (e) {

            alertify.log("Error Detectado: " + e);
        }


        return false;

    });

    $('#MainContent_btnAgregar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

        try {
            if (F_ValidarAgregar() == false)
                return false;
            if (confirm("Esta Seguro de Grabar") == false)
                return false;
            F_AgregarTemporal();

            $('#MainContent_txtArticulo').focus();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

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
                            CodProducto: item.split(',')[5]
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
            $('#hfCodProducto').val(i.item.CodProducto);
            $('#MainContent_lblStock').text(i.item.Stock);
            $('#MainContent_lblCosto').text(i.item.Costo);
            $('#MainContent_lblMoneda').text(i.item.Moneda);

        },
        minLength: 3
    });

    F_Controles_Inicializar();

    $('#MainContent_txtArticulo').css('background', '#FFFFE0');

    $('.ccsestilo').css('background', '#FFFFE0');

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
        var objParams = {
            Filtro_CodFamilia: '0xxx'
        };


        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Controles_Inicializar_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") {
                        F_Update_Division_HTML('div_Familia', result.split('~')[2]);
                        F_Update_Division_HTML('div_grvConsultaArticulo', result.split('~')[3]);
                        $('#MainContent_ddlFamilia').css('background', '#FFFFE0');
                        $('.ccsestilo').css('background', '#FFFFE0');
                        $('#MainContent_ddlFamilia').val('0');
                        $('#hfCodUsuario').val(result.split('~')[4]);
                        $('#hfCodSede').val(result.split('~')[5]);
                        return false;
                    }
                    else {

                        alertify.log(str_mensaje_operacion);
                        return false;
                    }


                }
            );

    } catch (mierror) {
        MostrarEspera(false);
        alertify.log("Error detectado: " + mierror);

    }

}

function F_Buscar_Productos() {

    var arg;

    try {
        var objParams =
            {
                Filtro_CodFamilia: $('#MainContent_ddlFamilia').val(),
                Filtro_CodProducto: $('#hfCodProducto').val()
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

        //        if ($('#hfCodUsuario').val() != '6' & $('#hfCodUsuario').val() != '11') {
        //            alertify.log("Permiso denegado");
        //            return false;
        //        }
        var cadena = "Ingrese los sgtes. campos: ";

        var x = 0;

        $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
            var chkSi = '#' + this.id;
            var txtDscProducto = chkSi.replace('chkOK', 'txtDscProducto');
            var txtM1 = chkSi.replace('chkOK', 'txtM1');
            var txtM2 = chkSi.replace('chkOK', 'txtM2');
            var lblCodProducto = chkSi.replace('chkOK', 'lblCodProducto');

            if ($(chkSi).is(':checked')) {
                if ($(txtDscProducto).val() == '')
                    cadena = cadena + "\n" + "Descripcion para el ID " + $(lblCodProducto).text();

                if ($(txtM1).val() == '0.00')
                    cadena = cadena + "\n" + "Margen 1 " + $(lblCodProducto).text();

                if ($(txtM2).val() == '0.00')
                    cadena = cadena + "\n" + "Margen 2 " + $(lblCodProducto).text();

                x = 1;
            }
        });

        if (x == 0)
            cadena = "No ha seleccionado ningun producto";

        if (cadena != "Ingrese los sgtes. campos: ") {
            alertify.log(cadena);
            return false;
        }

    }

    catch (e) {

        alertify.log("Error Detectado: " + e);
    }
}

function F_AgregarTemporal() {

    try {

        var arrDetalle = new Array();

        var lblCodProducto = '';
        var hfCodAlterno = '';
        var txtCosto = '';
        var txtMargen = '';
        var txtDescuento = '';
        var txtPrecio = '';


        $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
            var chkSi = '#' + this.id;

            lblCodProducto = chkSi.replace('chkOK', 'lblCodProducto');
            hfCodAlterno = chkSi.replace('chkOK', 'hfCodAlterno');
            lblCostoOriginal = chkSi.replace('chkOK', 'lblCostoOriginal');
            txtMargen = chkSi.replace('chkOK', 'txtMargen');
            txtDescuento = chkSi.replace('chkOK', 'txtDescuento');
            txtPrecio = chkSi.replace('chkOK', 'txtPrecio');

            if ($(chkSi).is(':checked')) {
                var objDetalle = {
                    CodProducto: $(lblCodProducto).text(),
                    CodAlterno: $(hfCodAlterno).val(),
                    Costo: $(lblCostoOriginal).text(),
                    Margen: $(txtMargen).val(),
                    Descuento: $(txtDescuento).val(),
                    Precio: $(txtPrecio).val()
                };

                arrDetalle.push(objDetalle);
            }
        });


        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_CodFamilia: $('#MainContent_ddlFamilia').val()

        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_AgregarTemporal_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_mensaje_operacion == "Se Grabo Correctamente")
                F_Update_Division_HTML('div_grvConsultaArticulo', result.split('~')[2]);

            $('.ccsestilo').css('background', '#FFFFE0');
            alertify.log(result.split('~')[1]);

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


    var boolEstado = false;
    var chkok_grilla = '';

    var cadena = 'Ingrese los sgtes. campos: '

    chkok_grilla = '#' + ControlID;

    var txtCosto = chkok_grilla.replace('chkOK', 'txtCosto');
    var txtDescuento = chkok_grilla.replace('chkOK', 'txtDescuento');
    var txtMargen = chkok_grilla.replace('chkOK', 'txtMargen');
    var txtPrecio = chkok_grilla.replace('chkOK', 'txtPrecio');


    boolEstado = $(chkok_grilla).is(':checked');
    if (boolEstado) {
        $(txtCosto).prop('disabled', false);
        $(txtMargen).prop('disabled', false);
        $(txtDescuento).prop('disabled', false);
        $(txtPrecio).prop('disabled', false);
    }
    else {
        $(txtCosto).prop('disabled', true);
        $(txtMargen).prop('disabled', true);
        $(txtDescuento).prop('disabled', true);
        $(txtPrecio).prop('disabled', true);
    }

    return true;
}

function F_Costo(ControlID) {

    var txtCosto = '#' + ControlID;
    var hfCosto = txtCosto.replace('txtCosto', 'hfCosto');

    if ($(txtCosto).val() == '' | $(txtCosto).val() == '0.00') {
        $(txtCosto).val($(hfCosto).val());
        return false;
    }

    var txtMargen = txtCosto.replace('txtCosto', 'txtMargen');
    var txtPrecio = txtCosto.replace('txtCosto', 'txtPrecio');

    if ($(txtPrecio).val() != '0.00' & $(txtMargen).val() != '0.00')
        $(txtPrecio).val(parseFloat((($(txtMargen).val() / 100) + 1) * $(txtCosto).val()).toFixed(2));

    return false;
}

function F_Precio(ControlID) {

    var txtPrecio = '#' + ControlID;
    var hfPrecio = txtPrecio2.replace('txtPrecio', 'hfPrecio');

    if ($(txtPrecio).val() == '' | $(txtPrecio).val() == '0.00') {
        $(txtPrecio).val($(hfPrecio).val());
        return false;
    }

    return false;
}

function F_Descuento(ControlID) {

    var txtDescuento = '#' + ControlID;
    var hfDescuento = txtDescuento.replace('txtDescuento', 'hfDescuento');

    if ($(txtDescuento).val() == '' | $(txtDescuento).val() == '0.00') {
        $(txtDescuento).val($(hfDescuento).val());
        return false;
    }

    return false;
}

function F_Margen(ControlID) {

    var txtMargen = '#' + ControlID;
    var hfMargen = txtMargen.replace('txtMargen', 'hfMargen');

    if ($(txtMargen).val() == '' | $(txtMargen).val() == '0.00') {
        $(txtMargen).val($(hfMargen).val());
        return false;
    }

    var txtPrecio = txtMargen.replace('txtMargen', 'txtPrecio');
    var lblCostoOriginal = txtMargen.replace('txtMargen', 'lblCostoOriginal');
    var Precio =( (parseFloat($(txtMargen).val()) / 100)+1 )*  parseFloat($(lblCostoOriginal).text());
    
    if ($('#MainContent_ddlFamilia').val() != "002") 
       Precio = (parseFloat(Precio * 2).toFixed(0)) / 2;
////    else 
        
// Precio = (Precio).toFixed(1);
    $(txtPrecio).val(Precio.toFixed(2));

    return false;
}


