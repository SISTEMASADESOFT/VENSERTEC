<%@ Page Title="Guia Interna Barras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GuiaInterna.aspx.cs" Inherits="SistemaInventario.Inventario.GuiaInterna" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"type="text/javascript"></script> 
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript"  src="GuiaInterna.js" charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


         <div class="titulo"  >GUIA INTERNA</div> 
                
                      <div id="divTabs">

                        <ul>
                            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
                            <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
                        </ul>

                        <div id="tabRegistro">
                      
                         
                           
                               <div id='divConsulta' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all"  style="width: 600px">
                        
                                       <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                                                 Datos Guia
                                        </div>
                                        
                                        <div class="ui-jqdialog-content"  style="width: 600px;">
                                          <table cellpadding="0" cellspacing="0" class="form-inputs" width="600">
                                             <tr>

                                                <td style="font-weight: bold;" >
                                            Serie
                                            </td>
                                                                                 
                                                <td>
                                        
                                             <asp:TextBox ID="txtSerializacion" runat="server" Width="390px" ForeColor="Blue"  Font-Names="Arial" Font-Bold="True"></asp:TextBox>                                     
                                     </td>
                                                                       
                                    
                                              </tr>
                                
                                             <tr>
                                            <td style="font-weight: bold;">
                                   Mensaje
                                 </td>
                                                                      
                                            <td>
                              <asp:TextBox ID="txtMensaje" runat="server" Width="390px"   ForeColor="Blue"  Font-Names="Arial" Font-Bold="True"></asp:TextBox>
                                      
                                                                                
                                     </td>

                                           </tr>
                                        </table>
                                                
                                        </div>

                                        <div class="linea-button">
                                       

                                       <asp:Button ID="btnNuevo" runat="server" Text="Nuevo"  
                                            class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                                     Font-Names="Arial" Font-Bold="True"    Width="120" />

                             
                                        </div>
                 </div>

                      </div>   
                                 
                        

                        <div id="tabConsulta">
                           <div id='div1' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
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
                                         <asp:DropDownList ID="ddlSerieConsulta" runat="server" Font-Names="Arial"  ForeColor="Blue"  Font-Bold="True"   >
                                         </asp:DropDownList>
                                     </div>
                                </td>
                                             
                                             <td>
                                         <asp:CheckBox ID="chkNumero" runat="server" Text="Numero" Font-Bold="True"/>
                                        </td>

                                             <td>
                                          <asp:TextBox ID="txtNumeroConsulta" runat="server" Width="45" Font-Names="Arial"  ForeColor="Blue"  Font-Bold="True"   ></asp:TextBox>
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
                                               <asp:CheckBox ID="chkCliente" runat="server" Text="Cliente" Font-Bold="True"/>
                                              </td>

                                             <td>
                                                <asp:TextBox ID="txtClienteConsulta" runat="server" Width="485" Font-Names="Arial"  ForeColor="Blue"  Font-Bold="True"   ></asp:TextBox>
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
                                            DataKeyNames="Codigo" Width="1017px" OnRowDataBound="grvConsulta_RowDataBound">
                                            
                                                <Columns>
                                                 

                                                                      <asp:TemplateField >
                                                    <ItemTemplate>
                                                        <img id="imgMas" alt = "" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click(this);" title="Ver Detalle" />
                                                        <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                                                <asp:GridView runat="server" ID="grvDetalle"  border="0" CellPadding="0" CellSpacing="1"  GridLines="None" class="GridView" />
                                                        </asp:Panel>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                                      <asp:TemplateField HeaderText="ID" >
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblcodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                                                         
                                                                </ItemTemplate>
                                                    </asp:TemplateField>

                                                                      <asp:TemplateField HeaderText="Numero" >
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                             <asp:Label runat="server" ID="lblNumero" Text='<%# Bind("Numero") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                                      <asp:TemplateField HeaderText="Razon Social" >
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                             <asp:Label runat="server" ID="lblcliente" Text='<%# Bind("Cliente") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                                                                   
                                                                      <asp:BoundField DataField="Emision" HeaderText="Emision" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                                      <asp:BoundField DataField="Destino" HeaderText="Destino" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                           
                                                                      <asp:TemplateField HeaderText="Estado" >
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                             <asp:Label runat="server" ID="lblestado" Text='<%# Bind("Estado") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="Operacion" HeaderText="Operacion" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                
                                                </Columns>

                                                    </asp:GridView>
                                    
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
     <input id="hfCodProducto" type="hidden"  value="0" />
     <input id="hfCodSerializacionCab" type="hidden"  value="0" />
</asp:Content>