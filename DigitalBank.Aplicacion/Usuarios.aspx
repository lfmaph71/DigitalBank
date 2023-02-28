<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="DigitalBank.Aplicacion.Usuarios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ccAjax" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.3.min.js"></script>
    <title>Usuarios</title>

</head>
<body class="bg-light">
    <div class="container w-25">
        <div>
            <form id="form_usuario" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <div class="form-control">

                    <div class="col-m-6 text-center mb-5">
                        <asp:Label Class="h1" runat="server" Text="Usuarios"></asp:Label>
                    </div>
                    <div class="mb-3">
                        <asp:Label runat="server" Text="Nombre:"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="TxtNombre" placeholder="Nombre Usuario"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <asp:Label runat="server" Text="Fecha de Nacimiento:"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="Txtfecha" placeholder="Fecha de Nacimiento"></asp:TextBox>
                        <ccAjax:CalendarExtender ID="CalendarExtender1" runat="server"
                            TargetControlID="Txtfecha" PopupButtonID="Txtfecha"></ccAjax:CalendarExtender>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="Label1" runat="server" Text="Sexo de Nacimiento:"></asp:Label>
                        <asp:DropDownList ID="DDLSexo" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                            <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="mb-3 row">
                        <asp:Button CssClass="btn btn-primary btn-dark" ID="BtnInsertar" OnClick="BtnInsertar_Click" runat="server" Text="Guardar" />
                        <asp:Button CssClass="btn btn-secondary btn-light" ID="BtnConsultar" runat="server" Text="Consultar" PostBackUrl="~/UsuarioConsulta.aspx" />
                    </div>
                </div>
            </form>
        </div>
    </div>

</body>
</html>
