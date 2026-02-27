<%@ Page Title="REG. VENTA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RegistroFacturaLUBRISERVICIOS.aspx.cs" Inherits="SistemaInventario.Ventas.RegistroFacturaLUBRISERVICIOS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script> 
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js" type="text/javascript"></script>        
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript"></script>
    <script src="../Scripts/inputatajos/kibo.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="RegistroFacturaLUBRISERVICIOS.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"  type="text/css" />      
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/multiselect-combo/multiple-select.js" type="text/javascript"></script>
    <link href="../Asset/multiselect-combo/multiple-select.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/multiselect-combo/multiselectcustom.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
    <tr valign ="top">
    <td style ="width:1100px" valign="top">
             <div class="titulo">
        <asp:Label ID="lbTipoDocumento" runat="server" Text="Factura" Font-Bold="False" Font-Size="Large"
            Visible="false"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="REGISTRO DE DOCUMENTO DE VENTA" Font-Bold="False"
            Font-Size="Large"></asp:Label>
    </div>
             <div id="divTabs" style="width: 1120px">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
        </ul>
        <div id="tabRegistro">
            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 1100px">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    DATOS DEL CLIENTE
                </div>
                <div>
                    <table cellpadding="0" cellspacing="0" class="form-inputs" width="750">
                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="font-weight: bold;">
                                            Tipo
                                        </td>
                                        <td style="padding-left: 10px">
                                            <div id="div_TipoDoc" style="margin-left: 25px">
                                                <asp:DropDownList ID="ddlTipoDoc" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="85px">
                                                    <asp:ListItem Value="1">FACTURA</asp:ListItem>
                                                    <asp:ListItem Value="2">BOLETA</asp:ListItem>
                                                    <asp:ListItem Value="16">NOTA DE PEDIDO</asp:ListItem>
                                                    <asp:ListItem Value="15">COTIZACION</asp:ListItem>                                                    
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="font-weight: bold">
                                            Cliente
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNroRuc" runat="server" Width="70px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" MaxLength="11" onblur="F_ValidaRucDni(); return false;" CssClass="autocomplete-input"></asp:TextBox>
                                        </td>
                                        <td id="td_loading" style="font-weight: bold; padding-left: 5px; display: none">
                                            <img src="../Asset/images/loading.gif" />
                                        </td>
                                        <td id="div_Cliente">
                                            <asp:TextBox ID="txtCliente" runat="server" Width="350px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                            <asp:ImageButton ID="imgAddScop" runat="server" ImageUrl="~/Asset/images/add_small.png"
                                                ImageAlign="AbsMiddle" ToolTip="Agregar Cliente" Style="display: none;" />
                                        </td>
                                        <td style="font-weight: bold; padding-left: 5px">
                                            Distrito
                                        </td>
                                        <td style="padding-left: 10px">
                                            <asp:TextBox ID="txtDistrito" runat="server" Width="324px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="font-weight: bold">
                                            Direccion
                                        </td>
                                        <td>
                                            <asp:TextBox Style="width: 547px; position: absolute; color: blue; font-family: Arial;
                                                font-weight: bold; background: rgb(255, 255, 224);" ID="txtDireccion" runat="server"
                                                autocomplete="off"></asp:TextBox>
                                            <asp:DropDownList ID="ddlDireccion" Style="width: 567px" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="font-weight: bold; padding-left: 5px">
                                            Correo
                                        </td>
                                        <td id="div_correos" style="padding-left: 10px; width: 332px">
                                            <select id="ddlCorreos" style="width: 330px">
                                            </select>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnEdicionEmails" runat="server" Text="E" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                Font-Names="Arial" Font-Bold="True" Width="30" ToolTip="Edicion de Emails del Cliente" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                        DATOS DE LA FACTURA
                    </div>
                    <table cellpadding="0" cellspacing="0" class="form-inputs" width="750">
                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="font-weight: bold; display: none">
                                            Referencia
                                        </td>
                                        <td style="display: none">
                                            <asp:TextBox ID="txtReferencia" runat="server" Width="197px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold; padding-left: 3px">
                                            Moneda
                                        </td>
                                        <td style="padding-left: 12px">
                                            <div id="div_moneda">
                                                <asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="85" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="font-weight: bold">
                                            Serie
                                        </td>
                                        <td style="padding-left: 0px;">
                                            <div id="div_serie">
                                                <asp:DropDownList ID="ddlSerie" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td id="divNumero" style="display: none">
                                            <asp:TextBox ID="txtNumero" runat="server" Width="48" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold; padding-left: 5px;">
                                            Igv (%)
                                        </td>
                                        <td>
                                            <div id="div_igv">
                                                <asp:DropDownList ID="ddlIgv" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="60">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                         <td style="font-weight: bold">
                                            C.
                                        </td>
                                        <td style="font-weight: bold;">
                                            <div style="display: none">
                                                <asp:Label ID="lblTCCompra" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                            </div>
                                            <asp:Label ID="lblTCParaleloCompra" runat="server" Text="LabelParalelo" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td style="font-weight: bold">
                                            V.
                                        </td>
                                        <td style="font-weight: bold;">
                                            <div style="display: none">
                                                <asp:Label ID="lblTC" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                            </div>
                                            <asp:Label ID="lblTCParalelo" runat="server" Text="LabelParalelo" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td style="font-weight: bold;">
                                            <div>
                                                Emision
                                            </div>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmision" runat="server" Width="56px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold;">
                                            cond.
                                        </td>
                                        <td>
                                            <div id="div_formapago">
                                                <asp:DropDownList ID="ddlFormaPago" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="85">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                          <td style="font-weight: bold;">
                                                        SubTotal
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSubTotal" runat="server" Width="73px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ReadOnly="True" Text="0.00" CssClass="Derecha"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold;">
                                                        Igv
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtIgv" runat="server" Width="73px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ReadOnly="True" Text="0.00" CssClass="Derecha"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold;">
                                                        total
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTotal" runat="server" Width="74px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ReadOnly="True" Text="0.00" CssClass="Derecha"></asp:TextBox>
                                                    </td>
                                        <td style="font-weight: bold; display: none">
                                            vcto
                                        </td>
                                        <td style="padding-left: 8px; display: none">
                                            <asp:TextBox ID="txtVencimiento" runat="server" Width="56px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                        </td>
                                     
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" colspan="7">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="font-weight: bold">
                                                        Atencion
                                                    </td>
                                                    <td >
                                                        <asp:TextBox ID="txtAtencion" runat="server" Width="222px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td id="td_Impresora">
                                                        <asp:CheckBox ID="chkImpresion" runat="server" Text="Impresion" Font-Bold="True" />
                                                    </td>
                                                    <td >
                                                        <div id="td_Ticketera">
                                                            <asp:CheckBox ID="chkImpresionTicket" runat="server" Text="Ticket" Checked="True"
                                                                Font-Bold="True" />
                                                        </div>
                                                    </td>
                                                   
                                                    <td style="font-weight: bold;">
                                                        Dscto %
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDescuento" runat="server" Width="40px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ReadOnly="False" Text="0.00" CssClass="Derecha"></asp:TextBox>
                                                    </td>
                                                     
                                                    <td>
                                                        <asp:Button ID="btnAplicarDescuento" runat="server" Text=">" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                            Font-Names="Arial" Font-Bold="True" Width="30" />
                                                    </td>
                                            

                                           <td style="font-weight: bold;">
                                            Veh.
                                        </td>
                                        <td id="div_Placa1">
                                            <asp:TextBox ID="txtPlaca" runat="server" Width="53px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td id="div_Placa2">
                                            <asp:TextBox ID="txtPlaca2" runat="server" Width="53px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td id="div_Placa3">
                                            <asp:TextBox ID="txtPlaca3" runat="server" Width="53px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td id="div_Placa4">
                                            <asp:TextBox ID="txtPlaca4" runat="server" Width="52px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                         
                                       
                              <%--          <td id="div_Placa5">
                                            <asp:TextBox ID="txtPlaca5" runat="server" Width="52px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td id="div_Placa6">
                                            <asp:TextBox ID="txtPlaca6" runat="server" Width="52px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td id="div_Placa7">
                                            <asp:TextBox ID="txtPlaca7" runat="server" Width="52px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td id="div_Placa8">
                                            <asp:TextBox ID="txtPlaca8" runat="server" Width="52px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>--%>

                                        
                                                  
                                                   
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="font-weight: bold; padding-left: 5px">
                                            Nro. OC
                                        </td>
                                        <td style="padding-left: 13px">
                                            <asp:TextBox ID="txtNroOC" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Nro. Oper.
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNroOperacion" runat="server" Width="75px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>

                                        <td style="font-weight: bold">
                                            Requerimiento
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRequerimiento" runat="server" Width="75px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                         <td style="font-weight: bold">
                                                        Cotizacion
                                                    </td>
                                                    <td style="padding-left: 10px">
                                                        <asp:TextBox ID="txtCodCotizacion" CssClass="Derecha" runat="server" Width="100px"
                                                            Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:TextBox ID="TextBox1" runat="server" Width="45" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                    </td>
                                                   <td style="font-weight: bold;">
                                                        VENDEDOR
                                                    </td>
                                                   <td>
                                                        <div id="div_Vendedor">
                                                            <asp:DropDownList ID="ddlVendedor" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="157">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                     <td style="font-weight: bold;">
                                            KM
                                        </td>
                                        <td >
                                            <asp:TextBox ID="txtKM" runat="server" Width="50px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>

                                                    </tr>
                                    
                        </table>
                        </td>
                                  
                                    </tr>
                                      <tr>
                                      <td>
                                      <table>
                                      <tr>
                                       <td style="font-weight: bold; padding-left: 5px">
                                            OBS.
                                        </td>
                                        <td style="padding-left: 26px">
                                            <asp:TextBox ID="txtObservacion" runat="server" Width="1005px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                      </tr>
                                      </table>
                                      </td>
                                       
                        </tr>
                    </table>
                </div>
                <div id="div_trResponsableNP" >
                    <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                        DATOS DEL RESPONSABLE DE LA NOTA DE PEDIDO
                    </div>
                    <div>
                        <table cellpadding="0" cellspacing="0" class="form-inputs" width="750">
                            <tr id="trResponsableNP">
                                <td>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="font-weight: bold;">
                                                Autorizo
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtResponsable1" runat="server" Width="250px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold;">
                                                DNI
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtResponsableDNI1" runat="server" Width="60px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold; padding-left: 22px">
                                               Entregado
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtResponsable2" runat="server" Width="250px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold;">
                                                DNI
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtResponsableDNI2" runat="server" Width="60px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                  <div id="accordion">
                                <h3>
                                    DATOS DE LA GUIA</h3>
                <div class="ui-jqdialog-content" id="div_CuerpoGuia" style="display: none">
                  <table cellpadding="0" cellspacing="0" class="form-inputs">
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkGuia" runat="server" Text="Guia Serie" Font-Bold="True" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <div id="div_serieguia">
                                                                    <asp:DropDownList ID="ddlSerieGuia" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                        Font-Bold="True">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtNumeroGuia" runat="server" Width="50" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div id="div_TipoTransportista">
                                                                    <asp:DropDownList ID="ddlTipoTransportista" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                        Font-Bold="True">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </td>
                                                            <td style="font-weight: bold; padding-left: 40px;">
                                                                Fecha
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtFechaTraslado" runat="server" Width="56px" CssClass="Jq-ui-dtp"
                                                                    Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td style="font-weight: bold;padding-left: 50px;">
                                                                LLegada
                                                            </td>
                                                            <td style="padding-left: 14px;">
                                                                <asp:TextBox ID="txtDestino" runat="server" Width="423px" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-weight: bold">
                                                    Transportista
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtNroRucTransportista" runat="server" Width="70px" Font-Names="Arial"
                                                                    ForeColor="Blue" Font-Bold="True" MaxLength="11" onblur="F_ValidaRucTransportista(); return false;"></asp:TextBox>
                                                            </td>
                                                            <td id="td_loadingTransportista" style="font-weight: bold; padding-left: 5px; display: none">
                                                                <img src="../Asset/images/loading.gif" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTransportista" runat="server" Width="250" Font-Names="Arial"
                                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td style="font-weight: bold;padding-left: 48px;">
                                                                Distrito
                                                            </td>
                                                           <td style="padding-left: 14px;">
                                                        <asp:TextBox ID="txtDistritoTransportista" runat="server" Width="423" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                           
                                                            <td style="font-weight: bold; display: none">
                                                                ACUENTA
                                                            </td>
                                                            <td style="display: none">
                                                                <asp:TextBox ID="txtAcuenta" runat="server" Width="90px" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" CssClass="Derecha" ReadOnly="True" Text="0.00"></asp:TextBox>
                                                            </td>
                                                            <td style="font-weight: bold; display: none">
                                                                ACUENTA NV
                                                            </td>
                                                            <td style="display: none">
                                                                <asp:TextBox ID="txtAcuentaNV" runat="server" Width="90px" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" CssClass="Derecha" ReadOnly="True" Text="0.00"></asp:TextBox>
                                                            </td>
                                                            <td style="display: none" id="tdftOC">
                                                                <table>
                                                                    <tr>
                                                                        <td style="font-weight: bold;">
                                                                            Serie
                                                                        </td>
                                                                        <td id="tdtxtSerieOC">
                                                                            <asp:TextBox ID="txtSerieOC" runat="server" Width="25px" ForeColor="Blue" Font-Names="Arial"
                                                                                Font-Bold="True"></asp:TextBox>
                                                                        </td>
                                                                        <td style="font-weight: bold;">
                                                                            Num.
                                                                        </td>
                                                                        <td id="tdtxtNumeroOC">
                                                                            <asp:TextBox ID="txtNumeroOC" runat="server" Width="42px" ForeColor="Blue" Font-Names="Arial"
                                                                                Font-Bold="True"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                            <td style="font-weight: bold">
                                                        Direccion
                                                    </td>
                                                    
                                                
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                         <td>
                                                                <asp:TextBox ID="txtDireccionTransportista" Style="position: absolute;" runat="server" Width="313" Font-Names="Arial"
                                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                                    <asp:DropDownList ID="dllDireccionTransportista" Style="width: 335px" runat="server">
                                                        </asp:DropDownList>
                                                            </td>
                                                        
                                                        <td style="font-weight: bold;padding-left: 45px;">
                                                    Placa
                                                </td>
                                                            <td style="padding-left: 25px;">
                                                                <asp:TextBox ID="txtPlacaTraslado" runat="server" Width="60" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td style="font-weight: bold">
                                                                Marca
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtMarcaGuia" runat="server" Width="152" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                              <td style="font-weight: bold">
                                                                Licencia
                                                            </td>
                                                             <td style="">
                                                                <asp:TextBox ID="txtLicenciaGuia" runat="server" Width="105" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                            <td style="font-weight: bold">
                                                                 Num Bultos
                                                            </td>
                                                            
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtNuBultos" runat="server" Width="40" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                            </td>
                                                            <td style="font-weight: bold;padding-left: 115px">
                                                                Peso 
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPeso" runat="server" Width="45" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div id="div_codunidadpeso">
                                                                    <asp:DropDownList ID="ddlcodunidadpeso" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                        Font-Bold="True">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </td>
                                                <td style="font-weight: bold;padding-left: 45px">
                                                    Conductor
                                                </td>
                                                            <td style="">
                                                                <asp:TextBox ID="txtConductorDNI" runat="server" Width="80" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" onblur="F_ValidaRucDniConductor(); return false;" ></asp:TextBox>
                                                            </td>
                                                            <td style=" ">
                                                                <asp:TextBox ID="txtConductorRazonSocial" runat="server" Width="332px" Font-Names="Arial"
                                                                    ForeColor="Blue" Font-Bold="True" placeholder="NOMBRE CONDUCTOR"></asp:TextBox>
                                                            </td>
                                                              
                                                        </tr>
                                                    </table>
                                                </td>
                                               
                                            </tr>
                                        </table>
                </div>
                 </div>
                <div class="linea-button">
                 <asp:Button ID="btnListarCotizaciones" runat="server" Text="Listar Cotiz." class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnOC" runat="server" Text="OV" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" Visible="false" />
                   <%-- <asp:Button ID="btnNotaVenta" runat="server" Text="Nota Pedido" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnCotizacion" runat="server" Text="Cotizaciones" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />--%>
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </div>
                <div>
                </div>
            </div>
            <div align="center">
                <asp:Label ID="lblNroItems" runat="server" Text="" Font-Bold="True"></asp:Label>
            </div>
            <div id="div_grvDetalleArticulo" style="padding-top: 5px;">
                <asp:GridView ID="grvDetalleArticulo" runat="server" AutoGenerateColumns="False"
                    border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                    Width="1100px">
                    <Columns>
                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ITEM">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblNro" Text='<%# Bind("NroRow") %>'></asp:Label>
                                <asp:HiddenField ID="lblcoddetalle" runat="server" Value='<%# Bind("CodDetalle") %>' />
                                <asp:HiddenField ID="hfcodarticulo" runat="server" Value='<%# Bind("CodArticulo") %>' />
                                <asp:HiddenField ID="hfPrecio" runat="server" Value='<%# Bind("Precio") %>' />
                                <asp:HiddenField ID="hfCantidad" runat="server" Value='<%# Bind("Cantidad") %>' />
                                <asp:HiddenField ID="hfCosto" runat="server" Value='<%# Bind("Costo") %>' />
                                <asp:HiddenField ID="hfCostoDolares" runat="server" Value='<%# Bind("Costo") %>' />
                                <asp:HiddenField ID="hfCostoProductoSoles" runat="server" Value='<%# Bind("CostoProductoSoles") %>' />
                                <asp:HiddenField ID="hfCostoProductoDolares" runat="server" Value='<%# Bind("CostoProductoDolares") %>' />
                                <asp:HiddenField ID="hfMargen" runat="server" Value='<%# Bind("Margen") %>' />
                                <asp:HiddenField ID="hfRedondeo" runat="server" Value='<%# Bind("Redondeo") %>' />
                                <asp:HiddenField ID="hfFactorRedondeo" runat="server" Value='<%# Bind("FactorRedondeo") %>' />
                                <asp:HiddenField ID="hfDescuento" runat="server" Value='<%# Bind("Descuento") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CodigoProducto" HeaderText="Codigo">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Producto">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblproducto" Text='<%# Bind("Producto") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Marca">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblMarca" Text='<%# Bind("Marca") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtCantidad" Width="75px" Font-Bold="true" Style="text-align: center;"
                                    Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Cantidad") %>' CssClass="ccsestilo"
                                    onblur="F_ActualizarCantidad(this.id); return false;"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="UM" HeaderText="UM">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <%--   <asp:TemplateField HeaderText="Costo">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCosto" Text='<%# Bind("Costo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Precio" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtPrecio" Width="75px" Font-Bold="true" Style="text-align: center;"
                                    Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Precio") %>' CssClass="ccsestilo"
                                    onblur="F_ActualizarPrecio(this.id); return false;" ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Importe">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblimporte" Text='<%# Bind("Importe") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="tabConsulta" style="width: 1100">
            <div id='divConsulta' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    Criterio de busqueda
                </div>
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" class="form-inputs">
                        <tbody>
                            <tr>
                                <td style="font-weight: bold">
                                    Tipo
                                </td>

                                <td>
                                <table cellpadding="0" cellspacing="0" >
                                <tr>
                                <td>
                                    <div id="div_TipoDoc2" style="margin-left: 23px">
                                        <asp:DropDownList ID="ddlTipoDoc2" runat="server" Font-Names="Arial" ForeColor="Blue"
                                            Font-Bold="True" Width="85px">
                                            <asp:ListItem Value="1">FACTURA</asp:ListItem>
                                            <asp:ListItem Value="2">BOLETA</asp:ListItem>
                                            <asp:ListItem Value="16">NOTA DE PEDIDO</asp:ListItem>  
                                            <asp:ListItem Value="15">COTIZACION</asp:ListItem>                                                                                                                                  
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td style="font-weight: bold">
                                    Serie
                                </td>
                                <td>
                                    <div id="div_serieconsulta">
                                        <asp:DropDownList ID="ddlSerieConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                            Font-Bold="True">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkNumero" runat="server" Text="Numero" Font-Bold="True" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNumeroConsulta" runat="server" Width="45" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkRango" runat="server" Text="Fecha" Font-Bold="True" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDesde" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHasta" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkCliente" runat="server" Text="Cliente" Font-Bold="True" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtClienteConsulta" runat="server" Width="200" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkPlacaConsulta" runat="server" Text="Placa" Font-Bold="True" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPlacaConsulta" runat="server" Width="50" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                                </tr>
                                </table>
                                </td>
                                
                           
                              
                            </tr>
                            <tr>
                             <td style="font-weight: bold">
                                    Est. PEDIDO
                                </td>
                                <td>
                                <table cellpadding="0" cellspacing="0">
                                <tr>
                                <td>
                                    <div id="Div_EstadoNP" style="margin-left: 23px">
                                        <asp:DropDownList ID="ddlEstadoConsultaNP" runat="server" Font-Names="Arial" ForeColor="Blue"
                                            Font-Bold="True"  Width="85px">
                                        </asp:DropDownList>
                                    </div>
                                </td>

                                     <td style="font-weight: bold">
                                    Est. SUNAT
                                </td>
                                <td>
                                    <div id="Div_Estado">
                                        <asp:DropDownList ID="ddlEstadoConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                            Font-Bold="True">
                                            <asp:ListItem Value="TODOS">TODOS</asp:ListItem>
                                            <asp:ListItem Value="APROBADO">APROBADO</asp:ListItem>
                                            <asp:ListItem Value="ESPERA">ESPERA</asp:ListItem>
                                            <asp:ListItem Value="RECHAZADO">RECHAZADO</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                  <div id="div_Visualizar">
                                        <asp:DropDownList ID="ddlVisualizar" runat="server" Font-Names="Arial" ForeColor="Blue"
                                            Font-Bold="True">
                                            <asp:ListItem Value="0">VER FACTURA Y GUIA ELECTRONICA</asp:ListItem>
                                            <asp:ListItem Value="1">VER SOLO FACTURA ELTRONICA</asp:ListItem>
                                            <asp:ListItem Value="10">VER SOLO GUIA ELECTRONICA</asp:ListItem>                                        
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                 <td style = "display:none;">
                                    <asp:CheckBox ID="chkProductoConsulta" runat="server" Text="Producto" Font-Bold="True" />
                                </td>
                                <td style = "display:none;">
                                    <asp:TextBox ID="txtProductoConsulta" runat="server" Width="100" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                                </tr>
                                </table>
                                </td>
                                
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="linea-button">             

                 

                 <asp:Button ID="btnFacturar" runat="server" Text="Facturar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnImpresionPedidos" runat="server" Text="Imprimir" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnBuscarConsulta" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </div>
            </div>
            <div style="padding-top: 5px;">
                            <table cellpadding="0" cellspacing="0" align="center">
                                <tr>
                                     <td style="font-weight: bold;padding-left: 20px; ">
                                        Cantidad de Registros:
                                    </td>
                                    <td style="font-weight: bold;">
                                        <label id="lblGrillaConsulta">
                                        </label>
                                    </td>  
                                    <td style="font-weight: bold;padding-left: 250px; color: red;font-size: medium">
                                        FALTA APROBAR:
                                    </td>
                                    <td style="font-weight: bold; color: red;font-size: 20px;">
                                        <label id="lblGrillaEspera">
                                        </label>
                                    </td>  
                                </tr>
                            </table>
                        </div>
            <div id="div_consulta" style="padding-top: 5px;">
                <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                    CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1170px"
                    OnRowDataBound="grvConsulta_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgReemplazar" ImageUrl="~/Asset/images/Reemplazo.png"
                                    ToolTip="Actualizar Documento" OnClientClick="F_ReemplazarDocumento(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEliminarDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                    ToolTip="Eliminar Factura" OnClientClick="F_EliminarRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/Eliminar.jpg"
                                    ToolTip="Anular Factura" OnClientClick="F_AnularPopUP(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEditarDocumento" ImageUrl="~/Asset/images/btnEdit.gif"
                                    ToolTip="Editar Factura" OnClientClick="F_EditarRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                      <%--  <asp:TemplateField HeaderText="GR">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgImprimir" ImageUrl="~/Asset/images/imprimir.gif"
                                    ToolTip="Imprimir Guia" OnClientClick="F_ImprimirGuia(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="TK">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgTCK" ImageUrl="~/Asset/images/imprimir.gif"
                                    ToolTip="IMPRIMIR TICKET" OnClientClick="F_ImprimirFacturaGrilla(this,'TK'); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IMP">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgPdf" ImageUrl="~/Asset/images/imprimir.gif"
                                    ToolTip="IMPRIMIR FACTURA" OnClientClick="F_ImprimirFacturaGrilla(this,'IMP'); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgPdf2" ImageUrl="~/Asset/images/pdf.png" ToolTip="VER PDF"
                                    OnClientClick="F_ImprimirFacturaHTML(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CE">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgMail" ImageUrl="~/Asset/images/Mail2.png"
                                    ToolTip="Reenvio de Correo" OnClientClick="F_ReenvioMail(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="A">
                        <ItemTemplate >
                                <img id="imgMasa" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click_Auditoria(this);"
                                    title="AUDITORIA" />
                                <asp:Panel ID="pnlOrdersAuditoria" runat="server" Style="display: none" >
                                    <asp:GridView ID="grvDetalleAuditoria" runat="server" border="0" CellPadding="0" CellSpacing="1"
                                        AutoGenerateColumns="False" GridLines="None" class="GridView">
                                        <Columns>
                                            <asp:BoundField DataField="Auditoria" HeaderText="Auditoria">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="O">
                          <ItemTemplate>
                                <img id="imgMasO" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click_Observacion(this);"
                                    title="OBSERVACION" />
                                <asp:Panel ID="pnlOrdersObservacion" runat="server" Style="display: none">
                                    <asp:GridView ID="grvDetalleObservacion" runat="server" border="0" CellPadding="0" CellSpacing="1"
                                        AutoGenerateColumns="False" GridLines="None" class="GridView">
                                        <Columns>
                                            <asp:BoundField DataField="Observacion" HeaderText="Observacion">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="D">
                            <ItemTemplate>
                                <img id="imgMas" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click(this);"
                                    title="Ver Detalle" />
                                <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                    <asp:GridView ID="grvDetalle" runat="server" border="0" CellPadding="0" CellSpacing="1"
                                        AutoGenerateColumns="False" GridLines="None" class="GridView">
                                        <Columns>
                                            <asp:BoundField DataField="ID" HeaderText="ID">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Codigo" HeaderText="Codigo">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Marca" HeaderText="Marca">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="UM" HeaderText="UM">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Precio" HeaderText="Precio">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                           
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Numero" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblnumero" Text='<%# Bind("Numero") %>' CssClass="detallesart"></asp:Label>
                                <%--<asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>'></asp:Label>--%>
                                <asp:HiddenField ID="lblCodigo" runat="server" Value='<%# Bind("Codigo") %>' />
                                <asp:HiddenField ID="hfCodTipoDoc" runat="server" Value='<%# Bind("CodTipoDoc") %>' />
                                <asp:HiddenField ID="hfCodTraslado" runat="server" Value='<%# Bind("CodGuia") %>' />
                                <asp:HiddenField ID="hfDetalleCargado" runat="server" Value='0' />
                                <asp:HiddenField ID="hfCodMoneda" runat="server" Value='<%# Bind("CodMoneda") %>' />
                                <asp:HiddenField ID="hfCodCtaCte" runat="server" Value='<%# Bind("CodCtaCte") %>' />
                                <asp:HiddenField ID="hfcodformapago" runat="server" Value='<%# Bind("CODFORMAPAGO") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cliente" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblcliente" Text='<%# Bind("Cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Emision" HeaderText="Emision" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Condicion" HeaderText="Condicion" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>                  
                        <asp:BoundField DataField="Moneda" HeaderText="Moneda" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>                    
                        <asp:BoundField DataField="Total" HeaderText="Total" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Saldo" HeaderText="Saldo" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                         <asp:TemplateField HeaderText="Guia" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblGuia" Text='<%# Bind("Guia") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Placa" HeaderText="Placa">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Anexo" HeaderText="Anexo">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Est. Sunat">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="lblEstadoSunat" Font-Underline="true" ForeColor="Black"
                                                Style="cursor: hand" Text='<%# Bind("EstatusSunat") %>' onclick="F_VerArchivoCDR(this.id); return false;"
                                                ToolTip="Ver Archivo CDR">
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="Correo Sunat">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr align="center">
                                        <td>
                                            <asp:Label runat="server" ID="lblCorreoSunat" Text='<%# Bind("CorreoSunat") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    </td> 
      <td valign="top" style="width: 120px">
               
                <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 200px;
                    height: 100%;">
                    <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                        Cotizaciones
                    </div>
                    <div id="divListaCotizaciones" class="ui-jqdialog-content">
                        <ul id="lu_Cotizaciones" class="ul-float" style="padding-left: 5px; width: 170px">
                        </ul>
                    </div>
                </div>
            </td>
    </tr>
    </table>
    <div id="divFacturacionOC" style="display: none;">
        <table cellpadding="0" cellspacing="0" width="850">
            <tr>
                <td align="right" style="padding-top: 10px;">
                    <asp:Button ID="btnDevolverItemOC" runat="server" Text="Devolver" class="ui-button ui-widget ui-state-default ui-corner-all
    ui-button-text-only" Font-Names="Arial" Width="120" />
                    <asp:Button ID="btnAgregarItemOC" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all
    ui-button-text-only" Font-Names="Arial" Width="120" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;">
                    <div id="div_DetalleOC">
                        <asp:GridView ID="grvDetalleOC" runat="server" AutoGenerateColumns="False" border="0"
                            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="860px">
                            <Columns>
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" onclick="F_ValidarCheck_OC(this.id);" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodDetalle" Text='<%# Bind("CodDetalle") %>'></asp:Label>
                                        <asp:HiddenField ID="hfCodArticulo" runat="server" Value='<%# Bind("CodArticulo")%>' />
                                        <asp:HiddenField ID="hfCodUndMedida" runat="server" Value='<%# Bind("CodUndMedida")
    %>' />
                                        <asp:HiddenField ID="hfCodMovimiento" runat="server" Value='<%# Bind("CodMovimiento")
    %>' />
                                        <asp:HiddenField ID="hfSerieDoc" runat="server" Value='<%# Bind("SerieDoc")
    %>' />
                                        <asp:HiddenField ID="hfNumeroDoc" runat="server" Value='<%# Bind("NumeroDoc")
    %>' />
                                        <asp:HiddenField ID="hfCostoUnitario" runat="server" Value='<%# Bind("CostoUnitario")
    %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Numero">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNumero" Text='<%# Bind("Numero") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Codigo">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Producto" HeaderText="Descripcion">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Compra">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCantidad" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="UM" HeaderText="UM">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Precio">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPrecio" Text='<%# Bind("Precio") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtCantidadEntregada" Width="55px" Font-Bold="true"
                                            Style="text-align: center;" Font-Names="Arial" onblur="F_ValidarStockGrillaOC(this.id);"
                                            Enabled="False"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_FacturacionGuia" style="display: none;">
        <table cellpadding="0" cellspacing="0" width="850">
            <tr>
                <td align="right" style="padding-top: 10px;">
                    <asp:Button ID="btnDevolverGuia" runat="server" Text="Devolver" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" ForeColor="Blue" Font-Bold="True" />
                    <asp:Button ID="btnAgregarGuia" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" ForeColor="Blue" Font-Bold="True" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;">
                    <div id="div_GrillaFacturacionGuia">
                        <asp:GridView ID="grvFacturacionGuia" runat="server" AutoGenerateColumns="False"
                            border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                            Width="860px" Height="400">
                            <Columns>
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" onclick="F_ValidarCheck_OC(this.id);" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodDetalle" Text='<%# Bind("CodDetalle") %>'></asp:Label>
                                        <asp:HiddenField ID="hfCodArticulo" runat="server" Value='<%# Bind("CodArticulo") %>' />
                                        <asp:HiddenField ID="hfCodUndMedida" runat="server" Value='<%# Bind("CodUndMedida") %>' />
                                        <asp:HiddenField ID="hfCodMovimiento" runat="server" Value='<%# Bind("CodMovimiento") %>' />
                                        <asp:HiddenField ID="hfSerieDoc" runat="server" Value='<%# Bind("SerieDoc") %>' />
                                        <asp:HiddenField ID="hfNumeroDoc" runat="server" Value='<%# Bind("NumeroDoc") %>' />
                                        <asp:HiddenField ID="hfCostoUnitario" runat="server" Value='<%# Bind("CostoUnitario") %>' />
                                        <asp:HiddenField ID="hfCodDepartamento" runat="server" Value='<%# Bind("CodDepartamento") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guia">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNumero" Text='<%# Bind("Numero") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FechaEmision" HeaderText="Fecha">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Almacen" HeaderText="Almacen">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Codigo">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Producto" HeaderText="Descripcion">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Compra">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCantidad" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="UM" HeaderText="UM">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Precio">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPrecio" Text='<%# Bind("Precio") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtCantidadEntregada" Width="55px" Font-Bold="true"
                                            Style="text-align: center;" Font-Names="Arial" onblur="F_ValidarStockGrillaOC(this.id);"
                                            Enabled="False"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="divConsultaArticulo" style="display: none;">
        <div id='div1' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                Criterio de busqueda
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                    <tbody>
                        <tr>
                            <td id="div_chkServicios">
                                <asp:CheckBox ID="chkServicios" runat="server" Text="Servicios" Font-Bold="True" />
                            </td>
                            <td id="div_chkActivos">
                                <asp:CheckBox ID="chkActivos" runat="server" Text="Activos" Font-Bold="True" />
                            </td>
                            <td style="display: none">
                                <asp:CheckBox ID="chkNotaPedido" runat="server" Text="nota pedido" Font-Bold="True" />
                            </td>
                            <td style="padding-left: 5px; font-weight: bold">
                                Descripcion
                            </td>
                            <td>
                                <asp:TextBox ID="txtArticulo" runat="server" Width="600px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold;">
                                total
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotal2" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" ReadOnly="True" Text="0.00" CssClass="Derecha"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold;">
                                <div>
                                    <asp:Label ID="Label1" runat="server" Text="Compra" Font-Bold="True"></asp:Label>
                                </div>
                            </td>
                            <td style="font-weight: bold;">
                                <div style="display: none">
                                    <asp:Label ID="lblTC2Compra" runat="server" Text="0.00" Font-Bold="True"></asp:Label>
                                </div>
                                <asp:Label ID="lblTC2ParaleloCompra" runat="server" Text="0.00" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="font-weight: bold;">
                                <div>
                                    <asp:Label ID="Label4" runat="server" Text="Venta" Font-Bold="True"></asp:Label>
                                </div>
                            </td>
                            <td style="font-weight: bold;">
                                <div style="display: none">
                                    <asp:Label ID="lblTC2" runat="server" Text="0.00" Font-Bold="True"></asp:Label>
                                </div>
                                <asp:Label ID="lblTC2Paralelo" runat="server" Text="0.00" Font-Bold="True"></asp:Label>
                            </td>
                             
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="linea-button">
                <asp:Button ID="btnBuscarArticulo" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all
    ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="120" />
                
            </div>
       
         <div class="linea-button">
            </div>
            <div>
                <table>
                    <tr>
                        <td valign="top">
                            <div style="overflow-y: scroll; height: 330px;">
                              <div style="padding-top: 5px;">
                            <table cellpadding="0" cellspacing="0" align="center">
                                <tr>
                                   
                                    <td style="font-weight: bold;padding-left: 20px; ">
                                        Cantidad de Registros:
                                    </td>
                                    <td style="font-weight: bold;">
                                        <label id="lblCantidadProducto">
                                        </label>
                                    </td>  
                                </tr>
                            </table>
                        </div>
                    <div id="div_grvConsultaArticulo" style="padding-top: 5px;">
                <asp:GridView ID="grvConsultaArticulo" runat="server" AutoGenerateColumns="False"
                border="0" CellPadding="0" CellSpacing="1" CssClass="GridView GridView-MaxHeight" GridLines="None"
                Width="1200px" OnRowDataBound="grvConsultaArticulo_RowDataBound">
                <Columns>
                   <%-- <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkOK" CssClass="chkSi" Text="" onclick="F_ValidarCheck(this.id);" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                     <asp:TemplateField>
                                                <ItemStyle Font-Bold="true" Width="26px" />
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="imgAgregar" ImageUrl="~/Asset/images/ok.gif"
                                                        ToolTip="Agregar" OnClientClick="F_AgregarArticulo(this.id,1); return false;" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                   
               <%--     <asp:TemplateField>
                        <ItemTemplate>
                            <img id="imgMasProducto" alt="" style="cursor: pointer" src="../Asset/images/plus.gif"
                                onclick="imgMasProducto_Click(this);" title="VER DETALLE PRODUCTO" />
                            <asp:Panel ID="pnlProductos" runat="server" Style="display: none">
                                <asp:GridView ID="grvDetalleProducto" runat="server" border="0" CellPadding="0" CellSpacing="1"
                                    AutoGenerateColumns="False" GridLines="None" class="GridView">
                                    <Columns>
                                        <asp:BoundField DataField="Linea" HeaderText="Linea">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Modelo" HeaderText="Modelo">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Año" HeaderText="Año">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Motor" HeaderText="Motor">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CajaCambio" HeaderText="Caja Cambio">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Transmision" HeaderText="Transmision">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Filtro" HeaderText="Filtro">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Codigo">
                        <ItemStyle Font-Bold="true" HorizontalAlign="Left" />
                        <ItemTemplate>
                           
                              <asp:HyperLink runat="server" ID="hlkCodigo" Font-Underline="true" ForeColor="Blue"
                                Style="cursor: hand" Text='<%# Bind("CodigoProducto") %>' onclick="F_VerUltimoPrecio(this.id); return false;"
                                ToolTip="Ver Series" class="detallesart"> </asp:HyperLink>
                            <asp:HiddenField ID="hfcodproducto" runat="server" Value='<%# Bind("CodProducto")%>'/>
                            <asp:HiddenField ID="hfcodunidadventa"  runat="server" Value='<%#Bind("CodUnidadVenta") %>' />
                            <asp:HiddenField ID="hfcosto" runat="server" Value='<%#Bind("Costo") %>' />
                            <asp:HiddenField ID="hfDescuento" runat="server" Value='<%#Bind("Descuento") %>' />
                            <asp:HiddenField ID="hfCodFamilia" runat="server" Value='<%#Bind("CodFamilia") %>' />
                            <asp:HiddenField ID="hfCostoProductoSoles" runat="server" Value='<%# Bind("CostoProductoSoles") %>' />
                            <asp:HiddenField ID="hfCostoProductoDolares" runat="server" Value='<%# Bind("CostoProductoDolares") %>' />
                            <asp:HiddenField ID="hfMargen" runat="server" Value='<%# Bind("Margen") %>' />
                            <asp:HiddenField ID="hfDscProducto2" runat="server" Value='<%# Bind("DscProducto2") %>' />
                            <asp:HiddenField ID="hfStock" runat="server" Value='<%# Bind("Stock") %>' />
                            <asp:HiddenField ID="hfRedondeo" runat="server" Value='<%# Bind("Redondeo") %>' />
                            <asp:HiddenField ID="hfFactorRedondeo" runat="server" Value='<%# Bind("FactorRedondeo") %>' />
                            <asp:HiddenField ID="hfUM" runat="server" Value='<%# Bind("UM") %>' />
                            <asp:HiddenField ID="hfpreciosoles" runat="server" Value='<%# Bind("PrecioSoles") %>' />
                            <asp:HiddenField ID="hfpreciodolares" runat="server" Value='<%# Bind("PrecioDolares") %>' />
                            <asp:HiddenField ID="hfCodTipoProducto" runat="server" Value='<%# Bind("CodTipoProducto") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Producto" HeaderStyle-HorizontalAlign="Center">
                           <ItemStyle HorizontalAlign="Left" />
                           <ItemTemplate>
                               <asp:HyperLink runat="server" ID="lblProducto" Font-Underline="true" ForeColor="Blue" class="detallesart"
                                   Style="cursor: hand" Text='<%# Bind("Producto") %>' onclick="F_AgregarArticuloFromDsc(this.id); return false;">
                               </asp:HyperLink>
                           </ItemTemplate>
                       </asp:TemplateField>

                    <asp:TemplateField HeaderText="Marca">
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblMarca" Text='<%# Bind("Marca") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- <asp:BoundField DataField="Medida" HeaderText="Medida">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>--%>
                   
                   <asp:TemplateField HeaderText="Stock">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblChala1" Text='<%# Bind("Chala1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="ALMACEN 2">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblChala2" Text='<%# Bind("Chala2")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                   
                     <asp:TemplateField HeaderText="UM">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblUM" Text='<%# Bind("UM") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Ubicacion" HeaderText="Ubic">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Dolares">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPrecioDolares" Text='<%# Bind("PrecioDolares")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Soles">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPrecioSoles" Text='<%# Bind("PrecioSoles") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MargenVenta" HeaderText="Margen">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Descuento" HeaderText="Dscto-Max">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UltimoPrecio" HeaderText="Ult. Precio">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                   
                    <%--<asp:TemplateField HeaderText="Precio" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtPrecio" Width="55px" Font-Bold="true" Style="text-align: center;"
                                CssClass="ccsestilo" Font-Names="Arial" onblur="F_ValidarPrecioGrilla(this.id);"
                                ForeColor="Blue" Enabled="False"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                   <%-- <asp:TemplateField HeaderText="Dscto" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtDescuento" Width="55px" Font-Bold="true" Style="text-align: center;"
                                CssClass="ccsestilo" Font-Names="Arial" onblur="F_ValidarDescuento(this.id);"
                                ForeColor="Blue" Enabled="False"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cant." ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtCantidad" Width="55px" Font-Bold="true" Style="text-align: center;"
                                CssClass="ccsestilo" Font-Names="Arial" onblur="F_ValidarStockGrilla(this.id);"
                                ForeColor="Blue" Enabled="False"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </div>
                            </div>
                            </td>
                            </tr>
                            </table>
                            </div>
            
            <div class="linea-button">
              </div>
              <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                    <tbody>
                        <tr>
                           
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                     <td style="font-weight: bold">
                                Codigo
                            </td>
                                        <td>
                                            <asp:TextBox ID="txtCodigoProductoAgregar" runat="server" Width="425px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True" ReadOnly="true" Font-Size="16"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Stock
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStockAgregar" runat="server" Width="100px" Font-Names="Arial"
                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True" ReadOnly="true" Font-Size="16"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            UM
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUMAgregar" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" ReadOnly="true" Font-Size="16"></asp:TextBox>
                                        </td>
                                        
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                           
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtArticuloAgregar" runat="server" Width="640px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True" Font-Size="16"></asp:TextBox>
                                        </td>
                                          <td style="font-weight: bold">
                                            Precio
                                        </td>
                                        <td>
                                            <asp:TextBox Style="width: 80px; position: absolute; color: blue; font-family: Arial;
                                                font-weight: bold; background: rgb(255, 255, 224);" ID="txtPrecioDisplay" runat="server"
                                                Font-Size="16"></asp:TextBox>
                                            <asp:DropDownList ID="ddlPrecio" Style="width: 100px" runat="server" Font-Size="16">
                                                <asp:ListItem Value="test1">test1</asp:ListItem>
                                                <asp:ListItem Value="test2">test2</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                         <td style="font-weight: bold">
                                            Descuento
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDsct" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" onblur="F_ValidarDescuento(this.id);" Font-Size="16"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Cantidad
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCantidad" runat="server" Width="40px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" CssClass="Derecha" Font-Size="16"></asp:TextBox>
                                        </td>
                                      
                                        <td style="font-weight: bold">
                                            <asp:Label ID="lblMonedaAgregar" runat="server" Text="" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                           <asp:Button ID="btnAgregar" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default
    ui-corner-all ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="120" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
     </div>
    </div>
    <div id="div_ultimoprecio" style="display: none;">
        <table>
            <tr>
                <td style="font-weight: bold">
                    Ultimo Precio
                </td>
                <td>
                    <asp:TextBox ID="txtUltimoPrecio" runat="server" Width="80px" ReadOnly="True" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" Font-Size="Small"></asp:TextBox>
                </td>
                <td style="font-weight: bold">
                    Moneda
                </td>
                <td>
                    <asp:TextBox ID="txtMonedaPrecio" runat="server" Width="80px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" ReadOnly="True" Font-Size="Small"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Fecha
                </td>
                <td>
                    <asp:TextBox ID="txtFechaPrecio" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True" Font-Size="Small" Enabled="false"></asp:TextBox>
                </td>
                <td style="font-weight: bold">
                    Cantidad
                </td>
                <td>
                    <asp:TextBox ID="txtCantidadPrecio" runat="server" Width="80px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" Font-Size="Small" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Descripcion 2
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtDescripcion2" runat="server" Width="260px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" Font-Size="Small" TextMode="MultiLine" Height="60"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Modelo
                </td>
                <td>
                    <asp:TextBox ID="txtModelo" runat="server" Width="80px" ReadOnly="True" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" Font-Size="Small"></asp:TextBox>
                </td>
                <td style="font-weight: bold">
                    Motor
                </td>
                <td>
                    <asp:TextBox ID="txtMotor" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True" ReadOnly="True" Font-Size="Small"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Posicion
                </td>
                <td>
                    <asp:TextBox ID="txtPosicion" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True" Font-Size="Small"></asp:TextBox>
                </td>
                <td style="font-weight: bold">
                    Año
                </td>
                <td>
                    <asp:TextBox ID="txtAño" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True" Font-Size="Small"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Medida
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtMedida" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True" Font-Size="Small"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_FacturarCotizacion" style="display: none;">
        <div class="ui-jqdialog-content">
            <table>
                <tr>
                    <td>
                        Codigo (ID)
                    </td>
                    <td style="padding-left: 5px;">
                     <%--   <asp:TextBox ID="txtCodCotizacion" runat="server" Width="80px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True" Font-Size="Small"></asp:TextBox>--%>
                    </td>
                    <td style="padding-left: 10px;">
                        <asp:Button ID="btnFacturarCotizacion" runat="server" Text="Facturar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="div_FacturacionNotaVenta" style="display: none;">
        <div class="ui-jqdialog-content">
            <table>
                <tr>
                    <td>
                        Codigo (ID)
                    </td>
                    <td style="padding-left: 5px;">
                        <asp:TextBox ID="txtCodNotaVenta" runat="server" Width="80px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True" Font-Size="Small"></asp:TextBox>
                    </td>
                    <td style="padding-left: 10px;">
                        <asp:Button ID="btnFacturarNV" runat="server" Text="Facturar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="div_VerPrecio" style="display: none;">
        <div id="div_PrecioMoneda" style="padding-top: 5px;">
            <asp:GridView ID="grvPrecioMoneda" runat="server" AutoGenerateColumns="False" border="0"
                CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="300px">
                <Columns>
                    <asp:BoundField DataField="CodProducto" HeaderText="ID">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Precio3" HeaderText="Precio 3">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Precio2" HeaderText="Precio 2">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Precio1" HeaderText="Precio 1">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Moneda" HeaderText="Moneda">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div id="divFacturacionNV" style="display: none;">
        <table cellpadding="0" cellspacing="0" width="1000">
            <tr style="width: 1060px">
                <td style="padding-top: 10px;">
                    <asp:CheckBox ID="chkDesdeNV" runat="server" Text="DESDE" Font-Bold="True" Checked="True" />
                </td>
                <td style="padding-left: 2px; padding-top: 10px;">
                    <asp:TextBox ID="txtDesdeNV" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="padding-top: 10px; padding-left: 2px; font-weight: bold">
                    HASTA
                </td>
                <td style="padding-top: 10px; padding-left: 2px;">
                    <asp:TextBox ID="txtHastaNV" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="font-weight: bold; padding-top: 10px;">
                    Serie
                </td>
                <td style="padding-top: 10px;">
                    <div id="div_SerieNV">
                        <asp:DropDownList ID="ddlSerieNV" runat="server" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True">
                        </asp:DropDownList>
                    </div>
                </td>
                <td style="padding-top: 10px;">
                    <asp:CheckBox ID="chkNotaVenta" runat="server" Text="Numero" Font-Bold="True" />
                </td>
                <td style="padding-top: 10px;">
                    <asp:TextBox ID="txtNumeroNotaVenta" runat="server" Width="45" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                </td>
                <td style="padding-top: 10px">
                    <asp:CheckBox ID="chkClienteNV" runat="server" Text="Cliente" Font-Bold="True" />
                </td>
                <td style="padding-top: 10px;">
                    <asp:TextBox ID="txtClienteNV" runat="server" Width="350" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True"></asp:TextBox>
                </td>
                <td style="padding-top: 10px;">
                    <asp:CheckBox ID="chkPlacaNV" runat="server" Text="Placa" Font-Bold="True" />
                </td>
                <td style="padding-top: 10px;">
                    <asp:TextBox ID="txtPlacaNV" runat="server" Width="100" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr align="right">
                <td colspan='12' style="padding-top: 10px; padding-left: 50px;">
                    <asp:Button ID="btnBuscarNV" runat="server" Text="Buscar" class="ui-button
    ui-widget ui-state-default ui-corner-all ui-button-text-only" Font-Names="Arial" Font-Bold="True"
                        Width="120" />
                    <asp:Button ID="btnDevolverNV" runat="server" Text="Devolver" Style="display: none;"
                        class="ui-button ui-widget ui-state-default ui-corner-all
    ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnAgregarItemNV" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default
    ui-corner-all ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="120" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;" colspan='12'>
                    <div id="div_DetalleNV">
                        <div id="div2" style="padding-top: 5px;">
                            <asp:GridView ID="grvConsultaNP" runat="server" AutoGenerateColumns="False" border="0"
                                CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1050px"
                                OnRowDataBound="grvConsultaNP_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkElegir" CssClass="chkDelete" Text="" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <img id="imgMas" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click2(this);"
                                                title="Ver Detalle" />
                                            <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                                <asp:GridView ID="grvDetalle" runat="server" border="0" CellPadding="0" CellSpacing="1"
                                                    AutoGenerateColumns="False" GridLines="None" class="GridView">
                                                    <Columns>
                                                        <asp:BoundField DataField="ID" HeaderText="ID">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Codigo" HeaderText="Codigo">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Marca" HeaderText="Marca">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="UM" HeaderText="UM">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Precio" HeaderText="Precio">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="OV" HeaderText="Anexo" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Numero" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblnumero" Text='<%# Bind("Numero") %>'></asp:Label>
                                            <asp:HiddenField ID="lblCodigo" runat="server" Value='<%# Bind("Codigo") %>' />
                                            <asp:HiddenField ID="hfDetalleCargado" runat="server" Value='0' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cliente" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblcliente" Text='<%# Bind("Cliente") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Emision" HeaderText="Emision" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Moneda" HeaderText="Moneda" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TC" HeaderText="TC" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Estado" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="divFacturacionCT" style="display: none;">
        <table cellpadding="0" cellspacing="0" width="850">
            <tr>
                <td style="padding-top: 10px;">
                    <asp:CheckBox ID="chkDesdeCT" runat="server" Text="DESDE" Font-Bold="True" Checked="True" />
                </td>
                <td style="padding-left: 2px; padding-top: 10px;">
                    <asp:TextBox ID="txtDesdeCT" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="padding-top: 10px; padding-left: 2px; font-weight: bold">
                    HASTA
                </td>
                <td style="padding-top: 10px; padding-left: 2px;">
                    <asp:TextBox ID="txtHastaCT" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="font-weight: bold; padding-top: 10px; padding-left: 20px">
                    Serie
                </td>
                <td style="padding-top: 10px">
                    <div id="div_SerieCT">
                        <asp:DropDownList ID="ddlSerieCT" runat="server" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True">
                        </asp:DropDownList>
                    </div>
                </td>
                <td style="padding-top: 10px; padding-left: 20px">
                    <asp:CheckBox ID="chkCotizacion" runat="server" Text="Numero" Font-Bold="True" />
                </td>
                <td style="padding-top: 10px;">
                    <asp:TextBox ID="txtCotizacion" runat="server" Width="45" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                </td>
                <td style="padding-top: 10px; padding-left: 20px">
                    <asp:CheckBox ID="chkClienteCT" runat="server" Text="Cliente" Font-Bold="True" />
                </td>
                <td style="padding-top: 10px;">
                    <asp:TextBox ID="txtClienteCT" runat="server" Width="410" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr align="right">
                <td colspan='10' style="padding-top: 10px; padding-left: 100px;">
                    <asp:Button ID="btnBuscarCT" runat="server" Text="Buscar" class="ui-button
    ui-widget ui-state-default ui-corner-all ui-button-text-only" Font-Names="Arial" Font-Bold="True"
                        Width="120" />
                    <asp:Button ID="btnDevolverCT" runat="server" Text="Devolver" Style="display: none;"
                        class="ui-button ui-widget ui-state-default ui-corner-all
    ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnAgregarItemCT" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default
    ui-corner-all ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="120" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;" colspan='10'>
                    <div id="div_DetalleCT">
                        <asp:GridView ID="grvDetalleCT" runat="server" AutoGenerateColumns="False" border="0"
                            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1150px">
                            <Columns>
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" onclick="F_ValidarCheck_OC(this.id);" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodDetalle" Text='<%# Bind("CodDetalle") %>'></asp:Label>
                                        <asp:HiddenField ID="hfCodArticulo" runat="server" Value='<%# Bind("CodArticulo") %>' />
                                        <asp:HiddenField ID="hfCodUndMedida" runat="server" Value='<%# Bind("CodUndMedida") %>' />
                                        <asp:HiddenField ID="hfCodMovimiento" runat="server" Value='<%# Bind("CodMovimiento") %>' />
                                        <asp:HiddenField ID="hfSerieDoc" runat="server" Value='<%# Bind("SerieDoc") %>' />
                                        <asp:HiddenField ID="hfNumeroDoc" runat="server" Value='<%# Bind("NumeroDoc") %>' />
                                        <asp:HiddenField ID="hfCostoUnitario" runat="server" Value='<%# Bind("CostoUnitario") %>' />
                                        <asp:HiddenField ID="hfFechaAnexo" runat="server" Value='<%# Bind("FechaAnexo") %>' />
                                        <asp:HiddenField ID="hfCodCtaCTe" runat="server" Value='<%# Bind("CodCtaCte") %>' />
                                        <asp:HiddenField ID="hfNroRuc" runat="server" Value='<%# Bind("NroRuc") %>' />
                                        <asp:HiddenField ID="hfPrecio" runat="server" Value='<%# Bind("Precio") %>' />
                                        <asp:HiddenField ID="hfCodMoneda" runat="server" Value='<%# Bind("CodMoneda") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Numero">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNumero" Text='<%# Bind("Numero") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cliente" HeaderText="Cliente">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Codigo">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Producto">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblProducto" Text='<%# Bind("Producto") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marca">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblMarca" Text='<%# Bind("Marca")
    %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCantidad" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="UM" HeaderText="UM">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Precio">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPrecio" Text='<%# Bind("Precio") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Moneda" HeaderText="Mon">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IMPORTE" HeaderText="IMPORTE" Visible="false">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Acuenta" Visible="false">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblAcuenta" Text='<%# Bind("Acuenta") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtCantidadEntregada" Width="55px" CssClass="ccsestilo"
                                            Style="text-align: center;" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"
                                            onblur="F_ValidarStockGrillaCT(this.id);" Enabled="False" ReadOnly="false"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_ImpresorasNotaPedido" style="display: none;">
        <div class="ui-jqdialog-content">
            <table>
                <tr>
                    <td style="font-weight: bold">
                        Impresora
                    </td>
                    <td style="padding-left: 3px;">
                        <div id="div_ComboImpresoraNotaPedido">
                            <asp:DropDownList ID="ddlImpresoraNotaPedido" runat="server" Font-Names="Arial" ForeColor="Blue"
                                Font-Bold="True" Width="250">
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td style="font-weight: bold">
                        <asp:Button ID="btnImprimirPedidos" runat="server" Text="Imprimir" class="ui-button ui-widget
    ui-state-default ui-corner-all ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="120" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="div_Editar" style="display: none;">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                EDICION Datos de LA Factura
            </div>
            <table>
        
                <tr>
                    <td style="font-weight: bold">
                        <asp:Label ID="lblTipoFacturaEdicion" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtNroFacturaEditar" runat="server" Width="80px" ReadOnly="True"
                                        Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Cliente
                                </td>
                                <td style="padding-left: 19px">
                                    <asp:TextBox ID="txtClienteEditar" runat="server" Width="270px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Nro. OC
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNroOCEdicion" runat="server" Width="80px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <%--<td style="font-weight: bold">
                                    Nro. Oper.
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNroOperacionEdicion" runat="server" Width="80px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>--%>
                                <td style="width: 150px">
                                    <asp:CheckBox ID="chkComisionableEdicion" runat="server" Text="Comisionable" Font-Bold="True" />
                                </td>
                                <td style="width: 150px">
                                    <asp:CheckBox ID="chkMotorizadoEdicion" runat="server" Text="Motorizado" Font-Bold="True" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Emision
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtEmisionEdicion" runat="server" Width="80px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="true" Enabled="false"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold;">
                                    Recepcion
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRecepcion" runat="server" Width="80px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Forma Pago
                                </td>
                                <td>
                                    <div id="div_FormaPagoEdicion">
                                        <asp:DropDownList ID="ddlFormaPagoEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                            Font-Bold="True" Width="85">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td style="font-weight: bold">
                                    Vencimiento
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVencimientoEdicion" runat="server" Width="80px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True" CssClass="Jq-ui-dtp" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        KM
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td >
                                    <asp:TextBox ID="txtKMEdicion" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                                <td id="div_Placa1Edicion1" style="font-weight: bold">
                                    Veh.
                                </td>
                                <td id="div_Placa1Edicion2">
                                    <asp:TextBox ID="txtPlaca1Edicion" runat="server" Width="80px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <%--<td id="div_Placa2Edicion1" style="font-weight: bold">
                                    Placa 2
                                </td>--%>
                                <td id="div_Placa2Edicion2">
                                    <asp:TextBox ID="txtPlaca2Edicion" runat="server" Width="80px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                               <%-- <td id="div_Placa3Edicion1" style="font-weight: bold">
                                    Placa3
                                </td>--%>
                                <td id="div_Placa3Edicion2">
                                    <asp:TextBox ID="txtPlaca3Edicion" runat="server" Width="80px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                               <%-- <td id="div_Placa4Edicion1" style="font-weight: bold">
                                    Placa 4
                                </td>--%>
                                <td id="div_Placa4Edicion2">
                                    <asp:TextBox ID="txtPlaca4Edicion" runat="server" Width="80px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                 <td style="font-weight: bold;">
                        Requerimiento
                    </td>
                       <td>
                                    <asp:TextBox ID="txtRequerimientoEdicion" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                               <%-- <td id="div_Placa5Edicion1" style="font-weight: bold">
                                    Placa 5
                                </td>--%>
                              <%--  <td id="div_Placa5Edicion2">
                                    <asp:TextBox ID="txtPlaca5Edicion" runat="server" Width="80px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>--%>
                                   <%-- <td id="div_Placa5Edicion1" style="font-weight: bold">
                                    Placa 5
                                </td>--%>
                               <%-- <td id="div_Placa6Edicion2">
                                    <asp:TextBox ID="txtPlaca6Edicion" runat="server" Width="80px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>--%>
                                   <%-- <td id="div_Placa5Edicion1" style="font-weight: bold">
                                    Placa 5
                                </td>--%>
                              <%--  <td id="div_Placa7Edicion2">
                                    <asp:TextBox ID="txtPlaca7Edicion" runat="server" Width="80px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>--%>
                                   <%-- <td id="div_Placa5Edicion1" style="font-weight: bold">
                                    Placa 5
                                </td>--%>
                               <%-- <td id="div_Placa8Edicion2">
                                    <asp:TextBox ID="txtPlaca8Edicion" runat="server" Width="80px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>--%>
                            </tr>
                        </table>
                    </td>
                </tr>


         

                
                 <tr>
                <td style="font-weight: bold">
                VENDEDOR
                </td>
                <td>
                <table>
                <tr>
                 <td>
                     <div id="div_VendedorEdicion">
                          <asp:DropDownList ID="ddlVendedorEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                               Font-Bold="True" Width="200">
                                </asp:DropDownList>
                     </div>
                </td>
                 <td style="font-weight: bold">
                                    Nombre Agencia
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNombreAgencia" runat="server" Width="150px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Guia Agencia
                                </td>
                                <td style="padding-left:12px;">
                                    <asp:TextBox ID="txtGuiaAgencia" runat="server" Width="80px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold;">
                                    Clave Agencia
                                </td>
                                <td>
                                    <asp:TextBox ID="txtClaveAgencia" runat="server" Width="58px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                </tr>
                </table>
                </td>
               
              
                </tr>

                   <tr>
                    <td id="Td1" style="font-weight: bold;">
                        Observacion
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td id="Td2" >
                                    <asp:TextBox ID="txtObservacionEdicion" runat="server" Width="820px" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
               
            </table>
            <div id="div_trResponsableNPEdicion" >
                    <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                        DATOS DEL RESPONSABLE DE LA NOTA DE PEDIDO
                    </div>
                    <div>
                        <table cellpadding="0" cellspacing="0" class="form-inputs" width="750">
                            <tr id="trResponsableNPEdicion">
                                <td>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="font-weight: bold;">
                                                Autorizo
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtResponsable1Edicion" runat="server" Width="250px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold;">
                                                DNI
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtResponsableDNI1Edicion" runat="server" Width="60px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold; padding-left: 22px">
                                               Entregado
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtResponsable2Edicion" runat="server" Width="250px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold;">
                                                DNI
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtResponsableDNI2Edicion" runat="server" Width="60px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            <div id="div_GuiaRemision" class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                Edicion de Datos de la guia REMISION
            </div>
            <div id="div_GuiaRemision2" ="ui-jqdialog-content">
                  <table cellpadding="0" cellspacing="0" width="750" class="form-inputs">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkGuiaEdicion" runat="server" Text="Guia Serie" Font-Bold="True" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div id="div_serieguiaEdicion">
                                                        <asp:DropDownList ID="ddlSerieGuiaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True">
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNumeroGuiaEdicion" runat="server" Width="50" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                                 <td>
                                                                <div id="div_TipoTransportistaEdicion">
                                                                    <asp:DropDownList ID="ddlTipoTransportistaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                        Font-Bold="True">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </td>
                                                <td style="font-weight: bold; padding-left: 10px;">
                                                    Fecha
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFechaTrasladoEdicion" runat="server" Width="56px" CssClass="Jq-ui-dtp"
                                                        Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                                <td style="font-weight: bold;">
                                                    LlEGADA
                                                </td>
                                                <td style="padding-left: 20px;">
                                                    <asp:TextBox ID="txtDestinoEdicion" runat="server" Width="445px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold">
                                        Transportista
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                             <td>
                                               <asp:TextBox ID="txtNroRucTransportistaEdicion" runat="server" Width="70px" Font-Names="Arial"
                                                 ForeColor="Blue" Font-Bold="True" MaxLength="11" onblur="F_ValidaRucTransportistaEdicion(); return false;"></asp:TextBox>
                                             </td>
                                             <td id="td_loadingTransportistaEdicion" style="font-weight: bold; padding-left: 5px; display: none">
                                                  <img src="../Asset/images/loading.gif" />
                                             </td>
                                               <td>
                                                    <asp:TextBox ID="txtTransportistaEdicion" runat="server" Width="222px" Font-Names="Arial"
                                                      ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                               </td>

                                                <td style="font-weight: bold;">
                                                                Distrito
                                                            </td>
                                                           <td style="padding-left: 20px;">
                                                        <asp:TextBox ID="txtDistritoTransportistaEdicion" runat="server" Width="445" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                               
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="font-weight: bold">
                                        Direccion
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                
                                                 <td>
                                                     <asp:TextBox ID="txtDireccionTransportistaEdicion" Style="position: absolute;" runat="server" Width="300px" Font-Names="Arial"
                                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                                    <asp:DropDownList ID="dllDireccionTransportistaEdicion" Style="width: 300px" runat="server">
                                                        </asp:DropDownList>
                                                            </td>
                                                <td style="font-weight: bold;">
                                                    Placa
                                                </td>
                                                <td style="padding-left: 36px;">
                                                   <asp:TextBox ID="txtPlacaTrasladoEdicion" runat="server" Width="80" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                </td>
                                                <td style="font-weight: bold">
                                                    Marca
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="txtMarcaGuiaEdicion" runat="server" Width="100" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                </td>
                                                <td style="font-weight: bold">
                                                    Licencia
                                                </td>
                                                <td style="">
                                                                <asp:TextBox ID="txtLicenciaGuiaEdicion" runat="server" Width="156" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                            </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                            <td style="font-weight: bold">
                                                                N° Bultos
                                                            </td>
                                                            
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                       <td>
                                                                <asp:TextBox ID="txtNuBultosEdicion" runat="server" Width="80" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                            </td>
                                                            <td style="font-weight: bold;padding-left:9px;">
                                                                Peso
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPesoEdicion" runat="server" Width="80" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                            </td>
                                                                 <td>
                                                                <div id="div_codunidadpesoedicion">
                                                                    <asp:DropDownList ID="ddlcodunidadpesoedicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                        Font-Bold="True">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </td>
                                                <td style="font-weight: bold;">
                                                    Conductor
                                                </td>
                                                            <td>
                                                                <asp:TextBox ID="txtConductorDNIEdicion" runat="server" Width="80" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" onblur="F_ValidaRucDniConductorEdicion(); return false;"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtConductorRazonSocialEdicion" runat="server" Width="357px" Font-Names="Arial"
                                                                    ForeColor="Blue" Font-Bold="True" placeholder="NOMBRE CONDUCTOR"></asp:TextBox>
                                                            </td>
                                                          
                                                        </tr>
                                                    </table>
                                                </td>
                                               
                                            </tr>

                                         <tr>
                                            <td colspan='2'>
                                              
                                    <asp:CheckBox ID="chkImpresionGuiaEdicion" runat="server" Text="IMPRIMIR GUIA" Font-Bold="True" />
                              
                                            </td>
                                            </tr>
                            </table>
                        </td>
                    </tr>

                          
                </table>
            </div>
            <div class="linea-button">
                <asp:Button ID="btnEditarFactura" runat="server" Text="Guardar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Font-Names="Arial" Font-Bold="True" Width="120" />
            </div>
        </div>
    </div>
    <div id="div_EmailsReenvio" style="display: none;">
        <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right" style="padding-top: 10px;" colspan="2">
                        <asp:Button ID="btnReenvioMailNP" runat="server" Text="Enviar" class="ui-button
    ui-widget ui-state-default ui-corner-all ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="120" />
                    </td>
                </tr>
                <tr style="display: none">
                    <td style="padding-top: 10px; font-weight: bold">
                        Responsable
                    </td>
                    <td style="padding-top: 10px; padding-left: 10px;">
                        <asp:TextBox ID="txtResponsableReenvio" runat="server" Width="500px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; font-weight: bold">
                        Cotizacion
                    </td>
                    <td style="padding-top: 10px; padding-left: 10px;">
                        <asp:TextBox ID="txtFacturaReenvio" runat="server" Width="150px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; font-weight: bold">
                        Correo 1
                    </td>
                    <td style="padding-top: 10px; padding-left: 10px;">
                        <asp:TextBox ID="txtCorreoResponsableReenvio1" runat="server" Width="500px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; font-weight: bold">
                        Correo 2
                    </td>
                    <td style="padding-top: 10px; padding-left: 10px;">
                        <asp:TextBox ID="txtCorreoResponsableReenvio2" runat="server" Width="500px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; font-weight: bold">
                        Correo 3
                    </td>
                    <td style="padding-top: 10px; padding-left: 10px;">
                        <asp:TextBox ID="txtCorreoResponsableReenvio3" runat="server" Width="500px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; font-weight: bold">
                        Correo 4
                    </td>
                    <td style="padding-top: 10px; padding-left: 10px;">
                        <asp:TextBox ID="txtCorreoResponsableReenvio4" runat="server" Width="500px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; font-weight: bold">
                        Correo 5
                    </td>
                    <td style="padding-top: 10px; padding-left: 10px;">
                        <asp:TextBox ID="txtCorreoResponsableReenvio5" runat="server" Width="500px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; font-weight: bold">
                        Correo 6
                    </td>
                    <td style="padding-top: 10px; padding-left: 10px;">
                        <asp:TextBox ID="txtCorreoResponsableReenvio6" runat="server" Width="500px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="div_CorreosEdicion" style="display: none">
        <table cellpadding="0" cellspacing="0" class="form-inputs">
            <tr>
                <td style="font-weight: bold">
                    Cliente
                </td>
                <td>
                    <asp:TextBox ID="txtEdicionMail_Cliente" runat="server" Width="450px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Distrito
                </td>
                <td>
                    <asp:TextBox ID="txtEdicionMail_Distrito" runat="server" Width="450px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Direccion
                </td>
                <td>
                    <asp:TextBox ID="txtEdicionMail_Direccion" runat="server" Width="450px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr style="padding-top: 10px;">
                <td style="padding-top: 5px; font-weight: bold">
                    Email 1
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEdicionMail_Email1" runat="server" Width="450px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email 2
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEdicionMail_Email2" runat="server" Width="450px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email 3
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEdicionMail_Email3" runat="server" Width="450px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email 4
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEdicionMail_Email4" runat="server" Width="450px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email 5
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEdicionMail_Email5" runat="server" Width="450px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email 6
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEdicionMail_Email6" runat="server" Width="450px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    <asp:Button ID="btnActualizarEmails" runat="server" Text="Actualizar" class="ui-button ui-widget ui-state-default ui-corner-all
    ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="120" />
                </td>
            </tr>
        </table>
    </div>
    <div id="div_EnvioCorreos" style="padding-top: 5px; display: none">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                    <tbody>
                        <tr>
                            <td style="font-weight: bold">
                                Documento
                            </td>
                            <td>
                                <asp:TextBox ID="txtDocumentoDisplayRC" runat="server" Width="100" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold">
                                Cliente
                            </td>
                            <td>
                                <asp:TextBox ID="txtClienteDisplayRC" runat="server" Width="330" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan='4'>
                                <span style="color:Red; font-weight:bold">--EL REENVIO-- DE LOS CORREOS SE HARA A LOS CORREOS QUE SE ENCUENTREN REGISTRADOS
                                EN EL MAESTRO DE CLIENTES, EN LA DIRECCION DEL DOCUMENTO </span>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="linea-button" style="padding-right: 12px">
                <asp:Button ID="btnHacerReenvio" runat="server" Text="Reenviar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Font-Names="Arial" Font-Bold="True" Width="120" />
            </div>
        </div>
          <div id="div_grvCorreos">
                <asp:GridView ID="grvConsultaCorreos" runat="server" AutoGenerateColumns="False"
                    border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                    Width="560px" >
                    <Columns>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkCorreo" Text="" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Correo" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCorreo" Text='<%# Bind("Correo") %>'></asp:Label>
                                <asp:HiddenField ID="hfCodCtaCte" runat="server" Value='<%# Bind("CodCtaCte") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div id="div_grvEnvioCorreos" >
                <asp:GridView ID="grvConsultaEnvioCorreos" runat="server" AutoGenerateColumns="False"
                    border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                    Width="560px" OnRowDataBound="grvConsultaEnvioCorreos_RowDataBound">
                    <Columns>
                        <%--                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" >
                            <HeaderTemplate>
                                <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <img id="imgMas" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click3(this);"
                                    title="Ver Detalle" />
                                <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                    <asp:GridView ID="grvDetalle" runat="server" border="0" CellPadding="0" CellSpacing="1"
                                        AutoGenerateColumns="False" GridLines="None" class="GridView">
                                        <Columns>
                                            <asp:BoundField DataField="Email" HeaderText="Email">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Estado" HeaderText="Estado">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblFecha" Text='<%# Bind("Fecha") %>'></asp:Label>
                                <asp:HiddenField ID="hfIdTransaccion" runat="server" Value='<%# Bind("IdTransaccion") %>' />
                                <asp:HiddenField ID="hfCodUsuario" runat="server" Value='<%# Bind("CodUsuario") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Usuario" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblUsuario" Text='<%# Bind("NombreUsuario") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CantidadDestinatarios" HeaderText="Destinatarios" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Enviados" HeaderText="Enviados" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
    </div>
    <%--POR DESARROLLAR--%>
    <div id="div3" style="display: none">
        <table cellpadding="0" cellspacing="0" class="form-inputs">
            <tr style="padding-top: 10px;">
                <td style="padding-top: 5px; font-weight: bold">
                    Email 1
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEnvioMail_Email1" runat="server" Width="450px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email 2
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEnvioMail_Email2" runat="server" Width="450px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email 3
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEnvioMail_Email3" runat="server" Width="450px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email 4
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEnvioMail_Email4" runat="server" Width="450px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email 5
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEnvioMail_Email5" runat="server" Width="450px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email 6
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEnvioMail_Email6" runat="server" Width="450px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    <asp:Button ID="btnReenviarEmails_Final" runat="server" Text="Actualizar" class="ui-button ui-widget ui-state-default ui-corner-all
						ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="120" />
                </td>
            </tr>
        </table>
    </div>
        <div id="div_Anulacion" style="display: none;">
        <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="font-weight: bold">
                        ¿ PORQUE LO ESTAS ANULANDO ?
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtObservacionAnulacion" runat="server" Width="450px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True" TextMode="MultiLine" Height="80"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold; padding-top: 5px;" align="right">
                        <asp:Button ID="btnAnular" runat="server" Text="ANULAR" class="ui-button ui-widget
    ui-state-default ui-corner-all ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="120" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
        <%--ARCHIVO CDR--%>
                                        <div id="div_CDR" style="display: none">
                                            <div>
                                                <table cellpadding="0" cellspacing="0" class="form-inputs">
                                                    <tr>
                                                        <td style="font-weight: bold">
                                                            Factura
                                                        </td>
                                                        <td style="padding-left: 10px">
                                                            <asp:TextBox ID="txtFacturaCDR" runat="server" Width="200px" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight: bold">
                                                            Archivo
                                                        </td>
                                                        <td style="padding-left: 10px">
                                                            <asp:TextBox ID="txtArchivoCDR" runat="server" Width="200px" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="padding-left: 10px">
                                                            <div id="tr_btnDescargaCDR">
                                                                <asp:Button ID="btnDescargarCDR" runat="server" Text="Descargar XML CDR Y PDF" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                                    Font-Names="Arial" Font-Bold="True" Width="200" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
    <div id="dlgWait" style="background-color: #CCE6FF; text-align: center; display: none;">
        <br />
        <br />
        <center>
            <asp:Label ID="Label2" runat="server" Text="PROCESANDO..." Font-Bold="true" Font-Size="Large"
                Style="text-align: center"></asp:Label></center>
        <br />
        <center>
            <img alt="Wait..." src="../Asset/images/ajax-loader2.gif" /></center>
    </div>
    <input id="hfCodCtaCte" type="hidden" value="0" />
    <input id="hfCodCtaCteEdicion" type="hidden" value="0" />
    <input id="hfCodCtaCteConsulta" type="hidden" value="0" />
    <input id="hfCodigoTemporal" type="hidden" value="0" />
    <input id="hfCodDocumentoVenta" type="hidden" value="0" />
    <input id="hfNotaPedido" type="hidden" value="0" />
    <input id="hfCodUsuario" type="hidden" value="0" />
    <input id="hfCodDepartamento" type="hidden" value="0" />
    <input id="hfCodProvincia" type="hidden" value="0" />
    <input id="hfCodDistrito" type="hidden" value="0" />
    <input id="hfCodProforma" type="hidden" value="0" />
    <input id="hfCodTraslado" type="hidden" value="0" />
    <input id="hfPartida" type="hidden" value="" />
    <input id="hfCodNotaVenta" type="hidden" value="0" />
    <input id="hfCodSede" type="hidden" value="0" />
    <input id="hfCodTipoCliente" type="hidden" value="2" />
    <input id="hfCodDireccion" type="hidden" value="2" />
    <input id="hfCodTipoDoc2" type="hidden" value="2" />
    <input id="hfCodTipoDocEdicion" type="hidden" value="0" />
    <input id="hfApePaterno" type="hidden" value="CLIENTE" />
    <input id="hfNroRuc" type="hidden" value="" />
    <input id="hfDistrito" type="hidden" value="" />
    <input id="hfDireccion" type="hidden" value="" />
    <input id="hfCliente" type="hidden" value="" />
    <input id="hfCodTransportista" type="hidden" value="0" />
    <input id="hfCodTransportistaEdicion" type="hidden" value="0" />
    <input id="hfCodDireccionTransportista" type="hidden" value="0" />
    <input id="hfCodDireccionTransportistaEdicion" type="hidden" value="0" />
    <input id="hfCodClienteNV" type="hidden" value="0" />
    <input id="hfCodClienteCT" type="hidden" value="0" />
    <input id="hfCodFacturaEdicion" type="hidden" value="0" />
    <input id="hfCodNotaPedidoReenvioMail" type="hidden" value="0" />
    <input id="hfRedondeoAM" type="hidden" value="0" />
    <input id="hfNroItems" type="hidden" value="0" />
    <input id="hfNroItemsMax" type="hidden" value="0" />
    <input id="hfCodDireccionDefecto" type="hidden" value="0" />
    <input id="hfCodFacturaAnterior" type="hidden" value="0" />
    <input id="hfFlagReemplazotmp" type="hidden" value="0" />
    <input id="hfDireccionTransportista" type="hidden" value="0" />
    <input id="hfDireccionFacturaEditar" type="hidden" value="0" />
    <input id="hfCodDocumentoReenvioMail" type="hidden" value="0" />
    <input id="hfCodProformaReenvioMail" type="hidden" value="0" />
    <input id="hfCodtipoDocReenvioMail" type="hidden" value="0" />
        <input id="hfUbigeo" type="hidden" value="0" />
        <input id="hftokenapisunat" type="hidden" value="0" />
        <input id="hfurlapisunat" type="hidden" value="0" />
        <input id="hfCodProductoAgregar" type="hidden" value="0" />
        <input id="hfCostoAgregar" type="hidden" value="0" />
        <input id="hfCodUmAgregar" type="hidden" value="0" />
        <input id="hfMenorPrecioAgregar" type="hidden" value="0" />
        <input id="hfPrecioSoles" type="hidden" value="0" />
        <input id="hfPrecioDolares" type="hidden" value="0" />
        <input id="hfCostoSoles" type="hidden" value="0" />
        <input id="hfCostoDolares" type="hidden" value="0" />
        <input id="hfMargen" type="hidden" value="0" />
        <input id="hfRedondeo" type="hidden" value="0" />
        <input id="hfFactorRedondeo" type="hidden" value="0" />
        <input id="hfDescuento" type="hidden" value="0" />
        <input id="hfcodproductoconsulta" type="hidden" value="0" />
        <input id="hfNroRucTransportista" type="hidden" value="0" />
        <input id="hfCodCtaCteTransportista" type="hidden" value="0" />
        <input id="hfTransportista" type="hidden" value="0" />
        <input id="hfCodDepartamentoTransportista" type="hidden" value="0" />
        <input id="hfCodProvinciaTransportista" type="hidden" value="0" />
        <input id="hfCodDistritoTransportista" type="hidden" value="0" />
        <input id="hfDistritoTransportista" type="hidden" value="0" />
        <input id="hfClienteTransportista" type="hidden" value="0" />
        <input id="hfCodDocumentoVentaDescargaCDR" type="hidden" value="0" />
        <input id="hfCodtipodoctemporal" type="hidden" value="0" />
        <input id="hfCodTipoDocAnulacion" type="hidden" value="0" />
        <input id="hfCodDocumentoVentaAnulacion" type="hidden" value="0" />
        <input id="hfClienteAnulacion" type="hidden" value="0" />
        <input id="hfNumeroAnulacion" type="hidden" value="0" />
        <input id="hfCodTipoProducto" type="hidden" value="0" />
        <input id="hfDistritoTraslado" type="hidden" value="" />
        <input id="hfCodDireccionDefectoTransportista" type="hidden" value="0" />
        <input id="hfCodCtaCteTransportistaEdicion" type="hidden" value="0" />
        <input id="hfTransportistaEdicion" type="hidden" value="" />
        <input id="hfRucTransportistaEdicion" type="hidden" value="" />
        <input id="hfDireccionTransportistaEdicion" type="hidden" value="" />
        <input id="hfRazonSocialTransportistaEdicion" type="hidden" value="" />
        <input id="hfCodDepartamentoTransportistaEdicion" type="hidden" value="0" />
        <input id="hfCodProvinciaTransportistaEdicion" type="hidden" value="0" />
        <input id="hfCodDistritoTransportistaEdicion" type="hidden" value="0" />
        <input id="hfDistritoTrasladoEdicion" type="hidden" value="" />
        <input id="hfCodDireccionDefectoTransportistaEdicion" type="hidden" value="0" />
         <input id="hfCodConductor" type="hidden" value="0" />
        <input id="hfNroRucTransportistaEdicion" type="hidden" value="0" />
        <input id="hfDniConductor" type="hidden" value="0" />
        <input id="hfDestinoEdicion" type="hidden" value="0" />
</asp:Content>
