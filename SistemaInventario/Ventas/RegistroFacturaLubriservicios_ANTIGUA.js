var AppSession = "../Ventas/RegistroFacturaLubriservicios_ANTIGUA.aspx";
var CodigoMenu = 4000; var CodigoInterno = 2;

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

    F_FuncionesBotones();

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

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

            //$('#txtSaldoCreditoFavor').text(i.item.SaldoCreditoFavor);
            //$('#hfSaldoCreditoFavor').val(i.item.SaldoCreditoFavor.replace("S/", "").replace(" ", ""));

            //F_BuscarDireccionPorDefecto();
            F_BuscarDireccionesCliente();
            F_BuscarResponsables();
            if ($('#hfNotaPedido').val() == '5' & $('#hfCodCtaCte').val() != $('#hfCodCtaCteNP').val())
                F_EliminarTodos();
            if ($('#hfNotaPedido').val() != '0'  & ($('#MainContent_ddlTipoDoc').val() == '5' | $('#MainContent_ddlTipoDoc').val() == '15' | $('#MainContent_ddlTipoDoc').val() == '16'))
                F_EliminarTodos();
        },
        complete: function () {
            $('#MainContent_txtNroRuc').val($('#hfNroRuc').val());
            $('#MainContent_txtCliente').focus();
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



    
    $('#MainContent_txtDireccionTransportistaEdicion').autocomplete({
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

    $("#MainContent_chkGuia").click(function () {
        if ($(this).is(':checked')) {
            F_Mostrar_Correlativo(10);
            if ($('#MainContent_txtDestino').val() == '') $('#MainContent_txtDestino').val($('#MainContent_txtDistrito').val().trim() + ', ' + $('#MainContent_txtDireccion').val().trim());
            if ($('#MainContent_txtDestino').val().trim() == ',') $('#MainContent_txtDestino').val('');

            $('#div_CabeceraGuia').css("display","block");
            $('#div_CuerpoGuia').css("display","block");
        }
        else {
            $('#MainContent_txtNumeroGuia').val('');
            $('#MainContent_txtDestino').val('');
            $('#MainContent_txtNumeroGuia').prop('readonly', true);
            $('#MainContent_txtDestino').prop('readonly', true);
            $('#MainContent_txtFechaTraslado').prop('readonly', true);

            $('#div_CabeceraGuia').css("display","none");
            $('#div_CuerpoGuia').css("display","none");
        }
    });

    $("#MainContent_chkGuiaEdicion").click(function () {
        if ($(this).is(':checked')) {
            F_Mostrar_Correlativo(10, 'Edicion');
            if ($('#MainContent_txtDestinoEdicion').val() == '') $('#MainContent_txtDestinoEdicion').val($('#hfDireccionFacturaEditar').val());
                $('#MainContent_txtFechaTrasladoEdicion').val($('#MainContent_txtEmisionEdicion').val())
        }
        else {
            $('#MainContent_txtNumeroGuiaEdicion').val('');
            $('#MainContent_txtDestinoEdicion').val('');

            $('#hfCodTransportista').val('0');
            $('#MainContent_txtTransportistaEdicion').val('');
            $('#hfCodDireccionTransportista').val('0');
            $('#MainContent_txtDireccionTransportistaEdicion').val('');
            $('#hfDireccionTransportista').val('');
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
               
                $('#MainContent_txtArticulo').val('');
                $('#MainContent_chkServicios').prop('checked',false);
                $('#MainContent_chkNotaPedido').prop('checked',false);

                var Moneda = 'S/ ';
                if ($('#MainContent_ddlMoneda').val() === "2")
                    Moneda = '$ ';

                $('#MainContent_txtTotal2').val(Moneda + $('#MainContent_txtTotal').val());

                $("#divConsultaArticulo").dialog({
                    resizable: false,
                    modal: true,
                    title: "Consulta de Productos",
                    title_html: true,
                    height: 550,
                    width: 1200,
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

    $('#MainContent_btnEditarFactura').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
     try 
        {
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
        if ($('#MainContent_ddlTipoDoc').val() == '16' | $('#MainContent_ddlTipoDoc').val() == '15' | $('#MainContent_ddlTipoDoc').val() == '2')
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

//    $('#MainContent_txtNumeroConsulta').blur(function () {
//        if ($('#MainContent_txtNumeroConsulta').val()=='')
//        return false;

//        var id = '0000000' + $('#MainContent_txtNumeroConsulta').val();
//        $('#MainContent_txtNumeroConsulta').val(id.substr(id.length - 7));
//        return false;
//    });

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

    //$("#MainContent_txtNroRuc").ForceNumericOnly();

    $("#MainContent_txtNumeroConsulta").ForceNumericOnly();

    $("#MainContent_txtCodCotizacion").ForceNumericOnly();

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

    $('#MainContent_txtPlacaTraslado').css('background', '#FFFFE0');

    $('#MainContent_txtClienteConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroGuia').css('background', '#FFFFE0');

    $('#MainContent_txtFechaTraslado').css('background', '#FFFFE0');

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

    $('#MainContent_txtFamilia').css('background', '#FFFFE0');

    $('#MainContent_txtCodigo').css('background', '#FFFFE0');


    F_Derecha();
});



function F_FuncionesBotones() {
    var k = new Kibo(); 
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
//        if (control.attr('id') == 'MainContent_txtPrecioDisplay')
//        {
//            F_PrecioDisplayUp();
//            return true;
//        }

        if (control.attr('id') == 'MainContent_txtDireccion')
        {
            F_DireccionDisplayUp();
            return true;
        }

        return false;
    });
    //ENZO
    k.down("down", function () {
        var control = $(':focus');
//        if (control.attr('id') == 'MainContent_txtPrecioDisplay')
//        {
//            F_PrecioDisplayDown();
//            return true;
//        }

        if (control.attr('id') == 'MainContent_txtDireccion')
        {
            F_DireccionDisplayDown();
            return true;
        }

//        F_TablaDown();
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
    $('#trResponsableNP').css('display', 'none');
    $('#div_trResponsableNP').css('display', 'none');
    //Solo para Nota de Pedido
    if ($('#MainContent_ddlTipoDoc').val() != '16')
    {
        $('#trResponsableNP').css('display', 'none');
        $('#div_trResponsableNP').css('display', 'none');
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

                        F_CambioSerie_TipoDoc();

                        F_LlenarCorreosResponsable();
                    }
                    else {

                        alertify.log(str_mensaje_operacion);

                    }
                    $('#trResponsableNP').css('display', 'block');
                    $('#div_trResponsableNP').css('display', 'block');


                }
            );

    } catch (mierror) {
    MostrarEspera(false);
        alertify.log("Error detectado: " + mierror);

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

$(document).on("change", "select[id $= 'MainContent_ddlTipoDoc2']",function () {
     F_CambioTipo2();
} );

$(document).on("change", "select[id $= 'MainContent_ddlDireccion']",function () {
     $('#MainContent_txtDireccion').val($('#MainContent_ddlDireccion option:selected').text());
     $('#hfCodDireccion').val($('#MainContent_ddlDireccion option:selected').val());
} );

//cambio de tipo de documento
function F_CambioTipoDoc() {
     
     $("#MainContent_ddlTipoDoc2").val($("#MainContent_ddlTipoDoc").val());
     $('#trResponsableNP').css('display','none');
     $('#div_trResponsableNP').css('display','none');

    switch($("#MainContent_ddlTipoDoc").val()) {
        case '1': //FACTURA
            //Bloqueo de campos
            $('#MainContent_txtCliente').prop('disabled', false);
            $('#MainContent_txtApePaterno').prop('disabled', true);
            $('#MainContent_txtApeMaterno').prop('disabled', true);
            $('#MainContent_txtNombres').prop('disabled', true);
            $('#MainContent_txtAtencion').prop('disabled', true);
            $('#MainContent_txtReferencia').prop('disabled', true);
            
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

            $('#MainContent_chkImpresion').prop('checked', true);
            $('#MainContent_chkImpresionTicket').prop('checked', false);
            
            break;
        case '2': //BOLETA
            //bloqueo de campos
            $('#MainContent_txtCliente').prop('disabled', true);
            $('#MainContent_txtApePaterno').prop('disabled', false);
            $('#MainContent_txtApeMaterno').prop('disabled', false);
            $('#MainContent_txtNombres').prop('disabled', false);
            $('#MainContent_txtAtencion').prop('disabled', true);
            $('#MainContent_txtReferencia').prop('disabled', true);

            //Tipo de CtaCte a filtrar
            $('#hfCodTipoCliente').val('1')

            if ($('#MainContent_txtNroRuc').val().length != 8)
            {
                F_BuscarDatosPorRucDni('11111111');
                F_BuscarDistrito();
            }

     
            $('#MainContent_ddlTipoImpresion').val('IMP');


            $('#MainContent_txtAtencion').focus();

                   $('#MainContent_chkImpresion').prop('checked', true);
            $('#MainContent_chkImpresionTicket').prop('checked', false);
            
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

            if ($('#MainContent_txtNroRuc').val() === '')
            F_BuscarDatosPorRucDni('11111111');

            $('#MainContent_chkImpresion').prop('checked', true);
            $('#MainContent_chkImpresionTicket').prop('checked', false);

            $('#MainContent_txtAtencion').focus();
            $('#MainContent_chkImpresion').prop('checked', true);
            $('#MainContent_chkImpresionTicket').prop('checked', false);
            break;

        case '16': //NOTA DE PEDIDO
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

            $('#MainContent_chkImpresion').prop('checked', true);
            $('#MainContent_chkImpresionTicket').prop('checked', false);


            $('#MainContent_txtAtencion').focus();
            break;
    }
    F_CambioSerie_TipoDoc();
    $('#MainContent_lbTipoDocumento').text($("#MainContent_ddlTipoDoc option:selected").text());

    F_BuscarResponsables();

    //solo actualizara los email si hay un CodDireccion, sino quedan tal cual
    if ($("#MainContent_ddlTipoDoc").val() === '16') {}
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
                Filtro_CodDoc: $("#MainContent_ddlTipoDoc").val()
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
                        F_Update_Division_HTML('div_formapago', result.split('~')[4]);
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
                        $('.ccsestilo').css('background', '#FFFFE0');
                        F_CambioSerie();
                        
                        FormaPagoDefault = result.split('~')[18];
                        $('#MainContent_ddlFormaPago').val(FormaPagoDefault);

                        if ($("#MainContent_ddlTipoDoc").val() == '16')
                        {
                            $('#MainContent_ddlFormaPago').val('11');
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
                Filtro_CodDoc: $("#MainContent_ddlTipoDoc2").val()
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
                        //$('#MainContent_ddlSerieConsulta').val(61);
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
    }
}

function F_Controles_Inicializar() {

    var arg;

    try {
        var objParams =
            {
                Filtro_Fecha: $('#MainContent_txtEmision').val(),
                Filtro_CodDoc: 1
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
                        F_Update_Division_HTML('div_formapago', result.split('~')[4]);
                        F_Update_Division_HTML('div_moneda', result.split('~')[5]);
                        $('#MainContent_lblTC').text(result.split('~')[6]);
                        $('#MainContent_lblTC2').text(result.split('~')[6]);
                        $('#MainContent_lblTCParalelo').text(result.split('~')[25]);
                        $('#MainContent_lblTC2Paralelo').text(result.split('~')[25]);
                        $('#MainContent_ddlSerieConsulta').val(61);
                        F_Update_Division_HTML('div_serieconsulta', result.split('~')[9]);
                        F_Update_Division_HTML('div_igv', result.split('~')[8]);
                        $('#MainContent_ddlMoneda').val(1);
                        
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
                        $('#MainContent_ddlTipoDoc').css('background', '#FFFFE0');
                        $('#MainContent_ddlTipoDoc2').css('background', '#FFFFE0');
                            $("#div_GuiaRemision").prop("style").display="none";
                            $("#div_GuiaRemision2").prop("style").display="none";

                        P_ImpresionImpresora = result.split('~')[26];
                        P_ImpresionTicketera = result.split('~')[27];

                        if (P_ImpresionImpresora === "0")
                            $('#td_Impresora').prop("style").display="none";

                        if (P_ImpresionTicketera === "0")
                            $('#td_Ticketera').prop("style").display="none";

                        //Placas
                        if (Number(result.split('~')[15]) < 2) {
                            $("#div_Placa2").prop("style").display="none";
                            $("#div_Placa2Edicion1").prop("style").display="none";
                            $("#div_Placa2Edicion2").prop("style").display="none";
                            }

                        if (Number(result.split('~')[15]) < 3) {
                            $("#div_Placa3").prop("style").display="none";
                            $("#div_Placa3Edicion1").prop("style").display="none";
                            $("#div_Placa3Edicion2").prop("style").display="none";
                            }

                        if (Number(result.split('~')[15]) < 4) {
                            $("#div_Placa4").prop("style").display="none";
                            $("#div_Placa4Edicion1").prop("style").display="none";
                            $("#div_Placa4Edicion2").prop("style").display="none";
                            }

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
                Filtro_CodFamilia : '0'
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
                $(txtPrecio).prop('disabled', true);
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
        var hfRedondeo = txtDescuento.replace('txtDescuento', 'hfRedondeo');
        var hfFactorRedondeo = txtDescuento.replace('txtDescuento', 'hfFactorRedondeo');

        var Descuento = 0;
        var Costo = 0;

        if ($('#MainContent_ddlMoneda').val() == 1) 
            Costo = $(hfCostoProductoSoles).val();
        else 
            Costo = $(hfCostoProductoDolares).val();

        $(txtPrecio).val(F_CalcularPrecioDescuento(Costo, $(hfMargen).val(), Number($(txtDescuento).val()) / 100, $(hfRedondeo).val(), $(hfFactorRedondeo).val()));
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
        var x=0;

                $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    txtprecio_grilla = chkSi.replace('chkOK', 'txtPrecioLibre');
                    txtcantidad_grilla = chkSi.replace('chkOK', 'txtCantidad');
                    lblcodproducto_grilla = chkSi.replace('chkOK', 'lblcodproducto');
                    
                     if ($(chkSi).is(':checked')) 
                        {
                            if ($(txtcantidad_grilla).val()== '' & $(lblcodproducto_grilla).text() == ctrlsel)
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
               
                $('#MainContent_grvConsultaArticulo .chkSi :checkbox').each(function () {
                    chkSi = '#' + this.id;
                    lblcodproducto_grilla = chkSi.replace('chkOK', 'lblcodproducto');
                    lblcodunidadventa_grilla = chkSi.replace('chkOK', 'lblcodunidadventa');
                    lblcosto_grilla = chkSi.replace('chkOK', 'lblcosto');
                    txtprecio_grilla = chkSi.replace('chkOK', 'txtPrecio');
                    txtdescuento_grilla = chkSi.replace('chkOK', 'txtDescuento');
                    txtcantidad_grilla = chkSi.replace('chkOK', 'txtCantidad');
                    hfcodunidadventa_grilla = chkSi.replace('chkOK', 'hfcodunidadventa');
                    hfcosto_grilla = chkSi.replace('chkOK', 'hfcosto');

                  if ($(chkSi).is(':checked') &  $(txtcantidad_grilla).val() > 0) 
                    {
                        var objDetalle = {
                        CodArticulo: $(lblcodproducto_grilla).text(),
                        Cantidad: $(txtcantidad_grilla).val(),
                        Precio: $(txtprecio_grilla).val(),
                        Costo: $(hfcosto_grilla).val(),
                        CodUm: $(hfcodunidadventa_grilla).val(),
                        CodDetalle:0
                        };

                            $(txtcantidad_grilla).val('');
                            $(txtdescuento_grilla).val('');
                            $(txtprecio_grilla).val('');
                            $(txtcantidad_grilla).val('');
                            $(txtcantidad_grilla).prop('disabled', true);
                            $(txtdescuento_grilla).prop('disabled', true);
                            $(txtprecio_grilla).prop('disabled', true);
                            $(chkSi).prop('checked', false);

                                               
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
                    Cadena = Cadena + "\n" + "Ruc Invalido"; 
         
             if ($('#hfCodCtaCte').val()==0 && $('#hfCodDistrito').val()==0)
                    Cadena=Cadena + '<p></p>' + 'Distrito';

             if ($('#hfCodCtaCte').val()==0 && $(Cuerpo + 'txtDireccion').val()=='')
                    Cadena=Cadena + '<p></p>' + 'Direccion';
         
             if ($(Cuerpo + 'txtTotal').val()=='0.00')
                    Cadena=Cadena + '<p></p>' + 'No ha ingresado ningun producto';

//            if (!F_ValidarCorreo($(Cuerpo + 'txtCorreo').val()))
//                Cadena = Cadena + '<p></p>' + 'Correo';

            //validaciones por tipo de documento
            switch($("#MainContent_ddlTipoDoc").val()) {
                case '1': //FACTURA
                    if ($('#MainContent_txtNroRuc').val().length != 11 || $('#hfCodCtaCte').val() == '1643' || $('#hfCodCtaCte').val() == '29' || $('#MainContent_txtNroRuc').val() == '99999999' || $('#MainContent_txtNroRuc').val() == '11111111')
                    Cadena=Cadena + '<p></p>' + 'NUMERO DE RUC VALIDO';

                    if ($('#MainContent_txtDistrito').val().trim() == '' || $('#MainContent_txtDireccion').val().trim() == '')
                    Cadena=Cadena + '<p></p>' + 'DISTRITO Y DIRECCION';

                    if ($('#MainContent_txtNroRuc').val() == '55555555555' | $('#MainContent_txtNroRuc').val() == '55555555')
                    Cadena=Cadena + '<p></p>' + 'NO SE PUEDE FACTURAR UN CLIENTE SIN DOCUMENTO';

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

function F_GrabarDocumento(){
  try 
        {
        var Contenedor = '#MainContent_';
        var FlagGuia='0'; var FlagRetencion='0'; var FlagLetra='0'; var FlagIgv='1'; var NotaPedido='0';
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

        var CodResponsable = '0'; var Responsable2 = ''; var Responsable2DNI = '';
        if ($('#MainContent_ddlResponsableNP option:selected').text() != '') {
            CodResponsable = $('#MainContent_ddlResponsableNP').val();
            Responsable2 = $('#MainContent_txtResponsable2').val();
            Responsable2DNI = $('#MainContent_txtResponsableDNI2').val();
        }

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
                                        Filtro_FlagGuia:FlagGuia,
                                        Filtro_SerieGuia: $("#MainContent_ddlSerieGuia option:selected").text(),

                                        Filtro_NumeroGuia: $(Contenedor + 'txtNumeroGuia').val(),
                                        Filtro_FechaTraslado: $(Contenedor + 'txtFechaTraslado').val(),
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
                                        Filtro_Destino: $(Contenedor + 'txtDestino').val(),

                                        Filtro_Transportista: $(Contenedor + 'txtTransportista').val(),
										Filtro_Marca: $(Contenedor + 'txtMarcaGuia').val(),
										Filtro_Licencia: $(Contenedor + 'txtLicenciaGuia').val(),
										Filtro_NuBultos: $(Contenedor + 'txtNuBultos').val(),
										Filtro_Peso: $(Contenedor + 'txtPeso').val(),
                                        Filtro_CodTransportista: $('#hfCodTransportista').val(),
                                        Filtro_CodDireccionTransportista: $('#hfCodDireccionTransportista').val(),
                                        Filtro_DireccionTrans: $('#MainContent_txtDireccionTransportista').val(),

                                        Filtro_FlagIgv: FlagIgv,
                                        Filtro_Placa:$(Contenedor + 'txtPlaca').val(),
                                        Filtro_Placa2:$(Contenedor + 'txtPlaca2').val(),
                                        Filtro_Placa3:$(Contenedor + 'txtPlaca3').val(),
                                        Filtro_Placa4:$(Contenedor + 'txtPlaca4').val(),
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
                                        
                                        Filtro_CodResponsable: CodResponsable,
                                        Filtro_Responsable2: Responsable2,
                                        Filtro_Responsable2DNI: Responsable2DNI,
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
                            var ti = 'IMP'; if ($('#MainContent_chkImpresionTicket').is(':checked')) ti = 'TK';
                            F_ImpresionGrabar(result.split('~')[2], $("#MainContent_ddlTipoDoc").val(), $("#MainContent_ddlSerie option:selected").text(), ti);
                        }

                        if (Number($('#hfCodDireccion').val()) === 0) {
                            F_ActualizarCorreosCodDocumentoVenta(result.split('~')[2], $("#MainContent_ddlTipoDoc").val());
                        }

                    F_Nuevo();                    
                    
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

       $('#MainContent_txtNumeroGuia').val('');
       $('#MainContent_txtDestino').val('');
       $('#MainContent_txtTransportista').val('');
       $('#MainContent_txtDireccionTransportista').val('');
       $('#MainContent_txtPlacaTraslado').val('');
       $('#MainContent_txtMarcaGuia').val('');
       $('#MainContent_txtLicenciaGuia').val('');
       $('#MainContent_txtNuBultos').val('');
       $('#MainContent_txtPeso').val('');
       $('#hfNotaPedido').val('0');
       $('#div_CabeceraGuia').css("display","none");
       $('#div_CuerpoGuia').css("display","none");
       $('#MainContent_txtResponsable2').val('');
       $('#MainContent_txtResponsableDNI2').val('');
       $('#MainContent_txtCorreo').val('');
       $('#MainContent_txtNroOC').val('');
       $('#MainContent_txtNroOperacion').val('');
       $('#MainContent_txtRequerimientoEdicion').val('');
       $("#MainContent_txtRequerimiento").val('');
        

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
              var Placa = '';
              var C=0;
              var F=0;
              if ($('#MainContent_chkNumero').is(':checked'))
              chkNumero='1';

              if ($('#MainContent_chkRango').is(':checked'))
              chkFecha='1';

              if ($('#MainContent_chkCliente').is(':checked'))
              chkCliente='1';

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
                                        Filtro_Placa: Placa
                                        
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
                    //contador de aprobados

                   $('#MainContent_grvConsulta  .detallesart').each(function () {
                    if($('#MainContent_grvConsulta_lblEstadoSunat_'+F).text()!='APROBADO'){
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

function F_AnularRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Anular') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

 try 
        {
       var imgID = Fila.id;
    var lblCodigo = '#' + imgID.replace('imgAnularDocumento', 'lblCodigo');
    var lblEstado = '#' + imgID.replace('imgAnularDocumento', 'lblEstado');
    var lblnumero_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblnumero');
    var lblcliente_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblcliente');
    var hfcodtipodoc_grilla = '#' + imgID.replace('imgAnularDocumento', 'hfCodTipoDoc');

    if ($(lblEstado).text()=="ANULADO(A)") 
    {alertify.log("ESTE DOCUMENTO SE ENCUENTRA ANULADO");
    return false;}

    if ($(lblEstado).text() == 'FACTURADO' & ($(hfcodtipodoc_grilla).val() == '16' | $(hfcodtipodoc_grilla).val() == '15'))
        {
            alertify.log('EL DOCUMENTO SE ENCUENTRA EN ESTADO FACTURADO');
            return false;
        }

    if(!confirm("ESTA SEGURO DE ANULAR LA " +  $("#MainContent_ddlTipoDoc2 option:selected").text() + " : " + $(lblnumero_grilla).text() + "\nDEL CLIENTE : " +  $(lblcliente_grilla).text()))
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
                    $('#MainContent_txtKMEdicion').val(result.split('~')[10]);
                    $('#hfCodCtaCteEdicion').val(result.split('~')[9]);

                    $('#hfCodTraslado').val(result.split('~')[11]);
                    $('#MainContent_txtNumeroGuiaEdicion').val(result.split('~')[13]);
                    $('#MainContent_txtFechaTrasladoEdicion').val(result.split('~')[14]);

                    if (result.split('~')[14] === "")
                        $('#MainContent_txtFechaTrasladoEdicion').val(result.split('~')[2]);

                    $('#MainContent_txtDestinoEdicion').val(result.split('~')[15]);

                    $('#MainContent_txtDireccionTransportistaEdicion').val(result.split('~')[16]);
                    $('#hfDireccionTransportista').val(result.split('~')[16]);

                    $('#hfCodTransportista').val(result.split('~')[17]);
                    $('#MainContent_txtTransportistaEdicion').val(result.split('~')[18]);
                    $('#hfDireccionFacturaEditar').val(result.split('~')[18]);
                    $('#hfCodDireccionTransportista').val(result.split('~')[20]);
                    $('#MainContent_txtNroOCEdicion').val(result.split('~')[21]);
                    $('#MainContent_txtRecepcion').val(result.split('~')[22]);
                    if (result.split('~')[23] == "1")
                        $('#MainContent_chkComisionableEdicion').prop('checked',true);
                    else
                        $('#MainContent_chkComisionableEdicion').prop('checked',false);

                    $('#MainContent_txtNroOperacionEdicion').val('');
                    
                    if (Number($('#hfCodTraslado').val()) == 0)
                        $('#MainContent_chkGuiaEdicion').prop('checked', false);
                    else
                        $('#MainContent_chkGuiaEdicion').prop('checked', true);


                    $('#MainContent_txtPlacaTrasladoEdicion').val(result.split('~')[24]);
                    $('#MainContent_txtMarcaGuiaEdicion').val(result.split('~')[25]);
                    $('#MainContent_txtLicenciaGuiaEdicion').val(result.split('~')[26]);
                    $('#MainContent_txtNuBultosEdicion').val(result.split('~')[27]);
                    $('#MainContent_txtPesoEdicion').val(result.split('~')[28]);

                    $('#MainContent_txtNroOperacionEdicion').val(result.split('~')[29]);
                    $('#MainContent_txtNroOCEdicion').val(result.split('~')[30]);
                    $('#MainContent_txtRequerimientoEdicion').val(result.split('~')[31]);

                        $('#div_Editar').dialog({
                                resizable: false,
                                modal: true,
                                title: "Edicion de Documento de Venta",
                                title_html: true,
                                height: 200,
                                width: 970,
                                autoOpen: false
                        });

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
                      Filtro_KM: $('#MainContent_txtKMEdicion').val(),
                      Filtro_FlagGuia: FlagGuia,
                      Filtro_CodTraslado: $('#hfCodTraslado').val(),
                      Filtro_SerieGuia: $('#MainContent_ddlSerieGuiaEdicion option:selected').text(),
                      Filtro_NumeroGuia: $('#MainContent_txtNumeroGuiaEdicion').val(),
                      Filtro_FechaTraslado: $('#MainContent_txtFechaTrasladoEdicion').val(),
                      Filtro_Destino: $('#MainContent_txtDestinoEdicion').val(),
                      Filtro_CodTransportista: $('#hfCodTransportista').val(),
                      Filtro_CodDireccionTransportista: $('#hfCodDireccionTransportista').val(),
                      Filtro_DireccionTransportista: $('#MainContent_txtDireccionTransportistaEdicion').val(),
                      Filtro_DireccionTraslado: $('#MainContent_txtDireccionTransportistaEdicion').val(),
                      Filtro_NroOperacion:  $('#MainContent_txtNroOperacionEdicion').val(),
                      Filtro_NroOC:$('#MainContent_txtNroOCEdicion').val(),
                      Filtro_FlagComisionable:FlagComisionable,
                      Filtro_Recepcion:  $('#MainContent_txtRecepcion').val(),

                      Filtro_PlacaTraslado: $('#MainContent_txtPlacaTrasladoEdicion').val(),
                      Filtro_MarcaTraslado: $('#MainContent_txtMarcaGuiaEdicion').val(),
                      Filtro_LicenciaTraslado: $('#MainContent_txtLicenciaGuiaEdicion').val(),
                      Filtro_NroBultos: $('#MainContent_txtNuBultosEdicion').val(),
                      Filtro_PesoBultos: $('#MainContent_txtPesoEdicion').val(),
                      Filtro_Requerimiento: $('#MainContent_txtRequerimientoEdicion').val(),
                      Filtro_Observacion: 'ELIMINADO DESDE EL FORMULARIO FACTURA MULTIPLE',
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


    rptURL = '../Reportes/Crystal.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Codigo=' + $(lblCodigo).val() + '&' ;
      
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

function F_ImpresionGrilla(Fila,rplc,TipoImp,NroCopias) {

    var imgID = Fila.id;
    var lblCodigo = '#' + imgID.replace(rplc, 'lblCodigo');
    var lblNumero = '#' + imgID.replace(rplc, 'lblnumero');
    var hfTipoDoc = '#' + imgID.replace(rplc, 'hfCodTipoDoc');
    var hfEstado = '#' + imgID.replace(rplc, 'lblEstado');


        

    var CodMenu = 2001;
    var Codigo = $(lblCodigo).val();
    var NumeroDoc = $(lblNumero).text();
    var CodTipoDoc = $(hfTipoDoc).val();

    if ($(hfEstado).text() === 'ANULADO(A)' & CodTipoDoc === '15') {
        alertify.log('NO SE PUEDE IMPRIMIR');
        return false;
    }

    if (!F_ValidarTipoImpresion(NumeroDoc, TipoImp, CodTipoDoc))
    return false;

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

    F_ImpresionDefinitiva(CodMenu, Codigo, NumeroDoc, CodTipoDoc, TipoImp, NroCopias);

return true;
}

function F_ImpresionDefinitiva(CodMenu, Codigo, SerieDoc, CodTipoDoc, TipoImp, NroCopias) {
    var rptURL = '';
        var NombreTabla = 'Electronica';

         if (CodTipoDoc == '16') {
            var NombreArchivo = 'rptElectronica.rpt'; }
    else  if ((CodTipoDoc == '15'))
    {
          var NombreArchivo = 'rptElectronica.rpt';
    }
    else  {
          var NombreArchivo = 'rptElectronica.rpt';
        }
    

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
    rptURL = rptURL + 'NombreTabla=' + NombreTabla + '&';
    rptURL = rptURL + 'NombreArchivo=' + NombreArchivo + '&';

    window.open(rptURL, "PopUpRpt", Params);
return true;
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
                alertify.log('OPCION NO VALIDA PARA ESTE TIPO DE DOCUMENTO');
                return false;
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
        CodProducto = $('#' + HlkControlID.replace('hlkCodigo', 'lblcodproducto')).text();
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
                    $('#MainContent_txtCodigo').val(result.split('~')[12]);
                    $('#MainContent_txtFamilia').val(result.split('~')[11]);

                        if ((result.split('~')[10] === '0'   ) && result.split('~')[11] === "RODAJES" ) {
                    $('#tdCodigo').css('display', 'none');
                }

                    if ((result.split('~')[10] === ""   ) && result.split('~')[11] === "RODAJES" ) {
                    $('#tdCodigo').css('display', 'none');
                }

                    if ( result.split('~')[11] != "RODAJES" ) {
                    $('#tdCodigo').css('display', 'none');
                }



                        $('#div_ultimoprecio').dialog({
                                resizable: false,
                                modal: true,
                                title: "Historial Venta",
                                title_html: true,
                                height: 320,
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
            
            var tasaigv = parseFloat( $("#MainContent_ddlIgv option:selected").text()) + parseFloat(1);

            var Precio = $(txtPrecio).val();
            var Costo = 0;
            var Descuento = 0;
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

                F_Update_Division_HTML('div_grvEnvioCorreos', result.split('~')[2]); 

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
  
        try {
            var objParams = {
                Filtro_CodDocumentoVenta: $('#hfCodDocumentoReenvioMail').val(),
                Filtro_CodProforma:     $('#hfCodProformaReenvioMail').val(),
                Filtro_CodTipoDoc:      $('#hfCodtipoDocReenvioMail').val()
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
                Filtro_CodDoc: $("#MainContent_ddlTipoDoc").val()
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

                        FormaPagoDefault = result.split('~')[18];
                        $('#MainContent_ddlFormaPago').val(CodFormaPagoActual);

                        if ($("#MainContent_ddlTipoDoc").val() == '16')
                        {
                            $('#MainContent_ddlFormaPago').val('11');
                            //$('#trResponsableNP').css('display','block');
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
                $('#hfNotaPedido').val(result.split('~')[8]);
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

//function F_BuscarDatosPorRucDni(RucDni) {
//            $.ajax({
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//                url: '../Servicios/Servicios.asmx/F_BuscarDatosPorRucDni',
//                data: "{'NroRuc':'" + RucDni +"'}",
//                dataType: "json",
//                async: false,
//                success: function (dbObject) {
//                MostrarEspera(true);
//                var data = dbObject.d;
//                try {
//                                $('#hfCodCtaCte').val(data[0].split(',')[0]); 
//                                $('#hfCliente').val(data[0].split(',')[1]); //razon social
//                                $('#MainContent_txtNroRuc').val(data[0].split(',')[8]);
//                                $('#hfNroRuc').val(data[0].split(',')[8]);
//                                $('#MainContent_txtCliente').val(data[0].split(',')[1]);
//                                $('#hfCliente').val(data[0].split(',')[1]);
//                                $('#MainContent_txtDireccion').val(data[0].split(',')[2]);
//                                $('#MainContent_txtDestino').val(data[0].split(',')[2]);
//                                $('#MainContent_txtDistrito').val(data[0].split(',')[4]);

//                                $('#MainContent_txtApePaterno').val(data[0].split(',')[9]);
//                                $('#hfApePaterno').val(data[0].split(',')[9]);
//                                $('#MainContent_txtApeMaterno').val(data[0].split(',')[10]);
//                                $('#MainContent_txtNombres').val(data[0].split(',')[11]);
//                                $('#hfCodDireccion').val('0');

//                                $('#hfCodDepartamento').val(data[0].split(',')[5]);
//                                $('#hfCodProvincia').val(data[0].split(',')[6]);
//                                $('#hfCodDistrito').val(data[0].split(',')[7]);
//                                $('#hfDistrito').val(data[0].split(',')[4]);
//                                //$('#txtSaldoCreditoFavor').text(data[0].split(',')[12]);
//                                //$('#hfSaldoCreditoFavor').val(data[0].split(',')[12].replace("S/", "").replace(" ", ""));

//                                F_BuscarDireccionPorDefecto();
//                }
//                catch (x) { alertify.log(x); }
//                MostrarEspera(false);
//            },


//                error: function (response) {
//                    alertify.log(response.responseText);
//                },
//                failure: function (response) {
//                    alertify.log(response.responseText);
//                }
//            });



//return true;
//}



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
                            $(Hfgv).val('1');
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

            if ($(lblTipoDoc).val() != '16') {
                alertify.log('SOLO SE PUEDEN MODIFICAR LAS NOTAS DE PEDIDO');
                return true;
            }

            var objParams = {
                Filtro_CodDoc: 16,
                Filtro_CodDocumentoVenta: $(lblcodigo).val(),
                Filtro_TasaIgv: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                Filtro_NotaPedido: 0,
                Filtro_CodTipoDoc: $(lblTipoDoc).val(),
                Filtro_TasaIgvDscto: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                Filtro_Tasa: parseFloat($("#MainContent_ddlIgv option:selected").text()) + parseFloat(1),
                Filtro_CodMoneda: $(lblCodMoneda).val(),
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

                    $('#MainContent_txtKM').val(data.KM);

                    F_BuscarResponsables();
                    F_LlenarCorreos();

                    CodResponsableReemplazo = data.CodResponsable;
                    $('#MainContent_txtResponsable2').val(data.Responsable2);
                    $('#MainContent_txtResponsableDNI2').val(data.Responsable2DNI);
                
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