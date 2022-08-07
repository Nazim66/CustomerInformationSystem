using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DataServices;

namespace WebApplication.Models
{
    public class Database
    {
        public CustomerDataService CustomerDataService { get; set; }

        public Database()
        {
            string connString = @"Server=DESKTOP-03VU7SV\SQLEXPRESS;Database=DemoDb;Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connString);

            CustomerDataService = new CustomerDataService(conn);

        }
    }
}
