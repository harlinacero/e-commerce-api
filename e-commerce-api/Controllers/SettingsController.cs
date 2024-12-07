using e_commerce_infraestructure;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettingsController : ControllerBase
    {
        /// <summary>
        /// Obtiene la cadena de conexión
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetConnectionString")]
        public string GetConnectionString()
        {
            var systemConfiuration = SystemConfiuration.GetInstance();
            var connectionString = systemConfiuration.GetConnecitonString("DefaultConnection");

            return connectionString;
        }

        /// <summary>
        /// Obtiene el valor de un parámetro de configuración
        /// </summary>
        /// <param name="parametername"></param>
        /// <returns></returns>
        [HttpGet("GetParameterValue")]
        public string GetParameterValue(string parametername)
        {
            var systemConfiuration = SystemConfiuration.GetInstance();
            var parameterValue = systemConfiuration.GetSettingsValue(parametername);

            return parameterValue;
        }
    }
}