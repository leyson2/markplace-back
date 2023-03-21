using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Data
{
    public class Context : IContext
    {


        IConfiguration _configuration;



        public Context(IConfiguration configuration)
        {

            _configuration = configuration;
            
        }



     //   public SqlConnection sqlConnection => new SqlConnection(_configuration.GetConnectionString("Cadena"));

       public SqlConnection Connection()
        {
            return new SqlConnection(_configuration.GetConnectionString("Cadena"));
        }
        //public SqlConnection SqlConnection => new SqlConnection("Data Source=GAMERPC;Initial Catalog=MarketPlace;Trusted_Connection=True;");





    }


   

}
