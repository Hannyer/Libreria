<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrusel.aspx.cs" Inherits="Library.Carrusel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Style" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <style>
        #carousel-container {
            position: relative;
            width: 100%;
            height: 400px;
            overflow: hidden;
        }

        .carousel-item {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            opacity: 0;
          
            transition: opacity 0.5s ease-in-out;
        }

            .carousel-item.active {
                opacity: 1;
            }

        .img {
            width: 100%;
              max-height:40rem;
            height: auto;
            margin: 10px;
            border: 1px solid #ccc;
            padding: 5px;
        }
        .imagen {
  width: 100%;
  height: 100%;
  overflow: hidden;
}

.imagen img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}
    </style>

    <h1>Carrusel</h1>

    <div id="carousel-container imagen">
        <div class="carousel-item active">

            <img src="Content/img/Carrusel1.jpg" class="img" />
        </div>
        <div class="carousel-item">
            <img src="Content/img/Carrusel2.jpg" class="img" />
        </div>
        <div class="carousel-item">
            <img src="Content/img/Carrusel3.jpg" class="img" />
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptsPersonalizados" runat="server">

    <script type="text/javascript">
        var slideIndex = 0;
        var slides = document.getElementsByClassName("carousel-item");

        function showSlide() {
            for (var i = 0; i < slides.length; i++) {
                slides[i].classList.remove("active");
            }
            slideIndex++;
            if (slideIndex > slides.length) {
                slideIndex = 1;
            }
            slides[slideIndex - 1].classList.add("active");
            setTimeout(showSlide, 3000);
        }

        showSlide();

    </script>
</asp:Content>
