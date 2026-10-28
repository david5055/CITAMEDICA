using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace medicitass
{
    public class Conexion
    {
        private string cadenaConexion =
            @"Data Source=(localdb)\MSSQLLocalDB;
              Initial Catalog=MediCitas;
              Integrated Security=True;
              TrustServerCertificate=True;";

        public SqlConnection Conectar()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}

