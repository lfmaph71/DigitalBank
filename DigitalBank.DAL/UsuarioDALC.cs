using DigitalBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DigitalBank.DAL
{
    public class UsuarioDALC:Conectar
    {
        #region Listar_Usuarios

        public List<UsuarioDTO> Lista()
        {
            List<UsuarioDTO> resul = new List<UsuarioDTO>();
            try
            {
                using (SqlConnection Con = new SqlConnection(Conecto()))
                {
                    Con.Open();
                    SqlCommand Cmd = new SqlCommand(DBprocedures.ListarUsuario, Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandTimeout = 1800;
                    using (SqlDataReader reader = Cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UsuarioDTO _lista = new UsuarioDTO()
                            {
                                IdUsuario = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                FechaNacimiento = reader.GetDateTime(2),
                                Sexo = reader.GetString(3)
                            };
                            resul.Add(_lista);
                        
}
                    };

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
                return resul;
        }
        #endregion

        #region Update_Usuarios
        public int Update(UsuarioDTO usuarioDTO)
        {
            try
            {
                using (SqlConnection Con = new SqlConnection(Conecto()))
                {
                    Con.Open();
                    SqlCommand Cmd = new SqlCommand(DBprocedures.EditarUsuario, Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandTimeout = 1800;
                    Cmd.Parameters.AddWithValue("IdUsuario", usuarioDTO.IdUsuario);
                    Cmd.Parameters.AddWithValue("Nombre", usuarioDTO.Nombre);
                    Cmd.Parameters.AddWithValue("FechaNacimiento", usuarioDTO.FechaNacimiento);
                    Cmd.Parameters.AddWithValue("Sexo", usuarioDTO.Sexo);
                    return Cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Insert_Usuario
        public int Insert(UsuarioDTO usuarioDTO)
        {
            try
            {
                using (SqlConnection Con = new SqlConnection(Conecto()))
                {
                    Con.Open();
                    SqlCommand Cmd = new SqlCommand(DBprocedures.GuardarUsuario,Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandTimeout = 1800;
                    Cmd.Parameters.AddWithValue("Nombre", usuarioDTO.Nombre);
                    Cmd.Parameters.AddWithValue("FechaNacimiento", usuarioDTO.FechaNacimiento);
                    Cmd.Parameters.AddWithValue("Sexo", usuarioDTO.Sexo);
                    return Cmd.ExecuteNonQuery();
                }
  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete_Usuario

        public int Delete(int IdUsuario)
        {
            try
            {
                using (SqlConnection Con = new SqlConnection(Conecto()))
                {
                    Con.Open();
                    SqlCommand Cmd = new SqlCommand(DBprocedures.BorrarUsuario, Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandTimeout = 1800;
                    Cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
                    return Cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion


    }
}
