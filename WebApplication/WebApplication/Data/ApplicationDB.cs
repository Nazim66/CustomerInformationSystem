using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class ApplicationDB: DbContext
    {
        public ApplicationDB(DbContextOptions<ApplicationDB>options): base(options)
        {

        }

        public DbSet<Customer> Customers { set; get; }
    }
}
