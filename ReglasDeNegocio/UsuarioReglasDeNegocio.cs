using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Dominio;

namespace ReglasDeNegocio
{
    public class UsuarioReglasDeNegocio
    {
        private string connectionString;

        public UsuarioReglasDeNegocio(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Usuario> buscarUsuario(string nombre)
        {
            UsuarioData data = new UsuarioData(this.connectionString);
            return data.buscarUsuario(nombre);
        }

        public Usuario buscarUsuarioId(int id)
        {
            UsuarioData data = new UsuarioData(this.connectionString);
            return data.buscarUsuarioId(id);
        }

        public Usuario Login(string cedula, string contrasena)
        {
            UsuarioData data = new UsuarioData(this.connectionString);
            return data.Login(cedula,contrasena);
        }

        public bool modificarUsuario(Usuario usuario)
        {
            UsuarioData data = new UsuarioData(this.connectionString);
            return data.modificarUsuario(usuario);
        }

        public bool crearUsuario(Usuario usuario)
        {
            UsuarioData data = new UsuarioData(this.connectionString);
            return data.crearUsuario(usuario);
        }
    }
}
