using Data;
using Dominio;

namespace ReglasDeNegocio
{
    public class RolReglasDeNegocio
    {
        private string connectionString;

        public RolReglasDeNegocio(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Rol> buscarRol(string nombre)
        {
            RolData data = new RolData(this.connectionString);
            return data.buscarRol(nombre);
        }

        public Rol buscarRolId(int id)
        {
            RolData data = new RolData(this.connectionString);
            return data.buscarRolId(id);
        }

        public bool modificarRol(Rol rol)
        {
            RolData data = new RolData(this.connectionString);
            return data.modificarRol(rol);
        }

        public bool crearRol(Rol rol)
        {
            RolData data = new RolData(this.connectionString);
            return data.crearRol(rol);
        }

        public bool borrarRol(int id) {
            RolData data = new RolData(this.connectionString);
            return data.borrarRol(id);
        }
    }
}