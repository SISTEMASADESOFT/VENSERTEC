var AppSession = "../Ventas/RegistroBoleta.aspx";

$(document).ready(function () {

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#MainContent_txtApePaterno').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 1 + "','CodTipoCliente':'" + 1 + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2],
                            DireccionEnvio: item.split(',')[3],
                            Distrito: item.split(',')[4],
                            CodDepartamento: item.split(',')[5],
                            CodProvincia: item.split(',')[6],
                            CodDistrito: item.split(',')[7],
                            NroRuc: item.split(',')[8],
                            ApePaterno: item.split(',')[9],
                            ApeMaterno: item.split(',')[10],
                            Nombres: item.split(',')[11]
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
            $('#MainContent_txtApePaterno').focus();
            $('#hfCodCtaCte').val(i.item.val);
            $('#MainContent_txtNroDni').val(i.item.NroRuc);
            $('#MainContent_txtDireccion').val(i.item.Direccion);
            $('#MainContent_txtDestino').val(i.item.DireccionEnvio);
            $('#MainContent_txtDistrito').val(i.item.Distrito);
            $('#hfApePaterno').val(i.item.ApePaterno);
            $('#MainContent_txtApeMaterno').val(i.item.ApeMaterno);
            $('#MainContent_txtNombre').val(i.item.Nombres);
            $('#hfCodDepartamento').val(i.item.CodDepartamento);
            $('#hfCodProvincia').val(i.item.CodProvincia);
            $('#hfCodDistrito').val(i.item.CodDistrito);
        },
        minLength: 3
    });

    $('#MainContent_txtClienteConsulta').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 1 + "','CodTipoCliente':'" + 1 + "'}",
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

    $('#MainContent_txtDistrito').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCDistrito_Listar',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[3],
                            val: item.split(',')[0],
                            CodProvincia: item.split(',')[1],
                            CodDistrito: item.split(',')[2]
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
            $('#hfCodDepartamento').val(i.item.val);
            $('#hfCodProvincia').val(i.item.CodProvincia);
            $('#hfCodDistrito').val(i.item.CodDistrito);
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

    $('#divTabs').tabs();   
    
    $('#MainContent_txtDesde').datepicker({onSelect: function() {
      var date = $(this).datepicker('getDate');
      if (date) {
            date.setDate(1);
            $(this).datepicker('setDate', date);
      }
      }}); 

    $('#MainContent_txtDesde').datepicker({beforeShowDay: function(date) {
      return [date.getDate() == 1, ''];
    }});

    F_Controles_Inicializar();

    $('#MainContent_btnBuscarArticulo').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try 
        {
        var cadena = "Ingresar los sgtes. campos :";
        if ($('#MainContent_txtArticulo').val()=="")
        return false
            if ($('#MainContent_txtArticulo').val=="" | $('#MainContent_txtArticulo').val().length<3)
            cadena=cadena + "\n" + "Articulo (Minimo 2 Caracteres)"

              if ($('#MainContent_ddlMoneda option').size() == 0)
              { cadena = cadena + "\n" + "Moneda"; }
              else 
              {
              if ($('#MainContent_ddlMoneda').val() == "-1")
                    cadena = cadena + "\n" + "Moneda";
              }

              if ( cadena != "Ingresar los sgtes. campos :")
              {
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

    $('#MainContent_btnAgregarProducto').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try 
        {
               
                $('#MainContent_txtArticulo').val('');
                $('#MainContent_chkServicios').prop('checked',false);
                $('#MainContent_chkNotaPedido').prop('checked',false);
                $("#divConsultaArticulo").dialog({
                    resizable: false,
                    modal: true,
                    title: "Consulta de Productos",
                    title_html: true,
                    height: 500,
                    width: 1000,
                    autoOpen: false
                });

                $('#divConsultaArticulo').dialog('open');
                $('#MainContent_txtArticulo').focus();


                 var objParams = { };
                 var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);


                F_CargarGrillaVaciaConsultaArticulo_NET(arg, function (result) {
//                var Entity = Sys.Serialization.JavaScriptSerializer.deserialize(result);

//                MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {                  
                    F_Update_Division_HTML('div_grvConsultaArticulo', result.split('~')[2]);                            
                    $('.ccsestilo').css('background', '#FFFFE0');      
                }
                else 
                {
                    alertify.log(result.split('~')[1]);
                }

                return false;

                });


        }
        catch (e) {

            alertify.log("Error Detectado: " + e);
        }


        return false;

    });  

    $('#MainContent_btnAgregar').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
     try 
        {
        if (F_ValidarAgregar()==false)
        return false;

        F_AgregarTemporal();
        F_LimpiarGrillaConsulta();
        $('#MainContent_txtArticulo').focus();
        return false;
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnAgregarItemOC').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try {

            if (F_ValidarAgregarOC() == false)
                return false;

            F_AgregarTemporalOC();
            F_LimpiarGrillaConsultaOC();

            return false;
        }

        catch (e) {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEliminar').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
     try 
        {
            if(F_ValidarEliminar()==false)
              return false;

            if (confirm("Esta seguro de eliminar los productos seleccionado"))
            F_EliminarTemporal();

            return false;
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
     
        });

    $('#MainContent_btnGrabar').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
     try 
        {
            if(F_ValidarGrabarDocumento()==false)
              return false;

            if (confirm("Esta Seguro de Grabar El Documento"))
            F_GrabarDocumento();
//                F_Nuevo();
//            }
            return false;
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
     
        });

    $('#MainContent_btnNuevo').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
     try 
        {
          F_Nuevo();
          return false;
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
     
        });

    $('#MainContent_btnBuscarConsulta').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
     try 
        {
          F_Buscar();
          return false;
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnOC').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_FacturacionOC();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnDevolverItemOC').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (F_ValidarDevolucion("Seleccione un articulo para devolver") == false)
                return false;

            if (confirm("Esta seguro de la devolucion de los productos seleccionado"))
                F_Devolucion();

            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnCotizacion').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
       
          $('#div_FacturarCotizacion').dialog({
              resizable: false,
              modal: true,
              title: "Facturar Cotizacion",
              title_html: true,
              height: 80,
              width: 280,
              autoOpen: false
          });
             var Contenedor = '#MainContent_';
          $(Contenedor + 'txtCodCotizacion').val('');
          $('#div_FacturarCotizacion').dialog('open');

          return false;

    });

    $('#MainContent_btnFacturarCotizacion').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_FacturacionCotizacion();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnDevolverGuia').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (F_ValidarDevolucionGuia("Seleccione un articulo para devolver") == false)
                return false;

            if (confirm("Esta seguro de la devolucion de los productos seleccionado"))
                F_DevolucionGuia();

            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnGuia').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_FacturacionGuia();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnAgregarGuia').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try {

            if (F_ValidarDevolucionGuia() == false)
                return false;

            F_AgregarTemporalGuia();
            F_LimpiarGrillaConsultaOC();

            return false;
        }

        catch (e) {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnFacturarNotaVenta').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
         try {
               $('#div_FacturacionNotaVenta').dialog({
              resizable: false,
              modal: true,
              title: "Facturar Nota Venta",
              title_html: true,
              height: 80,
              width: 280,
              autoOpen: false
          });
             var Contenedor = '#MainContent_';
          $(Contenedor + 'txtCodNotaVenta').val('');
          $('#div_FacturacionNotaVenta').dialog('open');

          return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnFacturarNV').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_FacturaNotaVenta();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });
        
    $('#MainContent_txtEmision').on('change', function (e) {
        F_FormaPago($("#MainContent_ddlFormaPago").val());
        F_TipoCambio();
    });

    $("#MainContent_txtNumero").ForceNumericOnly();

    $("#MainContent_txtNumeroConsulta").ForceNumericOnly();

    $("#MainContent_txtNroDni").ForceNumericOnly();

    $('#MainContent_txtApePaterno').blur(function () {
        try 
        {
            if ($('#MainContent_txtApePaterno').val()=='')
            return false

            if ($('#MainContent_txtApePaterno').val().substring(0, 8) == $('#MainContent_txtNroDni').val())
                $('#MainContent_txtApePaterno').val($('#hfApePaterno').val());
            return false;
              
        }
        catch (e) {

            alertify.log("Error Detectado: " + e);
        }


        return false;
    });

    $('#MainContent_txtArticulo').blur(function () {
          try 
        {
        if ($('#MainContent_txtArticulo').val()=='')
        return false

        var cadena = "Ingresar los sgtes. campos :";
            if ($('#MainContent_txtArticulo').val=="" | $('#MainContent_txtArticulo').val().length<3)
            cadena=cadena + "\n" + "Articulo (Minimo 3 Caracteres)"

              if ($('#MainContent_ddlMoneda option').size() == 0)
              { cadena = cadena + "\n" + "Moneda"; }
              else 
              {
              if ($('#MainContent_ddlMoneda').val() == "-1")
                    cadena = cadena + "\n" + "Moneda";
              }

              if ( cadena != "Ingresar los sgtes. campos :")
              {
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

    $('#MainContent_txtNumero').blur(function () {
        var id = '0000000' + $('#MainContent_txtNumero').val();
        $('#MainContent_txtNumero').val(id.substr(id.length - 7));
        return false;
    });

    $('#MainContent_txtNumeroConsulta').blur(function () {
        if ($('#MainContent_txtNumeroConsulta').val()=='')
        return false;

        var id = '0000000' + $('#MainContent_txtNumeroConsulta').val();
        $('#MainContent_txtNumeroConsulta').val(id.substr(id.length - 7));
        return false;
    });

    $('#MainContent_txtNumeroGuia').blur(function () {
        var id = '0000000' + $('#MainContent_txtNumeroGuia').val();
        $('#MainContent_txtNumeroGuia').val(id.substr(id.length - 7));
        return false;
    });

    $("#MainContent_chkServicios").change(function () {
        if (this.checked) {
            $('#MainContent_chkNotaPedido').prop('disabled', false);
            if ($('#hfNotaPedido') == '1')
                $('#MainContent_chkNotaPedido').prop('checked', true);
            else
                $('#MainContent_chkNotaPedido').prop('checked', false);
            $('#MainContent_txtArticulo').focus();
        }
        else {
            $('#MainContent_chkNotaPedido').prop('disabled', true);
            $('#MainContent_chkNotaPedido').prop('check', false);
        }

    });

    $("#MainContent_chkNotaPedido").change(function () {
        if (this.checked) {
            $('#hfNotaPedido').val('1');
            $('#MainContent_txtArticulo').val('');
            $('#MainContent_txtArticulo').focus();
        }

        else {
            $('#hfNotaPedido').val('0');

            var hfcodtipoproducto_grilla = '';
            var chkDel = '';
            var i = 0;

            $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
                chkDel = '#' + this.id;
                hfcodtipoproducto_grilla = chkDel.replace('chkEliminar', 'hfcodtipoproducto');
                if ($(hfcodtipoproducto_grilla).val() == '2') {
                    $(chkDel).prop('checked', true);
                    i = 1;
                }

            });

            if (i == 1) {
                if (confirm("Esta seguro de quitar el pedido")) {
                    F_EliminarTemporal();
                }
                else {

                    $('#MainContent_chkNotaPedido').prop('checked', true);
                    $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
                        chkDel = '#' + this.id;
                        hfcodtipoproducto_grilla = chkDel.replace('chkEliminar', 'hfcodtipoproducto');
                        if ($(hfcodtipoproducto_grilla).val() == '2') {
                            $(chkDel).prop('checked', false);
                        }

                    });
                    $('#hfNotaPedido').val('1');
                    $('#MainContent_txtArticulo').focus();

                }

            }
            return false;
        }



    });

    $("#MainContent_txtNroRuc").ForceNumericOnly();

    $("#MainContent_txtCodCotizacion").ForceNumericOnly();

    $('#MainContent_txtCodCotizacion').css('background', '#FFFFE0');

    $('#MainContent_txtApePaterno').css('background', '#FFFFE0');

    $('#MainContent_txtApeMaterno').css('background', '#FFFFE0');

    $('#MainContent_txtNombre').css('background', '#FFFFE0');

    $('#MainContent_txtDistrito').css('background', '#FFFFE0');

    $('#MainContent_txtNroDni').css('background', '#FFFFE0');

    $('#MainContent_txtDireccion').css('background', '#FFFFE0');
    
    $('#MainContent_txtVencimiento').css('background', '#FFFFE0');

    $('#MainContent_txtEmision').css('background', '#FFFFE0');

    $('#MainContent_txtPlaca').css('background', '#FFFFE0');

    $('#MainContent_txtClienteConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroGuia').css('background', '#FFFFE0');

    $('#MainContent_txtFechaTraslado').css('background', '#FFFFE0');

    $('#MainContent_txtDestino').css('background', '#FFFFE0');

    $('#MainContent_txtSubTotal').css('background', '#FFFFE0');

    $('#MainContent_txtIgv').css('background', '#FFFFE0');

    $('#MainContent_txtTotal').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtNumero').css('background', '#FFFFE0');

    $('#MainContent_txtDesde').css('background', '#FFFFE0');

    $('#MainContent_txtHasta').css('background', '#FFFFE0');

    $('#MainContent_txtArticulo').css('background', '#FFFFE0');

    $('#MainContent_txtUltimoPrecio').css('background', '#FFFFE0');

    $('#MainContent_txtMonedaPrecio').css('background', '#FFFFE0');

    $('#MainContent_ddlTipoDoc').css('background', '#FFFFE0');
        
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

function VerifySessionState(result) {}

$(document).on("change", "select[id $= 'MainContent_ddlSerieGuia']",function () {
     F_Mostrar_Correlativo($("#MainContent_ddlSerieGuia").val(), 10);
} );

$(document).on("change", "select[id $= 'MainContent_ddlSerie']",function () {
     F_CambioSerie();
 });

$(document).on("change", "select[id $= 'MainContent_ddlSerieConsulta']", function () {
     F_Buscar();
 });

$(document).on("change", "select[id $= 'MainContent_ddlFormaPago']",function () {
     $('#MainContent_ddlFormaPago').css('background', '#FFFFE0');
     F_FormaPago($("#MainContent_ddlFormaPago").val());
} );

function F_CambioSerie() {
    if ($("#MainContent_ddlSerie option:selected").text().substr(0, 1) == 'B')
    { $('#divNumero').prop("style").display = "none" }
    else
    { $('#divNumero').prop("style").display = "block" }

    F_Mostrar_Correlativo(2);
}

function F_Controles_Inicializar() {

    var arg;

    try {
        var objParams =
            {
                Filtro_Fecha: $('#MainContent_txtEmision').val(),
                Filtro_CodDoc: 2
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
                    if (str_resultado_operacion == "1") 
                    {
                        F_Update_Division_HTML('div_serie', result.split('~')[2]);
                        F_Update_Division_HTML('div_serieguia', result.split('~')[3]);
                        F_Update_Division_HTML('div_formapago', result.split('~')[4]);
                        F_Update_Division_HTML('div_moneda', result.split('~')[5]);
                        $('#MainContent_lblTC').text(result.split('~')[6]);
                        F_Update_Division_HTML('div_serieconsulta', result.split('~')[9]);
                        F_Update_Division_HTML('div_igv', result.split('~')[8]);
                        $('#MainContent_ddlSerieConsulta').val(59);
                        $('#MainContent_ddlSerie').val(59);
                        $('#MainContent_ddlMoneda').val(1);
                        $('#MainContent_ddlFormaPago').val(1);
                        $('#MainContent_txtNumero').val(result.split('~')[7]);
                        $('#MainContent_txtVencimiento').val($('#MainContent_txtEmision').val());
                        $('#hfCodUsuario').val(result.split('~')[10]);
                        $('#hfPartida').val(result.split('~')[11]);
                        $('#hfCodSede').val(result.split('~')[12]);
                        $('#hfCodCtaCte').val(29);
                        $('#MainContent_txtCliente').val('CLIENTE VARIOS');
                        $('#MainContent_txtDireccion').val('AREQUIPA');
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                        $('#MainContent_ddlFormaPago').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerie').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerieConsulta').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerieGuia').css('background', '#FFFFE0');
                        $('#MainContent_ddlIgv').css('background', '#FFFFE0');
                        $('#MainContent_ddlTipoDoc').css('background', '#FFFFE0');
                        F_Mostrar_Correlativo(2);
                        $('.ccsestilo').css('background', '#FFFFE0');
                        F_CambioSerie();
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

function F_Mostrar_Correlativo(CodDoc) {
    var arg;

    try {
        var SerieDoc = '';
        var objParams = {
            Filtro_CodDoc: CodDoc,
            Filtro_SerieDoc: $("#MainContent_ddlSerie option:selected").text()
        };

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Mostrar_Correlativo_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);

                    if (str_resultado_operacion == "1") 
                        $('#MainContent_txtNumero').val(result.split('~')[2]);
                    else 
                        alertify.log(str_mensaje_operacion);
                   
                    return false ;
                
                }
            );

    } catch (mierror) {
    MostrarEspera(false);
        alertify.log("Error detectado: " + mierror);

    }

}

function F_Buscar_Productos() {

  var arg;
    var CodTipoProducto = 2;
    var chkNotaPedido = 0;
    var chkServicio = 0;
    try {
         if ($('#MainContent_chkServicios').is(':checked'))
         {
             CodTipoProducto=1;
             chkServicio=1;
         }
            
         if ($('#MainContent_chkNotaPedido').is(':checked') && $('#MainContent_chkServicios').is(':checked'))
           {
             chkNotaPedido=1;
             CodTipoProducto=2;
           }   

        var objParams =
            {
                Filtro_DscProducto: $('#MainContent_txtArticulo').val(),
                Filtro_CodTipoProducto: CodTipoProducto,
                Filtro_CodMoneda: $('#MainContent_ddlMoneda').val(),
                Filtro_Servicio: chkServicio,
                Filtro_NotaPedido: chkNotaPedido
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
                        if (str_mensaje_operacion!='')
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
 
function F_ValidarPrecioLista(ControlID) {

    var ddlLista_Grilla = '';
    var lblprecio = '';
    var txtcant_grilla = '';
    var txtprecio_grilla = '';
    var boolEstado = false;

            ddlLista_Grilla = '#' + ControlID;
            txtprecio_grilla = ddlLista_Grilla.replace('ddlLista', 'txtPrecioLibre');
            txtcant_grilla = ddlLista_Grilla.replace('ddlLista', 'txtCantidad');

             switch ($(ddlLista_Grilla).val()) 
             {
              case "1":
                        lblprecio = ddlLista_Grilla.replace('ddlLista', 'lblPrecio1');
                        $(txtprecio_grilla).val($(lblprecio).val());
                       $(txtprecio_grilla).prop('disabled', true);
                        $(txtcant_grilla).focus();
                        break;

              case "2":
                        lblprecio = ddlLista_Grilla.replace('ddlLista', 'lblPrecio2');
                        $(txtprecio_grilla).val($(lblprecio).val());
                         $(txtprecio_grilla).prop('disabled', true);
                        $(txtcant_grilla).focus();
                        break;
              case "3":
                        lblprecio = ddlLista_Grilla.replace('ddlLista', 'lblPrecio3');
                        $(txtprecio_grilla).val($(lblprecio).val());
                       $(txtprecio_grilla).prop('disabled', true);
                        $(txtcant_grilla).focus();
                        break;

              case "4":
                    $(txtprecio_grilla).val('');
                    $(txtprecio_grilla).prop('disabled', false);
                    $(txtprecio_grilla).focus();
                        break;
    }

    return true;
}

function F_ValidarStockGrilla(ControlID) {
    
      var txtCantidad = '#' + ControlID;
      var chkOK = txtCantidad.replace('txtCantidad', 'chkOK');
      var txtPrecio = txtCantidad.replace('txtCantidad', 'txtPrecio');
      var txtDescuento = txtCantidad.replace('txtCantidad', 'txtDescuento');
   if ($(txtCantidad).val() == '')
    return false;
    if(F_ValidarAgregar()==false)
    {
    $(txtCantidad).val('');
    $(txtPrecio).val('');
    $(txtDescuento).val('');
    $(chkOK).prop('checked',false);
    return false;
    }
  
 
      
    var Stock = 0;

    var lblChala1 = txtCantidad.replace('txtCantidad', 'lblChala1');
    var lblChala2 = txtCantidad.replace('txtCantidad', 'lblChala2');

    if ($('#hfCodSede').val()==2)
        Stock = $(lblChala1).text();
    else
        Stock = $(lblChala2).text();

    if ($('#MainContent_chkNotaPedido').is(':checked')) {
        if ($(chkOK).is(':checked') && parseFloat($(txtCantidad).val()) > parseFloat(Stock)) {
            alertify.log("Stock insuficiente");
            $(txtCantidad).val('');
            return false;
        }
    }
    else {
        if ($('#MainContent_chkServicios').is(':checked') == false && $(chkOK).is(':checked')  && parseFloat($(txtCantidad).val()) > parseFloat(Stock)) {
            alertify.log("Stock insuficiente");
            $(txtCantidad).val('');
            return false;
        }
        else
        {

        F_AgregarTemporal();
        F_LimpiarGrillaConsulta();
        $('#MainContent_txtArticulo').focus();
        return false;
        }

    }


    return true;
}

function F_ValidarDescuento(ControlID) {

        var txtDescuento = '#' + ControlID;
        var chkOK = txtDescuento.replace('txtDescuento', 'chkOK');
        var txtPrecio = txtDescuento.replace('txtDescuento', 'txtPrecio');

        if (!$(chkOK).is(':checked'))
            return false;

        if ($(txtDescuento).val() == "") {
            $(txtDescuento).val("");
            return false;
        }

        var hfDescuento = txtDescuento.replace('txtDescuento', 'hfDescuento');
        if (parseFloat($(txtDescuento).val()) > parseFloat($(hfDescuento).val())) {
            alertify.log("Descuento no permitido");
            $(txtDescuento).val("");
            return false;
        }
        var lblPrecioSoles = txtDescuento.replace('txtDescuento', 'lblPrecioSoles');
        var lblPrecioDolares = txtDescuento.replace('txtDescuento', 'lblPrecioDolares');
        var hfCodFamilia = txtDescuento.replace('txtDescuento', 'hfCodFamilia');
        var hfCostoProductoSoles = txtDescuento.replace('txtDescuento', 'hfCostoProductoSoles');
        var hfCostoProductoDolares = txtDescuento.replace('txtDescuento', 'hfCostoProductoDolares');
        var hfMargen = txtDescuento.replace('txtDescuento', 'hfMargen');

        var Descuento = 0;
        var Costo = 0;

        if ($('#MainContent_ddlMoneda').val() == 1) 
            Costo = $(hfCostoProductoSoles).val();
        else 
            Costo = $(hfCostoProductoDolares).val();

        Descuento =($(hfMargen).val() - (parseFloat($(txtDescuento).val()) / 100))+1;
        Costo = (((Costo * Descuento) * 2).toFixed(0)) / 2;
        $(txtPrecio).val(Costo.toFixed(2));
      
        return true;
    }

function F_ValidarCheck(ControlID) {

    var cadena='Ingrese los sgtes. campos: '
            
          var  chkOK = '#' + ControlID;
          var  txtPrecio = chkOK.replace('chkOK', 'txtPrecio');
          var  txtCantidad = chkOK.replace('chkOK', 'txtCantidad');
          var  txtDescuento = chkOK.replace('chkOK', 'txtDescuento');
          var lblPrecioSoles = txtDescuento.replace('txtDescuento', 'lblPrecioSoles');
          var lblPrecioDolares = txtDescuento.replace('txtDescuento', 'lblPrecioDolares');

            if ($(chkOK).is(':checked'))
            {
                $(txtCantidad).prop('disabled', false);
                $(txtDescuento).prop('disabled', false);
                $(txtPrecio).prop('disabled', false);
                var i=0;
                if($(txtPrecio).val()=="")
                {$(txtPrecio).focus();
                i=1}

                if(i==0 && $(txtCantidad).val()=="")
                {$(txtPrecio).focus();}

                if ($('#MainContent_ddlMoneda').val()==1)
                $(txtPrecio).val($(lblPrecioSoles).text());
                else
                $(txtPrecio).val($(lblPrecioDolares).text()); 
                  
                $(txtDescuento).focus();
            }
            else
            {
                $(txtCantidad).val('');
                $(txtDescuento).val('');
                $(txtPrecio).val('');
                $(txtCantidad).prop('disabled', true);
                $(txtDescuento).prop('disabled', true);
                $(txtPrecio).prop('disabled', true);
            }
            
        
    return true;
}

function F_FormaPago(CodFormaPago){ 

 var arg;
    try 
    {
     switch (CodFormaPago)
     {
            case "1":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),0));
                       break;
            case "3":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),30));
                       break;
            case "4":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),15));
                       break;
            case "8":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),45));
                       break;
            case "9":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),60));
                       break;
            case "11":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),7));
                       break;
            case "12":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),0));
                       break;
            case "13":
                       $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),75));
                       break;
            case "14":
               $('#MainContent_txtVencimiento').val(Date_AddDays($('#MainContent_txtEmision').val(),90));
               break;
     }

     
    }
     catch (mierror) 
     {
        alertify.log("Error detectado: " + mierror);
     }

}

function F_ValidarAgregar(){

 try 
        {
        var chkSi='';
        var chkDel='';
        var txtcantidad_grilla='';
        var txtprecio_grilla='';
        var cadena = "Ingrese los sgtes. campos: ";
        var lblcodproducto_grilla='';
        var hfcodarticulodetalle_grilla='';
        var lbldscproducto_grilla='';
        var x=0;

                $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    txtprecio_grilla = chkSi.replace('chkOK', 'txtPrecioLibre');
                    txtcantidad_grilla = chkSi.replace('chkOK', 'txtCantidad');
                    lblcodproducto_grilla = chkSi.replace('chkOK', 'lblcodproducto');
                    
                     if ($(chkSi).is(':checked')) 
                        {
                            if ($(txtcantidad_grilla).val()=='')
                                cadena=cadena + "\n" + "Cantidad para el Codigo " + $(lblcodproducto_grilla).text(); 
                        
                            x=1;
                        }
               });

               if(x==0)
               cadena="No ha seleccionado ningun producto";

                if (cadena != "Ingrese los sgtes. campos: ")
                   {
                      alertify.log(cadena);
                      return false;
                   } 
                   else
                   {
                    cadena="Los sgtes. productos se encuentran agregados : ";
                    $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblcodproducto_grilla = chkSi.replace('chkOK', 'lblcodproducto');
               
                         if ($(chkSi).is(':checked')) 
                            {
                                 $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
                                   chkDel = '#' + this.id;
                                   hfcodarticulodetalle_grilla = chkDel.replace('chkEliminar', 'hfcodarticulo');
                                   lbldscproducto_grilla = chkDel.replace('chkEliminar', 'lblproducto');
                                    
                                    if ($(lblcodproducto_grilla).text()==$(hfcodarticulodetalle_grilla).val())
                                    {
                                    cadena= cadena + "\n"  + $(lbldscproducto_grilla).text();
                                    }
                         
                                  });
                            }
                    });
                   }    
                                 
                   if (cadena != "Los sgtes. productos se encuentran agregados : ") 
                   {alertify.log(cadena);
                   return false;}
                   else
                   {
                   return true;
                   }
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
}

function F_AgregarTemporal(){

  try 
        {
       

        var lblcodproducto_grilla='';
        var lblcodunidadventa_grilla='';
        var lblcosto_grilla='';
        var chkSi='';
        var txtcantidad_grilla='';
        var txtprecio_grilla='';
        var arrDetalle = new Array();
        var hfcodunidadventa_grilla='';
        var hfcosto_grilla='';
        var chkNotaPedido = 0;
        var chkServicio = 0;

        if ($('#MainContent_chkServicios').is(':checked'))
            chkServicio = 1;

        if ($('#MainContent_chkNotaPedido').is(':checked'))
            chkNotaPedido = 1;
               
                $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblcodproducto_grilla = chkSi.replace('chkOK', 'lblcodproducto');
                    lblcodunidadventa_grilla = chkSi.replace('chkOK', 'lblcodunidadventa');
                    lblcosto_grilla = chkSi.replace('chkOK', 'lblcosto');
                    txtprecio_grilla = chkSi.replace('chkOK', 'txtPrecio');
                    txtcantidad_grilla = chkSi.replace('chkOK', 'txtCantidad');
                    hfcodunidadventa_grilla = chkSi.replace('chkOK', 'hfcodunidadventa');
                    hfcosto_grilla = chkSi.replace('chkOK', 'hfcosto');

                  if ($(chkSi).is(':checked')) 
                    {
                        var objDetalle = {
                        CodArticulo: $(lblcodproducto_grilla).text(),
                        Cantidad: $(txtcantidad_grilla).val(),
                        Precio: $(txtprecio_grilla).val(),
                        Costo: $(hfcosto_grilla).val(),
                        CodUm: $(hfcodunidadventa_grilla).val(),
                        CodDetalle:0
                        };
                                               
                        arrDetalle.push(objDetalle);
                    }
                });

            
                var Contenedor = '#MainContent_';
                var tasaigv=parseFloat( $("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
                var objParams = {
                                        Filtro_CodTipoDoc: "1",
                                        Filtro_SerieDoc: $(Contenedor + 'ddlSerie').val(),
                                        Filtro_NumeroDoc: $(Contenedor + 'txtNumero').val(),
                                        Filtro_FechaEmision: $(Contenedor + 'txtEmision').val(),
                                        Filtro_Vencimiento: $(Contenedor + 'txtVencimiento').val(),
                                        Filtro_CodCliente: $(Contenedor + 'hfCodCtaCte').val(),
                                        Filtro_CodFormaPago: $(Contenedor + 'ddlFormaPago').val(),
                                        Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
                                        Filtro_TipoCambio: $(Contenedor + 'lblTC').text(),
                                        Filtro_SubTotal: $(Contenedor + 'txtSubTotal').val(),
                                        Filtro_CodProforma: "0",
                                        Filtro_Igv: $(Contenedor + 'txtIgv').val(),
                                        Filtro_Total: $(Contenedor + 'txtTotal').val(),
                                        Filtro_CodTraslado: "0",
                                        Filtro_Descuento: "0",
                                        Filtro_TasaIgv: tasaigv,
                                        Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
                                        Filtro_Servicio: chkServicio,
                                        Filtro_NotaPedido: chkNotaPedido,
                                        Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle)
                               };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
                MostrarEspera(true);

                F_AgregarTemporal_NET(arg, function (result) {
        
                 MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                    $('#hfCodigoTemporal').val(result.split('~')[3]);
                    $('#MainContent_txtTotal').val(result.split('~')[5]);
                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                    $('.ccsestilo').css('background', '#FFFFE0');
                    if (result.split('~')[2]=='Los Producto(s) se han agregado con exito')
                    alertify.log('Los Producto(s) se han agregado con exito');
                }
                else 
                {
                    alertify.log(result.split('~')[2]);
                }

                return false;

                });
        }
        
        catch (e) 
        {
        MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
        }
}

function F_LimpiarGrillaConsulta(){

         var chkSi='';
         var txtprecio_grilla='';
         var txtcantidad_grilla='';
         var ddlLista_grilla='';

         $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
                     chkSi = '#' + this.id;
                     txtprecio_grilla = chkSi.replace('chkOK', 'txtPrecioLibre');
                     txtcantidad_grilla = chkSi.replace('chkOK', 'txtCantidad');
                     ddlLista_grilla = chkSi.replace('chkOK', 'ddlLista');
                     
                     $(txtcantidad_grilla).prop('disabled', true);
                     $(txtprecio_grilla).val('');
                     $(txtcantidad_grilla).val('');
                     $(ddlLista_grilla).val('4');

                     $(chkSi).prop('checked', false);
                       
         });
}

function F_MostrarTotales(){

var lblimporte_grilla='';
var chkDel='';
var Total=0;
var Igv=0;
var Subtotal=0;
     $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
             chkDel = '#' + this.id;
             lblimporte_grilla = chkDel.replace('chkEliminar', 'lblimporte');
             Total+=parseFloat($(lblimporte_grilla).text());
     });
     var Cuerpo='#MainContent_'
    $(Cuerpo + 'txtTotal').val(Total.toFixed(2));
    $(Cuerpo + 'txtIgv').val((Total*parseFloat($(Cuerpo + 'ddligv').val())).toFixed(2));
    $(Cuerpo + 'txtSubTotal').val((Total / (1 + parseFloat($("#MainContent_ddlIgv option:selected").text()))).toFixed(2));

}

function F_EliminarTemporal(){

  try 
        {
        var chkSi='';
        var arrDetalle = new Array();
        var lblcoddetalle_grilla='';
        
               
                $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblcoddetalle_grilla = chkSi.replace('chkEliminar', 'lblcoddetalle');
                   
                  if ($(chkSi).is(':checked')) 
                    {
                        var objDetalle = {
                       
                        CodDetalle: $(lblcoddetalle_grilla).text()
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

                if (str_resultado_operacion == "1") 
                {
                    $('#hfCodigoTemporal').val(result.split('~')[3]);
                    if (result.split('~')[5]=='0')
                    {
                     $('#MainContent_txtTotal').val('0.00');
                    $('#MainContent_txtIgv').val('0.00');
                    $('#MainContent_txtSubTotal').val('0.00');
                    }
                    else
                    {
                      $('#MainContent_txtTotal').val(result.split('~')[5]);
                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                    }
                   
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                    if (result.split('~')[2]=='Se han eliminado los productos correctamente.')
                    alertify.log('Se han eliminado los productos correctamente.');
                }
                else 
                {
                    alertify.log(result.split('~')[2]);
                }

                return false;

                });
        }
        
        catch (e) 
        {
        MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
        }
}

function F_ValidarEliminar(){

 try 
        {
        var chkSi='';
        var x=0;

                $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                               
                     if ($(chkSi).is(':checked')) 
                        x=1;
                        
               });

               if(x==0)
               {
               alertify.log("Seleccione un articulo para eliminar");
               return false;
               }
               else
               {return true;}
               
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }
}

function F_ValidarGrabarDocumento(){
    try 
        {        
        var Cuerpo='#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos: <br> <p></p>'; 

        if ($(Cuerpo + 'txtApePaterno').val() == '')
                Cadena=Cadena + '<p></p>' + 'Apellido Paterno';

        if ($(Cuerpo + 'txtApeMaterno').val() == '')
               Cadena=Cadena + '<p></p>' + 'Apellido Materno';

        if ($(Cuerpo + 'txtNroDni').val()!='99999999' && $(Cuerpo + 'txtNombre').val()=='')
                Cadena=Cadena + '<p></p>' + 'Nombres';
        
        if ($(Cuerpo + 'lblTC').text()=='0')
                Cadena=Cadena + '<p></p>' + 'Tipo de Cambio';

        if ($(Cuerpo + 'txtNumero').val()=='')
                Cadena=Cadena + '<p></p>' + 'Numero de Factura';

        if ($(Cuerpo + 'txtEmision').val()=='')
                Cadena=Cadena + '<p></p>' + 'Fecha de Emision';

         if ($(Cuerpo + 'chkGuia').is(':checked') && $(Cuerpo + 'txtNumeroGuia').val()=='')
                Cadena=Cadena + '<p></p>' + 'Numero de Guia';

         if ($(Cuerpo + 'chkGuia').is(':checked') && $(Cuerpo + 'txtFechaTraslado').val()=='')
                Cadena=Cadena + '<p></p>' + 'Fecha de Traslado';
        
         if ($(Cuerpo + 'chkGuia').is(':checked') && $(Cuerpo + 'txtDestino').val()=='')
                Cadena=Cadena + '<p></p>' + 'Destino';

//         if (ValidarRuc($(Cuerpo + 'txtNroRuc').val()) == false)
//                Cadena = Cadena + "\n" + "Ruc Invalido"; 
         
         if ($('#hfCodCtaCte').val()==0 && $('#hfCodDistrito').val()==0)
                Cadena=Cadena + '<p></p>' + 'Distrito';

         if ($('#hfCodCtaCte').val()==0 && $(Cuerpo + 'txtDireccion').val()=='')
                Cadena=Cadena + '<p></p>' + 'Direccion';
         
         if ($(Cuerpo + 'txtTotal').val()=='0.00')
                Cadena=Cadena + '<p></p>' + 'No ha ingresado ningun producto';


        if (Cadena != 'Ingresar los sgtes. Datos: <br> <p></p>')
        {alertify.log(Cadena);
        return false;}
        return true;
        }
        
    catch (e) 
        {

            alertify.log("Error Detectado: " + e);
            return false;
        }
}

function F_GrabarDocumento(){
  try 
        {       
        var FlagGuia='0';
        var FlagRetencion='0';
        var FlagLetra='0';
        var FlagIgv='1';
        var Contenedor = '#MainContent_';
        var NotaPedido='0';

        if ($(Contenedor + 'txtNroDni').val() !='99999999' & $('#hfCodCtaCte').val() == '29')
                $('#hfCodCtaCte').val(0);






        if ($(Contenedor + 'chkGuia').is(':checked'))
                FlagGuia='1';

        if ($(Contenedor + 'chkRetencion').is(':checked'))
                FlagRetencion='1';

        if ($(Contenedor + 'ddlFormaPago').val()==12)
                FlagLetra='1';

        if ($(Contenedor + 'chkNotaPedido').is(':checked'))
                NotaPedido='1';

        var tasaigv=parseFloat( $("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
                   var objParams = {
                                        Filtro_CodTipoDoc: 2,
                                        Filtro_SerieDoc: $("#MainContent_ddlSerie option:selected").text(),
                                        Filtro_NumeroDoc: $(Contenedor + 'txtNumero').val(),

                                        Filtro_FechaEmision: $(Contenedor + 'txtEmision').val(),
                                        Filtro_Vencimiento: $(Contenedor + 'txtVencimiento').val(),
                                        Filtro_CodCliente: $('#hfCodCtaCte').val(),
                                        Filtro_CodEstado: 6,
                                        Filtro_CodFormaPago: $(Contenedor + 'ddlFormaPago').val(),

                                        Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
                                        Filtro_TipoCambio: $(Contenedor + 'lblTC').text(),
                                        Filtro_SubTotal: $(Contenedor + 'txtSubTotal').val(),
                                        Filtro_Igv: $(Contenedor + 'txtIgv').val(),
                                        Filtro_Total: $(Contenedor + 'txtTotal').val(),

                                        Filtro_CodTraslado: $('#hfCodTraslado').val(),
                                        Filtro_CodProforma: $('#hfCodProforma').val(),
                                        Filtro_FlagGuia:FlagGuia,
                                        Filtro_SerieGuia: $("#MainContent_ddlSerieGuia option:selected").text(),

                                        Filtro_NumeroGuia: $(Contenedor + 'txtNumeroGuia').val(),
                                        Filtro_FechaTraslado: $(Contenedor + 'txtFechaTraslado').val(),
                                        Filtro_CodTipoCliente:  1,
                                        Filtro_CodClaseCliente: 2,
                                        Filtro_CodDepartamento: $('#hfCodDepartamento').val(),

                                        Filtro_CodProvincia: $('#hfCodProvincia').val(),
                                        Filtro_CodDistrito: $('#hfCodDistrito').val(),
                                        Filtro_ApePaterno: $(Contenedor + 'txtApePaterno').val(),
                                        Filtro_ApeMaterno: $(Contenedor + 'txtApeMaterno').val(),
                                        Filtro_Nombres: $(Contenedor + 'txtNombre').val(),

                                        Filtro_RazonSocial: '',
                                        Filtro_NroDni: $(Contenedor + 'txtNroDni').val(),
                                        Filtro_NroRuc: '',
                                        Filtro_Direccion: $(Contenedor + 'txtDireccion').val(),
                                        Filtro_Destino: $(Contenedor + 'txtDestino').val(),

                                        Filtro_FlagIgv: FlagIgv,
                                        Filtro_Placa:$(Contenedor + 'txtPlaca').val(),
                                        Filtro_Cliente: $(Contenedor + 'txtApePaterno').val() + ' ' + $(Contenedor + 'txtApeMaterno').val() + ' ' + $(Contenedor + 'txtNombre').val(),
                                        Filtro_CodTasa: $(Contenedor + 'ddlIgv').val() ,
                                        Filtro_TasaIgv: tasaigv,
                                        Filtro_NotaPedido:NotaPedido,
                                        Filtro_SerieOC: '',
                                        
                                        Filtro_NumeroOC: '',
                                        Filtro_CodDetalle: $('#hfCodigoTemporal').val(),
                                        Filtro_CodTipoOperacion: 1,
                                        Filtro_Partida:$('#hfPartida').val(),

                                        Filtro_CodNotaVenta: $('#hfCodNotaVenta').val(),
                                        Filtro_DireccionCompleta:  $(Contenedor + 'txtDireccion').val() + ' ' + $(Contenedor + 'txtDistrito').val() ,
                                        Filtro_Descuento:0,
                                        Filtro_FlagRetencion:FlagRetencion,
                                        Filtro_FlagLetra:FlagLetra

                                      };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
                MostrarEspera(true);

                F_GrabarDocumento_NET(arg, function (result) {
                
                  MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                    if (str_mensaje_operacion=='Se Grabo Correctamente')
                    {
                     alertify.log('Se Grabo Correctamente');
                     $('#MainContent_txtNumero').val(result.split('~')[3]);
                     if ($('#MainContent_chkImpresion').is(':checked')) 
                        //F_ImprimirFactura(result.split('~')[2]);
                        F_ImprimirFacturaHTML(result.split('~')[2], '');
                
                     F_Nuevo();
                    
                    }  
                }
                else 
                {
                    alertify.log(result.split('~')[1]);
                    return false;
                }

                return false;

                });
        }
        
        catch (e) 
        {
        MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }
}

function F_Nuevo(){
       $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);
       $('.Jq-ui-dtp').datepicker('setDate', new Date());
       $('#hfCodTraslado').val('0');
       $('#hfCodProforma').val('0');
       $('#hfCodNotaVenta').val('0');
       $('#hfCodDepartamento').val('3');
       $('#hfCodProvincia').val('14');
       $('#hfCodDistrito').val('93');
       $('#hfCodCtaCte').val('29');
       $('#MainContent_ddlMoneda').val(1);
       $('#MainContent_ddlFormaPago').val(1);
       $('#hfCodigoTemporal').val('0');
       $('#hfApePaterno').val('CLIENTE');
       $('#MainContent_txtApePaterno').val('CLIENTE');
       $('#MainContent_txtApeMaterno').val('VARIOS');
       $('#MainContent_txtNombre').val('');
       $('#MainContent_txtNroDni').val('99999999');
       $('#MainContent_txtPlaca').val('');
       $('#MainContent_txtDistrito').val('AREQUIPA CARAVELI CHALA');
       $('#MainContent_txtDireccion').val('AREQUIPA');
       $('#MainContent_txtSubTotal').val('0.00');
       $('#MainContent_txtIgv').val('0.00');
       $('#MainContent_txtTotal').val('0.00');
       $('#MainContent_txtDestino').val('');
       $('#MainContent_txtVencimiento').val($('#MainContent_txtEmision').val());
       $('#MainContent_txtArticulo').val('');
       $('#MainContent_chkGuia').prop('checked', false);
       $('#MainContent_chkServicios').prop('checked', false);
       $('#MainContent_chkNotaPedido').prop('checked', false);
       $('#MainContent_chkImpresion').prop('checked', true);
       $('#MainContent_chkRetencion').prop('checked', false);
       $('#MainContent_txtNroRuc').val('');
       $('#MainContent_txtCliente').val('CLIENTE VARIOS');
       $('#MainContent_txtDireccion').val('AREQUIPA');
       $('#MainContent_ddlSerie').val(59);
       $('#MainContent_txtCliente').focus();
      
       try 
        {
              var objParams = {
                                    Filtro_CodSerie: '1',
                                    Filtro_CodSerieGuia: '4'
                                        
                               };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
                MostrarEspera(true);

                F_Nuevo_NET(arg, function (result) {
               MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                  
                    $('#MainContent_txtNumero').val(result.split('~')[3]);
                    $('#MainContent_txtNumeroGuia').val(result.split('~')[4]);
                    
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[2]);       
                        $('.ccsestilo').css('background', '#FFFFE0');                           
                    F_Mostrar_Correlativo(2); 
                }
                else 
                {
                    alertify.log(result.split('~')[1]);
                }

                return false;

                });
        }
        
        catch (e) 
        {
        MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }

}

function F_Buscar(){

       try 
        {
              var chkNumero='0';
              var chkFecha='0';
              var chkCliente='0';

              if ($('#MainContent_chkNumero').is(':checked'))
              chkNumero='1';

              if ($('#MainContent_chkRango').is(':checked'))
              chkFecha='1';

              if ($('#MainContent_chkCliente').is(':checked'))
              chkCliente='1';
              
              var objParams = {
                                        Filtro_Serie: $("#MainContent_ddlSerieConsulta option:selected").text(),
                                        Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                                        Filtro_Desde: $('#MainContent_txtDesde').val(),
                                        Filtro_Hasta: $('#MainContent_txtHasta').val(),
                                        Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                                        Filtro_CodTipoDoc: '2',
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

                if (str_resultado_operacion == "1") 
                {
                  
                    F_Update_Division_HTML('div_consulta', result.split('~')[2]); 
                    if (str_mensaje_operacion!='')                           
                    alertify.log(str_mensaje_operacion);
                  
                }
                else 
                {
                    alertify.log(result.split('~')[1]);
                }

                return false;

                });
        }
        
        catch (e) 
        {
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
 try 
        {
       var imgID = Fila.id;
    var lblCodigo = '#' + imgID.replace('imgAnularDocumento', 'lblCodigo');
    var lblEstado = '#' + imgID.replace('imgAnularDocumento', 'lblEstado');
    var lblnumero_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblNumero');
    var lblcliente_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblcliente');

    if ($(lblEstado).text()=="ANULADO(A)") 
    {alert ("Este documento se encuentra anulado");
    return false;}

    if(confirm("Esta seguro de anular la FACTURA : " + $(lblnumero_grilla).text() + "\n" + "Del Cliente : " +  $(lblcliente_grilla).text())==false)
    return false;

     var chkNumero='0';
              var chkFecha='0';
              var chkCliente='0';

              if ($('#MainContent_chkNumero').is(':checked'))
              chkNumero='1';

              if ($('#MainContent_chkRango').is(':checked'))
              chkFecha='1';

              if ($('#MainContent_chkCliente').is(':checked'))
              chkCliente='1';

    var objParams = {
                          Filtro_Codigo: $(lblCodigo).text(),
                          Filtro_Serie: $("#MainContent_ddlSerie option:selected").text(),
                          Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                          Filtro_Desde: $('#MainContent_txtDesde').val(),
                          Filtro_Hasta: $('#MainContent_txtHasta').val(),
                          Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                          Filtro_CodTipoDoc: '1',
                          Filtro_ChkNumero: chkNumero,
                          Filtro_ChkFecha: chkFecha,
                          Filtro_ChkCliente: chkCliente
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
        
        catch (e) 
        {
        MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }

 
}

function getContentTab(){

    var date = new Date();
    date.setMonth(date.getMonth(), 1);
 
    $('#MainContent_txtDesde').val(date.format("dd/MM/yyyy"));
    $('#MainContent_chkRango').prop('checked',true);
    F_Buscar();
    return false;

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

function F_ImprimirGuia(Fila) {

    var imgID = Fila.id;
    var lblCodigo = '#' + imgID.replace('imgImprimir', 'hfCodTraslado');
    var lblEstado = '#' + imgID.replace('imgImprimir', 'lblestado');
   
    if ($(lblEstado).text()=='ANULADO')
    {
        alertify.log("La factura se encuentra anulada");
        return false;
    }

    if ($(lblCodigo).val()=='0')
    {
        alertify.log("La factura no tiene guia adjunta");
        return false;
    }

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = '200';


    rptURL = '../Reportes/Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Codigo=' + $(lblCodigo).val() + '&' ;
      
    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function F_ImprimirFactura(Codigo) {

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = '202';

    rptURL = '../Reportes/Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Codigo=' + Codigo + '&' ;
      
    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function ImprimirFacturaDetalle(Fila) {

    var imgID = Fila.id;
    var lblCodigo = '#' + imgID.replace('imgPdf', 'lblCodigo');
    var lblEstado = '#' + imgID.replace('imgPdf', 'lblEstado');
   
    if ($(lblEstado).text()=='Anulado(a)')
    {
        alertify.log("La factura se encuentra anulada");
        return false;
    }

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = '201';


    rptURL = '../Reportes/Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Codigo=' + $(lblCodigo).text() + '&' ;
      
    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function F_TipoCambio(){
    try 
        {
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
        
        catch (e) 
        {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }

    }

function F_VerUltimoPrecio(HlkControlID) {
        var Contenedor = '#cphCuerpo_';
        var CodNeumatico = '';
        var CodNeumaticoAlm = '';

//        CodNeumatico = $('#' + HlkControlID).text();
        CodProducto = $('#' + HlkControlID.replace('hlkCodigo', 'lblcodproducto')).text();

        try {
            var objParams = {
                Filtro_CodProducto: CodProducto,
                Filtro_CodTipoOperacion: '1',
                Filtro_CodCtaCte:$('#hfCodCtaCte').val()
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);

            F_VerUltimoPrecio_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1")
                {
                    $('#MainContent_txtUltimoPrecio').val('');
                    $('#MainContent_txtMonedaPrecio').val('');
                    $('#MainContent_txtFechaPrecio').val('');
                    $('#MainContent_txtCantidadPrecio').val('');

                    $('#MainContent_txtUltimoPrecio').val(result.split('~')[2]);
                    $('#MainContent_txtMonedaPrecio').val(result.split('~')[3]);
                    $('#MainContent_txtFechaPrecio').val(result.split('~')[4]);
                    $('#MainContent_txtCantidadPrecio').val(result.split('~')[5]);

                        $('#div_ultimoprecio').dialog({
                                resizable: false,
                                modal: true,
                                title: "Historial Venta",
                                title_html: true,
                                height: 120,
                                width: 350,
                                autoOpen: false
                        });

                        $('#div_ultimoprecio').dialog('open');


                }
                   
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

function F_FacturacionOC() {
        var Contenedor = '#MainContent_';
        var Mensaje = "Ingrese los sgtes datos: ";

        if ($(Contenedor + 'txtProveedor').val() == "" || $('#hfCodCtaCte').val() == 0)
            Mensaje = Mensaje + "\n" + "Proveedor";

        if ($(Contenedor + 'lblTC').text() == "0")
            Mensaje = Mensaje + "\n" + "Tipo de Cambio";

        if (Mensaje != "Ingrese los sgtes datos: ") {
            alertify.log(Mensaje);
            return false;
        }

        try {
            var objParams = {
                Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val()
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);

            F_FacturacionOC_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") {

                    $('#divFacturacionOC').dialog({
                        resizable: false,
                        modal: true,
                        title: "Facturacion Orden de Compra",
                        title_html: true,
                        height: 500,
                        width: 890,
                        autoOpen: false
                    });
                    F_Update_Division_HTML('div_DetalleOC', result.split('~')[2]);

                    if (str_mensaje_operacion != "")
                        alertify.log(str_mensaje_operacion);
                    else
                        $('#divFacturacionOC').dialog('open');

                    return false;

                }

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

function F_ValidarAgregarOC() {
        try {
            var cadena = "Ingrese los sgtes. campos: ";
            var chkSi = '';
            var lblCodigo = '';
            var txtCantidadEntregada = '';
            var x = 0;

            $('#MainContent_grvDetalleOC .chkDelete :checkbox').each(function () {
                chkSi = '#' + this.id;

                txtCantidadEntregada = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
                lblCodigo = chkSi.replace('chkEliminar', 'lblCodigo');

                if ($(chkSi).is(':checked')) {
                    if ($(txtCantidadEntregada).val() == '')
                        cadena = cadena + "\n" + "Cantidad para el Codigo " + $(lblCodigo).text();
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

function F_AgregarTemporalOC() {
        try {

            var lblcodproducto_grilla = '';
            var lblcodunidadventa_grilla = '';
            var lblNumero = '';
            var lblcosto_grilla = '';
            var chkSi = '';
            var txtcantidad_grilla = '';
            var txtprecio_grilla = '';
            var txtdscto_grilla = '';
            var arrDetalle = new Array();
            var hfcodunidadventa_grilla = '';
            var hfcosto_grilla = '';
            var Contenedor = '#MainContent_';

            $('#MainContent_grvDetalleOC .chkDelete :checkbox').each(function () {
                chkSi = '#' + this.id;
                lblcodproducto_grilla = chkSi.replace('chkEliminar', 'hfCodArticulo');
                lblcodunidadventa_grilla = chkSi.replace('chkEliminar', 'hfCodUndMedida');
                lblcosto_grilla = chkSi.replace('chkEliminar', 'lblPrecio');
                txtprecio_grilla = chkSi.replace('chkEliminar', 'lblPrecio');
                txtcantidad_grilla = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
                hfcodunidadventa_grilla = chkSi.replace('chkEliminar', 'hfCodUndMedida');
                hfcosto_grilla = chkSi.replace('chkEliminar', 'lblPrecio');
                lblCodDetalle = chkSi.replace('chkEliminar', 'lblCodDetalle');
                hfCostoUnitario = chkSi.replace('chkEliminar', 'hfCostoUnitario');
                lblNumero = chkSi.replace('chkEliminar', 'lblNumero');

                if ($(chkSi).is(':checked')) {
                    var objDetalle = {
                        CodArticulo: $(lblcodproducto_grilla).val(),
                        Cantidad: $(txtcantidad_grilla).val(),
                        Precio: $(txtprecio_grilla).text(),
                        Costo: $(hfcosto_grilla).text(),
                        CodUm: $(hfcodunidadventa_grilla).val(),
                        CostoUnitario: $(hfCostoUnitario).val(),
                        Dscto: 0,
                        CodDetalle: $(lblCodDetalle).text(),
                        OC: $(lblNumero).text()
                    };

                    arrDetalle.push(objDetalle);
                }
            });

            var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

                  
            var objParams = {
                Filtro_CodTipoDoc: "1",
                Filtro_SerieDoc: $(Contenedor + 'ddlSerie').val(),
                Filtro_NumeroDoc: $(Contenedor + 'txtNumero').val(),
                Filtro_FechaEmision: $(Contenedor + 'txtEmision').val(),
                Filtro_Vencimiento: $(Contenedor + 'txtVencimiento').val(),
                Filtro_CodCliente: $('#hfCodCtaCte').val(),
                Filtro_CodFormaPago: $(Contenedor + 'ddlFormaPago').val(),
                Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
                Filtro_TipoCambio: $(Contenedor + 'lblTC').text(),
                Filtro_SubTotal: $(Contenedor + 'txtSubTotal').val(),
                Filtro_CodProforma: "0",
                Filtro_Igv: $(Contenedor + 'txtIgv').val(),
                Filtro_Total: $(Contenedor + 'txtTotal').val(),
                Filtro_CodTraslado: "0",
                Filtro_Descuento: "0",
                Filtro_TasaIgv: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                Filtro_TasaIgvDscto: tasaigv,
                Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
                Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle)
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

            MostrarEspera(true);
            F_AgregarTemporal_NET(arg, function (result) {
                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];
                MostrarEspera(false);
                if (str_resultado_operacion == "1") {
                    $('#hfCodigoTemporal').val(result.split('~')[3]);
                    $('#MainContent_txtTotal').val(result.split('~')[5]);
                    $('#MainContent_txtMonto').val(result.split('~')[5]);
                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                    $('#MainContent_txtDsctoTotal').val(result.split('~')[8]);
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                    if (result.split('~')[2] == 'Los Producto(s) se han agregado con exito')
                        alertify.log('Los Producto(s) se han agregado con exito');
                }
                else {
                    MostrarEspera(false);
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

function F_LimpiarGrillaConsultaOC() {
        var chkSi = '';
        var txtprecio_grilla = '';
        var txtcantidad_grilla = '';
        var ddlLista_grilla = '';

        $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
            chkSi = '#' + this.id;
            txtprecio_grilla = chkSi.replace('chkOK', 'txtPrecioLibre');
            txtcantidad_grilla = chkSi.replace('chkOK', 'txtCantidad');
            ddlLista_grilla = chkSi.replace('chkOK', 'ddlLista');

            $(txtcantidad_grilla).prop('disabled', true);
            $(txtprecio_grilla).val('');
            $(txtcantidad_grilla).val('');
            $(ddlLista_grilla).val('4');

            $(chkSi).prop('checked', false);

        });
    }

function F_ValidarDevolucion(Mensaje) {
        try {
            var chkSi = '';
            var x = 0;

            $('#MainContent_grvDetalleOC .chkDelete :checkbox').each(function () {
                chkSi = '#' + this.id;

                if ($(chkSi).is(':checked'))
                    x = 1;
            });

           
            if (x == 0) {
                alertify.log(Mensaje);
                return false;
            }
            else
            { return true; }

        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }
    }

function F_Devolucion(){
 try 
        {
        var chkSi='';
        var arrDetalle = new Array();
        var lblcoddetalle_grilla='';
        
               
                $('#MainContent_grvDetalleOC .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblCodDetalle = chkSi.replace('chkEliminar', 'lblCodDetalle');
                    hfCodArticulo = chkSi.replace('chkEliminar', 'hfCodArticulo');
                    hfCodUndMedida = chkSi.replace('chkEliminar', 'hfCodUndMedida');
                    hfCostoUnitario = chkSi.replace('chkEliminar', 'hfCostoUnitario');
                    hfSerieDoc = chkSi.replace('chkEliminar', 'hfSerieDoc');
                    lblPrecio = chkSi.replace('chkEliminar', 'lblPrecio');
                    hfNumeroDoc = chkSi.replace('chkEliminar', 'hfNumeroDoc');
                    txtCantidadEntregada = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
                   
                  if ($(chkSi).is(':checked')) 
                    {
                        var objDetalle = {
                        CodDetalle: $(lblCodDetalle).text(),
                        CodArticulo: $(hfCodArticulo).val(),
                        CodUndMedida: $(hfCodUndMedida).val(),
                        SerieDoc: $(hfSerieDoc).val(),
                        NumeroDoc: $(hfNumeroDoc).val(),
                        Costo: $(lblPrecio).text(),
                        Cantidad: $(txtCantidadEntregada).val(),
                        CostoUnitario: $(hfCostoUnitario).val()
                        };
                                               
                        arrDetalle.push(objDetalle);
                    }
                });

            
                var Contenedor = '#MainContent_';
                var tasaigv=parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

                var objParams = {
                                        Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
                                        Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
                                        Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                                        Filtro_TipoCambio: $(Contenedor + 'lblTC').text(),
                                        Filtro_CodTasa: $(Contenedor + 'ddlIgv').val() ,
                                        Filtro_TasaIgv: tasaigv,
                                      
                                };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);
                F_Devolucion_NET(arg, function (result) {

                  MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                    F_Update_Division_HTML('div_DetalleOC', result.split('~')[3]);
                    if (result.split('~')[2]=='Se grabo correctamente')
                    alertify.log('Se grabo correctamente');
                }
                else 
                {
                    alertify.log(result.split('~')[2]);
                }

                return false;

                });
        }
        
        catch (e) 
        {
              MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
        }
}

function F_ValidarCheck_OC(ControlID) {

    var txtprecio_Grilla = '';
    var ddlLista_grilla = '';
    var txtcant_grilla = '';
    var txtprecio_grilla = '';
    var boolEstado = false;
    var chkok_grilla='';
                   
            chkok_grilla = '#' + ControlID;
            txtCantidadEntregada = chkok_grilla.replace('chkEliminar', 'txtCantidadEntregada');
            lblCantidad = chkok_grilla.replace('chkEliminar', 'lblCantidad');
                 
            boolEstado = $(chkok_grilla).is(':checked');
            if (boolEstado)
            {
               
                $(txtCantidadEntregada).prop('disabled', false);
                $(txtCantidadEntregada).val($(lblCantidad).text());
                $(txtCantidadEntregada).focus();
            }
            else
            {
                $(txtCantidadEntregada).val('');
                $(txtCantidadEntregada).prop('disabled', true);
            }
            
        
    return true;
}

function F_ValidarStockGrillaOC(ControlID) {


    
    var txtcantidad_Grilla = '';
    var lblstock = '';
    var txtcant_grilla = '';
    var boolEstado = false;
    var chkok_grilla = '';

    txtcantidad_Grilla = '#' + ControlID;
    chkok_grilla = txtcantidad_Grilla.replace('txtCantidadEntregada', 'chkEliminar');
    lblstock = txtcantidad_Grilla.replace('txtCantidadEntregada', 'lblCantidad');

    
    boolEstado = $(chkok_grilla).is(':checked');

    if (boolEstado &&  parseFloat($(txtcantidad_Grilla).val()) > parseFloat($(lblstock).text())) {
            alertify.log("Stock insuficiente");
            $(txtcantidad_Grilla).val($(lblstock).text());
            F_MostrarTotales();
            return false;
    }
    if ($(txtcantidad_Grilla).val()=='')
        $(txtcantidad_Grilla).val($(lblstock).text());
    
    if (boolEstado==false)
     $(txtcantidad_Grilla).val($(lblstock).text());


    return true;
}

function ValidarRuc(valor) {
            valor = trim(valor)
            if (esnumero(valor)) {
                if (valor.length == 8) {
                    suma = 0
                    for (i = 0; i < valor.length - 1; i++) {

                        if (i == 0) suma += (digito * 2)
                        else suma += (digito * (valor.length - i))
                    }
                    resto = suma % 11;
                    if (resto == 1) resto = 11;
                    if (resto + (valor.charAt(valor.length - 1) - '0') == 11) {
                        return true
                    }
                } else if (valor.length == 11) {
                    suma = 0
                    x = 6
                    for (i = 0; i < valor.length - 1; i++) {
                        if (i == 4) x = 8
                        digito = valor.charAt(i) - '0';
                        x--
                        if (i == 0) suma += (digito * x)
                        else suma += (digito * x)
                    }
                    resto = suma % 11;
                    resto = 11 - resto

                    if (resto >= 10) resto = resto - 10;
                    if (resto == valor.charAt(valor.length - 1) - '0') {
                        return true
                    }
                }
            }
            return false
        }

function esnumero(campo) { return (!(isNaN(campo))); }

function F_FacturacionCotizacion() {
        var Contenedor = '#MainContent_';
        var Mensaje = "Ingrese los sgtes datos: ";

        if ($(Contenedor + 'txtCodCotizacion').val() == "")
            Mensaje = Mensaje + "\n" + "Codigo (ID)";
  
        if (Mensaje != "Ingrese los sgtes datos: ") {
            alertify.log(Mensaje);
            return false;
        }
        var tasaigv=parseFloat( $("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

        try {
            var objParams = {
                Filtro_CodProforma: $(Contenedor + 'txtCodCotizacion').val(),
                Filtro_TasaIgv: tasaigv,
                Filtro_NotaPedido: '0'
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);

            F_FacturacionCotizacion_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_mensaje_operacion == "")
                {
                   $('#hfCodigoTemporal').val(result.split('~')[2]);
                   $('#hfCodCtaCte').val(result.split('~')[3]);
                   $('#MainContent_ddlMoneda').val(result.split('~')[4]);
                   $('#MainContent_txtSubTotal').val(result.split('~')[5]);
                   $('#MainContent_txtIgv').val(result.split('~')[6]);
                   $('#MainContent_txtTotal').val(result.split('~')[7]);
                   $('#hfCodDepartamento').val(result.split('~')[8]);
                   $('#hfCodProvincia').val(result.split('~')[9]);
                   $('#hfCodDistrito').val(result.split('~')[10]);
                   $('#MainContent_txtDireccion').val(result.split('~')[11]);
                   $('#MainContent_txtNroRuc').val(result.split('~')[12]);
                   $('#MainContent_txtDistrito').val(result.split('~')[13]);
                   $('#MainContent_txtCliente').val(result.split('~')[14]);
                   F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[15]);
                   $('#MainContent_ddlFormaPago').val('1');
                   $('#hfCodProforma').val($(Contenedor + 'txtCodCotizacion').val());
                   $('#div_FacturarCotizacion').dialog('close');
                   return false;
                }
                else
                { 
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

function F_FacturacionGuia() {
        var Contenedor = '#MainContent_';
        var Mensaje = "Ingrese los sgtes datos: ";

        if ($(Contenedor + 'txtProveedor').val() == "" || $('#hfCodCtaCte').val() == 0)
            Mensaje = Mensaje + "\n" + "Proveedor";

        if ($(Contenedor + 'lblTC').text() == "0")
            Mensaje = Mensaje + "\n" + "Tipo de Cambio";

        if (Mensaje != "Ingrese los sgtes datos: ") {
            alertify.log(Mensaje);
            return false;
        }

        try {
            var objParams = {
                Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                Filtro_CodMotivoTraslado: 9
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);

            F_FacturacionGuia_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") {

                    $('#div_FacturacionGuia').dialog({
                        resizable: false,
                        modal: true,
                        title: "Facturacion Guia",
                        title_html: true,
                        height: 500,
                        width: 890,
                        autoOpen: false
                    });
                    F_Update_Division_HTML('div_GrillaFacturacionGuia', result.split('~')[2]);

                    if (str_mensaje_operacion != "")
                        alertify.log(str_mensaje_operacion);
                    else
                        $('#div_FacturacionGuia').dialog('open');

                    return false;

                }

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

function F_ValidarDevolucionGuia(Mensaje) {
        try {
            var chkSi = '';
            var x = 0;

            $('#MainContent_grvFacturacionGuia .chkDelete :checkbox').each(function () {
                chkSi = '#' + this.id;

                if ($(chkSi).is(':checked'))
                    x = 1;
            });

           
            if (x == 0) {
                alertify.log(Mensaje);
                return false;
            }
            else
            { return true; }

        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }
    }

function F_DevolucionGuia(){
 try 
        {
        var chkSi='';
        var arrDetalle = new Array();
        var lblcoddetalle_grilla='';
        
               
                $('#MainContent_grvFacturacionGuia .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblCodDetalle = chkSi.replace('chkEliminar', 'lblCodDetalle');
                    hfCodArticulo = chkSi.replace('chkEliminar', 'hfCodArticulo');
                    hfCodUndMedida = chkSi.replace('chkEliminar', 'hfCodUndMedida');
                    hfCostoUnitario = chkSi.replace('chkEliminar', 'hfCostoUnitario');
                    hfSerieDoc = chkSi.replace('chkEliminar', 'hfSerieDoc');
                    lblPrecio = chkSi.replace('chkEliminar', 'lblPrecio');
                    hfNumeroDoc = chkSi.replace('chkEliminar', 'hfNumeroDoc');
                    txtCantidadEntregada = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
                   
                  if ($(chkSi).is(':checked')) 
                    {
                        var objDetalle = {
                        CodDetalle: $(lblCodDetalle).text(),
                        CodArticulo: $(hfCodArticulo).val(),
                        CodUndMedida: $(hfCodUndMedida).val(),
                        SerieDoc: $(hfSerieDoc).val(),
                        NumeroDoc: $(hfNumeroDoc).val(),
                        Costo: $(lblPrecio).text(),
                        Cantidad: $(txtCantidadEntregada).val(),
                        CostoUnitario: $(hfCostoUnitario).val()
                        };
                                               
                        arrDetalle.push(objDetalle);
                    }
                });

            
                var Contenedor = '#MainContent_';
                var tasaigv=parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

                var objParams = {
                                        Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
                                        Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
                                        Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                                        Filtro_TipoCambio: $(Contenedor + 'lblTC').text(),
                                        Filtro_CodTasa: $(Contenedor + 'ddlIgv').val() ,
                                        Filtro_TasaIgv: tasaigv,
                                        Filtro_CodMotivoTraslado: 9
                                      
                                };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                MostrarEspera(true);
                F_DevolucionGuia_NET(arg, function (result) {

                  MostrarEspera(false);

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") 
                {
                    F_Update_Division_HTML('div_GrillaFacturacionGuia', result.split('~')[3]);
                    if (result.split('~')[2]=='Se grabo correctamente')
                    alertify.log('Se grabo correctamente');
                }
                else 
                {
                    alertify.log(result.split('~')[2]);
                }

                return false;

                });
        }
        
        catch (e) 
        {
              MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
        }
}

function F_ListarNroCuenta() {

    var arg;

    try {

        var objParams = {

            Filtro_CodBanco:  $('#MainContent_ddlBanco').val(),
            Filtro_CodMoneda:  $('#MainContent_ddlMoneda').val()
        };

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ListarNroCuenta_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") 
                    {
                     F_Update_Division_HTML('div_Cuenta', result.split('~')[2]);
                                
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

function F_AgregarTemporalGuia() {
        try {

            var lblcodproducto_grilla = '';
            var lblcodunidadventa_grilla = '';
            var lblNumero = '';
            var lblcosto_grilla = '';
            var chkSi = '';
            var txtcantidad_grilla = '';
            var txtprecio_grilla = '';
            var txtdscto_grilla = '';
            var arrDetalle = new Array();
            var hfcodunidadventa_grilla = '';
            var hfcosto_grilla = '';
            var Contenedor = '#MainContent_';

            $('#MainContent_grvFacturacionGuia .chkDelete :checkbox').each(function () {
                chkSi = '#' + this.id;
                lblcodproducto_grilla = chkSi.replace('chkEliminar', 'hfCodArticulo');
                lblcodunidadventa_grilla = chkSi.replace('chkEliminar', 'hfCodUndMedida');
                lblcosto_grilla = chkSi.replace('chkEliminar', 'lblPrecio');
                txtprecio_grilla = chkSi.replace('chkEliminar', 'lblPrecio');
                txtcantidad_grilla = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
                hfcodunidadventa_grilla = chkSi.replace('chkEliminar', 'hfCodUndMedida');
                hfcosto_grilla = chkSi.replace('chkEliminar', 'lblPrecio');
                lblCodDetalle = chkSi.replace('chkEliminar', 'lblCodDetalle');
                hfCostoUnitario = chkSi.replace('chkEliminar', 'hfCostoUnitario');
                lblNumero = chkSi.replace('chkEliminar', 'lblNumero');

                if ($(chkSi).is(':checked')) {
                    var objDetalle = {
                        CodArticulo: $(lblcodproducto_grilla).val(),
                        Cantidad: $(txtcantidad_grilla).val(),
                        Precio: $(txtprecio_grilla).text(),
                        Costo: $(hfcosto_grilla).text(),
                        CodUm: $(hfcodunidadventa_grilla).val(),
                        CostoUnitario: $(hfCostoUnitario).val(),
                        Dscto: 0,
                        CodDetalle: $(lblCodDetalle).text(),
                        OC: $(lblNumero).text()
                    };

                    arrDetalle.push(objDetalle);
                }
            });

            var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

                  
            var objParams = {
                Filtro_CodTipoDoc: "1",
                Filtro_SerieDoc: $(Contenedor + 'ddlSerie').val(),
                Filtro_NumeroDoc: $(Contenedor + 'txtNumero').val(),
                Filtro_FechaEmision: $(Contenedor + 'txtEmision').val(),
                Filtro_Vencimiento: $(Contenedor + 'txtVencimiento').val(),
                Filtro_CodCliente: $('#hfCodCtaCte').val(),
                Filtro_CodFormaPago: $(Contenedor + 'ddlFormaPago').val(),
                Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
                Filtro_TipoCambio: $(Contenedor + 'lblTC').text(),
                Filtro_SubTotal: $(Contenedor + 'txtSubTotal').val(),
                Filtro_CodProforma: "0",
                Filtro_Igv: $(Contenedor + 'txtIgv').val(),
                Filtro_Total: $(Contenedor + 'txtTotal').val(),
                Filtro_CodTraslado: "0",
                Filtro_Descuento: "0",
                Filtro_TasaIgv: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                Filtro_TasaIgvDscto: tasaigv,
                Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
                Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle)
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

            MostrarEspera(true);
            F_AgregarTemporal_NET(arg, function (result) {
                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];
                MostrarEspera(false);
                if (str_resultado_operacion == "1") {
                    $('#hfCodigoTemporal').val(result.split('~')[3]);
                    $('#MainContent_txtTotal').val(result.split('~')[5]);
                    $('#MainContent_txtMonto').val(result.split('~')[5]);
                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                    $('#MainContent_txtDsctoTotal').val(result.split('~')[8]);
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                    if (result.split('~')[2] == 'Los Producto(s) se han agregado con exito')
                        alertify.log('Los Producto(s) se han agregado con exito');
                }
                else {
                    MostrarEspera(false);
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

function F_FacturaNotaVenta() {
    var Contenedor = '#MainContent_';
    var Mensaje = "Ingrese los sgtes datos: ";

    if ($(Contenedor + 'txtCodNotaVenta').val() == "")
        Mensaje = Mensaje + "\n" + "Codigo (ID)";

    if (Mensaje != "Ingrese los sgtes datos: ") {
        alertify.log(Mensaje);
        return false;
    }
    var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

    try {
        var objParams = {
            Filtro_CodDocumentoVenta: $(Contenedor + 'txtCodNotaVenta').val(),
            Filtro_TasaIgv: tasaigv,
            Filtro_NotaPedido: '0'
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_FacturacionNotaVenta_NET(arg, function (result) {
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
                $('#hfCodNotaVenta').val($(Contenedor + 'txtCodNotaVenta').val());
                $('#div_FacturacionNotaVenta').dialog('close');
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

function F_VistaPreliminar(HlkControlID){
        var Codigo = '';
     
        Codigo = $('#' + HlkControlID).text();


 var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = '5';

    rptURL = '../Reportes/Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Codigo=' + Codigo + '&' ;
      
    window.open(rptURL, "PopUpRpt", Params);

    return false;

}

function F_ActualizarPrecio(Fila) {
 try 
        {
            var txtPrecio =  '#' + Fila;
           
            var lblcoddetalle = txtPrecio.replace('txtPrecio', 'lblcoddetalle');
            var hfPrecio = txtPrecio.replace('txtPrecio', 'hfPrecio');
            var hfCantidad = txtPrecio.replace('txtPrecio', 'hfCantidad');
            var txtCantidad = txtPrecio.replace('txtPrecio', 'txtCantidad');

            if(parseFloat($(txtPrecio).val())==parseFloat($(hfPrecio).val()) & parseFloat($(txtCantidad).val())==parseFloat($(hfCantidad).val()))
            {
            $(txtPrecio).val(parseFloat($(txtPrecio).val()).toFixed(2));
            $(txtCantidad).val(parseFloat($(txtCantidad).val()).toFixed(2));
            return false;
            }
            
            var tasaigv=parseFloat( $("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

            var objParams = {
                              Filtro_Precio: $(txtPrecio).val()/tasaigv,
                              Filtro_Cantidad: $(txtCantidad).val(),
                              Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
                              Filtro_CodDetDocumentoVenta: $(lblcoddetalle).text(),
                              Filtro_TasaIgv: tasaigv,
                              Filtro_NotaPedido: 0
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);
            F_ActualizarPrecio_Net(arg, function (result) {

                            var str_resultado_operacion = "";
                            var str_mensaje_operacion = "";

                            str_resultado_operacion = result.split('~')[0];
                            str_mensaje_operacion = result.split('~')[1];
                MostrarEspera(false);
                if (str_mensaje_operacion == "") {
                    $('#hfCodigoTemporal').val(result.split('~')[3]);
                    if (result.split('~')[5]=='0')
                    {
                     $('#MainContent_txtTotal').val('0.00');
                    $('#MainContent_txtIgv').val('0.00');
                    $('#MainContent_txtSubTotal').val('0.00');
                    }
                    else
                    {
                      $('#MainContent_txtTotal').val(result.split('~')[5]);
                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                    }
                   
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                }
                else {
                     F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                     alertify.log(result.split('~')[1]);
                }

                return false;
            });

            }
        
        catch (e) 
        {
        MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }

 
}

function F_ActualizarCantidad(Fila) {
 try 
        {
            var txtCantidad =  '#' + Fila;
           
            var lblcoddetalle = txtCantidad.replace('txtCantidad', 'lblcoddetalle');
            var hfPrecio = txtCantidad.replace('txtCantidad', 'hfPrecio');
            var hfCantidad = txtCantidad.replace('txtCantidad', 'hfCantidad');
            var txtPrecio = txtCantidad.replace('txtCantidad', 'txtPrecio');

            if(parseFloat($(txtPrecio).val())==parseFloat($(hfPrecio).val()) & parseFloat($(txtCantidad).val())==parseFloat($(hfCantidad).val()))
            {
            $(txtPrecio).val(parseFloat($(txtPrecio).val()).toFixed(2));
            $(txtCantidad).val(parseFloat($(txtCantidad).val()).toFixed(2));
            return false;
            }

//            if(parseFloat($(txtCantidad).val())>parseFloat($(hfCantidad).val()))
//            {
//            alertify.log("Stock Insuficiente");
//            return false;
//            }
            
            var tasaigv=parseFloat( $("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

            var objParams = {
                              Filtro_Precio: $(txtPrecio).val()/tasaigv,
                              Filtro_Cantidad: $(txtCantidad).val(),
                              Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
                              Filtro_CodDetDocumentoVenta: $(lblcoddetalle).text(),
                              Filtro_TasaIgv: tasaigv,
                              Filtro_NotaPedido: 0
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);
            F_ActualizarPrecio_Net(arg, function (result) {

                            var str_resultado_operacion = "";
                            var str_mensaje_operacion = "";

                            str_resultado_operacion = result.split('~')[0];
                            str_mensaje_operacion = result.split('~')[1];
                MostrarEspera(false);
                if (str_mensaje_operacion == "") {
                    $('#hfCodigoTemporal').val(result.split('~')[3]);
                    if (result.split('~')[5]=='0')
                    {
                     $('#MainContent_txtTotal').val('0.00');
                    $('#MainContent_txtIgv').val('0.00');
                    $('#MainContent_txtSubTotal').val('0.00');
                    }
                    else
                    {
                      $('#MainContent_txtTotal').val(result.split('~')[5]);
                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                    }
                   
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                }
                else {
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                     alertify.log(result.split('~')[1]);
                }

                return false;
            });

            }
        
        catch (e) 
        {
        MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }

 
}

function F_PrecioMoneda(HlkControlID) {

     var   CodProducto = $('#' + HlkControlID.replace('hlkMoneda', 'lblcodproducto')).text();
     var   CodMoneda = 2;
     if ($('#MainContent_ddlMoneda').val()==2)
     CodMoneda = 1

        try {
            var objParams = {
                Filtro_CodProducto: CodProducto,
                Filtro_CodMoneda: CodMoneda,
                Filtro_Fecha : $('#MainContent_txtEmision').val()
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);

            F_PrecioMoneda_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1")
                {
                        $('#div_VerPrecio').dialog({
                                resizable: false,
                                modal: true,
                                title: "Ver Precios",
                                title_html: true,
                                height: 120,
                                width: 350,
                                autoOpen: false
                        });
                        F_Update_Division_HTML('div_PrecioMoneda', result.split('~')[2]); 
                        $('#div_VerPrecio').dialog('open');
                }
                   
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

function F_EliminarRegistro(Fila) {
 try 
        {
    var imgID = Fila.id;
    var lblCodigo = '#' + imgID.replace('imgEliminarDocumento', 'lblCodigo');
    var lblEstado = '#' + imgID.replace('imgEliminarDocumento', 'lblEstado');
    var lblnumero_grilla = '#' + imgID.replace('imgEliminarDocumento', 'lblNumero');
    var lblcliente_grilla = '#' + imgID.replace('imgEliminarDocumento', 'lblcliente');    
  
    if(confirm("ESTA SEGURO DE ELIMINAR LA FACTURA : " + $(lblnumero_grilla).text() + "\n" + "Del Cliente : " +  $(lblcliente_grilla).text())==false)
    return false;

     var chkNumero='0';
              var chkFecha='0';
              var chkCliente='0';

              if ($('#MainContent_chkNumero').is(':checked'))
              chkNumero='1';

              if ($('#MainContent_chkRango').is(':checked'))
              chkFecha='1';

              if ($('#MainContent_chkCliente').is(':checked'))
              chkCliente='1';

    var objParams = {
                          Filtro_Codigo: $(lblCodigo).text(),
                          Filtro_Serie: $("#MainContent_ddlSerie option:selected").text(),
                          Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                          Filtro_Desde: $('#MainContent_txtDesde').val(),
                          Filtro_Hasta: $('#MainContent_txtHasta').val(),
                          Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                          Filtro_CodTipoDoc: '1',
                          Filtro_ChkNumero: chkNumero,
                          Filtro_ChkFecha: chkFecha,
                          Filtro_ChkCliente: chkCliente
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
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);      
                alertify.log(result.split('~')[1]);
        }
        else {
             alertify.log(result.split('~')[1]);
        }

        return false;
    });

            }
        
        catch (e) 
        {
        MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }

 
}

function F_ValidarPrecioGrilla(ControlID) {

//            var txtprecio_Grilla = '';
//            var lblprecio_grilla = '';
//            var txtcant_grilla = '';
//            var txtprecio_grilla = '';
//            var boolEstado = false;
//             chkok_grilla='';

            var txtPrecio = '#' + ControlID;
//            chkok_grilla = txtPrecio.replace('txtPrecio', 'chkOK');
//            lblprecio_grilla = txtPrecio.replace('txtPrecio', 'lblPrecio1');
//            boolEstado = $(chkok_grilla).is(':checked');
                
              if($(txtPrecio).val()=='')
              return false;

//            if ($('#hfCodUsuario').val()!='5' && boolEstado && parseFloat($(txtprecio_Grilla).val())< parseFloat($(lblprecio_grilla).val()))
//            {alertify.log("Precio por debajo del minimo");
//            $(txtprecio_Grilla).val('');
//              return false;
//             }

    return false;
}


function F_ImprimirFacturaHTML(codigo,Fila) {
    var nrodoc = '';
    if (codigo == undefined) {
        var imgID = Fila.id;
        //        var lblCodigo = '#' + imgID.replace('imgPdf', 'lblCodigo');
        var lblCodigo = '#' + imgID.replace('imgTCK', 'lblCodigo');
        var lblNumero = '#' + imgID.replace('imgTCK', 'lblnumero');
        codigo = $(lblCodigo).text();
        nrodoc = $(lblNumero).text();
    }

    if (nrodoc.substr(0, 1) == '0')
    { //si es factura NO electronica = Impresion matricial

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = '203';

    rptURL = '../Reportes/Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Codigo=' + codigo + '&';

    window.open(rptURL, "PopUpRpt", Params);

    }
    else
    { //si es factura ELECTRONICA : impresion ticketera
        try {
            var objParams = {
                Filtro_Codigo: codigo
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);

            F_ImprimirFacturaTicket_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1")
                    alertify.log('SE ENVIO LA IMPRESION');
                else
                    alertify.log('HUBO UN ERROR EN LA IMPRESION');

                return false;

            });
        }
        catch (e) {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }
    } 
    return false;
}
