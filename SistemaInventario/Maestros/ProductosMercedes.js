var AppSession = "../Maestros/ProductosMercedes.aspx";
var CodigoMenu = 1000; var CodigoInterno = 3;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#divTabs').tabs();


    $('#MainContent_txtModeloDetalle').autocomplete(
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_MODELOVEHICULO_AUTOCOMPLETE',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0]
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
            $('#hfCodModeloDetalle').val(i.item.val);
        },
        complete: function () {

        },
        minLength: 2
    });

    $('#MainContent_txtModeloDetalleEdicion').autocomplete(
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_MODELOVEHICULO_AUTOCOMPLETE',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0]
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
            $('#hfCodModeloDetalleEdicion').val(i.item.val);
        },
        complete: function () {

        },
        minLength: 2
    });

    $('#MainContent_txtLinea').autocomplete(
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_Linea_AUTOCOMPLETE',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0]
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
            $('#hfCodLinea').val(i.item.val);
        },
        complete: function () {

        },
        minLength: 1
    });

    $('#MainContent_txtLineaEdicion').autocomplete(
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_Linea_AUTOCOMPLETE',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0]
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
            $('#hfCodLineaEdicion').val(i.item.val);
        },
        complete: function () {

        },
        minLength: 1
    });

    $('#MainContent_txtMarca').autocomplete(
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_MARCAPRODUCTO_AUTOCOMPLETE',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0]
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
            $('#hfCodMarca').val(i.item.val);
        },
        complete: function () {

        },
        minLength: 1
    });

    $('#MainContent_txtMarcaEdicion').autocomplete(
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_MARCAPRODUCTO_AUTOCOMPLETE',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0]
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
            $('#hfCodMarcaEdicion').val(i.item.val);
        },
        complete: function () {

        },
        minLength: 1
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

    $('#MainContent_btnGrabar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (!F_ValidarGrabarDocumento())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR EL PRODUCTO"))
                F_GrabarDocumento();

            return false;
        }
        catch (e) {
            alertify.log("Error Detectado: " + e);
        }
    });


    $('#MainContent_btnGrabarDetalle').click(function () {
    if (F_PermisoOpcion(CodigoMenu, '333001', '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (!F_ValidarGrabarDetalle())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR EL DETALLE DEL PRODUCTO"))
                F_GrabarDetalle();

            return false;
        }
        catch (e) {
            alertify.log("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnGrabarDetalleEdicion').click(function () {
        try {
            if (!F_ValidarGrabarDetalleEdicion())
                return false;

            if (confirm("ESTA SEGURO DE ACTUALIZAR EL DETALLE DEL PRODUCTO"))
                F_EdicionDetalleRegistro();

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

    $('#MainContent_btnEdicion').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (!F_ValidarEdicionDocumento())
                return false;

            if (confirm("ESTA SEGURO DE ACTUALIZAR LOS DATOS DEL PRODUCTO"))
                F_EdicionRegistro();

            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $("#MainContent_txtCostoConIgv").blur(function () {

        if ($("#MainContent_txtMargen") == '' | $("#MainContent_txtCostoConIgv") == '')
            return false;

        $("#MainContent_txtPrecio3").val(parseFloat($("#MainContent_txtCostoConIgv").val() * ((parseFloat($("#MainContent_txtMargen").val()) / 100) + 1)).toFixed(2));

        if ($("#MainContent_ddlMonedaEdicion").val() == '2')
            $("#MainContent_txtCostoSolesEdicion").val(parseFloat($("#MainContent_txtCostoEdicion").val() * $("#MainContent_txtTcEdicion").val()).toFixed(6));
        else
            $("#MainContent_txtCostoSolesEdicion").val($("#MainContent_txtCostoEdicion").val());



        return false;

    });

    $("#MainContent_txtMargen").blur(function () {

        if ($("#MainContent_txtMargen") == '' | $("#MainContent_txtCosto") == '' | parseFloat($("#MainContent_txtMargen")) == 0)
            return false;


        $("#MainContent_txtPrecio3").val(parseFloat($("#MainContent_txtCostoConIgv").val() * ((parseFloat($("#MainContent_txtMargen").val()) / 100) + 1)).toFixed(2));

        if ($("#MainContent_ddlMoneda").val() == '2')
            $("#MainContent_txtCostoSolesIgv").val(parseFloat($("#MainContent_txtCostoConIgv").val() * $("#MainContent_txtTC").val()).toFixed(6));
        else
            $("#MainContent_txtCostoSolesIgv").val($("#MainContent_txtCostoConIgv").val());

        return false;

    });

    $("#MainContent_txtCostoConIgv").blur(function () {

        if ($("#MainContent_txtCostoConIgv") == '')
            return false;

        if ($("#MainContent_ddlMoneda").val() == '2')
            $("#MainContent_txtCostoSolesIgv").val(parseFloat($("#MainContent_txtCostoConIgv").val() * $("#MainContent_txtTC").val()).toFixed(6));
        else
            $("#MainContent_txtCostoSolesIgv").val($("#MainContent_txtCostoConIgv").val());

        return false;

    });

    $("#MainContent_txtMargenEdicion").blur(function () {

        if ($("#MainContent_txtMargenEdicion") == '' | $("#MainContent_txtCostoMercadoEdicion") == '' | parseFloat($("#MainContent_txtMargenEdicion")) == 0)
            return false;

        $("#MainContent_txtPrecio3Edicion").val(parseFloat($("#MainContent_txtCostoMercadoEdicion").val() * ((parseFloat($("#MainContent_txtMargenEdicion").val()) / 100) + 1)).toFixed(2));

        if ($("#MainContent_ddlMonedaEdicion").val() == '2')
            $("#MainContent_txtCostoSolesEdicion").val(parseFloat($("#MainContent_txtCostoEdicion").val() * $("#MainContent_txtTcEdicion").val()).toFixed(6));
        else
            $("#MainContent_txtCostoSolesEdicion").val($("#MainContent_txtCostoEdicion").val());

        if ($('#hfCodigoTemporal').val() == '1')
            $("#MainContent_txtCostoMercadoEdicion").val($("#MainContent_txtCostoEdicion").val());

        return false;

    });

    $("#MainContent_txtCostoMercadoEdicion").blur(function () {

        if ($("#MainContent_txtCostoMercadoEdicion").val() == '' | $("#MainContent_txtDescuentoEdicion").val() == '')
            return false;

        $("#MainContent_txtPrecio3Edicion").val(parseFloat($("#MainContent_txtCostoMercadoEdicion").val() * ((parseFloat($("#MainContent_txtMargenEdicion").val()) / 100) + 1)).toFixed(2));
        //      $("#MainContent_txtPrecio3Edicion").val(parseFloat($("#MainContent_txtCostoConIgvEdicion").val() * ((parseFloat($("#MainContent_txtMargenEdicion").val()) / 100) + 1)).toFixed(2));
        return false;
    });

    $("#MainContent_txtDescripcionConsulta").blur(function () {
        try {
            if ($('#MainContent_txtDescripcionConsulta').val() == '')
                return false;

            if ($('#MainContent_txtDescripcionConsulta').val == "" | $('#MainContent_txtDescripcionConsulta').val().length < 3)
                cadena = cadena + "Descripcion (Minimo 3 Caracteres)";

            F_Buscar();
            return false;
        }
        catch (e) {
            alertify.log("Error Detectado: " + e);
        }
    });

    $("#MainContent_txtAroEdicion").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtSeccionEdicion").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtFactorEdicion").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtCostoEdicion").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtCostoSolesEdicion").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtPrecio1Edicion").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtPrecio2Edicion").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtPrecio3Edicion").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtCostoMercadoEdicion").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtAro").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtSeccion").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtFactor").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtCosto").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtCostoSoles").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtPrecio1").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtPrecio2").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $("#MainContent_txtPrecio3").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
            e.preventDefault();
    });

    $('.Jq-ui-dtp').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy'
    });

    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
    $('.Jq-ui-dtp').datepicker('setDate', new Date());

    F_Controles_Inicializar();

    $('#MainContent_txtMargen').css('background', '#FFFFE0');

    $('#MainContent_txtDescuento').css('background', '#FFFFE0');

    $('#MainContent_txtCodigo').css('background', '#FFFFE0');

    $('#MainContent_txtTC').css('background', '#FFFFE0');

    $('#MainContent_txtCodigo2').css('background', '#FFFFE0');

    $('#MainContent_txtPartidaArancelaria').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcion2').css('background', '#FFFFE0');

    $('#MainContent_txtMedida').css('background', '#FFFFE0');

    $('#MainContent_TextBox2').css('background', '#FFFFE0');

    $('#MainContent_txtAroEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtSeccionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtPrecio3Edicion').css('background', '#FFFFE0');

    $('#MainContent_txtCostoMercadoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtAño').css('background', '#FFFFE0');

    $('#MainContent_txtCostoConIgv').css('background', '#FFFFE0');

    $('#MainContent_txtCostoSolesIgv').css('background', '#FFFFE0');

    $('#MainContent_txtFactor').css('background', '#FFFFE0');

    $('#MainContent_txtPrecio1').css('background', '#FFFFE0');

    $('#MainContent_txtPrecio2').css('background', '#FFFFE0');

    $('#MainContent_txtStockMinimo').css('background', '#FFFFE0');

    $('#MainContent_txtStockMaximo').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtCodigoProductoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtTcEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtCodigo2Edicion').css('background', '#FFFFE0');

    $('#MainContent_txtPartidaArancelariaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionInglesEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtLinea').css('background', '#FFFFE0');

    $('#MainContent_txtMarcaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtModeloEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtMedidaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtPosicionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtPrecio3').css('background', '#FFFFE0');

    $('#MainContent_txtCostoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtCostoSolesEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtFactorEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtPrecio1Edicion').css('background', '#FFFFE0');

    $('#MainContent_txtPrecio2Edicion').css('background', '#FFFFE0');

    $('#MainContent_txtSeccion').css('background', '#FFFFE0');

    $('#MainContent_txtAro').css('background', '#FFFFE0');

    $('#MainContent_txtMargenEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDescuentoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtMarca').css('background', '#FFFFE0');

    $('#MainContent_txtModelo').css('background', '#FFFFE0');

    $('#MainContent_txtMedida').css('background', '#FFFFE0');

    $('#MainContent_txtPosicion').css('background', '#FFFFE0');

    $('#MainContent_txtAño').css('background', '#FFFFE0');

    $('#MainContent_txtMarcaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtModeloEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtMedidaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtPosicionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtAñoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtPais').css('background', '#FFFFE0');

    $('#MainContent_txtPaisEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtCodAlternoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionAuxiliarEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtCodAlterno').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionAuxiliar').css('background', '#FFFFE0');

    $('#MainContent_txtUbicacion').css('background', '#FFFFE0');

    $('#MainContent_txtUbicacionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtMotor').css('background', '#FFFFE0');

    $('#MainContent_txtMotorEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcion2Edicion').css('background', '#FFFFE0');

    $('#MainContent_txtProductoHistorial').css('background', '#FFFFE0');

    $('#MainContent_txtMarcaHistorial').css('background', '#FFFFE0');

    $('#MainContent_txtCostoActual').css('background', '#FFFFE0');

    $('#MainContent_ddlFiltroCodEstado').css('background', '#FFFFE0');

    $('#MainContent_txtLineaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtProductoDetalle').css('background', '#FFFFE0');

    $('#MainContent_txtModeloDetalle').css('background', '#FFFFE0');

    $('#MainContent_txtAñoDetalle').css('background', '#FFFFE0');

    $('#MainContent_txtMotorDetalle').css('background', '#FFFFE0');

    $('#MainContent_txtProductoDetalleEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtModeloDetalleEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtAñoDetalleEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtMotorDetalleEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtCajaCambio').css('background', '#FFFFE0');

    $('#MainContent_txtFiltro').css('background', '#FFFFE0');

    $('#MainContent_txtTransmision').css('background', '#FFFFE0');

    $('#MainContent_txtCajaCambioEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtFiltroEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtTransmisionEdicion').css('background', '#FFFFE0');

    F_Derecha();

    
    $("#MainContent_txtDescripcionConsulta").blur(function () {
        F_Buscar();
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

$(document).on("change", "select[id $= 'MainContent_ddlMoneda']", function () {
    if ($("#MainContent_txtCostoConIgv") == '')
        return false;

    $("#MainContent_txtPrecio1").val(parseFloat($("#MainContent_txtCostoConIgv").val() * 1.12).toFixed(2));
    $("#MainContent_txtPrecio2").val(parseFloat($("#MainContent_txtCostoConIgv").val() * 1.15).toFixed(2));
    $("#MainContent_txtPrecio3").val(parseFloat($("#MainContent_txtCostoConIgv").val() * 1.20).toFixed(2));

    if ($("#MainContent_ddlMoneda").val() == '2')
        $("#MainContent_txtCostoSolesIgv").val(parseFloat($("#MainContent_txtCostoConIgv").val() * $("#MainContent_txtTC").val()).toFixed(6));
    else
        $("#MainContent_txtCostoSolesIgv").val($("#MainContent_txtCostoConIgv").val());

    return false;
});

$(document).on("change", "select[id $= 'MainContent_ddlMonedaEdicion']", function () {
    if ($("#MainContent_txtCostoEdicion") == '')
        return false;

    $("#MainContent_txtPrecio1Edicion").val(parseFloat($("#MainContent_txtCostoEdicion").val() * 1.12).toFixed(2));
    $("#MainContent_txtPrecio2Edicion").val(parseFloat($("#MainContent_txtCostoEdicion").val() * 1.15).toFixed(2));
    $("#MainContent_txtPrecio3Edicion").val(parseFloat($("#MainContent_txtCostoEdicion").val() * 1.20).toFixed(2));

    if ($("#MainContent_ddlMonedaEdicion").val() == '2')
        $("#MainContent_txtCostoSolesEdicion").val(parseFloat($("#MainContent_txtCostoEdicion").val() * $("#MainContent_txtTcEdicion").val()).toFixed(6));
    else
        $("#MainContent_txtCostoSolesEdicion").val($("#MainContent_txtCostoEdicion").val());

    return false;
});

$(document).on("change", "select[id $= 'MainContent_ddlUMCompra']", function () {
    $("#MainContent_ddlUMVenta").val($("#MainContent_ddlUMCompra").val());
    return false;
});

$(document).on("change", "select[id $= 'MainContent_ddlCompraEdicion']", function () {
    $("#MainContent_ddlVentaEdicion").val($("#MainContent_ddlCompraEdicion").val());
    return false;
});

function F_Controles_Inicializar() {

    var arg;

    try {
        var objParams = {
            Filtro_Fecha: $('#MainContent_txtFecha').val()
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
                        F_Update_Division_HTML('div_moneda', result.split('~')[2]);
                        F_Update_Division_HTML('div_umcompra', result.split('~')[4]);
                        F_Update_Division_HTML('div_umventa', result.split('~')[5]);
                        F_Update_Division_HTML('div_Familia', result.split('~')[6]);
                        F_Update_Division_HTML('div_familiaconsulta', result.split('~')[7]);
                        F_Update_Division_HTML('div_FamiliaEdicion', result.split('~')[8]);
                        F_Update_Division_HTML('div_MonedaEdicion', result.split('~')[9]);
                        F_Update_Division_HTML('div_CompraEdicion', result.split('~')[10]);
                        F_Update_Division_HTML('div_VentaEdicion', result.split('~')[11]);

                        F_Update_Division_HTML('div_Estado', result.split('~')[13]);
                        F_Update_Division_HTML('div_EstadoEdicion', result.split('~')[14]);

                        $('#MainContent_txtTC').val(result.split('~')[12]);
                        $('#MainContent_txtTcEdicion').val(result.split('~')[12]);
                        $('#MainContent_ddlMoneda').val('2');
                        $('#MainContent_ddlUMCompra').val('22');
                        $('#MainContent_ddlUMVenta').val('22');
                        $('#MainContent_txtFactor').val('1');
                        $('#MainContent_ddlFamiliaConsulta').val('0');

                        $('#MainContent_ddlEstado').val('1');
                        $('#MainContent_ddlEstadoEdicion').val('1');

                        $('#MainContent_txtCostoSolesIgv').prop('disabled', true);
                        $('#MainContent_txtPrecio1').prop('disabled', true);
                        $('#MainContent_txtPrecio2').prop('disabled', true);
                        $('#MainContent_txtPrecio3').prop('disabled', true);
                        $('#MainContent_ddlFamilia').css('background', '#FFFFE0');
                        $('#MainContent_ddlUMCompra').css('background', '#FFFFE0');
                        $('#MainContent_ddlUMVenta').css('background', '#FFFFE0');
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                        $('#MainContent_ddlFamiliaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlCompraEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlVentaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlMonedaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlFamiliaConsulta').css('background', '#FFFFE0');

                        $('#MainContent_ddlEstado').css('background', '#FFFFE0');
                        $('#MainContent_ddlEstadoEdicion').css('background', '#FFFFE0');



                        $('#MainContent_txtCodigo').focus();
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

function F_ValidarGrabarDocumento() {

    try {

        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtDescripcion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Descripcion';

        if ($(Cuerpo + 'txtTC').val() == '0')
            Cadena = Cadena + '<p></p>' + 'Tipo de Cambio';

        if ($(Cuerpo + 'txtFactor').val() == '')
            Cadena = Cadena + '<p></p>' + 'Factor';

        if (($(Cuerpo + 'ddlUMCompra').val() != $(Cuerpo + 'ddlUMVenta').val()) && ($(Cuerpo + 'txtFactor').val() == '1' | $(Cuerpo + 'txtFactor').val() == '1.00'))
            Cadena = Cadena + '<p></p>' + 'El Factor no puede ser 1.';

        //        if (($(Cuerpo + 'ddlFamilia').val() == '001' | $(Cuerpo + 'ddlFamilia').val() == '003'  | $(Cuerpo + 'ddlFamilia').val() == '007'  | $(Cuerpo + 'ddlFamilia').val() == '008'  | $(Cuerpo + 'ddlFamilia').val() == '006') && $(Cuerpo + 'txtAro').val()=='')
        //                Cadena=Cadena + '<p></p>' + 'Aro/Peso/Placas';

        //        if (($(Cuerpo + 'ddlFamilia').val() == '001' | $(Cuerpo + 'ddlFamilia').val() == '003'  | $(Cuerpo + 'ddlFamilia').val() == '007') && $(Cuerpo + 'txtMedida').val()=='')
        //                Cadena=Cadena + '<p></p>' + 'Medida';

        //        if (($(Cuerpo + 'ddlFamilia').val() == '001' | $(Cuerpo + 'ddlFamilia').val() == '003'  | $(Cuerpo + 'ddlFamilia').val() == '007') && $(Cuerpo + 'txtSeccion').val()=='')
        //                Cadena=Cadena + '<p></p>' + 'Seccion';

        if ($(Cuerpo + 'txtCostoConIgv').val() == '')
            Cadena = Cadena + '<p></p>' + 'Costo';

        if ($(Cuerpo + 'txtDescuento').val() == '')
            Cadena = Cadena + '<p></p>' + 'Descuento';

        if ($(Cuerpo + 'txtMargen').val() == '')
            Cadena = Cadena + '<p></p>' + 'Margen';

        if ($(Cuerpo + 'txtPrecio3').val() == '')
            Cadena = Cadena + '<p></p>' + 'Precio';

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
        var Contenedor = '#MainContent_';
        var Aro = '0';
        var Medida = '0';
        var Seccion = '0';

        var objParams = {
            Filtro_CodFamilia: $(Contenedor + 'ddlFamilia').val(),
            Filtro_DscProducto: $(Contenedor + 'txtDescripcion').val(),
            Filtro_DscProducto2: $(Contenedor + 'txtDescripcion2').val(),
            Filtro_DscProductoIngles: $(Contenedor + 'txtLinea').val(),
            Filtro_DescripcionAuxiliar: $(Contenedor + 'txtDescripcionAuxiliar').val(),
            Filtro_CodTipoProducto: '2',
            Filtro_CodUnidadCompra: $(Contenedor + 'ddlUMCompra').val(),
            Filtro_CodUnidadVenta: $(Contenedor + 'ddlUMVenta').val(),
            Filtro_Costo: $(Contenedor + 'txtCostoConIgv').val(),
            Filtro_CostoOriginal: $(Contenedor + 'txtCostoSolesIgv').val(),
            Filtro_Factor: $(Contenedor + 'txtFactor').val(),
            Filtro_CodigoProducto: $(Contenedor + 'txtCodigo').val(),
            Filtro_CodigoAlternativo: $(Contenedor + 'txtCodigo2').val(),
            Filtro_Descuento: $(Contenedor + 'txtDescuento').val(),
            Filtro_Margen: $(Contenedor + 'txtMargen').val(),
            Filtro_Precio3: $(Contenedor + 'txtPrecio3').val(),
            Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
            Filtro_Aro: Aro,
            Filtro_Medida: $(Contenedor + 'txtMedida').val(),
            Filtro_Seccion: Seccion,
            Filtro_Marca: $(Contenedor + 'txtMarca').val(),
            Filtro_Modelo: $(Contenedor + 'txtModelo').val(),
            Filtro_Posicion: $(Contenedor + 'txtPosicion').val(),
            Filtro_Año: $(Contenedor + 'txtAño').val(),
            Filtro_Pais: $(Contenedor + 'txtPais').val(),
            Filtro_Ubicacion: $(Contenedor + 'txtUbicacion').val(),
            Filtro_Motor: $(Contenedor + 'txtMotor').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstado').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarDocumento_NET(arg, function (result) {
            //                var Entity = Sys.Serialization.JavaScriptSerializer.deserialize(result);

            //                MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Se Grabo Correctamente.') {

                    $(Contenedor + 'txtCodigo').val('');
                    $(Contenedor + 'txtDescripcion').val('');
                    $(Contenedor + 'txtAro').val('');
                    $(Contenedor + 'txtMedida').val('');
                    $(Contenedor + 'txtSeccion').val(''),
                            $(Contenedor + 'txtFactor').val('1'),
                            $(Contenedor + 'txtCostoConIgv').val('');
                    $(Contenedor + 'txtCostoSolesIgv').val('');
                    $(Contenedor + 'ddlMoneda').val('2');
                    $(Contenedor + 'ddlUMCompra').val('22');
                    $(Contenedor + 'ddlUMVenta').val('22');
                    $(Contenedor + 'ddlFamilia').val('009');
                    $(Contenedor + 'txtPrecio1').val(''),
                            $(Contenedor + 'txtPrecio2').val('');
                    $(Contenedor + 'txtPrecio3').val('');
                    $(Contenedor + 'txtMarca').val('');
                    $(Contenedor + 'txtPosicion').val('');
                    $(Contenedor + 'txtAño').val('');
                    $(Contenedor + 'txtPais').val('');
                    $(Contenedor + 'txtModelo').val('');
                    $(Contenedor + 'txtCodigo2').val('');
                    $(Contenedor + 'txtMargen').val('');
                    $(Contenedor + 'txtDescuento').val('');
                    $(Contenedor + 'txtDescripcionAuxiliar').val('');
                    $(Contenedor + 'txtMotor').val('');
                    $(Contenedor + 'txtUbicacion').val('');
                    $(Contenedor + 'txtDescripcion2').val('');
                    $(Contenedor + 'ddlEstado').val('1');
                    $(Contenedor + 'txtAro').prop('disabled', false);
                    $(Contenedor + 'txtSeccion').prop('disabled', false),
                            alertify.log('Se Grabo Correctamente.');
                    $(Contenedor + 'txtCodigo').focus();
                }
                else
                    alertify.log(result.split('~')[1]);
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

function F_Nuevo() {
    var Contenedor = '#MainContent_';
    $(Contenedor + 'txtDescripcionAuxiliar').val('');
    $(Contenedor + 'txtCodigo').val('');
    $(Contenedor + 'txtDescripcion').val('');
    $(Contenedor + 'txtAro').val('');
    $(Contenedor + 'txtMedida').val('');
    $(Contenedor + 'txtLinea').val('');
    $(Contenedor + 'txtLineaEdicion').val('');
    $(Contenedor + 'txtSeccion').val(''),
                        $(Contenedor + 'txtFactor').val('1'),
                        $(Contenedor + 'txtCostoConIgv').val('');
    $(Contenedor + 'txtCostoSolesIgv').val('');
    $(Contenedor + 'ddlMoneda').val('2');
    $(Contenedor + 'ddlUMCompra').val('22');
    $(Contenedor + 'ddlUMVenta').val('22');
    $(Contenedor + 'ddlFamilia').val('007');
    $(Contenedor + 'txtMargen').val(''),
                        $(Contenedor + 'txtDescuento').val('');
    $(Contenedor + 'txtPrecio3').val('');
    $(Contenedor + 'txtAro').prop('disabled', false);
    $(Contenedor + 'txtSeccion').prop('disabled', false),
                        $(Contenedor + 'txtCodigo').focus();
    return false;
}

function F_Buscar() {
    //    if ($.trim($('#MainContent_txtDescripcionConsulta').val()) == '') {
    //    alertify.log('DEBE INDICAR POR LO MENOS TRES LETRAS DEL NOMBRE DEL PRODUCTO')
    //    return false
    //    }
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    if (($.trim($('#MainContent_txtDescripcionConsulta').val()) == "" || $('#MainContent_txtDescripcionConsulta').val().length < 3) & $('#MainContent_ddlFamiliaConsulta').val() == '0') {
        var cadena = 'Descripcion (Minimo 3 Caracteres)';
        alertify.log(cadena);
        return false;
    }
    try {
        var objParams = {
            Filtro_DscProducto: $("#MainContent_txtDescripcionConsulta").val(),
            Filtro_CodFamilia: $('#MainContent_ddlFamiliaConsulta').val(),
            Filtro_CodTipoProducto: 2,
            Filtro_CodTipoDoc: 0,
            Filtro_CodCliente: 0,
            Filtro_CodEstadoBusqueda: $('#MainContent_ddlFiltroCodEstado').val()
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
                if (str_mensaje_operacion != "")
                    alertify.log(result.split('~')[1]);
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

function F_AnularRegistro(Fila) {
if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var imgID = Fila.id;
        var lblCodigo = '#' + imgID.replace('imgAnularDocumento', 'hfCodProducto');
        var lblProducto_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblProducto');

        if (!confirm("ESTA SEGURO DE ELIMINAR EL PRODUCTO " + $(lblProducto_grilla).text()))
            return false;

        var objParams = {
            Filtro_CodProducto: $(lblCodigo).val(),
            Filtro_DscProducto: $("#MainContent_txtDescripcionConsulta").val(),
            Filtro_CodFamilia: $('#MainContent_ddlFamiliaConsulta').val(),
            Filtro_CodTipoProducto: 2,
            Filtro_CodTipoDoc: 0,
            Filtro_CodCliente: 0
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_AnularRegistro_Net(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
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
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }


}

function F_EditarRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var lblCodigoProducto_grilla = '#' + imgID.replace('imgEditarRegistro', 'lblCodigoProducto');
        var lblProducto_grilla = '#' + imgID.replace('imgEditarRegistro', 'lblProducto');
        var lblCosto_grilla = '#' + imgID.replace('imgEditarRegistro', 'lblCosto');
        var lblDescuento = '#' + imgID.replace('imgEditarRegistro', 'lblDescuento');
        var lblMargen = '#' + imgID.replace('imgEditarRegistro', 'lblMargen');
        var lblPrecio3_grilla = '#' + imgID.replace('imgEditarRegistro', 'lblPrecio3');
        var hfMedida = '#' + imgID.replace('imgEditarRegistro', 'hfMedida');
        var hfCodMoneda_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodMoneda');
        var hfCodUnidadCompra_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodUnidadCompra');
        var hfCodUnidadVenta_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodUnidadVenta');
        var hfCodFamilia_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodFamilia');
        var hfFactor_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfFactor');
        var hfCodigo = '#' + imgID.replace('imgEditarRegistro', 'hfCodProducto');
        var lblcostomercado_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCostoMercado');
        var lblcostosoles_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCostoSoles');
        var hfAño = '#' + imgID.replace('imgEditarRegistro', 'hfAño');
        var hfMarca = '#' + imgID.replace('imgEditarRegistro', 'lblMarca');
        var hfModelo = '#' + imgID.replace('imgEditarRegistro', 'hfModelo');
        var hfPosicion = '#' + imgID.replace('imgEditarRegistro', 'hfPosicion');
        var hfPais = '#' + imgID.replace('imgEditarRegistro', 'hfPais');
        var hfCodigoAlternativo = '#' + imgID.replace('imgEditarRegistro', 'hfCodigoAlternativo');
        var hfCodAlterno = '#' + imgID.replace('imgEditarRegistro', 'hfCodAlterno');
        var hfDescripcionAuxiliar = '#' + imgID.replace('imgEditarRegistro', 'hfDescripcionAuxiliar');
        var lblUbicacion = '#' + imgID.replace('imgEditarRegistro', 'lblUbicacion');
        var hfMotor = '#' + imgID.replace('imgEditarRegistro', 'hfMotor');
        var hfDscProducto2 = '#' + imgID.replace('imgEditarRegistro', 'hfDscProducto2');
        var hfCodEstado = '#' + imgID.replace('imgEditarRegistro', 'hfCodEstado');
        var lblDescripcionIngles = '#' + imgID.replace('imgEditarRegistro', 'lblDescripcionIngles');

        var Cuerpo = '#MainContent_';

        $(Cuerpo + 'txtCodigoProductoEdicion').val($(lblCodigoProducto_grilla).text());
        $(Cuerpo + 'ddlFamiliaEdicion').val($(hfCodFamilia_grilla).val());
        $(Cuerpo + 'txtDescripcionEdicion').val($(lblProducto_grilla).text().replace("(N)", ""));
        $(Cuerpo + 'txtDescripcion2Edicion').val($(hfDscProducto2).val());
        $(Cuerpo + 'txtMedidaEdicion').val($(hfMedida).val());
        $(Cuerpo + 'txtFactorEdicion').val($(hfFactor_grilla).val());
        $(Cuerpo + 'txtCostoEdicion').val($(lblCosto_grilla).text());
        $(Cuerpo + 'ddlMonedaEdicion').val($(hfCodMoneda_grilla).val());
        $(Cuerpo + 'ddlCompraEdicion').val($(hfCodUnidadCompra_grilla).val());
        $(Cuerpo + 'ddlVentaEdicion').val($(hfCodUnidadVenta_grilla).val());
        $(Cuerpo + 'txtCostoSolesEdicion').val($(lblcostosoles_grilla).val());
        $(Cuerpo + 'txtDescuentoEdicion').val($(lblDescuento).text());
        $(Cuerpo + 'txtMargenEdicion').val($(lblMargen).text());
        $(Cuerpo + 'txtPrecio3Edicion').val($(lblPrecio3_grilla).text());
        $(Cuerpo + 'txtPrecio1Edicion').prop('disabled', true);
        $(Cuerpo + 'txtPrecio2Edicion').prop('disabled', true);
        $(Cuerpo + 'txtPrecio3Edicion').prop('disabled', true);
        $(Cuerpo + 'txtCostoSolesEdicion').prop('disabled', true);
        $(Cuerpo + 'txtCostoMercadoEdicion').val($(lblcostomercado_grilla).val());
        $('#hfCodProducto').val($(hfCodigo).val());
        $(Cuerpo + 'txtAñoEdicion').val($(hfAño).val());
        $(Cuerpo + 'txtMarcaEdicion').val($(hfMarca).text());
        $(Cuerpo + 'txtPosicionEdicion').val($(hfPosicion).val());
        $(Cuerpo + 'txtPaisEdicion').val($(hfPais).val());
        $(Cuerpo + 'txtModeloEdicion').val($(hfModelo).val());
        $(Cuerpo + 'txtCodigo2Edicion').val($(hfCodigoAlternativo).val());
        $(Cuerpo + 'txtCodAlternoEdicion').val($(hfCodAlterno).val());
        $(Cuerpo + 'txtDescripcionAuxiliarEdicion').val($(hfDescripcionAuxiliar).val());
        $(Cuerpo + 'txtFactorEdicion').prop('disabled', true);
        $(Cuerpo + 'txtUbicacionEdicion').val($(lblUbicacion).text());
        $(Cuerpo + 'txtMotorEdicion').val($(hfMotor).val());
        $(Cuerpo + 'ddlEstadoEdicion').val($(hfCodEstado).val());
        $(Cuerpo + 'txtLineaEdicion').val($(lblDescripcionIngles).val());

        var d = new Date();
        var objParams = {
            Filtro_CodProducto: $('#hfCodProducto').val(),
            Filtro_Emision: d.format("dd/MM/yyyy")
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ConsultaMovimiento_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                $(Cuerpo + 'txtTcEdicion').val(result.split('~')[4]);

                if (result.split('~')[2] == '0') {
                    $(Cuerpo + 'txtCostoEdicion').prop('disabled', false);
                    $('#hfCodigoTemporal').val('1');
                }
                else {
                    $(Cuerpo + 'txtCostoEdicion').prop('disabled', true);
                    $(Cuerpo + 'ddlMonedaEdicion').prop('disabled', true);
                    $(Cuerpo + 'ddlVentaEdicion').prop('disabled', true);
                }

                if (result.split('~')[3] == '5') {
                    $(Cuerpo + 'txtCostoMercadoEdicion').prop('disabled', false);
                    $('#hfCodigoTemporal').val('2');
                }
                else
                    $(Cuerpo + 'txtCostoMercadoEdicion').prop('disabled', true);

                $("#divEdicionRegistro").dialog({
                    resizable: false,
                    modal: true,
                    title: "Edicion de Productos",
                    title_html: true,
                    height: 460,
                    width: 710,
                    autoOpen: false
                });

                $('#divEdicionRegistro').dialog('open');
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

function F_EdicionRegistro() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Contenedor = '#MainContent_';
        var Aro = '0';
        var Medida = '0';
        var Seccion = '0';

        var objParams = {
            Filtro_CodProducto: $('#hfCodProducto').val(),
            Filtro_CodFamiliaEdicion: $(Contenedor + 'ddlFamiliaEdicion').val(),
            Filtro_DscProductoEdicion: $(Contenedor + 'txtDescripcionEdicion').val(),
            Filtro_DscProducto2Edicion: $(Contenedor + 'txtDescripcion2Edicion').val(),
            Filtro_DescripcionAuxiliar: $(Contenedor + 'txtDescripcionAuxiliarEdicion').val(),
            Filtro_DscProductoIngles: $(Contenedor + 'txtLineaEdicion').val(),
            Filtro_CodTipoProducto: '2',
            Filtro_CodUnidadCompra: $(Contenedor + 'ddlCompraEdicion').val(),
            Filtro_CodUnidadVenta: $(Contenedor + 'ddlVentaEdicion').val(),
            Filtro_Costo: $(Contenedor + 'txtCostoSolesEdicion').val(),
            Filtro_CostoOriginal: $(Contenedor + 'txtCostoEdicion').val(),
            Filtro_Factor: parseFloat($(Contenedor + 'txtFactorEdicion').val()),
            Filtro_CodigoProducto: $(Contenedor + 'txtCodigoProductoEdicion').val(),
            Filtro_CodigoAlternativo: $(Contenedor + 'txtCodigo2Edicion').val(),
            Filtro_Descuento: $(Contenedor + 'txtDescuentoEdicion').val(),
            Filtro_Margen: $(Contenedor + 'txtMargenEdicion').val(),
            Filtro_Precio3: $(Contenedor + 'txtPrecio3Edicion').val(),
            Filtro_CodMoneda: $(Contenedor + 'ddlMonedaEdicion').val(),
            Filtro_Aro: Aro,
            Filtro_Medida: $(Contenedor + 'txtMedidaEdicion').val(),
            Filtro_Seccion: Seccion,
            Filtro_Marca: $(Contenedor + 'txtMarcaEdicion').val(),
            Filtro_Modelo: $(Contenedor + 'txtModeloEdicion').val(),
            Filtro_Posicion: $(Contenedor + 'txtPosicionEdicion').val(),
            Filtro_Año: $(Contenedor + 'txtAñoEdicion').val(),
            Filtro_Pais: $(Contenedor + 'txtPaisEdicion').val(),
            Filtro_CostoMarginable: $(Contenedor + 'txtCostoMercadoEdicion').val(),
            Filtro_Flag: $('#hfCodigoTemporal').val(),
            Filtro_DscProducto: $(Contenedor + 'txtDescripcionConsulta').val(),
            Filtro_Ubicacion: $(Contenedor + 'txtUbicacionEdicion').val(),
            Filtro_Motor: $(Contenedor + 'txtMotorEdicion').val(),
            Filtro_CodFamilia: 0,
            Filtro_CodTipoDoc: 0,
            Filtro_CodCliente: 0,
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoEdicion').val(),
            Filtro_CodEstadoBusqueda: $('#MainContent_ddlFiltroCodEstado').val(),
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EdicionRegistro_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Se Actualizo Correctamente.') {
                    F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                    $(Contenedor + 'txtCodigoProductoEdicion').val('');
                    $(Contenedor + 'txtDescripcionEdicion').val('');
                    $(Contenedor + 'txtAroEdicion').val('');
                    $(Contenedor + 'txtMedidaEdicion').val('');
                    $(Contenedor + 'txtSeccionEdicion').val(''),
                        $(Contenedor + 'txtFactorEdicion').val('1'),
                        $(Contenedor + 'txtCostoConIgvEdicion').val('');
                    $(Contenedor + 'txtCostoSolesIgvEdicion').val('');
                    $(Contenedor + 'txtPrecio1').val(''),
                        $(Contenedor + 'txtPrecio2').val('');
                    $(Contenedor + 'txtPrecio3').val('');
                    $(Contenedor + 'ddlEstadoEdicion').val('');
                    $(Contenedor + 'txtAroEdicion').prop('disabled', false);
                    $(Contenedor + 'txtSeccionEdicion').prop('disabled', false),
                        alertify.log('Se Actualizo Correctamente.');
                    $('#divEdicionRegistro').dialog('close');
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



function F_HistorialCostos(Fila) {
    if (F_PermisoOpcion(CodigoMenu, '333004', '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var hfCodProducto = '#' + imgID.replace('imgHistorialCosto', 'hfCodProducto');
        var lblCodigoProducto_grilla = '#' + imgID.replace('imgHistorialCosto', 'lblCodigoProducto');
        var lblProducto_grilla = '#' + imgID.replace('imgHistorialCosto', 'lblProducto');
        var lblMarca_grilla = '#' + imgID.replace('imgHistorialCosto', 'lblMarca');
        var lblcostomercado_grilla = '#' + imgID.replace('imgHistorialCosto', 'hfCostoMercado');
        var hfCodMoneda_grilla = '#' + imgID.replace('imgHistorialCosto', 'hfCodMoneda');
        var Mon = 'S/ ';
        if ($(hfCodMoneda_grilla).val() === '2')
            Mon = '$/ '

        var MarcaProducto = $(lblMarca_grilla).text().trim();
        var TituloProducto = $(lblCodigoProducto_grilla).text() + ' - ' + $(lblProducto_grilla).text();
        $('#MainContent_txtCostoActual').val(Mon + $(lblcostomercado_grilla).val());

        var objParams = {
            Filtro_CodProducto: $(hfCodProducto).val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ConsultaHistorialCostos_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            if (result.split('~')[1] == "") {

                F_Update_Division_HTML('div_grvHistorialCostos', result.split('~')[2]);

                $('#MainContent_txtProductoHistorial').val(TituloProducto.replace(MarcaProducto, ''));
                $('#MainContent_txtMarcaHistorial').val(MarcaProducto);

                $("#div_HistorialCostos").dialog({
                    resizable: false,
                    modal: true,
                    title: "Historial de Costos Productos",
                    title_html: true,
                    height: 500,
                    width: 1150,
                    autoOpen: false
                });

                $('#div_HistorialCostos').dialog('open');
            }
            else {
                alertify.log(result.split('~')[1]);
            }
            MostrarEspera(false);
            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
}






function F_ValidarGrabarDetalle() {
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtModeloDetalle').val() == '' | $('#hfCodModeloDetalle').val()==0)
            Cadena = Cadena + '<p></p>' + 'Modelo';
            
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

function F_GrabarDetalle() {
    try {
        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_CodProducto: $('#hfCodProducto').val(),
            Filtro_CodModeloVehiculo: $('#hfCodModeloDetalle').val(),
            Filtro_Anio: $(Contenedor + 'txtAñoDetalle').val(),
            Filtro_Motor: $(Contenedor + 'txtMotorDetalle').val(),
            Filtro_Transmision: $(Contenedor + 'txtTransmision').val(),
            Filtro_CajaCambio: $(Contenedor + 'txtCajaCambio').val(),
            Filtro_Filtro: $(Contenedor + 'txtFiltro').val()          
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarDetalle_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE GRABO CORRECTAMENTE') {
                    $('#hfCodModeloDetalle').val(0);
                    $(Contenedor + 'txtAñoDetalle').val('');
                    $(Contenedor + 'txtMotorDetalle').val('');
                    $(Contenedor + 'txtModeloDetalle').val('');
                    $(Contenedor + 'txtTransmision').val('');
                    $(Contenedor + 'txtCajaCambio').val('');
                    $(Contenedor + 'txtFiltro').val('');
                    F_Buscar_Detalle($('#hfCodProducto').val());
                    alertify.log('Se Grabo Correctamente.');
                }
                else
                    alertify.log(result.split('~')[1]);
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

function F_ActualizarDetalle() {
    try {
        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_CodProducto: $('#hfCodProducto').val(),
            Filtro_CodModeloVehiculo: $('#hfCodModeloDetalle').val(),
            Filtro_Anio: $(Contenedor + 'txtAñoDetalle').val(),
            Filtro_Motor: $(Contenedor + 'txtMotorDetalle').val(),
            Filtro_Transmision: $(Contenedor + 'txtTransmisionEdicion').val(),
            Filtro_CajaCambio: $(Contenedor + 'txtCajaCambioEdicion').val(),
            Filtro_Filtro: $(Contenedor + 'txtFiltroEdicion').val()     
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ActualizarDetalle_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Se Grabo Correctamente.') {
                    F_Buscar_Detalle();
                    alertify.log('Se Grabo Correctamente.');
                }
                else
                    alertify.log(result.split('~')[1]);
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

function F_Buscar_Detalle(CodProducto) {
    try {
        var objParams = {
            Filtro_CodProducto: CodProducto
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_Buscar_Detalle_NET(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_ProductoDetalle', result.split('~')[2]);
                if (str_mensaje_operacion != "")
                    alertify.log(result.split('~')[1]);
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

function F_DetalleProducto(Fila) {
    var imgID = Fila.id;
    var Contenedor = '#MainContent_';
    var lblCodigo = '#' + imgID.replace('imgDetalleProducto', 'hfCodProducto');
    var lblCodigoProducto = '#' + imgID.replace('imgDetalleProducto', 'lblCodigoProducto');
    var lblProducto = '#' + imgID.replace('imgDetalleProducto', 'lblProducto');
    $('#hfCodProducto').val($(lblCodigo).val());
    $(Contenedor + 'txtProductoDetalle').val($(lblProducto).text());
    $(Contenedor + 'txtModeloDetalle').val('');
    $(Contenedor + 'txtAñoDetalle').val('');
    $(Contenedor + 'txtMotorDetalle').val('');
    $(Contenedor + 'txtCajaCambio').val('');
    $(Contenedor + 'txtTransmision').val('');
    $(Contenedor + 'txtFiltro').val('');
    $('#hfCodModeloDetalle').val(0);
    $('#div_DetalleProducto').dialog({
        resizable: false,
        modal: true,
        title: "DETALLE PRODUCTO",
        title_html: true,
        height: 500,
        width: 890,
        autoOpen: false
    });
    $('#div_DetalleProducto').dialog('open');
    F_Buscar_Detalle($(lblCodigo).val());
    return false;
}

function F_EliminarDetalleProducto(Fila) {
    if (F_PermisoOpcion(CodigoMenu, '333003', '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var hfCodProductoModelo = '#' + imgID.replace('imgAnularDocumento', 'hfCodProductoModelo');
    
        if (!confirm("ESTA SEGURO DE ELIMINAR EL DETALLE"))
            return false;

        var objParams = {
            Filtro_CodProductoModelo: $(hfCodProductoModelo).val()   
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Eliminar_Detalle_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                F_Buscar_Detalle($('#hfCodProducto').val())
                alertify.log(result.split('~')[1]);
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

function F_EditarDetalleProducto(Fila) {
    if (F_PermisoOpcion(CodigoMenu, '333002', '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var imgID = Fila.id;
        var lblLinea = '#' + imgID.replace('imgEditarRegistro', 'lblLinea');
        var hfCodProductoModelo = '#' + imgID.replace('imgEditarRegistro', 'hfCodProductoModelo');
        var hfCodModelo = '#' + imgID.replace('imgEditarRegistro', 'hfCodModelo');
        var lblModelo = '#' + imgID.replace('imgEditarRegistro', 'lblModelo');
        var lblAño = '#' + imgID.replace('imgEditarRegistro', 'lblAño');
        var lblMotor = '#' + imgID.replace('imgEditarRegistro', 'lblMotor');
        var lblCajaCambio = '#' + imgID.replace('imgEditarRegistro', 'lblCajaCambio');
        var lblTransmision = '#' + imgID.replace('imgEditarRegistro', 'lblTransmision');
        var lblFiltro = '#' + imgID.replace('imgEditarRegistro', 'lblFiltro');   
        var Cuerpo = '#MainContent_';

        $(Cuerpo + 'txtProductoDetalleEdicion').val($(Cuerpo + 'txtProductoDetalle').val());
        $(Cuerpo + 'txtModeloDetalleEdicion').val($(lblLinea).text() + ' - ' + $(lblModelo).text());
        $(Cuerpo + 'txtAñoDetalleEdicion').val($(lblAño).text());
        $(Cuerpo + 'txtMotorDetalleEdicion').val($(lblMotor).text());
        $(Cuerpo + 'txtCajaCambioEdicion').val($(lblCajaCambio).text());
        $(Cuerpo + 'txtTransmisionEdicion').val($(lblTransmision).text());
        $(Cuerpo + 'txtFiltroEdicion').val($(lblFiltro).text());
        $('#hfCodModeloDetalleEdicion').val($(hfCodModelo).val());
        $('#hfCodProductoModelo').val($(hfCodProductoModelo).val());
        
        $("#div_DetalleProductoEditar").dialog({
            resizable: false,
            modal: true,
            title: "Edicion Detalle Producto",
            title_html: true,
            height: 250,
            width: 500,
            autoOpen: false
        });

        $('#div_DetalleProductoEditar').dialog('open');
    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function F_EdicionDetalleRegistro() {
    try {
        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_CodProductoModelo: $('#hfCodProductoModelo').val(),
            Filtro_CodProducto: $('#hfCodProducto').val(),
            Filtro_CodModeloVehiculo: $('#hfCodModeloDetalleEdicion').val(),
            Filtro_Anio: $(Contenedor + 'txtAñoDetalleEdicion').val(),
            Filtro_Motor: $(Contenedor + 'txtMotorDetalleEdicion').val(),
            Filtro_Transmision: $(Contenedor + 'txtTransmisionEdicion').val(),
            Filtro_CajaCambio: $(Contenedor + 'txtCajaCambioEdicion').val(),
            Filtro_Filtro: $(Contenedor + 'txtFiltroEdicion').val()     
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ActualizarDetalle_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE ACTUALIZO CORRECTAMENTE') {
                    alertify.log('Se Actualizo Correctamente.');
                    $('#hfCodModeloDetalleEdicion').val(0);
                    $(Contenedor + 'txtAñoDetalleEdicion').val('');
                    $(Contenedor + 'txtMotorDetalleEdicion').val('');
                    $(Contenedor + 'txtModeloDetalleEdicion').val('');
                    $(Contenedor + 'txtFiltroEdicion').val('');
                    $(Contenedor + 'txtCajaCambioEdicion').val('');
                    $(Contenedor + 'txtTransmisionEdicion').val('');
                    $('#div_DetalleProductoEditar').dialog('close');
                    F_Buscar_Detalle($('#hfCodProducto').val());               
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

function F_ValidarGrabarDetalleEdicion() {
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtModeloDetalleEdicion').val() == '' | $('#hfCodModeloDetalleEdicion').val() == 0)
            Cadena = Cadena + '<p></p>' + 'Modelo';

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
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }

    return false;
}

function F_LlenarGridDetalle(Fila) {
    try {
        var nmrow = 'MainContent_grvConsulta_pnlOrders_0';
        var Col = Fila.split('_')[3];
        var Codigo = $('#' + Fila.replace('pnlOrders', 'hfCodProducto')).val();      
        var grvNombre = 'MainContent_grvConsulta_grvDetalle_' + Col;
        Hfgv = '#' + Fila.replace('pnlOrders', 'hfDetalleCargado');

        if ($(Hfgv).val() === "1") {
            $(Ctlgv).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Ctlgv).next().html() + '</td></tr>');
            $(Ctlgv).attr('src', '../Asset/images/minus.gif');
        }
        else {
            {
                var objParams =
                        {
                            Filtro_Col: Col,
                            Filtro_Codigo: Codigo,          
                            Filtro_grvNombre: grvNombre
                        };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                //MostrarEspera(true);
                $(Ctlgv).attr('src', '../Asset/images/loading.gif');
                F_LlenarGridDetalle_NET(arg, function (result) {

                    $(Ctlgv).attr('src', '../Asset/images/minus.gif');
                    //MostrarEspera(false);

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