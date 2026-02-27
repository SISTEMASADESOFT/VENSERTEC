<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroCobranzas.aspx.cs" Inherits="SistemaInventario.Ventas.RegistroCobranzas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>  <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript"  src="RegistroCobranzas.js" charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />  <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />   <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />

 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="titulo">CUENTAS POR COBRAR</div> 

                     <div id="divTabs">

                        <ul>
                            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
                            <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
                        </ul>

                        <div id="tabRegistro">
                               <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" >
                                   <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                                    REGISTRO DE COBRANZAS
                                   </div>
                           
                                   <div >  
                             <table  cellpadding="0" cellspacing="0" class="form-inputs" width="750">
                                     <tr>

                                     <td >
                                            Razon Social
                                     </td>

                                     <td>
                                        <asp:TextBox ID="txtProveedor" runat="server" Width="307px" Font-Names="Arial" ></asp:TextBox>
                                                                                
                                     </td>

                                     <td>
                                     tc
                                     </td>

                                     <td>
                                   
                                     <asp:TextBox ID="txtTC" runat="server" Width="31px" Font-Names="Arial" ></asp:TextBox>
                                     </td>

                                     <td >
                               Emision
                                </td>
                                
                                     <td>
                                  <asp:TextBox ID="txtEmision" runat="server" Width="55px" CssClass="Jq-ui-dtp"  Font-Names="Arial" ></asp:TextBox>
                                  </td>

                                    <td>
                                Moneda
                                </td>
                                                                    
                                     <td>
                                <div id="div_moneda">
                                         <asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" >
                                         </asp:DropDownList>
                                     </div>
                                </td>

                                     <td style="padding-left:0px;">
                                    Medio Pago
                                </td>
                                                                       
                                     <td style="padding-left:0px;">
                                     <div id="div_MedioPago">
                                         <asp:DropDownList ID="ddlMedioPago" runat="server" Font-Names="Arial" 
                                              >
                                         </asp:DropDownList>
                                     </div>
                                 </td>


 
                                     
                                </tr>
                                
                                     <tr>
                                <td colspan="10">
                                <table  cellpadding="0" cellspacing="0" >
                                <tr>
                                

                                 <td>
                                   Banco
                                 </td>
                                                                    
                                 <td style="padding-left:47px;">
                                     <div id="div_Banco">
                                         <asp:DropDownList ID="ddlBanco" runat="server" Font-Names="Arial" >
                                         </asp:DropDownList>
                                     </div>
                                 </td>

                                 <td style="padding-left:2px;">
                                   Nro Cta
                                 </td>
                                                                    
                                 <td>
                                     <div id="div_Cuenta">
                                         <asp:DropDownList ID="ddlCuenta" runat="server" Font-Names="Arial" 
                                             Width="116px" >
                                         </asp:DropDownList>
                                     </div>
                                 </td>

                                 <td style="padding-left:45px;">
                             Nro Operacion
                             </td>

                                 <td >
                             <asp:TextBox ID="txtNroOperacion" runat="server"  Width="196px" Font-Names="Arial"></asp:TextBox>
                             </td>

                                 <td>
                             total Fac.
                             </td>

                                 <td style="padding-left:21px;">
                             <asp:TextBox ID="txtTotalFactura" runat="server"  Width="90px" Font-Names="Arial"  ReadOnly="True" Text="0.00"></asp:TextBox>
                             </td>
                          


                             </tr>
                                </table>
                                </td>
                                </tr>

                                <tr>
                                <td colspan="10">
                                <table  cellpadding="0" cellspacing="0" >
                                <tr>
                               
                                      <td style="padding-left:1px;">
                             Responsable
                             </td>

                                      <td style="padding-left:7px;">
                             <asp:TextBox ID="txtResponsable" runat="server"  Width="306px" Font-Names="Arial"></asp:TextBox>
                             </td>


                                      <td style="padding-left:2px;">
                             Pagador
                             </td>

                             <td>
                             <asp:TextBox ID="txtPagador" runat="server"  Width="274px" Font-Names="Arial"></asp:TextBox>
                             </td>

                                         <td style="padding-left:3px;">
                             Amortizacion
                             </td>

                             <td>
                             <asp:TextBox ID="txtTotalLetra" runat="server"  Width="90px" Font-Names="Arial"  Text="0.00"></asp:TextBox>
                             </td>
                             </tr>
                                </table>
                                </td>
                                </tr>
                                
                             
                               </table>
                             
                            </div>     
                            
                                   <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                            Detalle del documento
                            </div>    

                                   <div>
                            <table  cellpadding="0" cellspacing="0"  width="850" class="form-inputs">
                                
                                <tr>
                                                                        
                                    <td>
                                    <div id="div_grvFactura">
                                                    <asp:GridView ID="grvFactura" runat="server" AutoGenerateColumns="False" 
                                            border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                            Width="610px" Height="285" >
                                                    <Columns>

                                                              <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>                                                            
                                                            <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete"  Text="" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                              <asp:TemplateField HeaderText="Detalle" >
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblDetalle" Text='<%# Bind("Detalle") %>'></asp:Label>
                                                                </ItemTemplate>
                                                    </asp:TemplateField>

                                                              <asp:TemplateField HeaderText="Codigo" >
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblcodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                                                                </ItemTemplate>
                                                    </asp:TemplateField>

                                                              <asp:TemplateField HeaderText="Factura" >
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblFactura" Text='<%# Bind("Factura") %>'></asp:Label>
                                                                </ItemTemplate>
                                                    </asp:TemplateField>
                                                                                                   
                                                              <asp:BoundField DataField="Emision" HeaderText="Emision" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                 
                                                              <asp:BoundField DataField="Total" HeaderText="Total">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                              <asp:BoundField DataField="Moneda" HeaderText="Moneda" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                               
                                                    </Columns>

                                                    </asp:GridView>
                                    
                                    </div>
                                                </td>

                                    <td valign="top">
                                      <table  cellpadding="0" cellspacing="0" >
<tr>
                             
                            

                             <td>
                                <asp:Button ID="btnAgregarFactura" runat="server" Text="Agregar Factura"  
                                class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                        Font-Names="Arial"    />
                             </td>

                             <td>
                                
                                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo"  
                                class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                        Font-Names="Arial" Width="100px"    />
                            
                             </td>

                                             
                       
                             </tr>
                                <tr>

                             <td>
                                 <asp:Button ID="btnEliminarFactura" runat="server" Text="Eliminar Factura"  
                                class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                        Font-Names="Arial"   />
                             </td>

                             <td>
                                                
                           
                                <asp:Button ID="btnGrabar" runat="server" Text="Grabar"  
                                class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                        Font-Names="Arial"  Width="100px"   />
                            
                             </td>
                            </tr>
                             
                                </table>
                                    </td>
                                </tr>
                                                          
                                </table>
                            </div>

                        </div>

                                   <div id="divConsultaFactura" style="display:none;">
                           
                                         <div class="ui-jqdialog-content">
                                        <table width="360">
                                        
                                                   <tr>    
                                                    <td>
                                                         <asp:Button ID="btnAgregar" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                                            Font-Names="Arial"  />
                                                                </td>
                                                                                                                  
                                                        </tr>
                                                 
                                                   <tr>
                                                <td>
                                                   <div id="div_grvConsultaFactura">
                                                            <asp:GridView ID="grvConsultaFactura" runat="server" AutoGenerateColumns="False" 
                                            border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                             Width="360" Height="350" >  
                                       
                                                <Columns>
                                                 <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>                                                            
                                                            <asp:CheckBox runat="server" ID="chkOK" CssClass="chkSi" Text="" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Codigo" >
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                                                                </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="Factura" >
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblFactura" Text='<%# Bind("Factura") %>'></asp:Label>
                                                                </ItemTemplate>
                                                    </asp:TemplateField>

                                                           <asp:TemplateField HeaderText="Emision" >
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblEmision" Text='<%# Bind("Emision") %>'></asp:Label>
                                                                </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="Total" >
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblTotal" Text='<%# Bind("Total") %>'></asp:Label>
                                                                </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="Moneda" >
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblMoneda" Text='<%# Bind("Moneda") %>'></asp:Label>
                                                                </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
             
                                            </asp:GridView>
                                                   </div>
                                               
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
                                        <table cellpadding="0" cellspacing="0" class="form-inputs" width="700">
                                        <tr>
                                             <td>
                                         <asp:CheckBox ID="chkSerie" runat="server" Text="Serie" Checked="True" />
                                        </td>

                                             <td>
                                         <div id="div_serieconsulta">
                                         <asp:DropDownList ID="ddlSerieConsulta" runat="server" Font-Names="Arial" >
                                         </asp:DropDownList>
                                     </div>
                                </td>
                                             
                                             <td>
                                         <asp:CheckBox ID="chkNumero" runat="server" Text="Numero" />
                                        </td>

                                             <td>
                                          <asp:TextBox ID="txtNumeroConsulta" runat="server" Width="45" Font-Names="Arial" ></asp:TextBox>
                                     </td>

                                             <td>
                                               <asp:CheckBox ID="chkRango" runat="server" Text="Fecha" />
                                              </td>

                                             <td>
                                                <asp:TextBox ID="txtDesde" runat="server" Width="55" Font-Names="Arial"  CssClass="Jq-ui-dtp"></asp:TextBox>
                                             </td>

                                             <td>
                                                <asp:TextBox ID="txtHasta" runat="server" Width="55" Font-Names="Arial"  CssClass="Jq-ui-dtp"></asp:TextBox>
                                             </td>

                                             <td>
                                               <asp:CheckBox ID="chkCliente" runat="server" Text="Cliente" />
                                              </td>

                                             <td>
                                                <asp:TextBox ID="txtClienteConsulta" runat="server" Width="340" Font-Names="Arial" ></asp:TextBox>
                                             </td>

                                             <td>
                                            <asp:Button ID="btnBuscarConsulta" runat="server" Text="Buscar"  
                                            class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                                    Font-Names="Arial"    />
                             </td>
                                        </tr>

                                        <tr>
                                    <td colspan="10">
                                    <div id="div_consulta">
                                                    <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" 
                                            border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                            DataKeyNames="Codigo" Width="960px" Height="330" >
                                            
                                                <Columns>
                                                 
                                                    <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" id="imgAnularDocumento" ImageUrl="~/Asset/images/Eliminar.jpg" ToolTip="Anular Documento" OnClientClick="F_AnularRegistro(this); return false;" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Codigo" >
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblcodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                                                                    <asp:HiddenField ID="hfcodfactura" runat="server" Value='<%# Bind("CodFactura") %>' />
                                                                </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Factura" >
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                             <asp:Label runat="server" ID="lblnumero" Text='<%# Bind("Factura") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="NroRuc" HeaderText="Ruc" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                    <asp:TemplateField HeaderText="Cliente" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                             <asp:Label runat="server" ID="lblcliente" Text='<%# Bind("Cliente") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                                                                   
                                                    <asp:BoundField DataField="Emision" HeaderText="Fecha" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Moneda" HeaderText="Moneda" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="TC" HeaderText="TC">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Medio" HeaderText="Medio Pago">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Banco" HeaderText="Banco" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Cuenta" HeaderText="Cuenta" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="NroOperacion" HeaderText="Igv" >
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
                        </div>
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
     <input id="hfCodDocumentoVenta" type="hidden" value="0" />
     <input id="hfMoneda" type="hidden"  value="0" />

</asp:Content>