using Microsoft.Extensions.Configuration;

namespace e_commerce_infraestructure
{
    public class SystemConfiuration
    {
        private readonly IConfiguration configuration;
        /// <summary>
        /// Con Lazy se asegura que la se cree solo cuando se necesite
        /// </summary>
        private static Lazy<SystemConfiuration> instance;


        /// <summary>
        /// Se declara un constructor privadp para evitar que se creen instancias fuera de la clase
        /// </summary>
        private SystemConfiuration()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        /// <summary>
        /// Propiedad estatica para acceder a la instancia de la clase
        /// </summary>
        public static SystemConfiuration GetInstance()
        {
            if (instance == null)
            {
                instance = new Lazy<SystemConfiuration>(() => new SystemConfiuration());
            }
            return instance.Value;
        }

        /// <summary>
        /// Método para obtener la cadena de conexión
        /// </summary>
        /// <param name="nombreConexion">Nombre de la cadena de conexión</param>
        /// <returns></returns>
        public string GetConnecitonString(string nombreConexion)
        {
            return configuration.GetConnectionString(nombreConexion);
        }

        /// <summary>
        /// Devuelve el valor de una configuración específica por su nombre
        /// </summary>
        /// <param name="clave"></param>
        /// <returns></returns>
        public string GetSettingsValue(string clave)
        {
            return configuration[clave];
        }
    }
}
