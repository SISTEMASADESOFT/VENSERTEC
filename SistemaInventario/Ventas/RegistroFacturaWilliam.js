var AppSession = "../Ventas/RegistroFacturaWilliam.aspx";
var CodigoMenu = 4000; var CodigoInterno = 2;
var Codtipodoc=1

var Ubigeo = 0;
var CodDirecionDestinoEdicion = 0;
var CodDirecionTransportistaEdicion = 0;
var Direccion = '';
var Cuerpo='#MainContent_';
//---------------------------- 
var CodigoEmpresa =2; //1 Vensertec //2Lubricentro

// Lista de Impresoras impresion masiva
var ImpresorasNotaPedido = ['IMPRESORAFACTURAELECTRONICA', 'Otra Impresora'];
//----------------------------

var FormaPagoDefault = 1; //Viene de la Base de Datos
var MostrarUMConsultas = 1;
var RedondeoAM = 0;
var ValidarStock = 0; //1 Si valida //0 No Valida
var P_ImpresionImpresora = "1";
var P_ImpresionTicketera = "1";
var P_EDITAR_PRECIOS = "0";

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    F_FuncionesBotones();

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

//    $('#MainContent_txtNroRuc').autocomplete({
//        source: function (request, response) {
//            $.ajax({
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
//                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'1','CodTipoCliente':'" + $('#hfCodTipoCliente').val() + "'}",
//                dataType: "json",
//                async: true,
//                success: function (data) {
//                    response($.map(data.d, function (item) {
//                        return {
//                            label: item.split(',')[1],
//                            val: item.split(',')[0],
//                            Direccion: item.split(',')[2],
//                            DireccionEnvio: item.split(',')[3],
//                            Distrito: item.split(',')[4],
//                            CodDepartamento: item.split(',')[5],
//                            CodProvincia: item.split(',')[6],
//                            CodDistrito: item.split(',')[7],
//                            NroRuc: item.split(',')[8],
//                            ApePaterno: item.split(',')[9],
//                            ApeMaterno: item.split(',')[10],
//                            Nombres: item.split(',')[11],
//                            Cliente: item.split(',')[1],
//                            SaldoCreditoFavor: item.split(',')[12],
//                            CodDireccion: item.split(',')[13]
//                        }
//                    }))
//                },
//                error: function (response) {
//                    alertify.log(response.responseText);
//                },
//                failure: function (response) {
//                    alertify.log(response.responseText);
//                }
//            });
//        },
//        select: function (e, i) {
//            $('#MainContent_txtNroRuc').val(i.item.NroRuc);
//            $('#hfNroRuc').val(i.item.NroRuc);
//            $('#hfCodCtaCte').val(i.item.val);
//            $('#hfCliente').val(i.item.label);
//            $('#MainContent_txtCliente').val(i.item.label);
//            $('#MainContent_txtNroRuc').val(i.item.NroRuc);
//            $('#MainContent_txtDireccion').val(i.item.Direccion);
//            $('#MainContent_txtDistrito').val(i.item.Distrito.trim());
//            $('#hfCodDireccion').val('0');
//            $('#hfCodDepartamento').val(i.item.CodDepartamento);
//            $('#hfCodProvincia').val(i.item.CodProvincia);
//            $('#hfCodDistrito').val(i.item.CodDistrito);
//            $('#hfDistrito').val(i.item.Distrito.trim());
//            $('#hfCodDireccionDefecto').val(i.item.CodDireccion);

//            //$('#txtSaldoCreditoFavor').text(i.item.SaldoCreditoFavor);
//            //$('#hfSaldoCreditoFavor').val(i.item.SaldoCreditoFavor.replace("S/", "").replace(" ", ""));
//            if ($("#MainContent_chkGuia").is(':checked')) 
//                $('#MainContent_txtDestino').val($("#MainContent_txtDireccion").val().trim() + ' ' + $('#MainContent_txtDistrito').val().trim());
//            //F_BuscarDireccionPorDefecto();
//            F_BuscarDireccionesCliente();
//            F_BuscarResponsables();
//            if ($('#hfNotaPedido').val() == '5' & $('#hfCodCtaCte').val() != $('#hfCodCtaCteNP').val())
//                F_EliminarTodos();
//            if ($('#hfNotaPedido').val() != '0'  & ($('#MainContent_ddlTipoDoc').val() == '5' | $('#MainContent_ddlTipoDoc').val() == '15' | $('#MainContent_ddlTipoDoc').val() == '16'))
//                F_EliminarTodos();
//        },
//        complete: function () {
//            $('#MainContent_txtNroRuc').val($('#hfNroRuc').val());
//            $('#MainContent_txtCliente').focus();
//        },
//        minLength: 3
//    });


$('#MainContent_txtNroRuc').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'1','CodTipoCliente':'" + $('#hfCodTipoCliente').val() + "'}",
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
                            Nombres: item.split(',')[11],
                            Cliente: item.split(',')[1],
                            SaldoCreditoFavor: item.split(',')[12],
                            CodDireccion: item.split(',')[13]
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
            $('#MainContent_txtNroRuc').val(i.item.NroRuc);
            $('#hfNroRuc').val(i.item.NroRuc);
            $('#hfCodCtaCte').val(i.item.val);
            $('#hfCliente').val(i.item.label);
            $('#MainContent_txtCliente').val(i.item.label);
            $('#MainContent_txtNroRuc').val(i.item.NroRuc);
            $('#MainContent_txtDireccion').val(i.item.Direccion);
            $('#MainContent_txtDistrito').val(i.item.Distrito.trim());
            $('#hfCodDireccion').val('0');
            $('#hfCodDepartamento').val(i.item.CodDepartamento);
            $('#hfCodProvincia').val(i.item.CodProvincia);
            $('#hfCodDistrito').val(i.item.CodDistrito);
            $('#hfDistrito').val(i.item.Distrito.trim());
            $('#hfCodDireccionDefecto').val(i.item.CodDireccion);
            F_LlenarCorreos();
            //$('#txtSaldoCreditoFavor').text(i.item.SaldoCreditoFavor);
            //$('#hfSaldoCreditoFavor').val(i.item.SaldoCreditoFavor.replace("S/", "").replace(" ", ""));
            if ($("#MainContent_chkGuia").is(':checked')) 
                $('#MainContent_txtDestino').val($("#MainContent_txtDireccion").val().trim() + ' ' + $('#MainContent_txtDistrito').val().trim());
            //F_BuscarDireccionPorDefecto();
//            F_BuscarDireccionesCliente();
            F_BuscarResponsables();
            if ($('#hfNotaPedido').val() == '5' & $('#hfCodCtaCte').val() != $('#hfCodCtaCteNP').val())
            {
                F_EliminarTodos();
                }
            if ($('#hfNotaPedido').val() != '0'  & ($('#MainContent_ddlTipoDoc').val() == '5' | $('#MainContent_ddlTipoDoc').val() == '15' | $('#MainContent_ddlTipoDoc').val() == '16')){
                F_EliminarTodos();
                }
                
            F_GuardarDireccion($('#MainContent_txtNroRuc').val(),'#hfCodigoTemporal',$('#hfCodCtaCte').val(),'#MainContent_txtCliente'
            ,0,Ubigeo,Direccion,'#MainContent_ddldireccionNueva','#MainContent_ddldireccionNuevaDestino',1);     
        },
        close: function () {
         if ($('#hfCodCtaCte').val()>0)
            {
                $('#MainContent_txtNroRuc').val($('#hfNroRuc').val());
                $('#MainContent_txtCliente').focus();
                F_LlenarCorreos();
            }
        },
        minLength: 3
    });

    //modificado - miguel
        $('#MainContent_txtNroRucTransportista').autocomplete(   
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'2','CodTipoCliente':'2'}",
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
                            Nombres: item.split(',')[11],
                            Cliente: item.split(',')[1],
                            SaldoCreditoFavor: item.split(',')[12],
                            CodDireccion: item.split(',')[14]
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
            $('#hfCodTransportista').val(i.item.val);
            $('#MainContent_txtNroRucTransportista').val(i.item.NroRuc);
            $('#hfNroRucTransportista').val(i.item.NroRuc);
            $('#hfCodCtaCteTransportista').val(i.item.val);
            $('#hfTransportista').val(i.item.label);
            $('#MainContent_txtTransportista').val(i.item.label);
            $('#MainContent_txtNroRucTransportista').val(i.item.NroRuc);
            $('#MainContent_txtDireccionTransportista').val(i.item.Direccion);
            $('#hfDireccionTransportista').val(i.item.Direccion);
            $('#hfCodDireccionTransportista').val(i.item.CodDireccion);
            $('#hfCodDireccionDefectoTransportista').val(i.item.CodDireccion);
            $('#MainContent_txtDistritoTransportista').val(i.item.Distrito);
            $('#hfCodDepartamentoTransportista').val(i.item.CodDepartamento);
            $('#hfCodProvinciaTransportista').val(i.item.CodProvincia);
            $('#hfCodDistritoTransportista').val(i.item.CodDistrito);
            $('#hfDistritoTransportista').val(i.item.Distrito.trim());
//            F_BuscarDireccionesTransportista();
 F_GuardarDireccion($('#MainContent_txtNroRucTransportista').val(),'#hfCodigoTemporal',$('#hfCodCtaCteTransportista').val()
            ,'#MainContent_txtTransportista',1,Ubigeo,Direccion,'#MainContent_ddldireccionNuevaTransportista','',1);
        },
        close: function () {
        if ($('#hfCodTransportista').val()>0)
            {
            $('#MainContent_txtNroRucTransportista').val($('#hfNroRucTransportista').val());
            $('#MainContent_txtTransportista').focus();
            
            }
        },
        minLength: 3
    });

        $('#MainContent_txtProductoConsulta').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_Producto_AUTOCOMPLETE',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            val: item.split(',')[0],
                            label: item.split(',')[1]
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
            $('#MainContent_txtProductoConsulta').val(i.item.label);
            $('#hfcodproductoconsulta').val(i.item.val);
        },
        minLength: 1
    });

        $('#MainContent_txtNroRucTransportistaEdicion').autocomplete(   
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'2','CodTipoCliente':'2'}",
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
                            Nombres: item.split(',')[11],
                            Cliente: item.split(',')[1],
                            SaldoCreditoFavor: item.split(',')[12],
                            CodDireccion: item.split(',')[14]
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
            $('#hfCodTransportistaEdicion').val(i.item.val);
            $('#MainContent_txtNroRucTransportistaEdicion').val(i.item.NroRuc);
            $('#hfNroRucTransportistaEdicion').val(i.item.NroRuc);
            $('#hfCodCtaCteTransportistaEdicion').val(i.item.val);
            $('#hfTransportistaEdicion').val(i.item.label);
            $('#MainContent_txtTransportistaEdicion').val(i.item.label);
            $('#MainContent_txtNroRucTransportistaEdicion').val(i.item.NroRuc);
            $('#hfNroRucTransportistaEdicion').val(i.item.NroRuc);
//            $('#MainContent_txtDireccionTransportistaEdicion').val(i.item.Direccion);
//            $('#hfDireccionTransportistaEdicion').val(i.item.Direccion);
//            $('#hfCodDireccionTransportistaEdicion').val(i.item.CodDireccion);
//            $('#hfCodDireccionDefectoTransportistaEdicion').val(i.item.CodDireccion);
//            $('#MainContent_txtDistritoTransportistaEdicion').val(i.item.Distrito);
//            $('#hfCodDepartamentoTransportistaEdicion').val(i.item.CodDepartamento);
//            $('#hfCodProvinciaTransportistaEdicion').val(i.item.CodProvincia);
//            $('#hfCodDistritoTransportistaEdicion').val(i.item.CodDistrito);
//            $('#hfDistritoTransportistaEdicion').val(i.item.Distrito.trim());
//            F_BuscarDireccionesTransportistaEdicion();
            F_GuardarDireccion($('#MainContent_txtNroRucTransportistaEdicion').val(),'#hfCodigoTemporalEdicion',$('#hfCodTransportistaEdicion').val()
            ,'#MainContent_txtTransportistaEdicion',1,Ubigeo,Direccion,'#MainContent_ddldireccionNuevaTransportistaEdicion','',1);
        },
        close: function () {
            $('#MainContent_txtNroRucTransportistaEdicion').val($('#hfNroRucTransportistaEdicion').val());
            $('#MainContent_txtTransportistaEdicion').focus();
        },
        minLength: 3
    });
    

           $('#MainContent_txtDistritoMultiple').autocomplete({
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
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfDepartamento').val(i.item.val);
            $('#hfProvincia').val(i.item.CodProvincia);
            $('#hfDistrito').val(i.item.CodDistrito);
        },
        minLength: 3
    });

  $('#MainContent_txtConductorDNI').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 2 + "','CodTipoCliente':'" + 4 + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2],
                            Nombre: item.split(',')[11],
                            RUC: item.split(',')[8]
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
            $('#hfCodConductor').val(i.item.val);
            $('#hfDniConductor').val(i.item.RUC);
            $('#hfNombreConductor').val(i.item.Nombre);
            $('#MainContent_txtConductorDNI').val(i.item.RUC);
            $('#MainContent_txtConductorRazonSocial').val(i.item.Nombre);
        }, 
        complete: function () {
            $('#MainContent_txtConductorDNI').val($('#hfDniConductor').val());
            $('#MainContent_txtConductorRazonSocial').focus();
        },
        minLength: 3
    });

         $('#MainContent_txtConductorDNIEdicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 2 + "','CodTipoCliente':'" + 4 + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                               label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2],
                            Nombre: item.split(',')[11],
                            RUC: item.split(',')[8]
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
             $('#hfCodConductor').val(i.item.val);
            $('#hfDniConductor').val(i.item.RUC);
            $('#hfNombreConductor').val(i.item.Nombre);
              $('#MainContent_txtConductorDNIEdicion').val(i.item.RUC);
            $('#MainContent_txtConductorRazonSocialEdicion').val(i.item.Nombre);
        },
         complete: function () {
            $('#MainContent_txtConductorDNIEdicion').val($('#hfDniConductor').val());
            $('#MainContent_txtConductorRazonSocialEdicion').focus();
        },
        minLength: 3
    });


    $('#MainContent_txtClienteConsulta').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                //data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 1 + "','CodTipoCliente':'" + 2 + "'}",
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'1','CodTipoCliente':'" + $('#hfCodTipoCliente').val() + "'}",
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

    $('#MainContent_txtClienteNV').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                //data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 1 + "','CodTipoCliente':'" + 2 + "'}",
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'1','CodTipoCliente':'" + 0 + "'}",
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
            $('#hfCodClienteNV').val(i.item.val);
        },
        minLength: 3
    });

    $('#MainContent_txtClienteCT').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                //data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 1 + "','CodTipoCliente':'" + 2 + "'}",
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'1','CodTipoCliente':'" + 0 + "'}",
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
            $('#hfCodClienteCT').val(i.item.val);
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
            $('#hfDistrito').val(i.item.label);
            F_BuscarDireccionesCliente();
            //F_BuscarDireccionPorDefecto();
        },
        minLength: 3
    });

    //responsable
       
  $('#MainContent_txtResponsable1').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarResponsable_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','Codctacte':'" + $('#hfCodCtaCte').val() + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                         label: item.split(',')[2],
                            Nombre: item.split(',')[1],
                            RUC: item.split(',')[0]
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
            $('#MainContent_txtResponsableDNI1').val(i.item.RUC);
            $('#MainContent_txtResponsable1').val(i.item.Nombre);
        }, 
        complete: function () {
//            $('#MainContent_txtConductorDNI').val($('#hfDniConductor').val());
//            $('#MainContent_txtConductorRazonSocial').focus();
        },
        minLength: 3
    });

      //responsable
       
  $('#MainContent_txtResponsable2').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarResponsable_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','Codctacte':'" + $('#hfCodCtaCte').val() + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                         label: item.split(',')[2],
                            Nombre: item.split(',')[1],
                            RUC: item.split(',')[0]
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
            $('#MainContent_txtResponsableDNI2').val(i.item.RUC);
            $('#MainContent_txtResponsable2').val(i.item.Nombre);
        }, 
        complete: function () {
//            $('#MainContent_txtConductorDNI').val($('#hfDniConductor').val());
//            $('#MainContent_txtConductorRazonSocial').focus();
        },
        minLength: 3
    });

        //responsable
       
  $('#MainContent_txtResponsable1Edicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarResponsable_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','Codctacte':'" + $('#hfCodCtaCteEdicion').val() + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                         label: item.split(',')[2],
                            Nombre: item.split(',')[1],
                            RUC: item.split(',')[0]
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
            $('#MainContent_txtResponsableDNI1Edicion').val(i.item.RUC);
            $('#MainContent_txtResponsable1Edicion').val(i.item.Nombre);
        }, 
        complete: function () {
//            $('#MainContent_txtConductorDNI').val($('#hfDniConductor').val());
//            $('#MainContent_txtConductorRazonSocial').focus();
        },
        minLength: 3
    });

      //responsable
       
  $('#MainContent_txtResponsable2Edicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarResponsable_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','Codctacte':'" + $('#hfCodCtaCteEdicion').val() + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                         label: item.split(',')[2],
                            Nombre: item.split(',')[1],
                            RUC: item.split(',')[0]
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
            $('#MainContent_txtResponsableDNI2Edicion').val(i.item.RUC);
            $('#MainContent_txtResponsable2Edicion').val(i.item.Nombre);
        }, 
        complete: function () {
//            $('#MainContent_txtConductorDNI').val($('#hfDniConductor').val());
//            $('#MainContent_txtConductorRazonSocial').focus();
        },
        minLength: 3
    });

    $('#MainContent_txtTransportista').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'2','CodTipoCliente':'2'}",
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
            $('#hfCodTransportista').val(i.item.val);
        },
        minLength: 3
    });


    $('#MainContent_txtDireccionTransportista').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCDireccion_ListarXCodTransportista_AutoComplete',
                data: "{ 'Direccion': '" + request.term + "', 'CodCtaCte': '" + $('#hfCodTransportista').val() + "'}",
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
            $('#hfCodDireccionTransportista').val(i.item.val);
        },
        minLength: 3
    });
    

    $('#MainContent_txtTransportistaEdicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'2','CodTipoCliente':'2'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2],
                            
                            CodDireccion: item.split(',')[12],
                            Distrito: item.split(',')[4]
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
            $('#hfCodTransportistaEdicion').val(i.item.val);
            $('#MainContent_txtDireccionTransportistaEdicion').val(i.item.Direccion +' - ' +i.item.Distrito );
            $('#hfCodDireccionTransportistaEdicion').val(i.item.CodDireccion);
        },
        minLength: 3
    });
    

    $('#MainContent_txtDireccionTransportista').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCDireccion_ListarXCodTransportista_AutoComplete',
                data: "{ 'Direccion': '" + request.term + "', 'CodCtaCte': '" + $('#hfCodTransportista').val() + "'}",
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
            $('#hfCodDireccionTransportista').val(i.item.val);
        },
        minLength: 3
    });



    
    $('#MainContent_txtDireccionTransportistaEdicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCDireccion_ListarXCodTransportista_AutoComplete',
                data: "{ 'Direccion': '" + request.term + "', 'CodCtaCte': '" + $('#hfCodTransportistaEdicion').val() + "'}",
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
            $('#hfCodDireccionTransportistaEdicion').val(i.item.val);
            $('#hfDireccionTransportista').val(i.item.label);
        },
        minLength: 3
    });


    $('#MainContent_txtPlaca').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCte').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
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
            $('#MainContent_txtPlaca').val(i.item.label);
        },
        minLength: 1
    });

        $('#MainContent_txtPlaca2').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCte').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
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
            $('#MainContent_txtPlaca2').val(i.item.label);
        },
        minLength: 1
    });

        $('#MainContent_txtPlaca3').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCte').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
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
            $('#MainContent_txtPlaca3').val(i.item.label);
        },
        minLength: 1
    });

        $('#MainContent_txtPlaca4').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCte').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
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
            $('#MainContent_txtPlaca4').val(i.item.label);
        },
        minLength: 1
    });

  $('#MainContent_txtPlaca5').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCte').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
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
            $('#MainContent_txtPlaca5').val(i.item.label);
        },
        minLength: 1
    });

      $('#MainContent_txtPlaca6').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCte').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
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
            $('#MainContent_txtPlaca6').val(i.item.label);
        },
        minLength: 1
    });

      $('#MainContent_txtPlaca7').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCte').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
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
            $('#MainContent_txtPlaca7').val(i.item.label);
        },
        minLength: 1
    });

      $('#MainContent_txtPlaca8').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCte').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
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
            $('#MainContent_txtPlaca8').val(i.item.label);
        },
        minLength: 1
    });

    $('#MainContent_txtPlacaNV').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodClienteNV').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
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
            $('#MainContent_txtPlacaNV').val(i.item.label);
        },
        minLength: 1
    });

    $('#MainContent_txtPlacaConsulta').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCteEdicion').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
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
            $('#MainContent_txtPlacaConsulta').val(i.item.label);
        },
        minLength: 1
    });


    $('#MainContent_txtPlaca1Edicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCteEdicion').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
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
            $('#MainContent_txtPlaca1Edicion').val(i.item.label);
        },
        minLength: 1
    });


    $('#MainContent_txtPlaca2Edicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCteEdicion').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
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
            $('#MainContent_txtPlaca2Edicion').val(i.item.label);
        },
        minLength: 1
    });

    $('#MainContent_txtPlaca3Edicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCteEdicion').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
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
            $('#MainContent_txtPlaca3Edicion').val(i.item.label);
        },
        minLength: 1
    });

    $('#MainContent_txtPlaca4Edicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCteEdicion').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
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
            $('#MainContent_txtPlaca4Edicion').val(i.item.label);
        },
        minLength: 1
    });

     $('#MainContent_txtPlaca5Edicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCte').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
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
            $('#MainContent_txtPlaca5Edicion').val(i.item.label);
        },
        minLength: 1
    });

      $('#MainContent_txtPlaca6Edicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCte').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
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
            $('#MainContent_txtPlaca6Edicion').val(i.item.label);
        },
        minLength: 1
    });

      $('#MainContent_txtPlaca7Edicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCte').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
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
            $('#MainContent_txtPlaca7Edicion').val(i.item.label);
        },
        minLength: 1
    });

      $('#MainContent_txtPlaca8Edicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCte').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
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
            $('#MainContent_txtPlaca8Edicion').val(i.item.label);
        },
        minLength: 1
    });

    $("#MainContent_txtDistrito").bind("propertychange change keyup paste input", function(){
        if ($("#MainContent_txtDistrito").val() != $("#hfDistrito").val() & $("#hfCodDistrito").val() != '0')
        {
            $("#MainContent_txtDistrito").val('');
            $("#hfDistrito").val('');
            $("#hfCodDistrito").val('0');
            $("#MainContent_txtDireccion").val('');
            $("#hfCodDireccion").val('0');
            $("#hfDireccion").val('');
        }
            var Index= $('#MainContent_txtNroRuc').val().indexOf('-');
            var Cliente = $('#MainContent_txtNroRuc').val();

            if ( Index ==-1 ) {} else {
            $('#MainContent_txtNroRuc').val(Cliente.split('-')[0].trim());
            $('#hfCliente').val($('#MainContent_txtNroRuc').val());
            }
    });

    $("#MainContent_txtNroRuc").bind("propertychange change keyup paste input", function(){


            var Index= $('#MainContent_txtNroRuc').val().indexOf('-');
            var Cliente = $('#MainContent_txtNroRuc').val();
            var NroRuc = '';
            if ( Index ==-1 ) {} else {
            NroRuc = Cliente.split('-')[0].trim();
            }


        if (NroRuc != $("#hfNroRuc").val() & $("#hfCodCtaCte").val() != '0')
        {
            var nroruc = $("#MainContent_txtNroRuc").val();
            F_LimpiarCampos();

            $("#MainContent_txtEdicionMail_Email1").val('');
            $("#MainContent_txtEdicionMail_Email2").val('');
            $("#MainContent_txtEdicionMail_Email3").val('');
            $("#MainContent_txtEdicionMail_Email4").val('');
            $("#MainContent_txtEdicionMail_Email5").val('');
            $("#MainContent_txtEdicionMail_Email6").val('');
            F_InicializarCorreos();
            $("#MainContent_txtNroRuc").val(nroruc);
            $("#MainContent_txtNroRuc").focus();
        }
    });

    $("#MainContent_txtCliente").bind("propertychange change keyup paste input", function(){
        if ($("#MainContent_txtCliente").val() != $("#hfCliente").val() & $("#hfCodCtaCte").val() != '0')
        {
            if ($("#MainContent_txtNroRuc").val() != '11111111')
            {
                alertify.log('NO SE PUEDE MODIFICAR CLIENTES REGISTRADOS');
                $("#MainContent_txtCliente").val($("#hfCliente").val());
                return true;
            }
        }
    });

    $("#MainContent_txtDireccion").bind("propertychange change keyup paste input", function(){
        if ($("#MainContent_txtDireccion").val().trim() != $("#MainContent_ddlDireccion option:selected").text().trim() & $("#hfCodDireccion").val() != '0')
        {
            //$("#MainContent_txtDireccion").val('');
            $("#hfCodDireccion").val('0');
            
        }

            var Index= $('#MainContent_txtNroRuc').val().indexOf('-');
            var Cliente = $('#MainContent_txtNroRuc').val();

            if ( Index ==-1 ) {} else {
            $('#MainContent_txtNroRuc').val(Cliente.split('-')[0].trim());
            $('#hfCliente').val($('#MainContent_txtNroRuc').val());
            }
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

      $( "#accordion" ).accordion({
        collapsible: true,
        active: false
     });
    
    $("#MainContent_chkGuia").click(function () {
        if ($(this).is(':checked')) 
        {
////            $('#MainContent_txtDestino').val($("#MainContent_txtDireccion").val().trim() + ' ' + $('#MainContent_txtDistrito').val().trim());
//            $('#MainContent_txtNumeroGuia').prop('readonly', false);
//            $('#MainContent_txtDestino').prop('readonly', false);
//            $('#MainContent_txtFechaTraslado').prop('readonly', false);  
   BloqueoTipoTransportista($(Cuerpo + 'ddlSerieGuia option:selected').text(),(Cuerpo + 'txtNumeroGuia'),(Cuerpo + 'txtFechaTraslado')
                 ,(Cuerpo + 'ddldireccionNuevaDestino'),(Cuerpo + 'txtTransportista'),(Cuerpo + 'txtNroRucTransportista')                 
                 ,(Cuerpo + 'txtPlacaTraslado'),(Cuerpo + 'txtLicenciaGuia'),(Cuerpo + 'txtNuBultos'),(Cuerpo + 'txtPeso')
                 ,(Cuerpo + 'txtConductorRazonSocial'),(Cuerpo + 'txtConductorDNI'),$(Cuerpo + 'ddlTipoTransportista').val()
                 ,(Cuerpo + 'ddldireccionNuevaTransportista')
                 ,$('hfCodConductor').val(),(Cuerpo + 'txtMarcaGuia'),'#MainContent_ImageButton1','#MainContent_ImageButton2','#MainContent_chkGuia','#hfCodTransportista');

                  $('#MainContent_txtNuBultos').prop("disabled", false);
                  $('#MainContent_txtPeso').prop("disabled", false);
                  $('#MainContent_txtDestino').val($.trim($("#MainContent_txtDireccion").val())+ ' ' + $.trim($('#MainContent_txtDistrito').val()));
                  $('#MainContent_txtNumeroGuia').prop('readonly', false);
                  $('#MainContent_txtDestino').prop('readonly', false);
                  $('#MainContent_txtFechaTraslado').prop('readonly', false);  
                  $('#MainContent_txtObservacionGuia').prop('disabled', false); 
            F_Mostrar_Correlativo(10);
            //habilitado
//            $('#MainContent_txtNroRucTransportista').prop("disabled", false);
//            $('#MainContent_txtTransportista').prop("disabled", false);
//            $('#MainContent_txtDistritoTransportista').prop("disabled", false);
//            $('#MainContent_txtDireccionTransportista').prop("disabled", false);
//            $('#MainContent_txtPlacaTraslado').prop("disabled", false);
//            $('#MainContent_txtMarcaGuia').prop("disabled", false);
//            $('#MainContent_txtLicenciaGuia').prop("disabled", false);
//            $('#MainContent_txtNuBultos').prop("disabled", false);
//            $('#MainContent_txtPeso').prop("disabled", false);
//            $('#MainContent_txtConductorDNI').prop("disabled", false);
//            $('#MainContent_txtConductorRazonSocial').prop("disabled", false);
            F_CambioTransportista();
        }            
        else
        {
            //            $('#MainContent_txtDestino').val('') ;
//            $('#MainContent_txtNumeroGuia').val('');
////            $('#MainContent_txtDestino').val('');
//            $('#MainContent_txtNroRucTransportista').val('');
//            $('#MainContent_txtTransportista').val('');
//            $('#MainContent_txtDistritoTransportista').val('');
//            $('#MainContent_txtDireccionTransportista').val('');
//            $('#MainContent_txtPlacaTraslado').val('');
//            $('#MainContent_txtMarcaGuia').val('');
//            $('#MainContent_txtLicenciaGuia').val('');
//            $('#MainContent_txtNuBultos').val('');
//            $('#MainContent_txtPeso').val('');
//            $('#MainContent_txtConductorDNI').val('');
//            $('#MainContent_txtConductorRazonSocial').val('');
//            //desabilitado
//            $('#MainContent_txtNroRucTransportista').prop("disabled", true);
//            $('#MainContent_txtTransportista').prop("disabled", true);
//            $('#MainContent_txtDistritoTransportista').prop("disabled", true);
//            $('#MainContent_txtDireccionTransportista').prop("disabled", true);
//            $('#MainContent_txtPlacaTraslado').prop("disabled", true);
//            $('#MainContent_txtMarcaGuia').prop("disabled", true);
//            $('#MainContent_txtLicenciaGuia').prop("disabled", true);
//            $('#MainContent_txtNuBultos').prop("disabled", true);
//            $('#MainContent_txtPeso').prop("disabled", true);
//            $('#MainContent_txtConductorDNI').prop("disabled", true);
//            $('#MainContent_txtConductorRazonSocial').prop("disabled", true);

//            $('#MainContent_txtNumeroGuia').prop('readonly', true);
//            $('#MainContent_txtDestino').prop('readonly', true);
//            $('#MainContent_txtFechaTraslado').prop('readonly', true);
//            F_CambioTransportista();
 F_Limpiar_Controles_Guia();
        }       
    });
    
//    $("#MainContent_chkGuiaEdicion").click(function () {
//        if ($(this).is(':checked')) {
//            F_Mostrar_Correlativo(10, 'Edicion');
//            if ($('#MainContent_txtDestinoEdicion').val() == '') $('#MainContent_txtDestinoEdicion').val($('#hfDireccionFacturaEditar').val());
//                $('#MainContent_txtFechaTrasladoEdicion').val($('#MainContent_txtEmisionEdicion').val())
//                
//            $('#MainContent_txtNroRucTransportistaEdicion').prop('readonly', false);        
//            $('#MainContent_ddlSerieGuia').prop('readonly', false);
//            $('#MainContent_txtNumeroGuiaEdicion').prop('readonly', false);
//            $('#MainContent_txtNroRucTransportistaEdicion').prop('readonly', false);
//            $('#MainContent_txtTransportistaEdicion').prop('readonly', false);
//            $('#MainContent_txtDireccionTransportistaEdicion').prop('readonly', false);
//            $('#MainContent_txtNuBultosEdicion').prop('readonly', false);
//            $('#MainContent_txtDestinoEdicion').prop('readonly', false);
//            $('#MainContent_txtDistritoTransportistaEdicion').prop('readonly', false);
//            $('#MainContent_txtPlacaTrasladoEdicion').prop('readonly', false);
//            $('#MainContent_txtMarcaGuiaEdicion').prop('readonly', false);
//            $('#MainContent_txtLicenciaGuiaEdicion').prop('readonly', false);
//            $('#MainContent_txtDestinoEdicion').val($('#hfDestinoEdicion').val());
//            F_CambioTransportistaEdicion();
//        }
//        else {
//            $('#MainContent_txtNumeroGuiaEdicion').val('');
//          //  $('#MainContent_txtDestinoEdicion').val('');

//            $('#hfCodTransportista').val('0');
//            $('#MainContent_txtTransportistaEdicion').val('');
//            $('#hfCodDireccionTransportistaEdicion').val('0');
//            $('#MainContent_txtDireccionTransportistaEdicion').val('');
//            $('#hfDireccionTransportistaEdicion').val('');
//            $('#MainContent_txtDireccionTransportistaEdicion').val('');
//            $('#MainContent_txtPlacaTrasladoEdicion').val('');
//            $('#MainContent_txtMarcaGuiaEdicion').val('');
//            $('#MainContent_txtLicenciaGuiaEdicion').val('');
//            $('#MainContent_txtNuBultosEdicion').val('');
//            $('#MainContent_txtPesoEdicion').val('');
//            $('#MainContent_ddlSerieGuia').prop('readonly', true);
//            $('#MainContent_txtNumeroGuiaEdicion').prop('readonly', true);
//            $('#MainContent_txtNroRucTransportistaEdicion').prop('readonly', true);
//            $('#MainContent_txtTransportistaEdicion').prop('readonly', true);
//            $('#MainContent_txtDireccionTransportistaEdicion').prop('readonly', true);
//            $('#MainContent_txtNuBultosEdicion').prop('readonly', true);
//            $('#MainContent_txtDestinoEdicion').prop('readonly', true);
//            $('#MainContent_txtDistritoTransportistaEdicion').prop('readonly', true);
//            $('#MainContent_txtPlacaTrasladoEdicion').prop('readonly', false);
//            $('#MainContent_txtMarcaGuiaEdicion').prop('readonly', false);
//            $('#MainContent_txtLicenciaGuiaEdicion').prop('readonly', false);
//            $('#MainContent_txtConductorDNIEdicion').prop('readonly', false);
//            $('#MainContent_txtConductorRazonSocialEdicion').prop('readonly', false);
//            F_CambioTransportistaEdicion();
//        }
//    });

    $("#MainContent_chkGuiaEdicion").click(function () {
        if ($(this).is(':checked')) {

             BloqueoTipoTransportista($(Cuerpo + 'ddlSerieGuiaEdicion option:selected').text(),(Cuerpo + 'txtNumeroGuiaEdicion'),(Cuerpo + 'txtFechaTrasladoEdicion')
                 ,(Cuerpo + 'ddldireccionNuevaDestinoEdicion'),
                 (Cuerpo + 'txtTransportistaEdicion'),(Cuerpo + 'txtNroRucTransportistaEdicion')
                 ,(Cuerpo + 'txtPlacaTrasladoEdicion'),(Cuerpo + 'txtLicenciaGuiaEdicion')
                 ,(Cuerpo + 'txtNuBultosEdicion'),(Cuerpo + 'txtPesoEdicion'),
                 (Cuerpo + 'txtConductorRazonSocialEdicion')
                 ,(Cuerpo + 'txtConductorDNIEdicion')
                 ,$(Cuerpo + 'ddlTipoTransportistaEdicion').val(),(Cuerpo + 'ddldireccionNuevaTransportistaEdicion')
                 ,$('hfCodConductor').val(),(Cuerpo + 'txtMarcaGuiaEdicion')
                 ,'#MainContent_ImageButton3','#MainContent_ImageButton4','#MainContent_chkGuiaEdicion');

                    $('#MainContent_txtNuBultosEdicion').prop("disabled", false);
                  $('#MainContent_txtPesoEdicion').prop("disabled", false);
                  $('#MainContent_txtNumeroGuiaEdicion').prop('disabled', false);
                  $('#MainContent_ddldireccionNuevaDestinoEdicion').prop('disabled', false);
                  $('#MainContent_txtFechaTrasladoEdicion').prop('disabled', false);  
                  $('#MainContent_txtObservacionGuiaEdicion').prop('disabled', false); 

            F_Mostrar_Correlativo(10, 'Edicion');
            if ($('#MainContent_txtDestinoEdicion').val() == '') $('#MainContent_txtDestinoEdicion').val($('#hfDireccionFacturaEditar').val());
                $('#MainContent_txtFechaTrasladoEdicion').val($('#MainContent_txtEmisionEdicion').val())

//                $('#MainContent_chkImpresionGuiaEdicion').prop('checked',true);  
        }
        else {

         BloqueoTipoTransportista($(Cuerpo + 'ddlSerieGuiaEdicion option:selected').text(),(Cuerpo + 'txtNumeroGuiaEdicion'),(Cuerpo + 'txtFechaTrasladoEdicion')
                 ,(Cuerpo + 'ddldireccionNuevaDestinoEdicion'),
                 (Cuerpo + 'txtTransportistaEdicion'),(Cuerpo + 'txtNroRucTransportistaEdicion')
                 ,(Cuerpo + 'txtPlacaTrasladoEdicion'),(Cuerpo + 'txtLicenciaGuiaEdicion')
                 ,(Cuerpo + 'txtNuBultosEdicion'),(Cuerpo + 'txtPesoEdicion'),
                 (Cuerpo + 'txtConductorRazonSocialEdicion')
                 ,(Cuerpo + 'txtConductorDNIEdicion')
                 ,$(Cuerpo + 'ddlTipoTransportistaEdicion').val(),(Cuerpo + 'ddldireccionNuevaTransportistaEdicion')
                 ,$('hfCodConductor').val(),(Cuerpo + 'txtMarcaGuiaEdicion')
                 ,'#MainContent_ImageButton3','#MainContent_ImageButton4','#MainContent_chkGuiaEdicion');

            $('#MainContent_txtNumeroGuiaEdicion').val('');
            $('#MainContent_txtDestinoEdicion').val('');
            $('#hfCodTransportistaEdicion').val('0') 
            $('#hfCodTransportista').val('0');
            $('#MainContent_txtTransportistaEdicion').val('');
            $('#hfCodDireccionTransportista').val('0');
            $('#MainContent_txtDireccionTransportistaEdicion').val('');
            $('#hfDireccionTransportista').val('');
            $('#MainContent_txtPlacaTrasladoEdicion').val('');
            $('#MainContent_txtMarcaGuiaEdicion').val('');
            $('#MainContent_txtLicenciaGuiaEdicion').val('');
            $('#MainContent_txtNuBultosEdicion').val('');
            $('#MainContent_txtPesoEdicion').val('');
            $('#MainContent_txtConductorDNIEdicion').val('');
            $('#MainContent_txtConductorRazonSocialEdicion').val('');
            $('#MainContent_txtDistritoTransportistaEdicion').val('');
            $('#hfCodConductor').val('');
            $('#hfDniConductor').val('');
            $('#hfNombreConductor').val('');
//             $('#MainContent_chkImpresionGuiaEdicion').prop('checked',false); 
            $('#MainContent_ImageButton3').prop("disabled", true);  
            $('#MainContent_ImageButton4').prop("disabled", true);  
            $('#MainContent_ddldireccionNuevaTransportistaEdicion').empty();

        }
    });
    
    $("#MainContent_chkNotaVenta").click(function () {
        if ($(this).is(':checked')) {

        }
        else {
            $('#MainContent_txtNumeroNotaVenta').val('');
		}
    });

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
                $('#MainContent_grvConsultaArticulo_imgAgregar_0').select();
        }
        catch (e) {

            alertify.log("Error Detectado: " + e);
        }


        return false;

    });

    $('#MainContent_btnAgregarProducto').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
    if (F_PermisoOpcion(CodigoMenu, '777005', '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try 
        {

                   $('#MainContent_txtCodigoProductoAgregar').val('');
                  $('#MainContent_txtArticuloAgregar').val('');
                  $('#MainContent_txtStockAgregar').val('');
                  $('#MainContent_txtUMAgregar').val('');
                  $('#MainContent_txtPrecioDisplay').val('');
                  $('#MainContent_txtDsct').val('');
                  $('#MainContent_txtCantidad').val('');
                  $('#hfCodProductoAgregar').val('0');
                  $('#hfCostoAgregar').val('0');
                  $('#hfCodUmAgregar').val('0');

                  $('#hfPrecioSoles').val('0');
                  $('#hfPrecioDolares').val('0');
                  $('#hfCostoSoles').val('0');
                  $('#hfCostoDolares').val('0');
                  $('#hfMargen').val('0');
                  $('#hfRedondeo').val('0');
                  $('#hfFactorRedondeo').val('0');
                  $('#hfDescuento').val('0');
               
                $('#MainContent_txtArticulo').val('');
                $('#MainContent_chkServicios').prop('checked',false);
                $('#MainContent_chkNotaPedido').prop('checked',false);

                 if ($('#hfCodtipodoctemporal').val() === "22")
                 {
                  alertify.log("NO SE PUEDE AGREGAR PRODUCTO SI VIENEN DE UNA PROFORMA");
                  return false;
                 }
                 

                var Moneda = 'S/ ';
                if ($('#MainContent_ddlMoneda').val() === "2")
                    Moneda = '$ ';

                $('#MainContent_txtTotal2').val(Moneda + $('#MainContent_txtTotal').val());

                $("#divConsultaArticulo").dialog({
                    resizable: false,
                    modal: true,
                    title: "Consulta de Productos",
                    title_html: true,
                    height: 600,
                    width: 1250,
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
                    
                        $('#lblCantidadProducto').text(F_Numerar_Grilla("grvConsultaArticulo",'hlkCodigo'));       
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
    
    $('#MainContent_btnAplicarDescuento').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
    if (F_PermisoOpcion(CodigoMenu, '777008', '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try 
        {
            //valida que el descuento sea valido
            if ($.isNumeric($('#MainContent_txtDescuento').val()))
            {
                var Dcto = $('#MainContent_txtDescuento').val();
                if (Dcto >= 0 & Dcto < 100)
                {
                    //$('#MainContent_txtDescuento').val('0.00');
                    $('#MainContent_grvDetalleArticulo :checkbox').each(function () {
                        chkSi = this.id;
                        F_ActualizarPrecio(chkSi.replace('chkEliminar','txtPrecio'), Dcto);
                    });
                }
                else
                {
                    alertify.log('AGREGE UN PORCENTAJE DE DESCUENTO VALIDO');
                    $('#MainContent_txtDescuento').val('0.00');
                    $('#MainContent_txtDescuento').focus();
                }
            }
            else
            {
                alertify.log('INGRESE UN PORCENTAJE DE DESCUENTO VALIDO');
                $('#MainContent_txtDescuento').val('0.00');
                $('#MainContent_txtDescuento').focus();
            }
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
        if (!F_ValidarAgregar())
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

    $('#MainContent_btnEditarFactura').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
     try 
        {
        
             if(!F_ValidarGrabarEdicionDocumento())
              return false;

        if (confirm("ESTA SEGURO DE ACTUALIZAR EL DOCUMENTO"))
        F_GuardarCambiosFactura();
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

    $('#MainContent_btnNotaVenta').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, '777006', '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        if ($('#MainContent_ddlTipoDoc').val() == '16' | $('#MainContent_ddlTipoDoc').val() == '22' | $('#MainContent_ddlTipoDoc').val() == '2')
        return false;

        $('#MainContent_txtDesdeNV').val(Date_AddDays($('#MainContent_txtHastaNV').val(), -15));
        F_AbrirPanelNV();
        $('#MainContent_btnNotaVenta').focus();
        return false;
    });

    $('#MainContent_btnBuscarNV').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        F_FacturacionNV($('#MainContent_txtDesdeNV').val(), $('#MainContent_txtHastaNV').val());
        return false;
    });

    $('#MainContent_btnAgregarItemNV').click(function () {
            if (!F_SesionRedireccionar(AppSession)) return false;
        try {
//            if (!F_ValidarAgregarNV())
//                return false;

            F_AgregarNP();
            $('#MainContent_chkConIgvMaestro').prop('disabled',true);
            $('#MainContent_chkSinIgvMaestro').prop('disabled',true);
        }
        catch (e) {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnDescargarCDR').click(function () {
        try {
            F_DescargarArchivosPDF();
            F_DescargarArchivosXML();
            F_DescargarArchivosCDR();
        }
        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

        return false;

    });

     $('#MainContent_btnAnular').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if ($.trim($('#MainContent_txtObservacionAnulacion').val()).length<10)
            {
             alertify.log("INGRESAR LA OBSERVACION  (MINIMO 10 CARACTERES)");
              return false;
            }
            F_AnularRegistro();
            return false;
        }
        catch (e) {
            alertify.log("Error Detectado: " + e);
        }
    });

    //eSTO REENVIARA A COTIZACION --NO NP--
    $('#MainContent_btnReenvioMailNP').click(function () {
            if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (confirm("ESTA SEGURO DE ACTUALIZAR EL DOCUMENTO"))
            F_ReenvioMailNP_Enviar();
        }
        catch (e) {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
        }
    });    

    $('#MainContent_btnCotizacion').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, '777007', '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        if ($('#MainContent_ddlTipoDoc').val() == '15' | $('#MainContent_ddlTipoDoc').val() == '16')
        return false;
        $('#MainContent_txtDesdeCT').val(Date_AddDays($('#MainContent_txtHastaCT').val(), -15));
        F_AbrirPanelCT();
        $('#MainContent_btnCotizacion').focus();
        return false;
    });

    $('#MainContent_btnBuscarCT').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        F_FacturacionCT($('#MainContent_txtDesdeCT').val(), $('#MainContent_txtHastaCT').val());
        return false;
    });

    $('#MainContent_btnAgregarItemCT').click(function () {
            if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (!F_ValidarAgregarCT())
                return false;

            F_AgregarTemporalCT();
            $('#MainContent_chkConIgvMaestro').prop('disabled',true);
            $('#MainContent_chkSinIgvMaestro').prop('disabled',true);
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
            if(!F_ValidarEliminar())
              return false;

            if (confirm("ESTA SEGURO DE ELIMINAR LOS PRODUCTOS SELECCIONADOS"))
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
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

     try 
        {
            if(!F_ValidarGrabarDocumento())
              return false;

            if (confirm("ESTA SEGURO DE GRABAR LA " + $("#MainContent_ddlTipoDoc option:selected").text().toUpperCase()))
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
        
    $('#MainContent_btnActualizar').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
     try 
        {
          
          F_ActualizarDetalle();
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

    $('#MainContent_btnImpresionPedidos').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_ImpresionPedidos();
        }
        catch (e) {
            alertify.log("Error Detectado: " + e);
        }
        return false;
    });

    $('#MainContent_btnImprimirPedidos').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_ImpresionPedidos();
            $('#div_ImpresorasNotaPedido').dialog('close');
        }
        catch (e) {
            alertify.log("Error Detectado: " + e);
        }
        return false;
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

    $('#MainContent_btnFacturarCotizacion').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_AgregarTemporalCTxNumero();
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

    $('#MainContent_btnEdicionEmails').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try {

        if ($('#MainContent_txtNroRuc').val() === '11111111' | $('#MainContent_txtNroRuc').val() === '11111111111') {
            alertify.log('NO SE PUEDE ENVIAR CORREOS A CLIENTE VARIOS');
            F_InicializarCorreos();
            return false;
        }
        

        $("#div_CorreosEdicion").dialog({
            resizable: false,
            modal: true,
            title: "ACTUALIZAR DIRECCION DEL CLIENTE",
            title_html: true,
            height: 350,
            width: 550,
            autoOpen: false
        });

        if ($('#MainContent_ddlTipoDoc').val() != '16'){
            $('#MainContent_txtEdicionMail_Cliente').val($('#MainContent_txtCliente').val());
            $('#MainContent_txtEdicionMail_Distrito').val($('#MainContent_txtDistrito').val());
            $('#MainContent_txtEdicionMail_Direccion').val($('#MainContent_txtDireccion').val());
        } else {
            $('#MainContent_txtEdicionMail_Cliente').val('*** RESPONSABLE: ' + $('#MainContent_ddlResponsableNP option:selected').text() + ' ***');
            $('#MainContent_txtEdicionMail_Distrito').val('');
            $('#MainContent_txtEdicionMail_Direccion').val('');        
        }

        $('#div_CorreosEdicion').dialog('open');

          return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnActualizarEmails').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try {

            F_ActualizarCorreos();

          return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnHacerReenvio').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        try {

            F_HacerReenvio();

          return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $("#MainContent_txtDistritoTransportista").bind("propertychange change keyup paste input", function(){
        if ($("#MainContent_txtDistritoTransportista").val() != $("#hfDistritoTransportista").val() & $("#hfCodDistritoTransportista").val() != '0')
        {
            $("#MainContent_txtDistritoTransportista").val('');
            $("#hfDistritoTransportista").val('');
            $("#hfCodDistritoTransportista").val('0');
            $("#MainContent_txtDireccionTransportista").val('');
            $("#hfCodDireccionTransportista").val('0');
            $("#hfDireccionTransportista").val('');
        }
            var Index= $('#MainContent_txtNroRucTransportista').val().indexOf('-');
            var Cliente = $('#MainContent_txtNroRucTransportista').val();

            if ( Index ==-1 ) {} else {
                if ($("#MainContent_txtClienteTransportista").val() === '---NUEVO CLIENTE---')
                return true;
            $('#MainContent_txtNroRucTransportista').val(Cliente.split('-')[0].trim());
            $('#hfClienteTransportista').val($('#MainContent_txtNroRucTransportista').val());
            }
    });
    
    $("#MainContent_txtNroRucTransportista").bind("propertychange change keyup paste input", function(){
        if ($("#MainContent_txtNroRucTransportista").val() != $("#hfNroRucTransportista").val() & $("#hfCodCtaCteTransportista").val() != '0')
        {
            var Index= $('#MainContent_txtNroRucTransportista').val().indexOf('-');
            var Cliente = $('#MainContent_txtNroRucTransportista').val();

            if ( Index ==-1 ) {} else {
                if (Cliente.split('-')[0].trim() === "55555555555")
                return true;}

                if ((Index==9 || Index == 12) && $('#hfFlagRuc').val()=="1")
                return false;

                var nroruc = $("#MainContent_txtNroRucTransportista").val();
//                F_LimpiarCamposTransportista();
                $("#MainContent_txtNroRucTransportista").val(nroruc);
                $("#MainContent_txtNroRucTransportista").focus();
        }
    });

     $('#MainContent_btnCotizacion').click(function () {
    if (F_PermisoOpcion(CodigoMenu, 4000201, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        if (!($('#MainContent_ddlTipoDoc').val()=="1" | $('#MainContent_ddlTipoDoc').val()=="2")) return false;
        

        $('#MainContent_txtCodCotizacion').val('');
        $('#MainContent_txtCodCotizacion').select();
        return false;
    });

       $('#MainContent_btnFacturar').click(function () {
//    if (F_PermisoOpcion(CodigoMenu, 4000201, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
//        if (!($('#MainContent_ddlTipoDoc').val()=="1" | $('#MainContent_ddlTipoDoc').val()=="2")) return false;
        

        F_FacturarVale();
        Resultado=true;
        return false;
    });

        $('#MainContent_btnGrabarDireccion').click(function () {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (!F_ValidarGrabarDireccion())
                return false;
                var ddldireccion='';
                var hfCodCtacte='';
                var ddldireccionDestino='';
                var hfCodigoTemporal='';
                var FlagTraslado=0;
             
                switch(Ventana) {
                case 1:
                    ddldireccion='#MainContent_ddldireccionNueva';
                    hfCodCtacte='#hfCodCtaCte';
                    ddldireccionDestino='#MainContent_ddldireccionNuevaDestino';
                 hfCodigoTemporal='#hfCodigoTemporal';
                    FlagTraslado=0;
                break;
                case 2:
                    ddldireccion='#MainContent_ddldireccionNuevaDestino';
                    hfCodCtacte='#hfCodCtaCte';
                    ddldireccionDestino='';
                 hfCodigoTemporal='#hfCodigoTemporal';
                    FlagTraslado=0;
                break;
                 case 3:
                      ddldireccion='#MainContent_ddldireccionNuevaTransportista';
                    hfCodCtacte='#hfCodTransportista';
                    ddldireccionDestino='';
                 hfCodigoTemporal='#hfCodigoTemporal';
                    FlagTraslado=1;
                break;
                 case 4:
                    ddldireccion='';
                    hfCodCtacte='#hfCodCtaCteEdicion';
                    ddldireccionDestino='#MainContent_ddldireccionNuevaDestinoEdicion';
                 hfCodigoTemporal='#hfCodigoTemporalEdicion';
                    FlagTraslado=0;
                break;
                default:
                     ddldireccion='#MainContent_ddldireccionNuevaTransportistaEdicion';
                 hfCodigoTemporal='#hfCodigoTemporalEdicion';
                    hfCodCtacte='#hfCodTransportistaEdicion';
                    ddldireccionDestino='';
                    FlagTraslado=1;
                break;          
                }
            if (confirm("ESTA SEGURO DE GRABAR LA DIRECCION"))
                F_GrabarDireccion(hfCodigoTemporal,'#hfDepartamento','#hfProvincia','#hfDistrito','#MainContent_txtDireccionMultiple','#MainContent_txtEmailMultiple1',
                '#MainContent_txtEmailMultiple2',hfCodCtacte,ddldireccion,'#hfCodDireccionTemporal','#MainContent_txtDistritoMultiple',ddldireccionDestino,FlagTraslado,
                '#hfNroRuc','#MainContent_txtProveedor');


 
    
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

    $('#MainContent_txtEmisionEdicion').on('change', function (e) {
        F_FormaPagoEdicion($("#MainContent_ddlFormaPagoEdicion").val());
    });

    $("#MainContent_txtNumero").ForceNumericOnly();

    $("#MainContent_txtNumeroConsulta").ForceNumericOnly();

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
        var n = 7; 
        if ($("#MainContent_ddlSerie option:selected").text().substr(0, 1) == 'F' || $("#MainContent_ddlSerie option:selected").text().substr(0, 1) == 'B') n = 8;
        var id = '00000000' + $('#MainContent_txtNumero').val();
        $('#MainContent_txtNumero').val(id.substr(id.length - n));
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
    
    $("#MainContent_chkClienteCT").change(function () {
        if (this.checked) {
        }
        else {
            $('#MainContent_txtClienteCT').val('');
            $('#hfCodClienteCT').val(0);
        }
    });

    $("#MainContent_chkClienteNV").change(function () {
        if (this.checked) {
        }
        else {
            $('#MainContent_txtClienteNV').val('');
            $('#hfCodClienteNV').val(0);
        }
    });

    $("#MainContent_chkPlacaNV").change(function () {
        if (this.checked) {
        }
        else {
            $('#MainContent_txtPlacaNV').val('');
        }
    });

    $("#MainContent_chkPlacaConsulta").change(function () {
        if (this.checked) {
        }
        else {
            $('#MainContent_txtPlacaConsulta').val('');
        }
    });
    
    $("#MainContent_chkCliente").change(function () {
        if (this.checked) {
        }
        else {
            $('#MainContent_txtClienteConsulta').val('');
        }
    });

    $("#MainContent_chkImpresionTicket").change(function () {
        if (this.checked) 
          $('#MainContent_chkImpresion').prop('checked', false);          
    });

     $("#MainContent_chkImpresion").change(function () {
        if (this.checked)           
          $('#MainContent_chkImpresionTicket').prop('checked', false);      
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
    
    $('#MainContent_btnListarCotizaciones').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
    if (F_PermisoOpcion(CodigoMenu, 4000204, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            F_Pedidos();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $("#MainContent_chkGuia").click(function () {
        if ($(this).is(':checked')) 
        {
//            $('#MainContent_txtDestino').val($("#MainContent_txtDireccion").val().trim() + ' ' + $('#MainContent_txtDistrito').val().trim());
//            $('#MainContent_txtNumeroGuia').prop('readonly', false);
//            $('#MainContent_txtDestino').prop('readonly', false);
//            $('#MainContent_txtFechaTraslado').prop('readonly', false);  
//            $('#MainContent_txtNroRucTransportista').prop('readonly', false);  
//            $('#MainContent_txtTransportista').prop('readonly', false);  
//            $('#MainContent_txtDistritoTransportista').prop('readonly', false);  
//            $('#MainContent_txtDireccionTransportista').prop('readonly', false);  
//            $('#MainContent_txtPlacaTraslado').prop('readonly', false);  
//            $('#MainContent_txtMarcaGuia').prop('readonly', false);  
//            $('#MainContent_txtLicenciaGuia').prop('readonly', false);  
//            $('#MainContent_txtNuBultos').prop('readonly', false);  
//            $('#MainContent_txtPeso').prop('readonly', false);  
//            $('#MainContent_txtConductorDNI').prop('readonly', false);  
//            $('#MainContent_txtConductorRazonSocial').prop('readonly', false);  
             BloqueoTipoTransportista($(Cuerpo + 'ddlSerieGuia option:selected').text(),(Cuerpo + 'txtNumeroGuia'),(Cuerpo + 'txtFechaTraslado')
                 ,(Cuerpo + 'ddldireccionNuevaDestino'),(Cuerpo + 'txtTransportista'),(Cuerpo + 'txtNroRucTransportista')                 
                 ,(Cuerpo + 'txtPlacaTraslado'),(Cuerpo + 'txtLicenciaGuia'),(Cuerpo + 'txtNuBultos'),(Cuerpo + 'txtPeso')
                 ,(Cuerpo + 'txtConductorRazonSocial'),(Cuerpo + 'txtConductorDNI'),$(Cuerpo + 'ddlTipoTransportista').val()
                 ,(Cuerpo + 'ddldireccionNuevaTransportista')
                 ,$('hfCodConductor').val(),(Cuerpo + 'txtMarcaGuia'),'#MainContent_ImageButton1','#MainContent_ImageButton2','#MainContent_chkGuia','#hfCodTransportista');

                  $('#MainContent_txtNuBultos').prop("disabled", false);
                  $('#MainContent_txtPeso').prop("disabled", false);
                  $('#MainContent_txtDestino').val($.trim($("#MainContent_txtDireccion").val())+ ' ' + $.trim($('#MainContent_txtDistrito').val()));
                  $('#MainContent_txtNumeroGuia').prop('readonly', false);
                  $('#MainContent_txtDestino').prop('readonly', false);
                  $('#MainContent_txtFechaTraslado').prop('readonly', false);  
                  $('#MainContent_txtObservacionGuia').prop('disabled', false); 
            F_Mostrar_Correlativo(10);
        }            
        else
        {
//            $('#MainContent_txtDestino').val('') ;
//            $('#MainContent_txtNumeroGuia').val('');
//            $('#MainContent_txtDestino').val('');
//            $('#MainContent_txtNumeroGuia').prop('readonly', true);
//            $('#MainContent_txtDestino').prop('readonly', true);
//            $('#MainContent_txtFechaTraslado').prop('readonly', true);  
//            $('#MainContent_txtNroRucTransportista').prop('readonly', true);  
//            $('#MainContent_txtTransportista').prop('readonly', true);  
//            $('#MainContent_txtDistritoTransportista').prop('readonly', true);  
//            $('#MainContent_txtDireccionTransportista').prop('readonly', true);  
//            $('#MainContent_txtPlacaTraslado').prop('readonly', true);  
//            $('#MainContent_txtMarcaGuia').prop('readonly', true);  
//            $('#MainContent_txtLicenciaGuia').prop('readonly', true);  
//            $('#MainContent_txtNuBultos').prop('readonly', true);  
//            $('#MainContent_txtPeso').prop('readonly', true);    
//            $('#MainContent_txtConductorDNI').prop('readonly', true);  
//            $('#MainContent_txtConductorRazonSocial').prop('readonly', true);  
 F_Limpiar_Controles_Guia();
        }       
    });

    F_Inicializar_CajaTexto();

    F_Derecha();
});

function F_FuncionesBotones() {
    var k = new Kibo(); 
      //Botones Principales
    k.down("f1", function () {
        $("#MainContent_btnNuevo").click();
        return false;
    });
    k.down("f2", function () {
        $("#MainContent_btnAgregarProducto").click();
        return false;
    });
    k.down("f3", function () {
        $("#MainContent_btnNotaVenta").click();
        return false;
    });
    k.down("f4", function () {
        $("#MainContent_btnCotizacion").click();
        return false;
    });
    k.down("f5", function () {
        $("#MainContent_btnEliminar").click();
        return false;
    });
    k.down("f6", function () {
        $("#MainContent_btnGrabar").click();
        return false;
    });
    k.down("f11", function () {
        if ($("#MainContent_chkImpresion").prop('checked') === true)
            $("#MainContent_chkImpresion").prop('checked', false);
        else 
            $("#MainContent_chkImpresion").prop('checked', true);

        return false;
    });
    //Botones Principales
//    k.down("f1", function () {
//        $("#MainContent_btnNuevo").click();
//        return false;
//    });
//    k.down("f2", function () {
//        $("#MainContent_btnAgregarProducto").click();
//        return false;
//    });
//    k.down("f3", function () {
//        $("#MainContent_btnNotaVenta").click();
//        return false;
//    });
//    k.down("f4", function () {
//        $("#MainContent_btnCotizacion").click();
//        return false;
//    });
//    k.down("f5", function () {
//        $("#MainContent_btnEliminar").click();
//        return false;
//    });
//    k.down("f6", function () {
//        $("#MainContent_btnGrabar").click();
//        return false;
//    });
    

//    //Teclas de Atajos de Cotizaciones
//    k.down("shift 1", function () {
//        F_AgregarTemporalCTxID($("#COTIZACION_CODPROFORMA_" + 1).val(), 1);
//        return false;
//    });

//    k.down("shift 2", function () {
//        F_AgregarTemporalCTxID($("#COTIZACION_CODPROFORMA_" + 2).val(), 2);
//        return false;
//    });

//    k.down("shift 3", function () {
//        F_AgregarTemporalCTxID($("#COTIZACION_CODPROFORMA_" + 3).val(), 3);
//        return false;
//    });

//    k.down("shift 4", function () {
//        F_AgregarTemporalCTxID($("#COTIZACION_CODPROFORMA_" + 4).val(), 4);
//        return false;
//    });

//    k.down("shift 5", function () {
//        F_AgregarTemporalCTxID($("#COTIZACION_CODPROFORMA_" + 5).val(), 5);
//        return false;
//    });

//    k.down("shift 6", function () {
//        F_AgregarTemporalCTxID($("#COTIZACION_CODPROFORMA_" + 6).val(), 6);
//        return false;
//    });

//    k.down("shift 7", function () {
//        F_AgregarTemporalCTxID($("#COTIZACION_CODPROFORMA_" + 7).val(), 7);
//        return false;
//    });

//    k.down("shift 8", function () {
//        F_AgregarTemporalCTxID($("#COTIZACION_CODPROFORMA_" + 8).val(), 8);
//        return false;
//    });

//    k.down("shift 9", function () {
//        F_AgregarTemporalCTxID($("#COTIZACION_CODPROFORMA_" + 9).val(), 9);
//        return false;
//    });


    


    
    //funcionalidades de productos
     //ENZO
    k.down("up", function () {
        var control = $(':focus');
        if (control.attr('id') == 'MainContent_txtPrecioDisplay')
        {
            F_PrecioDisplayUp();
            return true;
        } else { 
            try {
                if (control.attr('id') == 'MainContent_txtDireccion')
                {
                    F_DireccionDisplayUp();
                    return true;
                }
            } catch (e) { }

            try {
                if (control.attr('id').indexOf("ddl") >= 0) 
                {
                F_ddlDisplayUp(control.attr('id') );
                return true;
                }
            } catch (e) { }
        }

        F_TablaUp();
        return false;
    });
    //ENZO
    k.down("down", function () {
        var control = $(':focus');
        if (control.attr('id') == 'MainContent_txtPrecioDisplay')
        {
            F_PrecioDisplayDown();
            return true;
        } else { 
            try {
                if (control.attr('id') == 'MainContent_txtDireccion')
                {
                    F_DireccionDisplayDown();
                    return true;
                }
            } catch (e) { }

            try {
                if (control.attr('id').indexOf("ddl") >= 0) 
                {
                    F_ddlDisplayDown(control.attr('id') );
                    return true;
                }
            } catch (e) { }
        }

        F_TablaDown();
        return false;
    });

    k.down("enter", function () {

            var control = $(':focus');
            var inputs = control.parents("form").eq(0).find("input, select");
            var idx = inputs.index(control);

            if (idx == inputs.length - 1) {
                //campos especiales
                F_CamposAlternativas(control.attr('id'));

            } else {
                inputs[idx + 1].focus(); //  handles submit buttons
                try {inputs[idx + 1].select();
                F_CamposAlternativas(control.attr('id'));
                } catch (e) { }               

            }
       return false;
    });
}

var ctrlPosActual = '';
var ctrlPosActualBuffer = '';
function F_TablaUp() {
    var ant = 0; var pos = 0;
    try {
        ant = parseInt(ctrlPosActual.split('_')[3]);
        pos = ant - 1; if (pos < 0) pos = 0;
        if ( $(ctrlPosActual.replace(ant, pos)).length > 0 ) {
            $(ctrlPosActual.replace(ant, pos)).focus();
            $(ctrlPosActual).closest("tr").children('td,th').css("background-color","#FFFFFF")
            ctrlPosActual = ctrlPosActual.replace(ant, pos);
            $(ctrlPosActual).closest("tr").children('td,th').css("background-color","#ffec85")
        }
        
    } catch (e) {
        $(ctrlPosActual).focus();
    }
    ctrlPosActualBuffer = ctrlPosActual;
}    
function F_TablaDown() {
    var ant = 0; var pos = 0;
    try {
        ant = parseInt(ctrlPosActual.split('_')[3]);
        pos = ant + 1;
        if ( $(ctrlPosActual.replace(ant, pos)).length > 0 ) {
            $(ctrlPosActual.replace(ant, pos)).focus();
            $(ctrlPosActual).closest("tr").children('td,th').css("background-color","#FFFFFF")
            ctrlPosActual = ctrlPosActual.replace(ant, pos);
            $(ctrlPosActual).closest("tr").children('td,th').css("background-color","#ffec85")
        }
    } catch (e) {
        $(ctrlPosActual).focus();
    }
    ctrlPosActualBuffer = ctrlPosActual;
}
function F_TablaClick(Control) {
    Control = "#" + Control;
    $(ctrlPosActualBuffer).closest("tr").children('td,th').css("background-color","#FFFFFF")
    $(Control).closest("tr").children('td,th').css("background-color","#ffec85")
    $(Control).focus();
    ctrlPosActualBuffer = Control;
}

//ENZO
function F_DireccionDisplayUp()
{
  var p;

  if ($('#MainContent_ddlDireccion option:selected').prev().length > 0) {
    p = $('#MainContent_ddlDireccion option:selected').prev().val();
    }
  else { 
    p = $('#MainContent_ddlDireccion option:selected').last().val();
  }

  $('#MainContent_ddlDireccion').val(p);
  $("#MainContent_txtDireccion").val($("#MainContent_ddlDireccion option:selected").text());   
  $('#hfCodDireccion').val(p);

}
//ENZO
function F_DireccionDisplayDown()
{
  var p;

  if ($('#MainContent_ddlDireccion option:selected').next().length > 0) {
    p = $('#MainContent_ddlDireccion option:selected').next().val();
    }
  else { 
    p = $('#MainContent_ddlDireccion option:selected').first().val();
  }
  $('#MainContent_ddlDireccion').val(p);
  $("#MainContent_txtDireccion").val($("#MainContent_ddlDireccion option:selected").text());  
  $('#hfCodDireccion').val(p);

}


function F_ddlDisplayUp(Control) {
  if ($('#' + Control + ' option:selected').prev().length > 0) 
    $('#' + Control + ' option:selected').prev().attr('selected', 'selected').trigger('change');
  else $('#' + Control + ' option').last().attr('selected', 'selected').trigger('change');
}

function F_BuscarDireccionPorDefecto() {
//    $('#hfCodDireccion').val('0');
//    $('#MainContent_txtDireccion').val('');
//    $('#hfDireccion').val('');
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDireccion_ListarXCodDistrito_AutoComplete',
        data: "{'Direccion':'','CodDepartamento':'" + $('#hfCodDepartamento').val() + "','CodProvincia':'" + $('#hfCodProvincia').val() + "','CodDistrito':'" + $('#hfCodDistrito').val() + "','CodCtaCte':'" + $('#hfCodCtaCte').val() + "'}",
        dataType: "json",
        async: false,
        success: function (data) {
                if (data.d.length >= 1)
                {
                    $('#hfCodDireccion').val(data.d[0].split(',')[0]);
                    $('#MainContent_txtDireccion').val(data.d[0].split(',')[1]);
                    $('#hfDireccion').val(data.d[0].split(',')[1]);
                    $('#MainContent_txtCorreo').val(data.d[0].split(',')[5]);
                    if ($('#hfCodCtaCte').val() == 29)
                    {
                        $('#hfCodDistrito').val(data.d[0].split(',')[2]);
                        $('#hfCodProvincia').val(data.d[0].split(',')[3]);
                        $('#hfCodDepartamento').val(data.d[0].split(',')[4]);
                    }

                    F_BuscarResponsables();

                    if ($('#MainContent_ddlTipoDoc').val() != '16')
                        F_LlenarCorreos();
                }
        },
        complete: function () {
            if (($('#hfCodDireccion').val() == '' | $('#hfCodDireccion').val() == '0') && $('#hfCodCtaCte').val() != 0)
            {
                alertify.log('NO HAY DIRECCION PARA EL DISTRITO ESPECIFICADO')
                $('#MainContent_txtDireccion').val('');
                $('#hfDireccion').val('');
                $('#hfCodDireccion').val('0');
                $('#MainContent_txtCorreo').val('');
            }

        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });

    return false;
}

var CodResponsableReemplazo = 0;
function F_BuscarResponsables() {
//    $('#trResponsableNP').css('display', 'none');
//    $('#div_trResponsableNP').css('display', 'none');
//    Solo para Nota de Pedido
    if ($('#MainContent_ddlTipoDoc').val() != '16' )
    {
        $('#trResponsableNP').css('display', 'none');
        $('#div_trResponsableNP').css('display', 'none');
        return false;
    }
    else
    {
    $('#trResponsableNP').css('display', 'block');
        $('#div_trResponsableNP').css('display', 'block');
        return false;
    }
     
    var arg;

    try {
        var objParams =
            {
                Filtro_CodCtaCte: $("#hfCodCtaCte").val()
            };

            
        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Buscar_Responsables_NET
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
                        F_Update_Division_HTML('div_ResponsableNP', result.split('~')[2]);
                        $('#MainContent_ddlResponsableNP').css('background', '#FFFFE0');
                        $('.ccsestilo').css('background', '#FFFFE0');
                        
                        if (CodResponsableReemplazo > 0) {
                            $('#MainContent_ddlResponsableNP').val(CodResponsableReemplazo);
                            CodResponsableReemplazo = 0; 
                        }

                        if ($('#hfCodigoTemporal').val() == '0')
                        {
                        F_CambioSerie_TipoDoc();
                        }

                        F_LlenarCorreosResponsable();
                    }
                    else {

                        alertify.log(str_mensaje_operacion);

                    }
//                    $('#trResponsableNP').css('display', 'block');
//                    $('#div_trResponsableNP').css('display', 'block');


                }
            );

    } catch (mierror) {
    MostrarEspera(false);
        alertify.log("Error detectado: " + mierror);

    }

    return false;
}

function F_BuscarResponsablesEdicion() {

    if ($('#hfCodTipoDocEdicion').val() != '16' )
    {
        $('#trResponsableNPEdicion').css('display', 'none');
        $('#div_trResponsableNPEdicion').css('display', 'none');
        return false;
    }
    else
    {
    $('#trResponsableNPEdicion').css('display', 'block');
        $('#div_trResponsableNPEdicion').css('display', 'block');
        return false;
    }
     
    return false;
}

function F_BuscarDistrito() {
//    $('#hfCodDireccion').val('0');
//    $('#MainContent_txtDireccion').val('');
//    $('#hfDireccion').val('');
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDistrito_ListarXCodDistrito',
        //data: "{'Direccion':'','CodDepartamento':'" + $('#hfCodDepartamento').val() + "','CodProvincia':'" + $('#hfCodProvincia').val() + "','CodDistrito':'" + $('#hfCodDistrito').val() + "','CodCtaCte':'" + $('#hfCodCtaCte').val() + "'}",
        data: "{'CodDistrito':'" + $('#hfCodDistrito').val() + "'}",
        dataType: "json",
        async: false,
        success: function (data) {
                if (data.d.length >= 1)
                {
                    $('#MainContent_txtDistrito').val(data.d[0].split(',')[3]);
                }
        },
        complete: function () {
            //if (($('#hfCodDireccion').val() == '' | $('#hfCodDireccion').val() == '0') && $('#hfCodCtaCte').val() != 0)
            //{
            //    alertify.log('NO HAY DIRECCION PARA EL DISTRITO ESPECIFICADO')
            //    $('#MainContent_txtDireccion').val('');
            //    $('#hfDireccion').val('');
            //    $('#hfCodDireccion').val('0');
            //}
        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });

    return false;
}

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
     F_Mostrar_Correlativo(10);
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

$(document).on("change", "select[id $= 'MainContent_ddlFormaPagoEdicion']",function () {
     $('#MainContent_ddlFormaPagoEdicion').css('background', '#FFFFE0');
     F_FormaPagoEdicion($("#MainContent_ddlFormaPagoEdicion").val());
} );

$(document).on("change", "select[id $= 'MainContent_ddlMoneda']",function () {
    F_ACTUALIZAR_MONTO_MONEDA();
} );

$(document).on("change", "select[id $= 'MainContent_ddlTipoDoc']",function () {
     F_CambioTipoDoc();
} );

$(document).on("change", "select[id $= 'MainContent_ddlTipoTransportista']",function () {
     F_CambioTransportista();
} );

$(document).on("change", "select[id $= 'MainContent_ddlTipoTransportistaEdicion']",function () {
     F_CambioTransportistaEdicion();
} );

$(document).on("change", "select[id $= 'MainContent_ddlTipoDoc2']",function () {
     F_CambioTipo2();
      if ($("#MainContent_ddlTipoDoc2").val()==16)
      {
      $('#MainContent_ddlEstadoConsultaNP').prop('disabled', false);
      $('#MainContent_chkProductoConsulta').prop('disabled', true);
      $('#MainContent_ddlEstadoConsultaNP').val(0);
      $('#MainContent_txtProductoConsulta').prop('disabled', true);
      $('#MainContent_ddlEstadoConsulta').val('TODOS');
      $('#MainContent_ddlEstadoConsulta').prop('disabled', true);
      $('#MainContent_txtProductoConsulta').val('');
      $('#hfcodproductoconsulta').val('0');
      }else if ($("#MainContent_ddlTipoDoc2").val()==15)
      {
      $('#MainContent_txtProductoConsulta').prop('disabled', false);
      $('#MainContent_chkProductoConsulta').prop('disabled', false);
      $('#MainContent_ddlEstadoConsultaNP').prop('disabled', true);
      $('#MainContent_ddlEstadoConsultaNP').val(0);
      $('#MainContent_ddlEstadoConsulta').val('TODOS');
      $('#MainContent_ddlEstadoConsulta').prop('disabled', true);
      }else{
      $('#MainContent_txtProductoConsulta').prop('disabled', true);
      $('#MainContent_chkProductoConsulta').prop('disabled', true);
      $('#MainContent_ddlEstadoConsultaNP').prop('disabled', true);
      $('#MainContent_ddlEstadoConsulta').prop('disabled', false);
      $('#MainContent_ddlEstadoConsultaNP').val(0);
      $('#MainContent_txtProductoConsulta').val('');
      $('#hfcodproductoconsulta').val('0');
      }
} );

$(document).on("change", "select[id $= 'MainContent_ddlDireccion']",function () {
     $('#MainContent_txtDireccion').val($('#MainContent_ddlDireccion option:selected').text());
     $('#hfCodDireccion').val($('#MainContent_ddlDireccion option:selected').val());
} );


$(document).on("change", "select[id $= 'MainContent_ddlSerieGuia']",function () {
     BloqueoTipoTransportista($(Cuerpo + 'ddlSerieGuia option:selected').text(),(Cuerpo + 'txtNumeroGuia'),(Cuerpo + 'txtFechaTraslado')
                 ,(Cuerpo + 'txtDestino'),
                 (Cuerpo + 'txtTransportista'),
                 (Cuerpo + 'txtNroRucTransportista')
                 ,(Cuerpo + 'txtPlacaTraslado'),
                 (Cuerpo + 'txtLicenciaGuia'),
                 (Cuerpo + 'txtNuBultos'),
                 (Cuerpo + 'txtPeso')
                 ,(Cuerpo + 'txtConductorRazonSocial'),
                 (Cuerpo + 'txtConductorDNI'),
                 $(Cuerpo + 'ddlTipoTransportista').val(),
                 (Cuerpo + 'ddldireccionNuevaTransportista'),
                 $('#hfCodConductor').val()
                 ,(Cuerpo + 'txtMarcaGuia'),
                 $(Cuerpo + 'ImageButton1'),
                 $(Cuerpo +'ImageButton2'),
                 (Cuerpo + 'chkGuia'),$('#hfCodTransportista').val());
});

$(document).on("change", "select[id $= 'MainContent_ddlTipoTransportista']",function () {
     BloqueoTipoTransportista($(Cuerpo + 'ddlSerieGuia option:selected').text(),(Cuerpo + 'txtNumeroGuia'),(Cuerpo + 'txtFechaTraslado')
                 ,(Cuerpo + 'txtDestino'),
                 (Cuerpo + 'txtTransportista'),
                 (Cuerpo + 'txtNroRucTransportista')
                 ,(Cuerpo + 'txtPlacaTraslado'),
                 (Cuerpo + 'txtLicenciaGuia'),
                 (Cuerpo + 'txtNuBultos'),
                 (Cuerpo + 'txtPeso')
                 ,(Cuerpo + 'txtConductorRazonSocial'),
                 (Cuerpo + 'txtConductorDNI'),
                 $(Cuerpo + 'ddlTipoTransportista').val(),
                 (Cuerpo + 'ddldireccionNuevaTransportista'),
                 $('#hfCodConductor').val()
                 ,(Cuerpo + 'txtMarcaGuia'),
                 $(Cuerpo + 'ImageButton1'),
                 $(Cuerpo +'ImageButton2'),
                 (Cuerpo + 'chkGuia'),$('#hfCodTransportista').val());
});

//cambio de tipo de documento
function F_CambioTipoDoc() {
     
     $("#MainContent_ddlTipoDoc2").val($("#MainContent_ddlTipoDoc").val());
//     $('#trResponsableNP').css('display','none');
//     $('#div_trResponsableNP').css('display','none');

    switch($("#MainContent_ddlTipoDoc").val()) {
        case '1': //FACTURA
            //Bloqueo de campos
            $('#MainContent_txtCliente').prop('disabled', false);
            $('#MainContent_txtApePaterno').prop('disabled', true);
            $('#MainContent_txtApeMaterno').prop('disabled', true);
            $('#MainContent_txtNombres').prop('disabled', true);
            $('#MainContent_txtAtencion').prop('disabled', true);
            $('#MainContent_txtReferencia').prop('disabled', true);
            
                $('#MainContent_txtNroRuc').prop('disabled', false);
            
            //Tipo de CtaCte a filtrar
            $('#hfCodTipoCliente').val('2');

            //Valores por Defecto
            if (!ValidarSoloRuc($('#MainContent_txtNroRuc').val()))
            {
                $('#hfCodCtaCte').val(0);
                $('#MainContent_txtNroRuc').val('');
                $('#hfNroRuc').val('');
                $('#MainContent_txtCliente').val('');
                $('#hfCliente').val('');
                $('#MainContent_txtApePaterno').val('');
                $('#MainContent_txtApeMaterno').val('');
                $('#MainContent_txtNombres').val('');
                $('#MainContent_txtAtencion').val('');
                $('#MainContent_txtReferencia').val('');

                $('#MainContent_txtDireccion').val('');
                $('#MainContent_txtDestino').val('');
                $('#MainContent_txtDistrito').val('');
                $('#hfCodDireccion').val(0);
                $('#hfCodDepartamento').val(0);
                $('#hfCodProvincia').val(0);
                $('#hfCodDistrito').val(0);
                $('#MainContent_ddlTipoImpresion').val('IMP');


                $('#MainContent_txtNroRuc').focus();
                $('#MainContent_txtNroRuc').select();
            }
            
            F_BUSCARDNIONBLURENTER('#MainContent_txtNroRuc');

            $('#MainContent_chkImpresion').prop('checked', true);
            $('#MainContent_chkImpresionTicket').prop('checked', false);
            $('#MainContent_chkGuia').prop('disabled', false);
            $('#trResponsableNP').css('display','none');
            $('#div_trResponsableNP').css('display','none');
            
            $('#MainContent_ddldireccionNueva').empty();    
            $('#MainContent_ddldireccionNuevaDestino').empty();  
            F_CambioSerie_TipoDoc();
            break;
        case '2': //BOLETA
            //bloqueo de campos
            $('#MainContent_txtCliente').prop('disabled', true);
            $('#MainContent_txtApePaterno').prop('disabled', false);
            $('#MainContent_txtApeMaterno').prop('disabled', false);
            $('#MainContent_txtNombres').prop('disabled', false);
            $('#MainContent_txtAtencion').prop('disabled', true);
            $('#MainContent_txtReferencia').prop('disabled', true);
                $('#MainContent_txtNroRuc').prop('disabled', false);

            //Tipo de CtaCte a filtrar
            $('#hfCodTipoCliente').val('1')

            
            $('#MainContent_ddldireccionNueva').empty();    
            $('#MainContent_ddldireccionNuevaDestino').empty();

            if ($('#MainContent_txtNroRuc').val().length != 8)
            {
                   $('#MainContent_txtNroRuc').val('11111111');
//              F_BuscarDatosPorRucDni('11111111');

            }
            
            F_BUSCARDNIONBLURENTER('#MainContent_txtNroRuc');
     
            $('#MainContent_ddlTipoImpresion').val('IMP');


            $('#MainContent_txtAtencion').focus();
            $('#MainContent_chkGuia').prop('disabled', false);
                   $('#MainContent_chkImpresion').prop('checked', true);
            $('#MainContent_chkImpresionTicket').prop('checked', false);
            $('#trResponsableNP').css('display','none');
     $('#div_trResponsableNP').css('display','none');
       
            F_CambioSerie_TipoDoc();
            
            break;
        case '15': //COTIZACION (PROFORMA)
            //bloqueo de campos
            $('#MainContent_txtCliente').prop('disabled', false);
            $('#MainContent_txtApePaterno').prop('disabled', true);
            $('#MainContent_txtApeMaterno').prop('disabled', true);
            $('#MainContent_txtNombres').prop('disabled', true);
            $('#MainContent_txtAtencion').prop('disabled', false);
            $('#MainContent_txtReferencia').prop('disabled', false);

            //Tipo de CtaCte a filtrar
            $('#hfCodTipoCliente').val('0')
            $('#MainContent_ddlTipoImpresion').val('IMP');
            
            $('#MainContent_ddldireccionNueva').empty();    
            $('#MainContent_ddldireccionNuevaDestino').empty();  
            
            if ($('#MainContent_txtNroRuc').val() == '')
            {
                 $('#MainContent_txtNroRuc').val('11111111');
//              F_BuscarDatosPorRucDni('11111111');

            }
            
            F_BUSCARDNIONBLURENTER('#MainContent_txtNroRuc');

            $('#MainContent_chkImpresion').prop('checked', true);
            $('#MainContent_chkImpresionTicket').prop('checked', false);

            $('#MainContent_txtAtencion').focus();
            $('#MainContent_chkImpresion').prop('checked', true);
            $('#MainContent_chkImpresionTicket').prop('checked', false);
            F_CambioSerie_TipoDoc();
            break;

        case '16': //NOTA DE PEDIDO
            //bloqueo de campos
            $('#MainContent_txtCliente').prop('disabled', false);
            $('#MainContent_txtApePaterno').prop('disabled', true);
            $('#MainContent_txtApeMaterno').prop('disabled', true);
            $('#MainContent_txtNombres').prop('disabled', true);
            $('#MainContent_txtAtencion').prop('disabled', false);
            $('#MainContent_txtReferencia').prop('disabled', false);
                $('#MainContent_txtNroRuc').prop('disabled', false);
            $('#MainContent_ddldireccionNueva').empty();    
            $('#MainContent_ddldireccionNuevaDestino').empty();

           //Tipo de CtaCte a filtrar
             $('#hfCodTipoCliente').val('1')

            if ($('#MainContent_txtNroRuc').val() == '')
            {
                 $('#MainContent_txtNroRuc').val('11111111');
//              F_BuscarDatosPorRucDni('11111111');

            }
            
            F_BUSCARDNIONBLURENTER('#MainContent_txtNroRuc');
            $('#MainContent_ddlTipoImpresion').val('IMP');

            $('#MainContent_chkImpresion').prop('checked', true);
            $('#MainContent_chkImpresionTicket').prop('checked', false);


            $('#MainContent_txtAtencion').focus();
            F_CambioSerie_TipoDoc();
            break;
            case '22': //NOTA DE PEDIDO
            //bloqueo de campos
            $('#MainContent_txtCliente').prop('disabled', false);
            $('#MainContent_txtApePaterno').prop('disabled', true);
            $('#MainContent_txtApeMaterno').prop('disabled', true);
            $('#MainContent_txtNombres').prop('disabled', true);
            $('#MainContent_txtAtencion').prop('disabled', false);
            $('#MainContent_txtReferencia').prop('disabled', false);
                $('#MainContent_txtNroRuc').prop('disabled', false);

            //Tipo de CtaCte a filtrar
            $('#hfCodTipoCliente').val('0')
            $('#MainContent_ddlTipoImpresion').val('IMP');

            $('#MainContent_chkImpresion').prop('checked', true);
            $('#MainContent_chkImpresionTicket').prop('checked', false);

            
            $('#MainContent_chkGuia').prop('disabled', true);
             //desabilitado
            $('#MainContent_txtNroRucTransportista').prop("disabled", true);
            $('#MainContent_txtTransportista').prop("disabled", true);
            $('#MainContent_txtDistritoTransportista').prop("disabled", true);
            $('#MainContent_txtDireccionTransportista').prop("disabled", true);
            $('#MainContent_txtPlacaTraslado').prop("disabled", true);
            $('#MainContent_txtMarcaGuia').prop("disabled", true);
            $('#MainContent_txtLicenciaGuia').prop("disabled", true);
            $('#MainContent_txtNuBultos').prop("disabled", true);
            $('#MainContent_txtPeso').prop("disabled", true);
            $('#MainContent_txtConductorDNI').prop("disabled", true);
            $('#MainContent_txtConductorRazonSocial').prop("disabled", true);

            $('#MainContent_txtNumeroGuia').prop('readonly', true);
            $('#MainContent_txtDestino').prop('readonly', true);
            $('#MainContent_txtFechaTraslado').prop('readonly', true);
            $('#MainContent_ddldireccionNueva').empty();    
            $('#MainContent_ddldireccionNuevaDestino').empty();  
               F_CambioSerie_TipoDoc();
            $('#MainContent_txtAtencion').focus();
            break;
    }
 
    $('#MainContent_lbTipoDocumento').text($("#MainContent_ddlTipoDoc option:selected").text());

    F_BuscarResponsables();

    //solo actualizara los email si hay un CodDireccion, sino quedan tal cual
    if ($("#MainContent_ddlTipoDoc").val() === '16') {
       F_CambioSerie_TipoDoc();}
    else
    F_LlenarCorreos();

    return false;
}

//cambio de tipo de documento
function F_CambioTipo2() {
    $("#hfCodTipoDoc2").val($("#MainContent_ddlTipoDoc2").val());
    F_CambioSerie_TipoDoc2();
    return false;
}

function F_CambioSerie_TipoDoc() {

    var arg;

    try {
        var objParams =
            {
                Filtro_Fecha: $('#MainContent_txtEmision').val(),
                Filtro_CodDoc: $("#MainContent_ddlTipoDoc").val(),
                
               Filtro_CodEstado: 'A'
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
                        F_Update_Division_HTML('div_serieguiaEdicion', result.split('~')[31]);
                        //F_Update_Division_HTML('div_formapago', result.split('~')[4]);
                        F_Update_Division_HTML('div_FormaPagoEdicion', result.split('~')[19]);
                        //F_Update_Division_HTML('div_moneda', result.split('~')[5]);
                        $('#MainContent_lblTC').text(result.split('~')[6]);
                        $('#MainContent_lblTC2').text(result.split('~')[6]);

                        $('#MainContent_lblTCParalelo').text(result.split('~')[25]);
                        $('#MainContent_lblTC2Paralelo').text(result.split('~')[25]);
                        $('#MainContent_ddlSerieConsulta').val(61);
                        F_Update_Division_HTML('div_serieconsulta', result.split('~')[9]);
                        F_Update_Division_HTML('div_igv', result.split('~')[8]);
                        //$('#MainContent_ddlMoneda').val(1);
                        
                        $('#MainContent_txtNumero').val(result.split('~')[7]);
                        $('#MainContent_txtVencimiento').val($('#MainContent_txtEmision').val());
                        $('#hfCodUsuario').val(result.split('~')[10]);
                        $('#hfPartida').val(result.split('~')[11]);
                        $('#hfCodSede').val(result.split('~')[12]);
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                        $('#MainContent_ddlFormaPago').css('background', '#FFFFE0');
                        $('#MainContent_ddlFormaPagoEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerie').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerieConsulta').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerieGuia').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerieGuiaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlIgv').css('background', '#FFFFE0');
                        $('#MainContent_ddlTipoDoc').css('background', '#FFFFE0');
                        $('#MainContent_txtAtencion').val('');
                        $('#MainContent_txtReferencia').val('');
                        $('#MainContent_txtDistritoTransportista').css('background', '#FFFFE0');
                        $('.ccsestilo').css('background', '#FFFFE0');
                        F_CambioSerie();                        
                        FormaPagoDefault = result.split('~')[18];
                       // $('#MainContent_ddlFormaPago').val(FormaPagoDefault);

                        if ($("#MainContent_ddlTipoDoc").val() == 2)
                        {
                            $('#MainContent_ddlFormaPago').val(1);
                            //$('#trResponsableNP').css('display','block');
                        }

                        //CHECK SERVICIOS Y ACTIVOS
                        //--
                        if (result.split('~')[29] === '0')
                            $('#div_chkServicios').css('display', 'none');
                        if (result.split('~')[30] === '0')
                            $('#div_chkActivos').css('display', 'none');                            
                        
                        //--

                        F_ContarItems();
                        F_InicializarCorreos();

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

function F_CambioSerie_TipoDoc2() {

    var arg;

    try {
        var objParams =
            {
                Filtro_Fecha: $('#MainContent_txtEmision').val(),
                Filtro_CodDoc: $("#MainContent_ddlTipoDoc2").val(),
                
                Filtro_CodEstado: 'A'
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
                        F_Update_Division_HTML('div_serieconsulta', result.split('~')[9]);
                        $('#MainContent_ddlSerieConsulta').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerieGuia').css('background', '#FFFFE0');
                        $('.ccsestilo').css('background', '#FFFFE0');
                        F_Buscar();
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

function F_ValidaRucDni() {
if (!F_SesionRedireccionar(AppSession)) return false;
    if ($('#MainContent_txtNroRuc').val().length > 0)
    {
        if ($('#MainContent_txtNroRuc').val().trim() === $('#hfNroRuc').val().trim() & 
            $('#MainContent_txtCliente').val().trim() === $('#hfCliente').val().trim() & 
            $('#MainContent_txtNroRuc').val().trim() != "")
        return false;


    var Index= $('#MainContent_txtNroRuc').val().indexOf('-');
    var Cliente = $('#MainContent_txtNroRuc').val();

    if ($('#MainContent_txtNroRuc').val() === '1') {
            $('#MainContent_txtNroRuc').val('11111111111');

            if ($('#MainContent_ddlTipoDoc').val() === '1')
                $('#MainContent_txtNroRuc').val('');

            if ($('#MainContent_ddlTipoDoc').val() === '2')
                $('#MainContent_txtNroRuc').val('11111111');
        }

    if ( Index ==-1 ) {
        if ((isNaN($('#MainContent_txtNroRuc').val()) | !ValidarRuc($('#MainContent_txtNroRuc').val())) & $('#MainContent_txtNroRuc').val() != '1')
        {
            $('#MainContent_txtNroRuc').val('');
            $('#MainContent_txtNroRuc').focus();
            alertify.log('ERROR EN RUC');
            return false;
        }
    } else {
    $('#MainContent_txtNroRuc').val(Cliente.split('-')[0].trim());
    }

//        $('#MainContent_txtCliente').val('');
//        $('#hfCliente').val('');

        //DNI
        if ($('#MainContent_txtNroRuc').val().length == 8)
        {
            var NroRuc = $('#MainContent_txtNroRuc').val();
            F_BuscarDatosPorRucDni($('#MainContent_txtNroRuc').val());
            return true;
        }
        else
        {
            //RUC
            if ($('#MainContent_txtNroRuc').val().length == 11 & $('#MainContent_txtNroRuc').val() != '55555555555')
            {
                $('#MainContent_txtCliente').focus();
                 if($('#MainContent_txtCliente').val()!=''){
                ConsultandoPadron = true;
                }else{
                ConsultandoPadron = false;
                }
                F_BuscarPadronSunat();
                return true;
            }
            else
            {
                //CLIENTE VARIOS
                if ($('#MainContent_txtNroRuc').val() == '1')
                {
                    $('#MainContent_txtNroRuc').val('11111111');
                    $('#hfNroRuc').val($('#MainContent_txtNroRuc').val());
                    F_BuscarDatosPorRucDni('11111111');
                    return true;
                }
                else if ($('#MainContent_txtNroRuc').val() === '55555555555') {
                    F_LlenarCorreos();
                    return true;
                }
                else
                {
//                    if ( Index ==-1 ) {} else {
                    alertify.log('NRO. RUC/DNI INVALIDO'); 
                    $('#MainContent_txtNroRuc').val('');
                    F_LimpiarCampos();
                    $('#MainContent_txtNroRuc').focus();
//                    }
                    return true;
                }
            }
        }
    }
    else
    {
        if ($('#MainContent_txtNroRuc').val() != $('#hfNroRuc').val())
        {
            F_LimpiarCampos();
            return true;
        }
    }
   return false;
}

var ConsultarPadron = true;
//aca busca si es un nuevo numero de dni o ruc
var API = ""
var ubigeo="";
function F_BuscarPadronSunat() {
  if (ConsultandoPadron == true)
        return true;

//    ConsultandoPadron = true;
        $('#td_loading').css('display', 'block');
        var NroRuc = $('#MainContent_txtNroRuc').val();
        F_LimpiarCampos();
        $('#MainContent_txtNroRuc').val(NroRuc);
        if (API == "") {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCCuentaCorriente_PadronSunat_Clientes',
                data: "{'NroRuc':'" + $('#MainContent_txtNroRuc').val() +"'}",
                dataType: "json",
                async: true,
                success: function (dbObject) {
                var data = dbObject.d;
                try {
                   // condiciona joel:si en la base de datos no se encuentra ninguna condicion de ruc se manda para la apisunat
                    if (data.length!=0) {
                    $('#td_loading').css('display', 'none');   
                    if (data.length == 0) {
                        alertify.log('NO SE ENCONTRO EL RUC EN LA BASE DE DATOS');

                        var NroRuc = $('#MainContent_txtNroRuc').val();
                        F_LimpiarCampos();
                        $('#MainContent_txtNroRuc').val(NroRuc);
                        $("#hfCodCtaCte").val('0');
                        $('#MainContent_txtCliente').prop('disabled', false);
                        if ($('#MainContent_txtCliente').val().trim() === '')
                            $('#MainContent_txtCliente').val('--NUEVO CLIENTE--');
                        $('#MainContent_txtCliente').select();
                        ConsultarPadron = false;
                        ConsultandoPadron = false;
                        return true;                    
                    }
                    else if (data[0].split(',')[0] === "-1")
                    {
                        alertify.log('PROBLEMA DE COMUNICACION CON EL SERVICIO DE PADRON SUNAT, SE DESHABILITARA TEMPORALMENTE LA CONSULTA. PUEDE INTERSAR EL NUEVO CLIENTE MANUALMENTE.');

                        var NroRuc = $('#MainContent_txtNroRuc').val();
                        F_LimpiarCampos();
                        $('#MainContent_txtNroRuc').val(NroRuc);
                        $("#hfCodCtaCte").val('0');
                        $('#MainContent_txtCliente').prop('disabled', false);
                        if ($('#MainContent_txtCliente').val().trim() === '')
                            $('#MainContent_txtCliente').val('--ERROR DE CONEXION--');
                        $('#MainContent_txtCliente').select();
                        ConsultarPadron = false;
                        ConsultandoPadron = false;
                        return true;
                    }
                    else {
                    $('#hfCodCtaCte').val(data[0].split(',')[0]); 
                    $('#hfCliente').val(data[0].split(',')[1]); //razon social
                    $('#MainContent_txtNroRuc').val(data[0].split(',')[8]);
                    $('#hfNroRuc').val(data[0].split(',')[8]);
                    $('#MainContent_txtCliente').val(data[0].split(',')[1]);
                    $('#hfCliente').val(data[0].split(',')[1]);
                    $('#MainContent_txtDireccion').val(data[0].split(',')[2]);
                    $('#MainContent_txtDestino').val(data[0].split(',')[2]);
                    $('#MainContent_txtDistrito').val(data[0].split(',')[4]);
                    $('#hfCodDireccion').val('0');
                    $('#hfCodDepartamento').val(data[0].split(',')[5]);
                    $('#hfCodProvincia').val(data[0].split(',')[6]);
                    $('#hfCodDistrito').val(data[0].split(',')[7]);
                    $('#hfDistrito').val(data[0].split(',')[4]);
                    $('#txtSaldoCreditoFavor').text(data[0].split(',')[12]);
                    $('#hfSaldoCreditoFavor').val(data[0].split(',')[12].replace("S/", "").replace(" ", ""));

                    F_BuscarDireccionPorDefecto();
//            if ($('#hfNotaPedido').val() == '5' & $('#hfCodCtaCte').val() != $('#hfCodCtaCteNP').val())
//                F_EliminarTodos();
//            if ($('#hfNotaPedido').val() != '0'  & ($('#MainContent_ddlTipoDoc').val() == '5' | $('#MainContent_ddlTipoDoc').val() == '15' | $('#MainContent_ddlTipoDoc').val() == '16'))
//                F_EliminarTodos();

                    }

                    }else{
                     API = "Usuario No Encontrado";
                        console.log(API);
                        F_API_RUC_Buscar();
                        F_BuscarPadronSunat();
                       
                    }
                }
                catch (x) { alertify.log(x); }
                MostrarEspera(false);
            },


                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
    };
    if (API == "Usuario No Encontrado") {
        //api sunat 
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url:  $('#hfurlapisunat').val() + $('#MainContent_txtNroRuc').val() + $('#hftokenapisunat').val(),dataType: "json",
            async: true,
            success: function (dbObject) {
                MostrarEspera(true);
                var data = dbObject.d;                                
                try {
                API = "";
                $('#td_loading').css('display', 'none');
                    $('#MainContent_txtCliente').val(dbObject.razonSocial); //razon social
                    $('#MainContent_txtNombreComercial').val(dbObject.razonSocial); //razon social
                    ubigeo=dbObject.ubigeo;
                    if (ubigeo==null){
                     toastr.warning("La sunat no ofrece direccion ni distrito para los ruc 10,debe colocarlo usted mismo.");
                     }
                    var direccion = dbObject.direccion;
                    var distrito = dbObject.departamento + ' ' + dbObject.provincia + ' ' + dbObject.distrito;
                    $('#MainContent_txtDireccion').val(direccion.replace(distrito, ""));
                     $('#MainContent_txtDestino').val(direccion.replace(distrito, ""));
                    $('#MainContent_txtDireccionEnvio').val(direccion.replace(distrito, ""));
                    $('#MainContent_txtDistrito').val(distrito);
                    $('#hfDistrito').val(distrito);
                    $('#hfUbigeo').val(dbObject.ubigeo);
                        ConsultandoPadron = false;
                    
                    F_BuscarDireccionNuevo();
                }
                catch (x) { }
                MostrarEspera(false);
            },
            error: function (response) {
                toastr.warning(response.responseText);
            },
            failure: function (response) {
                toastr.warning(response.responseText);
            }
        });
    }

return true;
}

function F_BuscarDatosPorRucDni(RucDni) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_BuscarClientesPorRucDni',
                data: "{'NroRuc':'" + RucDni +"'}",
                dataType: "json",
                async: false,
                success: function (dbObject) {
                var data = dbObject.d;
                if (data.length > 0)
                {
                    try {
                            $('#hfCodCtaCte').val(data[0].split(',')[0]); 
                            $('#MainContent_txtCliente').val(data[0].split(',')[1]);
                            $('#hfCliente').val($('#MainContent_txtCliente').val()); //razon social
                            $('#MainContent_txtNroRuc').val(data[0].split(',')[8]);
                            $('#hfNroRuc').val(data[0].split(',')[8]);
                            $('#MainContent_txtDireccion').val(data[0].split(',')[2]);
                            $('#MainContent_txtDestino').val(data[0].split(',')[2]);
                            $('#MainContent_txtDistrito').val(data[0].split(',')[4]);
                            $('#hfCodDireccion').val('0');
                            $('#hfCodDepartamento').val(data[0].split(',')[5]);
                            $('#hfCodProvincia').val(data[0].split(',')[6]);
                            $('#hfCodDistrito').val(data[0].split(',')[7]);
                            $('#hfDistrito').val(data[0].split(',')[4]);
//                            $('#txtSaldoCreditoFavor').text(data[0].split(',')[12]);
//                            $('#hfSaldoCreditoFavor').val(data[0].split(',')[12].replace("S/", "").replace(" ", ""));

                            F_BuscarDireccionPorDefecto(); 
                            F_BuscarResponsables();
                            return true;
                    }
                    catch (x) { alertify.log(x); }
                }
                else
                {
                    var NroRuc = $('#MainContent_txtNroRuc').val();
                    F_LimpiarCampos();
                    $('#MainContent_txtNroRuc').val(NroRuc);
                    if ($('#MainContent_txtNroRuc').val().length == 8)
                    {
                            $("#hfCodCtaCte").val('0');
                            if ($('#MainContent_txtNroRuc').val() != '11111111')
                            {
                                $('#MainContent_txtCliente').prop('disabled', false);
                                $('#MainContent_txtCliente').val('---NUEVO CLIENTE---');
                                }
                            $('#MainContent_txtCliente').select();
                    }
                    return false;
                }



            },


                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });



return true;
}

function F_LimpiarCampos() {
    switch($("#MainContent_ddlTipoDoc").val()) {
        case '1': //FACTURA
            //Bloqueo de campos
            $('#MainContent_txtCliente').prop('disabled', true);
            $('#MainContent_txtAtencion').prop('disabled', true);
            $('#MainContent_txtReferencia').prop('disabled', true);
            
            //Valores por Defecto
            $('#hfCodCtaCte').val(0);
            $('#MainContent_txtNroRuc').val('');
            $('#hfNroRuc').val('');
            $('#MainContent_txtCliente').val('');
            $('#hfCliente').val('');
            $('#MainContent_txtAtencion').val('');
            $('#MainContent_txtReferencia').val('');

            $('#MainContent_txtDireccion').val('');
            $('#MainContent_txtDestino').val('');
            $('#MainContent_txtDistrito').val('');
            $('#hfCodDireccion').val(0);
            $('#hfCodDepartamento').val(0);
            $('#hfCodProvincia').val(0);
            $('#hfCodDistrito').val(0);

            $('#MainContent_txtCliente').focus();

             $('#hfDistrito').val('');
             $('#hfDireccion').val('');
             
            break;
        case '2': //BOLETA
            //bloqueo de campos
            $('#MainContent_txtCliente').prop('disabled', true);
            $('#MainContent_txtAtencion').prop('disabled', true);
            $('#MainContent_txtReferencia').prop('disabled', true);

            //Tipo de CtaCte a filtrar
            $('#hfCodTipoCliente').val('1')

            //Valores por Defecto
            $('#hfCodCtaCte').val(0);
            $('#hfCodDireccion').val(0);
            $('#MainContent_txtNroRuc').val('');
            $('#hfNroRuc').val('');
            $('#MainContent_txtCliente').val('');
            $('#hfCliente').val('');
            $('#MainContent_txtAtencion').val('');
            $('#MainContent_txtReferencia').val('');

            $('#MainContent_txtDireccion').val('');
            $('#MainContent_txtDestino').val('');
            $('#MainContent_txtDistrito').val('');
            $('#hfCodDepartamento').val();
            $('#hfCodProvincia').val();
            $('#hfCodDistrito').val();

            F_BuscarDireccionPorDefecto();

            $('#MainContent_txtApePaterno').focus();

             $('#hfDistrito').val('');
             $('#hfDireccion').val('');

            break;
        case '15': //COTIZACION (PROFORMA)
            //bloqueo de campos
            $('#MainContent_txtCliente').prop('disabled', false);
            $('#MainContent_txtAtencion').prop('disabled', true);
            $('#MainContent_txtReferencia').prop('disabled', true);

            //Tipo de CtaCte a filtrar
            $('#hfCodTipoCliente').val('0')

            //Valores por Defecto
            $('#hfCodCtaCte').val(0);
            $('#hfCodDireccion').val(0);
            $('#MainContent_txtNroRuc').val('');
            $('#hfNroRuc').val('');
            $('#MainContent_txtCliente').val('');
            $('#hfCliente').val('');
            $('#MainContent_txtAtencion').val('');
            $('#MainContent_txtReferencia').val('');

            $('#MainContent_txtDireccion').val('');
            $('#MainContent_txtDestino').val('');
            $('#MainContent_txtDistrito').val('');
            $('#hfCodDepartamento').val();
            $('#hfCodProvincia').val();
            $('#hfCodDistrito').val();

             $('#hfDistrito').val('');
             $('#hfDireccion').val('');
            break;

        case '16': //NOTA DE PEDIDO
            //bloqueo de campos
            $('#MainContent_txtCliente').prop('disabled', false);
            $('#MainContent_txtAtencion').prop('disabled', true);
            $('#MainContent_txtReferencia').prop('disabled', true);

            //Tipo de CtaCte a filtrar
            $('#hfCodTipoCliente').val('0')

            //Valores por Defecto
            $('#hfCodCtaCte').val(0);
            $('#hfCodDireccion').val(0);
            $('#MainContent_txtNroRuc').val('');
            $('#hfNroRuc').val('');
            $('#MainContent_txtCliente').val('');
            $('#hfCliente').val('');
            $('#MainContent_txtAtencion').val('');
            $('#MainContent_txtReferencia').val('');

            $('#MainContent_txtDireccion').val('');
            $('#MainContent_txtDestino').val('');
            $('#MainContent_txtDistrito').val('');
            $('#hfCodDepartamento').val();
            $('#hfCodProvincia').val();
            $('#hfCodDistrito').val();

             $('#hfDistrito').val('');
             $('#hfDireccion').val('');
            break;
            case '22': //VALE CREDITO
            //bloqueo de campos
            $('#MainContent_txtCliente').prop('disabled', false);
            $('#MainContent_txtAtencion').prop('disabled', true);
            $('#MainContent_txtReferencia').prop('disabled', true);

            //Tipo de CtaCte a filtrar
            $('#hfCodTipoCliente').val('0')

            //Valores por Defecto
            $('#hfCodCtaCte').val(0);
            $('#hfCodDireccion').val(0);
            $('#MainContent_txtNroRuc').val('');
            $('#hfNroRuc').val('');
            $('#MainContent_txtCliente').val('');
            $('#hfCliente').val('');
            $('#MainContent_txtAtencion').val('');
            $('#MainContent_txtReferencia').val('');

            $('#MainContent_txtDireccion').val('');
            $('#MainContent_txtDestino').val('');
            $('#MainContent_txtDistrito').val('');
            $('#hfCodDepartamento').val();
            $('#hfCodProvincia').val();
            $('#hfCodDistrito').val();

             $('#hfDistrito').val('');
             $('#hfDireccion').val('');
            break;
    }
    $('#MainContent_lbTipoDocumento').text($("#MainContent_ddlTipoDoc option:selected").text());
}

function F_CambioSerie()
{
if ($("#MainContent_ddlSerie option:selected").text().substr(0, 1) == 'F' || $("#MainContent_ddlSerie option:selected").text().substr(0, 1) == 'B')
{ 
    $('#divNumero').prop("style").display="block";
    $('#MainContent_txtEmision').prop('disabled', true);
    $('#MainContent_txtNumero').prop('readonly', true);
     }
else
{ 
    $('#divNumero').prop("style").display="block";
    $('#MainContent_txtEmision').prop('disabled', false);
    $('#MainContent_txtNumero').prop('readonly', false);
 }



    switch($("#MainContent_ddlTipoDoc").val()) {
        case '1': //FACTURA
            F_Mostrar_CorrelativoVarios(1);
            break;
        case '2': //BOLETA
            F_Mostrar_CorrelativoVarios(2);
            break;
        case '15': //COTIZACION (PROFORMA)
            F_Mostrar_CorrelativoVarios(15);
            break;
        case '16': //NOTA PEDIDO
            F_Mostrar_CorrelativoVarios(16);
            break;
            case '22': //VALE CREDITO
            F_Mostrar_CorrelativoVarios(22);
            break;
    }
}

function F_Controles_Inicializar() {
 F_Inicializar_Parametros();

//    if (P_UNIDADES_ENTEROS == "1")
//        $('#MainContent_txtCantidad').ForceNumericOnly();
    var arg;

    try {
        var objParams =
            {
                Filtro_Fecha: $('#MainContent_txtEmision').val(),
                Filtro_CodDoc: 1,
                Filtro_CodEstado: 'A'
            };

        var val;
        for (val in ImpresorasNotaPedido) {
            st = new Option(ImpresorasNotaPedido[val], ImpresorasNotaPedido[val]);
            document.getElementById('MainContent_ddlImpresoraNotaPedido').add(st);
        }
        $("#MainContent_ddlImpresoraNotaPedido").css('background', '#FFFFE0');

            
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
                        F_Update_Division_HTML('div_serieguiaEdicion', result.split('~')[31]);
                        F_Update_Division_HTML('div_formapago', result.split('~')[4]);
                        F_Update_Division_HTML('div_FormaPagoEdicion', result.split('~')[19]);
                        F_Update_Division_HTML('div_moneda', result.split('~')[5]);
                        F_Update_Division_HTML('div_TipoTransportista', result.split('~')[36]);
                        F_Update_Division_HTML('div_TipoTransportistaEdicion', result.split('~')[37]);
                        F_Update_Division_HTML('div_codunidadpeso', result.split('~')[38]);
                        F_Update_Division_HTML('div_codunidadpesoedicion', result.split('~')[39]);
                        F_Update_Division_HTML('Div_EstadoNP', result.split('~')[40]);
                        $('#MainContent_lblTC').text(result.split('~')[6]);
                        $('#MainContent_lblTC2').text(result.split('~')[6]);
                        $('#MainContent_lblTCParalelo').text(result.split('~')[25]);
                        $('#MainContent_lblTC2Paralelo').text(result.split('~')[25]);
                        $('#MainContent_lblTCParaleloCompra').text(result.split('~')[32]);
                        $('#MainContent_lblTC2ParaleloCompra').text(result.split('~')[32]);
                        $('#MainContent_ddlSerieConsulta').val(61);
                        F_Update_Division_HTML('div_serieconsulta', result.split('~')[9]);
                        F_Update_Division_HTML('div_igv', result.split('~')[8]);
                        $('#MainContent_ddlMoneda').val(1);
                        $('#MainContent_txtProductoConsulta').val('');
                        $('#hfcodproductoconsulta').val('');
                        
      $('#MainContent_txtProductoConsulta').css('background', '#FFFFE0');
      $('#MainContent_ddlVisualizar').css('background', '#FFFFE0');
         
//            $('#MainContent_txtDestino').val('') ;
//            $('#MainContent_txtNumeroGuia').val('');
//            $('#MainContent_txtDestino').val('');
//            $('#MainContent_txtNumeroGuia').prop('readonly', true);
//            $('#MainContent_txtDestino').prop('readonly', true);
//            $('#MainContent_txtFechaTraslado').prop('readonly', true);  
//            $('#MainContent_txtNroRucTransportista').prop('readonly', true);  
//            $('#MainContent_txtTransportista').prop('readonly', true);  
//            $('#MainContent_txtDistritoTransportista').prop('readonly', true);  
//            $('#MainContent_txtDireccionTransportista').prop('readonly', true);  
//            $('#MainContent_txtPlacaTraslado').prop('readonly', false);  
//            $('#MainContent_txtMarcaGuia').prop('readonly', false);  
//            $('#MainContent_txtLicenciaGuia').prop('readonly', false);  
//            $('#MainContent_txtNuBultos').prop('readonly', true);  
//            $('#MainContent_txtPeso').prop('readonly', true);    
//            $('#MainContent_txtConductorDNI').prop('readonly', false);   
//            $('#MainContent_txtConductorRazonSocial').prop('readonly', false);   
 //desabilitado
            $('#MainContent_txtNroRucTransportista').prop("disabled", true);
            $('#MainContent_txtTransportista').prop("disabled", true);
            $('#MainContent_txtDistritoTransportista').prop("disabled", true);
            $('#MainContent_txtDireccionTransportista').prop("disabled", true);
            $('#MainContent_txtPlacaTraslado').prop("disabled", true);
            $('#MainContent_txtMarcaGuia').prop("disabled", true);
            $('#MainContent_txtLicenciaGuia').prop("disabled", true);
            $('#MainContent_txtNuBultos').prop("disabled", true);
            $('#MainContent_txtPeso').prop("disabled", true);
            $('#MainContent_txtConductorDNI').prop("disabled", true);
            $('#MainContent_txtConductorRazonSocial').prop("disabled", true);
            $('#MainContent_ddldireccionNuevaTransportista').prop("disabled", true);
            $('#MainContent_ImageButton1').prop("disabled", true);
            $('#MainContent_ImageButton2').prop("disabled", true);

            $('#MainContent_txtNumeroGuia').prop('readonly', true);
            $('#MainContent_txtDestino').prop('readonly', true);
            $('#MainContent_txtFechaTraslado').prop('readonly', true);
                       //miguel -GUIA
                       $('#MainContent_txtNombreAgencia').css('background', '#FFFFE0');
                       $('#MainContent_txtGuiaAgencia').css('background', '#FFFFE0');
                       $('#MainContent_txtClaveAgencia').css('background', '#FFFFE0');
                       $('#MainContent_ddlcodunidadpeso').css('background', '#FFFFE0');
                       $('#MainContent_ddlcodunidadpesoedicion').css('background', '#FFFFE0');
                       $('#MainContent_ddlTipoTransportista').css('background', '#FFFFE0');
                       $('#MainContent_ddlTipoTransportistaEdicion').css('background', '#FFFFE0');
                        
                         F_Update_Division_HTML('div_VendedorEdicion', result.split('~')[35]);
                         $('#MainContent_ddlVendedorEdicion').css('background', '#FFFFE0');
                         $('#MainContent_ddlSerieGuia').css('background', '#FFFFE0');
                         $('#MainContent_ddlSerieGuiaEdicion').css('background', '#FFFFE0');
                         $('#MainContent_ddlFormaPagoEdicion').css('background', '#FFFFE0');
                         $('#MainContent_ddlEstadoConsultaNP').css('background', '#FFFFE0');
                    //
                        
                        $('#MainContent_txtNumero').val(result.split('~')[7]);
                        $('#MainContent_txtVencimiento').val($('#MainContent_txtEmision').val());
                        $('#hfCodUsuario').val(result.split('~')[10]);
                        $('#hfPartida').val(result.split('~')[11]);
                        $('#hfCodSede').val(result.split('~')[12]);
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                        $('#MainContent_ddlFormaPago').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerie').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerieConsulta').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerieGuia').css('background', '#FFFFE0');
                        $('#MainContent_ddlIgv').css('background', '#FFFFE0');
                        $('#MainContent_txtAtencion').val('');
                        $('#MainContent_txtReferencia').val('');

                        F_Update_Division_HTML('div_TipoDoc', result.split('~')[13]);
                        F_Update_Division_HTML('div_TipoDoc2', result.split('~')[14]);
                        $('#MainContent_ddlTipoDoc').val(1);
                        $('#MainContent_ddlTipoDoc2').val(1);
                        $('#hfCodigoTemporal').val(0);
                        $('#MainContent_ddlTipoDoc').css('background', '#FFFFE0');
                        $('#MainContent_ddlTipoDoc2').css('background', '#FFFFE0');
                        P_ImpresionImpresora = result.split('~')[26];
                        P_ImpresionTicketera = result.split('~')[27];
                        F_Update_Division_HTML('div_Vendedor', result.split('~')[33]);
                        $('#MainContent_ddlVendedor').css('background', '#FFFFE0');
                        $('#MainContent_ddlVendedor').val(result.split('~')[34]);

                        if (P_ImpresionImpresora === "0")
                            $('#td_Impresora').prop("style").display="none";

                        if (P_ImpresionTicketera === "0")
                            $('#td_Ticketera').prop("style").display="none";


                        if ($("#MainContent_ddlTipoDoc2").val()==16)
                             {
                             $('#MainContent_ddlEstadoConsultaNP').prop('disabled', false);
                             $('#MainContent_ddlEstadoConsultaNP').val(5);
                             $('#MainContent_txtProductoConsulta').prop('disabled', true);
                             $('#MainContent_chkProductoConsulta').prop('disabled', true);
                             $('#MainContent_txtProductoConsulta').val('');
                             $('#hfcodproductoconsulta').val('0');
                             }else if ($("#MainContent_ddlTipoDoc2").val()==15)
                             {
                             $('#MainContent_txtProductoConsulta').prop('disabled', false);
                             $('#MainContent_chkProductoConsulta').prop('disabled', false);
                             $('#MainContent_ddlEstadoConsultaNP').prop('disabled', true);
                             $('#MainContent_ddlEstadoConsultaNP').val(0);
                             }else{
                             $('#MainContent_txtProductoConsulta').prop('disabled', true);
                             
                             $('#MainContent_chkProductoConsulta').prop('disabled', true);
                             $('#MainContent_ddlEstadoConsultaNP').prop('disabled', true);
                             $('#MainContent_ddlEstadoConsultaNP').val(0);
                             $('#MainContent_txtProductoConsulta').val('');
                             $('#hfcodproductoconsulta').val('0');
                             }


                             //direcciontemporal
                       $('#MainContent_ddldireccionNueva').css('background', '#FFFFE0');
                       $('#MainContent_ddldireccionNuevaTransportista').css('background', '#FFFFE0');
                       $('#MainContent_ddldireccionNuevaTransportistaEdicion').css('background', '#FFFFE0');
                       $('#MainContent_ddldireccionNuevaDestinoEdicion').css('background', '#FFFFE0');
                       $('#MainContent_ddldireccionNuevaDestino').css('background', '#FFFFE0');
                       $('#MainContent_txtObservacionGuia').css('background', '#FFFFE0');
                       $('#MainContent_txtDistritoMultiple').css('background', '#FFFFE0');
                       $('#MainContent_txtDireccionMultiple').css('background', '#FFFFE0');
                       $('#MainContent_txtEmailMultiple1').css('background', '#FFFFE0');
                       $('#MainContent_txtEmailMultiple2').css('background', '#FFFFE0');
                       $('#MainContent_txtGuiaAgencia').css('background', '#FFFFE0');
                       $('#MainContent_txtClaveAgencia').css('background', '#FFFFE0');
                       $('#MainContent_txtObservacionGuiaEdicion').css('background', '#FFFFE0');
                       $('#MainContent_txtObservacionGuiaEdicion').css('background', '#FFFFE0');
                       $('#MainContent_txtObservacionGuiaEdicion').css('background', '#FFFFE0');

                        //Campo KM solo para mercedes
                        if (result.split('~')[24] === "0") {
                            $("#div_KM").prop("style").display="none";
                            $("#div_txtKM").prop("style").display="none";
                            //$("#tr_KMEdicion").prop("style").display="none";
                            }

                        F_Update_Division_HTML('div_SerieNV', result.split('~')[16]);
                        $('#MainContent_ddlSerieNV').val(62);
                        $('#MainContent_ddlSerieNV').css('background', '#FFFFE0');
                        F_Update_Division_HTML('div_SerieCT', result.split('~')[17]);
                        $('#MainContent_ddlSerieCT').val(5);
                        $('#MainContent_ddlSerieCT').css('background', '#FFFFE0');
                        //miguel - guia
                         $('#MainContent_txtNroRucTransportistaEdicion').css('background', '#FFFFE0');
                            $('#MainContent_txtDistritoTransportistaEdicion').css('background', '#FFFFE0');
                            $('#MainContent_txtConductorDNIEdicion').css('background', '#FFFFE0');
                             $('#MainContent_txtConductorRazonSocialEdicion').css('background', '#FFFFE0');

                        F_CambioSerie();
                        //F_Mostrar_CorrelativoVarios(1);
                        $('.ccsestilo').css('background', '#FFFFE0');


                        MostrarUMConsultas = Number(result.split('~')[21]);
                        RedondeoAM = Number(result.split('~')[22]);
                        ValidarStock = Number(result.split('~')[23]);

                        P_EDITAR_PRECIOS = result.split('~')[28];
                        F_CambioTipoDoc();
                        $('#MainContent_txtCorreo').val('');
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

function F_Mostrar_Correlativo(CodDoc, Campo) {

    var arg;

    try {
        var SerieDoc = '';

        if (CodDoc==10)
           SerieDoc=$("#MainContent_ddlSerieGuia option:selected").text();
        else            
            SerieDoc=$("#MainContent_ddlSerie option:selected").text();
//        if (CodDoc==1 && ($("#MainContent_ddlSerie option:selected").text() == '001' | $("#MainContent_ddlSerie option:selected").text() == '003'  | $("#MainContent_ddlSerie option:selected").text() == 'F001'))
//        $("#MainContent_ddlMoneda").val(1)
//        else
//        $("#MainContent_ddlMoneda").val(2)

        var objParams = {

            Filtro_CodDoc: CodDoc,
            Filtro_SerieDoc: SerieDoc
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
                        if (CodDoc==1) {
                        $('#MainContent_txtNumero').val(result.split('~')[2]);
                        $('#hfNroItemsMax').val(result.split('~')[4]);
                        }
                        else {
                            if (Campo == 'Edicion')
                                $('#MainContent_txtNumeroGuiaEdicion').val(result.split('~')[2]);
                                else
                                $('#MainContent_txtNumeroGuia').val(result.split('~')[2]);
                        }
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

function F_Mostrar_CorrelativoVarios(CodDoc) {

    var arg;

    try {
        var SerieDoc = $("#MainContent_ddlSerie option:selected").text();

        var objParams = {
            Filtro_CodDoc: CodDoc,
            Filtro_SerieDoc: SerieDoc
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

                    if (str_resultado_operacion == "1") {
                        $('#MainContent_txtNumero').val(result.split('~')[2]);

                        $('#MainContent_chkImpresion').prop('checked', false);
                        $('#MainContent_chkImpresionTicket').prop('checked', false);

                        $('#hfNroItemsMax').val(result.split('~')[4]);

                        if (result.split('~')[3] === 'IMP')
                            $('#MainContent_chkImpresion').prop('checked', true);
                        else
                            $('#MainContent_chkImpresionTicket').prop('checked', true);

                        }
                    else {
                        alertify.log(str_mensaje_operacion);
                        }
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
    var chkActivo = 0;

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

         if ($('#MainContent_chkActivos').is(':checked'))
            CodTipoProducto=3;

        var objParams =
            {
                Filtro_DscProducto: $('#MainContent_txtArticulo').val(),
                Filtro_CodTipoProducto: CodTipoProducto,
                Filtro_CodMoneda: $('#MainContent_ddlMoneda').val(),
                Filtro_Servicio: chkServicio,
                Filtro_NotaPedido: chkNotaPedido,
                Filtro_CodTipoDoc: $('#MainContent_ddlTipoDoc').val(),
                Filtro_CodCliente: $('#hfCodCtaCte').val(),
                Filtro_CodFamilia : '0',
                Filtro_Ubicacion : ''
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
                         $('#lblCantidadProducto').text(F_Numerar_Grilla("grvConsultaArticulo",'hlkCodigo'));
                          $('#MainContent_grvConsultaArticulo_imgAgregar_0').select();
                       
                       ctrlPosActual = '#MainContent_grvConsultaArticulo_imgAgregar_0';
                        ctrlPosActualBuffer = ctrlPosActual;
                        $(ctrlPosActual).closest("tr").children('td,th').css("background-color","#ffec85")
                        $(ctrlPosActual).focus();
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
 
//funciones transportista  miguel

function F_BuscarDireccionesTransportista() {
if (!F_SesionRedireccionar(AppSession)) return false;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDireccion_ListarXCodDistritoCliente_AutoComplete',
        data: "{'Direccion':'','CodDepartamento':'" + $('#hfCodDepartamentoTransportista').val() + "','CodProvincia':'" + $('#hfCodProvinciaTransportista').val() + "','CodDistrito':'" + $('#hfCodDistritoTransportista').val() + "','CodCtaCte':'" + $('#hfCodCtaCteTransportista').val() + "'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                $('#MainContent_dllDireccionTransportista').empty();
                $.each(data.rows, function (index, item) {
                    $('#MainContent_dllDireccionTransportista').append($("<option></option>").val(item.CodDireccion).html(item.Direccion));
                });
                if (data.rows.length > 0) {
                    if ($('#hfCodDireccionDefectoTransportista').val() != '0') {
                        $('#MainContent_dllDireccionTransportista').val($('#hfCodDireccionDefectoTransportista').val());
                    }
                    $('#MainContent_txtDireccionTransportista').val($("#MainContent_dllDireccionTransportista option:selected").text());
                    if ($('#MainContent_txtDireccionTransportista').val() == "")
                    {
                        $('#MainContent_dllDireccionTransportista').val($("#MainContent_dllDireccionTransportista option:first").val());
                        $('#hfCodDireccionTransportista').val($("#MainContent_dllDireccionTransportista option:first").val());          
                        $('#MainContent_txtDireccionTransportista').val($("#MainContent_dllDireccionTransportista option:selected").text());
                    }
                    $('#hfCodDireccionTransportista').val($("#MainContent_dllDireccionTransportista").val());
                }
            }
            catch (x) { alertify.log('El Producto no tiene Imagenes'); }
            MostrarEspera(false);
        },
        complete: function () {
            if (($('#hfCodDireccionTransportista').val() == '' | $('#hfCodDireccionTransportista').val() == '0') && $('#hfCodCtaCteTransportista').val() != 0)
            {
                alertify.log('NO HAY DIRECCION PARA EL DISTRITO ESPECIFICADO')
                $('#MainContent_txtDireccionTransportista').val('');
                $('#hfDireccionTransportista').val('');
                $('#hfCodDireccionTransportista').val('0');
                //$('#MainContent_txtCorreo').val('');
            }

        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });

    return false;
}

function F_ValidaRucTransportista() {
if (!F_SesionRedireccionar(AppSession)) return false;
APITransportista = '';
ConsultandoPadronTransportista = false;
//F_LimpiarHiddenTrasportista();
    if ($('#MainContent_txtNroRucTransportista').val().length > 0)
    {
        if ($('#MainContent_txtNroRucTransportista').val().trim() === $('#hfNroRucTransportista').val().trim() & 
            $('#MainContent_txtTransportista').val().trim() === $('#hfTransportista').val().trim() & 
            $('#MainContent_txtNroRucTransportista').val().trim() != "")
        return false;

    var Index= $('#MainContent_txtNroRucTransportista').val().indexOf('-');
    var Cliente = $('#MainContent_txtNroRucTransportista').val();

    if ($('#MainContent_txtNroRucTransportista').val() != "1" & Index ==-1 ) {
       if (isNaN($('#MainContent_txtNroRucTransportista').val()) | !ValidarRuc($('#MainContent_txtNroRucTransportista').val()))
        {
            $('#MainContent_txtNroRucTransportista').val('');
            $('#MainContent_txtNroRucTransportista').focus();
            alertify.log('ERROR EN RUC');
            return false;
        }
    } else {
    $('#MainContent_txtNroRucTransportista').val(Cliente.split('-')[0].trim());
    }

        if ($('#hfCodCtaCteTransportista').val() != '0') 
            return true;

        $('#MainContent_txtTransportista').val('');
        $('#hfTransportista').val('');

        //DNI
        if ($('#MainContent_txtNroRucTransportista').val().length == 8)
        {
//            if ($('#MainContent_ddlTipoDoc').val() === '1') {
//                $('#MainContent_txtNroRuc').val('');
//                $('#MainContent_txtNroRuc').focus();
//                return true;
//            }

//            var NroRuc = $('#MainContent_txtNroRuc').val();
//            F_BuscarDatosPorRucDni($('#MainContent_txtNroRuc').val());
            alertify.log('RUC INVALIDO');
            return true;
        }
        else
        {
            //RUC
            if ($('#MainContent_txtNroRucTransportista').val().length == 11 & $('#MainContent_txtNroRucTransportista').val() != '55555555555')
            {
                $('#MainContent_txtTransportista').focus();
                F_BuscarPadronSunatTransportista();
                return true;
            }
            else
            {
                //CLIENTE VARIOS
                if ($('#MainContent_txtNroRucTransportista').val() == '1' | $('#MainContent_txtNroRucTransportista').val() === '55555555555')
                {
                    alertify.log('NRO. RUC TRANSPORTISTA INVALIDO'); 
                    $('#MainContent_txtNroRucTransportista').val('');
                    F_LimpiarCamposTransportista();
                    $('#MainContent_txtNroRucTransportista').focus();
                    return true;
                }
            }
        }


    }
    else
    {
        if ($('#MainContent_txtNroRucTransportista').val() != $('#hfNroRuc').val())
        {
            F_LimpiarCamposTransportista();
            return true;
        }
    }
   return false;
}

var APITransportista = ""
var ubigeoTransportista="";
var ConsultandoPadronTransportista = false;
function F_BuscarPadronSunatTransportista() {

    if (ConsultandoPadronTransportista == true)
        return true;

    ConsultandoPadronTransportista = true;

        $('#td_loadingTransportista').css('display', 'block');
        var NroRuc = $('#MainContent_txtNroRucTransportista').val();
//        F_LimpiarCamposTransportista();
        $('#MainContent_txtNroRucTransportista').val(NroRuc);
         if (APITransportista == "") {
         $('#hfCodDepartamentoTransportista').val("");
         $('#hfCodProvinciaTransportista').val("");
         $('#hfCodDistritoTransportista').val("");
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCCuentaCorriente_PadronSunat',
                data: "{'NroRuc':'" + $('#MainContent_txtNroRucTransportista').val() +"','CodTipoCtaCte':'2'}",
                dataType: "json",
                async: true,
                success: function (dbObject) {
                ConsultandoPadronTransportista = false;
                var data = dbObject.d;
                try {
                // condiciona joel:si en la base de datos no se encuentra ninguna condicion de ruc se manda para la apisunat
                    if (data.length > 0) {
                    $('#td_loadingTransportista').css('display', 'none');
                    $('#hfCodCtaCteTransportista').val(data[0].split(',')[0]); 
                    $('#hfTransportista').val(data[0].split(',')[1]); //razon social
                    $('#MainContent_txtNroRucTransportista').val(data[0].split(',')[8]);
                    $('#hfNroRucTransportista').val(data[0].split(',')[8]);
                    $('#MainContent_txtTransportista').val(data[0].split(',')[1]);
                    $('#hfTransportista').val(data[0].split(',')[1]);
                    $('#MainContent_txtDireccionTransportista').val(data[0].split(',')[2]);
                    //$('#MainContent_txtDestino').val(data[0].split(',')[2]+ ' ' + data[0].split(',')[4]);
                    $('#MainContent_txtDistritoTransportista').val(data[0].split(',')[4]);
                    $('#hfCodDireccionTransportista').val('0');
                    $('#hfCodDepartamentoTransportista').val(data[0].split(',')[5]);
                    $('#hfCodProvinciaTransportista').val(data[0].split(',')[6]);
                    $('#hfCodDistritoTransportista').val(data[0].split(',')[7]);
                    $('#hfDistritoTransportista').val(data[0].split(',')[4]);
                   // $('#txtSaldoCreditoFavor').text(data[0].split(',')[12]);
                    //$('#hfSaldoCreditoFavor').val(data[0].split(',')[12].replace("S/", "").replace(" ", ""));
                    $('#hfCodDireccionDefectoTransportista').val(data[0].split(',')[14]);

                    if ($('#MainContent_txtTransportista').val().trim().length > 0 & $('#hfCodDepartamentoTransportista').val() === "0")
                    { alertify.error('ESPECIFIQUE LA DIRECCION Y DISTRITO, PORQUE SUNAT NO ESTA PROVEYENDO ESTA INFORMACION'); }

                    F_BuscarDireccionesTransportista();
                    //F_BuscarDireccionPorDefecto();
                    }else{
                     APITransportista = "Usuario No Encontrado";
                        console.log(APITransportista);
                        F_API_RUC_Buscar();
                        F_BuscarPadronSunatTransportista();
                       
                    }
                }
                catch (x) { 
                    //alertify.log(x);
                    alertify.log('Por alguna razon el cliente no fue encontrado');
                    $('#td_loadingTransportista').css('display', 'none');
                }
            },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
 }; 
  if (APITransportista == "Usuario No Encontrado") {
        //api sunat 
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url:  $('#hfurlapisunat').val() + $('#MainContent_txtNroRucTransportista').val() + $('#hftokenapisunat').val(),
            dataType: "json",
            async: true,
            success: function (dbObject) {
                MostrarEspera(true);
                var data = dbObject.d;                                
                try {
                APITransportista = "";
                $('#td_loadingTransportista').css('display', 'none');
                    $('#MainContent_txtTransportista').val(dbObject.razonSocial); //razon social
                    $('#MainContent_txtNombreComercial').val(dbObject.razonSocial); //razon social
                    ubigeoTransportista=dbObject.ubigeo;
                    if (ubigeoTransportista==null){
                     toastr.warning("La sunat no ofrece direccion ni distrito para los ruc 10,debe colocarlo usted mismo.");
                     }
                    var direccion = dbObject.direccion;
                    var distrito = dbObject.departamento + ' ' + dbObject.provincia + ' ' + dbObject.distrito;
                    $('#MainContent_txtDireccionTransportista').val(direccion.replace(distrito, ""));
                   // $('#MainContent_txtDestino').val(direccion);
                   // $('#MainContent_txtDireccionEnvio').val(direccion.replace(distrito, ""));
                    $('#MainContent_txtDistritoTransportista').val(distrito);
                    $('#hfDistritoTransportista').val(distrito);
                  //  $('#hfUbigeo').val(dbObject.ubigeo);
                     $('#hfTransportista').val(dbObject.razonSocial); //razon social
                     $('#hfNroRucTransportista').val(dbObject.ruc);
                     F_GuardarDireccion($('#MainContent_txtNroRucTransportista').val(),'#hfCodigoTemporal',$('#hfCodTransportista').val()
            ,'#MainContent_txtTransportista',1,ubigeoTransportista,direccion.replace(distrito, ""),'#MainContent_ddldireccionNuevaTransportista','',1);
                }
                catch (x) { }
                MostrarEspera(false);
            },
            error: function (response) {
                
                if(response.responseText!=''){
                alertify.log(response.responseText);
                }else{
                alertify.log('Verificar conexión');
                $('#td_loadingTransportista').css('display', 'none');
                }
            },
            failure: function (response) {
               alertify.log(response.responseText);
            }
        });
    }


return true;
}

function F_BuscarDireccionNuevoTransportista() {
    if (!F_SesionRedireccionar(AppSession)) return false;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_Direccion_Buscar', 
        data: "{'Ubigeo':'" + ubigeoTransportista + "'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            $('#hfCodDepartamentoTransportista').val(data[0].split(',')[0]);
            $('#hfCodProvinciaTransportista').val(data[0].split(',')[1]);
            $('#hfCodDistritoTransportista').val(data[0].split(',')[2]);
            return true;

        },
        complete: function () {
            if (($('#hfRegion').val() == '' | $('#hfProvincia').val() == '') && $('#hfDistrito').val() == '') {
                toastr.warning('NO HAY DIRECCION PARA EL DISTRITO ESPECIFICADO')
                $('#MainContent_txtDireccionTransportista').val('');
                $('#hfDireccionTransportista').val('');
                $('#hfCodDireccionTransportista').val('0');
               // $('#MainContent_txtCorreo').val('');
            }

        },
        error: function (response) {
            toastr.warning(response.responseText);
        },
        failure: function (response) {
            toastr.warning(response.responseText);
        }
    });

    return false;
}

function F_LimpiarHiddenTrasportista() {
    $('#hfCodTransportista').val(0);
    $('#hfNroRucTransportista').val('');
    $('#hfCodCtaCteTransportista').val(0);
    $('#hfTransportista').val('');
    $('#hfDireccionTransportista').val('');
    $('#hfCodDireccionTransportista').val(0);
    $('#hfCodDireccionDefectoTransportista').val(0);
    $('#hfCodDepartamentoTransportista').val(0);
    $('#hfCodProvinciaTransportista').val(0);
    $('#hfCodDistritoTransportista').val(0);
    $('#hfDistritoTransportista').val('');
}

function F_LimpiarCamposTransportista() {
    if (!F_SesionRedireccionar(AppSession)) return false;

    $('#MainContent_txtRazonSocialTransportista').val('');
    $('#MainContent_txtDistritoTransportista').val('');
    $('#MainContent_txtDireccionTransportista').val('');
    $('#MainContent_txtDistritoTransportista').val('');
    $('#MainContent_txtNombreComercial').val('');

    $('#hfRegionTransportista').val('0');
    $('#hfProvinciaTransportista').val('0');
    $('#hfDistritoTransportista').val('0');

//    $('#hftokenapisunat').val('');
//    $('#hfurlapisunat').val('');
    return true;
}

function F_LimpiarHiddenTrasportistaEdicion() {
    
    $('#hfNroRucTransportistaEdicion').val('');
    $('#hfCodCtaCteTransportistaEdicion').val(0);
    $('#hfTransportistaEdicion').val('');
    $('#hfDireccionTransportistaEdicion').val('');
    $('#hfCodDireccionTransportistaEdicion').val(0);
    $('#hfCodDireccionDefectoTransportistaEdicion').val(0);
    $('#hfCodDepartamentoTransportistaEdicion').val(0);
    $('#hfCodProvinciaTransportistaEdicion').val(0);
    $('#hfCodDistritoTransportistaEdicion').val(0);
    $('#hfDistritoTransportistaEdicion').val('');
}

function F_BuscarDireccionesTransportistaEdicion() {
if (!F_SesionRedireccionar(AppSession)) return false;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDireccion_ListarXCodDistritoCliente_AutoComplete',
        data: "{'Direccion':'','CodDepartamento':'" + $('#hfCodDepartamentoTransportistaEdicion').val() + "','CodProvincia':'" + $('#hfCodProvinciaTransportistaEdicion').val() + "','CodDistrito':'" + $('#hfCodDistritoTransportistaEdicion').val() + "','CodCtaCte':'" + $('#hfCodCtaCteTransportistaEdicion').val() + "'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                $('#MainContent_dllDireccionTransportistaEdicion').empty();
                $.each(data.rows, function (index, item) {
                    $('#MainContent_dllDireccionTransportistaEdicion').append($("<option></option>").val(item.CodDireccion).html(item.Direccion));
                });
                if (data.rows.length > 0) {
                    if ($('#hfCodDireccionDefectoTransportistaEdicion').val() != '0') {
                        $('#MainContent_dllDireccionTransportistaEdicion').val($('#hfCodDireccionDefectoTransportistaEdicion').val());
                    }
                    $('#MainContent_txtDireccionTransportistaEdicion').val($("#MainContent_dllDireccionTransportistaEdicion option:selected").text());
                    if ($('#MainContent_txtDireccionTransportistaEdicion').val() == "")
                    {
                        $('#MainContent_dllDireccionTransportistaEdicion').val($("#MainContent_dllDireccionTransportistaEdicion option:first").val());
                        $('#hfCodDireccionTransportistaEdicion').val($("#MainContent_dllDireccionTransportistaEdicion option:first").val());          
                        $('#MainContent_txtDireccionTransportistaEdicion').val($("#MainContent_dllDireccionTransportistaEdicion option:selected").text());
                    }
                    $('#hfCodDireccionTransportistaEdicion').val($("#MainContent_dllDireccionTransportistaEdicion").val());
                }
            }
            catch (x) { alertify.log('El Producto no tiene Imagenes'); }
            MostrarEspera(false);
        },
        complete: function () {
            if (($('#hfCodDireccionTransportistaEdicion').val() == '' | $('#hfCodDireccionTransportistaEdicion').val() == '0') && $('#hfCodCtaCteTransportistaEdicion').val() != 0)
            {
                alertify.log('NO HAY DIRECCION PARA EL DISTRITO ESPECIFICADO')
                $('#MainContent_txtDireccionTransportistaEdicion').val('');
                $('#hfDireccionTransportistaEdicion').val('');
                $('#hfCodDireccionTransportistaEdicion').val('0');
                //$('#MainContent_txtCorreo').val('');
            }

        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });

    return false;
}

function F_ValidaRucTransportistaEdicion() {
if (!F_SesionRedireccionar(AppSession)) return false;
  APITransportistaEdicion = '';
  F_LimpiarHiddenTrasportistaEdicion();
  ConsultandoPadronTransportistaEdicion = false;
    if ($('#MainContent_txtNroRucTransportistaEdicion').val().length > 0)
    {
        if ($('#MainContent_txtNroRucTransportistaEdicion').val().trim() === $('#hfNroRucTransportistaEdicion').val().trim() & 
            $('#MainContent_txtTransportistaEdicion').val().trim() === $('#hfTransportistaEdicion').val().trim() & 
            $('#MainContent_txtNroRucTransportistaEdicion').val().trim() != "")
        return false;

    var Index= $('#MainContent_txtNroRucTransportistaEdicion').val().indexOf('-');
    var Cliente = $('#MainContent_txtNroRucTransportistaEdicion').val();

    if ($('#MainContent_txtNroRucTransportistaEdicion').val() != "1" & Index ==-1 ) {
       if (isNaN($('#MainContent_txtNroRucTransportistaEdicion').val()) | !ValidarRuc($('#MainContent_txtNroRucTransportistaEdicion').val()))
        {
            $('#MainContent_txtNroRucTransportistaEdicion').val('');
            $('#MainContent_txtNroRucTransportistaEdicion').focus();
            alertify.log('ERROR EN RUC');
            return false;
        }
    } else {
    $('#MainContent_txtNroRucTransportistaEdicion').val(Cliente.split('-')[0].trim());
    }

        if ($('#hfCodCtaCteTransportistaEdicion').val() != '0') 
            return true;

        $('#MainContent_txtTransportistaEdicion').val('');
        $('#hfTransportistaEdicion').val('');

        //DNI
        if ($('#MainContent_txtNroRucTransportistaEdicion').val().length == 8)
        {
            alertify.log('RUC INVALIDO');
            return true;
        }
        else
        {
            //RUC
            if ($('#MainContent_txtNroRucTransportistaEdicion').val().length == 11 & $('#MainContent_txtNroRucTransportistaEdicion').val() != '55555555555')
            {
                $('#MainContent_txtTransportistaEdicion').focus();
                F_BuscarPadronSunatTransportistaEdicion();
                return true;
            }
            else
            {
                //CLIENTE VARIOS
                if ($('#MainContent_txtNroRucTransportistaEdicion').val() == '1' | $('#MainContent_txtNroRucTransportistaEdicion').val() === '55555555555')
                {
                    alertify.log('NRO. RUC TRANSPORTISTA INVALIDO'); 
                    $('#MainContent_txtNroRucTransportistaEdicion').val('');
                    F_LimpiarCamposTransportistaEdicion();
                    $('#MainContent_txtNroRucTransportistaEdicion').focus();
                    return true;
                }
            }
        }


    }
    else
    {
//        if ($('#MainContent_txtNroRucTransportistaEdicion').val() != $('#hfNroRuc').val())
//        {
//            F_LimpiarCamposTransportista();
//            return true;
//        }
    }
   return false;
}

var APITransportistaEdicion = ""
var ubigeoTransportistaEdicion="";
var ConsultandoPadronTransportistaEdicion = false;
function F_BuscarPadronSunatTransportistaEdicion() {

    if (ConsultandoPadronTransportistaEdicion == true)
        return true;

    ConsultandoPadronTransportistaEdicion = true;

        $('#td_loadingTransportistaEdicion').css('display', 'block');
        var NroRuc = $('#MainContent_txtNroRucTransportistaEdicion').val();
        F_LimpiarCamposTransportistaEdicion();
        $('#MainContent_txtNroRucTransportistaEdicion').val(NroRuc);
         if (APITransportistaEdicion == "") {
         $('#hfCodDepartamentoTransportistaEdicion').val("");
         $('#hfCodProvinciaTransportistaEdicion').val("");
         $('#hfCodDistritoTransportistaEdicion').val("");
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCCuentaCorriente_PadronSunat',
                data: "{'NroRuc':'" + $('#MainContent_txtNroRucTransportistaEdicion').val() +"','CodTipoCtaCte':'2'}",
                dataType: "json",
                async: true,
                success: function (dbObject) {
                ConsultandoPadronTransportistaEdicion = false;
                var data = dbObject.d;
                try {
                // condiciona joel:si en la base de datos no se encuentra ninguna condicion de ruc se manda para la apisunat
                    if (data.length > 0) {
                    $('#td_loadingTransportistaEdicion').css('display', 'none');
                    $('#hfCodCtaCteTransportistaEdicion').val(data[0].split(',')[0]); 
                    $('#hfTransportistaEdicion').val(data[0].split(',')[1]); //razon social
                    $('#MainContent_txtNroRucTransportistaEdicion').val(data[0].split(',')[8]);
                    $('#hfNroRucTransportistaEdicion').val(data[0].split(',')[8]);
                    $('#MainContent_txtTransportistaEdicion').val(data[0].split(',')[1]);
                    $('#hfTransportistaEdicion').val(data[0].split(',')[1]);
                    $('#MainContent_txtDireccionTransportistaEdicion').val(data[0].split(',')[2]);
                    //$('#MainContent_txtDestino').val(data[0].split(',')[2]+ ' ' + data[0].split(',')[4]);
                    $('#MainContent_txtDistritoTransportistaEdicion').val(data[0].split(',')[4]);
                    $('#hfCodDireccionTransportistaEdicion').val('0');
                    $('#hfCodDepartamentoTransportistaEdicion').val(data[0].split(',')[5]);
                    $('#hfCodProvinciaTransportistaEdicion').val(data[0].split(',')[6]);
                    $('#hfCodDistritoTransportistaEdicion').val(data[0].split(',')[7]);
                    $('#hfDistritoTransportistaEdicion').val(data[0].split(',')[4]);
                   // $('#txtSaldoCreditoFavor').text(data[0].split(',')[12]);
                    //$('#hfSaldoCreditoFavor').val(data[0].split(',')[12].replace("S/", "").replace(" ", ""));
                    $('#hfCodDireccionDefectoTransportistaEdicion').val(data[0].split(',')[14]);

                    if ($('#MainContent_txtTransportistaEdicion').val().trim().length > 0 & $('#hfCodDepartamentoTransportistaEdicion').val() === "0")
                    { alertify.error('ESPECIFIQUE LA DIRECCION Y DISTRITO, PORQUE SUNAT NO ESTA PROVEYENDO ESTA INFORMACION'); }

                    F_BuscarDireccionesTransportistaEdicion();
                    //F_BuscarDireccionPorDefecto();
                    }else{
                     APITransportistaEdicion = "Usuario No Encontrado";
                        console.log(APITransportistaEdicion);
                        F_API_RUC_Buscar();
                        F_BuscarPadronSunatTransportistaEdicion();
                       
                    }
                }
                catch (x) { 
                    //alertify.log(x);
                    alertify.log('Por alguna razon el cliente no fue encontrado');
                    $('#td_loadingTransportistaEdicion').css('display', 'none');
                }
            },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
 }; 
  if (APITransportistaEdicion == "Usuario No Encontrado") {
        //api sunat 
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url:  $('#hfurlapisunat').val() + $('#MainContent_txtNroRucTransportistaEdicion').val() + $('#hftokenapisunat').val(),
            dataType: "json",
            async: true,
            success: function (dbObject) {
                MostrarEspera(true);
                var data = dbObject.d;                                
                try {
                APITransportistaEdicion = "";
                $('#td_loadingTransportistaEdicion').css('display', 'none');
                    $('#MainContent_txtTransportistaEdicion').val(dbObject.razonSocial); //razon social
                    $('#MainContent_txtNombreComercialEdicion').val(dbObject.razonSocial); //razon social
                    ubigeoTransportistaEdicion=dbObject.ubigeo;
                    if (ubigeoTransportistaEdicion==null){
                     toastr.warning("La sunat no ofrece direccion ni distrito para los ruc 10,debe colocarlo usted mismo.");
                     }
                    var direccion = dbObject.direccion;
                    var distrito = dbObject.departamento + ' ' + dbObject.provincia + ' ' + dbObject.distrito;
                    $('#MainContent_txtDireccionTransportistaEdicion').val(direccion.replace(distrito, ""));
                   // $('#MainContent_txtDestino').val(direccion);
                   // $('#MainContent_txtDireccionEnvio').val(direccion.replace(distrito, ""));
                    $('#MainContent_txtDistritoTransportistaEdicion').val(distrito);
                    $('#hfDistritoTransportistaEdicion').val(distrito);
                  //  $('#hfUbigeo').val(dbObject.ubigeo);
                     $('#hfTransportistaEdicion').val(dbObject.razonSocial); //razon social
                     $('#hfNroRucTransportistaEdicion').val(dbObject.ruc);
                   F_BuscarDireccionNuevoTransportistaEdicion();
                }
                catch (x) { }
                MostrarEspera(false);
            },
            error: function (response) {
                
                if(response.responseText!=''){
                alertify.log(response.responseText);
                }else{
                alertify.log('Verificar conexión');
                $('#td_loadingTransportistaEdicion').css('display', 'none');
                }
            },
            failure: function (response) {
               alertify.log(response.responseText);
            }
        });
    }


return true;
}

function F_LimpiarCamposTransportistaEdicion() {
    if (!F_SesionRedireccionar(AppSession)) return false;

    $('#MainContent_txtRazonSocialTransportistaEdicion').val('');
    $('#MainContent_txtDistritoTransportistaEdicion').val('');
    $('#MainContent_txtDireccionTransportistaEdicion').val('');
    $('#MainContent_txtDistritoTransportistaEdicion').val('');
    $('#MainContent_txtNombreComercialEdicion').val('');

    $('#hfRegionTransportista').val('0');
    $('#hfProvinciaTransportista').val('0');
    $('#hfDistritoTransportista').val('0');
    $('#hfCodCtaCteTransportista').val('0');

//    $('#hftokenapisunat').val('');
//    $('#hfurlapisunat').val('');
    return true;
}

function F_BuscarDireccionNuevoTransportistaEdicion() {
    if (!F_SesionRedireccionar(AppSession)) return false;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_Direccion_Buscar', 
        data: "{'Ubigeo':'" + ubigeoTransportistaEdicion + "'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            $('#hfCodDepartamentoTransportistaEdicion').val(data[0].split(',')[0]);
            $('#hfCodProvinciaTransportistaEdicion').val(data[0].split(',')[1]);
            $('#hfCodDistritoTransportistaEdicion').val(data[0].split(',')[2]);
            return true;

        },
        complete: function () {
            if (($('#hfRegionTransportistaEdicion').val() == '' | $('#hfProvinciaTransportistaEdicion').val() == '') && $('#hfDistritoTransportistaEdicion').val() == '') {
                toastr.warning('NO HAY DIRECCION PARA EL DISTRITO ESPECIFICADO')
                $('#MainContent_txtDireccionTransportistaEdicion').val('');
                $('#hfDireccionTransportista').val('');
                $('#hfCodDireccionTransportista').val('0');
               // $('#MainContent_txtCorreo').val('');
            }

        },
        error: function (response) {
            toastr.warning(response.responseText);
        },
        failure: function (response) {
            toastr.warning(response.responseText);
        }
    });

    return false;
}

//-----------------------------

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

    //validar cantidad maxima de items
    if (Number($('#hfNroItemsMax').val()) > 0) {
        if ((Number($('#hfNroItems').val()) + 1) <= (Number($('#hfNroItemsMax').val()))) {

        } else {
            alertify.log('YA SE ALCANZÓ EL NRO MAXIMO DE ITEMS (' + $('#hfNroItemsMax').val() + ')');
            return false;        
        }

    }
    
    var txtCantidad = '#' + ControlID;
    var chkOK = txtCantidad.replace('txtCantidad', 'chkOK');
    var txtPrecio = txtCantidad.replace('txtCantidad', 'txtPrecio');
    var txtDescuento = txtCantidad.replace('txtCantidad', 'txtDescuento');
    var lblcodProducto = txtCantidad.replace('txtCantidad', 'lblcodproducto');
    var hfStock = txtCantidad.replace('txtCantidad', 'hfStock');
      
    if ($(txtCantidad).val() == '')
    return false;

    if(F_ValidarAgregar($(lblcodProducto).text())==false)
    {
        $(txtCantidad).val('');
        $(txtPrecio).val('');
        $(txtDescuento).val('');
        $(chkOK).prop('checked',false);
        return false;
    }
  
 
      
    var Stock = $(hfStock).val();

    if ($('#MainContent_chkNotaPedido').is(':checked')) {
        if ($(chkOK).is(':checked') && parseFloat($(txtCantidad).val()) > parseFloat(Stock) && $("#MainContent_ddlTipoDoc").val() != 15) {
            if (ValidarStock == 1)
            {
                alertify.log("Stock insuficiente");
                $(txtCantidad).val('');
                $(txtDescuento).val('');
                $(txtPrecio).val('');
                $(txtCantidad).prop('disabled', true);
                $(txtDescuento).prop('disabled', true);
//                $(txtPrecio).prop('disabled', true);
                $(chkOK).prop('checked', false);
                return false;
            }
        }
    }
    else {
        if ($('#MainContent_chkServicios').is(':checked') == false && $(chkOK).is(':checked')  && parseFloat($(txtCantidad).val()) > parseFloat(Stock)  && $("#MainContent_ddlTipoDoc").val() != 15 ) {
            if (ValidarStock == 1)
            {   
                if (parseFloat(Stock) <= 0)
                {
                    alertify.log("NO TIENE STOCK");
                    $(txtCantidad).val('');
                    $(txtDescuento).val('');
                    $(txtPrecio).val('');
                    $(txtCantidad).prop('disabled', true);
                    $(txtDescuento).prop('disabled', true);
                    $(txtPrecio).prop('disabled', true);
                    $(chkOK).prop('checked', false);
                }
                else
                {
                    alertify.log("Stock insuficiente");
                    $(txtCantidad).focus();
                }
                return false;
            }
            else
            {
                F_AgregarTemporal();
            }
        }
        else
        {

        F_AgregarTemporal();
//        F_LimpiarGrillaConsulta();
//        $('#MainContent_txtArticulo').focus();
        return false;
        }

    }


    return true;
}

function F_ValidarDescuento(ControlID) {

        var txtDescuento = '#' + ControlID;
//        var chkOK = txtDescuento.replace('txtDescuento', 'chkOK');
        var txtPrecio = txtDescuento.replace('txtDsct', 'txtPrecioDisplay');

//        if (!$(chkOK).is(':checked'))
//            return false;

        if ($(txtDescuento).val() == "") {
            $(txtDescuento).val("");
            return false;
        }

        var hfDescuento = $('#hfDescuento').val();
        if (parseFloat(parseFloat($(txtDescuento).val()).toFixed(3)) > parseFloat(parseFloat(hfDescuento).toFixed(3))) {
            alertify.log("Descuento no permitido");
            $(txtDescuento).val("");
            return false;
        }
        var lblPrecioSoles =$('#hfPrecioSoles').val();
        var lblPrecioDolares =$('#hfPrecioDolares').val();
        var hfCodFamilia =$('#hfCodFamilia').val();
        var hfCostoProductoSoles =$('#hfCostoSoles').val();
        var hfCostoProductoDolares = $('#hfCostoDolares').val();
        var hfMargen =$('#hfMargen').val();
        var hfRedondeo =$('#hfRedondeo').val();
        var hfFactorRedondeo =$('#hfFactorRedondeo').val();

        var Descuento = 0;
        var Costo = 0;

        if ($('#MainContent_ddlMoneda').val() == 1) 
            Costo = parseFloat(hfCostoProductoSoles).toFixed(3);
        else 
            Costo = parseFloat(hfCostoProductoDolares).toFixed(3);

        $(txtPrecio).val(F_CalcularPrecioDescuento(Costo, parseFloat(hfMargen).toFixed(3), Number($(txtDescuento).val() ) / 100, parseFloat(hfRedondeo).toFixed(3), parseFloat(hfFactorRedondeo).toFixed(3)));

        $("#MainContent_ddlPrecio").empty();

    if ($(txtPrecio).val() != '')
    {
        $("#MainContent_ddlPrecio").append($("<option></option>").val($(txtPrecio).val()).html($(txtPrecio).val()));
        $("#hfMenorPrecioAgregar").val($(txtPrecio).val());
    }
        return true;
    }

function F_CalcularPrecioDescuento(Costo, Margen, Descuento, Redondeo, FactorRedondeo) {
    var Precio = 0;
    Costo = parseFloat(Costo);
    Margen = parseFloat(Margen);
    Descuento = parseFloat(Descuento);
    Redondeo = parseFloat(Redondeo);
    FactorRedondeo = parseFloat(FactorRedondeo);

    var Dsc = (Margen - Descuento) +1 ;
    Precio = (((Costo * Dsc) * FactorRedondeo).toFixed(Redondeo)) / FactorRedondeo;
        
    return Precio.toFixed(2);
}

function F_ValidarCheck(ControlID) {

    var cadena = 'Ingrese los sgtes. campos: '

    var chkOK = '#' + ControlID;
    var txtPrecio = chkOK.replace('chkOK', 'txtPrecio');
    var txtCantidad = chkOK.replace('chkOK', 'txtCantidad');
    var txtDescuento = chkOK.replace('chkOK', 'txtDescuento');
    var lblPrecioSoles = txtDescuento.replace('txtDescuento', 'lblPrecioSoles');
    var lblPrecioDolares = txtDescuento.replace('txtDescuento', 'lblPrecioDolares');

    if ($(chkOK).is(':checked')) {
        $(txtCantidad).prop('disabled', false);
        $(txtDescuento).prop('disabled', false);
        $(txtPrecio).prop('disabled', false);
        var i = 0;
        if ($(txtPrecio).val() == "") {
            $(txtPrecio).focus();
            i = 1
        }

        if (i == 0 && $(txtCantidad).val() == "")
        { $(txtPrecio).focus(); }

        if ($('#MainContent_ddlMoneda').val() == 1)
            $(txtPrecio).val($(lblPrecioSoles).text());
        else
            $(txtPrecio).val($(lblPrecioDolares).text());

        $(txtDescuento).focus();
    }
    else {
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

function F_FormaPagoEdicion(CodFormaPago){ 

 var arg;
    try 
    {
     switch (CodFormaPago)
     {
            case "1":
                       $('#MainContent_txtVencimientoEdicion').val(Date_AddDays($('#MainContent_txtEmisionEdicion').val(),0));
                       break;
            case "3":
                       $('#MainContent_txtVencimientoEdicion').val(Date_AddDays($('#MainContent_txtEmisionEdicion').val(),30));
                       break;
            case "4":
                       $('#MainContent_txtVencimientoEdicion').val(Date_AddDays($('#MainContent_txtEmisionEdicion').val(),15));
                       break;
            case "8":
                       $('#MainContent_txtVencimientoEdicion').val(Date_AddDays($('#MainContent_txtEmisionEdicion').val(),45));
                       break;
            case "9":
                       $('#MainContent_txtVencimientoEdicion').val(Date_AddDays($('#MainContent_txtEmisionEdicion').val(),60));
                       break;
            case "11":
                       $('#MainContent_txtVencimientoEdicion').val(Date_AddDays($('#MainContent_txtEmisionEdicion').val(),7));
                       break;
            case "12":
                       $('#MainContent_txtVencimientoEdicion').val(Date_AddDays($('#MainContent_txtEmisionEdicion').val(),0));
                       break;
            case "13":
                       $('#MainContent_txtVencimientoEdicion').val(Date_AddDays($('#MainContent_txtEmisionEdicion').val(),75));
                       break;
            case "14":
                       $('#MainContent_txtVencimientoEdicion').val(Date_AddDays($('#MainContent_txtEmisionEdicion').val(),90));
                       break;
     }

     
    }
     catch (mierror) 
     {
        alertify.log("Error detectado: " + mierror);
     }

}

function F_ValidarAgregar(ctrlsel){

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
        var lblStock_grilla=0;
        var x=0;

        txtcantidad_grilla=$('#MainContent_txtCantidad').val();
        txtPrecio_grilla=$('#MainContent_txtPrecioDisplay').val();
        lblcodproducto_grilla=$('#MainContent_txtCodigoProductoAgregar').val();
        lblStock_grilla=$('#MainContent_txtStockAgregar').val();
          
          
                            if (txtcantidad_grilla== '' || parseFloat(txtcantidad_grilla)== '0')
                                cadena=cadena + "\n" + "Cantidad para el Codigo " + lblcodproducto_grilla; 

                                   if (txtPrecio_grilla== '' || parseFloat(txtPrecio_grilla)== '0')
                                cadena=cadena + "\n" + "Precio para el Codigo " + lblcodproducto_grilla; 

                           
//                                  if (parseFloat(txtcantidad_grilla) <0 && parseFloat(lblStock_grilla)===0.00 )
//                                cadena=cadena + "\n" + "No tiene stock para el Codigo " + lblcodproducto_grilla; 

                                    if (parseFloat(txtcantidad_grilla) > parseFloat(lblStock_grilla) & $('#hfCodTipoProducto').val() == 2 & $('#MainContent_ddlTipoDoc').val() != 15)
                                cadena=cadena + "\n" + "No tiene stock suficiente para el Codigo " + lblcodproducto_grilla; 
                      
                      
                if (cadena != "Ingrese los sgtes. campos: ")
                   {
                      alertify.log(cadena);
                      return false;
                   } 
                   else
                   {
                    cadena="Los sgtes. productos se encuentran agregados : ";
                    lblcodproducto_grilla=$('#hfCodProductoAgregar').val();
                   $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
                                   chkDel = '#' + this.id;
                                   hfcodarticulodetalle_grilla = chkDel.replace('chkEliminar', 'hfcodarticulo');
                                   lbldscproducto_grilla = chkDel.replace('chkEliminar', 'lblproducto');
                                    
                                    if ($(lblcodproducto_grilla).val()==$(hfcodarticulodetalle_grilla).val())
                                    {
                                    cadena= cadena + "\n"  + $(lbldscproducto_grilla).text();
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
  try {
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

                        var objDetalle = {
                        CodArticulo: $('#hfCodProductoAgregar').val(),
                        Cantidad:$('#MainContent_txtCantidad').val(),
                        Precio: $('#MainContent_txtPrecioDisplay').val(),
                        Costo: $('#hfCostoAgregar').val(),
                        CodUm: $('#hfCodUmAgregar').val(),
                        CodDetalle:0
                        };
                         arrDetalle.push(objDetalle);
                           
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
                                        Filtro_Tasa: $(Contenedor + 'lblTC').text(),
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
                    var Moneda = 'S/ ';
                    if ($('#MainContent_ddlMoneda').val() === "2")
                        Moneda = '$ ';

                    $('#hfCodigoTemporal').val(result.split('~')[3]);
                    $('#MainContent_txtTotal').val(result.split('~')[5]);
                    $('#MainContent_txtTotal2').val(Moneda + result.split('~')[5]);
                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                     $('#MainContent_txtCantidad').val('');
                            $('#MainContent_txtDsct').val('');
                            $('#MainContent_txtPrecioDisplay').val('');
                            $('#MainContent_txtCantidad').val('');
                            $('#MainContent_txtCodigoProductoAgregar').val('');
                            $('#MainContent_txtArticuloAgregar').val('');
                            $('#MainContent_txtStockAgregar').val('');
                            $('#MainContent_txtUMAgregar').val('');
                            $('#hfCodProductoAgregar').val('0');

                            $('#MainContent_txtCodCotizacion').val('');
                    $('#hfNotaPedido').val(result.split('~')[8]);
                    $('.ccsestilo').css('background', '#FFFFE0');
                    if (result.split('~')[2]=='Los Producto(s) se han agregado con exito')
                    alertify.log('Los Producto(s) se han agregado con exito3');
                }
                else 
                {
                    alertify.log(result.split('~')[2]);
                }

                F_ContarItems();
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

    var Moneda = 'S/ ';
    if ($('#MainContent_ddlMoneda').val() === "2")
        Moneda = '$ ';

    $(Cuerpo + 'txtTotal').val(Total.toFixed(2));
    $(Cuerpo + 'txtTotal2').val(Moneda + Total.toFixed(2));
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
                       
                        CodDetalle: $(lblcoddetalle_grilla).val()
                        };
                                               
                        arrDetalle.push(objDetalle);
                    }
                });

            
                var Contenedor = '#MainContent_';
                var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
                var objParams = {
                                  Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
                                  Filtro_TasaIgv: tasaigv,
                                  Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
                                  Filtro_TipoCambio: $(Contenedor + 'lblTC').text(),
                                  Filtro_Tasa: $(Contenedor + 'lblTC').text(),
                                  Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
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

                    var Moneda = 'S/ ';
                    if ($('#MainContent_ddlMoneda').val() === "2")
                        Moneda = '$ ';

                    $('#hfCodigoTemporal').val(result.split('~')[3]);
                    if (result.split('~')[5]=='0')
                    {

                     $('#MainContent_txtTotal').val('0.00');
                     $('#MainContent_txtTotal2').val(Moneda + '0.00');
                    $('#MainContent_txtIgv').val('0.00');
                    $('#MainContent_txtSubTotal').val('0.00');
                    }
                    else
                    {
                      $('#MainContent_txtTotal').val(result.split('~')[5]);
                      $('#MainContent_txtTotal2').val(Moneda + result.split('~')[5]);
                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                    }

                    $('#hfNotaPedido').val(result.split('~')[8]);
                   
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                    if (result.split('~')[2]=='Se han eliminado los productos correctamente.')
                    alertify.log('Se han eliminado los productos correctamente.');
                }
                else 
                {
                    alertify.log(result.split('~')[2]);
                }
                $('.ccsestilo').css('background', '#FFFFE0');
                F_ContarItems();
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
               else if ($('#hfCodtipodoctemporal').val() === "22")
               {
               alertify.log("NO SE PUEDE ELIMINAR PRODUCTOS SI VIENEN DE UNA PROFORMA");
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
            var Cadena = 'Ingresar los sgtes. Datos:'; 

             if ($(Cuerpo + 'txtCliente').val()=='' && $('#hfCodCtaCte').val()==0 && $("#MainContent_ddlTipoDoc").val() == 1)
                    Cadena=Cadena + '<p></p>' + 'Cliente';

             if ($(Cuerpo + 'txtCliente').val()== '--ERROR DE CONEXION--' | $(Cuerpo + 'txtCliente').val()== '--NUEVO CLIENTE--')
                    Cadena=Cadena + '<p></p>' + 'Cliente';
        
             if ($(Cuerpo + 'lblTC').text()=='0')
                    Cadena=Cadena + '<p></p>' + 'Tipo de Cambio';

             if ($(Cuerpo + 'ddlFormaPago option:selected').text()=='')
                Cadena=Cadena + '<p></p>' + 'condicion de pago';

                if ($(Cuerpo + 'ddlVendedor option:selected').text()=='')
                Cadena=Cadena + '<p></p>' + 'Vendedor';

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

             if (!ValidarRuc($(Cuerpo + 'txtNroRuc').val()) & $('#MainContent_txtNroRuc').val() != '55555555555')
                    Cadena = Cadena + "<p></p>" + "Ruc Invalido"; 
         
//             if ($('#hfCodCtaCte').val()==0 && $('#hfCodDistrito').val()==0)
//                    Cadena=Cadena + '<p></p>' + 'Distrito';

//             if ($('#hfCodCtaCte').val()==0 && $(Cuerpo + 'txtDireccion').val()=='')
//                    Cadena=Cadena + '<p></p>' + 'Direccion';
         
             if ($(Cuerpo + 'txtTotal').val()=='0.00')
                    Cadena=Cadena + '<p></p>' + 'No ha ingresado ningun producto';

if($('#MainContent_chkGuia').prop('checked') && $('#MainContent_ddlTipoTransportista').val() == 1 &&  $("#MainContent_ddlSerieGuia option:selected").text().substr(0, 1) == 'T')
{
   if ($('#MainContent_txtNroRucTransportista').val() == '')
            Cadena=Cadena + '<p></p>' + 'Nro Ruc Transportista';

            
   if ( $('#MainContent_txtTransportista').val() == '')
            Cadena=Cadena + '<p></p>' + 'Transportista';

               if ( $('#MainContent_txtDistritoTransportista').val() == '')
            Cadena=Cadena + '<p></p>' + 'Distrito Tranpostista';

                 if ( $('#MainContent_txtDireccionTransportista').val() == '')
            Cadena=Cadena + '<p></p>' + 'Direccion Tranpostista'; 
            
             if ( $('#hfTransportista').val() == '0')
            Cadena=Cadena + '<p></p>' + 'Transportista';


}
if($('#MainContent_chkGuia').prop('checked') && $('#MainContent_ddlTipoTransportista').val() ==2 &&  $("#MainContent_ddlSerieGuia option:selected").text().substr(0, 1) == 'T')
{
   if ($('#MainContent_txtPlacaTraslado').val() == '')
            Cadena=Cadena + '<p></p>' + 'Placa';

            
   if ( $('#MainContent_txtConductorDNI').val() == '')
            Cadena=Cadena + '<p></p>' + 'Dni Conductor';

               if ( $('#MainContent_txtConductorRazonSocial').val() == '')
            Cadena=Cadena + '<p></p>' + 'Conductor';

                 if ( $('#hfCodConductor').val() == '0')
            Cadena=Cadena + '<p></p>' + 'Conductor';

}
if($('#MainContent_chkGuia').prop('checked') && $('#MainContent_ddlTipoTransportista').val() ==3 &&  $("#MainContent_ddlSerieGuia option:selected").text().substr(0, 1) == 'T')
{
   if ($('#MainContent_txtPlacaTraslado').val() == '')
            Cadena=Cadena + '<p></p>' + 'Placa';
}
        //miguel 

    if   ($('#MainContent_chkGuia').prop('checked') && $('#MainContent_ddlTipoDoc').val() == 16 &&  $("#MainContent_ddlSerieGuia option:selected").text().substr(0, 1) == 'T')
            Cadena=Cadena + '<p></p>' + 'LA PROFORMA NO PUEDE TENER GUIA ELECTRONICA';  
                 

         if (($('#MainContent_chkGuia').prop('checked') && $('#MainContent_txtNuBultos').val().trim() == "" &&  $("#MainContent_ddlSerieGuia option:selected").text().substr(0, 1) == 'T')  | ($('#MainContent_chkGuia').prop('checked') && $('#MainContent_txtNuBultos').val() == 0 &&  $("#MainContent_ddlSerieGuia option:selected").text().substr(0, 1) == 'T')  )
            Cadena=Cadena + '<p></p>' + 'BULTOS';

         if    (($('#MainContent_chkGuia').prop('checked') && $('#MainContent_txtPeso').val().trim() == "" &&  $("#MainContent_ddlSerieGuia option:selected").text().substr(0, 1) == 'T' ) | ($('#MainContent_chkGuia').prop('checked') && $('#MainContent_txtPeso').val() == 0 &&  $("#MainContent_ddlSerieGuia option:selected").text().substr(0, 1) == 'T'))
            Cadena=Cadena + '<p></p>' + 'PESO';
//                 
//    var Placa = $.trim($(Cuerpo + 'txtPlaca').val())  + $.trim($(Cuerpo + 'txtPlaca2').val()) + $.trim($(Cuerpo + 'txtPlaca3').val()) + $.trim($(Cuerpo + 'txtPlaca4').val());

//            if (Placa.indexOf($.trim($(Cuerpo + 'txtPlaca').val())) + Placa.indexOf($.trim($(Cuerpo + 'txtPlaca2').val()))+Placa.indexOf($.trim($(Cuerpo + 'txtPlaca3').val())) + Placa.indexOf($.trim($(Cuerpo + 'txtPlaca4').val())) > 0)
//                Cadena=Cadena + '<p></p>' + 'No se puede repetir placas';
                
            //validaciones por tipo de documento
            switch($("#MainContent_ddlTipoDoc").val()) {
                case '1': //FACTURA
                    if ($('#MainContent_txtNroRuc').val().length != 11 || $('#hfCodCtaCte').val() == '1643' || $('#hfCodCtaCte').val() == '29' || $('#MainContent_txtNroRuc').val() == '99999999' || $('#MainContent_txtNroRuc').val() == '11111111')
                    Cadena=Cadena + '<p></p>' + 'NUMERO DE RUC VALIDO';

//                    if ($('#MainContent_txtDistrito').val().trim() == '' || $('#MainContent_txtDireccion').val().trim() == '')
//                    Cadena=Cadena + '<p></p>' + 'DISTRITO Y DIRECCION';

                    if ($('#MainContent_txtNroRuc').val() == '55555555555' | $('#MainContent_txtNroRuc').val() == '55555555')
                    Cadena=Cadena + '<p></p>' + 'NO SE PUEDE FACTURAR UN CLIENTE SIN DOCUMENTO';
                     $('#MainContent_chkGuia').prop('disabled', false);
                    break;
                case '2': //BOLETA

                    //valida el monto no superior a 700 Soles
                    if ($('#hfCodCtaCte').val() == '1643' || $('#MainContent_txtNroRuc').val() == '99999999' || $('#MainContent_txtNroRuc').val() == '11111111')
                    {
                        var monto = $('#MainContent_txtTotal').val(); //rescata el monto
                        if ($('#MainContent_ddlMoneda').val()==2) { var tasa = $('#MainContent_lblTC').text(); monto = monto * tasa; } //si es en dolares hace la conversion
                        if (monto > 700) Cadena=Cadena + '<p></p>' + 'El monto es Mayor a 700 Soles, debe ingresar un NDI'; //valida
                    }

                    if ($('#MainContent_txtDistrito').val().trim() == '' || $('#MainContent_txtDireccion').val().trim() == '')
                    Cadena=Cadena + '<p></p>' + 'DISTRITO Y DIRECCION';

                    if ($(Cuerpo + 'chkGuia').is(':checked'))
                    {
                        if ($('#hfCodCtaCte').val() == '1643' || $('#MainContent_txtNroRuc').val() == '99999999' || $('#MainContent_txtNroRuc').val() == '11111111')
                        {
                            Cadena=Cadena + '<p></p>' + 'AL INGRESAR UNA GUIA, DEBE ESPECIFICAR UN DNI VALIDO';
                        }
                    }

                    if ($('#MainContent_txtNroRuc').val() == '55555555555' | $('#MainContent_txtNroRuc').val() == '55555555')
                    Cadena=Cadena + '<p></p>' + 'NO SE PUEDE FACTURAR UN CLIENTE SIN DOCUMENTO';
                    $('#MainContent_chkGuia').prop('disabled', false);
                    break;
                case '15': //COTIZACION (PROFORMA)

                    break;
                case '16': //NOTA DE PEDIDO
                    if ($('#MainContent_ddlResponsableNP option:selected').text() != '')
                    {
                    var Responsable2 = $('#MainContent_txtResponsable2').val();
                    var Responsable2DNI = $('#MainContent_txtResponsableDNI2').val();
                        if (Responsable2 != '' & Responsable2DNI == '' | Responsable2 == '' & Responsable2DNI != '')
                        Cadena=Cadena + '<p></p>' + 'SI VA A UTILIZAR RESPONSABLE 2, DEBE TENER TANTO NOMBRE COMO DNI COMPLETOS';
                    }

//                    $('#MainContent_chkGuia').prop('disabled', true);

                    break;
                     case '22': //VALE CREDITO
                    if ($('#MainContent_ddlResponsableNP option:selected').text() != '')
                    {
                    var Responsable2 = $('#MainContent_txtResponsable2').val();
                    var Responsable2DNI = $('#MainContent_txtResponsableDNI2').val();
                        if (Responsable2 != '' & Responsable2DNI == '' | Responsable2 == '' & Responsable2DNI != '')
                        Cadena=Cadena + '<p></p>' + 'SI VA A UTILIZAR RESPONSABLE 2, DEBE TENER TANTO NOMBRE COMO DNI COMPLETOS';
                    }

                    
                    $('#MainContent_chkGuia').prop('disabled', false);
                    if (($(Cuerpo + 'ddlFormaPago ').val()==1)||($(Cuerpo + 'ddlFormaPago ').val()==12)||($(Cuerpo + 'ddlFormaPago ').val()==2)||($(Cuerpo + 'ddlFormaPago ').val()==6)||($(Cuerpo + 'ddlFormaPago ').val()==15))
                Cadena=Cadena + '<p></p>' + 'solo puede ser credito';

                    break;
            }

             if (Cadena != 'Ingresar los sgtes. Datos:')
             {   
                 alertify.log(Cadena.toUpperCase());
                 return false;
             }   
             return true;
        }        
    catch (e) 
        {
            alertify.log("Error Detectado: " + e);
            return false;
        }
}

function F_ValidarGrabarEdicionDocumento(){
    try 
        {        
            var Cuerpo='#MainContent_';
      var Cadena = 'Ingresar los sgtes. Datos:'; 


   if ($('#MainContent_chkGuiaEdicion').prop('checked') && $('#MainContent_ddlTipoDoc2').val() == 16 &&  $("#MainContent_ddlSerieGuiaEdicion option:selected").text().substr(0, 1) == 'T')
            Cadena=Cadena + '<p></p>' + 'LA PROFORMA NO PUEDE TENER GUIA ELECTRONICA';  

if($('#MainContent_chkGuiaEdicion').prop('checked') && $('#MainContent_ddlTipoTransportistaEdicion').val() == 1 &&  $("#MainContent_ddlSerieGuiaEdicion option:selected").text().substr(0, 1) == 'T')
{
   if ($('#MainContent_txtNroRucTransportistaEdicion').val() == '')
            Cadena=Cadena + '<p></p>' + 'Nro Ruc Transportista';

//            if ($.trim($('#MainContent_txtDestinoEdicion').val()) == '')
//            Cadena=Cadena + '<p></p>' + 'Llegada';
            
   if ($.trim($('#MainContent_txtTransportistaEdicion').val()) == '')
            Cadena=Cadena + '<p></p>' + 'Transportista';

//               if ($.trim($('#MainContent_txtDistritoTransportistaEdicion').val()) == '')
//            Cadena=Cadena + '<p></p>' + 'Distrito Transportista';

//                 if ($.trim($('#MainContent_txtDireccionTransportistaEdicion').val()) == '')
//            Cadena=Cadena + '<p></p>' + 'Direccion Transportista'; 
            
//             if ( $('#hfCodTransportistaEdicion').val() == '0')
//            Cadena=Cadena + '<p></p>' + 'Transportista';


}
if($('#MainContent_chkGuiaEdicion').prop('checked') && $('#MainContent_ddlTipoTransportistaEdicion').val() ==2 &&  $("#MainContent_ddlSerieGuiaEdicion option:selected").text().substr(0, 1) == 'T')
{
 //  if ($('#MainContent_txtPlacaTraslado').val() == '')
       //     Cadena=Cadena + '<p></p>' + 'Placa';

            
   if ( $('#MainContent_txtConductorDNIEdicion').val() == '')
            Cadena=Cadena + '<p></p>' + 'Dni Conductor';

               if ( $('#MainContent_txtConductorRazonSocialEdicion').val() == '')
            Cadena=Cadena + '<p></p>' + 'Conductor';

                 if ( $('#hfCodConductor').val() == '0')
            Cadena=Cadena + '<p></p>' + 'Conductor';

}
if($('#MainContent_chkGuiaEdicion').prop('checked') && $('#MainContent_ddlTipoTransportistaEdicion').val() ==3 &&  $("#MainContent_ddlSerieGuiaEdicion option:selected").text().substr(0, 1) == 'T')
{
   if ($('#MainContent_txtPlacaTrasladoEdicion').val() == '')
            Cadena=Cadena + '<p></p>' + 'Placa';
}

        if (($('#MainContent_chkGuiaEdicion').prop('checked') && $('#MainContent_txtNuBultosEdicion').val().trim() == "" &&  $("#MainContent_ddlSerieGuiaEdicion option:selected").text().substr(0, 1) == 'T')  | 
        ($('#MainContent_chkGuiaEdicion').prop('checked') && $('#MainContent_txtNuBultosEdicion').val() == 0 &&  $("#MainContent_ddlSerieGuiaEdicion option:selected").text().substr(0, 1) == 'T')  )
            Cadena=Cadena + '<p></p>' + 'BULTOS';

         if    (($('#MainContent_chkGuiaEdicion').prop('checked') && $('#MainContent_txtPesoEdicion').val().trim() == "" &&  $("#MainContent_ddlSerieGuiaEdicion option:selected").text().substr(0, 1) == 'T' ) | 
         ($('#MainContent_chkGuiaEdicion').prop('checked') && $('#MainContent_txtPesoEdicion').val() == 0 &&  $("#MainContent_ddlSerieGuiaEdicion option:selected").text().substr(0, 1) == 'T'))
            Cadena=Cadena + '<p></p>' + 'PESO';
                 
                   if (Cadena != 'Ingresar los sgtes. Datos:')
             {   
                 alertify.log(Cadena.toUpperCase());
                 return false;
             }    
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
        var Contenedor = '#MainContent_';
        var FlagGuia='0'; var FlagRetencion='0'; var FlagLetra='0'; var FlagIgv='1'; var NotaPedido='0';var Peso = 0;
        var NroBultos=0;
        if ($(Contenedor + 'chkGuia').is(':checked')) FlagGuia='1';
        if ($(Contenedor + 'chkRetencion').is(':checked')) FlagRetencion='1';
        if ($(Contenedor + 'ddlFormaPago').val()==12) FlagLetra='1';
        if ($('#hfNotaPedido').val() == '1') NotaPedido='1';

        var Serie =  $("#MainContent_ddlSerie option:selected").text();
        var Numero = $(Contenedor + 'txtNumero').val();

        var Index= $('#MainContent_txtCliente').val().indexOf('-');
        var Cliente = $('#MainContent_txtCliente').val();
        if ( Index ==-1 ) {} 
        else {
            if (isNaN(Cliente.split('-')[0].trim()) | !ValidarRuc(Cliente.split('-')[0].trim()))
            {} else
            Cliente=Cliente.substr(Cliente.length - (Cliente.length -(Index+2)));
        }
        var RazonSocial = Cliente;

        var CodTipoCliente = 0;
        var NroDni = $('#MainContent_txtNroRuc').val();
        var NroRuc = $('#MainContent_txtNroRuc').val();
        if (NroDni.length == 11) NroDni = '';
        if (NroRuc.length == 8) NroRuc = '';
         if ($.trim($(Contenedor + 'txtNuBultos').val())!='')
              NroBultos=$.trim($(Contenedor + 'txtNuBultos').val());

        if ($.trim($(Contenedor + 'txtPeso').val())!='')
              Peso=$.trim($(Contenedor + 'txtPeso').val());
        
        var tasaigv=parseFloat( $("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
        var flagCSIgv = 0; if ($('#MainContent_chkConIgvMaestro').is(':checked')) {flagCSIgv = 1; };
        
        var FlagEnviarEmailsInmediato = '0'; 
        if ($("#MainContent_ddlTipoDoc option:selected").val() === '15' | $("#MainContent_ddlTipoDoc option:selected").val() === '16') FlagEnviarEmailsInmediato = '1';

        var Email1 = '';
        var Email2 = '';
        var Email3 = '';
        var Email4 = '';
        var Email5 = '';
        var Email6 = '';
        try {
            Email1 = $('#ddlCorreos').multipleSelect('getSelects', 'text')[0];
            Email2 = $('#ddlCorreos').multipleSelect('getSelects', 'text')[1];
            Email3 = $('#ddlCorreos').multipleSelect('getSelects', 'text')[2];
            Email4 = $('#ddlCorreos').multipleSelect('getSelects', 'text')[3];
            Email5 = $('#ddlCorreos').multipleSelect('getSelects', 'text')[4];
            Email6 = $('#ddlCorreos').multipleSelect('getSelects', 'text')[5];
            if (Email1 === "SIN CORREOS")
                Email1 = "";
                    
        } catch (e) { }

                   var objParams = {
                                        Filtro_CodTipoDoc: $("#MainContent_ddlTipoDoc option:selected").val(),
                                        Filtro_SerieDoc: Serie,
                                        Filtro_NumeroDoc: Numero,
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
                                       
                                        Filtro_CodTipoCliente:  CodTipoCliente,
                                        Filtro_CodClaseCliente: 2, 
                                        Filtro_CodDepartamento: $('#hfCodDepartamento').val(),
                                        Filtro_CodProvincia: $('#hfCodProvincia').val(),
                                        Filtro_CodDistrito: $('#hfCodDistrito').val(),
                                        Filtro_ApePaterno: '',
                                        Filtro_ApeMaterno: '',
                                        Filtro_Nombres:'',

                                        Filtro_RazonSocial: Cliente,
                                        Filtro_NroDni: NroDni, 
                                        Filtro_NroRuc: NroRuc, 
                                        Filtro_Direccion: $(Contenedor + 'txtDireccion').val(),
                                        
                                        Filtro_FlagIgv: FlagIgv,
                                        Filtro_Placa:$(Contenedor + 'txtPlaca').val(),
                                        Filtro_Placa2:$(Contenedor + 'txtPlaca2').val(),
                                        Filtro_Placa3:$(Contenedor + 'txtPlaca3').val(),
                                        Filtro_Placa4:$(Contenedor + 'txtPlaca4').val(),
                                        Filtro_Placa5:$(Contenedor + 'txtPlaca5').val(),
                                        Filtro_Placa6:$(Contenedor + 'txtPlaca6').val(),
                                        Filtro_Placa7:$(Contenedor + 'txtPlaca7').val(),
                                        Filtro_Placa8:$(Contenedor + 'txtPlaca8').val(),
                                        Filtro_PlacaTraslado:$(Contenedor + 'txtPlacaTraslado').val(),
                                        Filtro_Cliente: Cliente,
                                        Filtro_CodTasa: $(Contenedor + 'ddlIgv').val() ,
                                        Filtro_TasaIgv: tasaigv,
                                        Filtro_NotaPedido:NotaPedido,
                                        Filtro_SerieOC: '',
                                        
                                        Filtro_NumeroOC: $('#MainContent_txtNroOC').val(),
                                        Filtro_NroOperacion: $('#MainContent_txtNroOperacion').val(),
                                        Filtro_CodDetalle: $('#hfCodigoTemporal').val(),
                                        Filtro_CodTipoOperacion: 1,
                                        Filtro_Partida:$('#hfPartida').val(),

                                        Filtro_CodNotaVenta: $('#hfCodNotaVenta').val(),
                                        Filtro_DireccionCompleta:  $(Contenedor + 'txtDireccion').val() + ' ' + $(Contenedor + 'txtDistrito').val() ,
                                        Filtro_Descuento:0,
                                        Filtro_FlagRetencion:FlagRetencion,
                                        Filtro_FlagLetra:FlagLetra,
                                        Filtro_Atencion: $(Contenedor + 'txtAtencion').val(),
                                        Filtro_Referencia: $(Contenedor + 'txtReferencia').val(),
                                        Filtro_CodDireccion: $('#hfCodDireccion').val(),
                                        
                                        Filtro_Responsable1: $(Contenedor + 'txtResponsable1').val(),
                                        Filtro_Responsable1DNI: $(Contenedor + 'txtResponsableDNI1').val(),
                                        Filtro_CodResponsable: 0,
                                        Filtro_Responsable2: $(Contenedor + 'txtResponsable2').val(),
                                        Filtro_Responsable2DNI: $(Contenedor + 'txtResponsableDNI2').val(),
                                        Filtro_Correo: $('#MainContent_txtCorreo').val(),
                                        Filtro_KM: $('#MainContent_txtKM').val(),
                                        Filtro_Email1: Email1,
                                        Filtro_Email2: Email2,
                                        Filtro_Email3: Email3,
                                        Filtro_Email4: Email4,
                                        Filtro_Email5: Email5,
                                        Filtro_Email6: Email6, 
                                        Filtro_EnviarEmailsInmediato: FlagEnviarEmailsInmediato,
                                        Filtro_CodFacturaAnterior: $('#hfCodFacturaAnterior').val(),
                                        Filtro_Requerimiento: $('#MainContent_txtRequerimiento').val(),
                                        Filtro_Observacion: $('#MainContent_txtObservacion').val(),
                                        Filtro_CodVendedor: $('#MainContent_ddlVendedor').val(),
                                        Filtro_Codtipodoctemporal: $('#hfCodtipodoctemporal').val(),
                                        Filtro_CodDocumentoVentaDireccion: $('#MainContent_ddldireccionNueva').val(),
                                        Filtro_CodTipoOperacion: 1, 


                                         //DATOS TRANSPORTISTA - MIGUEL
//                                          Filtro_FlagGuia:FlagGuia,
//                                        Filtro_SerieGuia: $("#MainContent_ddlSerieGuia option:selected").text(),

//                                        Filtro_NumeroGuia: $(Contenedor + 'txtNumeroGuia').val(),
//                                        Filtro_FechaTraslado: $(Contenedor + 'txtFechaTraslado').val(),

//                                         Filtro_Destino: $(Contenedor + 'txtDestino').val(),

//                                        Filtro_Transportista: $(Contenedor + 'txtTransportista').val(),
//										Filtro_Marca: $(Contenedor + 'txtMarcaGuia').val(),
//										Filtro_Licencia: $(Contenedor + 'txtLicenciaGuia').val(),
//										Filtro_NuBultos: $(Contenedor + 'txtNuBultos').val(),
//										Filtro_Peso: $(Contenedor + 'txtPeso').val(),
//                                        Filtro_CodTransportista: $('#hfCodTransportista').val(),
//                                        Filtro_CodDireccionTransportista: $('#hfCodDireccionTransportista').val(),
//                                        Filtro_DireccionTrans: $('#MainContent_txtDireccionTransportista').val(),


//                                           Filtro_NroRucTransportista: $(Contenedor + 'txtNroRucTransportista').val(),
//                                           Filtro_CodDepartamentoTransportista: $('#hfCodDepartamentoTransportista').val(),
//                                           Filtro_CodProvinciaTransportista: $('#hfCodProvinciaTransportista').val(),
//                                           Filtro_CodDistritoTransportista: $('#hfCodDistritoTransportista').val(),
//                                           Filtro_CodConductor: $('#hfCodConductor').val(),
//                                           Filtro_TipoTransportista: $(Contenedor + 'ddlTipoTransportista').val(),
//                                           Filtro_codunidadpeso: $(Contenedor + 'ddlcodunidadpeso').val()
  // INICIO DATOS DE LA GUIA 

            Filtro_FlagGuia:FlagGuia,
            Filtro_SerieGuia: $("#MainContent_ddlSerieGuia option:selected").text(),
            Filtro_NumeroGuia: $(Contenedor + 'txtNumeroGuia').val(),
            Filtro_CodTipoTransportista: $('#MainContent_ddlTipoTransportista').val(),
            Filtro_FechaTraslado: $(Contenedor + 'txtFechaTraslado').val(),
            Filtro_CodDocumentoVentaDireccionDestino: $('#MainContent_ddldireccionNuevaDestino').val(),////
            Filtro_CodTransportista: $('#hfCodTransportista').val(),
            Filtro_CodDocumentoVentaDireccionTransportista: $('#MainContent_ddldireccionNuevaTransportista').val(),////
            Filtro_RucTransportista: $(Contenedor + 'txtNroRucTransportista').val(),
            Filtro_RazonSocialTransportista: $(Contenedor + 'txtTransportista').val(),          
            Filtro_PlacaTraslado:$(Contenedor + 'txtPlacaTraslado').val(),
            Filtro_MarcaVehiculo: $(Contenedor + 'txtMarcaGuia').val(),     
            Filtro_Licencia: $(Contenedor + 'txtLicenciaGuia').val(),
            Filtro_NroBultos: NroBultos,
            Filtro_Peso: Peso,
            Filtro_CodUnidadPeso: $('#MainContent_ddlcodunidadpeso').val(),
            Filtro_CodConductor: $('#hfCodConductor').val(),
            Filtro_ObservacionGuia: $('#MainContent_txtObservacionGuia').val()   
            
            // FIN DATOS DE LA GUIA       


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
                        if ($('#MainContent_chkImpresion').is(':checked') | $('#MainContent_chkImpresionTicket').is(':checked')) 
                        {
                            var CodMenu = 201; if ($('#MainContent_ddlTipoDoc2').val() == 15) CodMenu = 202;
                            var Tipo = 'IMP';

                            if($('#MainContent_chkImpresionTicket').is(':checked'))
                                Tipo = 'TK';

                            //F_ImpresionGrabar(result.split('~')[2], $("#MainContent_ddlTipoDoc").val(), $("#MainContent_ddlSerie option:selected").text(), ti);
                          
                            F_ImprimirFactura(result.split('~')[2],CodMenu,Tipo) 
                        }

                        if (Number($('#hfCodDireccion').val()) === 0) {
                            F_ActualizarCorreosCodDocumentoVenta(result.split('~')[2], $("#MainContent_ddlTipoDoc").val());
                        }
                        
                    $('#MainContent_ddlMoneda').prop('disabled', false);
                    F_Nuevo();                    
//                    F_Pedidos();
                    }
                    else
                    {
                        alertify.log(result.split('~')[1]);
                        return false;                    
                    }
                   
                   
                }
                else 
                {
                    alertify.log(result.split('~')[1]);
                    return false;
                }
                F_ContarItems();
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
       $('#hfCodDepartamento').val('0');
       $('#hfCodProvincia').val('0');
       $('#hfCodDistrito').val('0');
       $('#hfCodCtaCte').val('0');
       $('#MainContent_ddlMoneda').val('1');
       $('#MainContent_txtKM').val('');   
       $('#hfCodigoTemporal').val('0');
       $('#hfCodtipodoctemporal').val('0');
       $('#hfCodConductor').val('0');
       $('#MainContent_txtCliente').val('');
       $('#hfCliente').val('');
       $('#MainContent_txtPlaca').val('');
       $('#MainContent_txtPlaca2').val('');
       $('#MainContent_txtPlaca3').val('');
       $('#MainContent_txtPlaca4').val('');
       $('#MainContent_txtDistrito').val('');
       $('#MainContent_txtDireccion').val('');
       $('#MainContent_txtDescuento').val('0.00');
       $('#MainContent_txtSubTotal').val('0.00');
       $('#MainContent_txtIgv').val('0.00');
       $('#MainContent_txtTotal').val('0.00');
       $('#MainContent_txtTotal2').val('S/ 0.00');
       $('#MainContent_txtDestino').val('');
       $('#MainContent_txtObservacion').val('');
       $('#MainContent_txtVencimiento').val($('#MainContent_txtEmision').val());
       $('#MainContent_txtArticulo').val('');
       $('#MainContent_chkGuia').prop('checked', false);
       $('#MainContent_chkServicios').prop('checked', false);
       $('#MainContent_chkNotaPedido').prop('checked', false);
       $('#MainContent_chkImpresionTicket').prop('checked', true);
       $('#MainContent_chkImpresion').prop('checked', false);
       $('#MainContent_chkRetencion').prop('checked', false);
       $('#MainContent_txtNroRuc').val('');
       //$('#MainContent_ddlTipoDoc').val('1');
       $('#MainContent_txtCliente').focus();
       $('#MainContent_txtAtencion').val('');
       $('#MainContent_txtReferencia').val('');
       $('#hfCodigoTemporal').val('0')
       $('#MainContent_txtNumeroGuia').val('');
       $('#MainContent_txtDestino').val('');
       $('#MainContent_txtTransportista').val('');
       $('#MainContent_txtDireccionTransportista').val('');
       $('#MainContent_txtPlacaTraslado').val('');
       $('#MainContent_txtNroRucTransportista').val('');
       $('#MainContent_txtConductorDNI').val('');
       $('#MainContent_txtConductorRazonSocial').val('');
       $('#MainContent_txtDistritoTransportista').val('');
       $('#MainContent_txtMarcaGuia').val('');
       $('#MainContent_txtLicenciaGuia').val('');
       $('#MainContent_txtNuBultos').val('');
       $('#MainContent_txtPeso').val('');
       $('#hfNotaPedido').val('0');
       $('#div_CabeceraGuia').css("display","none");
       $('#div_CuerpoGuia').css("display","none");
       $('#MainContent_txtResponsable1').val('');
       $('#MainContent_txtResponsableDNI1').val('');
       $('#MainContent_txtResponsable2').val('');
       $('#MainContent_txtResponsableDNI2').val('');
       $('#MainContent_txtCorreo').val('');
       $('#MainContent_txtNroOC').val('');
       $('#MainContent_txtNroOperacion').val('');
       $('#MainContent_txtRequerimientoEdicion').val('');
       $("#MainContent_txtRequerimiento").val('');
         $( "#accordion" ).accordion({
        collapsible: true,
        active: false
        });


        $('#hfCodFacturaAnterior').val(0)
        $('#MainContent_ddlTipoDoc').prop('disabled', false);
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
                    $('#MainContent_ddlFormaPago').val(1);
                    $('#MainContent_txtNumero').val(result.split('~')[3]);
                    $('#MainContent_txtNumeroGuia').val(result.split('~')[4]);
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[2]);   
                    $('.ccsestilo').css('background', '#FFFFE0'); 
                    F_Mostrar_Correlativo($("#MainContent_ddlTipoDoc").val());                     
                    F_CambioTipoDoc();
                    F_ContarItems();
                    F_InicializarCorreos();
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
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

       try 
        {
              var chkNumero='0';
              var chkFecha='0';
              var chkCliente='0';
              var chkProducto='0';
              var Placa = '';
              var C=0;
              var F=0;
              if ($('#MainContent_chkNumero').is(':checked'))
              chkNumero='1';

              if ($('#MainContent_chkRango').is(':checked'))
              chkFecha='1';

              if ($('#MainContent_chkCliente').is(':checked'))
              chkCliente='1';
                 if ($('#MainContent_chkProductoConsulta').is(':checked'))
              chkProducto='1';

              if ($('#MainContent_chkPlacaConsulta').is(':checked'))
              Placa=$('#MainContent_txtPlacaConsulta').val();
              
              
              var objParams = {
                                        Filtro_Serie: $("#MainContent_ddlSerieConsulta option:selected").text(),
                                        Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                                        Filtro_Desde: $('#MainContent_txtDesde').val(),
                                        Filtro_Hasta: $('#MainContent_txtHasta').val(),
                                        Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                                        Filtro_CodTipoDoc: $("#MainContent_ddlTipoDoc2").val(),
                                        Filtro_ChkNumero: chkNumero,
                                        Filtro_ChkFecha: chkFecha,
                                        Filtro_ChkCliente: chkCliente,
                                        Filtro_Placa: Placa,
                                        Filtro_Estado: $("#MainContent_ddlEstadoConsulta").val(),
                                        Filtro_EstadoNP: $("#MainContent_ddlEstadoConsultaNP").val(),
                                        Filtro_ChkProducto: chkProducto,
                                        Filtro_CodProducto: $('#hfcodproductoconsulta').val()                                        
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

   var titulos = true;
                     var TOTALSOLES = 0;
                    var MONEDA = 0;
                    var TOTALDOLARES = 0;
                    var PTOTAL = '#MainContent_grvConsulta_lblTotal_';
                    var PMONEDA = '#MainContent_grvConsulta_lblMoneda_';
                      //SUMA
                    $('#MainContent_grvConsulta > tbody  > tr').each(function(index, tr) { 
                    MONEDA=$(PMONEDA +  index).text();
                    if (titulos == true) {
                        titulos = false;
                        
                        if (MONEDA =='S/')
                        {
                        TOTALSOLES = TOTALSOLES+Number($(PTOTAL +  index).text());
                        }else if (MONEDA =='US$')
                        {
                        TOTALDOLARES =  TOTALDOLARES+Number($(PTOTAL +  index).text());
                        }
                    }
                    else {
//                        PRUEBA
                    if(typeof $(PTOTAL +  (index )).val() !=='undefined'){
                        if (MONEDA =='S/')
                        {
                        TOTALSOLES = TOTALSOLES+ Number($(PTOTAL +  index).text());
                        }else if (MONEDA =='US$')
                        {
                        TOTALDOLARES = TOTALDOLARES+ Number($(PTOTAL +  index).text());
                        }
                        }
                    }
                }); 
                      
                    $('#lblTotalSoles').text(TOTALSOLES.toFixed(2));
                    $('#lblTotalDolares').text(TOTALDOLARES.toFixed(2));  


                    $('#lblGrillaConsulta').text(F_Numerar_Grilla("grvConsulta",'lblnumero'));
                    $('#MainContent_grvConsulta  .detallesart').each(function () {
                    if($('#MainContent_grvConsulta_lblEstadoSunat_'+F).text()!='APROBADO' && $('#MainContent_grvConsulta_lblCodigo_'+F).val()!=0){
                       C++;
                    }
                     F++
                        });
                    $('#lblGrillaEspera').text(C); 
                    $('#lblGrillaEspera').css("font-size","x-large");
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

function F_AnularRegistro() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Anular') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

 try 
        {

         if(!confirm("ESTA SEGURO DE ANULAR LA "  + $("#MainContent_ddlTipoDoc2 option:selected").text() + " : " + $('#hfNumeroAnulacion').val() + "\n" + "DEL CLIENTE : " +  $('#hfClienteAnulacion').val()))
    return false;

    var chkNumero='0';
              var chkFecha='0';
              var chkCliente='0';
              var chkProducto='0';
              var Placa = '';

                 if ($('#MainContent_chkNumero').is(':checked'))
              chkNumero='1';

              if ($('#MainContent_chkRango').is(':checked'))
              chkFecha='1';

              if ($('#MainContent_chkCliente').is(':checked'))
              chkCliente='1';
                 if ($('#MainContent_chkProductoConsulta').is(':checked'))
              chkProducto='1';

              if ($('#MainContent_chkPlacaConsulta').is(':checked'))
              Placa=$('#MainContent_txtPlacaConsulta').val();


    var objParams = {
                          Filtro_Codigo: $('#hfCodDocumentoVentaAnulacion').val(),
                          Filtro_Serie: $("#MainContent_ddlSerieConsulta option:selected").text(),
                          Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                          Filtro_Desde: $('#MainContent_txtDesde').val(),
                          Filtro_Hasta: $('#MainContent_txtHasta').val(),
                          Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                          Filtro_CodTipoDoc: $("#MainContent_ddlTipoDoc2").val(),
                          Filtro_ChkNumero: chkNumero,
                          Filtro_ChkFecha: chkFecha,
                          Filtro_ChkCliente: chkCliente,
                          Filtro_Placa: Placa,
                          Filtro_Estado: $("#MainContent_ddlEstadoConsulta").val(),
                          Filtro_EstadoNP: $("#MainContent_ddlEstadoConsultaNP").val(),
                          Filtro_ChkProducto: chkProducto,
                          Filtro_CodProducto: $('#hfcodproductoconsulta').val(),
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
                 $('#div_Anulacion').dialog('close');     
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

function F_EditarRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
 try 
        {
       var imgID = Fila.id;
    var lblCodigo = '#' + imgID.replace('imgEditarDocumento', 'lblCodigo');
    var lblEstado = '#' + imgID.replace('imgEditarDocumento', 'lblEstado');
    var lblnumero_grilla = '#' + imgID.replace('imgEditarDocumento', 'lblnumero');
    var lblcliente_grilla = '#' + imgID.replace('imgEditarDocumento', 'lblcliente');
    var hfcodtipodoc_grilla = '#' + imgID.replace('imgEditarDocumento', 'hfCodTipoDoc');

    if ($(lblEstado).text()=="ANULADO") 
    {alertify.log("ESTE DOCUMENTO SE ENCUENTRA ANULADO");
    return false;}

    var objParams = {
                      Filtro_CodDocumentoventa: $(lblCodigo).val(),
                      Filtro_CodTipoDoc: $(hfcodtipodoc_grilla).val()
                    };

    $('#hfCodTipoDocEdicion').val($(hfcodtipodoc_grilla).val());  


    var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
    MostrarEspera(true);
    F_DatosFactura_NET(arg, function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") {
                        
                    
                    $('#hfCodFacturaEdicion').val($(lblCodigo).val());  
                    $('#MainContent_lblTipoFacturaEdicion').text('# ' + $('#MainContent_ddlTipoDoc2 option:selected').text());
                    $('#MainContent_txtNroFacturaEditar').val($(lblnumero_grilla).text());
                    $('#MainContent_txtClienteEditar').val($(lblcliente_grilla).text());

                    $('#MainContent_txtEmisionEdicion').val(result.split('~')[2]);
                    $('#MainContent_ddlFormaPagoEdicion').val(result.split('~')[4]);
                    $('#MainContent_txtVencimientoEdicion').val(result.split('~')[3]);
                    $('#MainContent_txtPlaca1Edicion').val(result.split('~')[5]);
                    $('#MainContent_txtPlaca2Edicion').val(result.split('~')[6]);
                    $('#MainContent_txtPlaca3Edicion').val(result.split('~')[7]);
                    $('#MainContent_txtPlaca4Edicion').val(result.split('~')[8]);
                    $('#MainContent_txtPlaca5Edicion').val(result.split('~')[33]);
                    $('#MainContent_txtPlaca6Edicion').val(result.split('~')[34]);
                    $('#MainContent_txtPlaca7Edicion').val(result.split('~')[35]);
                    $('#MainContent_txtPlaca8Edicion').val(result.split('~')[36]);
                    $('#hfCodConductor').val(result.split('~')[39]);
                    $('#MainContent_txtConductorDNIEdicion').val(result.split('~')[37]);
                    $('#MainContent_txtConductorRazonSocialEdicion').val(result.split('~')[38]);
                    $('#MainContent_txtKMEdicion').val(result.split('~')[10]);
                    $('#hfCodCtaCteEdicion').val(result.split('~')[9]);

                    $('#hfCodTraslado').val(result.split('~')[11]);
                    $('#MainContent_txtNumeroGuiaEdicion').val(result.split('~')[13]);
                    $('#MainContent_txtFechaTrasladoEdicion').val(result.split('~')[14]);

                    //MIGUEL GUIA
                      $('#hfCodConductor').val(result.split('~')[39]);
                    $('#MainContent_ddlVendedorEdicion').val(result.split('~')[41]);
                    $('#MainContent_txtNombreAgencia').val(result.split('~')[42]);
                    $('#MainContent_txtGuiaAgencia').val(result.split('~')[43]);
                    $('#MainContent_txtClaveAgencia').val(result.split('~')[44]);
                    $('#MainContent_txtResponsable1Edicion').val(result.split('~')[47]);
                    $('#MainContent_txtResponsableDNI1Edicion').val(result.split('~')[48]);
                    $('#MainContent_txtResponsable2Edicion').val(result.split('~')[49]);
                    $('#MainContent_txtResponsableDNI2Edicion').val(result.split('~')[50]);

                    $('#MainContent_txtDistritoTransportistaEdicion').val(result.split('~')[45]);

                    if (result.split('~')[14] === "")
                        $('#MainContent_txtFechaTrasladoEdicion').val(result.split('~')[2]);

                         if ((result.split('~')[12]).substring(0,1)==="T" && $('#hfCodTraslado').val() != 0){
                         $("#MainContent_ddlSerieGuiaEdicion option:selected").text(result.split('~')[12]);

                                                  $('#MainContent_ddlSerieGuiaEdicion').prop('disabled',true);
                         $('#MainContent_txtNumeroGuiaEdicion').prop('disabled',true);
                         $('#MainContent_txtFechaTrasladoEdicion').prop('disabled',true);
                         $('#MainContent_txtDestinoEdicion').prop('disabled',true);
                         $('#MainContent_txtNroRucTransportistaEdicion').prop('disabled',true);
                         $('#MainContent_txtTransportistaEdicion').prop('disabled',true);
                         $('#MainContent_txtDistritoTransportistaEdicion').prop('disabled',true);
                         $('#MainContent_txtDireccionTransportistaEdicion').prop('disabled',true);
                         $('#MainContent_txtPlacaTrasladoEdicion').prop('disabled',true);
                         $('#MainContent_txtMarcaGuiaEdicion').prop('disabled',true);
                         $('#MainContent_txtLicenciaGuiaEdicion').prop('disabled',true);
                         $('#MainContent_txtNuBultosEdicion').prop('disabled',true);
                         $('#MainContent_txtConductorDNIEdicion').prop('disabled',true);
                         $('#MainContent_txtConductorRazonSocialEdicion').prop('disabled',true);
                         $('#MainContent_chkGuiaEdicion').prop('disabled',true);

                        
                        }else
                        {
                         $('#MainContent_ddlSerieGuiaEdicion').prop('disabled',false);
                         $('#MainContent_txtNumeroGuiaEdicion').prop('disabled',false);
                         $('#MainContent_txtFechaTrasladoEdicion').prop('disabled',false);
                         $('#MainContent_txtDestinoEdicion').prop('disabled',false);
                         $('#MainContent_txtTransportistaEdicion').prop('disabled',false);
                         $('#MainContent_txtDistritoTransportistaEdicion').prop('disabled',false);
                         $('#MainContent_txtDireccionTransportistaEdicion').prop('disabled',false);
                         $('#MainContent_txtPlacaTrasladoEdicion').prop('disabled',false);
                         $('#MainContent_txtMarcaGuiaEdicion').prop('disabled',false);
                         $('#MainContent_txtLicenciaGuiaEdicion').prop('disabled',false);
                         $('#MainContent_txtNuBultosEdicion').prop('disabled',false);
                         
                         $('#MainContent_txtConductorDNIEdicion').prop('disabled',false);
                         $('#MainContent_txtConductorRazonSocialEdicion').prop('disabled',false);
                        $('#MainContent_chkGuiaEdicion').prop('disabled',false);
                        }

                        
                         $('#MainContent_ddlFormaPagoEdicion').prop('disabled',true);
                         
                         $('#MainContent_txtVencimientoEdicion').prop('disabled',true);
                    $('#MainContent_txtDestinoEdicion').val(result.split('~')[15]);
                    $('#hfDestinoEdicion').val(result.split('~')[15]);
                    $('#MainContent_txtDireccionTransportistaEdicion').val(result.split('~')[16]);
                    $('#hfDireccionTransportista').val(result.split('~')[16]);

                    $('#hfCodTransportistaEdicion').val(result.split('~')[17]);
                    $('#MainContent_txtTransportistaEdicion').val(result.split('~')[18]);
                    $('#hfDireccionFacturaEditar').val(result.split('~')[18]);
                    $('#hfCodDireccionTransportistaEdicion').val(result.split('~')[20]);
                    $('#MainContent_txtNroOCEdicion').val(result.split('~')[21]);
                    $('#MainContent_txtRecepcion').val(result.split('~')[22]);
                  $('#MainContent_txtNroRucTransportistaEdicion').val(result.split('~')[18].split('-')[0].trim());
                    if (result.split('~')[23] == "1")
                        $('#MainContent_chkComisionableEdicion').prop('checked',true);
                    else
                        $('#MainContent_chkComisionableEdicion').prop('checked',false);

                         if (result.split('~')[46] == "1")
                        $('#MainContent_chkMotorizadoEdicion').prop('checked',true);
                    else
                        $('#MainContent_chkMotorizadoEdicion').prop('checked',false);

                        F_BuscarResponsablesEdicion();
                    if (Number($('#hfCodTraslado').val()) == 0)
                        {
                        $('#MainContent_chkGuiaEdicion').prop('checked', false);
                        
            $('#MainContent_ddlSerieGuiaEdicion').prop('disabled', true);
            $('#MainContent_txtNumeroGuiaEdicion').prop('disabled', true);
            $('#MainContent_txtNroRucTransportistaEdicion').prop('disabled', true);
            $('#MainContent_txtTransportistaEdicion').prop('disabled', true);
            $('#MainContent_txtDireccionTransportistaEdicion').prop('disabled', true);
            $('#MainContent_txtNuBultosEdicion').prop('disabled', true);       
            $('#MainContent_txtDestinoEdicion').prop('disabled', true);
            $('#MainContent_txtDistritoTransportistaEdicion').prop('disabled', true);
            $('#MainContent_txtPlacaTrasladoEdicion').prop('disabled', true);
            $('#MainContent_txtMarcaGuiaEdicion').prop('disabled', true);
            $('#MainContent_txtLicenciaGuiaEdicion').prop('disabled', true);
            $('#MainContent_txtConductorDNIEdicion').prop('disabled', true);
            $('#MainContent_txtConductorRazonSocialEdicion').prop('disabled', true);
                        }
                    else{
                        $('#MainContent_chkGuiaEdicion').prop('checked', true);
                        }

                    $('#MainContent_txtPlacaTrasladoEdicion').val(result.split('~')[24]);
                    $('#MainContent_txtMarcaGuiaEdicion').val(result.split('~')[25]);
                    $('#MainContent_txtLicenciaGuiaEdicion').val(result.split('~')[26]);
                    $('#MainContent_txtNuBultosEdicion').val(result.split('~')[27]);
                    $('#MainContent_txtPesoEdicion').val(result.split('~')[28]);

                    $('#MainContent_txtNroOperacionEdicion').val(result.split('~')[29]);
                    $('#MainContent_txtNroOCEdicion').val(result.split('~')[30]);
                    $('#MainContent_txtRequerimientoEdicion').val(result.split('~')[31]);
                    $('#MainContent_txtObservacionEdicion').val(result.split('~')[32]);
                    $('#hfNroRucCliente').val();

                    if ($(hfcodtipodoc_grilla).val()==16)
                        $('#MainContent_chkGuiaEdicion').prop('disabled', true);

                    $('#MainContent_chkImpresionGuiaEdicion').prop('checked',true);
                        $('#div_Editar').dialog({
                                resizable: false,
                                modal: true,
                                title: "Edicion de Documento de Venta",
                                title_html: true,
                                height: 450,
                                width: 970,
                                autoOpen: false
                        });

                        F_GuardarDireccion($('#hfNroRucCliente').val(),'#hfCodigoTemporalEdicion',$('#hfCodCtaCteEdicion').val(),'#MainContent_txtClienteEditar',
                                    0,Ubigeo,Direccion,'#MainContent_ddldireccionNuevaDestinoEdicion','',Codtipodoc);
                    
                    if ($('#hfCodTransportista').val()>0 || $('#hfCodConductor').val()>0)
                    {
                        F_GuardarDireccion($('#MainContent_txtNroRucTransportistaEdicion').val(),'#hfCodigoTemporalEdicion',$('#hfCodTransportistaEdicion').val(),
                                          '#MainContent_txtTransportistaEdicion',1,Ubigeo,Direccion,'#MainContent_ddldireccionNuevaTransportistaEdicion','',Codtipodoc);
                   }
                    else
                    {
                        BloqueoTipoTransportista(result.split('~')[10],(Cuerpo + 'txtNumeroGuiaEdicion'),(Cuerpo + 'txtFechaTrasladoEdicion'),
                        (Cuerpo + 'ddldireccionNuevaDestinoEdicion'),(Cuerpo + 'txtTransportistaEdicion'),(Cuerpo + 'txtNroRucTransportistaEdicion'),(Cuerpo + 'txtPlacaTrasladoEdicion'),
                        (Cuerpo + 'txtLicenciaGuiaEdicion'),(Cuerpo + 'txtNuBultosEdicion'),(Cuerpo + 'txtPesoEdicion'),(Cuerpo + 'txtConductorRazonSocialEdicion'),
                        (Cuerpo + 'txtConductorDNIEdicion'),$(Cuerpo + 'ddlTipoTransportistaEdicion').val(),(Cuerpo + 'ddldireccionNuevaTransportistaEdicion'),$('hfCodConductor').val(),
                        (Cuerpo + 'txtMarcaGuiaEdicion'),'#MainContent_ImageButton3','#MainContent_ImageButton4','#MainContent_chkGuiaEdicion'); 
                    }                
                  
                    if ($('#MainContent_txtNroRucTransportistaEdicion').val() + $('#MainContent_txtConductorDNIEdicion').val() != '')
                    {
                         if ($('#MainContent_txtNroRucTransportistaEdicion').val()=='')
                             $('#MainContent_ddlTipoTransportistaEdicion').val(2);
                         else
                             $('#MainContent_ddlTipoTransportistaEdicion').val(1);                      
                    }

                        $('#div_Editar').dialog('open');

                    }
                    else 
                    {
                        alertify.log(result.split('~')[1]);
                        $('#hfCodTipoDocEdicion').val('0');  
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

function F_GuardarCambiosFactura() { 

 try 
        {

    var FlagComisionable = 0; if ($('#MainContent_chkComisionableEdicion').is(':checked')) {FlagComisionable = 1; };
    var FlagGuia = 0; if ($('#MainContent_chkGuiaEdicion').is(':checked')) {FlagGuia = 1; };
      var FlagMotorizado = 0; if ($('#MainContent_chkMotorizadoEdicion').is(':checked')) {FlagMotorizado = 1; };

    var objParams = {
                      Filtro_CodDocumentoVenta: $('#hfCodFacturaEdicion').val(),
                      Filtro_CodTipoDoc: $('#hfCodTipoDocEdicion').val(),
                      Filtro_Emision:  $('#MainContent_txtEmisionEdicion').val(),
                      Filtro_CodFormaPago:  $('#MainContent_ddlFormaPagoEdicion').val(),
                      Filtro_Vencimiento:  $('#MainContent_txtVencimientoEdicion').val(),
                      Filtro_Placa1:  $('#MainContent_txtPlaca1Edicion').val(),
                      Filtro_Placa2:  $('#MainContent_txtPlaca2Edicion').val(),
                      Filtro_Placa3:  $('#MainContent_txtPlaca3Edicion').val(),
                      Filtro_Placa4:  $('#MainContent_txtPlaca4Edicion').val(),
                      Filtro_Placa5:  $('#MainContent_txtPlaca5Edicion').val(),
                      Filtro_Placa6:  $('#MainContent_txtPlaca6Edicion').val(),
                      Filtro_Placa7:  $('#MainContent_txtPlaca7Edicion').val(),
                      Filtro_Placa8:  $('#MainContent_txtPlaca8Edicion').val(),
                      Filtro_KM: $('#MainContent_txtKMEdicion').val(),
                      Filtro_FechaTraslado: $('#MainContent_txtFechaTrasladoEdicion').val(),
                      Filtro_NroOperacion:  $('#MainContent_txtNroOperacionEdicion').val(),
                      Filtro_NroOC:$('#MainContent_txtNroOCEdicion').val(),
                      Filtro_FlagComisionable:FlagComisionable,
                      Filtro_FlagMotorizado:FlagMotorizado,
                      Filtro_Recepcion:  $('#MainContent_txtRecepcion').val(),

                      Filtro_Requerimiento: $('#MainContent_txtRequerimientoEdicion').val(),
                      Filtro_Observacion: $('#MainContent_txtObservacionEdicion').val(),
                      Filtro_GuiaAgencia: $('#MainContent_txtGuiaAgencia').val(),
                      Filtro_NombreAgencia: $('#MainContent_txtNombreAgencia').val(),
                      Filtro_txtClaveAgencia: $('#MainContent_txtClaveAgencia').val(),
                       Filtro_CodVendedor:  $('#MainContent_ddlVendedorEdicion').val(), 
                       Filtro_Responsable1: $('#MainContent_txtResponsable1Edicion').val(),
                       Filtro_ResponsableDni1:  $('#MainContent_txtResponsableDNI1Edicion').val(),
                      Filtro_Responsable2: $('#MainContent_txtResponsable2Edicion').val(),
                       Filtro_ResponsableDni2:  $('#MainContent_txtResponsableDNI2Edicion').val(),

//                          //transportista  -- miguel
//                          
//                      Filtro_PlacaTraslado: $('#MainContent_txtPlacaTrasladoEdicion').val(),
//                      Filtro_MarcaTraslado: $('#MainContent_txtMarcaGuiaEdicion').val(),
//                      Filtro_LicenciaTraslado: $('#MainContent_txtLicenciaGuiaEdicion').val(),
//                      Filtro_NroBultos: $('#MainContent_txtNuBultosEdicion').val(),
//                      Filtro_PesoBultos: $('#MainContent_txtPesoEdicion').val(),
//                      Filtro_NroRucTransportista: $('#MainContent_txtNroRucTransportistaEdicion').val(),
//                      Filtro_Transportista: $('#MainContent_txtTransportistaEdicion').val(),
//                      Filtro_CodDepartamentoTransportista: $('#hfCodDepartamentoTransportistaEdicion').val(),
//                      Filtro_CodProvinciaTransportista: $('#hfCodProvinciaTransportistaEdicion').val(),
//                      Filtro_CodDistritoTransportista: $('#hfCodDistritoTransportistaEdicion').val(),

//                      Filtro_Destino: $('#MainContent_txtDestinoEdicion').val(),
//                      Filtro_CodTransportista: $('#hfCodTransportistaEdicion').val(),
//                      Filtro_CodDireccionTransportista: $('#hfCodDireccionTransportistaEdicion').val(),
//                      Filtro_DireccionTransportista: $('#MainContent_txtDireccionTransportistaEdicion').val(),
//                      Filtro_DireccionTraslado: $('#MainContent_txtDireccionTransportistaEdicion').val(),
//                      Filtro_FlagGuia: FlagGuia,
//                      Filtro_CodTraslado: $('#hfCodTraslado').val(),
//                      Filtro_SerieGuia: $('#MainContent_ddlSerieGuiaEdicion option:selected').text(),
//                      Filtro_NumeroGuia: $('#MainContent_txtNumeroGuiaEdicion').val(),
//                     
//                        Filtro_CodConductor:$('#hfCodConductor').val(),
//                         Filtro_TipoTransportista: $('#MainContent_ddlTipoTransportistaEdicion').val(),
//                         Filtro_codunidadpeso: $('#MainContent_ddlcodunidadpesoedicion').val()
                     // DATOS DE LA GUIA 

                      Filtro_FlagGuia:FlagGuia,
                      Filtro_SerieGuia: $('#MainContent_ddlSerieGuiaEdicion option:selected').text(),
                      Filtro_NumeroGuia: $('#MainContent_txtNumeroGuiaEdicion').val(),
                      Filtro_CodTipoTransportista: $('#MainContent_ddlTipoTransportistaEdicion').val(),
                      Filtro_FechaTraslado: $('#MainContent_txtFechaTrasladoEdicion').val(),   
                      Filtro_CodDocumentoVentaDireccionDestino: $('#MainContent_ddldireccionNuevaDestinoEdicion').val(),             
                      Filtro_CodTransportista: $('#hfCodTransportistaEdicion').val(),
                      Filtro_CodDocumentoVentaDireccionTransportista: $('#MainContent_ddldireccionNuevaTransportistaEdicion').val(),
                      Filtro_NroRucTransportista: $('#MainContent_txtNroRucTransportistaEdicion').val(),
                      Filtro_RazonSocialTransportista: $('#MainContent_txtTransportistaEdicion').val(),                     
                      Filtro_PlacaTraslado:$('#MainContent_txtPlacaTrasladoEdicion').val(),
                      Filtro_MarcaVehiculo: $('#MainContent_txtMarcaGuiaEdicion').val(),  
                      Filtro_Licencia: $('#MainContent_txtLicenciaGuiaEdicion').val(),
                      Filtro_NroBultos: $('#MainContent_txtNuBultosEdicion').val(),
                      Filtro_Peso: $('#MainContent_txtPesoEdicion').val(),
                      Filtro_CodUnidadPeso: $('#MainContent_ddlcodunidadpesoedicion').val(),
                      Filtro_CodConductor: $('#hfCodConductor').val(),
                      Filtro_ObservacionGuia: $('#MainContent_txtObservacionGuiaEdicion').val(),
                      Filtro_CodTrasladoEdicion: $('#hfCodTraslado').val()         

                    };

    var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
    MostrarEspera(true);
    F_EdicionFactura_NET(arg, function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") {

                        $('#div_Editar').dialog('close');

                        F_Buscar();

//                         if ($('#MainContent_chkImpresionGuiaEdicion').is(':checked') | result.split('~')[2] > 0) 
//                        {
//                            var CodMenu = 102; 
//                            var Tipo = 'IMP';                                                   
//                            F_ImprimirFactura(result.split('~')[2],CodMenu,Tipo) 
//                        }

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

function getContentTab(){
    $('#MainContent_chkRango').prop('checked',true);
    if ($('#MainContent_ddlTipoDoc2').val()==16)
        $('#MainContent_ddlEstadoConsultaNP').prop('disabled',false);
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
   
    if ($(lblEstado).text()=='Anulado(a)' | $(lblEstado).text()=='ANULADO')
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
    var CodMenu = '204';
    var NombreTabla = 'GuiaImpresion';
    var NombreArchivo = 'rptTrasladosCab_Impresion.rpt';


    rptURL = '../Reportes/Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Codigo=' + $(lblCodigo).val() + '&' ;
    rptURL = rptURL + 'NombreTabla=' + NombreTabla + '&' ;
    rptURL = rptURL + 'NombreArchivo=' + NombreArchivo + '&' ;
      
    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

function F_ImpresionGrabar(Codigo, CodTipoDoc, NumeroDoc, TipoImp) {
    if (!F_ValidarTipoImpresion(NumeroDoc, TipoImp, CodTipoDoc))
        return false;
    
    var CodMenu = 2001;

    if (CodTipoDoc == '15') {
        CodMenu = 4; }
    else if (CodTipoDoc == '16') {
        //CodMenu = 5; 
        }
    else {
        //si no es electronica imprime normal
        if (NumeroDoc.substr(0, 1) == 'F' | NumeroDoc.substr(0, 1) == 'B') { }
        else { TipoImp  = 'MTK'; }
    }

    F_ImpresionDefinitiva(CodMenu, Codigo, NumeroDoc, CodTipoDoc, TipoImp, 0);         
    return true;
}

function F_ImprimirFacturaHTML(Fila) {
    var imgID = Fila.id;
    var Guia = $('#' + imgID.replace('imgPdf2', 'hfCodTraslado')).val() ;
    var Codigo = '#' + imgID.replace('imgPdf2', 'lblCodigo');  
    var hfCodTipoDoc = '#' + imgID.replace('imgPdf2', 'hfCodTipoDoc');  
    var TipoImp = 'PDF'
    var CodMenu = 203; 

    if ($('#MainContent_ddlVisualizar').val()==1){
        Guia=0;
    }

    if (Guia == 0)
    {
        TipoImp = 'IMP'

        if ($(hfCodTipoDoc).val()==15)
            CodMenu = 204;

        F_ImprimirFactura($(Codigo).val(),CodMenu,TipoImp);
        return false
    }
    else
    {    
         if($('#MainContent_ddlVisualizar').val()==10)
         {
             TipoImp = 'IMP'
             CodMenu = 100;
             F_ImprimirFactura(Guia,CodMenu,TipoImp);
             return false;         
         }
    }
    
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_Facturas_Guia_Lote2_PDF',
        data: "{'Codigos':'" + $(Codigo).val() + "','Guia':'" + Guia + "','TipoImp':'" + TipoImp + "'}",
        dataType: "json",
        async: true,
        success: function (data) {
            if (data.d === "")
                toastr.error("no se pudo descargar los documentos");

            var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';

            window.open(data.d, 'PopUpRpt', Params);         
        },
        error: function (response) {
            toastr.error(response.responseText);
          
        },
        failure: function (response) {
            toastr.error(response.responseText);
          
        }
    });


    return false;
}

function F_ValidarTipoImpresion (NumeroDocumento, TipoImp, CodTipoDoc) {
    //VALIDACONES PRE IMPRESION
    if (NumeroDocumento.substr(0, 1) == 'F' || NumeroDocumento.substr(0, 1) == 'B')
    {
        switch (TipoImp) {
            case 'PDF':  
                break;
            case 'IMP':
                break;
            case 'TK':
                break;
        }
    }
    else if (CodTipoDoc == '15')
    {
        switch (TipoImp) {
            case 'PDF':  
                //alertify.log('OPCION NO VALIDA PARA ESTE TIPO DE DOCUMENTO');
                //return false;
                break;
            case 'IMP':
                //alertify.log('OPCION NO VALIDA PARA ESTE TIPO DE DOCUMENTO');
                //return false;
                break;
            case 'TK':
                break;
        }        
    }
    else if (CodTipoDoc == '16')
    {
        switch (TipoImp) {
            case 'PDF':  
                //alertify.log('OPCION NO VALIDA PARA ESTE TIPO DE DOCUMENTO');
                //return false;
                break;
            case 'IMP':
//                alertify.log('OPCION NO VALIDA PARA ESTE TIPO DE DOCUMENTO');
//                return false;
                break;
            case 'TK':
                break;
        }        
    }
    else
    {
        switch (TipoImp) {
            case 'PDF':  
                alertify.log('OPCION NO VALIDA PARA ESTE TIPO DE DOCUMENTO');
                return false;
                break;
            case 'IMP':
                break;
            case 'TK':
                alertify.log('OPCION NO VALIDA PARA ESTE TIPO DE DOCUMENTO');
                return false;
                break;
        }    
    }

return true;
}

function F_EnvioCorreoDirecto(Codigo, CodTipoDoc) {

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    rptURL = '../Reportes/Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodDocumentoVenta=' + Codigo + '&';
    rptURL = rptURL + 'CodSede=' + $('#hfCodSede').val() + '&';
    rptURL = rptURL + 'SerieDoc=' + SerieDoc.substr(0, 4) + '&';
    rptURL = rptURL + 'CodTipoDoc=' + CodTipoDoc + '&';
    rptURL = rptURL + 'TipoImpresion=' + TipoImp + '&';
    rptURL = rptURL + 'NroCopias=' + NroCopias + '&';

    window.open(rptURL, "PopUpRpt", Params);

return true;
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

                if (str_resultado_operacion == "1") {
                    $('#MainContent_lblTC').text(result.split('~')[2]);
                    $('#MainContent_lblTC2').text(result.split('~')[3]); }
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

        $('#MainContent_txtUltimoPrecio').val('');
        $('#MainContent_txtMonedaPrecio').val('');
        $('#MainContent_txtFechaPrecio').val('');
        $('#MainContent_txtCantidadPrecio').val('');
        $('#MainContent_txtDescripcion2').val('');
        $('#MainContent_txtModelo').val('');
        $('#MainContent_txtMotor').val('');
        $('#MainContent_txtPosicion').val('');
        $('#MainContent_txtAño').val('');
        $('#MainContent_txtMedida').val('');

//        CodNeumatico = $('#' + HlkControlID).text();
        CodProducto = $('#' + HlkControlID.replace('hlkCodigo', 'hfcodproducto')).val();
        var DscProducto2 = $('#' + HlkControlID.replace('hlkCodigo', 'hfDscProducto2')).val();
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
                    $('#MainContent_txtDescripcion2').val(DscProducto2);
                    $('#MainContent_txtModelo').val(result.split('~')[6]);
                    $('#MainContent_txtMotor').val(result.split('~')[7]);
                    $('#MainContent_txtPosicion').val(result.split('~')[8]);
                    $('#MainContent_txtAño').val(result.split('~')[9]);
                    $('#MainContent_txtMedida').val(result.split('~')[10]);
                        $('#div_ultimoprecio').dialog({
                                resizable: false,
                                modal: true,
                                title: "Historial Venta",
                                title_html: true,
                                height: 250,
                                width: 400,
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
                        title: "Facturacion Orden de Venta",
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
                        cadena = cadena + "\n" + "Cantidad para el Codigo " + $(lblCodigo).val();
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
                Filtro_Tasa: $(Contenedor + 'lblTC').text(),
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

                    var Moneda = 'S/ ';
                    if ($('#MainContent_ddlMoneda').val() === "2")
                        Moneda = '$ ';

                    $('#hfCodigoTemporal').val(result.split('~')[3]);
                    $('#MainContent_txtTotal').val(result.split('~')[5]);
                    $('#MainContent_txtTotal2').val(Moneda + result.split('~')[5]);
                    $('#MainContent_txtMonto').val(result.split('~')[5]);
                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                    $('#MainContent_txtDsctoTotal').val(result.split('~')[8]);
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                    if (result.split('~')[2] == 'Los Producto(s) se han agregado con exito')
                        alertify.log('Los Producto(s) se han agregado con exito4');
                }
                else {
                    MostrarEspera(false);
                    alertify.log(result.split('~')[2]);

                }
                F_ContarItems();
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
                    F_Update_Division_HTML('div_DetalleOC', result.split('~')[2]);
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

function F_ValidarStockGrillaNV(ControlID) {


    
    var txtcantidad_Grilla = '';
    var lblstock = '';
    var txtcant_grilla = '';
    var boolEstado = false;
    var chkok_grilla = '';

    txtcantidad_Grilla = '#' + ControlID;
    chkok_grilla = txtcantidad_Grilla.replace('txtCantidadEntregada', 'chkEliminar');
    lblstock = txtcantidad_Grilla.replace('txtCantidadEntregada', 'lblCantidad');

    
    boolEstado = $(chkok_grilla).is(':checked');

    if (!F_ValidarAgregarNV(1))
      return false;

//    if (boolEstado &&  parseFloat($(txtcantidad_Grilla).val()) > parseFloat($(lblstock).text())) {
//            alertify.log("Stock insuficiente");
//            $(txtcantidad_Grilla).val($(lblstock).text());
//            F_MostrarTotales();
//            return false;
//    }
    if ($(txtcantidad_Grilla).val()=='')
        $(txtcantidad_Grilla).val($(lblstock).text());
    
    if (boolEstado==false)
     $(txtcantidad_Grilla).val($(lblstock).text());


     F_AgregarTemporalNV();
    return true;
}

function F_ValidarStockGrillaCT(ControlID) {


    
    var txtcantidad_Grilla = '';
    var lblstock = '';
    var txtcant_grilla = '';
    var boolEstado = false;
    var chkok_grilla = '';

    txtcantidad_Grilla = '#' + ControlID;
    chkok_grilla = txtcantidad_Grilla.replace('txtCantidadEntregada', 'chkEliminar');
    lblstock = txtcantidad_Grilla.replace('txtCantidadEntregada', 'lblCantidad');

    
    boolEstado = $(chkok_grilla).is(':checked');

//    if (boolEstado &&  parseFloat($(txtcantidad_Grilla).val()) > parseFloat($(lblstock).text())) {
//            alertify.log("Stock insuficiente");
//            $(txtcantidad_Grilla).val($(lblstock).text());
//            F_MostrarTotales();
//            return false;
//    }
//    if ($(txtcantidad_Grilla).val()=='')
//        $(txtcantidad_Grilla).val($(lblstock).text());
//    
//    if (boolEstado==false)
//     $(txtcantidad_Grilla).val($(lblstock).text());

    if (!F_ValidarAgregarCT(1))
      return false;

F_AgregarTemporalCT();
    return true;
}

function ValidarRuc(valor) {
    valor = trim(valor)
    if (esnumero(valor)) {
        if (valor.length < 11) {
            if (valor.length == 8)
                return true;
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

function ValidarSoloRuc(valor) {
    valor = trim(valor)
    if (esnumero(valor)) {
        if (valor.length < 11) {
            if (valor.length == 8)
                return false;
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

                    var Moneda = 'S/ ';
                    if ($('#MainContent_ddlMoneda').val() === "2")
                        Moneda = '$ ';

                   $('#hfCodigoTemporal').val(result.split('~')[2]);
                   $('#hfCodCtaCte').val(result.split('~')[3]);
                   $('#MainContent_ddlMoneda').val(result.split('~')[4]);
                   $('#MainContent_txtSubTotal').val(result.split('~')[5]);
                   $('#MainContent_txtIgv').val(result.split('~')[6]);
                   $('#MainContent_txtTotal').val(result.split('~')[7]);
                   $('#MainContent_txtTotal2').val(Moneda + result.split('~')[7]);
                   $('#hfCodDepartamento').val(result.split('~')[8]);
                   $('#hfCodProvincia').val(result.split('~')[9]);
                   $('#hfCodDistrito').val(result.split('~')[10]);
                   $('#MainContent_txtDireccion').val(result.split('~')[11]);
                   $('#MainContent_txtNroRuc').val(result.split('~')[12]);
                   $('#MainContent_txtDistrito').val(result.split('~')[13]);
                   $('#MainContent_txtCliente').val(result.split('~')[14]);
                   $('#hfCliente').val(result.split('~')[14]);
                   F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[15]);
                   
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
                Filtro_Tasa: $(Contenedor + 'lblTC').text(),
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

                    var Moneda = 'S/ ';
                    if ($('#MainContent_ddlMoneda').val() === "2")
                        Moneda = '$ ';

                    $('#hfCodigoTemporal').val(result.split('~')[3]);
                    $('#MainContent_txtTotal').val(result.split('~')[5]);
                    $('#MainContent_txtTotal2').val(Moneda + result.split('~')[5]);
                    $('#MainContent_txtMonto').val(result.split('~')[5]);
                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                    $('#MainContent_txtDsctoTotal').val(result.split('~')[8]);
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                    if (result.split('~')[2] == 'Los Producto(s) se han agregado con exito')
                        alertify.log('Los Producto(s) se han agregado con exito5');
                }
                else {
                    MostrarEspera(false);
                    alertify.log(result.split('~')[2]);

                }
                F_ContarItems();
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
                $('#hfCliente').val(result.split('~')[8]);
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

function F_ActualizarPrecio(Fila, Dcto) {

    if (Dcto=='') Dcto = 1;

 try 
        {
            var txtPrecio =  '#' + Fila;
           
            var lblcoddetalle = txtPrecio.replace('txtPrecio', 'lblcoddetalle');
            var hfPrecio = txtPrecio.replace('txtPrecio', 'hfPrecio');
            var hfCantidad = txtPrecio.replace('txtPrecio', 'hfCantidad');
            var txtCantidad = txtPrecio.replace('txtPrecio', 'txtCantidad');
            var hfCostoProductoSoles = txtPrecio.replace('txtPrecio', 'hfCostoProductoSoles');
            var hfCostoProductoDolares = txtPrecio.replace('txtPrecio', 'hfCostoProductoDolares');
            var hfMargen = txtPrecio.replace('txtPrecio', 'hfMargen');
            var hfRedondeo = txtPrecio.replace('txtPrecio', 'hfRedondeo');
            var hfFactorRedondeo = txtPrecio.replace('txtPrecio', 'hfFactorRedondeo');
            var hfDescuento = txtPrecio.replace('txtPrecio', 'hfDescuento');

            if(parseFloat($(txtPrecio).val())==parseFloat($(hfPrecio).val()) & parseFloat($(txtCantidad).val())==parseFloat($(hfCantidad).val())&Dcto<0)
            {
                $(txtPrecio).val(parseFloat($(txtPrecio).val()).toFixed(2));
                $(txtCantidad).val(parseFloat($(txtCantidad).val()).toFixed(2));
                return false;
            }

            
             if( parseFloat($(txtPrecio).val())<=0)
            {
            alertify.log("NO PUEDE SER LA CANTIDAD MENOR O IGUAL A CERO");
            $(txtPrecio).val(parseFloat($(hfPrecio).val()).toFixed(2));
            return false;
            }

              if( $(txtPrecio).val()=="")
            {
          
            $(txtPrecio).val(parseFloat($(hfPrecio).val()).toFixed(2));
            return false;
            }

            
            var tasaigv = parseFloat( $("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

            var Precio = $(txtPrecio).val();
            var Costo = 0;
            var Descuento = 0;

             if( parseFloat($('#hfCodtipodoctemporal').val())>0)
            {
            alertify.log("NO SE PUDE EDITAR PRECIOS DIFERENTES A LA PROFORMA");
            $(txtPrecio).val(parseFloat($(hfPrecio).val()).toFixed(2));
            return false;
            }

            if (Dcto>=0)
            {
                var DescuentoArticulo = Dcto;
                    if (DescuentoArticulo > Number($(hfDescuento).val()))
                        DescuentoArticulo = Number($(hfDescuento).val());

            if ($('#MainContent_ddlMoneda').val() == 1) 
                Costo = $(hfCostoProductoSoles).val();
            else 
                Costo = $(hfCostoProductoDolares).val();

            Precio = F_CalcularPrecioDescuento(Costo, $(hfMargen).val(), Number(DescuentoArticulo) / 100, $(hfRedondeo).val(), $(hfFactorRedondeo).val());
            }

            var objParams = {
                              Filtro_Precio: Precio / tasaigv,
                              Filtro_Cantidad: $(txtCantidad).val(),
                              Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
                              Filtro_CodDetDocumentoVenta: $(lblcoddetalle).val(),
                              Filtro_TasaIgv: tasaigv,
                              Filtro_NotaPedido: 0,
                              Filtro_Tasa: $('#MainContent_lblTC').text(),
                              Filtro_CodMoneda: $('#MainContent_ddlMoneda').val()
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
                   $('#hfNotaPedido').val(result.split('~')[8]);
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                }
                else {
                     F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                     alertify.log(result.split('~')[1]);
                }
                F_ContarItems();
                $('.ccsestilo').css('background', '#FFFFE0');
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

             if( parseFloat($(txtCantidad).val())<=0)
            {
            alertify.log("NO PUEDE SER LA CANTIDAD MENOR O IGUAL A CERO");
            $(txtCantidad).val(parseFloat($(hfCantidad).val()).toFixed(2));
            return false;
            }

              if( $(txtCantidad).val()=="")
            {
          
            $(txtCantidad).val(parseFloat($(hfCantidad).val()).toFixed(2));
            return false;
            }


            if( parseFloat($('#hfCodtipodoctemporal').val())>0)
            {
            alertify.log("NO SE PUDE EDITAR CANTIDADES DIFERENTES A LA PROFORMA");
            $(txtCantidad).val(parseFloat($(hfCantidad).val()).toFixed(2));
            return false;
            }
            
            var tasaigv=parseFloat( $("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

            var objParams = {
                              Filtro_Precio: $(txtPrecio).val()/tasaigv,
                              Filtro_Cantidad: $(txtCantidad).val(),
                              Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
                              Filtro_CodDetDocumentoVenta: $(lblcoddetalle).val(),
                              Filtro_TasaIgv: tasaigv,
                              Filtro_NotaPedido: 0,
                              Filtro_TipoCambio: $('#MainContent_lblTC').text(),
                              Filtro_Tasa: $('#MainContent_lblTC').text(),
                              Filtro_CodMoneda: $('#MainContent_ddlMoneda').val(),
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
                   $('#hfNotaPedido').val(result.split('~')[8]);
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                }
                else {
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                     alertify.log(result.split('~')[1]);
                }
                $('.ccsestilo').css('background', '#FFFFE0');

                F_ContarItems();
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
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

 try 
        {
    var imgID = Fila.id;
    var lblCodigo = '#' + imgID.replace('imgEliminarDocumento', 'lblCodigo');
    var lblEstado = '#' + imgID.replace('imgEliminarDocumento', 'lblEstado');
    var lblnumero_grilla = '#' + imgID.replace('imgEliminarDocumento', 'lblnumero');
    var lblcliente_grilla = '#' + imgID.replace('imgEliminarDocumento', 'lblcliente');    
    var hfcodtipodoc_grilla = '#' + imgID.replace('imgEliminarDocumento', 'hfCodTipoDoc');

    if ($(lblEstado).text() == 'FACTURADO' & ($(hfcodtipodoc_grilla).val() == '16' | $(hfcodtipodoc_grilla).val() == '15'))
        {
            alertify.log('EL DOCUMENTO SE ENCUENTRA EN ESTADO FACTURADO');
            return false;
        }

    if(!confirm("ESTA SEGURO DE ELIMINAR LA " +  $("#MainContent_ddlTipoDoc2 option:selected").text() + " : " + $(lblnumero_grilla).text() + "\nDEL CLIENTE : " +  $(lblcliente_grilla).text()))
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
                          Filtro_Codigo: $(lblCodigo).val(),
                          Filtro_Serie: $("#MainContent_ddlSerieConsulta option:selected").text(),
                          Filtro_Numero: $('#MainContent_txtNumeroConsulta').val(),
                          Filtro_Desde: $('#MainContent_txtDesde').val(),
                          Filtro_Hasta: $('#MainContent_txtHasta').val(),
                          Filtro_CodCtaCte: $('#hfCodCtaCteConsulta').val(),
                          Filtro_CodTipoDoc: $(hfcodtipodoc_grilla).val(),
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

function F_ReenvioMail(Fila) {

   var ID = Fila.id;
    var lblCodigo = '#' + ID.replace('imgMail', 'lblCodigo');
    var hfTipoDoc = '#' + ID.replace('imgMail', 'hfCodTipoDoc');
    var lblnumero = '#' + ID.replace('imgMail', 'lblnumero');
    var lblcliente = '#' + ID.replace('imgMail', 'lblcliente');

    var CodDocumentoVenta = $(lblCodigo).val();
    var CodProforma = 0;
    var Cliente = $(lblcliente).val();

    if ($(hfTipoDoc).val() === '15') {
        CodDocumentoVenta = 0;
        CodProforma = $(lblCodigo).val();
    }

    $('#hfCodDocumentoReenvioMail').val(CodDocumentoVenta);
    $('#hfCodProformaReenvioMail').val(CodProforma);
    $('#hfCodtipoDocReenvioMail').val($(hfTipoDoc).val());
    

        try {
            var objParams = {
                Filtro_CodDocumentoVenta: CodDocumentoVenta,
                Filtro_CodProforma: CodProforma
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);
            F_ListarEnviosCorreos_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

//                F_Update_Division_HTML('div_grvEnvioCorreos', result.split('~')[2]); 
                F_Update_Division_HTML('div_grvCorreos', result.split('~')[3]); 

                $("#div_EnvioCorreos").dialog({
                    resizable: false,
                    modal: true,
                    title: "Consulta de Envio de Correos",
                    title_html: true,
                    height: 550,
                    width: 600,
                    autoOpen: false
                });

                $('#MainContent_txtDocumentoDisplayRC').val($(lblnumero).text());
                $('#MainContent_txtClienteDisplayRC').val($(lblcliente).text());

                $('#div_EnvioCorreos').dialog('open');


                return false;

            });
        }
        catch (e) {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }
    return false;
















//    var ID = Fila.id;
//    var lblCodigo = '#' + ID.replace('imgMail', 'lblCodigo');
//    var hfTipoDoc = '#' + ID.replace('imgMail', 'hfCodTipoDoc');
//        if ($(hfTipoDoc).val() == 15)
//        {
//            F_ReenvioMailNP($(lblCodigo).val());
//            return false;
//        }

//        try {
//            var objParams = {
//                Filtro_Codigo: $(lblCodigo).val()
//            };

//            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
//            MostrarEspera(true);
//            F_ReenvioMail_NET(arg, function (result) {
//                MostrarEspera(false);

//                var str_resultado_operacion = "";
//                var str_mensaje_operacion = "";

//                str_resultado_operacion = result.split('~')[0];
//                str_mensaje_operacion = result.split('~')[1];

//                if (str_resultado_operacion == "1")
//                    alertify.log(str_mensaje_operacion);
//                else
//                    alertify.log(str_mensaje_operacion);

//                return false;

//            });
//        }
//        catch (e) {
//            MostrarEspera(false);
//            alertify.log("Error Detectado: " + e);
//            return false;
//        }
//    return false;
}

function F_HacerReenvio() {
  var C=0
   var arrDetalle = new Array();    
  $('#MainContent_grvConsultaCorreos .chkCorreo :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblCorreo_grilla = chkSi.replace('chkEliminar', 'lblCorreo');
                   C=C+1
                  if ($(chkSi).is(':checked')) 
                    {
                        var objDetalle = {
                       Orden :C,
                        Correo: $(lblCorreo_grilla).text()
                        };
                                               
                        arrDetalle.push(objDetalle);
                    }
                });

        try {
            var objParams = {
                Filtro_CodDocumentoVenta: $('#hfCodDocumentoReenvioMail').val(),
                Filtro_CodProforma:     $('#hfCodProformaReenvioMail').val(),
                Filtro_CodTipoDoc:      $('#hfCodtipoDocReenvioMail').val(),
                 Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);
            F_DocumentoVentaCab_ReenvioMail_Documentos_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                $('#div_EnvioCorreos').dialog('close');

                alertify.log(str_mensaje_operacion);


                return false;

            });
        }
        catch (e) {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }
    return false;















}

function F_ReenvioMail_OLD(Fila) {
    var ID = Fila.id;
    var lblCodigo = '#' + ID.replace('imgMail', 'lblCodigo');
    var hfTipoDoc = '#' + ID.replace('imgMail', 'hfCodTipoDoc');
        if ($(hfTipoDoc).val() == 15)
        {
            F_ReenvioMailNP($(lblCodigo).val());
            return false;
        }

        try {
            var objParams = {
                Filtro_Codigo: $(lblCodigo).val()
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);
            F_ReenvioMail_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1")
                    alertify.log(str_mensaje_operacion);
                else
                    alertify.log(str_mensaje_operacion);

                return false;

            });
        }
        catch (e) {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }
    return false;
}

function F_ReenvioMailNP(Codigo) {

    $('#hfCodNotaPedidoReenvioMail').val(Codigo);


        try {
            var objParams = {
                Filtro_Codigo: Codigo
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);
            F_ReenvioMailNP_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];
                $('#MainContent_txtResponsableReenvio').val(result.split('~')[2]);
                $('#MainContent_txtFacturaReenvio').val(result.split('~')[3]);
                $('#MainContent_txtCorreoResponsableReenvio1').val(result.split('~')[4]);
                $('#MainContent_txtCorreoResponsableReenvio2').val(result.split('~')[5]);
                $('#MainContent_txtCorreoResponsableReenvio3').val(result.split('~')[6]);
                $('#MainContent_txtCorreoResponsableReenvio4').val(result.split('~')[7]);
                $('#MainContent_txtCorreoResponsableReenvio5').val(result.split('~')[8]);
                $('#MainContent_txtCorreoResponsableReenvio6').val(result.split('~')[9]);

                $('#div_EmailsReenvio').dialog({
                    resizable: false,
                    modal: true,
                    title: "Envio de Emails de Cotizaciones",
                    title_html: true,
                    height: 320,
                    width: 620,
                    autoOpen: false
                });

                $('#div_EmailsReenvio').dialog('open');

                return false;

            });
        }
        catch (e) {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }
    return false;
}

function F_ReenvioMailNP_Enviar() {

        try {
            var objParams = {
                Filtro_Codigo: $('#hfCodNotaPedidoReenvioMail').val(),
                Filtro_Correo1: $('#MainContent_txtCorreoResponsableReenvio1').val(),
                Filtro_Correo2: $('#MainContent_txtCorreoResponsableReenvio2').val(),
                Filtro_Correo3: $('#MainContent_txtCorreoResponsableReenvio3').val(),
                Filtro_Correo4: $('#MainContent_txtCorreoResponsableReenvio4').val(),
                Filtro_Correo5: $('#MainContent_txtCorreoResponsableReenvio5').val(),
                Filtro_Correo6: $('#MainContent_txtCorreoResponsableReenvio6').val()
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);
            F_ReenvioMail_Enviar_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1")
                    alertify.log(str_mensaje_operacion);
                else
                    alertify.log(str_mensaje_operacion);


                $('#div_EmailsReenvio').dialog('close');
                $('#hfCodNotaPedidoReenvioMail').val(0);
                $('#MainContent_txtResponsableReenvio').val('');
                $('#MainContent_txtFacturaReenvio').val('');
                $('#MainContent_txtCorreoResponsableReenvio1').val('');
                $('#MainContent_txtCorreoResponsableReenvio2').val('');
                $('#MainContent_txtCorreoResponsableReenvio3').val('');
                $('#MainContent_txtCorreoResponsableReenvio4').val('');
                $('#MainContent_txtCorreoResponsableReenvio5').val('');
                $('#MainContent_txtCorreoResponsableReenvio6').val('');

                return false;

            });
        }
        catch (e) {
            MostrarEspera(false);
            alertify.log("Error Detectado: " + e);
            return false;
        }
    return false;
}

function F_ImpresionPedidos() {
    if ($('#MainContent_ddlEstado').val() == "14" || $('#MainContent_ddlEstado').val() == "3") {
        alertify.log("SELECCIONE AL MENOS UNA NOTA DE PEDIDO");
        return false;
    }

    var rptURL = '';
    var Params = 'width=' + (screen.width) + ', height=' + (screen.height) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var CodMenu = 2002;
    var CodTipoArchivo = 0;
    var chkSi = '';
    var arrDetalle = new Array();
    var lblID = '';
    var i = 0;
    var cn = 0;
    $('#MainContent_grvConsulta .chkDelete :checkbox').each(function () {
        chkSi = '#' + this.id;
        lblID = chkSi.replace('chkEliminar', 'lblCodigo');

        var lblCodigo = chkSi.replace('chkEliminar', 'lblCodigo');
        var lblNumero = chkSi.replace('chkEliminar', 'lblnumero');
        var hfTipoDoc = chkSi.replace('chkEliminar', 'hfCodTipoDoc');
        codigo = $(lblCodigo).val();
        nrodoc = $(lblNumero).text();
        TipoDoc = $(hfTipoDoc).val();

        if ((TipoDoc == '1' & nrodoc.substr(0,1) == 'F') | (TipoDoc == '2' & nrodoc.substr(0,1) == 'B'))
        {
            if ($(chkSi).is(':checked')) {
                var objDetalle = {
                    CodDocumentoVenta: $(lblID).val(),
                    NumeroFactura: nrodoc,
                    TipoDocumento: TipoDoc,
                    SerieDoc: nrodoc.substr(0, 4)
                };
                arrDetalle.push(objDetalle);
                i += 1;
            }
        } else
        {
            cn++;
        }



    });

    if (cn++ == 0)
    {
        if (i == 0) {
            alertify.log("SELECCIONE AL MENOS UNA NOTA DE PEDIDO");
            return false;
        }

        var XmlDetalle = Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle);

        rptURL = '../Reportes/Crystal.aspx';
        rptURL = rptURL + '?';
        rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
        rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
        rptURL = rptURL + 'Impresora=' + $("#MainContent_ddlImpresoraNotaPedido").val() + '&';
        rptURL = rptURL + 'CodSede=' + $('#hfCodSede').val() + '&';
        rptURL = rptURL + 'TipoImpresion=' + 'IMP' + '&';
        rptURL = rptURL + 'XmlDetalle=' + XmlDetalle + '&';

        window.open(rptURL, "PopUpRpt", Params);
    }
    else
    {
        alertify.log('SOLO SE PUEDEN ENVIAR DOCUMENTOS ELECTRONICOS FACTURAS Y BOLETAS');
    }
    return false;
}


var CodTipoDocActual = '';
var CodMonedaActual = '';
var SerieActual = '';
var CodFormaPagoActual = '';

function F_ActualizarDetalle(){
  try 
        {
//        if($('#MainContent_txtTotal').val()=='0.00')
//        return;

        var FlagIgv = 0;
        var Contenedor = '#MainContent_';    
        var tasaigv;

                if ($('#MainContent_chkConIgvMaestro').is(':checked'))
                 tasaigv=parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
                else
                 tasaigv=1;
                
        if($(Contenedor + 'chkConIgvMaestro').is(':checked')) 
             FlagIgv = 1; 
                
                var Contenedor = '#MainContent_';
                var tasaigv=parseFloat( $("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
                var objParams = {
                                        Filtro_CodTipoDoc: $("#MainContent_ddlTipoDoc").val(),
                                        Filtro_SerieDoc: $(Contenedor + 'ddlSerie').val(),
                                        Filtro_NumeroDoc: $(Contenedor + 'txtNumero').val(),
                                        Filtro_FechaEmision: $(Contenedor + 'txtEmision').val(),
                                        Filtro_Vencimiento: $(Contenedor + 'txtVencimiento').val(),
                                        //Filtro_CodCliente: $(Contenedor + 'hfCodCtaCte').val(),
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
                                        Filtro_Tasa: $('#MainContent_lblTC').text(),
                                        Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
                                        //Filtro_Servicio: chkServicio,
                                        //Filtro_NotaPedido: chkNotaPedido
                               };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
                MostrarEspera(true);
                F_ActualizarDetalle_NET(arg, function (result) {
                
                  MostrarEspera(false);

                   var str_resultado_operacion = result.split('~')[0];
                   var str_mensaje_operacion = result.split('~')[1];

                  if (str_mensaje_operacion == "Se Grabo Correctamente")
                   {                  
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                     $('.ccsestilo').css('background', '#FFFFE0');
                   }
                else 
                {
                     F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                      $('.ccsestilo').css('background', '#FFFFE0');
                }


                     //-------------------------------------------


            CodTipoDocActual = $("#MainContent_ddlTipoDoc").val();
            CodMonedaActual = $('#MainContent_ddlMoneda').val();
            SerieActual = $('#MainContent_ddlSerie').val();
            CodFormaPagoActual = $('#MainContent_ddlFormaPago').val();


        objParams =
            {
                Filtro_Fecha: $('#MainContent_txtEmision').val(),
                Filtro_CodDoc: $("#MainContent_ddlTipoDoc").val(),
                Filtro_CodEstado: 'A'
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
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") 
                    {
                        F_Update_Division_HTML('div_serie', result.split('~')[2]);
                        F_Update_Division_HTML('div_serieguia', result.split('~')[3]);
                        F_Update_Division_HTML('div_formapago', result.split('~')[4]);
                        F_Update_Division_HTML('div_FormaPagoEdicion', result.split('~')[19]);
                        //F_Update_Division_HTML('div_moneda', result.split('~')[5]);
                        $('#MainContent_lblTC').text(result.split('~')[6]);
                        $('#MainContent_lblTC2').text(result.split('~')[6]);

                        $('#MainContent_lblTCParalelo').text(result.split('~')[25]);
                        $('#MainContent_lblTC2Paralelo').text(result.split('~')[25]);
                        $('#MainContent_ddlSerieConsulta').val(61);
                        //F_Update_Division_HTML('div_serieconsulta', result.split('~')[9]);
                        //F_Update_Division_HTML('div_igv', result.split('~')[8]);
                        //$('#MainContent_ddlMoneda').val(1);

                       
                        $('#MainContent_txtNumero').val(result.split('~')[7]);
                        $('#MainContent_txtVencimiento').val($('#MainContent_txtEmision').val());
                        $('#hfCodUsuario').val(result.split('~')[10]);
                        $('#hfPartida').val(result.split('~')[11]);
                        $('#hfCodSede').val(result.split('~')[12]);
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                        $('#MainContent_ddlFormaPago').css('background', '#FFFFE0');
                        $('#MainContent_ddlFormaPagoEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerie').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerieConsulta').css('background', '#FFFFE0');
                        $('#MainContent_ddlSerieGuia').css('background', '#FFFFE0');
                        $('#MainContent_ddlIgv').css('background', '#FFFFE0');
                        $('#MainContent_ddlTipoDoc').css('background', '#FFFFE0');
                        $('#MainContent_txtAtencion').val('');
                        $('#MainContent_txtReferencia').val('');
                        $('.ccsestilo').css('background', '#FFFFE0');

                        F_CambioSerie();
                        
//            CodTipoDocActual = $("#MainContent_ddlTipoDoc").val();
//            CodMonedaActual = $('#MainContent_ddlMoneda').val();
//            SerieActual = $('#MainContent_ddlSerie').val();
//            CodFormaPagoActual = $('#MainContent_ddlFormaPago').val();

//                        FormaPagoDefault = result.split('~')[18];
//                        $('#MainContent_ddlFormaPago').val(CodFormaPagoActual);

                        if ($("#MainContent_ddlTipoDoc").val() == '16')
                        {
                            $('#MainContent_ddlFormaPago').val('11');
                        }

                        if ($("#MainContent_ddlTipoDoc").val() == '2')
                        {
                            $('#MainContent_ddlFormaPago').val('1');
                        }

                        F_ContarItems();
                        F_InicializarCorreos();
                        if ($("#MainContent_ddlTipoDoc").val() != '16')
                        F_LlenarCorreos();
                        else 
                        F_LlenarCorreosResponsable();

                    }
                    else {

                        alertify.log(str_mensaje_operacion);

                    }


                }
            );
                     //-------------------------------------------

                $('#hfNotaPedido').val(result.split('~')[8]);

                return false;

                });
        }
        
        catch (e) 
        {
              MostrarEspera(false);
            alertify.log("ERROR DETECTADO: " + e);
            return false;
        }
}

function F_AbrirPanelNV() {

    $('#MainContent_chkNotaVenta').prop('checked', false);
    $('#MainContent_chkClienteNV').prop('checked', false);
    $('#MainContent_chkPlacaNV').prop('checked', false);
    $('#MainContent_txtNumeroNotaVenta').val('');
    $('#MainContent_txtClienteNV').val('');
    $('#MainContent_txtPlacaNV').val('');
    

  try {
        var objParams = {
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_Inicializar_GrillaVacia_DetalleNV_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

                $('#divFacturacionNV').dialog({
                    resizable: false,
                    modal: true,
                    title: "Facturacion Nota de Pedido",
                    title_html: true,
                    height: 500,
                    width: 1100,
                    autoOpen: false
                });
                F_Update_Division_HTML('div_DetalleNV', result.split('~')[2]);
                $('.ccsestilo').css('background', '#FFFFE0');

                $('#divFacturacionNV').dialog('open');

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

function F_FacturacionNV(Desde, Hasta) {
    var Contenedor = '#MainContent_';
    var Mensaje = "Ingrese los sgtes datos: ";
    var NumeroDoc = "";
    var CodCliente = 0;
    var Placa = "";
    var Filtro_ChkNumero = 0;
    var Filtro_ChkFecha = 0;
    var Filtro_ChkCliente = 0;

    if ($(Contenedor + 'lblTC').text() == "0")
        Mensaje = Mensaje + "<p></p>" + "Tipo de Cambio";

    if ($('#MainContent_chkNotaVenta').is(':checked'))
        Filtro_ChkNumero = 1;

    if ($('#MainContent_chkNotaVenta').is(':checked'))
        Filtro_ChkNumero = 1;

    if ($('#MainContent_chkDesdeNV').is(':checked'))
            Filtro_ChkFecha = 1;

//    if (!$('#MainContent_chkConIgvMaestro').is(':checked')) {
//        Mensaje = Mensaje + "<p></p>" + "Con Igv debe estar chequeado";
//    }   
    if ($('#MainContent_chkClienteNV').is(':checked'))
    {
        CodCliente = $('#hfCodClienteNV').val();
        Filtro_ChkCliente = 1;
        if (CodCliente == '0' | $('#MainContent_txtClienteNV').val().trim() == '')
        {
        alertify.log('DEBE ESPECIFICAR CLIENTE');
        return false
    }
    }

    try {
        var objParams = {
            Filtro_Serie: $("#MainContent_ddlSerieNV option:selected").text(),
            Filtro_CodTipoDoc: 16,
            Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
            Filtro_ChkNumero: Filtro_ChkNumero,
            Filtro_Numero: NumeroDoc,
            Filtro_ChkFecha: Filtro_ChkFecha,
            Filtro_Desde: Desde,
            Filtro_Hasta: Hasta,
            Filtro_ChkCliente: Filtro_ChkCliente,
            Filtro_CodCliente: CodCliente,
            Filtro_Placa: Placa
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_FacturacionNV_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

//                $('#divFacturacionNV').dialog({
//                    resizable: false,
//                    modal: true,
//                    title: "Facturacion Nota de Venta",
//                    title_html: true,
//                    height: 500,
//                    width: 1000,
//                    autoOpen: false
//                });
                F_Update_Division_HTML('div_DetalleNV', result.split('~')[2]);
                $('.ccsestilo').css('background', '#FFFFE0');

//                $('#divFacturacionNV').dialog('open');

                if (str_mensaje_operacion != "")
                    alertify.log(str_mensaje_operacion);
                else
                    $('#divFacturacionNV').dialog('open');

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

function F_ValidarAgregarNV(msg) {
    try {
        var cadena = "Ingrese los sgtes. campos: ";
        var chkSi = '';
        var lblCodigo = '';
        var txtCantidadEntregada = '';
        var x = 0;

        $('#MainContent_grvDetalleNV .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;

            txtCantidadEntregada = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
            lblCodigo = chkSi.replace('chkEliminar', 'lblCodigo');

            if ($(chkSi).is(':checked')) {
                if ($(txtCantidadEntregada).val() === '')
                    cadena = cadena + "<p></p>" + "Cantidad para el Codigo " + $(lblCodigo).text();
                x = 1;
            }
        });


        if (x == 0 & msg == 1)
        {
            cadena = "No ha seleccionado ningun producto";
            alertify.log(cadena);
            return false;
         }

        if (cadena != "Ingrese los sgtes. campos: ") {
            alertify.log(cadena);
            return false;
        }
        else
            return true;

//}    


    }
    catch (e) {
        alertify.log("Error Detectado: " + e);
    }
}

function F_AgregarTemporalNV() {
    try {
        var lblcodproducto_grilla = '';
        var lblcodunidadventa_grilla = '';
        var lblcosto_grilla = '';
        var chkSi = '';
        var txtcantidad_grilla = '';
        var txtprecio_grilla = '';
        var txtdscto_grilla = '';
        var arrDetalle = new Array();
        var hfcodunidadventa_grilla = '';
        var hfcosto_grilla = '';
        var lblProducto = '';
        var lblAcuenta = '';
        var hfFechaAnexo = '';
        var hfCodCtaCte = '';
        var hfNroRuc = '';
        var Contenedor = '#MainContent_';
        var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

        $('#MainContent_grvDetalleNV .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblcodproducto_grilla = chkSi.replace('chkEliminar', 'hfCodArticulo');
            lblcodunidadventa_grilla = chkSi.replace('chkEliminar', 'hfCodUndMedida');
            lblPrecio = chkSi.replace('chkEliminar', 'lblPrecio');
            txtcantidad_grilla = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
            hfcodunidadventa_grilla = chkSi.replace('chkEliminar', 'hfCodUndMedida');
            hfcosto_grilla = chkSi.replace('chkEliminar', 'lblPrecio');
            lblCodDetalle = chkSi.replace('chkEliminar', 'lblCodDetalle');
            hfCostoUnitario = chkSi.replace('chkEliminar', 'hfCostoUnitario');
            lblNumero = chkSi.replace('chkEliminar', 'lblNumero');
            lblProducto = chkSi.replace('chkEliminar', 'lblProducto');
            lblAcuenta = chkSi.replace('chkEliminar', 'lblAcuenta');
            hfFechaAnexo = chkSi.replace('chkEliminar', 'hfFechaAnexo');
            hfCodCtaCte = chkSi.replace('chkEliminar', 'hfCodCtaCte');
            hfNroRuc = chkSi.replace('chkEliminar', 'hfNroRuc');

            if ($(chkSi).is(':checked')) {
                if ($('#hfCodCtaCte').val() === '0') {
                    $('#MainContent_txtNroRuc').val($(hfNroRuc).val());
                    F_ValidaRucDni();
                }
                var objDetalle = {
                    CodArticulo: $(lblcodproducto_grilla).val(),
                    Cantidad: $(txtcantidad_grilla).val(),
                    Precio: $(lblPrecio).text(),
                    PrecioDscto: $(lblPrecio).text(),
                    Costo: $(hfcosto_grilla).text(),
                    CodUm: $(hfcodunidadventa_grilla).val(),
                    CostoUnitario: $(hfCostoUnitario).val(),
                    Dscto: 0,
                    CodDetalle: $(lblCodDetalle).text(),
                    OC: $(lblNumero).text(),
                    Descripcion: $(lblProducto).text(),
                    Acuenta: $(lblAcuenta).text(),
                    CodTipoDoc: 16,
                    Fecha: $(hfFechaAnexo).val()
                };
                arrDetalle.push(objDetalle);
                $(chkSi).prop('checked', false);
                $(txtcantidad_grilla).val('');
            }
        });

        var objParams = {
            Filtro_CodTipoDoc: 16,
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
            Filtro_CodGuia: "1",
            Filtro_Descuento: "0",
            Filtro_TasaIgv: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
            Filtro_TasaIgvDscto: tasaigv,
            Filtro_Tasa: $(Contenedor + 'lblTC').text(),
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_FlagIgv: 1
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_AgregarTemporal_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (result.split('~')[2] == "Los Producto(s) se han agregado con exito") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                $('#MainContent_txtTotal').val(parseFloat(result.split('~')[5]).toFixed(2));
                $('#MainContent_txtIgv').val(parseFloat(result.split('~')[6]).toFixed(2));
                $('#MainContent_txtSubTotal').val(parseFloat(result.split('~')[7]).toFixed(2));
                $('#MainContent_txtAcuentaNV').val(parseFloat(result.split('~')[8]).toFixed(2));
                if ($('#MainContent_ddlFormaPago').val() == 1)
                    $('#MainContent_txtAcuenta').val(parseFloat(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaNV').val())).toFixed(2));
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('.ccsestilo').css('background', '#FFFFE0');
                $('#hfNotaPedido').val(result.split('~')[8]);
               // $('#divFacturacionNV').dialog('close');
               alertify.log(result.split('~')[2]);
            }
            else {
                MostrarEspera(false);
                alertify.log(result.split('~')[2]);
            }
            F_ContarItems();
            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
    }
}

function F_AgregarTemporalNP() {
    try {
        var lblCodDocumentoVenta = '';
        var lblcodproducto_grilla = '';
        var lblcodunidadventa_grilla = '';
        var lblcosto_grilla = '';
        var chkSi = '';
        var txtcantidad_grilla = '';
        var txtprecio_grilla = '';
        var txtdscto_grilla = '';
        var arrDetalle = new Array();
        var hfcodunidadventa_grilla = '';
        var hfcosto_grilla = '';
        var lblProducto = '';
        var lblAcuenta = '';
        var hfFechaAnexo = '';
        var hfCodCtaCte = '';
        var hfNroRuc = '';
        var Contenedor = '#MainContent_';
        var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

        $('#MainContent_grvConsultaNP .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblCodDocumentoVenta = chkSi.replace('chkElegir', 'lblCodigo');
            
            if ($(chkSi).is(':checked')) {
                if ($('#hfCodCtaCte').val() === '0') {
                    $('#MainContent_txtNroRuc').val($(hfNroRuc).val());
                    F_ValidaRucDni();
                }
                var objDetalle = {
                    CodDocumentoVenta : $(lblCodDocumentoVenta).val()
                };
                arrDetalle.push(objDetalle);
                $(chkSi).prop('checked', false);
            }
        });

        var objParams = {
            Filtro_CodTipoDoc: 16,
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
            Filtro_CodGuia: "1",
            Filtro_Descuento: "0",
            Filtro_TasaIgv: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
            Filtro_TasaIgvDscto: tasaigv,
            Filtro_Tasa: $(Contenedor + 'lblTC').text(),
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_XmlDocumentos: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_FlagIgv: 1
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_AgregarTemporal_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (result.split('~')[2] == "Los Producto(s) se han agregado con exito") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                $('#MainContent_txtTotal').val(parseFloat(result.split('~')[5]).toFixed(2));
                $('#MainContent_txtIgv').val(parseFloat(result.split('~')[6]).toFixed(2));
                $('#MainContent_txtSubTotal').val(parseFloat(result.split('~')[7]).toFixed(2));
                $('#MainContent_txtAcuentaNV').val(parseFloat(result.split('~')[8]).toFixed(2));
                if ($('#MainContent_ddlFormaPago').val() == 1)
                    $('#MainContent_txtAcuenta').val(parseFloat(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaNV').val())).toFixed(2));
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('.ccsestilo').css('background', '#FFFFE0');
                $('#hfNotaPedido').val(result.split('~')[8]);
               // $('#divFacturacionNV').dialog('close');
               alertify.log(result.split('~')[2]);
            }
            else {
                MostrarEspera(false);
                alertify.log(result.split('~')[2]);
            }
            F_ContarItems();
            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
    }
}

function F_AbrirPanelCT() {

    $('#MainContent_chkCotizacion').prop('checked', false);
    $('#MainContent_chkClienteCT').prop('checked', false);
    $('#MainContent_txtNumeroNotaVenta').val('');
    $('#MainContent_txtClienteCT').val('');

  try {
        var objParams = {
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_Inicializar_GrillaVacia_DetalleCT_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

                $('#divFacturacionCT').dialog({
                    resizable: false,
                    modal: true,
                    title: "Facturacion Cotizaciones",
                    title_html: true,
                    height: 500,
                    width: 1200,
                    autoOpen: false
                });
                F_Update_Division_HTML('div_DetalleCT', result.split('~')[2]);
                $('.ccsestilo').css('background', '#FFFFE0');

                $('#divFacturacionCT').dialog('open');

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

function F_FacturacionCT(Desde, Hasta) {
    var Contenedor = '#MainContent_';
    var Mensaje = "Ingrese los sgtes datos: ";
    var NumeroDoc = "";
    var CodCliente = 0;

    if ($(Contenedor + 'lblTC').text() == "0")
        Mensaje = Mensaje + "<p></p>" + "Tipo de Cambio";

    if ($('#MainContent_chkCotizacion').is(':checked'))
        NumeroDoc = $(Contenedor + 'txtCotizacion').val();
    else
        NumeroDoc = "";

    if ($('#MainContent_chkClienteCT').is(':checked'))
        CodCliente = $('#hfCodClienteCT').val();

//    if (!$('#MainContent_chkConIgvMaestro').is(':checked')) {
//        Mensaje = Mensaje + "<p></p>" + "Con Igv debe estar chequeado";
//    }   

//    if (CodCliente == '0')
//     {
//        alertify.log('NO SE ENCONTRARON REGISTROS');
//        return false
//     }

    try {
        var objParams = {
            Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
            Filtro_Desde: Desde,
            Filtro_Hasta: Hasta,
            Filtro_NumeroDoc: NumeroDoc,
            Filtro_SerieDoc: $("#MainContent_ddlSerieCT option:selected").text(),
            Filtro_CodCliente: CodCliente
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_FacturacionCT_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

//                $('#divFacturacionCT').dialog({
//                    resizable: false,
//                    modal: true,
//                    title: "Facturacion Nota de Venta",
//                    title_html: true,
//                    height: 500,
//                    width: 1000,
//                    autoOpen: false
//                });
                F_Update_Division_HTML('div_DetalleCT', result.split('~')[2]);
                $('.ccsestilo').css('background', '#FFFFE0');

//                $('#divFacturacionCT').dialog('open');

                if (str_mensaje_operacion != "")
                    alertify.log(str_mensaje_operacion);
                else
                    $('#divFacturacionCT').dialog('open');

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

function F_AgregarTemporalCT() {
    try {
        var lblcodproducto_grilla = '';
        var lblcodunidadventa_grilla = '';
        var lblcosto_grilla = '';
        var chkSi = '';
        var txtcantidad_grilla = '';
        var txtprecio_grilla = '';
        var txtdscto_grilla = '';
        var arrDetalle = new Array();
        var hfcodunidadventa_grilla = '';
        var hfcosto_grilla = '';
        var lblProducto = '';
        var lblAcuenta = '';
        var hfFechaAnexo = '';
        var hfCodCtaCte = '';
        var hfNroRuc = '';
        var hfPrecio = '';
        var hfCodMoneda = '';
        var Contenedor = '#MainContent_';
        var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

        $('#MainContent_grvDetalleCT .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblcodproducto_grilla = chkSi.replace('chkEliminar', 'hfCodArticulo');
            lblcodunidadventa_grilla = chkSi.replace('chkEliminar', 'hfCodUndMedida');
            lblPrecio = chkSi.replace('chkEliminar', 'lblPrecio');
            txtcantidad_grilla = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
            hfcodunidadventa_grilla = chkSi.replace('chkEliminar', 'hfCodUndMedida');
            hfcosto_grilla = chkSi.replace('chkEliminar', 'lblPrecio');
            lblCodDetalle = chkSi.replace('chkEliminar', 'lblCodDetalle');
            hfCostoUnitario = chkSi.replace('chkEliminar', 'hfCostoUnitario');
            lblNumero = chkSi.replace('chkEliminar', 'lblNumero');
            lblProducto = chkSi.replace('chkEliminar', 'lblProducto');
            lblAcuenta = chkSi.replace('chkEliminar', 'lblAcuenta');
            hfFechaAnexo = chkSi.replace('chkEliminar', 'hfFechaAnexo');
            hfCodCtaCte = chkSi.replace('chkEliminar', 'hfCodCtaCte');
            hfNroRuc = chkSi.replace('chkEliminar', 'hfNroRuc');
            hfPrecio = chkSi.replace('chkEliminar', 'hfPrecio');
            hfCodMoneda = chkSi.replace('chkEliminar', 'hfCodMoneda');

            if ($(chkSi).is(':checked')) {
                
                if ($('#hfCodCtaCte').val() === '0') {
                    $('#MainContent_txtNroRuc').val($(hfNroRuc).val());
                    F_ValidaRucDni();
                }

                var CodMonedaActual = Number($('#MainContent_ddlMoneda').val());
                var CodMonedaCotiza = Number($(hfCodMoneda).val());
                var vPrecio = $(hfPrecio).val(); 
                if (CodMonedaActual != CodMonedaCotiza){
                    if (CodMonedaActual == 1)
                        vPrecio = Number(vPrecio) * Number($('#MainContent_lblTCParalelo').text());
                    else 
                        vPrecio = Number(vPrecio) / Number($('#MainContent_lblTCParalelo').text());
                }

                var objDetalle = {
                    CodArticulo: $(lblcodproducto_grilla).val(),
                    Cantidad: $(txtcantidad_grilla).val(),
                    Precio: vPrecio,
                    PrecioDscto: vPrecio,
                    Costo: $(hfcosto_grilla).text(),
                    CodUm: $(hfcodunidadventa_grilla).val(),
                    CostoUnitario: $(hfCostoUnitario).val(),
                    Dscto: 0,
                    CodDetalle: $(lblCodDetalle).text(),
                    OC: $(lblNumero).text(),
                    Descripcion: $(lblProducto).text(),
                    Acuenta: $(lblAcuenta).text(),
                    CodTipoDoc: 15,
                    Fecha: $(hfFechaAnexo).val()
                };
                arrDetalle.push(objDetalle);
                $(chkSi).prop('checked', false);
                $(txtcantidad_grilla).val('');
            }
        });

        var objParams = {
            Filtro_CodTipoDoc: 16,
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
            Filtro_CodGuia: "1",
            Filtro_Descuento: "0",
            Filtro_TasaIgv: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
            Filtro_TasaIgvDscto: tasaigv,
            Filtro_Tasa: $(Contenedor + 'lblTC').text(),
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
            Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            Filtro_FlagIgv: 1
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        MostrarEspera(true);
        F_AgregarTemporal_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (result.split('~')[2] == "Los Producto(s) se han agregado con exito") {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                $('#MainContent_txtTotal').val(parseFloat(result.split('~')[5]).toFixed(2));
                $('#MainContent_txtIgv').val(parseFloat(result.split('~')[6]).toFixed(2));
                $('#MainContent_txtSubTotal').val(parseFloat(result.split('~')[7]).toFixed(2));
                $('#MainContent_txtAcuentaCT').val(parseFloat(result.split('~')[8]).toFixed(2));
                if ($('#MainContent_ddlFormaPago').val() == 1)
                    $('#MainContent_txtAcuenta').val(parseFloat(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaCT').val())).toFixed(2));
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('.ccsestilo').css('background', '#FFFFE0');
                $('#hfCodProforma').val(result.split('~')[8]);
               // $('#divFacturacionCT').dialog('close');
               alertify.log(result.split('~')[2]);
            }
            else {
                MostrarEspera(false);
                alertify.log(result.split('~')[2]);
            }
            F_ContarItems();
            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
    }
}

function F_ValidarAgregarCT(msg) {
    try {
        var cadena = "Ingrese los sgtes. campos: ";
        var chkSi = '';
        var lblCodigo = '';
        var txtCantidadEntregada = '';
        var x = 0;

        $('#MainContent_grvDetalleCT .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;

            txtCantidadEntregada = chkSi.replace('chkEliminar', 'txtCantidadEntregada');
            lblCodigo = chkSi.replace('chkEliminar', 'lblCodigo');

            if ($(chkSi).is(':checked')) {
                if ($(txtCantidadEntregada).val() == '')
                    cadena = cadena + "<p></p>" + "Cantidad para el Codigo " + $(lblCodigo).text();
                x = 1;
            }
        });

        if (x == 0 & msg == 1)
        {
            cadena = "No ha seleccionado ningun producto";
            alertify.log(cadena);
            return false;
         }

        if (cadena != "Ingrese los sgtes. campos: ") {
            alertify.log(cadena);
            return false;
        }
        else
            return true;
    }
    catch (e) {
        alertify.log("Error Detectado: " + e);
    }
}

//ENZO
function F_BuscarDireccionesCliente() {
if (!F_SesionRedireccionar(AppSession)) return false;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDireccion_ListarXCodDistritoCliente_AutoComplete',
        data: "{'Direccion':'','CodDepartamento':'" + $('#hfCodDepartamento').val() + "','CodProvincia':'" + $('#hfCodProvincia').val() + "','CodDistrito':'" + $('#hfCodDistrito').val() + "','CodCtaCte':'" + $('#hfCodCtaCte').val() + "'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                var count = 0;
                $('#MainContent_ddlDireccion').empty();
                $.each(data.rows, function (index, item) {
                    $('#MainContent_ddlDireccion').append($("<option></option>").val(item.CodDireccion).html(item.Direccion));
                    if (count === 0)
                    {
                        $('#MainContent_txtDireccion').val(item.Direccion);
                        $('#hfDireccion').val(item.Direccion);
                        $('#hfCodDireccion').val(item.CodDireccion);
                    }
                    if (data.rows.length > 0) {
                        if ($('#hfCodDireccionDefecto').val() != '0') {
                            $('#MainContent_ddlDireccion').val($('#hfCodDireccionDefecto').val());
                        }
                        $('#MainContent_txtDireccion').val($("#MainContent_ddlDireccion option:selected").text());
                        if ($('#MainContent_txtDireccion').val() == "")
                        {
                            $('#MainContent_ddlDireccion').val($("#MainContent_ddlDireccion option:first").val());
                            $('#hfCodDireccion').val($("#MainContent_ddlDireccion option:first").val());          
                            $('#MainContent_txtDireccion').val($("#MainContent_ddlDireccion option:selected").text());
                        }
                        $('#hfCodDireccion').val($("#MainContent_ddlDireccion").val());
                    }
                    count++;
                });
            }
            catch (x) { alertify.log('El Producto no tiene Imagenes'); }
            MostrarEspera(false);
        },
        complete: function () {
            if (($('#hfCodDireccion').val() == '' | $('#hfCodDireccion').val() == '0') && $('#hfCodCtaCte').val() != 0)
            {
                alertify.log('NO HAY DIRECCION PARA EL DISTRITO ESPECIFICADO')
                $('#MainContent_txtDireccion').val('');
                $('#hfDireccion').val('');
                $('#hfCodDireccion').val('0');
                $('#MainContent_txtCorreo').val('');
            }

        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });

    return false;
}

function F_BuscarDistrito() {
if (!F_SesionRedireccionar(AppSession)) return false;
//    $('#hfCodDireccion').val('0');
//    $('#MainContent_txtDireccion').val('');
//    $('#hfDireccion').val('');
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDistrito_ListarXCodDistrito',
        //data: "{'Direccion':'','CodDepartamento':'" + $('#hfCodDepartamento').val() + "','CodProvincia':'" + $('#hfCodProvincia').val() + "','CodDistrito':'" + $('#hfCodDistrito').val() + "','CodCtaCte':'" + $('#hfCodCtaCte').val() + "'}",
        data: "{'CodDistrito':'" + $('#hfCodDistrito').val() + "'}",
        dataType: "json",
        async: false,
        success: function (data) {
                if (data.d.length >= 1)
                {
                    $('#MainContent_txtDistrito').val(data.d[0].split(',')[3]);
                }
        },
        complete: function () {
        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });

    return false;
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

function imgMas_Click2(Control) {
    Ctlgv = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {

        var grid = $(Control).next();
        //F_LlenarGridDetalle(grid.attr('id'));
        $(Control).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Control).next().html() + '</td></tr>');
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }

    return false;
}

function imgMas_Click3(Control) {
    Ctlgv = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {

        var grid = $(Control).next();
        $(Control).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Control).next().html() + '</td></tr>');
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }

    return false;
}

function F_LlenarGridDetalle(Fila){
  try 
        {             
                var nmrow = 'MainContent_grvConsulta_pnlOrders_0';
                var Col = Fila.split('_')[3];
                var Codigo = $('#' + Fila.replace('pnlOrders', 'lblCodigo')).val();
                var CodTipoDoc = $('#' + Fila.replace('pnlOrders', 'hfCodTipoDoc')).val();
                var grvNombre = 'MainContent_grvConsulta_grvDetalle_' + Col;
                Hfgv = '#' + Fila.replace('pnlOrders', 'hfDetalleCargado');

                if ($(Hfgv).val() === "1")
                {
                    $(Ctlgv).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Ctlgv).next().html() + '</td></tr>');
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
                        F_LlenarGridDetalle_NET(arg, function (result) {
                
                        MostrarEspera(false);

                        var str_resultado_operacion = result.split('~')[0];
                        var str_mensaje_operacion = result.split('~')[1];

                        if (str_resultado_operacion === "0")
                        {
                            var p = $('#' + result.split('~')[3]).parent();
                            $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                            F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);

                            $(Ctlgv).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Ctlgv).next().html() + '</td></tr>');
//                            $(Hfgv).val('1');
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

function F_ContarItems(){

 try 
        {
        var chkSi='';
        var x=0;

                $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    var nro = chkSi.replace('chkEliminar', 'lblNro');          
                    var txtPrecio = chkSi.replace('chkEliminar', 'txtPrecio');        
                     if ($(nro).text().trim() != "") {
                        x++;

                        if (P_EDITAR_PRECIOS === "1")
                            $(txtPrecio).prop('readonly', false);
                            $(txtPrecio).prop('disabled', false);
                     }
                        

               });               



               //$('#MainContent_lblNroItems').text('CANTIDAD DE REGISTROS: ' + x);
               $('#MainContent_lblNroItems').text('CANTIDAD DE REGISTROS: ' + F_ContarRowsGrilla('grvDetalleArticulo', 'chkEliminar', 'lblproducto'));
               $('#hfNroItems').val(x);
        }
        
        catch (e) 
        {

            alertify.log("Error Detectado: " + e);
        }

        return true;
}

function F_ACTUALIZAR_MONTO_MONEDA(){
  try 
        {
        if($('#MainContent_txtTotal').val()=='0.00')
        return;

        var FlagIgv = 0;
        var Contenedor = '#MainContent_';    
        var tasaigv;

                if ($('#MainContent_chkConIgvMaestro').is(':checked'))
                 tasaigv=parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
                else
                 tasaigv=1;
                
        if($(Contenedor + 'chkConIgvMaestro').is(':checked')) 
             FlagIgv = 1; 
                
                var Contenedor = '#MainContent_';
                var tasaigv=parseFloat( $("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
                var objParams = {
                                        Filtro_CodTipoDoc: $("#MainContent_ddlTipoDoc").val(),
                                        Filtro_SerieDoc: $(Contenedor + 'ddlSerie').val(),
                                        Filtro_NumeroDoc: $(Contenedor + 'txtNumero').val(),
                                        Filtro_FechaEmision: $(Contenedor + 'txtEmision').val(),
                                        Filtro_Vencimiento: $(Contenedor + 'txtVencimiento').val(),
                                        //Filtro_CodCliente: $(Contenedor + 'hfCodCtaCte').val(),
                                        Filtro_CodFormaPago: $(Contenedor + 'ddlFormaPago').val(),
                                        Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
                                        Filtro_TipoCambio: $('#MainContent_lblTCParalelo').text(),
                                        Filtro_SubTotal: $(Contenedor + 'txtSubTotal').val(),
                                        Filtro_CodProforma: "0",
                                        Filtro_Igv: $(Contenedor + 'txtIgv').val(),
                                        Filtro_Total: $(Contenedor + 'txtTotal').val(),
                                        Filtro_CodTraslado: "0",
                                        Filtro_Descuento: "0",
                                        Filtro_TasaIgv: tasaigv,
                                        Filtro_Tasa: $('#MainContent_lblTC').text(),
                                        Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
                                        //Filtro_Servicio: chkServicio,
                                        //Filtro_NotaPedido: chkNotaPedido
                               };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
                MostrarEspera(true);
                F_ActualizarDetalle_CAMBIO_MONEDA_NET(arg, function (result) {
                
                  MostrarEspera(false);

                   var str_resultado_operacion = result.split('~')[0];
                   var str_mensaje_operacion = result.split('~')[1];

                  if (str_mensaje_operacion == "")
                   {                  
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                     $('.ccsestilo').css('background', '#FFFFE0');

                    var Moneda = 'S/ ';
                    if ($('#MainContent_ddlMoneda').val() === "2")
                        Moneda = '$ ';

                    $('#MainContent_txtTotal').val(result.split('~')[5]);
                    $('#MainContent_txtTotal2').val(Moneda + result.split('~')[5]);
                    $('#MainContent_txtIgv').val(result.split('~')[6]);
                    $('#MainContent_txtSubTotal').val(result.split('~')[7]);
                    $('#hfNotaPedido').val(result.split('~')[8]);

                   }



                return false;

                });
        }
        
        catch (e) 
        {
              MostrarEspera(false);
            alertify.log("ERROR DETECTADO: " + e);
            return false;
        }
}

function F_InicializarCorreos() {

	$("#ddlCorreos").multipleSelect({
        selectAll: false,
        single: false,
        hideOptgroupCheckboxes: false,
        data: [
	      {
	        text: '[SIN CORREOS]',
	        value: 0
	      }
	    ]
	});
    $("#ddlCorreos").multipleSelect('checkAll');
    return true;
}

function F_LlenarCorreos() {

    var CodDireccion = $('#hfCodDireccion').val();
    var CodCtaCte = $('#hfCodCtaCte').val();

        F_InicializarCorreos();
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: 'RegistroFactura.aspx/F_Correos_Por_Cliente_Listar_NET',
        data: "{'CodCtaCte':'" + CodCtaCte + "', 'CodDireccion':'" + CodDireccion + "'}",
        dataType: "json",
        async: true,
        success: function (dbObject) {
            var data = dbObject.d;

            F_ConstruirComboCorreos(data);

        },
        complete: function () {

        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });

return true;
}

function F_LlenarCorreosResponsable() {

    var CodDireccion = $('#hfCodDireccion').val();
    var CodCtaCte = $('#hfCodCtaCte').val();

        F_InicializarCorreos();

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: 'RegistroFactura.aspx/F_Correos_Por_Responsable_Listar_NET',
        data: "{'CodResponsable':'" + $('#MainContent_ddlResponsableNP').val() + "'}",
        dataType: "json",
        async: true,
        success: function (dbObject) {
            var data = dbObject.d;

            F_ConstruirComboCorreos(data);

        },
        complete: function () {

        },
        error: function (response) {
//            alertify.log(response.responseText);
        },
        failure: function (response) {
//            alertify.log(response.responseText);
        }
    });

return true;
}

function F_ConstruirComboCorreos(Lista) {
    if (Number($('#hfCodDireccion').val()) === 0) {
        F_ConstruirComboCorreosSinCodDireccion();
        return true;
    }
    
    var vSinCorreos = true;
    $("#MainContent_txtEdicionMail_Email1").val('');
    $("#MainContent_txtEdicionMail_Email2").val('');
    $("#MainContent_txtEdicionMail_Email3").val('');
    $("#MainContent_txtEdicionMail_Email4").val('');
    $("#MainContent_txtEdicionMail_Email5").val('');
    $("#MainContent_txtEdicionMail_Email6").val('');

    try {
        //Limpio y Reconstruyo la table
        $('#div_correos').empty();
        var html = '<select id="ddlCorreos" style="width:330px"> </select>';
        $(html).appendTo($("#div_correos"))

        $.each(Lista, function (index, item) {
            $('#ddlCorreos').append(new Option(item.Email, (item.Email == '[SIN CORREOS]')? '0' : item.Email));
            if (item.Email === '[SIN CORREOS]') {
                $("#MainContent_txtEdicionMail_Email1").val('');
                $("#MainContent_txtEdicionMail_Email2").val('');
                $("#MainContent_txtEdicionMail_Email3").val('');
                $("#MainContent_txtEdicionMail_Email4").val('');
                $("#MainContent_txtEdicionMail_Email5").val('');
                $("#MainContent_txtEdicionMail_Email6").val('');
                vSinCorreos = false;
                }
            else {
                if (item.Nro === 1) 
                    $("#MainContent_txtEdicionMail_Email1").val(item.Email);
                if (item.Nro === 2)               
                    $("#MainContent_txtEdicionMail_Email2").val(item.Email);
                if (item.Nro === 3)               
                    $("#MainContent_txtEdicionMail_Email3").val(item.Email);
                if (item.Nro === 4)               
                    $("#MainContent_txtEdicionMail_Email4").val(item.Email);
                if (item.Nro === 5)               
                    $("#MainContent_txtEdicionMail_Email5").val(item.Email);
                if (item.Nro === 6)               
                    $("#MainContent_txtEdicionMail_Email6").val(item.Email);
            }
        });

	  $("#ddlCorreos").multipleSelect({
        selectAll: vSinCorreos,
        single: false,
        hideOptgroupCheckboxes: false,
	  });

      if ($("#MainContent_ddlTipoDoc").val() === '15')
        $("#ddlCorreos").multipleSelect('uncheckAll');
      else 
        $("#ddlCorreos").multipleSelect('checkAll');


    if (vSinCorreos === false)
        $("#ddlCorreos").multipleSelect('checkAll');

    }
    catch (x) { alertify.log('ERROR AL CARGAR LOS CORREOS DE LA LISTA'); }
return true;
}

function F_ConstruirComboCorreosSinCodDireccion() {

    var Email1 = $("#MainContent_txtEdicionMail_Email1").val().trim();
    var Email2 = $("#MainContent_txtEdicionMail_Email2").val().trim();
    var Email3 = $("#MainContent_txtEdicionMail_Email3").val().trim();
    var Email4 = $("#MainContent_txtEdicionMail_Email4").val().trim();
    var Email5 = $("#MainContent_txtEdicionMail_Email5").val().trim();
    var Email6 = $("#MainContent_txtEdicionMail_Email6").val().trim();

        var vSinCorreos = false;

        //Actualiza solo el js, sin actualizar el cliente
        $('#div_correos').empty();
        var html = '<select id="ddlCorreos" style="width:330px"> </select>';
        $(html).appendTo($("#div_correos"));

        if (Email1.length > 0) {
            $('#ddlCorreos').append(new Option(Email1, Email1));
            vSinCorreos = true; }

        if (Email2.length > 0) {
            $('#ddlCorreos').append(new Option(Email2, Email2));
            vSinCorreos = true; }

        if (Email3.length > 0) {
            $('#ddlCorreos').append(new Option(Email3, Email3));
            vSinCorreos = true; }

        if (Email4.length > 0) {
            $('#ddlCorreos').append(new Option(Email4, Email4));
            vSinCorreos = true; }

        if (Email5.length > 0) {
            $('#ddlCorreos').append(new Option(Email5, Email5));
            vSinCorreos = true; }

        if (Email6.length > 0) {
            $('#ddlCorreos').append(new Option(Email6, Email6));
            vSinCorreos = true; }

	  $("#ddlCorreos").multipleSelect({
        selectAll: vSinCorreos,
        single: false,
        hideOptgroupCheckboxes: false,
	  });

      if ($("#MainContent_ddlTipoDoc").val() === '15')
        $("#ddlCorreos").multipleSelect('uncheckAll');
      else 
        $("#ddlCorreos").multipleSelect('checkAll');


    if (vSinCorreos === false)
        $("#ddlCorreos").multipleSelect('checkAll');

        $('#div_CorreosEdicion').dialog('close');

        return true;
return true;
}

function F_ActualizarCorreos() {

    var CodDireccion = $('#hfCodDireccion').val();
    var CodCtaCte = $('#hfCodCtaCte').val();

    var Email1 = $("#MainContent_txtEdicionMail_Email1").val().trim();
    var Email2 = $("#MainContent_txtEdicionMail_Email2").val().trim();
    var Email3 = $("#MainContent_txtEdicionMail_Email3").val().trim();
    var Email4 = $("#MainContent_txtEdicionMail_Email4").val().trim();
    var Email5 = $("#MainContent_txtEdicionMail_Email5").val().trim();
    var Email6 = $("#MainContent_txtEdicionMail_Email6").val().trim();

    if (Email1.length > 0) {
        if (!F_ValidarCorreo(Email1)) {
            alertify.log('FORMATO INCORRECTO EN EMAIL 1');
            return true; } };

    if (Email2.length > 0) {
        if (!F_ValidarCorreo(Email2)) {
            alertify.log('FORMATO INCORRECTO EN EMAIL 2');
            return true; } };

    if (Email3.length > 0) {
        if (!F_ValidarCorreo(Email3)) {
            alertify.log('FORMATO INCORRECTO EN EMAIL 3');
            return true; } };

    if (Email4.length > 0) {
        if (!F_ValidarCorreo(Email4)) {
            alertify.log('FORMATO INCORRECTO EN EMAIL 4');
            return true; } };

    if (Email5.length > 0) {
        if (!F_ValidarCorreo(Email5)) {
            alertify.log('FORMATO INCORRECTO EN EMAIL 5');
            return true; } };

    if (Email6.length > 0) {
        if (!F_ValidarCorreo(Email6)) {
            alertify.log('FORMATO INCORRECTO EN EMAIL 6');
            return true; } };

    if (!confirm("¿SEGURO DE ACTUALIZAR LOS CORREOS?"))
        return false;

    //Inicializa el combo
    F_InicializarCorreos();

    //si no hay coddireccion no tiene nada que actualizar
    if (Number(CodDireccion) === 0) {
        F_ConstruirComboCorreosSinCodDireccion();
    }

    var dir = 'F_Correos_Por_Cliente_Actualizar_NET';
    if ($('#MainContent_ddlTipoDoc').val() === '16') {
            dir = 'F_Correos_Por_Responsable_Actualizar_NET';
            CodDireccion = $('#MainContent_ddlResponsableNP').val();
        }

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: 'RegistroFactura.aspx/' + dir,
        data: "{'CodDireccion':'" + CodDireccion + "','Email1':'" + Email1 + "','Email2':'" + Email2 + "','Email3':'" + Email3 + "','Email4':'" + Email4 + "','Email5':'" + Email5 + "','Email6':'" + Email6 + "'}",
        dataType: "json",
        async: true,
        success: function (dbObject) {
            var data = dbObject.d;

            alertify.log(data);
            if (data === "Se Grabo Correctamente") {
                if ($('#MainContent_ddlTipoDoc').val() === '16')
                    F_LlenarCorreosResponsable();
                else
                    F_LlenarCorreos();
                $('#div_CorreosEdicion').dialog('close');
                }

        },
        complete: function () {

        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });

return true;
}

function F_ActualizarCorreosCodDocumentoVenta(CodDocumentoVenta, CodTipoDoc) {

    var Email1 = $("#MainContent_txtEdicionMail_Email1").val().trim();
    var Email2 = $("#MainContent_txtEdicionMail_Email2").val().trim();
    var Email3 = $("#MainContent_txtEdicionMail_Email3").val().trim();
    var Email4 = $("#MainContent_txtEdicionMail_Email4").val().trim();
    var Email5 = $("#MainContent_txtEdicionMail_Email5").val().trim();
    var Email6 = $("#MainContent_txtEdicionMail_Email6").val().trim();

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: 'RegistroFactura.aspx/F_Correos_Por_Cliente_Actualizar_CodDocumentoVenta_NET',
        data: "{'CodDocumentoVenta':'" + CodDocumentoVenta + "','CodTipoDoc':'" + CodTipoDoc + "','Email1':'" + Email1 + 
                    "','Email2':'" + Email2 + "','Email3':'" + Email3 + "','Email4':'" + Email4 + "','Email5':'" + Email5 + "','Email6':'" + Email6 + "'}",
        dataType: "json",
        async: true,
        success: function (dbObject) {
            var data = dbObject.d;

            alertify.log(data);
            if (data === "Se Grabo Correctamente") {

                }

        },
        complete: function () {

        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });

return true;
}

function F_ReemplazarDocumento(Fila) {
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

        try {
            var imgID = Fila.id;
            var lblcodigo = '#' + imgID.replace('imgReemplazar', 'lblCodigo');
            var lblEstado = '#' + imgID.replace('imgReemplazar', 'lblEstado');
            var lblTipoDoc = '#' + imgID.replace('imgReemplazar', 'hfCodTipoDoc');
            var lblCodMoneda = '#' + imgID.replace('imgReemplazar', 'hfCodMoneda');

            if ($(lblTipoDoc).val() != '16' && $(lblTipoDoc).val() != '15') {
                alertify.log('SOLO SE PUEDEN MODIFICAR  PROFORMA');
                return true;
            }

            if ($(lblEstado).text() != 'PENDIENTE' ) {
                alertify.log('ELIMINE EL PAGO PARA EDITAR');
                return true;
            }

            var objParams = {
                Filtro_CodDoc: $(lblTipoDoc).val() ,
                Filtro_CodDocumentoVenta: $(lblcodigo).val(),
                Filtro_TasaIgv: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                Filtro_NotaPedido: 0,
                Filtro_CodTipoDoc: $(lblTipoDoc).val(),
                Filtro_TasaIgvDscto: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                Filtro_Tasa: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                Filtro_CodMoneda: $(lblCodMoneda).val()
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);

            F_ReemplazarFactura_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = result.split('~')[0];
                var str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") {

                    $('#MainContent_ddlTipoDoc').val($(lblTipoDoc).val());
                    $('#MainContent_ddlTipoDoc').prop('disabled', true);

                    var data = jQuery.parseJSON(result.split('~')[4]);

                    $('#hfCodFacturaAnterior').val(data.CodFactura_Anterior);
                    $('#hfCodigoTemporal').val(data.Codigo);

                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[2]);

                    F_Update_Division_HTML('div_serie', result.split('~')[3]);
                    $('#MainContent_ddlSerie').css('background', '#FFFFE0');


                    $('#MainContent_txtTotal').val(data.Total);
                    $('#MainContent_txtMonto').val(data.Total);
                    $('#MainContent_txtIgv').val(data.Igv);
                    $('#MainContent_txtSubTotal').val(data.SubTotal);
                    $('#MainContent_txtDsctoTotal').val(data.Descuento);
                    $('#MainContent_txtNroRuc').val(data.NroRuc);
                    $('#MainContent_txtCliente').val(data.Cliente);
                    $('#MainContent_ddlMoneda').val(data.CodMoneda);
                    $('#MainContent_ddlVendedor').val(data.CodVendedor);
                    $('#MainContent_txtRequerimiento').val(data.Requerimiento);
                    var Moneda = 'S/ ';
                    if ($('#MainContent_ddlMoneda').val() === "2")
                        Moneda = '$ ';
                    $('#MainContent_txtTotal2').val(Moneda + data.Total);

                    //---------
                    $('#MainContent_ddlFormaPago').val(data.CodFormaPago);
                    $('#hfCodCtaCte').val(data.CodCliente);
                    $('#MainContent_txtNumero').val(data.NumeroDoc);
                    //$('#MainContent_ddlSerie').val(data.SerieDoc);

                    $('#MainContent_txtEmision').val(data.FechaEmisionStr);
                    $('#MainContent_txtVencimiento').val(data.FechaVencimientoStr);

                    $('#MainContent_ddlIgv').val(data.CodTasa);

                    $('#MainContent_chkConIgvMaestro').prop('checked', true);
                    $('#MainContent_chkSinIgvMaestro').prop('checked', false);
                    if (Number(data.FlagIgv) == 0) {
                        $('#MainContent_chkConIgvMaestro').prop('checked', false);
                        $('#MainContent_chkSinIgvMaestro').prop('checked', true);                    
                    }

                    $('#hfCodDireccionDefecto').val(data.CodDireccion);
                    F_BuscarDireccionesCliente();
                    $('#hfCodDireccion').val(data.CodDireccion);
                    $('#hfCodDepartamento').val(data.CodDepartamento);
                    $('#hfCodProvincia').val(data.CodProvincia);
                    $('#hfCodDistrito').val(data.CodDistrito);
                    $('#hfDistrito').val(data.Distrito);
                    $('#MainContent_txtDistrito').val(data.Distrito);
                    $('#hfFlagReemplazotmp').val(result.split('~')[26]);

                    $('#MainContent_txtPlaca').val(data.Placa);
                    $('#MainContent_txtPlaca2').val(data.Placa2);
                    $('#MainContent_txtPlaca3').val(data.Placa3);
                    $('#MainContent_txtPlaca4').val(data.Placa4);
                    $('#MainContent_txtPlaca5').val(data.Placa5);
                    $('#MainContent_txtPlaca6').val(data.Placa6);
                    $('#MainContent_txtPlaca7').val(data.Placa7);
                    $('#MainContent_txtPlaca8').val(data.Placa8);

                    //guia
                    if (data.Codtraslado >0)
                    {
                        $('#MainContent_chkGuia').prop('checked', true); 
                              $('#hfCodTraslado').val(data.Codtraslado);
                    $('#MainContent_ddlSerieGuia option:selected').text(data.SerieDocGuia);
                    $('#MainContent_txtNumeroGuia').val(data.NumeroDocGuia);
                    $('#MainContent_txtDestino').val(data.Destino);
                    $('#MainContent_txtNroRucTransportista').val(data.NroRuctrans);
                    $('#MainContent_txtTransportista').val(data.RazonSocialtrans);
                    $('#MainContent_txtDireccionTransportista').val(data.DireccionTrans);
                    //miguel guia
                    $('#MainContent_txtPlacaTraslado').val(data.PlacaTraslado);
                    $('#MainContent_txtDistritoTransportista').val(data.DistritoTransportista);
                    $('#MainContent_txtMarcaGuia').val(data.Marca);
                    $('#MainContent_txtLicenciaGuia').val(data.Licencia);
                    $('#MainContent_txtNuBultos').val(data.NuBultos);
                    $('#MainContent_txtPeso').val(data.Peso);
                    $('#hfCodTransportista').val(data.CodTransportista);
                    $('#hfCodDireccionTransportista').val(data.CodDireccionTransportista);
                    $('#hfPartida').val(data.Partida);
                    $('#hfCodDepartamento').val(data.CodDepartamentoGuia);
                    $('#hfCodProvincia').val(data.CodDistritoGuia);
                    $('#hfCodDistrito').val(data.CodProvinciaGuia);
                    }
                    else
                    {
                    $('#MainContent_chkGuia').prop('checked', false); 
                    }
              
                    $('#MainContent_txtKM').val(data.KM);

                    F_BuscarResponsables();
                    F_LlenarCorreos();

                    CodResponsableReemplazo = data.CodResponsable;
                    $('#MainContent_txtResponsable2').val(data.Responsable2);
                    $('#MainContent_txtResponsableDNI2').val(data.Responsable2DNI);
                    $('#MainContent_txtResponsable1').val(data.Responsable);
                    $('#MainContent_txtResponsableDNI1').val(data.ResponsableDNI);
                    $('#MainContent_txtObservacion').val(data.Observacion);
                    $('#MainContent_txtAtencion').val(data.atencion);
                    $('#MainContent_txtNroOC').val(data.NroOC);
                    $('#MainContent_txtNroOperacion').val(data.NroOperacion);
                     F_ContarItems();
                
                    $('.ccsestilo').css('background', '#FFFFE0');
                    $("#divTabs").tabs("option", "active", $("#liRegistro").index());

                    F_GuardarDireccion($('#MainContent_txtNroRuc').val(),'#hfCodigoTemporal',$('#hfCodCtaCte').val(),'#MainContent_txtCliente'
            ,0,Ubigeo,Direccion,'#MainContent_ddldireccionNueva','#MainContent_ddldireccionNuevaDestino',1);   
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
            alert("Error Detectado: " + e);
            return false;
        }
    }

function F_AgregarNP(Fila) {
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

        var arrDetalle = new Array();
        var rucAsignado = false;;
        $('#MainContent_grvConsultaNP .chkDelete :checkbox').each(function () {
            chkSi = '#' + this.id;
            lblCodDocumentoVenta = chkSi.replace('chkElegir', 'lblCodigo');
            
            if ($(chkSi).is(':checked')) {
                if ($('#hfCodCtaCte').val() === '0') {
                    $('#MainContent_txtNroRuc').val($(hfNroRuc).val());
                    F_ValidaRucDni();
                }
                var objDetalle = {
                    CodDocumentoVenta : $(lblCodDocumentoVenta).val()
                };
                arrDetalle.push(objDetalle);
                $(chkSi).prop('checked', false);
            }
        });

        try {

            var objParams = {
                Filtro_TasaIgv: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                Filtro_NotaPedido: 0,
                Filtro_CodTipoDoc: $("#MainContent_ddlTipoDoc").val(),
                Filtro_TasaIgvDscto: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                Filtro_Tasa: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                Filtro_CodMoneda: $('#MainContent_ddlMoneda').val(),
                Filtro_CodTemporal: $('#hfCodigoTemporal').val(),
                Filtro_XmlDocumentos: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);

            F_AgregarTemporalNP_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = result.split('~')[0];
                var str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") {

                    var data = jQuery.parseJSON(result.split('~')[4]);

                    //$('#hfCodFacturaAnterior').val(data.CodFactura_Anterior);
                    $('#hfCodigoTemporal').val(data.Codigo);

                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[2]);

                    //F_Update_Division_HTML('div_serie', result.split('~')[3]);
                    //$('#MainContent_ddlSerie').css('background', '#FFFFE0');


                    $('#MainContent_txtTotal').val(data.Total);
                    $('#MainContent_txtMonto').val(data.Total);
                    $('#MainContent_txtIgv').val(data.Igv);
                    $('#MainContent_txtSubTotal').val(data.SubTotal);
                    $('#MainContent_txtDsctoTotal').val(data.Descuento);
                    $('#MainContent_txtNroRuc').val(data.NroRuc);
                    $('#MainContent_txtCliente').val(data.Cliente);
                    $('#MainContent_ddlMoneda').val(data.CodMoneda);
                    var Moneda = 'S/ ';
                    if ($('#MainContent_ddlMoneda').val() === "2")
                        Moneda = '$ ';
                    $('#MainContent_txtTotal2').val(Moneda + data.Total);

                    //---------
                    //$('#MainContent_ddlFormaPago').val(data.CodFormaPago);
                    $('#hfCodCtaCte').val(data.CodCliente);
                    $('#MainContent_txtNumero').val(data.NumeroDoc);
                    //$('#MainContent_ddlSerie').val(data.SerieDoc);

                    //$('#MainContent_txtEmision').val(data.FechaEmisionStr);
                    //$('#MainContent_txtVencimiento').val(data.FechaVencimientoStr);

                    $('#MainContent_ddlIgv').val(data.CodTasa);

                    $('#MainContent_chkConIgvMaestro').prop('checked', true);
                    $('#MainContent_chkSinIgvMaestro').prop('checked', false);
                    if (Number(data.FlagIgv) == 0) {
                        $('#MainContent_chkConIgvMaestro').prop('checked', false);
                        $('#MainContent_chkSinIgvMaestro').prop('checked', true);                    
                    }

                    $('#hfCodDireccionDefecto').val(data.CodDireccion);
                    F_BuscarDireccionesCliente();
                    $('#hfCodDireccion').val(data.CodDireccion);
                    $('#hfCodDepartamento').val(data.CodDepartamento);
                    $('#hfCodProvincia').val(data.CodProvincia);
                    $('#hfCodDistrito').val(data.CodDistrito);
                    $('#hfDistrito').val(data.Distrito);
                    $('#MainContent_txtDistrito').val(data.Distrito);
                    //$('#hfFlagReemplazotmp').val(result.split('~')[26]);
                    
                    $('#MainContent_txtPlaca').val(data.Placa);
                    $('#MainContent_txtPlaca2').val(data.Placa2);
                    $('#MainContent_txtPlaca3').val(data.Placa3);
                    $('#MainContent_txtPlaca4').val(data.Placa4);

                    $('#MainContent_txtKM').val(data.KM);
                    
                    F_BuscarResponsables();
                    F_LlenarCorreos();

                    CodResponsableReemplazo = data.CodResponsable;
                    $('#MainContent_txtResponsable2').val(data.Responsable2);
                    $('#MainContent_txtResponsableDNI2').val(data.Responsable2DNI);

                    $('#hfNotaPedido').val(data.NotaPedido);
                
                    $('.ccsestilo').css('background', '#FFFFE0');
                    $("#divTabs").tabs("option", "active", $("#liRegistro").index());
                }
                else {
                    alert(result.split('~')[1]);
                    return false;
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

var CtlgvProducto;
var HfgvProducto;

function imgMasProducto_Click(Control) {
    CtlgvProducto = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {
        var grid = $(Control).next();
        F_ProductoDetalle(grid.attr('id'));
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }
    return false;
}

function F_ProductoDetalle(Fila){
  try 
        {             
                var nmrow = 'MainContent_grvConsultaArticulo_pnlProductos_0';
                var Col = Fila.split('_')[3];
                var Codigo = $('#' + Fila.replace('pnlProductos', 'lblcodproducto')).text();           
                var grvNombre = 'MainContent_grvConsultaArticulo_grvDetalleProducto_' + Col;
                HfgvProducto = '#' + Fila.replace('pnlProductos', 'hfDetalleCargado');

                if ($(HfgvProducto).val() === "1")
                {
                    $(CtlgvProducto).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvProducto).next().html() + '</td></tr>');
                    $(CtlgvProducto).attr('src', '../Asset/images/minus.gif');
                }
                else 
                {                                                                                                                                                                                                                        {
                        var objParams = 
                        {
                            Filtro_Col: Col,
                            Filtro_Codigo: Codigo,                        
                            Filtro_grvNombre: grvNombre
                        };

                        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                        $(CtlgvProducto).attr('src', '../Asset/images/loading.gif');
                        F_ProductoDetalle_NET(arg, function (result) {
                
                        $(CtlgvProducto).attr('src', '../Asset/images/minus.gif');
                  
                        var str_resultado_operacion = result.split('~')[0];
                        var str_mensaje_operacion = result.split('~')[1];

                        if (str_resultado_operacion === "0")
                        {
                            var p = $('#' + result.split('~')[3]).parent();
                            $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                            F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);

                            $(CtlgvProducto).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvProducto).next().html() + '</td></tr>');
                            $(HfgvProducto).val('1');
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

function checkAll(objRef)
{
    var checkallid = '#' + objRef.id;

    if ($(checkallid).is(':checked'))
        $('#MainContent_grvConsulta input:checkbox').prop('checked', true);
        else
        $('#MainContent_grvConsulta input:checkbox').prop('checked', false);
}
function checkAllCorreo(objRef)
{
    var checkallid = '#' + objRef.id;

    if ($(checkallid).is(':checked'))
        $('#MainContent_grvConsultaCorreos input:checkbox').prop('checked', true);
        else
        $('#MainContent_grvConsultaCorreos input:checkbox').prop('checked', false);
}
//Joel
//api sunat
//esta funcion buscar la direccion con el ubigeo que se consigue con el api,esta funcion se encuentra en servicios
function F_BuscarDireccionNuevo() {
    if (!F_SesionRedireccionar(AppSession)) return false;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_Direccion_Buscar', 
        data: "{'Ubigeo':'" + ubigeo + "'}",    
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            $('#hfCodDepartamento').val(data[0].split(',')[0]);
            $('#hfCodProvincia').val(data[0].split(',')[1]);
            $('#hfCodDistrito').val(data[0].split(',')[2]);
            return true;

        },
        complete: function () {
            if (($('#hfRegion').val() == '' | $('#hfProvincia').val() == '') && $('#hfDistrito').val() == '') {
                toastr.warning('NO HAY DIRECCION PARA EL DISTRITO ESPECIFICADO')
                $('#MainContent_txtDireccion').val('');
                $('#hfDireccion').val('');
                $('#hfCodDireccion').val('0');
                $('#MainContent_txtCorreo').val('');
            }

        },
        error: function (response) {
            toastr.warning(response.responseText);
        },
        failure: function (response) {
            toastr.warning(response.responseText);
        }
    });

    return false;
}

// esta funcion se encarga de busca la url y el token del api para la busque en la parte de padronsunat
function F_API_RUC_Buscar() {
    if (!F_SesionRedireccionar(AppSession)) return false;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_API_RUC_Buscar',
        data: "{}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            $('#hfurlapisunat').val(data[0].split(',')[0]);
            $('#hftokenapisunat').val(data[0].split(',')[1]);
            
            return true;

        },
        complete: function () {
         
        },
        error: function (response) {
            toastr.warning(response.responseText);
        },
        failure: function (response) {
            toastr.warning(response.responseText);
        }
    });

    return false;
}

function F_AgregarArticulo(ControlID, DirectoBoton) {
    var txtprecio_Grilla = '';
    var ddlLista_grilla = '';
    var txtcant_grilla = '';
    var txtprecio_grilla = '';
    var ddlprecio_grilla = '';
    var hfArticulo_grilla = '';
    var hfPrecio1_grilla = '';
    var hfPrecio2_grilla = '';
    var hfPrecio3_grilla = '';
    var lblCodigoProducto_grilla = '';
    var lblStock_grilla = '';
    var lblUM_grilla = '';
    var lblMoneda_grilla = '';
    var lblCodProducto_grilla = '';
    var lblCosto_grilla = '';
    var lblCodUm_grilla = '';
    var boolEstado = false;
    var imgAgregar_grilla = '';
    var hfCodTipoProducto = '';
    var cadena = 'Ingrese los sgtes. campos: '

    imgAgregar_grilla = '#' + ControlID;
    ctrlPosActual = imgAgregar_grilla;
    hfArticulo_grilla = imgAgregar_grilla.replace('imgAgregar', 'lblProducto');
    hfPrecio1_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfpreciosoles');
    hfPrecio2_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfpreciodolares');
    hfCostoSoles_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfCostoProductoSoles');
    hfCostoDolares_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfCostoProductoDolares');
    hfMargen_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfMargen');
    hfRedondeo_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfRedondeo');
    hfFactorRedondeo_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfFactorRedondeo');
    hfDescuento_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfDescuento');
    lblCodigoProducto_grilla = imgAgregar_grilla.replace('imgAgregar', 'hlkCodigo');
    lblStock_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfStock');
    lblUM_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfUM');
    lblCosto_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfcosto');
    lblCodUm_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfcodunidadventa');
    hfCodTipoProducto = imgAgregar_grilla.replace('imgAgregar', 'hfCodTipoProducto');
    lblCodProducto_grilla = imgAgregar_grilla.replace('imgAgregar', 'hfcodproducto');

    $('#hfCodProductoAgregar').val($(lblCodProducto_grilla).val());
    $('#hfCostoAgregar').val($(lblCosto_grilla).val());
    $('#hfCodTipoProducto').val($(hfCodTipoProducto).val());
    $('#hfCodUmAgregar').val($(lblCodUm_grilla).val());
    $('#hfPrecioSoles').val($(hfPrecio1_grilla).val());
    $('#hfPrecioDolares').val($(hfPrecio2_grilla).val());
    $('#hfCostoSoles').val($(hfCostoSoles_grilla).val());
    $('#hfCostoDolares').val($(hfCostoDolares_grilla).val());
    $('#hfMargen').val($(hfMargen_grilla).val());
    $('#hfRedondeo').val($(hfRedondeo_grilla).val());
    $('#hfFactorRedondeo').val($(hfFactorRedondeo_grilla).val());
    $('#hfDescuento').val($(hfDescuento_grilla).val());
    $('#MainContent_txtCodigoProductoAgregar').val($(lblCodigoProducto_grilla).text());
    $('#MainContent_txtUMAgregar').val($(lblUM_grilla).val());
    $('#MainContent_txtStockAgregar').val(parseFloat($(lblStock_grilla).val()).toFixed(2));
    $('#MainContent_lblMonedaAgregar').text($(lblMoneda_grilla).val());
    

    $('#MainContent_txtArticuloAgregar').val($(hfArticulo_grilla).text());
    $('#MainContent_txtCantidad').val();
      if ($('#MainContent_ddlMoneda').val() == 1)
          $('#MainContent_txtPrecioDisplay').val($(hfPrecio1_grilla).val());
        else
          $('#MainContent_txtPrecioDisplay').val($(hfPrecio2_grilla).val());

    $("#hfMenorPrecioAgregar").val(0);

    $("#MainContent_ddlPrecio").empty();

    if ($('#MainContent_txtPrecioDisplay').val() != '')
    {
        $("#MainContent_ddlPrecio").append($("<option></option>").val($('#MainContent_txtPrecioDisplay').val()).html($('#MainContent_txtPrecioDisplay').val()));
        $("#hfMenorPrecioAgregar").val($('#MainContent_txtPrecioDisplay').val());
    }

   // $('#MainContent_chkServicios').prop('checked', false);

    F_VerUltimoPrecio_Buscar($('#MainContent_txtCodigoProductoAgregar').val(), $('#hfCodProductoAgregar').val());

    if (DirectoBoton === 1)
        F_TablaClick(ControlID);
    return false;
}

function F_CamposAlternativas(Campos) { 
                switch (Campos)
                {
                    case "MainContent_txtArticulo":
                        $('#MainContent_btnBuscarArticulo').click();
                    break;
                    case "MainContent_btnBuscarArticulo":
                        $('#MainContent_grvConsultaArticulo_imgAgregar_0').select();
                    break;
                    case "MainContent_txtArticuloAgregar":
                        $('#MainContent_txtPrecioDisplay').select();
                    break;
                     case "MainContent_txtPrecioDisplay":
                        $('#MainContent_txtDsct').select();
                    break;
                     case "MainContent_txtDsct":
                        $('#MainContent_txtCantidad').select();
                    break;
                    case "MainContent_txtCantidad":
                        if (P_UNIDADES_ENTEROS == "1")
                            $("#MainContent_txtCantidad").val(Number($("#MainContent_txtCantidad").val()).toFixed(0));
                        $('#MainContent_btnAgregar').click();
                    break;
                    case "MainContent_btnAgregar":
                           $('#MainContent_btnAgregar').click();
                    break;
                    case "MainContent_ddlSerie":
                        $('#MainContent_ddlIgv').focus();
                    break;
                    case "MainContent_txtEmision":
                        $('#MainContent_ddlFormaPago').focus();
                    break;
                    case "MainContent_txtNroOperacion":
                        $('#MainContent_txtCorreo').focus();
                    break;
                    case "MainContent_txtKM":
                        $('#MainContent_chkImpresionTicket').focus();
                    break;
                    case "ddlCorreos":
                        $('#MainContent_ddlMoneda').focus();
                    break;
                     case "MainContent_txtCliente":
                        $('#MainContent_txtDistrito').focus();
                    break;
                    case "MainContent_txtCodCotizacion":
                        if ($("#MainContent_txtCodCotizacion").val().trim() != "")
                            {
                                if (isNaN($("#MainContent_txtCodCotizacion").val().trim()))
                                    $("#MainContent_txtCodCotizacion").val('');
                                else
                                    $('#MainContent_btnFacturarCotizacion').click();
                            }
                        
                        $('#MainContent_chkImpresion').focus();
                    break;
                    default:
                    //otros casos

                        //Agregar Con Enter desde la Grilla
                        if (Campos.indexOf("MainContent_grvConsultaArticulo_imgAgregar") >= 0)
                        {
                            F_AgregarArticulo(Campos, 0);
                            return true;
                        }

                    break;
                }
return true;
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
                var Codigo = $('#' + Fila.replace('pnlOrdersAuditoria', 'lblCodigo')).val();
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
                var Codigo = $('#' + Fila.replace('pnlOrdersObservacion', 'lblCodigo')).val();
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

function F_ValidaRucDniTransportista() {
if (!F_SesionRedireccionar(AppSession)) return false;
    if ($('#MainContent_txtNroRucTransportista').val().length > 0)
    {
        if ($('#MainContent_txtNroRucTransportista').val().trim() === $('#hfNroRucTransportista').val() & 
            $('#MainContent_txtTransportista').val().trim() === $('#hfTransportista').val() & 
            $('#MainContent_txtNroRucTransportista').val().trim() != "")
        return false;

    var Index= $('#MainContent_txtNroRucTransportista').val().indexOf('-');
    var Cliente = $('#MainContent_txtNroRucTransportista').val();

    if ($('#MainContent_txtNroRucTransportista').val() != "1" & Index ==-1 ) {
       if (isNaN($('#MainContent_txtNroRucTransportista').val()) | !ValidarRuc($('#MainContent_txtNroRucTransportista').val()))
        {
            $('#MainContent_txtNroRucTransportista').val('');
            $('#MainContent_txtNroRucTransportista').focus();
            alertify.log('ERROR EN RUC');
            return false;
        }
    } else {
    $('#MainContent_txtNroRucTransportista').val(Cliente.split('-')[0].trim());
    }

        if ($('#hfCodCtaCteTransportista').val() != '0') 
            return true;

        $('#MainContent_txtTransportista').val('');
        $('#hfTransportista').val('');

        //DNI
        if ($('#MainContent_txtNroRucTransportista').val().length == 8)
        {
            $('#MainContent_txtNroRucTransportista').val('');
            $('#MainContent_txtNroRucTransportista').focus();
            alertify.log('ERROR EN RUC');
            return false;
        }
        else
        {
            //RUC
            if ($('#MainContent_txtNroRucTransportista').val().length == 11 & $('#MainContent_txtNroRucTransportista').val() != '55555555555')
            {
                $('#MainContent_txtTransportista').focus();
                F_BuscarPadronSunatTransportista();
                return true;
            }
        }
    }
    else
    {
        if ($('#MainContent_txtNroRucTransportista').val() != $('#hfNroRucTransportista').val())
        {
            F_LimpiarCamposTransportista();
            return true;
        }
    }
   return false;
}

function F_ValidaRucDniConductor() {
if (!F_SesionRedireccionar(AppSession)) return false;
    if ($('#MainContent_txtConductorDNI').val().length > 0)
    {
        if ($('#MainContent_txtConductorDNI').val().trim() === $('#hfDniConductor').val() & 
            $('#MainContent_txtConductorRazonSocial').val().trim() === $('#hfNombreConductor').val() & 
            $('#MainContent_txtConductorDNI').val().trim() != "")
        return false;

    var Index= $('#MainContent_txtConductorDNI').val().indexOf('-');
    var Cliente = $('#MainContent_txtConductorDNI').val();

    if ($('#MainContent_txtConductorDNI').val() != "1" & Index ==-1 ) {
       if (isNaN($('#MainContent_txtConductorDNI').val()) | !ValidarRuc($('#MainContent_txtConductorDNI').val()))
        {
            $('#MainContent_txtConductorDNI').val('');
            $('#MainContent_txtConductorDNI').focus();
            alertify.log('ERROR EN RUC');
            return false;
        }
    } else {
    $('#MainContent_txtConductorDNI').val(Cliente.split('-')[0].trim());
    }

        if ($('#hfCodConductor').val() != '0') 
            return true;

        $('#MainContent_txtConductorDNI').val('');
        $('#hfNombreConductor').val('');

        //DNI
        if ($('#MainContent_txtConductorDNI').val().length == 8)
        {
            $('#MainContent_txtConductorDNI').val('');
            $('#MainContent_txtConductorDNI').focus();
            alertify.log('ERROR EN RUC');
            return false;
        }
        else
        {
            //RUC
            if ($('#MainContent_txtConductorDNI').val().length == 11 & $('#MainContent_txtConductorDNI').val() != '55555555555')
            {
                $('#MainContent_txtConductorDNI').focus();
                
                return true;
            }
        }
    }
    else
    {
        if ($('#MainContent_txtConductorDNI').val() != $('#hfDniConductor').val())
        {
           $('#MainContent_txtConductorDNI').val('')
           $('#MainContent_txtConductorRazonSocial').val('')
           $('#hfCodConductor').val(0)
           $('#hfDniConductor').val('')
            return true;
        }
    }
   return false;
}

function F_ValidaRucDniConductorEdicion() {
if (!F_SesionRedireccionar(AppSession)) return false;
    if ($('#MainContent_txtConductorDNIEdicion').val().length > 0)
    {
        if ($('#MainContent_txtConductorDNIEdicion').val().trim() === $('#hfDniConductor').val() & 
            $('#MainContent_txtConductorRazonSocialEdicion').val().trim() === $('#hfNombreConductor').val() & 
            $('#MainContent_txtConductorDNIEdicion').val().trim() != "")
        return false;

    var Index= $('#MainContent_txtConductorDNIEdicion').val().indexOf('-');
    var Cliente = $('#MainContent_txtConductorDNIEdicion').val();

    if ($('#MainContent_txtConductorDNIEdicion').val() != "1" & Index ==-1 ) {
       if (isNaN($('#MainContent_txtConductorDNIEdicion').val()) | !ValidarRuc($('#MainContent_txtConductorDNIEdicion').val()))
        {
            $('#MainContent_txtConductorDNIEdicion').val('');
            $('#MainContent_txtConductorDNIEdicion').focus();
            alertify.log('ERROR EN RUC');
            return false;
        }
    } else {
    $('#MainContent_txtConductorDNIEdicion').val(Cliente.split('-')[0].trim());
    }

        if ($('#hfCodConductor').val() != '0') 
            return true;

        $('#MainContent_txtConductorDNIEdicion').val('');
        $('#hfNombreConductor').val('');

        //DNI
        if ($('#MainContent_txtConductorDNIEdicion').val().length == 8)
        {
            $('#MainContent_txtConductorDNIEdicion').val('');
            $('#MainContent_txtConductorDNIEdicion').focus();
            alertify.log('ERROR EN RUC');
            return false;
        }
        else
        {
            //RUC
            if ($('#MainContent_txtConductorDNIEdicion').val().length == 11 & $('#MainContent_txtConductorDNIEdicion').val() != '55555555555')
            {
                $('#MainContent_txtConductorDNIEdicion').focus();
                
                return true;
            }
        }
    }
    else
    {
        if ($('#MainContent_txtConductorDNIEdicion').val() != $('#hfDniConductor').val())
        {
           $('#MainContent_txtConductorDNIEdicion').val('')
           $('#MainContent_txtConductorRazonSocialEdicion').val('')
           $('#hfCodConductor').val(0)
           $('#hfDniConductor').val('')
            return true;
        }
    }
   return false;
}

function F_VerArchivoCDR (Control) {
    Control = '#' + Control.replace('lblEstadoSunat', 'lblnumero');
    $('#MainContent_txtFacturaCDR').val($(Control).text());
    $('#MainContent_txtArchivoCDR').val('');
    Control = Control.replace('lblnumero', 'lblCodigo');

    $('#hfCodDocumentoVentaDescargaCDR').val($(Control).val());
    

    $.ajax({
        async: true,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: 'RegistroFacturaWilliam.aspx/F_ObtenerArchivoCDR_NET',
        dataType: "json",
        data: "{'CodDocumentoVenta':'" + $(Control).val()  + "'}",
        success: function (dbObject) {
            MostrarEspera(true);
            var data = dbObject.d;
            try {

                $('#div_CDR').dialog({
                    resizable: false,
                    modal: true,
                    title: "Archivo CDR",
                    title_html: true,
                    height: 130,
                    width: 300,
                    autoOpen: false
                });

                $('#MainContent_txtArchivoCDR').val(data.ArchivoCDR.trim());
                $('#tr_btnDescargaCDR').css('display', 'block');
                if (data.ArchivoCDR.trim() === 'NO HA SIDO PROCESADO') 
                    $('#tr_btnDescargaCDR').css('display', 'none');

                $('#div_CDR').dialog('open');

            }
            catch (x) { alertify.log(''); }
            MostrarEspera(false);
        },
        complete: function () {
        
        },
        error: function (xhr, ajaxOptions, thrownError) {

        },
        async: true
    });
}

function F_DescargarArchivosPDF () {

//descargo el PDF
    $.ajax({
        async: true,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Stocks.asmx/DescargarDocumentosSunat',
        dataType: "json",
        data: "{'CodDocumentoVenta':'" + $('#hfCodDocumentoVentaDescargaCDR').val()  + "','TipoDocumento':'PDF'}",
        success: function (dataObject) {
            var result = dataObject.d;

            if (result.Mensaje === "" | result.Mensaje === "DOCUMENTO ANULADO") {
                try {
                    if (result.MensajePdf === "") {
                        var bytespdf = new Uint8Array(result.ArchivoPdf);
                        var blobpdf = new Blob([bytespdf], { type: "application/pdf" });
                        var linkpdf = document.createElement('a');
                        linkpdf.href = window.URL.createObjectURL(blobpdf);
                        linkpdf.download = result.ArchivoPdfNombre;
                        linkpdf.click();
                    } else {
                        alertify.error(result.MensajePdf);
                    }
                }
                catch (err) { }

            } else {
                alertify.error(result.Mensaje);
            }

            if (result.Mensaje + result.MensajePdf + result.MensajeXml === "") {
                alertify.success("Operacion completada con exito");
            }
        },
        complete: function () {
        
        },
        error: function (xhr, ajaxOptions, thrownError) {

        },
        async: true
    });

    return true;
}

function F_DescargarArchivosXML () {

//descargo el XML ENVIO
    $.ajax({
        async: true,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Stocks.asmx/DescargarDocumentosSunat',
        dataType: "json",
        data: "{'CodDocumentoVenta':'" + $('#hfCodDocumentoVentaDescargaCDR').val()  + "','TipoDocumento':'ENVIO'}",
        success: function (dataObject) {
            var result = dataObject.d;

            if (result.Mensaje === "") {
                try {
                    if (result.MensajeXml === "") {
                        var bytesxml = new Uint8Array(result.ArchivoXml);
                        var blobxml = new Blob([bytesxml], { type: "application/xml" });
                        var linkxml = document.createElement('a');
                        linkxml.href = window.URL.createObjectURL(blobxml);
                        linkxml.download = result.ArchivoXmlNombre;
                        linkxml.click();
                    } else {
                        alertify.error(result.MensajeXml);
                    }

                }
                catch (err) { }

            } else {
                alertify.error(result.Mensaje);
            }

            if (result.Mensaje + result.MensajePdf + result.MensajeXml === "") {
                alertify.success("Operacion completada con exito");
            }
        },
        complete: function () {
        
        },
        error: function (xhr, ajaxOptions, thrownError) {

        },
        async: true
    });


    return true;
}

function F_DescargarArchivosCDR () {

//descargo el CDR RPTA
    $.ajax({
        async: true,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Stocks.asmx/DescargarDocumentosSunat',
        dataType: "json",
        data: "{'CodDocumentoVenta':'" + $('#hfCodDocumentoVentaDescargaCDR').val()  + "','TipoDocumento':'RPTA'}",
        success: function (dataObject) {
            var result = dataObject.d;

            if (result.Mensaje === "") {
                try {
                    if (result.MensajeCdr === "") {
                        var bytescdr = new Uint8Array(result.ArchivoCdr);
                        var blobcdr = new Blob([bytescdr], { type: "application/cdr" });
                        var linkcdr = document.createElement('a');
                        linkcdr.href = window.URL.createObjectURL(blobcdr);
                        linkcdr.download = result.ArchivoCdrNombre;
                        linkcdr.click();
                    } else {
                        alertify.error(result.Mensajecdr);
                    }
                }
                catch (err) { }

            } else {
                alertify.error(result.Mensaje);
            }

            if (result.Mensaje + result.MensajePdf + result.MensajeXml === "") {
                alertify.success("Operacion completada con exito");
            }
        },
        complete: function () {
        
        },
        error: function (xhr, ajaxOptions, thrownError) {

        },
        async: true
    });




}

var arrCotizaciones = new Array();
function F_Pedidos() {
    PedidosCargados = false;
    $.ajax({
        async: true,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: 'RegistroFacturaWilliam.aspx/F_Consulta_Cotizaciones_Pendientes_NET',
        dataType: "json",
        data: "{'CodAlmacen':'" + $('#hfCodSede').val()  + "'}",
        success: function (dbObject) {
            MostrarEspera(true);
            var data = dbObject.d;
            try {
                var lu = $('#lu_Cotizaciones');
                lu.empty();
                var Count = 1;
                var CountVisible = 1;
                arrCotizaciones = new Array();
                $.each(data.rows, function (index, item) {
                    var fmt2 =   ' <li style="width: 170px; height:30px; padding-top:0px; display:block"> <div class="linea-button"> ' +
                                '  <table cellpadding="0" cellspacing="0" style="width: 170px;" > <tr>  ' +
								'  		<td style="width: 40px; Display:none;"> ' +
                                '             <label style="font-weight: bold; font-size: 24px;">@Nro</label> ' +
                                '             <input type="hidden" id="@ID" value="@CodProforma"> ' +
                                '             <input type="hidden" id="@ID_SERIE" value="@Serie"> ' +
                                '             <input type="hidden" id="@ID_NUMERO" value="@Numero"> ' +
                                '             <input type="hidden" id="@ID_EMISION" value="@Emision"> ' +
                                '             <input type="hidden" id="@ID_VENCIMIENTO" value="@Vencimiento"> ' +
                                '             <input type="hidden" id="@ID_CODCTACTE" value="@CodCtaCte"> ' +
                                '             <input type="hidden" id="@ID_NRORUC" value="@NroRuc"> ' +
                                '             <input type="hidden" id="@ID_CLIENTE" value="@Cliente"> ' +
                                '             <input type="hidden" id="@ID_CODDEPARTAMENTO" value="@CodDepartamento"> ' +
                                '             <input type="hidden" id="@ID_CODPROVINCIA" value="@CodProvincia"> ' +
                                '             <input type="hidden" id="@ID_CODDISTRITO" value="@CodDistrito"> ' +
                                '             <input type="hidden" id="@ID_DISTRITO" value="@Distrito"> ' +
                                '             <input type="hidden" id="@ID_DIRECCION" value="@Direccion"> ' +
                                '             <input type="hidden" id="@ID_CODMONEDA" value="@CodMoneda"> ' +
                                '             <input type="hidden" id="@ID_TC" value="@TC"> ' +
                                '             <input type="hidden" id="@ID_SUBTOTAL" value="@Subtotal"> ' +
                                '             <input type="hidden" id="@ID_IGV" value="@Igv"> ' +
                                '             <input type="hidden" id="@ID_TOTAL" value="@Total"> ' +
								'             <input type="hidden" id="@ID_FLAGIGV" value="@FlagIgv"> ' +
								'             <input type="hidden" id="@ID_NROOPERACION" value="@NroOperacion"> ' +
								'             <input type="hidden" id="@ID_CODEMPLEADO" value="@CodEmpleado"> ' +
								'             <input type="hidden" id="@ID_PLACA" value="@Placa"> ' +
								'             <input type="hidden" id="@ID_KM" value="@KM"> ' +
                                '       </td> ' +
								'  		<td style="width: 100;padding-left:45px"> ' +
                                '             <label style="font-weight: bold; font-size: 18px;">@NroDocumento</label> ' +
                                '       </td> ' +
								'  		<td style="padding-left:5px"> ' +
                                '             <label style="font-weight: bold; font-size: 18px;">@ElVendedor</label> ' +
                                '       </td> ' +
								'  		<td style="width: 25"> ' +
                                '             <button type="button" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="25"  height:"25" ' + 
                                '                   id="@ID_BTNAGREGARCOTIZACION" onclick="F_AgregarTemporalCTxBoton(this.id); return false;"> ' +
                                '             <img src="../Asset/images/ok.gif"> </button>  ' +
                                '       </td> ' +
                                '     </tr> ' +
                                '     <table> ' +
                                ' </div> </li> ';


                    var li = fmt2.replace('@Nro', Count).replace('@ID', 'COTIZACION_CODPROFORMA_' + Count).replace('@CodProforma', item.CodProforma)
                                        .replace('@NroDocumento', Number(item.Numero)).replace("@ElVendedor", item.Vendedor).replace('@Cliente', item.Cliente)
                                        .replace('@ID_SERIE', 'COTIZACION_SERIE_' + Count).replace('@Serie', item.Serie)
                                        .replace('@ID_NUMERO', 'COTIZACION_NUMERO_' + Count).replace('@Numero', item.Numero)
                                        .replace('@ID_EMISION', 'COTIZACION_EMISION_' + Count).replace('@Emision', item.EmisionStr)
                                        .replace('@ID_VENCIMIENTO', 'COTIZACION_VENCIMIENTO_' + Count).replace('@Vencimiento', item.VencimientoStr)
                                        .replace('@ID_CODCTACTE', 'COTIZACION_CODCTACTE_' + Count).replace('@CodCtaCte', item.CodCtaCte)
                                        .replace('@ID_NRORUC', 'COTIZACION_NRORUC_' + Count).replace('@NroRuc', item.NroRuc)
                                        .replace('@ID_CLIENTE', 'COTIZACION_CLIENTE_' + Count).replace('@Cliente', item.CodCtaCte)
                                        .replace('@ID_CODDEPARTAMENTO', 'COTIZACION_CODDEPARTAMENTO_' + Count).replace('@CodDepartamento', item.CodDepartamento)
                                        .replace('@ID_CODPROVINCIA', 'COTIZACION_CODPROVINCIA_' + Count).replace('@CodProvincia', item.CodProvincia)
                                        .replace('@ID_CODDISTRITO', 'COTIZACION_CODDISTRITO_' + Count).replace('@CodDistrito', item.CodDistrito)
                                        .replace('@ID_DISTRITO', 'COTIZACION_DISTRITO_' + Count).replace('@Distrito', item.Distrito)
                                        .replace('@ID_DIRECCION', 'COTIZACION_DIRECCION_' + Count).replace('@Direccion', item.Direccion)
                                        .replace('@ID_CODFORMAPAGO', 'COTIZACION_CODFORMAPAGO_' + Count).replace('@CodFormaPago', item.CodFormaPago)
                                        .replace('@ID_CODMONEDA', 'COTIZACION_CODMONEDA_' + Count).replace('@CodMoneda', item.CodMoneda)
                                        .replace('@ID_TC', 'COTIZACION_TC_' + Count).replace('@TC', item.TipoCambio)
                                        .replace('@ID_SUBTOTAL', 'COTIZACION_SUBTOTAL_' + Count).replace('@Subtotal', item.SubTotal)
                                        .replace('@ID_IGV', 'COTIZACION_IGV_' + Count).replace('@Igv', item.Igv)
                                        .replace('@ID_TOTAL', 'COTIZACION_TOTAL_' + Count).replace('@Total', item.Total)
                                        .replace('@ID_BTNAGREGARCOTIZACION', 'BTN_COTIZACION_' + Count).replace('@Total', item.Total)
										.replace('@ID_FLAGIGV', 'COTIZACION_FLAGIGV_' + Count).replace('@FlagIgv', item.FlagIgv)
										.replace('@ID_NROOPERACION', 'COTIZACION_NROOPERACION_' + Count).replace('@NroOperacion', item.NroOperacion)
										.replace('@ID_CODEMPLEADO', 'COTIZACION_CODEMPLEADO_' + Count).replace('@CodEmpleado', item.CodEmpleado)
										.replace('@ID_PLACA', 'COTIZACION_PLACA_' + Count).replace('@Placa', item.Placa)
										.replace('@ID_KM', 'COTIZACION_KM_' + Count).replace('@KM', item.KM)



                        var objDetalle = {
                            Indice: Count,
                            CodProforma: item.CodProforma,
                            Serie: item.Serie,
                            Numero: item.Numero,
                            Nro: item.Serie + '-' + item.Numero
                        };
                        arrCotizaciones.push(objDetalle);
                    
                    if (CountVisible > 13 | item.FlagVisibleFacturacion == 0)
						li = li.replace('block', 'none');

                    lu.append(li);
                    Count++;

                    if (item.FlagVisibleFacturacion == 1)
						CountVisible++;

                });
                PedidosCargados = true;
            }
            catch (x) { alertify.log('El Producto no tiene Imagenes'); }
            MostrarEspera(false);
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    });

}

var cotFlagIgv = '';
function F_AgregarTemporalCTxBoton(Boton) {
    $('#MainContent_txtCodCotizacion').val($('#COTIZACION_NUMERO_' + Boton.split('_')[2]).val());
    F_AgregarTemporalCTxNumero();
}

function F_AgregarTemporalCTxNumero() {
        var Contenedor = '#MainContent_';
        var Mensaje = "Ingrese los sgtes datos: ";

        if ($(Contenedor + 'txtCodCotizacion').val() == "")
            Mensaje = Mensaje + "\n" + "Numero Cotizacion";
  
        if (Mensaje != "Ingrese los sgtes datos: ") {
            alertify.log(Mensaje);
            return false;
        }

    $.ajax({
        async: true,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: 'RegistroFacturaWilliam.aspx/F_ObtenerCotizacion_PorNumero_Net',
        dataType: "json",
        data: "{'NumeroCotizacion':'" + $(Contenedor + 'txtCodCotizacion').val()  + "'}",
        success: function (dbObject) {
            MostrarEspera(true);
            var data = dbObject.d;
            try {

            $('#MainContent_ddlMoneda').val(data.CodMoneda);
            
              if (data.FlagComisionable==1)
                  $('#MainContent_chkComisionable').prop('checked', true);   
              else
                  $('#MainContent_chkComisionable').prop('checked', false);   

        var arrDetalle = new Array();
        var Contenedor = '#MainContent_';
        var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

                    //Array de Items
                    $.each(data.lProformaDet, function (index, item) {
                        var objDetalle = {
                            CodArticulo: item.CodArticulo,
                            Cantidad: item.Cantidad,
                            Precio: item.Precio,
                            PrecioDscto: item.Precio,
                            Precio2: item.Precio2 ,
                            Costo: 0,
                            CodUm: item.CodUnidadMedida,
                            CostoUnitario: 0,
                            Dscto: 0,
                            CodDetalle: item.CodDetalleProforma,
                            OC: '',
                            Descripcion: item.Descripcion,
                            Acuenta: 0,
                            CodTipoDoc: 15,
                            Fecha: ''
                        };
                        arrDetalle.push(objDetalle);



                    });

                    var objParams = {
                        Filtro_CodTipoDoc: 15,
                        Filtro_SerieDoc: data.Serie,
                        Filtro_NumeroDoc: data.Numero,
                        Filtro_FechaEmision: data.EmisionStr,
                        Filtro_Vencimiento: data.VencimientoStr,
                        Filtro_CodCliente: data.CodCtaCte,
                        Filtro_CodFormaPago: data.CodFormaPago,
                        Filtro_CodMoneda: data.CodMoneda,
                        Filtro_TipoCambio: data.TipoCambio,
                        Filtro_SubTotal: data.SubTotal,
                        Filtro_CodProforma: data.CodProforma,
                        Filtro_Igv: data.Igv,
                        Filtro_Total: data.Total,
                        Filtro_CodGuia: "0",
                        Filtro_Descuento: "0",
                        Filtro_TasaIgv: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                        Filtro_TasaIgvDscto: tasaigv,
                        Filtro_CodigoTemporal: $('#hfCodigoTemporal').val(),
                        Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle),
                        Filtro_FlagIgv: data.FlagIgv
                    };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                F_AgregarTemporal_NET(arg, function (result) {
                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (result.split('~')[2] == "Los Producto(s) se han agregado con exito") {
                        
                        $('#MainContent_chkConIgvMaestro').prop('checked', true);
                        $('#MainContent_chkSinIgvMaestro').prop('checked', false);
                        if (cotFlagIgv === '0') {
                            $('#MainContent_chkConIgvMaestro').prop('checked', false);
                            $('#MainContent_chkSinIgvMaestro').prop('checked', true);                        
                        }
                            
                        
                        $('#hfCodigoTemporal').val(result.split('~')[3]);
                        $('#MainContent_txtTotal').val(parseFloat(result.split('~')[5]).toFixed(2));
                        $('#MainContent_txtIgv').val(parseFloat(result.split('~')[6]).toFixed(2));
                        $('#MainContent_txtSubTotal').val(parseFloat(result.split('~')[7]).toFixed(2));
                        $('#hfCodProforma').val(result.split('~')[8]);
                        
                        if ($('#MainContent_ddlFormaPago').val() == "1" | $('#MainContent_ddlFormaPago').val() == "5" | $('#MainContent_ddlFormaPago').val() == "6" |                                     $('#MainContent_ddlFormaPago').val() == "10" |  $('#MainContent_ddlFormaPago').val() == "15")
                            $('#MainContent_txtAcuenta').val(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaNV').val()).toFixed(2));
                        F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                        

                        $('#MainContent_txtNroRuc').val(data.NroRuc);
                        $('#hfNroRuc').val(data.NroRuc);
                        $('#MainContent_txtCliente').val(data.Cliente);
                        $('#hfCliente').val(data.Cliente);

                        $('#hfCodCtaCte').val(data.CodCtaCte);
                        $('#hfCodDepartamento').val(data.CodDepartamento);
                        $('#hfCodProvincia').val(data.CodProvincia);
                        $('#hfCodDistrito').val(data.CodDistrito);
                        $('#MainContent_txtDistrito').val(data.Distrito);
                        $('#MainContent_txtDireccion').val(data.Direccion);
                        $('#MainContent_txtNroOperacion').val(data.NroOperacion);
                        $('#MainContent_txtAtencion').val(data.Atencion);
                        $('#MainContent_txtNroOC').val(data.NroOC);
                        $('#MainContent_ddlVendedor').val(data.CodEmpleado);
                        $('#MainContent_txtPlaca').val(data.Placa);
                        $('#MainContent_txtPlaca2').val(data.Placa2);
                        $('#MainContent_txtPlaca3').val(data.Placa3);
                        $('#MainContent_txtPlaca4').val(data.Placa4);
                        $('#MainContent_txtKM').val(data.KM);
                        $('#MainContent_txtObservacion').val(data.Observacion);
                        $('#MainContent_txtRequerimiento').val(data.Requerimiento);
                        $('#MainContent_ddlVendedor').val(data.CodEmpleado);
                        $('#hfCodDireccionDefecto').val(data.CodDireccion);
                        $('#MainContent_ddlFormaPago').val(data.CodFormaPago);
                        $('.ccsestilo').css('background', '#FFFFE0');
                        $('#hfNotaPedido').val(0)
//                        $('#hfNotaPedido').val(result.split('~')[9]);
                            if ($('#hfNotaPedido').val() == '5')
                                $('#hfCodCtaCteNP').val($('#hfCodCtaCte').val());
                                else $('#hfCodCtaCteNP').val(0);

                        F_BuscarDireccionesCliente();

                        $('#MainContent_txtCodCotizacion').val('');
                                F_GuardarDireccion($('#MainContent_txtNroRuc').val(),'#hfCodigoTemporal',$('#hfCodCtaCte').val(),'#MainContent_txtCliente',0,
                        Ubigeo,Direccion,'#MainContent_ddldireccionNueva','#MainContent_ddldireccionNuevaDestino',Codtipodoc);
                        

                   BuscarDireccionCotizacion('#hfCodigoTemporal',data.CodDireccion,'#MainContent_ddldireccionNueva','#MainContent_ddldireccionNuevaDestino',Codtipodoc);
                    
                        $('#div_Cotizacion').dialog('close');
                        $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));

                    }
                    else {
                        MostrarEspera(false);
                        alertify.log(result.split('~')[1]);
                    }
                    return false;
                });
                }
            catch (x) { alertify.log('La cotizacion no esta disponible'); }
            MostrarEspera(false);
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    });

}
var verificarvale=0;
function F_FacturarVale() {
//        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

        try {

        var chkSi='';
        var arrDetalle = new Array();
        var lblcoddoc_grilla='';

        var chkSi = '';
    var CLIENTE = '';
    var MONEDA = '';
    var FORMAPAGO = '';
    var CodCliente = '';
    var CodMoneda = '';
    var CodFormapago = '';
    var codctacte = '';
    var codmo = '';
    var codfor = '';
    var Estado = '';

                        $('#MainContent_grvConsulta  .chkDelete :checkbox').each(function () {
                         chkSi = '#' + this.id;
                          CLIENTE = chkSi.replace('chkEliminar', 'hfCodCtaCte');
                          MONEDA = chkSi.replace('chkEliminar', 'hfCodMoneda');
                          FORMAPAGO = chkSi.replace('chkEliminar', 'hfcodformapago');
                          if ($(chkSi).is(':checked')) {
                               CodCliente =$(CLIENTE).val();
                               CodMoneda =$(MONEDA).val();
                               CodFormapago =$(FORMAPAGO).val();
                               
                           return false
                            }

                        });

                          $('#MainContent_grvConsulta  .chkDelete :checkbox').each(function () {
                         chkSi = '#' + this.id;
                          
                          codctacte = chkSi.replace('chkEliminar', 'hfCodCtaCte');
                          codmo = chkSi.replace('chkEliminar', 'hfCodMoneda');
                          codfor = chkSi.replace('chkEliminar', 'hfcodformapago');
                          Estado = chkSi.replace('chkEliminar', 'lblEstado');
                          if ($(chkSi).is(':checked')) {

                            if( $(codmo).val()!= CodMoneda ){
                             $(chkSi).prop('checked', false);
                             alertify.log('LAS PROFORMAS DEBEN DE SER DEL MISMO CLIENTE Y MISMA MONEDA ');
                             Resultado=false;
                    return true;
                            }
                            else if ($(Estado).text()== 'FACTURADO')
                            {
                             $(chkSi).prop('checked', false);
                             alertify.log('SOLO PROFORMAS PENDIENTES');
                             Resultado=false;
                    return true;
                            }
                               
                            }

                        });

                        if (Resultado ===false)
                        {
                           return true;
                        } 
            
              $('#MainContent_grvConsulta .chkDelete :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblcoddoc_grilla = chkSi.replace('chkEliminar', 'lblCodigo');
                    lblCodMoneda_grilla = chkSi.replace('chkEliminar', 'hfCodMoneda');
                    lblEstado_grilla = chkSi.replace('chkEliminar', 'lblEstado');
                   
                  if ($(chkSi).is(':checked') ) 
                    {
                        var objDetalle = {
                       
                        CodDoc: $(lblcoddoc_grilla).val()
                        };
                                               
                        arrDetalle.push(objDetalle);
                    }
                });

        

          if ( $('#MainContent_ddlTipoDoc2').val() != 16 ) {
                alertify.log('SOLO SE PUEDEN FACTURAR LAS PROFORMAS');
                return true;
            }

            var objParams = {
                Filtro_CodDoc: $("#MainContent_ddlTipoDoc").val(),
                Filtro_TasaIgv: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                Filtro_NotaPedido: 1,
                Filtro_CodTipoDoc: $("#MainContent_ddlTipoDoc").val(),
                Filtro_TasaIgvDscto: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                Filtro_Tasa: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                Filtro_CodMoneda: $(lblCodMoneda_grilla).val(),
                Filtro_CodDocumentoventa: $('#hfCodigoTemporal').val(),
                Filtro_XmlDetalle: Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle)
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);

            F_FacturarVale_NET(arg, function (result) {
                MostrarEspera(false);

                var str_resultado_operacion = result.split('~')[0];
                var str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") {

                if (str_mensaje_operacion=='')
                    {
                         $('#MainContent_ddlTipoDoc').val($("#MainContent_ddlTipoDoc").val());
//                    $('#MainContent_ddlTipoDoc').prop('disabled', true);

                    var data = jQuery.parseJSON(result.split('~')[4]);

                    $('#hfCodFacturaAnterior').val(data.CodFactura_Anterior);
                    $('#hfCodigoTemporal').val(data.Codigo);
                     $('#hfCodProforma').val(data.CodFactura_Anterior);
                    F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[2]);

                    F_Update_Division_HTML('div_serie', result.split('~')[3]);
                    $('#MainContent_ddlSerie').css('background', '#FFFFE0');


                    $('#MainContent_txtTotal').val( result.split('~')[5]);
                    $('#MainContent_txtMonto').val(data.Total);
                    $('#MainContent_txtIgv').val( result.split('~')[6]);
                    $('#MainContent_txtSubTotal').val( result.split('~')[7]);
                    $('#MainContent_txtDsctoTotal').val(data.Descuento);
                    $('#MainContent_txtNroRuc').val(data.NroRuc);
                    $('#MainContent_txtCliente').val(data.Cliente);
                    $('#MainContent_ddlMoneda').val(data.CodMoneda);
                    var Moneda = 'S/ ';
                    if ($('#MainContent_ddlMoneda').val() === "2")
                        Moneda = '$ ';
                    $('#MainContent_txtTotal2').val(Moneda + data.Total);

                    //---------
                    $('#MainContent_ddlFormaPago').val(data.CodFormaPago);
                    $('#hfCodCtaCte').val(data.CodCliente);
                    $('#MainContent_txtNumero').val(data.NumeroDoc);
                    //$('#MainContent_ddlSerie').val(data.SerieDoc);
                      
                    $('#MainContent_txtEmision').val(data.FechaEmisionStr);
                    $('#MainContent_txtVencimiento').val(data.FechaVencimientoStr);

                    $('#MainContent_ddlIgv').val(data.CodTasa);

                    $('#MainContent_chkConIgvMaestro').prop('checked', true);
                    $('#MainContent_chkSinIgvMaestro').prop('checked', false);
                    if (Number(data.FlagIgv) == 0) {
                        $('#MainContent_chkConIgvMaestro').prop('checked', false);
                        $('#MainContent_chkSinIgvMaestro').prop('checked', true);                    
                    }

                    $('#hfCodDireccionDefecto').val(data.CodDireccion);
//                    F_BuscarDireccionesCliente();
                    $('#hfCodDireccion').val(data.CodDireccion);
                    $('#hfCodDepartamento').val(data.CodDepartamento);
                    $('#hfCodProvincia').val(data.CodProvincia);
                    $('#hfCodDistrito').val(data.CodDistrito);
                    $('#hfDistrito').val(data.Distrito);
                    $('#MainContent_txtDistrito').val(data.Distrito);
                    $('#hfFlagReemplazotmp').val(result.split('~')[26]);

                    $('#MainContent_txtPlaca').val(data.Placa);
                    $('#MainContent_txtPlaca2').val(data.Placa2);
                    $('#MainContent_txtPlaca3').val(data.Placa3);
                    $('#MainContent_txtPlaca4').val(data.Placa4);
                    $('#MainContent_txtPlaca5').val(data.Placa5);
                    $('#MainContent_txtPlaca6').val(data.Placa6);
                    $('#MainContent_txtPlaca7').val(data.Placa7);
                    $('#MainContent_txtPlaca8').val(data.Placa8);

                    $('#MainContent_txtKM').val(data.KM);

                    F_BuscarResponsables();
                    F_LlenarCorreos();
                    $('#hfNotaPedido').val('1');
                    $('#MainContent_ddlTipoDoc').val('1');
                    F_CambioTipoDoc();
                    
                    F_CambioSerie_TipoDoc();
                    $('#hfCodtipodoctemporal').val(data.Codtipodoctemporal);
                     F_ContarItems();
                    CodResponsableReemplazo = data.CodResponsable;
                    $('#MainContent_txtResponsable2').val(data.Responsable2);
                    $('#MainContent_txtResponsableDNI2').val(data.Responsable2DNI);
                    if ($('#MainContent_txtNroRuc').val()=='11111111' ){
                    $('#MainContent_txtNroRuc').prop('disabled', true);
                    $('#MainContent_txtCliente').prop('disabled', true);
                    $('#MainContent_txtDistrito').prop('disabled', true);
                    $('#MainContent_txtDireccion').prop('disabled', true);
                    }else{
                    
                    $('#MainContent_txtNroRuc').prop('disabled', false);
                    $('#MainContent_txtCliente').prop('disabled', false);
                    $('#MainContent_txtDistrito').prop('disabled', false);
                    $('#MainContent_txtDireccion').prop('disabled', false);
                    $('#MainContent_ddlMoneda').prop('disabled', false);
                    }

//                   $('#MainContent_txtDestino').val($("#MainContent_txtDireccion").val().trim() + ' ' + $('#MainContent_txtDistrito').val().trim());
  F_GuardarDireccion($('#MainContent_txtNroRuc').val(),'#hfCodigoTemporal',$('#hfCodCtaCte').val(),'#MainContent_txtCliente'
            ,0,Ubigeo,Direccion,'#MainContent_ddldireccionNueva','#MainContent_ddldireccionNuevaDestino',1);  
                
                    $('.ccsestilo').css('background', '#FFFFE0');
                    $("#divTabs").tabs("option", "active", $("#liRegistro").index());
                    }
                    else
                    {
                        alertify.log(result.split('~')[1]);
                        return false;                    
                    }
                    
                   
                }
                else {
                    alert(result.split('~')[1]);
                    return false;
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
    var Resultado = "0";
    function Verificar_VALE() {
     var chkSi = '';
    var CLIENTE = '';
    var MONEDA = '';
    var CodCliente = '';
    var CodMoneda = '';
    var codctacte = '';
    var codmo = '';
    var Estado = '';

                        $('#MainContent_grvConsulta  .chkDelete :checkbox').each(function () {
                         chkSi = '#' + this.id;
                          CLIENTE = chkSi.replace('chkEliminar', 'hfCodCtaCte');
                          MONEDA = chkSi.replace('chkEliminar', 'hfCodMoneda');
                          if ($(chkSi).is(':checked')) {
                               CodCliente =$(CLIENTE).val();
                               CodMoneda =$(MONEDA).val();
                               
                           return false
                            }

                        });

                          $('#MainContent_grvConsulta  .chkDelete :checkbox').each(function () {
                         chkSi = '#' + this.id;
                          
                          codctacte = chkSi.replace('chkEliminar', 'hfCodCtaCte');
                          codmo = chkSi.replace('chkEliminar', 'hfCodMoneda');
                          Estado = chkSi.replace('chkEliminar', 'lblEstado');
                          if ($(chkSi).is(':checked')) {

                            if($(codctacte).val()!= CodCliente || $(codmo).val()!= CodMoneda){
                             $(chkSi).prop('checked', false);
                             alertify.log('LAS PROFORMAS DEBEN DE SER MISMA MONEDA');
                             Resultado=false;
                    return false;
                            }
                            else if ($(Estado).text()== 'FACTURADO')
                            {
                             $(chkSi).prop('checked', false);
                             alertify.log('SOLO VALE PENDIENTES');
                             Resultado=false;
                    return false;
                            }
                               
                            }
                            return Resultado;
                        });
}

function F_AnularPopUP(Fila) {
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Anular') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        var imgID = Fila.id;
        var lblCodigo = '#' + imgID.replace('imgAnularDocumento', 'lblCodigo');
        var lblEstado = '#' + imgID.replace('imgAnularDocumento', 'lblEstado');
        var lblnumero = '#' + imgID.replace('imgAnularDocumento', 'lblnumero');
        var lblcliente = '#' + imgID.replace('imgAnularDocumento', 'lblcliente');
        var hfCodTipoDoc = '#' + imgID.replace('imgAnularDocumento', 'hfCodTipoDoc');  

        if ($(hfCodTipoDoc).val() == '16')
        {
            if ($(lblEstado).text()=="ANULADO") 
            {alertify.log ("LA NOTA DE VENTA SE ENCUENTRA ANULADA");
            return false;}

            if ($(lblEstado).text() == "CANCELADO") {
                alertify.log("ESTA NOTA DE VENTA SE ENCUENTRA CANCELADA; PRIMERO ELIMINE LA COBRANZA Y LUEGO ELIMINE LA NOTA DE VENTA");
                return false;
            }

            if ($(lblEstado).text() == "FACTURADO") {
                alertify.log("ESTA NOTA DE VENTA SE ENCUENTRA FACTURADA; PRIMERO ELIMINE LA FACTURA Y LUEGO ANULE LA NOTA DE VENTA");
                return false;
            }
        }
        else
        {
            if ($(lblEstado).text() == "ANULADO") {
                alertify.log("LA FACTURA SE ENCUENTRA ANULADA");
                return false;
            }

            if ($(lblEstado).text() == "CANCELADO") {
                alertify.log("ESTA FACTURA SE ENCUENTRA CANCELADA; PRIMERO ELIMINE LA COBRANZA Y LUEGO ANULE LA FACTURA");
                return false;
            }        
        }
            
        $('#hfCodTipoDocAnulacion').val($(hfCodTipoDoc).val()) ;
        $('#hfCodDocumentoVentaAnulacion').val($(lblCodigo).val()) ;
        $('#hfClienteAnulacion').val($(lblcliente).text()) ;
        $('#hfNumeroAnulacion').val($(lblnumero).text()) ;
        $('#MainContent_txtObservacionAnulacion').val('');
        $('#div_Anulacion').dialog({
               resizable: false,
               modal: true,
               title: "Anulacion de Documento de Venta",
               title_html: true,
               height: 190,
               width: 470,
               autoOpen: false
           });          
        $('#div_Anulacion').dialog('open');
}

function F_VerUltimoPrecio_Buscar(CodNeumatico, CodProducto) {
    var Contenedor = '#cphCuerpo_';
    var CodNeumaticoAlm = '';

    $('#MainContent_lbCodProducto').val(CodNeumatico);
    $('#MainContent_lbCodNeumatico').val(CodProducto);

    try {
        var objParams = {
            Filtro_CodProducto: CodProducto,
            Filtro_CodTipoOperacion: '1',
            Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
            Filtro_Top: 5
        }

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_VerUltimoPrecio_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            $('#MainContent_lbCodProducto').val(CodProducto);
            $('#MainContent_lbCodNeumatico').val(CodNeumatico);
            F_Update_Division_HTML('div_grvConsultaUltimosPrecios', result.split('~')[2]);

            if (str_resultado_operacion == "1") {
            }

//            else
//                alertify.log('no se encontraron datos');

            $('#MainContent_txtArticuloAgregar').focus();

            return false;

        });
    }
    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }

}

function F_Inicializar_Parametros() {
    P_CodMoneda_Inicial = "1";
    P_CodMoneda_LineaCredito_Inicial = "1";
    P_CantidadPlacas = "1";
    P_VALIDASTOCK = "1";
    P_VALIDASTOCK_MONTO_MINIMO = "0"; 
    P_UNIDADES_ENTEROS = "1";
        
var Parametros = F_ParametrosPagina('', CodigoMenu, CodigoInterno);
$.each(Parametros, function (index, item) {

    switch(item.Parametro) {
        case "P_CODMONEDA" :
            P_CodMoneda_Inicial = item.Valor;
            break;
        case "P_CODMONEDA_LINEACREDITO" :
            P_CodMoneda_LineaCredito_Inicial = item.Valor;
            break;
        case "P_CANTIDADPLACAS" :
            P_CantidadPlacas = item.Valor;
            break;

        case "P_VALIDASTOCK" :
            P_VALIDASTOCK = item.Valor;
            break;
        case "P_VALIDASTOCK_MONTO_MINIMO" :
            P_VALIDASTOCK_MONTO_MINIMO = item.Valor;
            break;
        case "P_UNIDADES_ENTEROS" :
            P_UNIDADES_ENTEROS = item.Valor;
            break;

    };

});


return true;
}

function F_PrecioDisplayUp()
{
  if ($('#MainContent_ddlPrecio option:selected').prev().length > 0) 
    $('#MainContent_ddlPrecio option:selected').prev().attr('selected', 'selected').trigger('change');
  else $('#MainContent_ddlPrecio option').last().attr('selected', 'selected').trigger('change');

  $("#MainContent_txtPrecioDisplay").val($("#MainContent_ddlPrecio option:selected").text());   
}

function F_PrecioDisplayDown()
{

  if ($('#MainContent_ddlPrecio option:selected').next().length > 0) 
  {
    $("#MainContent_txtPrecioDisplay").val($("#MainContent_ddlPrecio option:selected").next().text());
    $('#MainContent_ddlPrecio option:selected').val($("#MainContent_txtPrecioDisplay").val());
  }
  else {
    $("#MainContent_txtPrecioDisplay").val($("#MainContent_ddlPrecio option:selected").prev().text());
    $('#MainContent_ddlPrecio option:selected').val($("#MainContent_txtPrecioDisplay").val());    
  } 
}

function F_AgregarArticuloFromDsc(ControlID) {
    ControlID = ControlID.replace('lblProducto', 'imgAgregar');
    F_AgregarArticulo(ControlID, 1);
return true;
}

//cambio de tipo de documento
function F_CambioTransportista() {

    switch($("#MainContent_ddlTipoTransportista").val()) {
        case '1': //FACTURA
            //Bloqueo de campos
            $('#MainContent_txtNroRucTransportista').prop('disabled', false);
            $('#MainContent_txtTransportista').prop('disabled', false);
            $('#MainContent_txtDistritoTransportista').prop('disabled', false);
            $('#MainContent_txtDireccionTransportista').prop('disabled', false);
            $('#MainContent_txtPlacaTraslado').prop('disabled', false);
            $('#MainContent_txtMarcaGuia').prop('disabled', false);
            $('#MainContent_txtLicenciaGuia').prop('disabled', false);
            $('#MainContent_txtNuBultos').prop('disabled', false);
            $('#MainContent_txtPeso').prop('disabled', false);
            $('#MainContent_txtConductorDNI').prop('disabled', false);
            $('#MainContent_txtConductorRazonSocial').prop('disabled', false);
            $('#MainContent_txtNroRucTransportista').val('');
            $('#MainContent_txtTransportista').val('');
            $('#MainContent_txtDistritoTransportista').val('');
            $('#MainContent_txtDireccionTransportista').val('');
            $('#MainContent_txtPlacaTraslado').val('');
            $('#MainContent_txtMarcaGuia').val('');
            $('#MainContent_txtLicenciaGuia').val('');
            $('#MainContent_txtNuBultos').val('');
            $('#MainContent_txtPeso').val('');
            $('#MainContent_txtConductorDNI').val('');
            $('#MainContent_txtConductorRazonSocial').val('');           
            break;
        case '2': //BOLETA
            $('#MainContent_txtNroRucTransportista').prop('disabled', true);
            $('#MainContent_txtTransportista').prop('disabled', true);
            $('#MainContent_txtDistritoTransportista').prop('disabled', true);
            $('#MainContent_txtDireccionTransportista').prop('disabled', true);
            $('#MainContent_txtPlacaTraslado').prop('disabled', false);
            $('#MainContent_txtMarcaGuia').prop('disabled', false);
            $('#MainContent_txtLicenciaGuia').prop('disabled', false);
            $('#MainContent_txtNuBultos').prop('disabled', false);
            $('#MainContent_txtPeso').prop('disabled', false);
            $('#MainContent_txtConductorDNI').prop('disabled', false);
            $('#MainContent_txtConductorRazonSocial').prop('disabled', false);
//            $('#MainContent_txtDestino').val('');
            $('#MainContent_txtNroRucTransportista').val('');
            $('#MainContent_txtTransportista').val('');
            $('#MainContent_txtDistritoTransportista').val('');
            $('#MainContent_txtDireccionTransportista').val('');
            $('#MainContent_txtPlacaTraslado').val('');
            $('#MainContent_txtMarcaGuia').val('');
            $('#MainContent_txtLicenciaGuia').val('');
            $('#MainContent_txtNuBultos').val('');
            $('#MainContent_txtPeso').val('');
            $('#MainContent_txtConductorDNI').val('');
            $('#MainContent_txtConductorRazonSocial').val('');
         
            break;
        case '3': //COTIZACION (PROFORMA)
           $('#MainContent_txtNroRucTransportista').prop('disabled', true);
            $('#MainContent_txtTransportista').prop('disabled', true);
            $('#MainContent_txtDistritoTransportista').prop('disabled', true);
            $('#MainContent_txtDireccionTransportista').prop('disabled', true);
            $('#MainContent_txtPlacaTraslado').prop('disabled', false);
            $('#MainContent_txtMarcaGuia').prop('disabled', true);
            $('#MainContent_txtLicenciaGuia').prop('disabled', true);
            $('#MainContent_txtNuBultos').prop('disabled', false);
            $('#MainContent_txtPeso').prop('disabled', false);
            $('#MainContent_txtConductorDNI').prop('disabled', true);
            $('#MainContent_txtConductorRazonSocial').prop('disabled', true);
//            $('#MainContent_txtDestino').val('');
            $('#MainContent_txtNroRucTransportista').val('');
            $('#MainContent_txtTransportista').val('');
            $('#MainContent_txtDistritoTransportista').val('');
            $('#MainContent_txtDireccionTransportista').val('');
            $('#MainContent_txtPlacaTraslado').val('');
            $('#MainContent_txtMarcaGuia').val('');
            $('#MainContent_txtLicenciaGuia').val('');
            $('#MainContent_txtNuBultos').val('');
            $('#MainContent_txtPeso').val('');
            $('#MainContent_txtConductorDNI').val('');
            $('#MainContent_txtConductorRazonSocial').val('');
            break;

    }
 
   
    return false;
}

//cambio de tipo de documento
function F_CambioTransportistaEdicion() {
    switch($("#MainContent_ddlTipoTransportistaEdicion").val()) {
        case '1': //FACTURA
            //Bloqueo de campos
            $('#MainContent_txtNroRucTransportistaEdicion').prop('disabled', false);
            $('#MainContent_txtTransportistaEdicion').prop('disabled', false);
            $('#MainContent_txtDistritoTransportistaEdicion').prop('disabled', false);
            $('#MainContent_txtDireccionTransportistaEdicion').prop('disabled', false);
            $('#MainContent_txtPlacaTrasladoEdicion').prop('disabled', false);
            $('#MainContent_txtMarcaGuiaEdicion').prop('disabled', false);
            $('#MainContent_txtLicenciaGuiaEdicion').prop('disabled', false);
            $('#MainContent_txtNuBultosEdicion').prop('disabled', false);          
            $('#MainContent_txtConductorDNIEdicion').prop('disabled', false);
            $('#MainContent_txtConductorRazonSocialEdicion').prop('disabled', false);
             $('#MainContent_txtDestinoEdicion').prop('disabled', false);
            $('#MainContent_txtNroRucTransportistaEdicion').val('');
            $('#MainContent_txtTransportistaEdicion').val('');
            $('#MainContent_txtDistritoTransportistaEdicion').val('');
            $('#MainContent_txtDireccionTransportistaEdicion').val('');
            $('#MainContent_txtPlacaTrasladoEdicion').val('');
            $('#MainContent_txtMarcaGuiaEdicion').val('');
            $('#MainContent_txtLicenciaGuiaEdicion').val('');
            $('#MainContent_txtNuBultosEdicion').val('');
            $('#MainContent_txtPesoEdicion').val('');
            $('#MainContent_txtConductorDNIEdicion').val('');
            $('#MainContent_txtConductorRazonSocialEdicion').val('');           
            break;
        case '2': //BOLETA
            $('#MainContent_txtNroRucTransportistaEdicion').prop('disabled', true);
            $('#MainContent_txtTransportistaEdicion').prop('disabled', true);
            $('#MainContent_txtDistritoTransportistaEdicion').prop('disabled', true);
            $('#MainContent_txtDireccionTransportistaEdicion').prop('disabled', true);
            $('#MainContent_txtPlacaTrasladoEdicion').prop('disabled', false);
            $('#MainContent_txtMarcaGuiaEdicion').prop('disabled', false);
            $('#MainContent_txtLicenciaGuiaEdicion').prop('disabled', false);
            $('#MainContent_txtNuBultosEdicion').prop('disabled', false);
            $('#MainContent_txtDestinoEdicion').prop('disabled', false);
            $('#MainContent_txtConductorDNIEdicion').prop('disabled', false);
            $('#MainContent_txtConductorRazonSocialEdicion').prop('disabled', false);
//            $('#MainContent_txtDestino').val('');
            $('#MainContent_txtNroRucTransportistaEdicion').val('');
            $('#MainContent_txtTransportistaEdicion').val('');
            $('#MainContent_txtDistritoTransportistaEdicion').val('');
            $('#MainContent_txtDireccionTransportistaEdicion').val('');
            $('#MainContent_txtPlacaTrasladoEdicion').val('');
            $('#MainContent_txtMarcaGuiaEdicion').val('');
            $('#MainContent_txtLicenciaGuiaEdicion').val('');
            $('#MainContent_txtNuBultosEdicion').val('');
            $('#MainContent_txtPesoEdicion').val('');
            $('#MainContent_txtConductorDNIEdicion').val('');
            $('#MainContent_txtConductorRazonSocialEdicion').val('');
         
            break;
        case '3': //COTIZACION (PROFORMA)
           $('#MainContent_txtNroRucTransportistaEdicion').prop('disabled', true);
            $('#MainContent_txtTransportistaEdicion').prop('disabled', true);
            $('#MainContent_txtDistritoTransportistaEdicion').prop('disabled', true);
            $('#MainContent_txtDireccionTransportistaEdicion').prop('disabled', true);
            $('#MainContent_txtPlacaTrasladoEdicion').prop('disabled', false);
            $('#MainContent_txtMarcaGuiaEdicion').prop('disabled', true);
            $('#MainContent_txtLicenciaGuiaEdicion').prop('disabled', true);
            $('#MainContent_txtNuBultosEdicion').prop('disabled', false);
            $('#MainContent_txtDestinoEdicion').prop('disabled', false);
           // $('#MainContent_txtPesoEdicion').prop('disabled', false);
            $('#MainContent_txtConductorDNIEdicion').prop('disabled', true);
            $('#MainContent_txtConductorRazonSocialEdicion').prop('disabled', true);
//            $('#MainContent_txtDestino').val('');
            $('#MainContent_txtNroRucTransportistaEdicion').val('');
            $('#MainContent_txtTransportistaEdicion').val('');
            $('#MainContent_txtDistritoTransportistaEdicion').val('');
            $('#MainContent_txtDireccionTransportistaEdicion').val('');
            $('#MainContent_txtPlacaTrasladoEdicion').val('');
            $('#MainContent_txtMarcaGuiaEdicion').val('');
            $('#MainContent_txtLicenciaGuiaEdicion').val('');
            $('#MainContent_txtNuBultosEdicion').val('');
            $('#MainContent_txtPesoEdicion').val('');
            $('#MainContent_txtConductorDNIEdicion').val('');
            $('#MainContent_txtConductorRazonSocialEdicion').val('');
            break;

    }
 
   
    return false;
}

function F_ImprimirFacturaGrilla(Fila,Tipo) {
        var imgID = Fila.id;
        var lblCodigo = '';
        var lblEstado = '';
        var hfCodTipoDoc = '';
        var CodMenu = 201;

        if (Tipo == 'TK')
        {
           lblCodigo = '#' + imgID.replace('imgTCK', 'lblCodigo');     
           lblEstado = '#' + imgID.replace('imgTCK', 'lblEstado');       
           hfCodTipoDoc = '#' + imgID.replace('imgTCK', 'hfCodTipoDoc');   
        }
        else
        {
           lblCodigo = '#' + imgID.replace('imgPdf', 'lblCodigo');     
           lblEstado = '#' + imgID.replace('imgPdf', 'lblEstado');    
           hfCodTipoDoc = '#' + imgID.replace('imgPdf', 'hfCodTipoDoc');              
        }

        if ($(lblEstado).text()=='ANULADO')
        {
            alertify.log("La factura se encuentra anulada");
            return false;
        }

        if ($(hfCodTipoDoc).val()==15)
            CodMenu = 202;  
            
        F_ImprimirFactura($(lblCodigo).val(),CodMenu,Tipo);
      
        return false;
}

function F_ImprimirFactura(Codigo,CodMenu,Tipo) {    
        var rptURL = '';
        var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
        var TipoArchivo = 'application/pdf';
        var NombreArchivo = '';
        var NombreTabla = 'Electronica';

        rptURL = '../Reportes/Web_Pagina_Crystal_Nuevo.aspx';
        rptURL = rptURL + '?';
        rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
        rptURL = rptURL + 'Codigo=' + Codigo  + '&';
        rptURL = rptURL + 'TipoImp=' + Tipo  + '&';
        rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
        rptURL = rptURL + 'NombreArchivo=' + NombreArchivo + '&';
        rptURL = rptURL + 'NombreTabla=' + NombreTabla + '&';

        window.open(rptURL, "PopUpRpt", Params);
        return false;
}

function F_Inicializar_CajaTexto()
{
    $("#MainContent_txtNumeroConsulta").ForceNumericOnly();
    
    $('#MainContent_txtCodCotizacion').css('background', '#FFFFE0');

    $('#MainContent_txtCliente').css('background', '#FFFFE0');

    $('#MainContent_txtDistrito').css('background', '#FFFFE0');

    $('#MainContent_txtNroRuc').css('background', '#FFFFE0');

    $('#MainContent_txtDireccion').css('background', '#FFFFE0');
    
    $('#MainContent_txtVencimiento').css('background', '#FFFFE0');

    $('#MainContent_txtEmision').css('background', '#FFFFE0');

    $('#MainContent_txtPlaca').css('background', '#FFFFE0');

    $('#MainContent_txtPlaca2').css('background', '#FFFFE0');

    $('#MainContent_txtPlaca3').css('background', '#FFFFE0');

    $('#MainContent_txtPlaca4').css('background', '#FFFFE0');

    $('#MainContent_txtPlaca5').css('background', '#FFFFE0');

    $('#MainContent_txtPlaca6').css('background', '#FFFFE0');

    $('#MainContent_txtPlaca7').css('background', '#FFFFE0');

    $('#MainContent_txtPlaca8').css('background', '#FFFFE0');

    $('#MainContent_txtResponsable1').css('background', '#FFFFE0');

    $('#MainContent_txtResponsableDNI1').css('background', '#FFFFE0');

    $('#MainContent_txtResponsable1Edicion').css('background', '#FFFFE0');

    $('#MainContent_txtResponsableDNI1Edicion').css('background', '#FFFFE0');

    $('#MainContent_txtResponsable2Edicion').css('background', '#FFFFE0');

    $('#MainContent_txtResponsableDNI2Edicion').css('background', '#FFFFE0');

    $('#MainContent_txtCodCotizacion').css('background', '#FFFFE0');

    $('#MainContent_txtConductorDNI').css('background', '#FFFFE0');   

    $('#MainContent_txtConductorRazonSocial').css('background', '#FFFFE0');
    
    $('#MainContent_txtFacturaCDR').css('background', '#FFFFE0');

    $('#MainContent_txtArchivoCDR').css('background', '#FFFFE0');

    $('#MainContent_txtObservacion').css('background', '#FFFFE0');
    
    $('#MainContent_txtObservacionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtPlacaTraslado').css('background', '#FFFFE0');

    $('#MainContent_txtClienteConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroGuia').css('background', '#FFFFE0');

    $("#MainContent_txtObservacionAnulacion").css('background', '#FFFFE0');

    $('#MainContent_ddlEstadoConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtFechaTraslado').css('background', '#FFFFE0');
    
    $('#MainContent_txtNroRucTransportista').css('background', '#FFFFE0');

    $('#MainContent_txtDestino').css('background', '#FFFFE0');

    $('#MainContent_txtDescuento').css('background', '#FFFFE0');

    $('#MainContent_txtSubTotal').css('background', '#FFFFE0');

    $('#MainContent_txtIgv').css('background', '#FFFFE0');

    $('#MainContent_txtTotal').css('background', '#FFFFE0');

    $('#MainContent_txtTotal2').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtNumero').css('background', '#FFFFE0');

    $('#MainContent_txtDesde').css('background', '#FFFFE0');

    $('#MainContent_txtHasta').css('background', '#FFFFE0');

    $('#MainContent_txtArticulo').css('background', '#FFFFE0');

    $('#MainContent_txtUltimoPrecio').css('background', '#FFFFE0');

    $('#MainContent_txtMonedaPrecio').css('background', '#FFFFE0');

    $('#MainContent_txtFechaPrecio').css('background', '#FFFFE0');

    $('#MainContent_txtCantidadPrecio').css('background', '#FFFFE0');

    $('#MainContent_ddlTipoDoc').css('background', '#FFFFE0');

    $('#MainContent_ddlTipoDoc2').css('background', '#FFFFE0');

    $('#MainContent_txtApePaterno').css('background', '#FFFFE0');
    
    $('#MainContent_txtApeMaterno').css('background', '#FFFFE0');

    $('#MainContent_txtNombres').css('background', '#FFFFE0');

    $('#MainContent_txtAtencion').css('background', '#FFFFE0');

    $('#MainContent_txtReferencia').css('background', '#FFFFE0');

    $('#MainContent_ddlTipoImpresion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcion2').css('background', '#FFFFE0');   

    $('#MainContent_txtTransportista').css('background', '#FFFFE0');   
    
    $('#MainContent_txtDireccionTransportista').css('background', '#FFFFE0');   

    $('#MainContent_txtMarcaGuia').css('background', '#FFFFE0');   

    $('#MainContent_txtLicenciaGuia').css('background', '#FFFFE0');   

    $('#MainContent_txtNuBultos').css('background', '#FFFFE0');   

    $('#MainContent_txtPeso').css('background', '#FFFFE0');   

    $('#MainContent_txtNumeroNotaVenta').css('background', '#FFFFE0');   

    $('#MainContent_txtDesdeNV').css('background', '#FFFFE0');   
    
    $('#MainContent_txtHastaNV').css('background', '#FFFFE0');   

    $('#MainContent_txtCotizacion').css('background', '#FFFFE0');   

    $('#MainContent_txtDesdeCT').css('background', '#FFFFE0');   
    
    $('#MainContent_txtHastaCT').css('background', '#FFFFE0');
    
    $('#MainContent_txtModelo').css('background', '#FFFFE0');
    
    $('#MainContent_txtMotor').css('background', '#FFFFE0');
    
    $('#MainContent_txtPosicion').css('background', '#FFFFE0');
    
    $('#MainContent_txtAño').css('background', '#FFFFE0');
    
    $('#MainContent_txtMedida').css('background', '#FFFFE0');   

    $('#MainContent_txtClienteNV').css('background', '#FFFFE0');   

    $('#MainContent_txtClienteCT').css('background', '#FFFFE0');   

    $('#MainContent_txtPlacaNV').css('background', '#FFFFE0');   

    $('#MainContent_ddlResponsableNP').css('background', '#FFFFE0');  
    
    $('#MainContent_txtResponsable2').css('background', '#FFFFE0');        

    $('#MainContent_txtResponsableDNI2').css('background', '#FFFFE0');        

    $('#MainContent_txtPlacaConsulta').css('background', '#FFFFE0');   
        
    $('#MainContent_txtNroFacturaEditar').css('background', '#FFFFE0');        

    $('#MainContent_txtClienteEditar').css('background', '#FFFFE0');        

    $('#MainContent_txtEmisionEdicion').css('background', '#FFFFE0');        

    $('#MainContent_ddlFormaPagoEdicion').css('background', '#FFFFE0');        

    $('#MainContent_txtVencimientoEdicion').css('background', '#FFFFE0');        

    $('#MainContent_txtPlaca1Edicion').css('background', '#FFFFE0');        

    $('#MainContent_txtPlaca2Edicion').css('background', '#FFFFE0');        

    $('#MainContent_txtPlaca3Edicion').css('background', '#FFFFE0');        

    $('#MainContent_txtPlaca4Edicion').css('background', '#FFFFE0');   

    $('#MainContent_txtPlaca5Edicion').css('background', '#FFFFE0');

    $('#MainContent_txtPlaca6Edicion').css('background', '#FFFFE0');

    $('#MainContent_txtPlaca7Edicion').css('background', '#FFFFE0');

    $('#MainContent_txtPlaca8Edicion').css('background', '#FFFFE0');     

    $('#MainContent_txtResponsableReenvio').css('background', '#FFFFE0');        

    $('#MainContent_txtFacturaReenvio').css('background', '#FFFFE0');        

    $('#MainContent_txtCorreoResponsableReenvio1').css('background', '#FFFFE0');        

    $('#MainContent_txtCorreoResponsableReenvio2').css('background', '#FFFFE0');        

    $('#MainContent_txtCorreoResponsableReenvio3').css('background', '#FFFFE0');        

    $('#MainContent_txtCorreoResponsableReenvio4').css('background', '#FFFFE0');        
    
    $('#MainContent_txtCorreoResponsableReenvio5').css('background', '#FFFFE0');        

    $('#MainContent_txtCorreoResponsableReenvio6').css('background', '#FFFFE0');        

    $('#MainContent_txtCorreo').css('background', '#FFFFE0');        

    $('#MainContent_txtKM').css('background', '#FFFFE0');    

    $('#MainContent_txtKMEdicion').css('background', '#FFFFE0');    

    $('#MainContent_txtEdicionMail_Cliente').css('background', '#FFFFE0');    
    
    $('#MainContent_txtEdicionMail_Distrito').css('background', '#FFFFE0');    
    
    $('#MainContent_txtEdicionMail_Direccion').css('background', '#FFFFE0');    

    $('#MainContent_txtEdicionMail_Email1').css('background', '#FFFFE0');    
    
    $('#MainContent_txtEdicionMail_Email2').css('background', '#FFFFE0');    
    
    $('#MainContent_txtEdicionMail_Email3').css('background', '#FFFFE0');    
    
    $('#MainContent_txtEdicionMail_Email4').css('background', '#FFFFE0');    
    
    $('#MainContent_txtEdicionMail_Email5').css('background', '#FFFFE0');    
    
    $('#MainContent_txtEdicionMail_Email6').css('background', '#FFFFE0');    
    
   $('#MainContent_ddlSerieGuiaEdicion').css('background', '#FFFFE0');
   
   $('#MainContent_txtRecepcion').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroGuiaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtFechaTrasladoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDestinoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtTransportistaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDireccionTransportistaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtPlacaTrasladoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtMarcaGuiaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtLicenciaGuiaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtNuBultosEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtPesoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtNroOCEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtNroOperacionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtNroOC').css('background', '#FFFFE0');

    $('#MainContent_txtNroOperacion').css('background', '#FFFFE0');

    $('#MainContent_txtDocumentoDisplayRC').css('background', '#FFFFE0');

    $('#MainContent_txtClienteDisplayRC').css('background', '#FFFFE0');

    $('#MainContent_txtRequerimiento').css('background', '#FFFFE0');

    $('#MainContent_txtRequerimientoEdicion').css('background', '#FFFFE0');
    
    $('#MainContent_txtCodigoProductoAgregar').css('background', '#FFFFE0');

    $('#MainContent_txtStockAgregar').css('background', '#FFFFE0');

    $('#MainContent_txtUMAgregar').css('background', '#FFFFE0');

    $('#MainContent_txtArticuloAgregar').css('background', '#FFFFE0');

    $('#MainContent_txtCantidad').css('background', '#FFFFE0');

    $('#MainContent_txtDsct').css('background', '#FFFFE0');

    $('#MainContent_txtProductoConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtDistritoTransportista').css('background', '#FFFFE0');

    $('#MainContent_ddldireccionNueva').css('background', '#FFFFE0');
    $('#MainContent_ddldireccionNuevaDestino').css('background', '#FFFFE0');
    $('#MainContent_ddldireccionNuevaTransportista').css('background', '#FFFFE0');
    $('#MainContent_txtObservacionGuia').css('background', '#FFFFE0');
}


function F_CAMBIOGENERAL() {
    
    try {
      
        var Contenedor = '#MainContent_';
        var tasaigv = 1;
        var FlagIgv = 0;
        var chkNotaPedido = 0;
        var chkServicio = 0;

         if ($('#MainContent_chkConIgvMaestro').is(':checked')) {
            tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
            FlagIgv = 1;
        }   
         
        if ($('#lblCantidadRegistro').text() ==0) {
           F_CambioSerie_TipoDoc();
           return false
        }    

        var objParams = {
            Filtro_CodTipoDoc: Codtipodoc,
            Filtro_CodigoTemporal: $('#hfCodigoTemporal').val() ,
             Filtro_Igv: $(Contenedor + 'txtIgv').val(),
             Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
             Filtro_FlagIgv: FlagIgv,
             Filtro_TasaIgv: tasaigv,
             Filtro_TasaIgvDscto: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
            Filtro_NotaPedido: chkNotaPedido,
             Filtro_CodCliente: $('#hfCodCtaCte').val()  
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        
        F_CambioGeneral_NET(arg, function (result) {
        
            MostrarEspera(false);

            var str_resultado_operacion = result.split('~')[0];
            var str_mensaje_operacion = result.split('~')[2];

            if (str_mensaje_operacion == 'Los Producto(s) se han agregado con exito')  {
                $('#hfCodigoTemporal').val(result.split('~')[3]);
                $('#MainContent_txtAcuentaNV').val(parseFloat(result.split('~')[8]).toFixed(2));
                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[4]);
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblimporte"));
                $('.ccsestilo').css('background', '#FFFFE0');
                F_LimpiarGrillaConsulta();
                if (result.split('~')[2] == 'Los Producto(s) se han agregado con exito')
                    alertify.log('Los Producto(s) se han agregado con exito');
                $('#MainContent_chkDescripcion').focus();
                F_MostrarTotales();
                $('#hfCodProductoAgregar').val('0');
                $('#hfCostoAgregar').val('0');
                $('#hfCodUmAgregar').val('0');
                $('#MainContent_txtCodigoProductoAgregar').val('');
                $('#MainContent_txtStockAgregar').val('');
                $('#MainContent_txtUMAgregar').val('');
                $('#MainContent_txtPrecioDisplay').val('0.00');
                $('#MainContent_ddlPrecio').empty();
                $('#MainContent_txtArticuloAgregar').val('');
                $('#MainContent_txtCantidad').val('1');
                $('#MainContent_txtCantidadMayorista').val('0');
                $('#MainContent_txtPrecioMayorista').val('0.00');
                $("#hfMenorPrecioAgregar").val(0);
                $('#MainContent_txtExclusivo').val('');
//                 //Valores por Defecto
//            $('#MainContent_txtNroRuc').val('11111111');
//            $('#hfNroRuc').val('11111111');   
//                F_BUSCARDNIONBLURENTER(MainContent_txtNroRuc);
                 F_CambioSerie_TipoDoc();
                F_TablaDown(); 
                F_ValidarPrecioMinimoRojo();
                return false;
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

function F_VistaPreliminar(Fila,CodMenu) {
    var imgID = Fila.id;
    var Codigo = '';

    if (CodMenu == 100){

        if(($('#' + imgID.replace('imgPdfGuia', 'hfCodTraslado')).val())==0){
       alertify.log("No tiene guia adjunta");
        return false;
        }
        Codigo = $('#' + imgID.replace('imgPdfGuia', 'hfCodTraslado')).val() ;
   } else{
        Codigo = $('#' + imgID.replace('imgPdfFactura', 'lblCodigo')).val() ;
    }   
    F_ImprimirFactura (Codigo,CodMenu);
    
    return false;
}

function F_ImprimirFactura(Codigo,CodMenu) {    
        var rptURL = '';
        var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
        var TipoArchivo = 'application/pdf';
        var NombreArchivo = '';
        var NombreTabla = 'Electronica';

        rptURL = '../Reportes/Web_Pagina_Crystal_Nuevo.aspx';
        rptURL = rptURL + '?';
        rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
        rptURL = rptURL + 'Codigo=' + Codigo  + '&';
        rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
        rptURL = rptURL + 'NombreArchivo=' + NombreArchivo + '&';
        rptURL = rptURL + 'NombreTabla=' + NombreTabla + '&';

        window.open(rptURL, "PopUpRpt", Params);
        return false;
}

function F_ImprimirFacturaGrilla(Fila,CodMenu) {
        var imgID = Fila.id;
        var Codigo = '';
        var Estado = '';    

        if (CodMenu == 200)
        {

         if(($('#' + imgID.replace('imgImprimirGuia', 'hfCodTraslado')).val())==0){
       alertify.log("No tiene guia adjunta");
        return false;
        }
            Codigo = $('#' + imgID.replace('imgImprimirGuia', 'hfCodTraslado')).val() ; 
            Estado = $('#' + imgID.replace('imgImprimirGuia', 'lblEstado')).val() ;    
        }
        else
        {
            Codigo = $('#' + imgID.replace('imgImprimirFactura', 'lblCodigo')).val() ; 
            Estado = $('#' + imgID.replace('imgImprimirFactura', 'lblEstado')).val() ;       
        }       
     
        if (Estado=='ANULADO')
        {
            alertify.log("La factura se encuentra anulada");
            return false;
        }
            
        F_ImprimirFactura(Codigo,CodMenu);
      
        return false;
}


function F_FacturaGuia() {
    var Contenedor = '#MainContent_';
    var Mensaje = "Ingrese los sgtes datos:";

    if ($(Contenedor + 'txtGuia').val() == "")
        Mensaje = Mensaje + "<p></p>" + "Numero Guia";

    if (Mensaje != "Ingrese los sgtes datos:") {
        alertify.log(Mensaje);
        return false;
    }

    var tasaigv = parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);
    
    try {
        var objParams = {
            Filtro_NumeroDoc: $(Contenedor + 'txtGuia').val(),
            Filtro_FechaEmision: $(Contenedor + 'txtEmision').val(),
            Filtro_Vencimiento: $(Contenedor + 'txtEmision').val(),
            Filtro_CodTipoDoc:10,
            Filtro_CodTipoOperacionNC: $(Contenedor + 'ddlTipoOperaciones').val(),
            Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
            Filtro_TasaIgv: tasaigv,
            Filtro_NotaPedido: 0,
            Filtro_CodEmpresa: $('#MainContent_ddlEmpresa').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_FacturacionGuia_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_mensaje_operacion == "") {
                $('#hfCodigoTemporal').val(result.split('~')[26]);
                $('#hfCodCtaCte').val(result.split('~')[20]);
                $('#hfCodTransportista').val(result.split('~')[6]);
                $('#hfCodConductor').val(result.split('~')[12]);
             
                
                $('#MainContent_txtNroRuc').val(result.split('~')[21]);
                $('#MainContent_txtCliente').val(result.split('~')[22]);

                
                    $('#MainContent_chkGuia').prop('checked', true);
                $('#MainContent_ddlSerieGuia option:selected').text(result.split('~')[3]);
                $('#MainContent_txtNumeroGuia').val(result.split('~')[4]);
                $('#MainContent_txtNroRucTransportista').val(result.split('~')[7]);
                $('#MainContent_ddlTipoTransportista').val(result.split('~')[5]);
                $('#MainContent_txtTransportista').val(result.split('~')[8]);
                $('#MainContent_txtNuBultos').val(result.split('~')[10]);
                $('#MainContent_txtPeso').val(result.split('~')[11]);
                $('#MainContent_txtNuBultos').val(result.split('~')[10]);
                $('#MainContent_txtConductorDNI').val(result.split('~')[13]);
                $('#MainContent_txtConductorRazonSocial').val(result.split('~')[14]);
                $('#MainContent_txtObservacionGuia').val(result.split('~')[15]);
                $('#MainContent_txtPlacaTraslado').val(result.split('~')[16]);
                $('#MainContent_txtMarcaGuia').val(result.split('~')[17]);
                $('#MainContent_txtLicenciaGuia').val(result.split('~')[18]);

                F_Update_Division_HTML('div_grvDetalleArticulo', result.split('~')[27]);
                $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", "lblImporte"));

                //BLOQUEO
                $('#MainContent_txtNroRuc').prop("disabled", true);
                $('#MainContent_txtCliente').prop("disabled", true);
                $('#MainContent_chkGuia').prop("disabled", true);
                $('#MainContent_ddlSerieGuia').prop("disabled", true);
                $('#MainContent_txtNumeroGuia').prop("disabled", true);
                $('#MainContent_txtNroRucTransportista').prop("disabled", true);
                $('#MainContent_ddlTipoTransportista').prop("disabled", true);
                $('#MainContent_txtTransportista').prop("disabled", true);
                $('#MainContent_txtNuBultos').prop("disabled", true);
                $('#MainContent_txtPeso').prop("disabled", true);
                $('#MainContent_txtNuBultos').prop("disabled", true);
                $('#MainContent_txtConductorDNI').prop("disabled", true);
                $('#MainContent_txtConductorRazonSocial').prop("disabled", true);
                $('#MainContent_txtObservacionGuia').prop("disabled", true);
                $('#MainContent_txtPlacaTraslado').prop("disabled", true);
                $('#MainContent_txtMarcaGuia').prop("disabled", true);
                $('#MainContent_txtLicenciaGuia').prop("disabled", true);

                        //clkeinte

                    if ($('#hfCodCtaCte').val()>0)
             { F_GuardarDireccion($('#MainContent_txtNroRuc').val(),'#hfCodigoTemporal',$('#hfCodCtaCte').val()
                ,'#MainContent_txtCliente',0,result.split('~')[25],result.split('~')[24],'#MainContent_ddldireccionNueva','#MainContent_ddldireccionNuevaDestino',Codtipodoc);
                
             }     else
             {
             F_GuardarDireccion($('#MainContent_txtNroRuc').val(),'#hfCodigoTemporal',$('#hfCodCtaCte').val(),
 '#MainContent_txtCliente',0,result.split('~')[25],result.split('~')[24],'#MainContent_ddldireccionNueva','#MainContent_ddldireccionNuevaDestino',Codtipodoc);
             }    
             //transportista
            if($('#hfCodTransportista').val()!=0 && $('#hfCodConductor').val() ==0)
            {
             F_GuardarDireccion($('#MainContent_txtNroRucTransportista').val(),'#hfCodigoTemporal',$('#hfCodCtaCteTransportista').val()
            ,'#MainContent_txtTransportista',1,result.split('~')[9],result.split('~')[24],'#MainContent_ddldireccionNuevaTransportista','',1);
            }
             
                $('.ccsestilo').css('background', '#FFFFE0');
                $('#div_GuiaConsignacion').dialog('close');

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


function F_BUSCARDNIONBLURENTER(RUC)
{
          if ($(RUC).val()=='')
          return false;

          //CLIENTE VARIOS
          if ($(RUC).val() == '1' & $('#MainContent_ddlTipoDoc').val() != '1')
          {
              $('#MainContent_txtNroRuc').val('11111111');
              $('#hfNroRuc').val($('#MainContent_txtNroRuc').val());
          }
          else if ($(RUC).val() == '1' & $('#MainContent_ddlTipoDoc').val() == '1')
          {
              $('#MainContent_txtNroRuc').val('');
              $('#hfNroRuc').val($('#MainContent_txtNroRuc').val());
          }

         if ($(RUC).val()=='')
         return false;

         var VALORRUC=$(RUC).val()
         var CADENA=F_BuscarDatosPorRucDniENTERONBLUR(VALORRUC,1); //FUNCION Q BUSCA DATOS EN LA BASE DE DATOS DE CLIENTE  DEBE ESTARR EN UTLITARIOS DEBE 2 CODCTACTE RAZONSOCIAL
         var CODCTACTE = 0;
         var RAZONSOCIAL = '';
         if (CADENA.length > 0)
         {
             CODCTACTE=CADENA[0].split(',')[0];
             RAZONSOCIAL=CADENA[0].split(',')[1];

             $('#hfCodCtaCte').val(CODCTACTE);
             $('#MainContent_txtNroRuc').val(VALORRUC);
             $('#MainContent_txtCliente').val(RAZONSOCIAL)
             $('#hfNroRuc').val($('#MainContent_txtNroRuc').val());

             if (CODCTACTE>0)
             { F_GuardarDireccion($('#MainContent_txtNroRuc').val(),'#hfCodigoTemporal',$('#hfCodCtaCte').val()
                ,'#MainContent_txtCliente',0,Ubigeo,Direccion,'#MainContent_ddldireccionNueva','#MainContent_ddldireccionNuevaDestino',Codtipodoc);
                
                return false;
             }        
         }

         if (CODCTACTE==0 & VALORRUC!='')
         { 
            F_API_RUC_Buscar_Global();
 
            //api sunat 
            $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url:  $('#hfurlapisunat').val() + $('#MainContent_txtNroRuc').val() + $('#hftokenapisunat').val(),
            dataType: "json",
            async: true,
            success: function (dbObject) {
                MostrarEspera(true);
                data = dbObject.d;    
                  $('#MainContent_txtCliente').val(dbObject.razonSocial); //razon social
                     ubigeo=dbObject.ubigeo;
                      if (ubigeo==null)
                      {
                         var direccion = '';
                    var distrito = '';
                     }
                     else
                     {
                    var distrito = dbObject.departamento + ' ' + dbObject.provincia + ' ' + dbObject.distrito;
                     var direccion = dbObject.direccion;
                  Direccion = direccion.replace(distrito, "");

                  F_GuardarDireccion($('#MainContent_txtNroRuc').val(),'#hfCodigoTemporal',$('#hfCodCtaCte').val(),
 '#MainContent_txtCliente',0,ubigeo,Direccion,'#MainContent_ddldireccionNueva','#MainContent_ddldireccionNuevaDestino',Codtipodoc);
                     }
                    
                  MostrarEspera(false);
            },
            error: function (response) {
                toastr.warning(response.responseText);
            },
            failure: function (response) {
                toastr.warning(response.responseText);
            }
        });
         }

      
    return false;
}

function F_Limpiar_Controles_Guia()
{
 $('#MainContent_txtNumeroGuia').val('');
            $('#MainContent_txtNroRucTransportista').val('');
            $('#MainContent_txtTransportista').val('');
            $('#MainContent_txtDistritoTransportista').val('');
            $('#MainContent_txtDireccionTransportista').val('');
            $('#MainContent_txtPlacaTraslado').val('');
            $('#MainContent_txtMarcaGuia').val('');
            $('#MainContent_txtLicenciaGuia').val('');
            $('#MainContent_txtNuBultos').val('0');
            $('#MainContent_txtObservacionGuia').val('');
            $('#MainContent_txtPeso').val('0.00');
            $('#MainContent_txtConductorDNI').val('');
            $('#MainContent_txtConductorRazonSocial').val('');    
            $('#MainContent_txtNroRucTransportista').prop("disabled", true);
            $('#MainContent_txtTransportista').prop("disabled", true);
            $('#MainContent_txtDistritoTransportista').prop("disabled", true);
            $('#MainContent_txtDireccionTransportista').prop("disabled", true);
            $('#MainContent_txtPlacaTraslado').prop("disabled", true);
            $('#MainContent_txtMarcaGuia').prop("disabled", true);
            $('#MainContent_txtLicenciaGuia').prop("disabled", true);
            $('#MainContent_txtObservacionGuia').prop("disabled", true);
            $('#MainContent_txtNuBultos').prop("disabled", true);
            $('#MainContent_txtPeso').prop("disabled", true);
            $('#MainContent_txtConductorDNI').prop("disabled", true);
            $('#MainContent_txtConductorRazonSocial').prop("disabled", true);
            $('#MainContent_txtNumeroGuia').prop('readonly', true);
            $('#MainContent_txtDestino').prop('readonly', true);
            $('#MainContent_txtFechaTraslado').prop('readonly', true);
            $('#MainContent_ImageButton1').prop("disabled", true);  
            $('#MainContent_ImageButton2').prop("disabled", true);  
            $('#MainContent_ddldireccionNuevaTransportista').empty();
            return false;
}

function F_DireccionesTemporal(temporal,CodProvincia,CodDistrito,CodDepartamento,txtDireccion,txtDistrito,formulario,FlagTraslado) {
        var Codtemporal = '#'+temporal.id
        try {
       Ventana=formulario
        var objParams = {
            Filtro_CodTemporal: $(Codtemporal).val(),
            Filtro_FlagTraslado: FlagTraslado
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_DireccionTemporal_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

                $('#div_DireccionMultiple').dialog({
                    resizable: false,
                    modal: true,
                    title: "Direcciones",
                    title_html: true,
                    height: 500,
                    width: 910,
                    autoOpen: false
                });
                F_Update_Division_HTML('div_DireccionTemporal', result.split('~')[2]);
                $(CodProvincia).val('0');
                $(CodDistrito).val('0');
                $(CodDepartamento).val('0');
                $(txtDireccion).val('');
                $(txtDistrito).val('');
                try { $('#div_DireccionMultiple').dialog('open');}
                catch (e) { }

                return false;

            }

            else
                toastr.warning(result.split('~')[1]);

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }

return true;
}

function F_ValidarGrabarDireccion() {

    try {

        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos: <br> <p></p>';

        if ($(Cuerpo + 'txtDistritoMultiple').val() == '')
            Cadena = Cadena + '<p></p>' + 'Distrito';
        else { 
        if($('#hfDistrito').val()=="0")
            Cadena = Cadena + '<p></p>' + 'Distrito';
        }

        if (Cadena != 'Ingresar los sgtes. Datos: <br> <p></p>') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
    }
}