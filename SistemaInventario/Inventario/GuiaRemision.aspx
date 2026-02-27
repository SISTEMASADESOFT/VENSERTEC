<%@ Page Title="Guia Remision" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"    CodeBehind="GuiaRemision.aspx.cs" Inherits="SistemaInventario.Inventario.GuiaRemision" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js" type="text/javascript"></script>       
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript"  charset="UTF-8"></script>      
    <script src="../Scripts/UtilitariosDatos.js" type="text/javascript"></script>
    <script src="../Scripts/inputatajos/kibo.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="GuiaRemision.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"     type="text/css" />   
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        GUIA DE REMISION</div>
    <div id="divTabs">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
        </ul>
        <div id="tabRegistro">
            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    Datos de Guia Remision
                </div>
                <div>
                    <table cellpadding="0" cellspacing="0" class="form-inputs" width="750">
                        <tr style="display: none;">
                            <td style="font-weight: bold">
                                Empresa
                            </td>
                            <td style="padding-left: 4px;">
                                <div id="div_Empresa">
                                    <asp:DropDownList ID="ddlEmpresa" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="404" Font-Size="Medium">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Tipo Doc
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div id="div_TipoDocumento">
                                                <asp:DropDownList ID="ddlTipoDocumento" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="124">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="font-weight: bold;display:none">
                                            almacen
                                        </td>
                                        <td style="font-weight: bold;display:none">
                                            <div id="div_Almacen">
                                                <asp:DropDownList ID="ddlAlmacen" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="100">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="padding-left: 38px; font-weight: bold; display: none">
                                            Factura
                                        </td>
                                        <td style="display: none">
                                            <asp:TextBox ID="txtSerieFactura" runat="server" Width="40px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="display: none">
                                            <asp:TextBox ID="txtNumeroFactura" runat="server" Width="60px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold;">
                                            Emision
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmision" runat="server" Width="55px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                        </td>
                                          <td style="font-weight: bold;padding-left: 51px;">
                                            Traslado
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTraslado" runat="server" Width="55px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Serie
                                        </td>
                                        <td style="padding-left: 31px">
                                            <div id="div_serie">
                                                <asp:DropDownList ID="ddlSerie" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNumero" runat="server" Width="46" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" MaxLength="8"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold;display:none">
                                            Ref
                                        </td>
                                        <td style="font-weight: bold;display:none">
                                            <asp:TextBox ID="txtReferencia" runat="server" Width="50" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                      <%--  <td style="font-weight: bold">
                                            Operacion
                                        </td>
                                        <td>
                                            <div id="div_MotivoTrabajo">
                                                <asp:DropDownList ID="ddlMotivoTrabajo" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="165px" Enabled="True">
                                                </asp:DropDownList>
                                            </div>
                                        </td>--%>
                                        <td style="font-weight: bold; display: none">
                                            <asp:Label ID="lblTC" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                        </td>
                                         <td style="font-weight: bold">
                                tipo transporte
                            </td>               
                                           <td>
                                                                <div id="div_TipoTransportista">
                                                                    <asp:DropDownList ID="ddlTipoTransportista" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                        Font-Bold="True" Width="195">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Proveedor
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtProveedor" runat="server" Width="400px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                      <td style="font-weight: bold">
                                            motivo
                                        </td>

                                             <td  style="padding-left: 21px;">
                                            <div id="div_MotivoTrabajo">
                                                <asp:DropDownList ID="ddlMotivoTrabajo" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="400px" Enabled="True">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="padding-left: 6px;display:none;">
                                            <div id="div_Direccion1">
                                                <asp:DropDownList ID="ddlDireccion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" BackColor="#FFFF99" Width="420">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                            <td style="display:none;">                                  
                                              <div id="Div_direccion">
                                              <asp:DropDownList ID="ddldireccionNueva" runat="server" Font-Names="Arial" ForeColor="Blue"
                                              Font-Bold="True" Width="400" Font-Size="Small">
                                              </asp:DropDownList>
                                              </div>
                                              </td>
                                             <td style = "display:none;">
                                              <asp:ImageButton runat="server" ID="imgDireccion" ImageUrl="../Asset/images/add_small.png"
                                              ToolTip="DIRECCION" OnClientClick="F_DireccionesTemporal(hfCodigoTemporal,hfCodProvincia,hfCodDistrito,hfCodDepartamento,MainContent_txtDireccionMultiple,MainContent_txtDistritoMultiple,1,0); return false;" />
                                              </td>   
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold;">
                                   <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                              </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtPartida" runat="server" Width="400px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Enabled="False"></asp:TextBox>
                                        </td>
                                           <td style="font-weight: bold; color: #FF0000; font-size: small;">
                                            Destino
                                        </td>
                                        <td style="padding-left: 18px;display:none;">
                                            <div id="div_Destino">
                                                <asp:DropDownList ID="ddlDestino" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" BackColor="#FFFF99" Width="420">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                         <td  style="padding-left:2px;">
                                        <div id="Div_DireccionDestino">
                                        <asp:DropDownList ID="ddldireccionNuevaDestino" runat="server" Font-Names="Arial" ForeColor="Red"
                                        Font-Bold="True" Width="400" Font-Size="Small">
                                        </asp:DropDownList>
                                        </div>
                                        </td>
                                        <td>
                                        <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="../Asset/images/add_small.png"
                                        ToolTip="DIRECCION" OnClientClick="F_DireccionesTemporal(hfCodigoTemporal,hfCodProvincia,hfCodDistrito,hfCodDepartamento,MainContent_txtDireccionMultiple,MainContent_txtDistritoMultiple,2,0); return false;" />
                                         </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                     
                      
                        <tr id="tdtrasn1" >
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
                                                                <asp:TextBox ID="txtTransportista" runat="server" Width="320" Font-Names="Arial"
                                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                            </td>
                                        <td style="font-weight: bold">
                                            Direccion
                                        </td>
                                        <td  style="padding-left: 6px;display:none;">
                                             <asp:TextBox ID="txtDireccionTransportista" Style="position: absolute;" runat="server" Width="415" Font-Names="Arial"
                                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                <asp:DropDownList ID="dllDireccionTransportista" runat="server" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" BackColor="#FFFF99" Width="420">
                                                </asp:DropDownList>
                                            
                                        </td>
                                        <td style="padding-left: 6px;">
                                         <div id="Div_DireccionTransportista">
                                         <asp:DropDownList ID="ddldireccionNuevaTransportista" runat="server" Font-Names="Arial" ForeColor="Blue"
                                          Font-Bold="True" Width="400" Font-Size="Small">
                                           </asp:DropDownList>
                                         </div>
                                         </td>
                                        <td>
                                         <asp:ImageButton runat="server" ID="ImageButton2" ImageUrl="../Asset/images/add_small.png"
                                          ToolTip="DIRECCION" OnClientClick="F_DireccionesTemporal(hfCodigoTemporal,hfCodProvincia,hfCodDistrito,hfCodDepartamento,MainContent_txtDireccionMultiple,MainContent_txtDistritoMultiple,3,1); return false;" />
                                           </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="tdtrasn2">                           
                             <td style="font-weight: bold">
                                          Licencia  
                                        </td>
                            <td style="padding-left: 2px;">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                    
                                        <td >
                                            <asp:TextBox ID="txtLicenciaGuia" runat="server" Width="100" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style = "display:none;">
                                                    <asp:CheckBox ID="chkGuia" runat="server" Text="Guia Serie" Font-Bold="True" Checked="True" />
                                                </td>
                                        <td style="font-weight: bold">
                                         Placa
                                         </td>
                                        <td>
                                            <asp:TextBox ID="txtPlaca" runat="server" Width="100" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>                                        
                                        <td style="font-weight: bold; padding-left: 6px;">
                                            Marca
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMarcaGuia" runat="server" Width="100" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold;">
                                            nro Bult.
                                        </td>
                                        <td style="padding-left: 10px;">
                                        <asp:TextBox ID="txtNuBultos" runat="server" Width="40" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold;padding-left: 60px;">
                                            Peso
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPeso" runat="server" Width="40" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                        </td>
                                        <td>
                                          <div id="div_codunidadpeso">
                                                                    <asp:DropDownList ID="ddlcodunidadpeso" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                        Font-Bold="True">
                                                                    </asp:DropDownList>
                                                                </div>
                                          </td>
                                        <td>
                                            <asp:CheckBox ID="chkImpresion" runat="server" Text="Impresion" Font-Bold="True"
                                                Checked="True" />
                                        </td>

                                         <td >
                                                      
                                                            <asp:CheckBox ID="chkImpresionTicket" runat="server" Text="Ticket" 
                                                                Font-Bold="True" />
                                                 
                                                    </td>
                                       </tr>                                
                                </table>
                            </td>
                        </tr>

                          <tr>
                         <td style="font-weight: bold;padding-left: 0px">
                                                    Conductor
                                                </td>
                         <td>
                                                <table  cellpadding="0" cellspacing="0">
                                                 <td>
                                                                <asp:TextBox ID="txtConductorDNI" runat="server" Width="80" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" onblur="F_ValidaRucDniConductor(); return false;" ></asp:TextBox>
                                                            </td>
                                                            <td style=" ">
                                                                <asp:TextBox ID="txtConductorRazonSocial" runat="server" Width="312px" Font-Names="Arial"
                                                                    ForeColor="Blue" Font-Bold="True" placeholder="NOMBRE CONDUCTOR"></asp:TextBox>
                                                            </td>
                                                         
                                                </table>
                                                </td>
                                                  
                        </tr>

                            <tr style="font-weight: bold;display:none">
                            <td style="font-weight: bold;display:none">
                                Formato
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <div id="div4">
                                                <asp:DropDownList ID="ddlFormatoImpresion" runat="server" Font-Names="Arial" ForeColor="Blue" Font-Bold="True" Width="400">
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
                    <asp:Button ID="btnNuevo" runat="server" Text="Limpiar (F1)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar (F2)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar (F5)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar (F6)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </div>
            </div>
            <div style="text-align: center; width: 100%; color: Black; font-weight: bold">
                Cantidad de registros
                <asp:Label ID="lblNumRegistros" runat="server" Text="0"></asp:Label>
            </div>
            <div id="div_grvDetalleArticulo" style="padding-top: 5px;">
                <asp:GridView ID="grvDetalleArticulo" runat="server" AutoGenerateColumns="False"
                    border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                    Width="1013px">
                    <Columns>
                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                           <HeaderTemplate>
                              <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                          </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                             <asp:TemplateField HeaderText="ITEM">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblNro" Text='<%# Bind("NroRow") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CodigoProducto" HeaderText="Codigo">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Descripcion">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblProducto" Text='<%# Bind("Producto") %>' CssClass="detallesart"></asp:Label>
                                <asp:HiddenField ID="hfCodArticulo" runat="server" Value='<%# Bind("CodArticulo") %>' />
                                <asp:HiddenField ID="hfCantidad" runat="server" Value='<%# Bind("Cantidad") %>' />
                                <asp:HiddenField ID="hfPrecio" runat="server" Value='<%# Bind("Precio") %>' />
                                <asp:HiddenField ID="hfCodDetalle" runat="server" Value='<%# Bind("CodDetalle") %>' />
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
                                    CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Cantidad") %>'
                                    onblur="F_ActualizarCantidad(this.id); return false;"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="UM" HeaderText="UM">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Precio" ItemStyle-HorizontalAlign="Center" Visible="false">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtPrecio" Width="75px" Font-Bold="true" Style="text-align: center;"
                                    ForeColor="Blue" CssClass="ccsestilo" Font-Names="Arial" Text='<%# Bind("Precio") %>'
                                    onblur="F_ActualizarPrecio(this.id); return false;"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Importe" Visible="false">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblimporte" Text='<%# Bind("Importe") %>' CssClass="detallesart"></asp:Label>
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
                                    EMPRESA
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <div id="div_EmpresaConsulta">
                                                    <asp:DropDownList ID="ddlEmpresaConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Enabled="False" Font-Bold="True" Width="200">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td style="font-weight: bold">
                                                Tipo Doc
                                            </td>
                                            <td>
                                                <div id="div_TipoDocConsulta">
                                                    <asp:DropDownList ID="ddlTipoDocConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="125">
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
                                            <td style="font-weight:bold;display:none;">                                    
                                                <div id="div_FormatoImpresion">                                       
                                                    <asp:DropDownList ID="ddlFormatoImpresion2" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                     Font-Bold="True" Width="65px">
                                                        <asp:ListItem Value="1">A4</asp:ListItem>
                                                        <asp:ListItem Value="2">A5</asp:ListItem>
                                                        <asp:ListItem Value="3">TICKET</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkCliente" runat="server" Text="Proveedor" Font-Bold="True" />
                                </td>
                                <td style="padding-left: 6px;">
                                    <asp:TextBox ID="txtClienteConsulta" runat="server" Width="380" Font-Names="Arial"
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
            <div style="padding-top: 5px;">
               <table cellpadding="0" cellspacing="0" align="center">
                                    <tr>
                                        <td style="font-weight: bold">
                                           Cantidad de Registros:
                                        </td>
                                        <td style="font-weight: bold">
                                            <label id="lblNumeroConsulta"></label>
                                        </td>                                
                                    </tr>
                                </table>
            </div>
            <div id="div_consulta" style="padding-top: 5px;">
                <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                    CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1000px"
                    OnRowDataBound="grvConsulta_RowDataBound">
                    <Columns>                 
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/Eliminar.jpg"
                                    ToolTip="ANULAR GUIA" OnClientClick="F_AnularPopUP(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>                 
                         <asp:TemplateField HeaderText="TK">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgTCK" ImageUrl="~/Asset/images/imprimir.gif"
                                    ToolTip="Imprimir Ticket" OnClientClick="F_ImprimirFacturaGrilla(this,'TK'); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IMP">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgimpPdf" ImageUrl="~/Asset/images/imprimir.gif"
                                    ToolTip="Imprimir Factura" OnClientClick="F_ImprimirFacturaGrilla(this,'IMP'); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" Visible="true">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgPdf" ImageUrl="~/Asset/images/pdf.png" ToolTip="VISUALIZAR PDF"
                                    OnClientClick="F_ImprimirFacturaPDF(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="A">
                            <ItemTemplate>
                                <img id="imgMasAuditoria" alt="" style="cursor: pointer" src="../Asset/images/plus.gif"
                                    onclick="imgMasAuditoria_Click(this);" title="Auditoria" />
                                <asp:Panel ID="pnlOrdersAuditoria" runat="server" Style="display: none">
                                    <asp:GridView ID="grvDetalleAuditoria" runat="server" border="0" CellPadding="0"
                                        CellSpacing="1" AutoGenerateColumns="False" GridLines="None" class="GridView">
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
                                <img id="imgMasObservacion" alt="" style="cursor: pointer" src="../Asset/images/plus.gif"
                                    onclick="imgMasObservacion_Click(this);" title="OBSERVACION" />
                                <asp:Panel ID="pnlOrdersObservacion" runat="server" Style="display: none">
                                    <asp:GridView ID="grvDetalleObservacion" runat="server" border="0" CellPadding="0"
                                        CellSpacing="1" AutoGenerateColumns="False" GridLines="None" class="GridView">
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
                        <asp:TemplateField>
                            <ItemTemplate>
                                <img id="imgMas" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click(this);"
                                    title="Ver Detalle" />
                                <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                    <asp:GridView ID="grvDetalle" runat="server" border="0" CellPadding="0" CellSpacing="1"
                                        AutoGenerateColumns="False" GridLines="None" class="GridView">
                                        <Columns>
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
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <%-- <asp:BoundField DataField="Empresa" HeaderText="EMP">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Numero">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblNumero" Text='<%# Bind("Numero") %>' CssClass="detallesart"></asp:Label>
                                <asp:HiddenField ID="hfCodigo" runat="server" Value='<%# Bind("ID") %>' />
                               <%-- <asp:HiddenField ID="hfAutomatico" runat="server" Value='<%# Bind("Automatico") %>' />--%>
                                <asp:HiddenField ID="hfDetalleCargadoObservacion" runat="server" Value='0' />
                                <asp:HiddenField ID="hfDetalleCargadoAuditoria" runat="server" Value='0' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Razon Social">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCliente" Text='<%# Bind("RazonSocial") %>'></asp:Label>
                                <asp:HiddenField ID="hfCodTipoDoc" runat="server" Value='<%# Bind("CodTipoDoc") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Emision" HeaderText="Emision">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Estado">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Factura" HeaderText="Factura">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Operacion" HeaderText="Operacion">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>                  
                     
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div id="divConsultaArticulo" style="display: none;">
        <div id='divCabecera' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                Criterio de busqueda
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                    <tbody>
                        <tr>
                            <td style="font-weight: bold">
                                Descripcion
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="padding-left: 5px; font-weight: bold">
                                            <asp:CheckBox ID="chkDescripcion" runat="server" Text="descripcion" Font-Bold="True"
                                                Style="display: none;" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtArticulo" runat="server" Width="717px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                       <%-- <td>
                                            <asp:CheckBox runat="server" ID="chkProductosConStock" Text="Productos con Stock"
                                                Checked="True" Font-Bold="True" />
                                        </td>--%>
                                        <td>
                                            <asp:Button ID="btnBuscarArticulo" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                Font-Names="Arial" Font-Bold="True" Width="120" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="linea-button">
            </div>
            <div>
                <table>
                    <tr>
                        <td valign="top">
                          <div style="text-align: center; width: 100%; color: Black; font-weight: bold">
                Cantidad de registros
                <asp:Label ID="lblcantidadregistroproductos" runat="server" Text="0"></asp:Label>
            </div>
                            <div style="overflow-y: scroll; height: 375px;">
                                <div id="div_grvConsultaArticulo" style="padding-top: 5px">
                                    <asp:GridView ID="grvConsultaArticulo" runat="server" AutoGenerateColumns="False"
                                        border="0" CellPadding="0" CellSpacing="1" CssClass="GridView GridView-MaxHeight"
                                        GridLines="None" Width="1150px" OnRowDataBound="grvConsultaArticulo_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="imgAgregar" ImageUrl="~/Asset/images/ok.gif"
                                                        ToolTip="Agregar" OnClientClick="F_AgregarArticulo(this.id,1); return false;" />
                                                </ItemTemplate>
                                            </asp:TemplateField>                              
                                            <asp:TemplateField HeaderText="Código">
                                                <ItemStyle Font-Bold="true" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="hlkCodNeumaticoGv" Text='<%# Bind("CodigoProducto") %>' CssClass="detallesart"></asp:Label>
                                                    <asp:HiddenField ID="lblcodproducto" runat="server" Value='<%# Bind("CodProducto") %>' />
                                                    <asp:HiddenField ID="hfcodunidadventa" runat="server" Value='<%# Bind("CodUnidadVenta") %>' />
                                                    <asp:HiddenField ID="hfcosto" runat="server" Value='<%# Bind("Costo") %>' />
                                                    <asp:HiddenField ID="lblPrecio1" runat="server" Value='<%# Bind("Precio1") %>' />
                                                    <asp:HiddenField ID="lblPrecio2" runat="server" Value='<%# Bind("Precio2") %>' />
                                                    <asp:HiddenField ID="lblPrecio3" runat="server" Value='<%# Bind("Precio3") %>' />
                                                    <asp:HiddenField ID="hfMedida" runat="server" Value='<%# Bind("Medida") %>' />
                                                    <asp:HiddenField ID="hfMarca" runat="server" Value='<%# Bind("Marca") %>' />
                                                    <asp:HiddenField ID="hfModelo" runat="server" Value='<%# Bind("Modelo") %>' />
                                                    <asp:HiddenField ID="hfPosicion" runat="server" Value='<%# Bind("Posicion") %>' />
                                                    <asp:HiddenField ID="hfDescripcion" runat="server" Value='<%# Bind("Descripcion") %>' />
                                                    <asp:HiddenField ID="hfAnio" runat="server" Value='<%# Bind("Anio") %>' />
                                                    <asp:HiddenField ID="hfCodigoAlternativo" runat="server" Value='<%# Bind("Codigo2") %>' />
                                                    <asp:HiddenField ID="hfFlagProductoInicial" runat="server" Value='<%# Bind("FlagProductoInicial") %>' />
                                                    <asp:HiddenField ID="hfMoneda" runat="server" Value='<%# Bind("Moneda") %>' />
                                                    <asp:HiddenField ID="hfStock" runat="server" Value='<%# Bind("Stock") %>' />
                                                    <asp:HiddenField ID="hfCodigoInterno" runat="server" Value='<%# Bind("CodigoInterno") %>' />
                                                    <asp:HiddenField ID="hfCodProductoAzure" runat="server" Value='<%# Bind("CodProductoAzure") %>' />
                                                    <asp:HiddenField ID="hfDetalleCargado" runat="server" Value='0' />                                                    
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Descripcion" HeaderStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:HyperLink runat="server" ID="lblProducto" Font-Underline="true" ForeColor="Blue"
                                                        Style="cursor: hand" Text='<%# Bind("Producto") %>' onclick="F_AgregarArticuloFromDsc(this.id); return false;">
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="MARCA">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblMarca" Text='<%# Bind("MARCA") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Stock">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblstock" Text='<%# Bind("Stock") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="UM">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblUM" Text='<%# Bind("UM") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>                                   
                                            <asp:TemplateField HeaderText="Precio" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" ID="txtPrecioLibre" Width="55px" Font-Bold="true" Style="text-align: center;"
                                                        CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Precio1") %>'
                                                        onblur="F_ValidarPrecioGrilla(this.id); return false;" Enabled="false"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Precio" Visible="false">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlPrecio" runat="server" CssClass="ccsestilo" Font-Bold="true">
                                                    </asp:DropDownList>
                                                    <%--<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlQuantity_SelectedIndexChanged"></asp:DropDownList>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cant." ItemStyle-HorizontalAlign="Center" Visible="false">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" ID="txtCantidad" Width="55px" Font-Bold="true" Style="text-align: center;"
                                                        CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" onblur="F_ValidarStockGrilla(this.id); return false;"
                                                        Enabled="False"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </td>
                     <%--   <td id="tdPanelStocks" valign="top" style="display: none">
                            <div id="divStocksEmpresas" style="width: 230px; padding-top: 5px">
                                <table>
                                    <thead>
                                        <tr>
                                            <th style="width: 190px">
                                                Almacen
                                            </th>
                                            <th style="width: 25px">
                                                Stock
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                KARINA Principal
                                            </td>
                                            <td align="right">
                                                10
                                            </td>
                                        </tr>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td>
                                                TOTAL
                                            </td>
                                            <td align="right">
                                                10
                                            </td>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                            <div id="div_ultimoprecio">
                                <div class="ui-jqdialog-content">
                                    <div class="ui-jqdialog-content">
                                        <%--COMBO
                                        <div id="divcombo">
                                            <%--<asp:Label runat="server" ID="lblID" Text='<%# Bind("ID") %>'></asp:Label>
                                            <asp:Label runat="server" ID="lbCodProducto" Text=""></asp:Label>
                                            <asp:Label runat="server" ID="lbCodNeumatico" Text=""></asp:Label>
                                            <asp:TextBox ID="txtClienteDropTop" runat="server" Width="227px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            <asp:DropDownList ID="ddlDropTop" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True">
                                                <asp:ListItem Text="Top 5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="Top 10" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="Top 15" Value="15"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Button ID="btnBuscarTop" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                Font-Names="Arial" Font-Bold="True" Width="120" />
                                        </div>
                                        <%--GRID CON LOS ULTIMOS PRECIOS
                                        <div id="div_grvConsultaUltimosPrecios" style="padding-top: 5px;">
                                            <asp:GridView ID="grvConsultaUltimosPrecios" runat="server" AutoGenerateColumns="False"
                                                border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                                Width="227px">
                                                <Columns>
                                                    <asp:BoundField DataField="Precio" HeaderText="Precio Unitario">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Moneda" HeaderText="Moneda">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" Visible="false">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" Visible="false">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Factura" HeaderText="Factura" Visible="false">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </td>--%>
                    </tr>
                </table>
            </div>
            <div class="linea-button">
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                    <tbody>
                        <tr>
                            <td style="font-weight: bold">
                                Codigo
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
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
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                           
                            <td colspan='2'>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
 <td style="font-weight: bold;display:none;">
                                <asp:CheckBox ID="chkServicios" runat="server" Text="Servicios" Font-Bold="True"/>
                                 
                            </td>
                                        <td>
                                            <asp:TextBox ID="txtArticuloAgregar" runat="server" Width="700px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True" Font-Size="16"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Cantidad
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCantidad" runat="server" Width="40px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" CssClass="Derecha" Font-Size="16"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold; display: none">
                                            Precio
                                        </td>
                                        <td style="display: none">
                                            <asp:TextBox Style="width: 80px; color: blue; font-family: Arial; font-weight: bold;
                                                background: rgb(255, 255, 224);" ID="txtPrecioDisplay" runat="server" Font-Size="16"></asp:TextBox>
                                            <%--                                            <asp:DropDownList ID="ddlPrecio" Style="width: 100px" runat="server" Font-Size="16">
                                                <asp:ListItem Value="test1">test1</asp:ListItem>
                                                <asp:ListItem Value="test2">test2</asp:ListItem>
                                            </asp:DropDownList>--%>
                                        </td>
                                        <td style="font-weight: bold;display:none;">
                                            <asp:Label ID="lblMonedaAgregar" runat="server" Text="" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                Font-Names="Arial" Font-Bold="True" Width="120" />
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
    <div id="divFacturacionOC" style="display: none;">
        <table cellpadding="0" cellspacing="0" width="850">
            <tr>
                <td align="right" style="padding-top: 10px;">
                    <asp:Button ID="btnDevolverItemOC" runat="server" Text="Devolver" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Width="120" />
                    <asp:Button ID="btnAgregarItemOC" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Width="120" />
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
                                        <asp:HiddenField ID="hfCodArticulo" runat="server" Value='<%# Bind("CodArticulo") %>' />
                                        <asp:HiddenField ID="hfCodUndMedida" runat="server" Value='<%# Bind("CodUndMedida") %>' />
                                        <asp:HiddenField ID="hfCodMovimiento" runat="server" Value='<%# Bind("CodMovimiento") %>' />
                                        <asp:HiddenField ID="hfSerieDoc" runat="server" Value='<%# Bind("SerieDoc") %>' />
                                        <asp:HiddenField ID="hfNumeroDoc" runat="server" Value='<%# Bind("NumeroDoc") %>' />
                                        <asp:HiddenField ID="hfCostoUnitario" runat="server" Value='<%# Bind("CostoUnitario") %>' />
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
                   <td style="font-weight: bold;padding-top:5px;"  align="right">
                        <asp:Button ID="btnAnular" runat="server" Text="ELIMINAR" class="ui-button ui-widget
    ui-state-default ui-corner-all ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="120" />
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
    <input id="hfProveedor" type="hidden" value="" />
    <input id="hfCodTransportista" type="hidden" value="0" />
    <input id="hfCodMovimiento" type="hidden" value="0" />
    <input id="hfCodCtaCteConsulta" type="hidden" value="0" />
    <input id="hfCodigoTemporal" type="hidden" value="0" />
    <input id="hfCodDocumentoVenta" type="hidden" value="0" />
    <input id="hfCodFacturaAnterior" type="hidden" value="0" />
    <input id="hfDireccion" type="hidden" value="" />
    <input id="hfDestino" type="hidden" value="" />
    <input id="hfCodProductoAgregar" type="hidden" value="0" />
    <input id="hfMenorPrecioAgregar" type="hidden" value="0" />
    <input id="hfCostoAgregar" type="hidden" value="0" />
    <input id="hfCodUmAgregar" type="hidden" value="0" />
    <input id="hfCodEmpresa" type="hidden" value="0" />
    <input id="hfCodAlmacen" type="hidden" value="0" />
    <input id="hfCodDocumentoVentaAnulacion" type="hidden" value="0" />
    <input id="hfClienteAnulacion" type="hidden" value="0" />
    <input id="hfCodDireccionTransportista" type="hidden" value="0" />
    <input id="hfCodDireccionDefectoTransportista" type="hidden" value="0" />
    <input id="hfCodDepartamentoTransportista" type="hidden" value="0" />
    <input id="hfCodProvinciaTransportista" type="hidden" value="0" />
    <input id="hfCodDistritoTransportista" type="hidden" value="0" />
    <input id="hfCodCtaCteTransportista" type="hidden" value="0" />
    <input id="hfDistritoTransportista" type="hidden" value="0" />
    <input id="hfDniConductor" type="hidden" value="0" />
    <input id="hfCodConductor" type="hidden" value="0" />
    <input id="hfNombreConductor" type="hidden" value="0" />
    <input id="hfNroRucTransportista" type="hidden" value="0" />
    <input id="hfTransportista" type="hidden" value="0" />
</asp:Content>
