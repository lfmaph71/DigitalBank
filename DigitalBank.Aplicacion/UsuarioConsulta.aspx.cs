using DigitalBank.Aplicacion.ServiceDigitalBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DigitalBank.Aplicacion
{
    public partial class UsuarioConsulta : System.Web.UI.Page
    {
        Service1Client Service = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }

        }

        public void CargarDatos()
        {
            List<UsuarioDTO> listaUsuario = new List<UsuarioDTO>();
            listaUsuario = Service.ListUsuario().ToList();
            GRVUsuario.DataSource = listaUsuario;
            GRVUsuario.DataBind();
        }

        protected void GRVUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id_usuario = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName.Equals("DeleteRow"))
            {
                Service.DeleteUsuario(id_usuario);
                CargarDatos();
                this.UpGrid.Update();
            }

        }
    }
}