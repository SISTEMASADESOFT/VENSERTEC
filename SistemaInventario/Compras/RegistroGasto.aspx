<%@ Page Title="Gastos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroGasto.aspx.cs" Inherits="SistemaInventario.Compras.RegistroGasto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>  <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript"  src="RegistroGasto.js" charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />  <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />   <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />

 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="titulo">Gastos</div> 
                     <div id="divTabs">

                        <ul>
                            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
                            <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
                        </ul>

                        <div id="tabRegistro">
                               <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" >
                                   <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                                    REGISTRO DE Gastos
                                   </div>
                           
                                   <div >  
                                         <table  cellpadding="0" cellspacing="0" class="form-inputs" width="550">
                                              <tr>
                                                  <td  style="font-weight: bold">
                                                    proveedor
                                                  </td>

                                                  <td>
                                                    <table  cellpadding="0" cellspacing="0">
                                                        <tr>
                                                              <td>
                                                                <asp:TextBox ID="txtProveedor" runat="server" Width="350px"   ForeColor="Blue"  Font-Names="Arial" Font-Bold="True" ></asp:TextBox>
                                                             </td>

                                                              <td>
                                                                <asp:ImageButton ID="imgAddScop" runat="server" style="display:none;"  ImageUrl="~/Asset/images/add_small.png" ImageAlign="AbsMiddle" ToolTip="Agregar Proveedor" />       
                                                             </td>

                                                             

                                                              <td style="font-weight: bold">
                                                                Serie
                                                              </td>

                                                              <td>
                                                                <asp:TextBox ID="txtSerie" runat="server" Width="100"   ForeColor="Blue"  Font-Names="Arial" Font-Bold="True" ></asp:TextBox>
                                                              </td>

                                                              <td>
                                                    <asp:TextBox ID="txtNumero" runat="server" Width="100"  Font-Names="Arial" Font-Bold="True"   ForeColor="Blue" ></asp:TextBox>
                                                  </td>

                                                              <td style="font-weight: bold">
                                                    Igv
                                                  </td>

                                                              <td style="padding-left:13px;">
                                     
                                                     <div id="div_igv">
                                                         <asp:DropDownList ID="ddlIgv" runat="server"  Font-Names="Arial" Font-Bold="True" Width="60"  ForeColor="Blue" >
                                                         </asp:DropDownList>
                                                     </div>
                                    
                                                </td>

                                                              <td>
                                                                <asp:Label ID="Label1" runat="server" Text="T.C." Font-Bold="True"></asp:Label>
                                                             </td>

                                                              <td>
                                                                <asp:Label ID="lblTC" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                                             </td>
                                                        </tr>
                                                     </table>
                                                  </td>

                                              </tr>
                                
                                              <tr>
                                                  <td style="font-weight: bold">
                                                    Tipo doc
                                                  </td>

                                                  <td>
                                                 <table cellpadding="0" cellspacing="0">
                                                 <tr>
                                                 <td >
                                          <div id="div_tipodocumento">
                                     <asp:DropDownList ID="ddlTipoDocumento" runat="server"  Font-Names="Arial" Font-Bold="True" Width="160"  ForeColor="Blue"  >
                                     </asp:DropDownList>
                                   </div> 
                                 </td>

                              <td style="padding-left:86px;font-weight: bold">
                               Emision
                                </td>
                                
                                                  <td>
                                  <asp:TextBox ID="txtEmision" runat="server" Width="55px" CssClass="Jq-ui-dtp"    ForeColor="Blue"  Font-Names="Arial" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                  </td>

                                                  <td style="padding-left:5px;font-weight: bold">
                                  cond.
                                  </td>

                                                  <td>
                                        <div id="div_formapago">
                                   <asp:DropDownList ID="ddlFormaPago" runat="server"  Font-Names="Arial" Font-Bold="True" Width="103px"  ForeColor="Blue"   >
                                     </asp:DropDownList>
                                   </div>
                                  </td>

                                                  <td style="padding-left:16px;font-weight: bold">
                                  vcto
                                  </td>

                                                  <td>
                                    <asp:TextBox ID="txtVencimiento" runat="server"  Width="55px"  Font-Names="Arial" Font-Bold="True"   ForeColor="Blue"  ReadOnly="True"></asp:TextBox>
                                  </td>
                                        <td   style="font-weight: bold">
                                     PERIODO 
                                     </td>
                                                
                                                  <td>
                                  <asp:TextBox ID="txtPeriodo" runat="server" Width="38px"   ForeColor="Blue"  Font-Names="Arial" Font-Bold="True" CssClass="MesAnioPicker" ReadOnly="True"></asp:TextBox>
                                  
                                  </td>
                                                 </tr>
                                                 </table>
                                                 </td>

                                              </tr>
                                
                                              <tr>
                                                  <td style="font-weight: bold">
                             clasificacion
                             </td>

                                                  <td>
                             <table  cellpadding="0" cellspacing="0">
                             <tr>
                                <td>
                                <div id="div_clasificacion">
                                         <asp:DropDownList ID="ddlClasificacion" runat="server"  Font-Names="Arial" 
                                             Font-Bold="True" Width="160"  ForeColor="Blue" Enabled="False" >
                                         </asp:DropDownList>
                                     </div>
                                </td>
                                    <td style="padding-left:67px;font-weight: bold">
                                                                Moneda
                                                              </td>

                                   <td>
                                                                 <div id="div_moneda">
                                                                     <asp:DropDownList ID="ddlMoneda" runat="server"  Font-Names="Arial" Font-Bold="True"  ForeColor="Blue" >
                                                                     </asp:DropDownList>
                                                                 </div>
                                                              </td>
                                         <td style="padding-left:4px;font-weight: bold">
                             total
                             </td>
                              <td >
                             <asp:TextBox ID="txtTotal" runat="server"  Width="73px"  Font-Names="Arial" Font-Bold="True"   ForeColor="Blue"  Text="0.00"></asp:TextBox>
                             </td>
                             
                                                     <td style="padding-left:21px;font-weight: bold">
                             SubTotal
                             </td>

                                                     <td>
                             <asp:TextBox ID="txtSubTotal" runat="server"  Width="55px"  Font-Names="Arial" Font-Bold="True"   ForeColor="Blue"  ReadOnly="True" Text="0.00"></asp:TextBox>
                             </td>

                                                     <td style="padding-left:0px;font-weight: bold">
                             Igv
                             </td>

                                                     <td style="padding-left:16px;">
                             <asp:TextBox ID="txtIgv" runat="server"  Width="55px"  Font-Names="Arial" Font-Bold="True"   ForeColor="Blue"  ReadOnly="True" Text="0.00"></asp:TextBox>
                             </td>

                              
                            
                             </tr>
                             </table>
                             </td>

                                              </tr>

                                              <tr>
                                               <td  style="font-weight: bold">
                                                     Categoria
                                                     </td>
                                              <td>
                                              <table  cellpadding="0" cellspacing="0">
                                              <tr>
                                              <td>
                                                <div id="div_Categoria">
                                                     <asp:DropDownList ID="ddlCategoria" runat="server"  Font-Names="Arial" 
                                                     Font-Bold="True" Width="160"  ForeColor="Blue" >
                                                    </asp:DropDownList>
                                     </div>
                                     </td>
                                     <td style="font-weight: bold;padding-left:50px;">

                                     Descuento
                                
                                              </td>
                                                   <td>
                             <asp:TextBox ID="txtDsctoTotal" runat="server"  Width="73px"  Font-Names="Arial" Font-Bold="True" Text="0.00"  ForeColor="Blue" ></asp:TextBox>
                             </td>
                                        <td  style="font-weight: bold;padding-left:131px;">
                             NO AFECTO
                             </td>

                                              <td>
                             <asp:TextBox ID="txtNoAfecto" runat="server"  Width="55px"  Font-Names="Arial" Font-Bold="True" Text="0.00"  ForeColor="Blue" ></asp:TextBox>
                             </td>
                                              </tr>
                                              </table>
                                             
                                              </td>
                                              </tr>
                                        </table>
                             
                            </div>     
                                <div class="linea-button">  
                      
                           
                                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo"  
                                class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                         Font-Names="Arial" Font-Bold="True"    Width="120" />
                    
                                <asp:Button ID="btnGrabar" runat="server" Text="Grabar"  
                                class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                         Font-Names="Arial" Font-Bold="True"   Width="120"  />
                                                                                     
                            </div>
                               
                        </div>

                               <div id="divEdicionRegistro" style="display:none;">
                           
                                  <div class="ui-jqdialog-content">
                                   <table  cellpadding="0" cellspacing="0" class="form-inputs">
                                        <tr>

                                     <td >
                                            Codigo Producto
                                     </td>

                                     <td style="padding-left:4px;" >
                                        <asp:TextBox ID="txtCodigoProductoEdicion" runat="server" Width="211px"  Font-Names="Arial" Font-Bold="True" ></asp:TextBox>
                                                                                
                                     </td>

                                     <td style="padding-left:0px;">
                                        Familia
                                      </td>
                                                                       
                                     <td style="padding-left:0px;">
                                     <div id="div_FamiliaEdicion">
                                         <asp:DropDownList ID="ddlFamiliaEdicion" runat="server"  Font-Names="Arial" Font-Bold="True"> 
                                          </asp:DropDownList>
                                     </div>
                                 </td>

                                     <td>
                                     t.c.
                                     </td>

                                     <td>
                                   
                                     <asp:TextBox ID="txtTcEdicion" runat="server" Width="31px"  Font-Names="Arial" Font-Bold="True" ReadOnly="True" Text="2.796"></asp:TextBox>
                                     </td>
                                     
                                     </tr>
                                
                                        <tr>
                               
                                 
                                 <td>
                                   Descripcion
                                 </td>
                                                                    
                                 <td colspan='5'   style="padding-left:4px;">
                                   <asp:TextBox ID="txtDescripcionEdicion" runat="server" Width="502px"  Font-Names="Arial" Font-Bold="True" ></asp:TextBox>
                                 </td>

                                 </tr>

                                        <tr>

                                         <td>
                                            Aro /PESO
                                         </td>

                                         <td colspan='5'>
                                        <table  cellpadding="0" cellspacing="0" >
                             <tr>

                                 <td >
                             <asp:TextBox ID="txtAroEdicion" runat="server"  Width="75px"  Font-Names="Arial" Font-Bold="True"></asp:TextBox>
                             </td>

                                 <td>
                             Medida
                             </td>

                                 <td  style="padding-left:10px;">
                             <asp:TextBox ID="txtMedidaEdicion" runat="server"  Width="75px"  Font-Names="Arial" Font-Bold="True"></asp:TextBox>
                             </td>

                                 <td>
                             Seccion
                             </td>

                                 <td style="padding-left:21px;">
                             <asp:TextBox ID="txtSeccionEdicion" runat="server"  Width="75px"  Font-Names="Arial" Font-Bold="True" ></asp:TextBox>
                             </td>

                                  <td style="padding-left:0px;">
                             Factor
                             </td>
                             <td style="padding-left:15px;">
                             <asp:TextBox ID="txtFactorEdicion" runat="server"  Width="75px"  Font-Names="Arial" Font-Bold="True"  Text="0.00"></asp:TextBox>
                             </td>
                                </tr>

                                </table>
                                         </td>

                                </tr>

                                        <tr>
                                <td>
                             Costo Con Igv
                             </td>

                                <td colspan='5'>
                                <table  cellpadding="0" cellspacing="0" >
                                <tr>
                               
                                   
                                      <td >
                             <asp:TextBox ID="txtCostoEdicion" runat="server"  Width="75px"  Font-Names="Arial" Font-Bold="True"></asp:TextBox>
                             </td>

                             <td>
                                Moneda
                                </td>
                                                                    
                                     <td style="padding-left:6px;">
                                <div id="div_MonedaEdicion">
                                         <asp:DropDownList ID="ddlMonedaEdicion" runat="server"  Font-Names="Arial" Font-Bold="True" Width="78">
                                         </asp:DropDownList>
                                     </div>
                                </td>

                                      <td style="padding-left:3px;">
                             UM COMPRA
                             </td>

                             <td style="padding-left:2px;">
                                     <div id="div_CompraEdicion">
                                         <asp:DropDownList ID="ddlCompraEdicion" runat="server"  Font-Names="Arial" Font-Bold="True" Width="78">
                                         </asp:DropDownList>
                                     </div>
                               </td>

                                     <td style="padding-left:3px;">
                             UM Venta
                             </td>

                             <td>
                                     <div id="div_VentaEdicion">
                                         <asp:DropDownList ID="ddlVentaEdicion" runat="server"  Font-Names="Arial" Font-Bold="True" Width="78">
                                         </asp:DropDownList>
                                     </div>
                               </td>
                               
                             </tr>
                                </table>
                                </td>
                                </tr>
                                
                                        <tr>
   <td>
                             Costo S/ Con Igv
                             </td>
                                <td colspan='5'>
                                <table  cellpadding="0" cellspacing="0" >
                                <tr>
                               
                                   

                                      <td >
                             <asp:TextBox ID="txtCostoSolesEdicion" runat="server"  Width="75px"  Font-Names="Arial" Font-Bold="True"></asp:TextBox>
                             </td>

                             
                                    <td style="padding-left:3px;">
                             Precio 1
                             </td>
                             <td>
                             <asp:TextBox ID="txtPrecio1Edicion" runat="server"  Width="75px"  Font-Names="Arial" Font-Bold="True"  ></asp:TextBox>
                             </td>

                              <td style="padding-left:3px;">
                             Precio 2
                             </td>
                             <td style="padding-left:17px;">
                             <asp:TextBox ID="txtPrecio2Edicion" runat="server"  Width="75px"  Font-Names="Arial" Font-Bold="True"  ></asp:TextBox>
                             </td>

                              <td style="padding-left:3px;">
                             Precio 3
                             </td>
                             <td style="padding-left:7px;">
                             <asp:TextBox ID="txtPrecio3Edicion" runat="server"  Width="75px"  Font-Names="Arial" Font-Bold="True"  ></asp:TextBox>
                             </td>
                             </tr>
                                </table>
                                </td>
                                </tr>
                                        
                                        <tr>
                                             <td>
                                                    Costo Mercado
                                             </td>

                                             <td colspan='5'style="padding-left:4px;">
                                     
                                                <asp:TextBox ID="txtCostoMercadoEdicion" runat="server"  Width="75px"  Font-Names="Arial" Font-Bold="True"></asp:TextBox>
                            
                                             </td>
                                        </tr>
                                    
                                        <tr>
                                     <td colspan='6' align="right">
                                     <asp:Button ID="btnEdicion" runat="server" Text="Grabar"  
                                class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                         Font-Names="Arial" Font-Bold="True"  Width="100px"   />
                                     </td>
                                     </tr>
                                                                          
                                        </table>
                                    </div>
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
                                            
                                             
                                             <td>
                                         <asp:CheckBox ID="chkNumero" runat="server" Text="Numero" Font-Bold="True"/>
                                        </td>

                                             <td>
                                          <asp:TextBox ID="txtNumeroConsulta" runat="server" Width="70" Font-Names="Arial"  ForeColor="Blue"  Font-Bold="True"   ></asp:TextBox>
                                     </td>

                                             <td>
                                               <asp:CheckBox ID="chkRango" runat="server" Text="Fecha" Font-Bold="True"/>
                                              </td>

                                             <td>
                                                <asp:TextBox ID="txtDesde" runat="server" Width="55" Font-Names="Arial"  ForeColor="Blue"  Font-Bold="True"    
                                                     CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                                             </td>

                                             <td>
                                                <asp:TextBox ID="txtHasta" runat="server" Width="55" Font-Names="Arial"  ForeColor="Blue"  Font-Bold="True"    
                                                     CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                                             </td>

                                             <td>
                                               <asp:CheckBox ID="chkCliente" runat="server" Text="Proveedor" Font-Bold="True"/>
                                              </td>

                                             <td>
                                                <asp:TextBox ID="txtClienteConsulta" runat="server" Width="535" Font-Names="Arial"  ForeColor="Blue"  Font-Bold="True"   ></asp:TextBox>
                                             </td>

                                       </tr>
                            </tbody>
                            </table >
                            </div>

                                  <div class="linea-button">
                              <asp:Button ID="btnBuscarConsulta" runat="server" Text="Buscar"  
                                            class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                                    Font-Names="Arial" Font-Bold="True"      Width="120" />
                            </div>

                            </div>
         <div id="div_consulta" style="padding-top:5px;">
                                                    <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" 
                                            border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                            Width="1005px" >

                                                                                        

                                                <Columns>
                                                        <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" id="imgEditarRegistro" ImageUrl="~/Asset/images/btnEdit.gif" 
                                                                    ToolTip="Editar Registro" OnClientClick="F_EditarRegistro(this); return false;" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                      <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" id="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png" ToolTip="Eliminar Documento" OnClientClick="F_AnularRegistro(this); return false;" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="ID" >
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblcodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                                                                </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Numero" >
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                             <asp:Label runat="server" ID="lblnumero" Text='<%# Bind("Numero") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Proveedor"  HeaderStyle-HorizontalAlign="Center" >
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                             <asp:Label runat="server" ID="lblcliente" Text='<%# Bind("RazonSocial") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="Emision" HeaderText="Emision" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                              
                                                    <asp:BoundField DataField="Condicion" HeaderText="Condicion" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                              
                                                    <asp:BoundField DataField="Vcto" HeaderText="Vcto" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Moneda" HeaderText="Moneda" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                           
                                                    <asp:BoundField DataField="Dscto" HeaderText="Dscto" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Igv" HeaderText="Igv" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                           
                                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>

                                                     <asp:BoundField DataField="TipoCambio" HeaderText="TC">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>

                                                
                                                    <asp:TemplateField HeaderText="Estado"  HeaderStyle-HorizontalAlign="Center" >
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                             <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                       <asp:BoundField DataField="Categoria" HeaderText="Categoria">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                    <asp:TemplateField HeaderText="Periodo"  HeaderStyle-HorizontalAlign="Center" >
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                             <asp:Label runat="server" ID="lblPeriodo" Text='<%# Bind("Periodo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>

                                                    </asp:GridView>
                                    
                                    </div>
                      </div>  
                      </div>

                      
                    <div id="div_Mantenimiento" style="display:none;">
                           
                                         <div class="ui-jqdialog-content">
                                        <table cellpadding="0" cellspacing="0" class="form-inputs" >
                                        
                                                 <tr>    
                                                        <td colspan="2">
                                                             <asp:Button ID="btnGrabarEdicion" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                                                Font-Names="Arial"  Font-Bold="True"    Width="120"   />

                                                        </td>
                                                                                                                  
                                                  </tr>
                                                 
                                                 <tr>
                                                 <td style="padding-top:10px;" colspan = '2'>
                                                 <table>
                                                 <tr>
                                                       <td style="font-weight: bold">
                                                   Periodo
                                                 </td>

                                                 <td>
                                                  <asp:TextBox ID="txtPeriodoConsulta" runat="server" Width="75px"  Font-Names="Arial"  ForeColor="Blue"  Font-Bold="True"   CssClass="MesAnioPicker" ReadOnly="true"></asp:TextBox>
                                                 </td>
                                                 </tr>
                                                 </table>
                                                 </td>
                                           
                                                
                                                 </tr>
                                                                       
                                        </table>
                                    </div>
                                </div>


                          <div id="dlgWait" style="background-color:#CCE6FF; text-align:center; display:none;">
        <br /><br />
        <center><asp:Label ID="Label2" runat="server" Text="PROCESANDO..." Font-Bold="true" Font-Size="Large" style="text-align:center"></asp:Label></center>
        <br />
        <center><img alt="Wait..." src="../Asset/images/ajax-loader2.gif"/></center>
    </div>       
     <input id="hfCodCtaCte" type="hidden"  value="0" />
     <input id="hfCodCtaCteConsulta" type="hidden"  value="0" />
     <input id="hfCodigoTemporal" type="hidden"  value="0" />
     <input id="hfCodProducto" type="hidden" value="0" />
     <input id="hfCodDocumentoVenta" type="hidden"  value="0" />
</asp:Content>