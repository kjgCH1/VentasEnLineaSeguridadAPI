using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Data
{
    public class UsuarioData
    {
        private string connectionString;

        public UsuarioData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool crearUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_crearUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros al comando
                        command.Parameters.AddWithValue("@cedula", usuario.Cedula);
                        command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@telefono", usuario.Telefono);
                        command.Parameters.AddWithValue("@rol", usuario.Rol);
                        command.Parameters.AddWithValue("@contrasena", usuario.Contrasena);
                        command.Parameters.AddWithValue("@habilitado", usuario.Habilitado);

                        // Ejecutar el procedimiento almacenado
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // El número 2627 es específico para violación de restricción única.
                {
                    // Aquí puedes manejar el error como desees, por ejemplo, mostrar un mensaje al usuario.
                    Console.WriteLine("Ya existe un registro con ese nombre.");
                    return false;
                }
                else
                {
                    // Otro manejo de errores si no es una violación de restricción única.
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }

        }//crearUsuario

        public bool modificarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_modificarUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", usuario.Id);
                        command.Parameters.AddWithValue("@cedula", usuario.Cedula);
                        command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@telefono", usuario.Telefono);
                        command.Parameters.AddWithValue("@rol", usuario.Rol);
                        command.Parameters.AddWithValue("@contrasena", usuario.Contrasena);
                        command.Parameters.AddWithValue("@habilitado", usuario.Habilitado);
                        int rowsAffected = command.ExecuteNonQuery();

                    }
                }
                return true;
            }
            catch (SqlException ex)
            {
                // Manejo de errores
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }//modificarUsuario

        public List<Usuario> buscarUsuario(string nombre)
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_buscarUsuario @nombre='{nombre}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.Id = (int)reader["id"];
                        usuario.Nombre = reader["nombre"].ToString();
                        usuario.Telefono = reader["telefono"].ToString();
                        usuario.Rol = (int)reader["rol"];
                        usuario.Contrasena = reader["contrasena"].ToString();
                        usuario.Habilitado = (bool)reader["habilitado"];

                        usuarios.Add(usuario);

                    }
                    connection.Close();

                }
                return usuarios;
            }
        }//buscarUsuarios

        public Usuario buscarUsuarioId(int id)
        {
            Usuario usuario = new Usuario();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_buscarUsuarioId @id={id}";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        usuario.Id = (int)reader["id"];
                        usuario.Cedula = reader["cedula"].ToString();
                        usuario.Nombre = reader["nombre"].ToString();
                        usuario.Telefono = reader["telefono"].ToString();
                        usuario.Rol = (int)reader["rol"];
                        usuario.Contrasena = reader["contrasena"].ToString();
                        usuario.Habilitado = (bool)reader["habilitado"];

                    }
                    connection.Close();

                }
                return usuario;
            }
        }//buscarUsuarioId

        public Usuario Login(string cedula, string contrasena)
        {
            Usuario usuario = new Usuario();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_login @cedula='{cedula}', @contrasena='{contrasena}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        usuario.Id = (int)reader["id"];
                        usuario.Cedula = reader["cedula"].ToString();
                        usuario.Nombre = reader["nombre"].ToString();
                        usuario.Telefono = reader["telefono"].ToString();
                        usuario.Rol = (int)reader["rol"];
                        usuario.Contrasena = reader["contrasena"].ToString();
                        usuario.Habilitado = (bool)reader["habilitado"];

                    }
                    connection.Close();

                }
                return usuario;
            }
        }//buscarUsuarioId

    }
}
