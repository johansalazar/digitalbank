using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceDigitalBank.Models;
using WcfServiceDigitalBank.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Jose;
using System.ServiceModel.Web;

namespace WcfServiceDigitalBank
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UsuarioService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UsuarioService.svc or UsuarioService.svc.cs at the Solution Explorer and start debugging.
    public class UsuarioService : IUsuarioService
    {
        public void CrearUsuarios(Usuarios usuario)
        {

            // Establece la cadena de conexión a tu base de datos
            string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("CrearUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Define los parámetros necesarios para el procedimiento almacenado
                    command.Parameters.Add(new SqlParameter("@ID", SqlDbType.NVarChar, 100) { Value = usuario.ID });
                    command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar, 100) { Value = usuario.Nombre });
                    command.Parameters.Add(new SqlParameter("@FechaNacimiento", SqlDbType.Date) { Value = usuario.FechaNacimiento });
                    command.Parameters.Add(new SqlParameter("@Sexo", SqlDbType.Char, 1) { Value = usuario.Sexo });

                    // Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery();
                }
            }
        }

        public Usuarios LeerUsuarios(string usuarioID)
        {
            // Establece la cadena de conexión a tu base de datos
            string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

            Usuarios usuario = null;

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("LeerUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar el parámetro @UsuarioID a la consulta SQL
                    command.Parameters.Add(new SqlParameter("@ID", usuarioID));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuarios
                            {
                                ID = reader["ID"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                                Sexo = reader["Sexo"].ToString()
                            };
                        }
                    }
                }
            }

            return usuario;
        }

        public void ActualizarUsuarios(Usuarios usuario)
        {
            // Establece la cadena de conexión a tu base de datos
            string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ActualizarUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros necesarios para el procedimiento almacenado
                    command.Parameters.Add(new SqlParameter("@ID", usuario.ID));
                    command.Parameters.Add(new SqlParameter("@Nombre", usuario.Nombre));
                    command.Parameters.Add(new SqlParameter("@FechaNacimiento", usuario.FechaNacimiento));
                    command.Parameters.Add(new SqlParameter("@Sexo", usuario.Sexo));

                    // Ejecutar el procedimiento almacenado
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarUsuarios(string usuarioID)
        {
            // Establece la cadena de conexión a tu base de datos
            string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("EliminarUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar el parámetro necesario para el procedimiento almacenado
                    command.Parameters.Add(new SqlParameter("@ID", usuarioID));

                    // Ejecutar el procedimiento almacenado
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Usuarios> ListarUsuariosConPaginacion(int paginaActual, int tamanoPagina)
        {

            // Establece la cadena de conexión a tu base de datos
            string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

            List<Usuarios> listaUsuarios = new List<Usuarios>();

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ObtenerUsuariosPaginados", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros necesarios para el procedimiento almacenado
                    command.Parameters.Add(new SqlParameter("@Pagina", paginaActual));
                    command.Parameters.Add(new SqlParameter("@TamañoPagina", tamanoPagina));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Usuarios usuario = new Usuarios
                                {
                                    ID = reader["ID"].ToString(),
                                    Nombre = reader["Nombre"].ToString(),
                                    FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                                    Sexo = reader["Sexo"].ToString()
                                };
                                listaUsuarios.Add(usuario);
                            }
                        }
                    }
                }
            }

            return listaUsuarios;
        }
        public void RegistrarActividad(string accion, string tablaAfectada, string usuario, string detalles)
        {
            // Lógica para registrar actividad en la tabla "RegistroActividades" utilizando un procedimiento almacenado.
            // Establece la cadena de conexión a tu base de datos
            string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("RegistrarActividad", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros necesarios para el procedimiento almacenado
                    command.Parameters.Add(new SqlParameter("@Accion", accion));
                    command.Parameters.Add(new SqlParameter("@TablaAfectada", tablaAfectada));
                    command.Parameters.Add(new SqlParameter("@Usuario", usuario));
                    command.Parameters.Add(new SqlParameter("@Detalles", detalles));

                    // Ejecutar el procedimiento almacenado
                    command.ExecuteNonQuery();
                }
            }
        }

        public int ObtenerTotalRegistros()
        {
            // Establece la cadena de conexión a tu base de datos
            string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

            int totalRegistros = 0;

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand("ObtenerTotalRegistros", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    conexion.Open();

                    // Ejecutar el procedimiento almacenado
                    totalRegistros = (int)comando.ExecuteScalar();
                }
            }
            return totalRegistros;
        }
    }
}
