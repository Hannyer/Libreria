﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Library.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title></title>

    <script src="Content/sweetalert.min.js"></script>
</head>
<body style="background-color: darkgrey;">
    <form runat="server">
        <div class="container">
            <!-- Section: Design Block -->
            <section class=" text-center text-lg-start" style="margin-top: 5rem;">
                <style>
                    .rounded-t-5 {
                        border-top-left-radius: 0.5rem;
                        border-top-right-radius: 0.5rem;
                    }

                    @media (min-width: 992px) {
                        .rounded-tr-lg-0 {
                            border-top-right-radius: 0;
                        }

                        .rounded-bl-lg-5 {
                            border-bottom-left-radius: 0.5rem;
                        }
                    }
                </style>
                <div class="card mb-3">
                    <div class="row g-0 d-flex align-items-center">
                        <div class="col-lg-4 d-none d-lg-flex">
                            <img src="https://mdbootstrap.com/img/new/ecommerce/vertical/004.jpg" alt="Trendy Pants and Shoes"
                                class="w-100 rounded-t-5 rounded-tr-lg-0 rounded-bl-lg-5" />
                        </div>
                        <div class="col-lg-8">
                            <div class="card-body py-5 px-md-5">

                                <form>
                                    <!-- Email input -->
                                    <div class="form-outline mb-4">
                                        <asp:TextBox runat="server" ID="txtCedula" class="form-control" />
                                        <label class="form-label" for="txtCedula">Cédula</label>
                                    </div>

                                    <!-- Password input -->
                                    <div class="form-outline mb-4">
                                        <asp:TextBox runat="server" type="password" ID="txtContrasenna" class="form-control" />
                                        <label class="form-label" for="txtContrasenna">Contraseña</label>
                                    </div>

                                    <!-- 2 column grid layout for inline styling -->
                                    <div class="row mb-4">
                                        <div class="col d-flex justify-content-center">
                                            <!-- Checkbox -->
                                            <div class="form-check">
                                                <input class="form-check-input" type="checkbox" value="" id="form2Example31" checked />
                                                <label class="form-check-label" for="form2Example31">Recordar usuario </label>
                                            </div>
                                        </div>

                                        <div class="col">
                                            <!-- Simple link -->
                                            <a href="#!">¿Olvidó su contraseña?</a>
                                        </div>
                                    </div>

                                    <!-- Submit button -->
                                    <asp:LinkButton runat="server" ID="btnIngresar" OnClick="btnIngresar_Click" type="button" class="btn btn-primary btn-block mb-4">Ingresar</asp:LinkButton>

                                </form>

                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- Section: Design Block -->
        </div>

    </form>

    <script type="text/javascript">
        document.addEventListener("keyup", function (event) {
            if (event.key === 'Enter') {
                document.getElementById("<%=btnIngresar.ClientID %>").click();
            }
        });
    </script>
</body>
</html>
