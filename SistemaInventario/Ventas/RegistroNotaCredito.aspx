<%@ Page Title="Nota de Credito-Venta" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="RegistroNotaCredito.aspx.cs" Inherits="SistemaInventario.Ventas.RegistroNotaCredito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js" type="text/javascript"></script>       
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="RegistroNotaCredito.js" charset="UTF-8"></script>       
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />       
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        Nota de Credito - VENTA</div>
    <div id="divTabs">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
        </ul>
        <div id="tabRegistro">
            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    REGISTRO
                </div>
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" class="form-inputs">
                           <tr>
                            <td style="font-weight: bold">
                                Razon Social
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtCliente" runat="server" Width="305px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" ReadOnly="False"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="T.C." Font-Bold="True"></asp:Label>
                                            <asp:Label ID="lblTC" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td style="font-weight: bold">
                                            TIPO DOC
                                        </td>
                                        <td>
                                            <div id="div_tipodocumento">
                                                <asp:DropDownList ID="ddlTipoDocumento" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="110">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                         <td style="font-weight: bold">
                                            Num. Rel
                                        </td>

                                        <td>
                                          <asp:TextBox ID="txtNumeroRelacionado" runat="server" Width="100" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" ReadOnly="True"></asp:TextBox>
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
                                            <asp:TextBox ID="txtNumero" runat="server" Width="50" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                       
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Operacion
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div id="div_TipoOperaciones">
                                                <asp:DropDownList ID="ddlTipoOperaciones" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="padding-left: 20px; font-weight: bold">
                                            Moneda
                                        </td>
                                        <td style="padding-left: 6px;">
                                            <div id="div_moneda">
                                                <asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="85px">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                                          <td style="font-weight: bold">
                                            Emision
                                        </td>
                                        <td style="padding-left: 58px;">
                                            <asp:TextBox ID="txtEmision" runat="server" Width="55px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            condicion pago
                                        </td>
                                        <td style="padding-left: 13px;">
                                            <div id="div_formapago">
                                                <asp:DropDownList ID="ddlFormaPago" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="104">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="font-weight: bold">
                                            vcto
                                        </td>
                                        <td style="padding-left: 5px;">
                                            <asp:TextBox ID="txtVencimiento" runat="server" Width="55px" CssClass="Jq-ui-dtp"
                                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
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
                            Observacion
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtObservacion" runat="server" Width="466px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                      
                                        
                                        <td style="font-weight: bold;">
                                            SubTotal
                                        </td>
                                        <td style="font-weight: bold;padding-left: 48px;">
                                            <asp:TextBox ID="txtSubTotal" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" CssClass="Derecha" ReadOnly="True" Text="0.00"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Igv
                                        </td>
                                        <td style="font-weight: bold">
                                            <asp:TextBox ID="txtIgv" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" CssClass="Derecha" ReadOnly="True" Text="0.00"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            total
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotal" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" CssClass="Derecha" ReadOnly="True" Text="0.00"></asp:TextBox>
                                        </td>
                                     

                                        <td style="padding-left: 2px; display: none;">
                                            <asp:TextBox ID="txtAcuenta" runat="server" Width="82px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" CssClass="Derecha" ReadOnly="True" Text="0.00"></asp:TextBox>
                                        </td>

                                          <td style="padding-left: 48px; font-weight: bold; display: none;">
                                            <asp:TextBox ID="txtAcuentaNV" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" CssClass="Derecha" ReadOnly="True" Text="0.00"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 81px; font-weight: bold; display: none;">
                                            ACUENTA
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="linea-button">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnFactura" runat="server" Text="Factura" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </div>
            </div>
            <div id="div_grvDetalleArticulo" style="padding-top: 5px;">
                <asp:GridView ID="grvDetalleArticulo" runat="server" AutoGenerateColumns="False"
                    border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                    Width="1017px">
                    <Columns>


                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">

                           <HeaderTemplate>
                              <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                          </HeaderTemplate>

                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" />
                            </ItemTemplate>


                        </asp:TemplateField>



                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="~/Asset/images/btnEdit.gif"
                                    ToolTip="Editar Registro" OnClientClick="F_EditarRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID">
                            <ItemStyle Font-Bold="true" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="lblCodDetalle" Font-Underline="true" ForeColor="Blue"
                                    Style="cursor: hand" Text='<%# Bind("CodDetalle") %>' onclick="F_VerSeries(this.id); return false;"
                                    ToolTip="Ver Series">
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Codigo">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("CodigoProducto") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Producto">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblProducto" Text='<%# Bind("Producto") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="Marca" HeaderText="Marca" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Cantidad">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCantidad" Text='<%# Bind("Cantidad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UM">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblUM" Text='<%# Bind("UM") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Precio">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblPrecio" Text='<%# Bind("Precio") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Importe">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblImporte" Text='<%# Bind("Importe") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Acuenta" Visible="FALSE">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblAcuenta" Text='<%# Bind("Acuenta") %>'></asp:Label>
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
                        <tbody>
                            <tr>
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
                                    <asp:TextBox ID="txtClienteConsulta" runat="server" Width="485" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </tbody>
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
                       <%-- <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEliminarDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                    ToolTip="Eliminar Documento" OnClientClick="F_EliminarRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/Eliminar.jpg"
                                    ToolTip="ANULAR NOTA DE CREDITO" OnClientClick="F_AnularRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <%--    <asp:TemplateField HeaderText="TK">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgTCK2" ImageUrl="~/Asset/images/imprimir.gif"
                                    ToolTip="Imprimir Ticket" OnClientClick="F_ImprimirFacturaHTML(undefined,this,'imgTCK2','TK'); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="IMP">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgTCK" ImageUrl="~/Asset/images/imprimir.gif"
                                    ToolTip="Imprimir Ticket" OnClientClick="F_ImprimirFacturaHTML(undefined,this,'imgTCK','IMP'); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PDF">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgPdf" ImageUrl="~/Asset/images/pdf.png" ToolTip="Imprimir Nota de Credito"
                                    OnClientClick="F_ImprimirFacturaHTML(undefined,this,'imgPdf','PDF'); return false;" />
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
<%--                        <asp:TemplateField HeaderText="ID">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Numero" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblNumero" Text='<%# Bind("Numero") %>'></asp:Label>
                                <asp:HiddenField ID="lblCodigo" runat="server" Value='<%# Bind("Codigo") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cliente" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCliente" Text='<%# Bind("Cliente") %>'></asp:Label>
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
                        <asp:BoundField DataField="Vencimiento" HeaderText="Vcto" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Moneda" HeaderText="Moneda" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TC" HeaderText="TC" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Total" HeaderText="Total" HeaderStyle-HorizontalAlign="Center"
                            DataFormatString="{0:N2}">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Factura" HeaderText="Factura" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Estado" HeaderStyle-HorizontalAlign="Center">
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
    <div id="div_Factura" style="display: none;">
        <div class="ui-jqdialog-content">
            <table>
                <tr>
                    <td style="font-weight: bold">
                        Numero Factura
                    </td>
                    <td style="padding-left: 5px;">
                        <asp:TextBox ID="txtCodFactura" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True" Font-Size="Small"></asp:TextBox>
                    </td>
                    <td style="padding-left: 10px;">
                        <asp:Button ID="btnFacturarNotaCredito" runat="server" Text="Facturar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="div_Mantenimiento" style="display: none;">
        <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0" class="form-inputs">
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnGrabarEdicion" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px;">
                        Codigo
                    </td>
                    <td style="padding-top: 10px; padding-left: 4px;">
                        <asp:TextBox ID="txtCodigo" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Descripcion
                    </td>
                    <td style="padding-left: 4px;">
                        <asp:TextBox ID="txtDescripcion" runat="server" Width="300px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Cantidad
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCantidad" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="padding-left: 40px;">
                                    UM
                                </td>
                                <td style="padding-left: 36px;">
                                    <asp:TextBox ID="txtUM" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        Precio
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtPrecio" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="padding-left: 40px;">
                                    Importe
                                </td>
                                <td style="padding-left: 4px;">
                                    <asp:TextBox ID="txtImporte" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="div_SerieDetalle" style="display: none;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="padding-top: 5px;">
                    <div id="div_GrillaSerieDetalle">
                        <asp:GridView ID="grvSerieDetalle" runat="server" AutoGenerateColumns="False" border="0"
                            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="360px">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgEliminar" ImageUrl="~/Asset/images/Eliminar.jpg"
                                            ToolTip="Eliminar" OnClientClick="F_EliminarSerie(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblID" Text='<%# Bind("ID") %>'></asp:Label>
                                        <asp:HiddenField ID="hfCodDetDocumentoVenta" runat="server" Value='<%# Bind("CodDetDocumentoVenta") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Serie" HeaderText="Serie">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
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
    <input id="hfCodCtaCte" type="hidden" value="0" />
    <input id="hfCodigoTemporal" type="hidden" value="0" />
    <input id="hfCodDocumentoVenta" type="hidden" value="0" />
    <input id="hfCodCtaCteConsulta" type="hidden" value="0" />
    <input id="hfCodDetalle" type="hidden" value="0" />
    <input id="hfSerie" type="hidden" value="0" />
    <input id="hfCantidad" type="hidden" value="0" />
    <input id="hfPrecio" type="hidden" value="0" />
</asp:Content>
