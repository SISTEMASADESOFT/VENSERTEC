<%@ Page Title="Proveedores" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Proveedores.aspx.cs" Inherits="SistemaInventario.Maestros.Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"type="text/javascript"></script>        
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="Proveedores.js" charset="UTF-8"></script>  
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"  type="text/css" />      
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        Proveedores</div>
    <div id="divTabs">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta">Consulta</a></li>
        </ul>
        <div id="tabRegistro">
            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 640px">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    REGISTRO DE Proveedores
                </div>
                <div>
                    <table cellpadding="0" cellspacing="0" class="form-inputs">
                        <tr>
                            <td style="font-weight: bold">
                                Tipo de Proveedor
                            </td>
                            <td style="padding-left: 4px;">
                                <div id="div_TipoCliente">
                                    <asp:DropDownList ID="ddlTipoCliente" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td style="padding-left: 37px; font-weight: bold">
                                Nro Ruc
                            </td>
                            <td style="padding-left: 0px;">
                                <asp:TextBox ID="txtNroRuc" runat="server" Width="82px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" MaxLength="11" onblur="F_ValidaRucDni();"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold">
                                Nro Dni
                            </td>
                            <td>
                                <asp:TextBox ID="txtNroDni" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" MaxLength="8"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Proveedor
                            </td>
                            <td colspan='5' style="padding-left: 4px;">
                                <asp:TextBox ID="txtRazonSocial" runat="server" Width="485px" Font-Names="Arial"
                                    Font-Bold="True" ForeColor="Blue" onblur="F_ValidaCuentaCorriente();"></asp:TextBox>
                            </td>
                        </tr>
                           <tr>
                            <td style="font-weight: bold">
                                Nombres
                            </td>
                            <td colspan='5'>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtNombres" runat="server" Width="485px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr style="display: none">
                            <td style="font-weight: bold">
                                Apellido Paterno
                            </td>
                            <td colspan='5'>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtApellidoPaterno" runat="server" Width="219px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Materno
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtApellidoMaterno" runat="server" Width="219px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                     
                        <tr>
                            <td style="font-weight: bold">
                                Distrito
                            </td>
                            <td colspan='5'>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtDistrito" runat="server" Width="485px" Font-Names="Arial" ForeColor="Blue"
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
                            <td style="padding-left: 4px;" colspan='5'>
                                <asp:TextBox ID="txtDireccion" runat="server" Width="485px" Font-Names="Arial" Font-Bold="True"
                                    ForeColor="Blue"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td style="font-weight: bold">
                                Direccion Envio
                            </td>
                            <td style="padding-left: 4px;" colspan='5'>
                                <asp:TextBox ID="txtDireccionEnvio" runat="server" Width="485px" Font-Names="Arial"
                                    Font-Bold="True" ForeColor="Blue"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Email
                            </td>
                            <td style="padding-left: 4px;" colspan='5'>
                                <asp:TextBox ID="txtEmail" runat="server" Width="485px" Font-Names="Arial" Font-Bold="True"
                                    ForeColor="Blue"></asp:TextBox>
                            </td>
                        </tr>
                         <tr style="font-weight: bold;display: none">
                            <td style="font-weight: bold;display: none">
                                Retencion
                            </td>
                            <td style="padding-left: 4px;" colspan='5'>
                                 <asp:CheckBox ID="chkRetencion" runat="server" Text="" Font-Bold="True" />
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td style="font-weight: bold">
                                Linea Credito
                            </td>
                            <td colspan='5'>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="padding-left: 2px;" colspan='5'>
                                            <asp:TextBox ID="txtLineaCredito" runat="server" Width="100px" Font-Names="Arial"
                                                Font-Bold="True" ForeColor="Blue" CssClass="Derecha"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Moneda
                                        </td>
                                        <td>
                                            <div id="div_moneda">
                                                <asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="75" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="linea-button">
                    <asp:CheckBox ID="chkProveedor" runat="server" Text="Cliente" Font-Bold="True" />
                    <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" ForeColor="Blue" Text="CONSULTA RUC SUNAT"
                        NavigateUrl="http://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias">CONSULTA RUC SUNAT</asp:HyperLink>
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120px" />
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120px" />
                </div>
            </div>
        </div>
        <div id="tabConsulta">
            <div id='divConsulta' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    Criterio de busqueda
                </div>
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" class="form-inputs" width="700">
                        <tr>
                            <td style="font-weight: bold">
                                Descripcion (Razon Social/RUC)
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescripcionConsulta" runat="server" Width="772" Font-Names="Arial"
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
            <div id="div_consulta" style="padding-top: 5px;">
                <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                    CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1017px">
                    <Columns>
                        <asp:TemplateField HeaderText="Anu" HeaderStyle-Width="10px">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                    ToolTip="Eliminar Proveedor" OnClientClick="F_AnularRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edi" HeaderStyle-Width="10px">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                    ToolTip="Editar Proveedor" OnClientClick="F_EditarRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dir" HeaderStyle-Width="10px">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgDireccion" ImageUrl="../Asset/images/add_small.png"
                                    ToolTip="Direccion" OnClientClick="F_Direccion(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
              <%--          <asp:TemplateField HeaderText="Res" HeaderStyle-Width="10px" Visible="false">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgResponsables" ImageUrl="../Asset/images/User.png"
                                    ToolTip="Responsables por Cliente" OnClientClick="F_Responsables(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Con" HeaderStyle-Width="10px">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgContactos" ImageUrl="../Asset/images/User.png"
                                    ToolTip="Contactos Cliente" OnClientClick="F_Contactos(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID" HeaderStyle-Width="15px"  Visible ="false">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblcodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Documento" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                  <asp:Label runat="server" ID="lblDocumento" Text='<%# Bind("Documento") %>' CssClass="detallesart"></asp:Label>
                                <asp:HiddenField ID="hfCodigo" runat="server" Value='<%# Bind("Codigo") %>' />
                                <asp:HiddenField ID="hfDepartamento" runat="server" Value='<%# Bind("DscDepartamento") %>' />
                                <asp:HiddenField ID="hfProvincia" runat="server" Value='<%# Bind("DscProvincia") %>' />
                                <asp:HiddenField ID="hfDireccionEnvio" runat="server" Value='<%# Bind("DireccionEnvio") %>' />
                                <asp:HiddenField ID="hfApePaterno" runat="server" Value='<%# Bind("ApePaterno") %>' />
                                <asp:HiddenField ID="hfApeMaterno" runat="server" Value='<%# Bind("ApeMaterno") %>' />
                                <asp:HiddenField ID="hfNombres" runat="server" Value='<%# Bind("Nombres") %>' />
                                <asp:HiddenField ID="hfNroRuc" runat="server" Value='<%# Bind("NroRuc") %>' />
                                <asp:HiddenField ID="hfNroDni" runat="server" Value='<%# Bind("NroDni") %>' />
                                <asp:HiddenField ID="hfCodTipoCliente" runat="server" Value='<%# Bind("CodTipoCliente") %>' />
                                <asp:HiddenField ID="hfCodDepartamento" runat="server" Value='<%# Bind("CodDepartamento") %>' />
                                <asp:HiddenField ID="hfCodProvincia" runat="server" Value='<%# Bind("CodProvincia") %>' />
                                <asp:HiddenField ID="hfCodDistrito" runat="server" Value='<%# Bind("CodDistrito") %>' />
                                <asp:HiddenField ID="hfRazonSocial" runat="server" Value='<%# Bind("RazonSocial") %>' />
                                <asp:HiddenField ID="hfEmail" runat="server" Value='<%# Bind("Email") %>' />
                                <asp:HiddenField ID="hfCodRetencion" runat="server" Value='<%# Bind("CodRetencion") %>' />
                                <asp:HiddenField ID="hfLineaCredito" runat="server" Value='0' />
                                <asp:HiddenField ID="hfDeudaCredito" runat="server" Value='0' />
                                <asp:HiddenField ID="hfCodMonedaLineaCredito" runat="server" Value='0' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Proveedor" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCliente" Text='<%# Bind("Cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div id="divEdicionRegistro" style="display: none;">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                DATOS PROVEEDOR
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                    <tr>
                        <td style="font-weight: bold">
                            Tipo de Proveedor
                        </td>
                        <td style="padding-left: 4px;">
                            <div id="div_tipoclienteedicion">
                                <asp:DropDownList ID="ddlTipoCliente_Edicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True">
                                </asp:DropDownList>
                            </div>
                        </td>
                        <td style="padding-left: 42px; font-weight: bold">
                            Nro Ruc
                        </td>
                        <td style="padding-left: 5px;">
                            <asp:TextBox ID="txtRucEdicion" runat="server" Width="82px" Font-Names="Arial" ForeColor="Blue"
                                Font-Bold="True" MaxLength="11"></asp:TextBox>
                        </td>
                        <td style="padding-left: 0px; font-weight: bold">
                            Nro Dni
                        </td>
                        <td>
                            <asp:TextBox ID="txtDniEdicion" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                Font-Bold="True" MaxLength="8"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            PROVEEDOR
                        </td>
                        <td colspan='5' style="padding-left: 4px;">
                            <asp:TextBox ID="txtRazonSocialEdicion" runat="server" Width="500px" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>

                       <tr>
                        <td style="font-weight: bold">
                            Nombres
                        </td>
                        <td colspan='5'>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtNombreEdicion" runat="server" Width="500px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr style="display: none">
                        <td style="font-weight: bold">
                            Apellido Paterno
                        </td>
                        <td colspan='5'>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtApellidoPaternoEdicion" runat="server" Width="219px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold">
                                        Materno
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtApellidoMaternoEdicion" runat="server" Width="219px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                 
                    <tr>
                        <td style="font-weight: bold; display: none">
                            Distrito
                        </td>
                        <td colspan='5' style="display: none">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtDistritoEdicion" runat="server" Width="500px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; display: none">
                            Direccion
                        </td>
                        <td style="padding-left: 4px; display: none" colspan='5'>
                            <asp:TextBox ID="txtDireccionEdicion" runat="server" Width="500px" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td style="font-weight: bold; display: none">
                            Direccion Envio
                        </td>
                        <td style="padding-left: 4px; display: none" colspan='5'>
                            <asp:TextBox ID="txtDireccionEnvioEdicion" runat="server" Width="500px" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; display: none">
                            Email
                        </td>
                        <td style="padding-left: 4px; display: none" colspan='5'>
                            <asp:TextBox ID="txtEmailEdicion" runat="server" Width="500px" Font-Names="Arial"
                                Font-Bold="True" ForeColor="Blue"></asp:TextBox>
                        </td>
                    </tr>
                      <tr style="font-weight: bold;display:none">
                            <td style="font-weight: bold;display:none">
                                Retencion
                            </td>
                            <td style="padding-left: 4px;" colspan='5'>
                                 <asp:CheckBox ID="chkRetencionEdicion" runat="server" Text="" Font-Bold="True" />
                            </td>
                        </tr>
                </table>
            </div>
            <div class="linea-button">
                <asp:Button ID="btnEdicion" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Font-Names="Arial" Font-Bold="True" Width="120px" />
            </div>
        </div>
    </div>
    <div id="div_DireccionMultipleAdd" style="display: none">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="padding-top: 10px; font-weight: bold">
                    Distrito
                </td>
                <td style="padding-top: 10px;">
                    <asp:TextBox ID="txtDistritoMultiple" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Direccion
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtDireccionMultiple" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email 1
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEmailMultiple1" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email 2
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEmailMultiple2" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email 3
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEmailMultiple3" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email 4
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEmailMultiple4" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email 5
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEmailMultiple5" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email 6
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEmailMultiple6" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    <asp:Button ID="btnGrabarDireccion" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </td>
            </tr>
            <tr align="right">
                <td>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_DireccionMultiple" style="display: none;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td align="right" colspan="2">
                    <asp:Button ID="btnAgregarDireccionMultiple" runat="server" Text="AGREGAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;" colspan="2">
                    <div id="div_Direccion">
                        <asp:GridView ID="grvDireccion" runat="server" AutoGenerateColumns="False" border="0"
                            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="860px"
                            OnRowDataBound="grvConsulta_RowDataBound">
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                            ToolTip="Eliminar Direccion" OnClientClick="F_EliminarDireccion(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                            ToolTip="Editar Direccion" OnClientClick="F_EditarRegistroDireccion(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgActivarRegistro" ImageUrl="../Asset/images/ok.gif"
                                            Height="18px" Width="18px" ToolTip="ACTIVO: PRESIONES PARA INACTIVAR" OnClientClick="F_ActivarRegistroDireccion(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgPrincipal" ImageUrl="../Asset/images/Circle_Yellow.png"
                                            ToolTip="Activar/Desactivar" OnClientClick="F_ElegirPrincipalDireccion(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCodDireccion" runat="server" Text='<%# Bind("CodDireccion") %>'></asp:Label>
                                        <asp:HiddenField ID="hfPrincipal" runat="server" Value='<%# Bind("Principal") %>' />
                                        <asp:HiddenField ID="hfCodDistrito" runat="server" Value='<%# Bind("CodDistrito") %>' />
                                        <asp:HiddenField ID="hfCodDepartamento" runat="server" Value='<%# Bind("CodDepartamento") %>' />
                                        <asp:HiddenField ID="hfCodProvincia" runat="server" Value='<%# Bind("CodProvincia") %>' />
                                        <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                        <asp:HiddenField ID="hfEmail" runat="server" Value='<%# Bind("Email") %>' />
                                        <asp:HiddenField ID="hfEmail2" runat="server" Value='<%# Bind("Email2") %>' />
                                        <asp:HiddenField ID="hfEmail3" runat="server" Value='<%# Bind("Email3") %>' />
                                        <asp:HiddenField ID="hfEmail4" runat="server" Value='<%# Bind("Email4") %>' />
                                        <asp:HiddenField ID="hfEmail5" runat="server" Value='<%# Bind("Email5") %>' />
                                        <asp:HiddenField ID="hfEmail6" runat="server" Value='<%# Bind("Email6") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <img id="imgMas" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click(this);"
                                            title="Ver Detalle" />
                                        <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                            <asp:GridView ID="grvDetalle" runat="server" border="0" CellPadding="0" CellSpacing="1"
                                                AutoGenerateColumns="True" GridLines="None" class="GridView">
                                                <Columns>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Distrito" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDistrito" Text='<%# Bind("Distrito") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Direccion" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDireccion" Text='<%# Bind("Direccion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_EdicionDireccion" style="display: none;">
        <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right" style="padding-top: 10px;" colspan="2">
                        <asp:Button ID="btnGrabarEdicionDireccion" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" />
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold; padding-top: 5px;">
                        Distrito
                    </td>
                    <td style="padding-left: 5px; padding-top: 5px;">
                        <asp:TextBox ID="txtDistritoDireccionEdicion" runat="server" Width="360px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold; padding-top: 5px;">
                        Direccion
                    </td>
                    <td style="padding-left: 5px; padding-top: 5px;">
                        <asp:TextBox ID="txtDireccionEdicionMultiple" runat="server" Width="360px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold; padding-top: 5px;">
                        Email 1
                    </td>
                    <td style="padding-left: 5px; padding-top: 5px;">
                        <asp:TextBox ID="txtEmailEdicionMultiple1" runat="server" Width="360px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold; padding-top: 5px;">
                        Email 2
                    </td>
                    <td style="padding-left: 5px; padding-top: 5px;">
                        <asp:TextBox ID="txtEmailEdicionMultiple2" runat="server" Width="360px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold; padding-top: 5px;">
                        Email 3
                    </td>
                    <td style="padding-left: 5px; padding-top: 5px;">
                        <asp:TextBox ID="txtEmailEdicionMultiple3" runat="server" Width="360px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold; padding-top: 5px;">
                        Email 4
                    </td>
                    <td style="padding-left: 5px; padding-top: 5px;">
                        <asp:TextBox ID="txtEmailEdicionMultiple4" runat="server" Width="360px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold; padding-top: 5px;">
                        Email 5
                    </td>
                    <td style="padding-left: 5px; padding-top: 5px;">
                        <asp:TextBox ID="txtEmailEdicionMultiple5" runat="server" Width="360px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold; padding-top: 5px;">
                        Email 6
                    </td>
                    <td style="padding-left: 5px; padding-top: 5px;">
                        <asp:TextBox ID="txtEmailEdicionMultiple6" runat="server" Width="360px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="div_Responsables" style="display: none;" class="form-inputs">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="font-weight: bold">
                    Proveedor
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtClienteResponsable" runat="server" Width="500px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Nombre
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtResponsable" runat="server" Width="370px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold">
                                Dni
                            </td>
                            <td>
                                <asp:TextBox ID="txtResponsableDNI" runat="server" Width="100px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Correo 1
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtCorreoResponsable1" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold; padding-left: 10px">
                                Correo 2
                            </td>
                            <td style="padding-left: 10px">
                                <asp:TextBox ID="txtCorreoResponsable2" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Correo 3
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtCorreoResponsable3" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold; padding-left: 10px">
                                Correo 4
                            </td>
                            <td style="padding-left: 10px">
                                <asp:TextBox ID="txtCorreoResponsable4" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Correo 5
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtCorreoResponsable5" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold; padding-left: 10px">
                                Correo 6
                            </td>
                            <td style="padding-left: 10px">
                                <asp:TextBox ID="txtCorreoResponsable6" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Estado
                </td>
                <td style="font-weight: bold">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div id="div_EstadoResponsable">
                                    <asp:DropDownList ID="ddlEstadoResponsable" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="right" colspan="2">
                    <asp:Button ID="btnGrabarResponsable" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;" colspan="2">
                    <div id="div_ResponsablesGrid">
                        <asp:GridView ID="grvResponsables" runat="server" AutoGenerateColumns="False" border="0"
                            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="860px">
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                            ToolTip="Eliminar Direccion" OnClientClick="F_EliminarDireccion(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgEditarResponsable" ImageUrl="../Asset/images/btnEdit.gif"
                                            ToolTip="Editar Direccion" OnClientClick="F_EditarResponsables(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodResponsable" Text='<%# Bind("CodResponsable") %>'></asp:Label>
                                        <asp:HiddenField ID="hfCodCtaCte" runat="server" Value='<%# Bind("CodCtaCte") %>' />
                                        <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Datos Personales" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDatosPersonales" Text='<%# Bind("DatosPersonales") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DNI" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDNI" Text='<%# Bind("Dni") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correo1" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCorreo1" Text='<%# Bind("Correo1") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correo2" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCorreo2" Text='<%# Bind("Correo2") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correo3" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCorreo3" Text='<%# Bind("Correo3") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correo4" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCorreo4" Text='<%# Bind("Correo4") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correo5" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCorreo5" Text='<%# Bind("Correo5") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correo6" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCorreo6" Text='<%# Bind("Correo6") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_ResponsablesEdicion" style="display: none;" class="form-inputs">
        <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                    </td>
                    <td align="right" style="padding-top: 10px;" colspan="2">
                        <asp:Button ID="btnEditarResponsable" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" />
                    </td>
                </tr>
                <tr style="padding-top: 10px">
                    <td style="font-weight: bold">
                        Nombre
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtResponsableEdicion" runat="server" Width="370px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Dni
                                </td>
                                <td>
                                    <asp:TextBox ID="txtResponsableDNIEdicion" runat="server" Width="100px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Correo 1
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCorreoResponsableEdicion1" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold; padding-left: 10px">
                                    Correo 2
                                </td>
                                <td style="padding-left: 10px">
                                    <asp:TextBox ID="txtCorreoResponsableEdicion2" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Correo 3
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCorreoResponsableEdicion3" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold; padding-left: 10px">
                                    Correo 4
                                </td>
                                <td style="padding-left: 10px">
                                    <asp:TextBox ID="txtCorreoResponsableEdicion4" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Correo 5
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCorreoResponsableEdicion5" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold; padding-left: 10px">
                                    Correo 6
                                </td>
                                <td style="padding-left: 10px">
                                    <asp:TextBox ID="txtCorreoResponsableEdicion6" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Estado
                    </td>
                    <td style="font-weight: bold">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div id="div_EstadoResponsableEdicion">
                                        <asp:DropDownList ID="ddlEstadoResponsableEdicion" runat="server" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="div_Contactos" style="display: none;" class="form-inputs">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="font-weight: bold">
                    Proveedor
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtClienteContacto" runat="server" Width="505px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Nombre
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="3">
                                <asp:TextBox ID="txtContacto" runat="server" Width="505px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Area
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtContactoArea" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold; padding-left: 10px">
                                Telefono
                            </td>
                            <td style="padding-left: 13px">
                                <asp:TextBox ID="txtContactoTelefono" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Correo 1
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtCorreoContacto1" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold; padding-left: 12px">
                                Correo 2
                            </td>
                            <td style="padding-left: 12px">
                                <asp:TextBox ID="txtCorreoContacto2" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Correo 3
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtCorreoContacto3" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold; padding-left: 10px">
                                Celular 1
                            </td>
                            <td style="padding-left: 10px">
                                <asp:TextBox ID="txtCelularContacto1" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Celular 2
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtCelularContacto2" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold; padding-left: 10px">
                                Celular 3
                            </td>
                            <td style="padding-left: 10px">
                                <asp:TextBox ID="txtCelularContacto3" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Estado
                </td>
                <td style="font-weight: bold">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div id="div_EstadoContacto">
                                    <asp:DropDownList ID="ddlEstadoContacto" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True">
                                        <asp:ListItem Value="1">Activo</asp:ListItem>
                                        <asp:ListItem Value="2">Inativo</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkFlag_MostrarEnReporte" runat="server" Text="Mostrar en Reporte"
                                    Font-Bold="True" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="right" colspan="2">
                    <asp:Button ID="btnGrabarContacto" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;" colspan="2">
                    <div id="div_ContactosGrid">
                        <asp:GridView ID="grvContactos" runat="server" AutoGenerateColumns="False" border="0"
                            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="860px">
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                            ToolTip="Eliminar Direccion" OnClientClick="F_EliminarDireccion(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgEditarContacto" ImageUrl="../Asset/images/btnEdit.gif"
                                            ToolTip="Editar Direccion" OnClientClick="F_EditarContactos(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodContacto" Text='<%# Bind("CodContacto") %>'></asp:Label>
                                        <asp:HiddenField ID="hfCodCtaCte" runat="server" Value='<%# Bind("CodCtaCte") %>' />
                                        <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                        <asp:HiddenField ID="hfFlag_MostrarEnReporte" runat="server" Value='<%# Bind("Flag_MostrarEnReporte") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Datos Personales" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDatosPersonales" Text='<%# Bind("DatosPersonales") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Area" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblArea" Text='<%# Bind("Area") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Telef" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblTelefono" Text='<%# Bind("Telefono") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correo1" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCorreo1" Text='<%# Bind("Correo1") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correo2" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCorreo2" Text='<%# Bind("Correo2") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correo3" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCorreo3" Text='<%# Bind("Correo3") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Celular 1" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCelular1" Text='<%# Bind("Celular1") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Celular 2" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCelular2" Text='<%# Bind("Celular2") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Celular 3" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCelular3" Text='<%# Bind("Celular3") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_ContactosEdicion" style="display: none;" class="form-inputs">
        <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                    </td>
                    <td align="right" style="padding-top: 10px;" colspan="2">
                        <asp:Button ID="btnEditarContacto" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" />
                    </td>
                </tr>
                <tr style="padding-top: 10px">
                    <td style="font-weight: bold">
                        Nombre
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="3">
                                    <asp:TextBox ID="txtContactoEdicion" runat="server" Width="505px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="padding-top: 10px">
                    <td style="font-weight: bold">
                        Area
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtContactoAreaEdicion" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold; padding-left: 10px">
                                    Telefono
                                </td>
                                <td style="padding-left: 12px">
                                    <asp:TextBox ID="txtTelefonoContactoEdicion" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Correo 1
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCorreoContactoEdicion1" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold; padding-left: 10px">
                                    Correo 2
                                </td>
                                <td style="padding-left: 12px">
                                    <asp:TextBox ID="txtCorreoContactoEdicion2" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Correo 3
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCorreoContactoEdicion3" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold; padding-left: 10px">
                                    Celular 1
                                </td>
                                <td style="padding-left: 10px">
                                    <asp:TextBox ID="txtCelularContactoEdicion1" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        celular 2
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCelularContactoEdicion2" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold; padding-left: 10px">
                                    Celular 3
                                </td>
                                <td style="padding-left: 10px">
                                    <asp:TextBox ID="txtCelularContactoEdicion3" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Estado
                    </td>
                    <td style="font-weight: bold">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div id="div_EstadoContactoEdicion">
                                        <asp:DropDownList ID="ddlEstadoContactoEdicion" runat="server" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True">
                                            <asp:ListItem Value="1">Activo</asp:ListItem>
                                            <asp:ListItem Value="2">Inativo</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkFlag_MostrarEnReporteEdicion" runat="server" Text="Mostrar en Reporte"
                                        Font-Bold="True" />
                                </td>
                            </tr>
                        </table>
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
    <input id="hfRegion" type="hidden" value="0" />
    <input id="hfProvincia" type="hidden" value="0" />
    <input id="hfDistrito" type="hidden" value="0" />
    <input id="hfRegionEdicion" type="hidden" value="0" />
    <input id="hfProvinciaEdicion" type="hidden" value="0" />
    <input id="hfDistritoEdicion" type="hidden" value="0" />
    <input id="hfMoneda" type="hidden" value="0" />
    <input id="hfCodDireccion" type="hidden" value="0" />
    <input id="hfCodResponsable" type="hidden" value="0" />
    <input id="hfCodContacto" type="hidden" value="0" />
    <input id="hfurlapisunat" type="hidden" value="0" />
    <input id="hftokenapisunat" type="hidden" value="0" />
</asp:Content>
