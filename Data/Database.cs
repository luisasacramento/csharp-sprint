using System.Data.SqlClient;

namespace ProjetoCSharp.Data
{
    public static class Database
    {
        // Ajuste para sua instância do SQL Server
        private static readonly string connectionString = 
            "Server=localhost;Database=ProjetoDB;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
