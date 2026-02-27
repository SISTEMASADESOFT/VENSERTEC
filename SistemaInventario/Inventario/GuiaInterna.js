var AppSession = "../Inventario/GuiaInterna.aspx";

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
    //    document.onkeydown = function (evt) {
    //        return (evt ? evt.which : event.keyCode) != 13;
    //    }

    $('.Jq-ui-dtp').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy'
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

    $('#MainContent_txtHasta').datepicker({ beforeShowDay: function (date) {
        return [date.getDate() == 1, ''];
    }
    });

    $('#MainContent_txtSerializacion').keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            F_AgregarTemporal();
            return false;
        }
        event.stopPropagation();
    });

    $('#MainContent_btnNuevo').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            $('#MainContent_txtMensaje').val('');
            $('#MainContent_txtSerializacion').val('');
            $('#MainContent_txtSerializacion').focus('');
            return false;
        }

        catch (e) {

            alert("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnBuscarConsulta').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_Buscar();
            return false;
        }

        catch (e) {

            alert("Error Detectado: " + e);
        }

    });

    F_Controles_Inicializar();

    $('#MainContent_txtSerializacion').css('background', '#FFFFE0');

    $('#MainContent_txtMensaje').css('background', '#FFFFE0');

    $('#MainContent_txtClienteConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtDesde').css('background', '#FFFFE0');

    $('#MainContent_txtHasta').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroConsulta').css('background', '#FFFFE0');
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

function getContentTab() {

    var date = new Date();
    date.setMonth(date.getMonth(), 1);

    $('#MainContent_txtDesde').val(date.format("dd/MM/yyyy"));

    $('#MainContent_chkRango').prop('checked', true);
    F_Buscar();
    return false;

}

function VerifySessionState(result) { }

function F_AgregarTemporal() {
    try {

        if ($('#MainContent_txtSerializacion').val() == '') {
            $('#MainContent_txtMensaje').val('Ingrese Serie');
            return false;
        }

        var objParams = {
            Filtro_Serie: $('#MainContent_txtSerializacion').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_AgregarTemporal_NET(arg, function (result) {


            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                if (result.split('~')[2] == 'Se Grabo Correctamente') {
                    $('#MainContent_txtMensaje').val(result.split('~')[2]);
                    $('#MainContent_txtSerializacion').val('');
                    $('#MainContent_txtSerializacion').focus('');
                }
                else {
                    $('#MainContent_txtMensaje').val(result.split('~')[2]);
                    $('#MainContent_txtSerializacion').val('');
                    $('#MainContent_txtSerializacion').focus('');
                }

            }
            else {
                alert(result.split('~')[2]);
            }

            return false;

        });
    }

    catch (e) {

        alert("Error Detectado: " + e);
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

function F_Buscar() {

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
            Filtro_CodTipoDoc: '4',
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
                if (str_mensaje_operacion != '')
                    alert(str_mensaje_operacion);

            }
            else {
                alert(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alert("Error Detectado: " + e);
        return false;
    }

}

function F_Controles_Inicializar() {

    var arg;

    try {
        var objParams =
            {
                Filtro_CodSerie: 67
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
                        F_Update_Division_HTML('div_serieconsulta', result.split('~')[2]);

                        $('#MainContent_ddlSerieConsulta').css('background', '#FFFFE0');
                    }
                    else {
                        alert(str_mensaje_operacion);
                    }
                }
            );

    } catch (mierror) {
        MostrarEspera(false);
        alert("Error detectado: " + mierror);

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