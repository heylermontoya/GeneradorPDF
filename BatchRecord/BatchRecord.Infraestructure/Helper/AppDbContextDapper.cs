using Microsoft.Data.SqlClient;
using System.Data;

namespace BatchRecord.Infrastructure.Helper
{
    public class AppDbContextDapper(string conexion)
    {
        private readonly string _conexionString = conexion;

        public IDbConnection CreateConexion() => new SqlConnection(_conexionString);
        public IDbConnection CreateConexion(string conexionString) => new SqlConnection(conexionString);
    }
}
