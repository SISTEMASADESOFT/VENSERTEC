<%@ Page Title="Inventario Stock Minimo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventario_Stock_Minimo.aspx.cs" Inherits="SistemaInventario.Reportes.Inventario_Stock_Minimo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>  <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript"  src="Inventario_Stock_Minimo.js" charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />  <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />   <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />

 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="titulo" style="width: 930px">Reporte de Inventario Stock Minimo</div> 
                        <div id="tabRegistro" style="width: 910px">
                          <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" >
                           <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix" >
                                    Inventario Stock Minimo
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
                                            Width="910px" >  
                                       
                                                <Columns>
                                                    <asp:BoundField DataField="Familia" HeaderText="Familia">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

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

                                                     <asp:BoundField DataField="StockActual" HeaderText="StockActual">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>

                                                    
                                                  <asp:BoundField DataField="StockMinimo" HeaderText="StockMinimo">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>

                                           
                                                    <asp:BoundField DataField="UltimaCompra" HeaderText="UltimaCompra">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Costo" HeaderText="Costo">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                           
                                                   
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                   
                                                         <asp:BoundField DataField="Moneda" HeaderText="Mon.">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                                <asp:BoundField DataField="Proveedor" HeaderText="Proveedor">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
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
