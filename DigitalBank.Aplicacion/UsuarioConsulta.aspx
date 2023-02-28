<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioConsulta.aspx.cs" Inherits="DigitalBank.Aplicacion.UsuarioConsulta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.3.min.js"></script>
    <title>Consultas de Usuarios</title>
</head>
<body>
    <div class="container w-50">
        <div>
            <form id="form_usuarioConsulta" runat="server">
                <asp:ScriptManager ID="ScripMg1" runat="server"></asp:ScriptManager>
                <div class="form-control">
                    <div class="text-center mb-3">
                        <asp:Label runat="server" Text="Consulta de Usuarios" CssClass="h1"></asp:Label>
                    </div>
                    <asp:UpdatePanel ID="UpGrid" runat="server" UpdateMode="Conditional" ClientIDMode="Static">
                        <ContentTemplate>
                            <div class="form-control">
                                <asp:GridView ID="GRVUsuario" Font-Size="14px" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4"
                                    ForeColor="Black" GridLines="Vertical" DataKeyNames="IdUsuario" OnRowCommand="GRVUsuario_RowCommand">
                                    <AlternatingRowStyle BackColor="#669999" ForeColor="#000000" />
                                    <EmptyDataTemplate>
                                        <asp:Literal runat="server" Text="No hay datos para Mostrar" />
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Codigo" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="LblIdUsuario" Text='<%# Eval("IdUsuario") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nombre" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="LblNombre" Text='<%# Eval("Nombre") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha Nacimiento" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="LblNacimiento" Text='<%#DateTime.Parse(Eval("FechaNacimiento").ToString()).ToString("d") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sexo" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="LblSexo" Text='<%#Eval("Sexo") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <div class="text-center">
                                                    <asp:LinkButton runat="server" ID="LnkEditar" CssClass="link-primary" ClientIDMode="Static" Text="Editar"
                                                        PostBackUrl='<%# "~/Usuarios.aspx?UsuarioId=" + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(Eval("IdUsuario").ToString()))%>'>
                                                    </asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="LnkEliminar" CssClass="link-primary" ClientIDMode="Static" Text="Eliminar"
                                                    CommandArgument='<%#Eval("IdUsuario") %>' CommandName="DeleteRow">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div>
                        <asp:LinkButton runat="server" ID="LnkBack" CssClass="link-success" ClientIDMode="Static" Text="Volver"
                             PostBackUrl="~/Usuarios.aspx">
                        </asp:LinkButton>
                    </div>
                </div>
            </form>
        </div>
    </div>

</body>
</html>
