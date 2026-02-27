<%@ Page Title="Ajuste" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RegistroAjuste.aspx.cs" Inherits="SistemaInventario.Compras.RegistroAjuste" %>

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
    <script type="text/javascript" language="javascript" src="RegistroAjuste.js" charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo" style="width: 1200px">
        Ajuste de Inventario</div>
    <div id="tabRegistro" style="width: 1200px">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                Registro de Ajuste
            </div>
            <div id="divConsultaArticulo">
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" width="1200" class="form-inputs">
                        <tr>
                            <td style="font-weight: bold">
                                Descripcion
                            </td>
                            <td>
                                <asp:TextBox ID="txtArticulo" runat="server" Width="807px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="linea-button">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Font-Names="Arial" Font-Bold="True"
                    class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Width="120" />
                <asp:Button ID="btnAgregar" runat="server" Text="Grabar" Font-Names="Arial" Font-Bold="True"
                    Width="120" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" />
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
                                </tr>
                            </table>
                        </div>
        <div id="div_grvConsultaArticulo" style="padding-top: 5px;">
            <asp:GridView ID="grvConsultaArticulo" runat="server" AutoGenerateColumns="False"
                border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                Width="1200px">
                <Columns>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkOK" CssClass="chkSi" Text="" onclick="F_ValidarCheck(this.id);" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Codigo">
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCodigoProducto" Text='<%# Bind("CodigoProducto") %>' CssClass="detallesart"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Producto" HeaderText="Producto">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Marca" HeaderText="Marca">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="STOCK">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblChala1" Text='<%# Bind("Chala1") %>'></asp:Label>
                            <asp:HiddenField ID="hfCodUnidadCompra" runat="server" Value='<%# Bind("CodUnidadCompra") %>' />
                            <asp:HiddenField ID="hfCodUnidadVenta" runat="server" Value='<%# Bind("CodUnidadVenta") %>' />
                            <asp:HiddenField ID="hfFactor" runat="server" Value='<%# Bind("Factor") %>' />
                            <asp:HiddenField ID="hfCodProducto" runat="server" Value='<%# Bind("CodProducto") %>' />
                            <asp:HiddenField ID="hfStock" runat="server" Value='<%# Bind("Stock") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ALMACEN 2">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblChala2" Text='<%# Bind("Chala2") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="UM" HeaderText="UM">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Costo" HeaderText="Costo">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Moneda" HeaderText="Mon.">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Nuevo Stock" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtCantidad" Width="55px" Style="text-align: center;"
                                CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Font-Bold="True" Enabled="False"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Observacion" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtObservacion" Width="300px" CssClass="ccsestilo"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" Enabled="False"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
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
    <input id="hfCodCtaCteConsulta" type="hidden" value="0" />
    <input id="hfCodigoTemporal" type="hidden" value="0" />
    <input id="hfCodDocumentoVenta" type="hidden" value="0" />
</asp:Content>
