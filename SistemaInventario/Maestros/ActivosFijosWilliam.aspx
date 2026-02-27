<%@ Page Title="Activos Fijos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ActivosFijosWilliam.aspx.cs" Inherits="SistemaInventario.Maestros.ActivosFijosWilliam" %>

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
    <script type="text/javascript" language="javascript" src="ActivosFijosWilliam.js" charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"        type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        ACTIVOS FIJOS</div>
    <div id="divTabs">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta">Consulta</a></li>
        </ul>
        <div id="tabRegistro">
            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 690px">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    REGISTRO DE ACTIVOS FIJOS
                </div>
                <div>
                    <table cellpadding="0" cellspacing="0" class="form-inputs">
                        <tr>
                            <td style="font-weight: bold">
                                Codigo Sunat
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtCodAlterno" runat="server" Width="211px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 0px; font-weight: bold">
                                            Familia
                                        </td>
                                        <td style="padding-left: 25px;">
                                            <div id="div_Familia">
                                                <asp:DropDownList ID="ddlFamilia" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="235">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="padding-left: 57px; font-weight: bold; display: none;">
                                            t.c.
                                        </td>
                                        <td style="display: none;">
                                            <asp:TextBox ID="txtTC" runat="server" Width="31px" Font-Names="Arial" ReadOnly="True"
                                                Text="3.36" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Codigo 1
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtCodigo2" runat="server" Width="211px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Pais
                                        </td>
                                        <td style="padding-left: 40px;">
                                            <asp:TextBox ID="txtPais" runat="server" Width="231px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Codigo Factura
                            </td>
                            <td colspan='5'>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtCodigo" runat="server" Width="211px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Descripcion Factura
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtDescripcionAuxiliar" runat="server" Width="515px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Descripcion
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtDescripcion" runat="server" Width="515px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Descripcion 2
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtDescripcion2" runat="server" Width="515px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td style="font-weight: bold">
                                Linea
                            </td>
                            <td style="padding-left: 4px;">
                                <asp:TextBox ID="txtLinea" runat="server" Width="515px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Marca
                            </td>
                            <td colspan='5'>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtMarca" runat="server" Width="211px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Modelo
                                        </td>
                                        <td style="padding-left: 20px;">
                                            <asp:TextBox ID="txtModelo" runat="server" Width="230px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Motor
                            </td>
                            <td>
                                <asp:TextBox ID="txtMotor" runat="server" Width="515px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Posicion
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtPosicion" runat="server" Width="211px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Año
                                        </td>
                                        <td style="padding-left: 42px;">
                                            <asp:TextBox ID="txtAño" runat="server" Width="76px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 2px; font-weight: bold">
                                            Factor
                                        </td>
                                        <td style="padding-left: 27px;">
                                            <asp:TextBox ID="txtFactor" runat="server" Width="75px" Font-Names="Arial" Text="1"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Medida
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtMedida" runat="server" Width="211px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold; display: none">
                                            Medida
                                        </td>
                                        <td style="padding-left: 12px; display: none">
                                            <asp:TextBox ID="txtAro" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold; display: none">
                                            Seccion
                                        </td>
                                        <td style="padding-left: 17px; display: none">
                                            <asp:TextBox ID="txtFecha" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                                CssClass="Jq-ui-dtp" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 2px; font-weight: bold; display: none">
                                            Factor
                                        </td>
                                        <td style="padding-left: 29px; display: none">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Costo Con Igv
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtCostoConIgv" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Moneda
                                        </td>
                                        <td style="padding-left: 7px;">
                                            <div id="div_moneda">
                                                <asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" Width="79" ForeColor="Blue"
                                                    Font-Bold="True">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="padding-left: 2px; font-weight: bold">
                                            UM COMPRA
                                        </td>
                                        <td style="padding-left: 1px;">
                                            <div id="div_umcompra">
                                                <asp:DropDownList ID="ddlUMCompra" runat="server" Font-Names="Arial" Width="79" ForeColor="Blue"
                                                    Font-Bold="True">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="padding-left: 2px; font-weight: bold">
                                            UM Venta
                                        </td>
                                        <td style="padding-left: 17px;">
                                            <div id="div_umventa">
                                                <asp:DropDownList ID="ddlUMVenta" runat="server" Font-Names="Arial" Width="79" ForeColor="Blue"
                                                    Font-Bold="True" Enabled="False">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Costo Con Igv S/
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtCostoSolesIgv" runat="server" Width="75px" Font-Names="Arial"
                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 2px; font-weight: bold">
                                            Margen
                                        </td>
                                        <td style="padding-left: 7px;">
                                            <asp:TextBox ID="txtMargen" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                                CssClass="Derecha" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 3px; font-weight: bold">
                                            Dscto
                                        </td>
                                        <td style="padding-left: 28px;">
                                            <asp:TextBox ID="txtDescuento" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                                CssClass="Derecha" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 2px; font-weight: bold">
                                            Precio
                                        </td>
                                        <td style="padding-left: 30px;">
                                            <asp:TextBox ID="txtPrecio3" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                                CssClass="Derecha" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Ubicacion
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="padding-left: 4px;">
                                            <asp:TextBox ID="txtUbicacion" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Estado
                                        </td>
                                        <td style="padding-left: 11px;">
                                            <div id="div_Estado">
                                                <asp:DropDownList ID="ddlEstado" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="78">
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
                                            <asp:TextBox ID="txtObservacion" runat="server" Width="502px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="linea-button">
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120px" />
                </div>
            </div>
        </div>
        <div id="tabConsulta">
            <div id='divConsulta' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" >
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    Criterio de busqueda
                </div>
                <div class="ui-jqdialog-content">
                    <div class="ui-jqdialog-content">
                        <table cellpadding="0" cellspacing="0" class="form-inputs">
                            <tr>
                                <td style="font-weight: bold">
                                    familia
                                </td>
                                <td>
                                    <div id="div_familiaconsulta">
                                        <asp:DropDownList ID="ddlFamiliaConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                            Font-Bold="True">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td style="font-weight: bold">
                                    Codigo / Descripcion
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescripcionConsulta" runat="server" Width="400" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="padding-left: 5px; font-weight: bold;">
                                    Estado
                                </td>
                                <td style="padding-left: 22px; font-weight: bold;">
                                    <div id="div_FiltroEstados">
                                        <asp:DropDownList ID="ddlFiltroCodEstado" runat="server" Font-Names="Arial" ForeColor="Blue"
                                            Font-Bold="True" Width="78">
                                            <%--<asp:ListItem Value="0">Todos</asp:ListItem>--%>
                                            <asp:ListItem Value="1" Selected>Activos</asp:ListItem>
                                            <asp:ListItem Value="2">Inactivos</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="linea-button">
                     <asp:Button ID="btnGrabarConsulta" runat="server" Text="Grabar" CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Width="120" />
                        <asp:Button ID="btnBuscarConsulta" runat="server" Text="Buscar" CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Width="120" />
                    </div>
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
            <div id="div_consulta" style="padding-top: 5PX;">
                <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                    OnRowDataBound="grvConsulta_RowDataBound" CellPadding="0" CellSpacing="1" CssClass="GridView"
                    GridLines="None" Width="1305px">
                    <Columns>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkOK" CssClass="chkSi" Text="" onclick="F_ValidarCheck(this.id);" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="../Asset/images/EliminarBtn.png"
                                    ToolTip="ELIMINAR PRODUCTO" OnClientClick="F_AnularRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                    ToolTip="EDITAR PRODUCTO" OnClientClick="F_EditarRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgHistorialCosto" ImageUrl="../Asset/images/historial4.png"
                                    ToolTip="HISTORIAL DE COSTOS" OnClientClick="F_HistorialCostos(this); return false;"
                                    Width="18px" Height="18px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgDetalleProducto" ImageUrl="../Asset/images/texto.png"
                                    ToolTip="DETALLE PRODUCTO" OnClientClick="F_DetalleProducto(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <img id="imgMas" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click(this);"
                                    title="Ver Detalle" />
                                <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                    <asp:GridView ID="grvDetalle" runat="server" border="0" CellPadding="0" CellSpacing="1"
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
                        <%-- <asp:TemplateField HeaderText="Codigo 1" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtCodAlterno" Width="100px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" 
                                Text='<%# Bind("CodAlterno") %>' Enabled="False"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Pais" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtPais" Width="40px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" 
                                Text='<%# Bind("Pais") %>' Enabled="False"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Codigo" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                
                                 <asp:TextBox runat="server" ID="txtCodigoProducto" Width="80px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" 
                                Text='<%# Bind("CodigoProducto") %>' Enabled="False"></asp:TextBox>
                                <asp:HiddenField ID="hfCodProducto" runat="server" Value='<%# Bind("CodProducto") %>' />
                                <asp:HiddenField ID="hfModelo" runat="server" Value='<%# Bind("Modelo") %>' />
                                <asp:HiddenField ID="hfAño" runat="server" Value='<%# Bind("Año") %>' />
                                <asp:HiddenField ID="hfPosicion" runat="server" Value='<%# Bind("Posicion") %>' />
                                <asp:HiddenField ID="hfPais" runat="server" Value='<%# Bind("Pais") %>' />
                                <asp:HiddenField ID="hfMedida" runat="server" Value='<%# Bind("Medida") %>' />
                                <asp:HiddenField ID="hfCodMoneda" runat="server" Value='<%# Bind("CodMoneda") %>' />
                                <asp:HiddenField ID="hfCodUnidadCompra" runat="server" Value='<%# Bind("CodUnidadCompra") %>' />
                                <asp:HiddenField ID="hfCodUnidadVenta" runat="server" Value='<%# Bind("CodUnidadVenta") %>' />
                                <asp:HiddenField ID="hfCodFamilia" runat="server" Value='<%# Bind("CodFamilia") %>' />
                                <asp:HiddenField ID="hfFactor" runat="server" Value='<%# Bind("Factor") %>' />
                                <asp:HiddenField ID="hfCostoMercado" runat="server" Value='<%# Bind("CostoMercado") %>' />
                                <asp:HiddenField ID="hfCostoSoles" runat="server" Value='<%# Bind("CostoSoles") %>' />
                                <asp:HiddenField ID="hfCodigoAlternativo" runat="server" Value='<%# Bind("CodigoAlternativo") %>' />
                                <asp:HiddenField ID="hfDescripcionAuxiliar" runat="server" Value='<%# Bind("DescripcionAuxiliar") %>' />
                                <asp:HiddenField ID="hfCodAlterno" runat="server" Value='<%# Bind("CodAlterno") %>' />
                                <asp:HiddenField ID="hfMotor" runat="server" Value='<%# Bind("Motor") %>' />
                                <asp:HiddenField ID="hfDscProducto2" runat="server" Value='<%# Bind("DscProducto2") %>' />
                                <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                <asp:HiddenField ID="lblDescripcionIngles" runat="server" Value='<%# Bind("DescripcionIngles") %>' />
                                <asp:HiddenField ID="lblProducto" runat="server" Value='<%# Bind("Producto") %>' />
                                <asp:HiddenField ID="lblUbicacion" runat="server" Value='<%# Bind("Ubicacion") %>' />
                                <asp:HiddenField ID="lblDescuento" runat="server" Value='<%# Bind("Descuento") %>' />
                                <asp:HiddenField ID="lblMargen" runat="server" Value='<%# Bind("MargenOriginal") %>' />
                                <asp:HiddenField ID="lblCosto" runat="server" Value='<%# Bind("Costo") %>' />
                                <asp:HiddenField ID="lblMarca" runat="server" Value='<%# Bind("Marca") %>' />
                                <asp:HiddenField ID="lblObservacion" runat="server" Value='<%# Bind("Observacion") %>' />
                                <asp:HiddenField ID="lblCodigoProducto" runat="server" Value='<%# Bind("CodigoProducto") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--  <asp:TemplateField HeaderText="Producto Fact." HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtDescripcionAuxiliar" Width="100px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" 
                                Text='<%# Bind("DescripcionAuxiliar") %>' Enabled="False"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Producto" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtProducto" Width="120px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" 
                                Text='<%# Bind("Producto") %>' Enabled="False"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                     <%--     <asp:TemplateField HeaderText="Producto 2" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtDscProducto2" Width="100px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" 
                                Text='<%# Bind("DscProducto2") %>' Enabled="False"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Marca" HeaderStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                
                                  <asp:TextBox runat="server" ID="txtMarca" Width="100px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" 
                                Text='<%# Bind("Marca") %>' Enabled="False"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="STOCK">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblstock" Text='<%# Bind("Chala1") %>' CssClass="detallesart"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                      <%--  <asp:TemplateField HeaderText="Modelo" HeaderStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                
                                  <asp:TextBox runat="server" ID="txtModelo" Width="50px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" 
                                Text='<%# Bind("Modelo") %>' Enabled="False"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Motor" HeaderStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                
                                  <asp:TextBox runat="server" ID="txtMotor" Width="50px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" 
                                Text='<%# Bind("Motor") %>' Enabled="False"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Posicion" HeaderStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                
                                  <asp:TextBox runat="server" ID="txtPosicion" Width="60px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" 
                                Text='<%# Bind("Posicion") %>' Enabled="False"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Año" HeaderStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                
                                  <asp:TextBox runat="server" ID="txtAño" Width="30px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" 
                                Text='<%# Bind("Año") %>' Enabled="False"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="MEDIDA" HeaderStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                
                                  <asp:TextBox runat="server" ID="txtMEDIDA" Width="50px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" 
                                Text='<%# Bind("MEDIDA") %>' Enabled="False"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                         <asp:TemplateField HeaderText="Costo" HeaderStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                
                                  <asp:TextBox runat="server" ID="txtCosto" Width="80px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" 
                                Text='<%# Bind("Costo") %>' Enabled="False"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Margen" HeaderStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                
                                  <asp:TextBox runat="server" ID="txtMargen" Width="80px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" 
                                Text='<%# Bind("MargenOriginal") %>' Enabled="False"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Precio">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblPrecio3" Text='<%# Bind("Precio3") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Dsco." HeaderStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                
                                  <asp:TextBox runat="server" ID="txtDescuento" Width="80px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" 
                                Text='<%# Bind("Descuento") %>' Enabled="False"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Ubicacion" HeaderStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                
                                  <asp:TextBox runat="server" ID="txtUbicacion" Width="80px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" 
                                Text='<%# Bind("Ubicacion") %>' Enabled="False"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                                           <%--  <asp:TemplateField HeaderText="COSTO">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCosto2" Text='<%# Bind("Chala2") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
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
                        <asp:BoundField DataField="UM" HeaderText="UM">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                      
                      
                        <asp:BoundField DataField="Moneda" HeaderText="Mon">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        
                    <%-- <asp:BoundField DataField="Familia" HeaderText="Familia">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>--%>
                         <asp:TemplateField HeaderText="Familia" HeaderStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                
                                  <asp:TextBox runat="server" ID="txtFamilia" Width="100px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="AutoComplete"  onblur="AutocompleteFamilia(this.id);"
                                Text='<%# Bind("Familia") %>' Enabled="False"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="ESTADO">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:DropDownList runat="server" ID="ddlEstado" Font-Names="Arial" ForeColor="Blue"
                                Font-Bold="True" CssClass="ccsestilo">
                                <asp:ListItem Value="1">ACTIVO</asp:ListItem>
                                <asp:ListItem Value="2">INACTIVO</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div id="divEdicionRegistro" style="display: none;">
        <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0" class="form-inputs">
                <tr>
                    <td style="font-weight: bold">
                        Codigo Sunat
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCodAlternoEdicion" runat="server" Width="211px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="padding-left: 2px; font-weight: bold">
                                    Familia
                                </td>
                                <td style="padding-left: 27px;">
                                    <div id="div_FamiliaEdicion">
                                        <asp:DropDownList ID="ddlFamiliaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                            Font-Bold="True" Width="242">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Codigo 1
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCodigo2Edicion" runat="server" Width="211px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Pais
                                </td>
                                <td style="padding-left: 44px;">
                                    <asp:TextBox ID="txtPaisEdicion" runat="server" Width="238Px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Codigo Factura
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="padding-left: 2px;">
                                    <asp:TextBox ID="txtCodigoProductoEdicion" runat="server" Width="211px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="padding-left: 52px; font-weight: bold; display: none;">
                                    t.c.
                                </td>
                                <td style="display: none;">
                                    <asp:TextBox ID="txtTcEdicion" runat="server" Width="31px" Font-Names="Arial" ReadOnly="True"
                                        Text="2.796" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Descripcion Factura
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtDescripcionAuxiliarEdicion" runat="server" Width="525px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Descripcion
                    </td>
                    <td colspan='5' style="padding-left: 4px;">
                        <asp:TextBox ID="txtDescripcionEdicion" runat="server" Width="525px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Descripcion 2
                    </td>
                    <td colspan='5' style="padding-left: 4px;">
                        <asp:TextBox ID="txtDescripcion2Edicion" runat="server" Width="525px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display:none">
                    <td style="font-weight: bold">
                        Linea
                    </td>
                    <td style="padding-left: 4px;">
                        <asp:TextBox ID="txtLineaEdicion" runat="server" Width="525px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Marca
                    </td>
                    <td colspan='5'>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtMarcaEdicion" runat="server" Width="211px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Modelo
                                </td>
                                <td style="padding-left: 24px;">
                                    <asp:TextBox ID="txtModeloEdicion" runat="server" Width="235px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Motor
                    </td>
                    <td>
                        <asp:TextBox ID="txtMotorEdicion" runat="server" Width="525px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Posicion
                    </td>
                    <td colspan='5' style="font-weight: bold;">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtPosicionEdicion" runat="server" Width="211px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Año
                                </td>
                                <td style="padding-left: 45px;">
                                    <asp:TextBox ID="txtAñoEdicion" runat="server" Width="235px" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold;">
                        Medida
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="font-weight: bold;">
                                    <asp:TextBox ID="txtMedidaEdicion" runat="server" Width="211px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold; display: none;">
                                    Medida
                                </td>
                                <td style="padding-left: 11px; display: none;">
                                    <asp:TextBox ID="txtAroEdicion" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold; display: none;">
                                    Seccion
                                </td>
                                <td style="padding-left: 23px; display: none;">
                                    <asp:TextBox ID="txtSeccionEdicion" runat="server" Width="75px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold; display: none;">
                                    Factor
                                </td>
                                <td style="padding-left: 33px; display: none;">
                                    <asp:TextBox ID="txtFactorEdicion" runat="server" Width="75px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True" Text="1"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Costo Con Igv
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCostoEdicion" runat="server" ForeColor="Blue" Font-Bold="True"
                                        CssClass="Derecha" Width="75px" Font-Names="Arial" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Moneda
                                </td>
                                <td style="padding-left: 6px;">
                                    <div id="div_MonedaEdicion">
                                        <asp:DropDownList ID="ddlMonedaEdicion" runat="server" Font-Names="Arial" Width="79"
                                            ForeColor="Blue" Font-Bold="True">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td style="font-weight: bold">
                                    UM COMPRA
                                </td>
                                <td style="padding-left: 6px;">
                                    <div id="div_CompraEdicion">
                                        <asp:DropDownList ID="ddlCompraEdicion" runat="server" Font-Names="Arial" Width="78"
                                            ForeColor="Blue" Font-Bold="True">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td style="font-weight: bold">
                                    UM Venta
                                </td>
                                <td style="padding-left: 23px;">
                                    <div id="div_VentaEdicion">
                                        <asp:DropDownList ID="ddlVentaEdicion" runat="server" Font-Names="Arial" Width="79"
                                            ForeColor="Blue" Font-Bold="True" Enabled="False">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Costo S/ Con Igv
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCostoSolesEdicion" runat="server" Width="75px" Font-Names="Arial"
                                        CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Margen
                                </td>
                                <td style="padding-left: 6px;">
                                    <asp:TextBox ID="txtMargenEdicion" runat="server" Width="75px" Font-Names="Arial"
                                        CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Dscto
                                </td>
                                <td style="padding-left: 33px;">
                                    <asp:TextBox ID="txtDescuentoEdicion" runat="server" Width="75px" Font-Names="Arial"
                                        CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Precio
                                </td>
                                <td style="padding-left: 36px;">
                                    <asp:TextBox ID="txtPrecio3Edicion" runat="server" Width="75px" Font-Names="Arial"
                                        CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Costo Mercado
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCostoMercadoEdicion" runat="server" Width="73px" ForeColor="Blue"
                                        CssClass="Derecha" Font-Bold="True" Font-Names="Arial"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Ubicacion
                                </td>
                                <td>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="padding-left: 4px;">
                                                <asp:TextBox ID="txtUbicacionEdicion" runat="server" Width="67px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td style="padding-left: 5px; font-weight: bold;">
                                                Estado
                                            </td>
                                            <td style="padding-left: 22px; font-weight: bold;">
                                                <div id="div_EstadoEdicion">
                                                    <asp:DropDownList ID="ddlEstadoEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="78">
                                                        <asp:ListItem Value="0">Todos</asp:ListItem>
                                                        <asp:ListItem Value="1">Activos</asp:ListItem>
                                                        <asp:ListItem Value="2">Inactivos</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
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
                        Observacion
                    </td>
                    <td colspan='5' style="padding-left: 4px;">
                        <asp:TextBox ID="txtObservacionEdicion" runat="server" Width="525px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan='6' align="right">
                        <asp:Button ID="btnEdicion" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Width="120px" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="div_HistorialCostos" style="display: none;">
        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td style="font-weight: bold">
                                Producto
                            </td>
                            <td style="padding-left: 4px;">
                                <asp:TextBox ID="txtProductoHistorial" runat="server" Width="577px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold">
                                Marca
                            </td>
                            <td style="padding-left: 4px;">
                                <asp:TextBox ID="txtMarcaHistorial" runat="server" Width="200px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold">
                                Costo Actual
                            </td>
                            <td style="padding-left: 4px;">
                                <asp:TextBox ID="txtCostoActual" runat="server" Width="100px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                   <div style="padding-top: 5px;">
                            <table cellpadding="0" cellspacing="0" align="center">
                                <tr>
                                     <td style="font-weight: bold;padding-left: 20px; ">
                                        Cantidad de Registros:
                                    </td>
                                    <td style="font-weight: bold;">
                                        <label id="lblGrillaConsultaCostos">
                                        </label>
                                    </td>  
                                </tr>
                            </table>
                        </div>
                    <div id="div_grvHistorialCostos" style="padding-top: 5px;">
                        <asp:GridView ID="grvHistorialCostos" runat="server" AutoGenerateColumns="False"
                            border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                            Width="1100px">
                            <Columns>
                              
                                 <asp:TemplateField HeaderText="ID" HeaderStyle-Width="15px"  >
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="hfFechaRegistro" Text='<%# Bind("FechaRegistro") %>' CssClass="detallesart"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                                <asp:BoundField DataField="Usuario" HeaderText="Usuario" HeaderStyle-Width="160px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Modulo" HeaderText="Modulo-Transaccion" HeaderStyle-Width="170px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaDocumento" HeaderText="Emision" HeaderStyle-Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" HeaderStyle-Width="250px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CostoMercado_ANTERIOR" HeaderText="Costo Anterior" HeaderStyle-Width="40px"
                                    Visible="false">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CostoMercado_NUEVO" HeaderText="Costo" HeaderStyle-Width="60px">
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
    <div id="div_DetalleProducto" style="display: none;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="padding-top: 10px; font-weight: bold">
                    PRODUCTO
                </td>
                <td style="padding-top: 10px;">
                    <asp:TextBox ID="txtProductoDetalle" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    MODELO
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtModeloDetalle" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    AÑO
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtAñoDetalle" runat="server" Width="500px" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Motor
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtMotorDetalle" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Caja Cambio
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtCajaCambio" runat="server" Width="500px" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Transmision
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtTransmision" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Filtro
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtFiltro" runat="server" Width="500px" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    <asp:Button ID="btnGrabarDetalle" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;" colspan="2">
                    <div id="div_ProductoDetalle">
                        <asp:GridView ID="grvProductoDetalle" runat="server" AutoGenerateColumns="False"
                            border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                            Width="860px">
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                            ToolTip="ELIMINAR DETALLE PRODUCTO" OnClientClick="F_EliminarDetalleProducto(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                            ToolTip="EDITAR DETALLE PRODUCTO" OnClientClick="F_EditarDetalleProducto(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Linea" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblLinea" Text='<%# Bind("Linea") %>'></asp:Label>
                                        <asp:HiddenField ID="hfCodProductoModelo" runat="server" Value='<%# Bind("CodProductoModelo") %>' />
                                        <asp:HiddenField ID="hfCodModelo" runat="server" Value='<%# Bind("CodModeloVehiculo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Modelo" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblModelo" Text='<%# Bind("Modelo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Año" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblAño" Text='<%# Bind("Año") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Motor" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblMotor" Text='<%# Bind("Motor") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Caja Cambio" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCajaCambio" Text='<%# Bind("CajaCambio") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Transmision" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblTransmision" Text='<%# Bind("Transmision") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Filtro" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblFiltro" Text='<%# Bind("Filtro") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_DetalleProductoEditar" style="display: none;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="padding-top: 10px; font-weight: bold">
                    PRODUCTO
                </td>
                <td style="padding-top: 10px;">
                    <asp:TextBox ID="txtProductoDetalleEdicion" runat="server" Width="370px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    MODELO
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtModeloDetalleEdicion" runat="server" Width="370px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    AÑO
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtAñoDetalleEdicion" runat="server" Width="370px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Motor
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtMotorDetalleEdicion" runat="server" Width="370px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Caja Cambio
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtCajaCambioEdicion" runat="server" Width="370px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Transmision
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtTransmisionEdicion" runat="server" Width="370px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Filtro
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtFiltroEdicion" runat="server" Width="370px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 10px;" align="right" colspan="2">
                    <asp:Button ID="btnGrabarDetalleEdicion" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
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
    <input id="hfCodCtaCteConsulta" type="hidden" value="0" />
    <input id="hfCodigoTemporal" type="hidden" value="0" />
    <input id="hfCodProducto" type="hidden" value="0" />
    <input id="hfMoneda" type="hidden" value="0" />
    <input id="hfCodModeloDetalle" type="hidden" value="0" />
    <input id="hfCodModeloDetalleEdicion" type="hidden" value="0" />
    <input id="hfCodProductoModelo" type="hidden" value="0" />
    <input id="hfCodLinea" type="hidden" value="0" />
    <input id="hfCodLineaEdicion" type="hidden" value="0" />
    <input id="hfCodMarca" type="hidden" value="0" />
    <input id="hfCodMarcaEdicion" type="hidden" value="0" />
</asp:Content>
