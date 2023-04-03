<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Library.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Style" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   

<!DOCTYPE html>

    <style>
        #pdf-modal {
            display: none;
            position: fixed;
            z-index: 1000;
            top: 0;
            left: 0;
            height: 100%;
            width: 100%;
            background-color: rgba(0, 0, 0, 0.5);
        }

        #pdf-container {
            position: absolute;
            left: 50%;
            top: 50%;
            transform: translate(-50%, -50%);
            width: 80%;
            height: 80%;
            background-color: white;
        }

        #pdf-viewer {
            height: 100%;
        }
    </style>


    <div id="pdf-modal">
        <div id="pdf-container">
            <div id="pdf-viewer"></div>
            <button id="close-btn">Close</button>
        </div>
    </div>

    <button id="preview-btn">Preview PDF</button>



    <script src="packages/PDFjs.1.10.100/content/Scripts/pdf.js/build/pdf.js"></script>
    <script>

        var rutaArchivo = new URL("C:\Users\hpitterson\Downloads\Bienvenidos.pdf");
      
        var pdfUrl = rutaArchivo.href;

        var pdfModal = document.getElementById("pdf-modal");
        var pdfViewer = document.getElementById("pdf-viewer");

        var previewBtn = document.getElementById("preview-btn");
        previewBtn.addEventListener("click", function () {
            PDFJS.getDocument(pdfUrl).then(function (pdf) {
                var pageNum = 1;
                pdf.getPage(pageNum).then(function (page) {
                    var viewport = page.getViewport(1.0);
                    var canvas = document.createElement("canvas");
                    var context = canvas.getContext("2d");
                    canvas.height = viewport.height;
                    canvas.width = viewport.width;
                    pdfViewer.appendChild(canvas);
                    page.render({ canvasContext: context, viewport: viewport });
                });
            });

            pdfModal.style.display = "block";
        });

        var closeBtn = document.getElementById("close-btn");
        closeBtn.addEventListener("click", function () {
            pdfViewer.innerHTML = "";
            pdfModal.style.display = "none";
        });
    </script>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptsPersonalizados" runat="server">
</asp:Content>
