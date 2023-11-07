using Dominio;
using Data;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string connectionString = "workstation id=WokAndRollSeguridad.mssql.somee.com;packet size=4096;user id=kevinAguilar_SQLLogin_1;pwd=rwnezrmq5c;data source=WokAndRollSeguridad.mssql.somee.com;persist security info=False;initial catalog=WokAndRollSeguridad";

            Usuario usuario = new Usuario();
            usuario.Id = 3;
            usuario.Nombre = "Nombre1";
            usuario.Rol = 1;
            usuario.Cedula = "cedula1";
            usuario.Contrasena = "contraseña1";
            usuario.Telefono = "Telefono1";
            usuario.Habilitado = true;

            UsuarioData data = new UsuarioData(connectionString);
            data.Login("304610238","123");

        }


    }
}