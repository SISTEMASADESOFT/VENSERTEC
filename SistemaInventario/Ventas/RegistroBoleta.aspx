<%@ Page Title="Boleta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RegistroBoleta.aspx.cs" Inherits="SistemaInventario.Ventas.RegistroBoleta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"
        type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="RegistroBoleta.js" charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        Boleta de Venta</div>
    <div id="divTabs">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
        </ul>
        <div id="tabRegistro">
            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    Datos de Factura
                </div>
                <div>
                    <table cellpadding="0" cellspacing="0" class="form-inputs" width="750">
                        <tr>
                            <td style="font-weight: bold">
                                Cliente
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtNroDni" runat="server" Width="55px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" MaxLength="8" Text="99999999"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtApePaterno" runat="server" Width="150px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Text="CLIENTE"></asp:TextBox>
                                            <asp:TextBox ID="txtApeMaterno" runat="server" Width="150px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Text="VARIOS"></asp:TextBox>
                                            <asp:TextBox ID="txtNombre" runat="server" Width="150px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                            <asp:ImageButton ID="imgAddScop" runat="server" ImageUrl="~/Asset/images/add_small.png"
                                                Style="display: none;" ImageAlign="AbsMiddle" ToolTip="Agregar Cliente" />
                                            <asp:Label ID="Label1" runat="server" Text="T.C." Font-Bold="True"></asp:Label>
                                            <asp:Label ID="lblTC" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td style="font-weight: bold">
                                            Moneda
                                        </td>
                                        <td>
                                            <div id="div_moneda">
                                                <asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Enabled="False">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="font-weight: bold">
                                            Serie
                                        </td>
                                        <td>
                                            <div id="div_serie">
                                                <asp:DropDownList ID="ddlSerie" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td id="divNumero" style="display: none">
                                            <asp:TextBox ID="txtNumero" runat="server" Width="43" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Igv (%)
                                        </td>
                                        <td>
                                            <div id="div_igv">
                                                <asp:DropDownList ID="ddlIgv" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="60">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Distrito
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtDistrito" runat="server" Width="200px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Text="AREQUIPA CARAVELI CHALA"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Direccion
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDireccion" runat="server" Width="254px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Text="AREQUIPA"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Emision
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmision" runat="server" Width="55px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            cond.
                                        </td>
                                        <td colspan="2">
                                            <div id="div_formapago">
                                                <asp:DropDownList ID="ddlFormaPago" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="80">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="font-weight: bold">
                                            vcto
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVencimiento" runat="server" Width="56px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkImpresion" runat="server" Text="Imprimir" Checked="True" Font-Bold="True" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    Datos de la guia
                </div>
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" width="750" class="form-inputs">
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkGuia" runat="server" Text="guia" Font-Bold="True" />
                            </td>
                            <td style="font-weight: bold; padding-left: 5px;">
                                Serie
                            </td>
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
                            <td style="font-weight: bold; padding-left: 5px;">
                                Fecha
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaTraslado" runat="server" Width="56px" CssClass="Jq-ui-dtp"
                                    Font-Names="Arial" ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold; padding-left: 5px;">
                                Destino
                            </td>
                            <td>
                                <asp:TextBox ID="txtDestino" runat="server" Width="635px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold; display: none;">
                                Vendedor
                            </td>
                            <td style="font-weight: bold; display: none;">
                                <div id="div_Vendedor">
                                    <asp:DropDownList ID="ddlVendedor" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="linea-button">
                    <table cellpadding="0" cellspacing="0" width="850" class="form-inputs">
                        <tr>
                            <td>
                                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                            </td>
                            <td>
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                            </td>
                            <td>
                                <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                            </td>
                            <td>
                                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                            </td>
                            <td>
                                <asp:CheckBox ID="chkImpresion2" runat="server" Text="Imprimir" Checked="True" Font-Bold="True" />
                            </td>
                            <td>
                                SubTotal
                            </td>
                            <td>
                                <asp:TextBox ID="txtSubTotal" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" ReadOnly="True" Text="0.00"></asp:TextBox>
                            </td>
                            <td>
                                Igv
                            </td>
                            <td>
                                <asp:TextBox ID="txtIgv" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" ReadOnly="True" Text="0.00"></asp:TextBox>
                            </td>
                            <td>
                                total
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotal" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" ReadOnly="True" Text="0.00"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="div_grvDetalleArticulo" style="padding-top: 5px;">
                <asp:GridView ID="grvDetalleArticulo" runat="server" AutoGenerateColumns="False"
                    border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                    Width="1017px">
                    <Columns>
                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblcoddetalle" Text='<%# Bind("CodDetalle") %>'></asp:Label>
                                <asp:HiddenField ID="hfcodarticulo" runat="server" Value='<%# Bind("CodArticulo") %>' />
                                <asp:HiddenField ID="hfPrecio" runat="server" Value='<%# Bind("Precio") %>' />
                                <asp:HiddenField ID="hfCantidad" runat="server" Value='<%# Bind("Cantidad") %>' />
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
                        <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtCantidad" Width="75px" Font-Bold="true" Style="text-align: center;"
                                    CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Cantidad") %>'
                                    onblur="F_ActualizarCantidad(this.id); return false;"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="UM" HeaderText="UM">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Precio" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtPrecio" Width="75px" Font-Bold="true" Style="text-align: center;"
                                    CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Precio") %>'
                                    onblur="F_ActualizarPrecio(this.id); return false;"></asp:TextBox>
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
        <div id="tabConsulta">
            <div id='divConsulta' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    Criterio de busqueda
                </div>
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" class="form-inputs">
                        <tr>
                            <td style="font-weight: bold;">
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
                                    Font-Bold="True" CssClass="Jq-ui-dtp"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtHasta" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" CssClass="Jq-ui-dtp"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkCliente" runat="server" Text="Cliente" Font-Bold="True" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtClienteConsulta" runat="server" Width="485" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="linea-button">
                    <asp:Button ID="btnBuscarConsulta" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </div>
            </div>
            <div id="div_consulta" style="padding-top: 5px;">
                <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                    CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1005px"
                    OnRowDataBound="grvConsulta_RowDataBound">
                    <Columns>
                        <%--                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEliminarDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                    ToolTip="Eliminar Factura" OnClientClick="F_EliminarRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/Eliminar.jpg"
                                    ToolTip="Anular Documento" OnClientClick="F_AnularRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TK">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgTCK" ImageUrl="~/Asset/images/imprimir.gif"
                                    ToolTip="Imprimir Ticket" OnClientClick="F_ImprimirFacturaHTML(undefined,this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--                        <asp:TemplateField HeaderText="Guia">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgImprimir" ImageUrl="~/Asset/images/imprimir.gif"
                                    ToolTip="Imprimir Guia" OnClientClick="F_ImprimirGuia(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Bol">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgPdf" ImageUrl="~/Asset/images/pdf.png" ToolTip="Imprimir Boleta"
                                    OnClientClick="ImprimirFacturaDetalle(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <img id="imgMas" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click(this);"
                                    title="Ver Detalle" />
                                <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                    <asp:GridView runat="server" ID="grvDetalle" border="0" CellPadding="0" CellSpacing="1"
                                        GridLines="None" class="GridView" />
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Numero">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblnumero" Text='<%# Bind("Numero") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cliente">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblcliente" Text='<%# Bind("Cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Emision" HeaderText="Emision">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Condicion" HeaderText="Condicion">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Vencimiento" HeaderText="Vcto">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Moneda" HeaderText="Moneda">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TC" HeaderText="TC">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SubTotal" HeaderText="SubTotal">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Igv" HeaderText="Igv">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Total" HeaderText="Total">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Guia" HeaderText="Guia">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Estado">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Est. Sunat">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEstadoSunat" Text='<%# Bind("EstatusSunat") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Correo Sunat">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCorreoSunat" Text='<%# Bind("CorreoSunat") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
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
                            <td>
                                <asp:CheckBox ID="chkServicios" runat="server" Text="Servicios" Font-Bold="True" />
                            </td>
                            <td>
                                <asp:CheckBox ID="chkNotaPedido" runat="server" Text="nota pedido" Font-Bold="True" />
                            </td>
                            <td style="padding-left: 5px; font-weight: bold">
                                Descripcion
                            </td>
                            <td>
                                <asp:TextBox ID="txtArticulo" runat="server" Width="600px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="linea-button">
                <asp:Button ID="btnBuscarArticulo" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Font-Names="Arial" Font-Bold="True" Width="120" />
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Font-Names="Arial" Font-Bold="True" Width="120" />
            </div>
        </div>
        <div id="div_grvConsultaArticulo" style="padding-top: 5px;">
            <asp:GridView ID="grvConsultaArticulo" runat="server" AutoGenerateColumns="False"
                border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                Width="975px">
                <Columns>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkOK" CssClass="chkSi" Text="" onclick="F_ValidarCheck(this.id);" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ID">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblcodproducto" Text='<%# Bind("CodProducto") %>'></asp:Label>
                            <asp:HiddenField ID="hfcodunidadventa" runat="server" Value='<%# Bind("CodUnidadVenta") %>' />
                            <asp:HiddenField ID="hfcosto" runat="server" Value='<%# Bind("Costo") %>' />
                            <asp:HiddenField ID="hfDescuento" runat="server" Value='<%# Bind("Descuento") %>' />
                            <asp:HiddenField ID="hfCodFamilia" runat="server" Value='<%# Bind("CodFamilia") %>' />
                            <asp:HiddenField ID="hfCostoProductoSoles" runat="server" Value='<%# Bind("CostoProductoSoles") %>' />
                            <asp:HiddenField ID="hfCostoProductoDolares" runat="server" Value='<%# Bind("CostoProductoDolares") %>' />
                            <asp:HiddenField ID="hfMargen" runat="server" Value='<%# Bind("Margen") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Codigo">
                        <ItemStyle Font-Bold="true" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlkCodigo" Font-Underline="true" ForeColor="Blue"
                                Style="cursor: hand" Text='<%# Bind("CodigoProducto") %>' onclick="F_VerUltimoPrecio(this.id); return false;"
                                ToolTip="Ver Series">
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Producto" HeaderText="Producto">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Chala1">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblChala1" Text='<%# Bind("Chala1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Chala2">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblChala2" Text='<%# Bind("Chala2") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="UM" HeaderText="UM">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Dolares">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPrecioDolares" Text='<%# Bind("PrecioDolares") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Soles">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPrecioSoles" Text='<%# Bind("PrecioSoles") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TipoCambio" HeaderText="TC">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MargenVenta" HeaderText="Margen">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Descuento" HeaderText="Dscto-Max">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Precio" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtPrecio" Width="55px" Font-Bold="true" Style="text-align: center;"
                                CssClass="ccsestilo" Font-Names="Arial" onblur="F_ValidarPrecioGrilla(this.id);"
                                ForeColor="Blue" Enabled="False"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dscto" ItemStyle-HorizontalAlign="Center">
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
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
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
    <div id="div_ultimoprecio" style="display: none;">
        <div class="ui-jqdialog-content">
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
                            Font-Bold="True" Font-Size="Small"></asp:TextBox>
                    </td>
                    <td style="font-weight: bold">
                        Cantidad
                    </td>
                    <td>
                        <asp:TextBox ID="txtCantidadPrecio" runat="server" Width="80px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True" Font-Size="Small"></asp:TextBox>
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
    <div id="divFacturacionOC" style="display: none;">
        <table cellpadding="0" cellspacing="0" width="850">
            <tr>
                <td align="right" style="padding-top: 10px;">
                    <asp:Button ID="btnDevolverItemOC" runat="server" Text="Devolver" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" ForeColor="Blue" Font-Bold="True" />
                    <asp:Button ID="btnAgregarItemOC" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" ForeColor="Blue" Font-Bold="True" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;">
                    <div id="div_DetalleOC">
                        <asp:GridView ID="grvDetalleOC" runat="server" AutoGenerateColumns="False" border="0"
                            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="860px"
                            Height="400">
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
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OC">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNumero" Text='<%# Bind("Numero") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
    <input id="hfCodCtaCte" type="hidden" value="29" />
    <input id="hfCodCtaCteConsulta" type="hidden" value="0" />
    <input id="hfCodigoTemporal" type="hidden" value="0" />
    <input id="hfCodDocumentoVenta" type="hidden" value="0" />
    <input id="hfCodUsuario" type="hidden" value="0" />
    <input id="hfCodNotaVenta" type="hidden" value="0" />
    <input id="hfCodSede" type="hidden" value="0" />
    <input id="hfCodDepartamento" type="hidden" value="3" />
    <input id="hfCodProvincia" type="hidden" value="14" />
    <input id="hfCodDistrito" type="hidden" value="93" />
    <input id="hfApePaterno" type="hidden" value="CLIENTE" />
</asp:Content>
