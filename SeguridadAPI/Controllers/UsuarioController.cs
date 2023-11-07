using Dominio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReglasDeNegocio;

namespace SeguridadAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]//Ensablado de clase
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public string BuscarUsuario()
        {
            string connectionString = "workstation id=WokAndRollSeguridad.mssql.somee.com;packet size=4096;user id=kevinAguilar_SQLLogin_1;pwd=rwnezrmq5c;data source=WokAndRollSeguridad.mssql.somee.com;persist security info=False;initial catalog=WokAndRollSeguridad";
            UsuarioReglasDeNegocio reglasDeNegocio = new UsuarioReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.buscarUsuario(""));
        }

        [HttpGet("buscarUsuario")]
        public string BuscarUsuario(string parametroBusqueda)
        {
            string connectionString = "workstation id=WokAndRollSeguridad.mssql.somee.com;packet size=4096;user id=kevinAguilar_SQLLogin_1;pwd=rwnezrmq5c;data source=WokAndRollSeguridad.mssql.somee.com;persist security info=False;initial catalog=WokAndRollSeguridad";
            UsuarioReglasDeNegocio reglasDeNegocio = new UsuarioReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.buscarUsuario(parametroBusqueda));
        }

        [HttpGet("buscarUsuarioId")]
        public string BuscarUsuarioId(int id)
        {
            string connectionString = "workstation id=WokAndRollSeguridad.mssql.somee.com;packet size=4096;user id=kevinAguilar_SQLLogin_1;pwd=rwnezrmq5c;data source=WokAndRollSeguridad.mssql.somee.com;persist security info=False;initial catalog=WokAndRollSeguridad";
            UsuarioReglasDeNegocio reglasDeNegocio = new UsuarioReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.buscarUsuarioId(id));
        }

        [HttpGet("Login")]
        public string Login(string cedula,string contrasena)
        {
            string connectionString = "workstation id=WokAndRollSeguridad.mssql.somee.com;packet size=4096;user id=kevinAguilar_SQLLogin_1;pwd=rwnezrmq5c;data source=WokAndRollSeguridad.mssql.somee.com;persist security info=False;initial catalog=WokAndRollSeguridad";
            UsuarioReglasDeNegocio reglasDeNegocio = new UsuarioReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.Login(cedula, contrasena));
        }

        [HttpPut("modificarUsuario")]
        public string modificarSalonero([FromBody] Usuario usuario)
        {
            string connectionString = "workstation id=WokAndRollSeguridad.mssql.somee.com;packet size=4096;user id=kevinAguilar_SQLLogin_1;pwd=rwnezrmq5c;data source=WokAndRollSeguridad.mssql.somee.com;persist security info=False;initial catalog=WokAndRollSeguridad";
            UsuarioReglasDeNegocio reglasDeNegocio = new UsuarioReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.modificarUsuario(usuario));
        }

        [HttpPost("crearUsuario")]
        public string crearUsuario([FromBody] Usuario usuario)
        {
            string connectionString = "workstation id=WokAndRollSeguridad.mssql.somee.com;packet size=4096;user id=kevinAguilar_SQLLogin_1;pwd=rwnezrmq5c;data source=WokAndRollSeguridad.mssql.somee.com;persist security info=False;initial catalog=WokAndRollSeguridad";
            UsuarioReglasDeNegocio reglasDeNegocio = new UsuarioReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.crearUsuario(usuario));
        }
    }
}
