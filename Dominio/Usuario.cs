using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public  class Usuario
    {
        private int id;
        private string cedula;
        private string nombre;
        private string telefono;
        private int rol;
        private string contrasena;
        private bool habilitado;

        public Usuario()
        {
            this.id = 0;
            this.cedula = "";
            this.rol = 0;
            this.nombre = "";
            this.telefono = "";
            this.contrasena = "";
            this.habilitado = false;
        }

        public Usuario(int id, string cedula, string nombre, string telefono, int rol, string contrasena, bool habilitado)
        {
            this.id = id;
            this.cedula = cedula;
            this.nombre = nombre;
            this.telefono = telefono;
            this.rol = rol;
            this.contrasena = contrasena;
            this.habilitado = habilitado;
        }

        public int Id { get => id; set => id = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int Rol { get => rol; set => rol = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public bool Habilitado { get => habilitado; set => habilitado = value; }
    }
}
