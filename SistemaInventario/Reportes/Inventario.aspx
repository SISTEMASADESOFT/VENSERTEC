<%@ Page Title="Inventario Stock Actual" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="SistemaInventario.Reportes.Inventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>  <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript"  src="Inventario.js" charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />  <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />   <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />

 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="titulo" style="width: 1000px">Reporte de Inventario Stock Actual</div> 
                        <div id="tabRegistro" style="width: 1000px">
                          <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" >
                           <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix" >
                                    Inventario Stock Actual
                            </div>
                          
                                <div id="divConsultaArticulo">
                                     <div class="ui-jqdialog-content">
                                        <table >
                                        <tr>    
                                             <td style="font-weight: bold">
                                                               Familia
                                        </td>
                                                        
                                             <td>
                                      
                                          <div id="div_familiaconsulta">
                                                 <asp:DropDownList ID="ddlFamiliaConsulta" runat="server" Font-Names="Arial"  ForeColor="Blue" 
                                          Font-Bold="True"   Width="200" BackColor="#FFFF99"> 
                                                  </asp:DropDownList>
                                            </div>
                                        </td>
                                          </td>
                                            <td style="font-weight: bold">
                                    Codigo / Descripcion
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescripcionConsulta" runat="server" Width="275" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Ubicacion
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUbicacionConsulta" runat="server" Width="75" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="padding-left: 5px; font-weight: bold;">
                                    Estado
                                </td>
                                <td style="padding-left: 22px; font-weight: bold;">
                                    <div id="div_FiltroEstados">
                                        <asp:DropDownList ID="ddlFiltroCodEstado" runat="server" Font-Names="Arial" ForeColor="Blue"
                                            Font-Bold="True" Width="98">
                                            <%--<asp:ListItem Value="0">Todos</asp:ListItem>--%>
                                            <asp:ListItem Value="1" Selected>Habilitado</asp:ListItem>
                                            <asp:ListItem Value="2">Inhabilitado</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>                                                        
                                         </tr>
                                                 
                                        </table>
                                    </div>

                                     <div  class="linea-button">
                                   <asp:Button ID="btnBuscar" runat="server" Text="BUSCAR" Font-Names="Arial"
                                                                class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" Width="120px" 
                                                                 />
                                                                <asp:Button ID="btnExcel" runat="server" Text="Excel" Font-Names="Arial"
                                                                class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" Width="120px" 
                                                                 />
                                                                <asp:Button ID="btnPdf" runat="server" Text="PDF" Font-Names="Arial"
                                                                            style="display:none;"
                                                                class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" Width="120px" 
                                                                 />
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
                            <div id="div_grvConsultaArticulo" style="padding-top:5px;">
                                                            <asp:GridView ID="grvConsultaArticulo" runat="server" AutoGenerateColumns="False" 
                                            border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                            Width="1000px" >  
                                       
                                                <Columns>

                                                   <asp:TemplateField HeaderText="Codigo" HeaderStyle-HorizontalAlign="Center">
                                                   <ItemStyle HorizontalAlign="Left" />
                                                   <ItemTemplate>
                                                       <asp:Label runat="server" ID="lblCodigoProducto" Text='<%# Bind("Codigo") %>' CssClass="detallesart"></asp:Label>
                                                   </ItemTemplate>
                                                    </asp:TemplateField>                          
                                                
                                                    <asp:BoundField DataField="Producto" HeaderText="Producto" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                   
                                           
                                                  <asp:BoundField DataField="MARCA" HeaderText="MARCA">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                     <asp:BoundField DataField="Stock" HeaderText="Stock">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>

                                                       <asp:BoundField DataField="UM" HeaderText="UM">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Costo" HeaderText="Costo">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                           
                                                    <asp:BoundField DataField="Margen" HeaderText="Margen">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Precio" HeaderText="Precio">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                           
                                                   
                                                    <asp:BoundField DataField="DSCTO" HeaderText="Dscto">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                   
                                                             

                                                    <asp:BoundField DataField="Moneda" HeaderText="Mon.">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                    
                                                    <asp:BoundField DataField="Familia" HeaderText="Familia">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                                                                      
                                                  </Columns>
             
                                            </asp:GridView>
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
</asp:Content>
