using Microsoft.AspNetCore.Mvc;
using ReglasDeNegocio;
using Dominio;
using Newtonsoft.Json;

namespace SeguridadAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]//Ensablado de clase
    public class RolController : ControllerBase
    {

        [HttpGet]
        public string BuscarRol()
        {
            string connectionString = "workstation id=WokAndRollSeguridad.mssql.somee.com;packet size=4096;user id=kevinAguilar_SQLLogin_1;pwd=rwnezrmq5c;data source=WokAndRollSeguridad.mssql.somee.com;persist security info=False;initial catalog=WokAndRollSeguridad";
            RolReglasDeNegocio reglasDeNegocio = new RolReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.buscarRol(""));
        }

        [HttpGet("buscarRol")]
        public string BuscarRol(string parametroBusqueda)
        {
            string connectionString = "workstation id=WokAndRollSeguridad.mssql.somee.com;packet size=4096;user id=kevinAguilar_SQLLogin_1;pwd=rwnezrmq5c;data source=WokAndRollSeguridad.mssql.somee.com;persist security info=False;initial catalog=WokAndRollSeguridad";
            RolReglasDeNegocio reglasDeNegocio = new RolReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.buscarRol(parametroBusqueda));
        }

        [HttpGet("buscarRolId")]
        public string BuscarRolId(int id)
        {
            string connectionString = "workstation id=WokAndRollSeguridad.mssql.somee.com;packet size=4096;user id=kevinAguilar_SQLLogin_1;pwd=rwnezrmq5c;data source=WokAndRollSeguridad.mssql.somee.com;persist security info=False;initial catalog=WokAndRollSeguridad";
            RolReglasDeNegocio reglasDeNegocio = new RolReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.buscarRolId(id));
        }

        [HttpPut("modificarRol")]
        public string modificarRol([FromBody] Rol rol)
        {
            string connectionString = "workstation id=WokAndRollSeguridad.mssql.somee.com;packet size=4096;user id=kevinAguilar_SQLLogin_1;pwd=rwnezrmq5c;data source=WokAndRollSeguridad.mssql.somee.com;persist security info=False;initial catalog=WokAndRollSeguridad";
            RolReglasDeNegocio reglasDeNegocio = new RolReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.modificarRol(rol));
        }

        [HttpPost("crearRol")]
        public string crearRol([FromBody] Rol rol)
        {
            string connectionString = "workstation id=WokAndRollSeguridad.mssql.somee.com;packet size=4096;user id=kevinAguilar_SQLLogin_1;pwd=rwnezrmq5c;data source=WokAndRollSeguridad.mssql.somee.com;persist security info=False;initial catalog=WokAndRollSeguridad";
            RolReglasDeNegocio reglasDeNegocio = new RolReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.crearRol(rol));
        }

        [HttpDelete("borrarRol")]
        public string borrarRol(int id)
        {
            string connectionString = "workstation id=WokAndRollSeguridad.mssql.somee.com;packet size=4096;user id=kevinAguilar_SQLLogin_1;pwd=rwnezrmq5c;data source=WokAndRollSeguridad.mssql.somee.com;persist security info=False;initial catalog=WokAndRollSeguridad";
            RolReglasDeNegocio reglasDeNegocio = new RolReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.borrarRol(id));
        }
    }
}
