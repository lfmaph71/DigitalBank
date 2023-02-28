using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigitalBank.Aplicacion.ServiceDigitalBank;

namespace DigitalBank.Aplicacion
{
    public partial class Usuarios : System.Web.UI.Page
    {
        Service1Client Service = new Service1Client();
        private int _IdUsu
        { get
            {
                string strIdUsua = Request.QueryString["UsuarioId"];
                int IdUsua = 0;
                if (!string.IsNullOrEmpty(strIdUsua))
                {
                    IdUsua = int.Parse(System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(strIdUsua)));
                }
                return IdUsua;
            }
         }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_IdUsu > 0)
                {
                    List<UsuarioDTO> lista = new List<UsuarioDTO>();
                    lista = Service.ListUsuario().ToList();
                    UsuarioDTO dato = lista.Where(x => x.IdUsuario == _IdUsu).FirstOrDefault();
                    TxtNombre.Text = dato.Nombre;
                    Txtfecha.Text = dato.FechaNacimiento.ToString("d");
                    DDLSexo.Text = dato.Sexo;
                }
            }
        }

        protected void BtnInsertar_Click(object sender, EventArgs e)
        {
            if (_IdUsu > 0)
            {
                UsuarioDTO objeto = new UsuarioDTO()
                {
                    IdUsuario = _IdUsu,
                    Nombre = TxtNombre.Text,
                    FechaNacimiento = Convert.ToDateTime(Txtfecha.Text),
                    Sexo = DDLSexo.Text
                };
                Service.UpdateUsuario(objeto);
                Response.Redirect("UsuarioConsulta.aspx");
            }
            else
            {
                UsuarioDTO inserta = new UsuarioDTO()
                {
                    Nombre = TxtNombre.Text,
                    FechaNacimiento = Convert.ToDateTime(Txtfecha.Text),
                    Sexo = DDLSexo.Text
                };
                Service.InsertUsuario(inserta);
                Limpia();
            }
        }

        public void Limpia()
        {
            TxtNombre.Text = string.Empty;
            Txtfecha.Text = string.Empty;
            DDLSexo.SelectedIndex = 1;
        }
    }
}