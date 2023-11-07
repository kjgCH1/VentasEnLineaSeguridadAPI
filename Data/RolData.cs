
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Data
{
    public class RolData
    {
        private string connectionString;

        public RolData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool crearRol(Rol rol)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_crearRol", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros al comando
                        command.Parameters.AddWithValue("@nombre", rol.Nombre);

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
        }

        public bool modificarRol(Rol rol)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_modificarRol", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", rol.Id);
                        command.Parameters.AddWithValue("@nombre", rol.Nombre);
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
        }

        public List<Rol> buscarRol(string nombre)
        {
            List<Rol> rols = new List<Rol>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_buscarRol @nombre='{nombre}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Rol rol = new Rol();
                        rol.Id = (int)reader["id"];
                        rol.Nombre = reader["nombre"].ToString();

                        rols.Add(rol);

                    }
                    connection.Close();

                }
                return rols;
            }

        }//buscarRol

        public Rol buscarRolId(int id)
        {
            Rol rol = new Rol();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_buscarRolId @id={id}";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        rol.Id = (int)reader["id"];
                        rol.Nombre = reader["nombre"].ToString();

                    }
                    connection.Close();

                }
                return rol;
            }
        }//buscarRolId

        public bool borrarRol(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_borrarRol", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", id);
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
        }
    }
}
