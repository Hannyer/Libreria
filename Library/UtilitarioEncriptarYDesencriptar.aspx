<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UtilitarioEncriptarYDesencriptar.aspx.cs" Inherits="Library.UtilitarioEncriptarYDesencriptar" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Style" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
              <div class="container" style="background-color: aliceblue; box-shadow: 5px 5px 5px 2px #e0e0d1, 8px 8px 8px 5px #e0e0d1; min-height: 32rem !important;">
      
            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="input-group mb-3">
                        <h1>Encriptar y Desencriptar</h1>
                        <asp:LinkButton Style="margin-left: 5%; height: 38px;margin-top: 8px;"
                            ID="btnLimpiar" OnClick="btnLimpiar_Click" class="btn btn-secondary"
                            runat="server"> Limpiar  
                        </asp:LinkButton>
                    </div>

                </div>
                <div class="col-lg-4 col-md-12 col-sm-12">

                    <div class="col-lg-12 col-md-12 col-sm-12 pt-3">
                        <label class="control-label">Valor Digitado</label>
                        <asp:TextBox Rows="4" ID="txtValorDigitado"  TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>

                </div>
                <div class="col-lg-4 col-md-12 col-sm-12 pt-3" style="align-self: center; text-align: center;">

                    <div class="col-lg-12 col-md-12 col-sm-12 pt-3">

                        <asp:LinkButton Style="width: 200px;"
                            ID="btnEncriptar" OnClick="btnEncriptar_Click" class="btn btn-primary"
                            runat="server"> Encriptar  
                        </asp:LinkButton>

                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 pt-3">


                        <asp:LinkButton Style="width: 200px;"
                            ID="btnDesencriptar" OnClick="btnDesencriptar_Click" class="btn btn-primary"
                            runat="server">
                Desencriptar
                        </asp:LinkButton>

                    </div>

                </div>
                <div class="col-lg-4 col-md-12 col-sm-12">

                    <div class="col-lg-12 col-md-12 col-sm-12 pt-3">
                        <label class="control-label">Valor Obtenido</label>
                        <asp:TextBox ID="txtValorObtenido"  TextMode="MultiLine" Rows="4" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>

                </div>
            </div>
                  </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="scriptsPersonalizados" runat="server">

     <script type="text/javascript">
        jQuery(document).ready(function () {


        });

        //On UpdatePanel Refresh
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        if (prm != null) {
            prm.add_beginRequest(function (sender, e) {
                $(".loading-panel").attr("style", "display:block");
            });

            prm.add_endRequest(function (sender, e) {
                $(".loading-panel").attr("style", "display:none");

            });
         }

      <%--   $("#<%=txtValorDigitado.ClientID%>").change(function () {
             $("#<%=txtValorObtenido.ClientID%>").val("");
         });--%>

<%--         var TxtDigitado = document.getElementById("<%txtValorDigitado.ClientID%>");

         TxtDigitado.addEventListener("change", (event) => {
             console.log("Hola");
         });--%>

     </script>
</asp:Content>
