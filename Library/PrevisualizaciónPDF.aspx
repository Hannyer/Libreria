<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" Async="true"  AutoEventWireup="true" CodeBehind="PrevisualizaciónPDF.aspx.cs" Inherits="Library.WebForm1" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Style" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container" style="background-color: aliceblue; box-shadow: 5px 5px 5px 2px #e0e0d1, 8px 8px 8px 5px #e0e0d1;">
        <div class="row" >
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" style="display: contents;">
                <ContentTemplate>
                    <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12 pt-4 p-0" style=" padding-right: 1rem !important;">
                        <div class="input-group mb-3">
                            <asp:Label ID="Label17" Font-Bold="true" CssClass="col-lg-4 col-md-5 col-sm-5 col-xs-5 lead" runat="server" Text="Fecha inicial:"></asp:Label>
                            <asp:TextBox PlaceHolder="Fecha inicial" EnableViewState="false"  onkeydown="return false" CssClass=" col-lg-8 col-md-7 col-sm-7 col-xs-7 pl-lg-0 form-control control-w100 marginTextBox" name="txtFechaInicial" ID="txtFechaInicial" autocomplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaInicial" Format="dd/MM/yyyy" />
                        </div>
                    </div>

                    <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12 pt-4 p-0">
                        <div class="input-group mb-3">
                            <asp:Label ID="Label1" Font-Bold="true" CssClass="col-lg-4 col-md-5 col-sm-5 col-xs-5 lead" runat="server" Text="Fecha Final:"></asp:Label>
                            <asp:TextBox PlaceHolder="Fecha inicial" onkeydown="return false"  EnableViewState="false"  AutoPostBack="false" CssClass=" col-lg-8 col-md-7 col-sm-7 col-xs-7 pl-lg-0 form-control control-w100 marginTextBox" name="txtFechaFinal" ID="txtFechaFinal" autocomplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaFinal" Format="dd/MM/yyyy" />
                        </div>
                    </div>


                </ContentTemplate>
            </asp:UpdatePanel>
        </div>


           <div class=" row offset-4 pt-4">
                  <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-center pb-4">
                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                           <asp:LinkButton ID="btnConsultar" Font-Size="Medium" runat="server" CssClass="btn btn-primary btn-lg"
                              OnClick="btnConsultar_Click"><i class="bi bi-search"></i> Consultar</asp:LinkButton>
                           <asp:LinkButton ID="btnLimpiar" Font-Size="Medium" runat="server" CssClass="btn btn-danger btn-lg"
                              OnClick="btnLimpiar_Click"><i class="bi bi-eraser-fill"></i> Limpiar</asp:LinkButton>
                        </ContentTemplate>
                     </asp:UpdatePanel>
                  </div>
               </div>
               <br />
               <br />
           <div style="background-color: transparent">
                  <div class="row">
                     <!--Agregar lista de Datos-->
                     <div class="col-lg-12 ">
                        <div class="col-sm-12">
                           <div class="table-responsive">
                              <!--Tabla de articulos-->
                              <asp:UpdatePanel ID="upNum4" runat="server">
                                 <ContentTemplate>
                                    <asp:GridView ID="dgvAsignacion"
                                       runat="server"
                                       AutoGenerateColumns="false"
                                       OnPreRender="dgvAsignacion_PreRender"
                                       CssClass="table table-striped table-bordered table-hover dt-responsive"
                                       CellSpacing="0"
                                       OnRowDataBound="dgvAsignacion_RowDataBound"
                                       DataKeyNames="
                                                    Clave,
                                                    Consecutivo,
                                                    ID_Emisor,
                                                    Nombre_emisor,
                                                    Fecha_Registrado,
                                                    Departamento_Descripcion,
                                                    Categoria_Descripcion,
                                                    Requiere_Embarque_Descripcion,
                                                    Prioridad"
                                       Width="100%">
                                       <Columns>
                                          <asp:BoundField DataField="Consecutivo" HeaderText="Consecutivo" ControlStyle-Width="30px"></asp:BoundField>
                                          <asp:BoundField DataField="ID_Emisor" HeaderText="ID Emisor" ControlStyle-Width="30px"></asp:BoundField>
                                          <asp:BoundField DataField="Nombre_emisor" HeaderText="Emisor" ControlStyle-Width="2%"></asp:BoundField>
                                          <asp:BoundField DataField="Fecha_Registrado" HeaderText="Fecha" DataFormatString="{0:d}" ControlStyle-Width="2%"></asp:BoundField>
                                          <asp:BoundField DataField="Departamento_Descripcion" HeaderText="Asignado" ControlStyle-Width="2%"></asp:BoundField>
                                          <asp:BoundField DataField="Categoria_Descripcion" HeaderText="Categoria" ControlStyle-Width="2%"></asp:BoundField>
                                          <asp:BoundField DataField="Requiere_Embarque_Descripcion" HeaderText="Embarque" ControlStyle-Width="2%"></asp:BoundField>
                                          <asp:TemplateField HeaderText="Ver PDF" ItemStyle-Width="100">
                                             <ItemTemplate>
                                                <asp:UpdatePanel runat="server">
                                                   <ContentTemplate>
                                                      <asp:LinkButton ID="btnAprobar" OnClick="btnAprobar_Click" class="btn btn-success" runat="server"> 
                                    <span class="fa-solid fa-file-pdf iconsize"> </span>
                                                      </asp:LinkButton>
                                                   </ContentTemplate>
                                                </asp:UpdatePanel>
                                             </ItemTemplate>
                                          </asp:TemplateField>
                                       
                                       </Columns>
                                       <HeaderStyle BackColor="#212529 " Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                       <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" />
                                    </asp:GridView>

                                    <div class="text-center pb-4 ">
                                       <asp:Label ID="lblMensaje" Font-Bold="true" runat="server" Visible="false" CssClass="lead"></asp:Label>
                                    </div>
                                 </ContentTemplate>
                              </asp:UpdatePanel>
                           </div>
                        </div>
                     </div>
                  </div>
               </div>


    </div>


      <%--   modal del pdf--%>
   <div class="modal " id="modalPDF" role="dialog" data-backdrop="static" data-keyboard="false">
      <div class="modal-dialog dialogPDF modal-lg">
         <!-- Modal content-->
         <div class="modal-content contentPDF" style="min-height: 663px; min-width: 306px;">
            <div class="modal-header modalFirmaEstilo" style="background-color: blue;">
               <h5 style="align-self: center; color: white !important;" class="modal-title LetraTamanno" id="exito12">Previsualización PDF</h5>
               <%--  <button type="button" class="btn-close" onclick="MaximizarModalPDf();" aria-label="Maximizar"></button>--%>
               <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body modalbodypdf" style="height: 100%;">
               <div class="login" style="height: 100%">
                  <div class="row" style="height: 100%">
                     <div class="col-md-12" style="min-height: 500px">
                        <asp:UpdatePanel ID="UpdatePanel5" style="height: 100%;" runat="server">
                           <ContentTemplate>
                              <div id="divPDF" style="height: 100%" runat="server"></div>
                           </ContentTemplate>
                        </asp:UpdatePanel>
                     </div>
                  </div>
               </div>
            </div>
            <div class="modal-footer">
               <button type="button" class="btn btn-danger btn-lg" data-bs-dismiss="modal" aria-label="Close">Cerrar</button>
            </div>
         </div>
      </div>
   </div>

</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="scriptsPersonalizados" runat="server">
    <script src="Content/js/jquery-ui.min.js"></script>
    <link href="Content/js/jquery-ui.css" rel="stylesheet" />
    <script src="Content/JS/Combo/Multiple/chosenSelect.js"></script>
    <link href="Content/Css/Combo/chosenSelect.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>


    
   <link href="Content/DataTable/Buttons-2.2.3/css/buttons.bootstrap5.min.css" rel="stylesheet" />
   <link href="Content/DataTable/Buttons-2.2.3/css/buttons.dataTables.min.css" rel="stylesheet" />
   <link href="Content/DataTable/Buttons-2.2.3/css/buttons.foundation.min.css" rel="stylesheet" />
   <link href="Content/DataTable/DataTables-1.12.1/css/dataTables.bootstrap5.min.css" rel="stylesheet" />
   <link href="Content/DataTable/Responsive-2.3.0/css/responsive.bootstrap5.min.css" rel="stylesheet" />

       <script src="Content/js/Combo/Multiple/fSelect.js"></script>
   <link href="Content/css/Combo/fSelect.css" rel="stylesheet" />
   <link href="Content/css/Combo/chosenSelect.css" rel="stylesheet" />
   <script src="Content/js/Combo/Multiple/chosenSelect.js"></script>

       <script src="Content/DataTable/DataTables-1.12.1/js/jquery.dataTables.js"></script>
   <script src="Content/DataTable/DataTables-1.12.1/js/dataTables.bootstrap5.min.js"></script>
   <script src="Content/DataTable/Responsive-2.3.0/js/dataTables.responsive.min.js"></script>
   <script src="Content/DataTable/Responsive-2.3.0/js/responsive.bootstrap5.min.js"></script>
   <script src="Content/DataTable/Buttons-2.2.3/js/dataTables.buttons.min.js"></script>
   <script src="Content/DataTable/JSZip-2.5.0/jszip.min.js"></script>

   <script src="Content/DataTable/pdfmake-0.1.36/pdfmake.min.js"></script>
   <script src="Content/DataTable/pdfmake-0.1.36/vfs_fonts.js"></script>
   <script src="Content/DataTable/Buttons-2.2.3/js/buttons.html5.min.js"></script>
   <script src="Content/DataTable/Buttons-2.2.3/js/buttons.print.min.js"></script>
   <script src="Content/DataTable/Buttons-2.2.3/js/buttons.colVis.min.js"></script>
  

    
   <link href="Content/virtual-select-master/dist/virtual-select.min.css" rel="stylesheet" />
   <script src="Content/virtual-select-master/dist/virtual-select.min.js"></script>


    
   <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
   <script src="Content/bootstrap-5.0.2-dist/js/bootstrap.bundle.min.js"></script>

    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function (event) {
            CargarTablaPerfil();
            chosenSelect();
        });

        //On UpdatePanel Refresh
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_beginRequest(function (sender, e) {
                $(".loading-panel").attr("style", "display:block");
                chosenSelect();
            });
            prm.add_endRequest(function (sender, e) {

                $(".loading-panel").attr("style", "display:none");
                CargarTablaPerfil();
                chosenSelect();
            });
        }
        let CargarTablaPerfil = () => {
       InitializeDataTableWithParameter('<%= dgvAsignacion.ClientID %>');
        }
        function chosenSelect() {
            $(".chosen-select").chosen();
            $('.chosen-select-deselect').chosen({ allow_single_deselect: true });
        }


        $('.contentPDF').resizable({
            //alsoResize: ".modal-dialog",
            /* minHeight: 150*/
        });
        // $('.dialogPDF').draggable();
        $(".dialogPDF").draggable({
            alsoResize: ".modal-dialog",

            handle: ".modal-header"
        });

        $('#modalPDF').on('show.bs.modal', function () {
            $(this).find('.modalbodypdf').css({
                'max-height': '90%'
            });
            $(this).find('.divPDF').css({
                'max-height': '100%'
            });
        });
        var EstadoModalMaximizado = false;
        const WidthInicial = 798;
        const HeigthInicial = 628;
        $('.modal-header').dblclick(() => {
            var heightWindows = $(window).height();
            var widthWindows = $(window).width();
            var width = $('.contentPDF').width();
            var height = $('.contentPDF').height();
            if (!EstadoModalMaximizado) {
                $('.contentPDF').css("height", heightWindows);
                $('.contentPDF').css("width", widthWindows - 10);
                EstadoModalMaximizado = true;
            }
            else {
                $('.contentPDF').width(WidthInicial);
                $('.contentPDF').height(HeigthInicial);
                EstadoModalMaximizado = false;
            }
        });
    </script>
</asp:Content>
