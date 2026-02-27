<%@ Page Title="Precios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MantenimientoPrecios.aspx.cs" Inherits="SistemaInventario.Maestros.MantenimientoPrecios" %>

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
    <script type="text/javascript" language="javascript" src="MantenimientoPrecios.js"
        charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo" style="width: 1200px">
        Mantenimiento Precios</div>
    <div id="tabRegistro" style="width: 1200px">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                Mantenimiento Precios
            </div>
            <div id="divConsultaArticulo">
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" width="900" class="form-inputs">
                        <tr>
                            <td style="font-weight: bold">
                                Articulo
                            </td>
                            <td>
                                <asp:TextBox ID="txtArticulo" runat="server" Width="480px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold">
                                Familia
                            </td>
                            <td style="padding-left: 0px;">
                                <div id="div_Familia">
                                    <asp:DropDownList ID="ddlFamilia" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td style="padding-left: 10px; font-weight: bold;">
                                COSTO Y PRECIO INCLUIDO IGV
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
                    <asp:TemplateField HeaderText="ID">
                        <ItemStyle HorizontalAlign="Right" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCodProducto" Text='<%# Bind("CodProducto") %>'></asp:Label>
                            <asp:HiddenField ID="hfCodAlterno" runat="server" Value='<%# Bind("CodAlterno") %>' />
                            <asp:HiddenField ID="hfCosto" runat="server" Value='<%# Bind("Costo") %>' />
                            <asp:HiddenField ID="hfPrecio" runat="server" Value='<%# Bind("Precio") %>' />
                            <asp:HiddenField ID="hfMargen" runat="server" Value='<%# Bind("Margen") %>' />
                            <asp:HiddenField ID="hfDescuento" runat="server" Value='<%# Bind("Descuento") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
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
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Costo" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Right" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCostoOriginal" Text='<%# Bind("CostoOriginal") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Margen %" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtMargen" Width="50px" Style="text-align: Center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" onblur="F_Margen(this.id); return false;"
                                Text='<%# Bind("Margen") %>' Enabled="False"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Precio" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtPrecio" Width="80px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" onblur="F_Precio(this.id);"
                                Text='<%# Bind("Precio") %>' Enabled="False"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descuento %" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtDescuento" Width="50px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" onblur="F_Descuento(this.id); return false;"
                                Text='<%# Bind("Descuento") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Moneda" HeaderText="Moneda">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
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
    <input id="hfCodUsuario" type="hidden" value="0" />
    <input id="hfCodSede" type="hidden" value="0" />
    <input id="hfCodProducto" type="hidden" value="0" />
    <input id="hfCodDocumentoVenta" type="hidden" value="0" />
</asp:Content>
