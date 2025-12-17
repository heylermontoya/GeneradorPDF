using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace BatchRecord.Api.Helper
{
    public static class DbHelper
    {
        private static IConfiguration? _configuration;
        private static IHttpContextAccessor? _httpContextAccessor;

        public static void Initialize(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public static string GetConnectionString(string name = "DB")
        {
            if (_configuration is null)
                throw new InvalidOperationException("DbHelper no ha sido inicializado con IConfiguration.");

            // Obtener la cadena desde ConnectionStrings o fallback a claves conocidas
            string? cadenaConexion = _configuration.GetConnectionString(name)
                ?? _configuration[$"ConnectionStrings:{name}"]
                ?? _configuration[name]
                ?? (name.Equals("DB", StringComparison.OrdinalIgnoreCase) ? _configuration["StringConnection"] : null)
                ?? (name.Equals("Auth", StringComparison.OrdinalIgnoreCase) ? _configuration["AuthStringConnection"] : null);

            if (string.IsNullOrWhiteSpace(cadenaConexion))
            {
                throw new InvalidOperationException($"No se encontró la cadena de conexión '{name}' en la configuración.");
            }

            // Si pedimos la cadena Auth no hacemos reemplazos ni exigimos header
            if (name.Equals("Auth", StringComparison.OrdinalIgnoreCase))
            {
                return cadenaConexion;
            }

            // Para DB dinámico: preferir header "DB" y luego HttpContext.Items["DB"]
            string? dbKey = _httpContextAccessor?.HttpContext?.Request?.Headers["DB"].FirstOrDefault()
                           ?? _httpContextAccessor?.HttpContext?.Items["DB"]?.ToString();

            if (string.IsNullOrWhiteSpace(dbKey))
            {
                throw new InvalidOperationException("No se proporcionó el header 'DB' ni HttpContext.Items['DB']. Establezca la base de datos destino.");
            }

            return cadenaConexion.Replace("@BaseDatosReemplazar", dbKey);
        }
    }
}
