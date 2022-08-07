using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public double Discount { get; set; }
        public int Sex { get; set; }
        public string Remarks { get; set; }
        public string LandPhone { get; set; }
        public string PostCode { get; set; }
        public string PostOffice { get; set; }
        public string Thana { get; set; }
        public string Zilla { get; set; }
        public string Address { get; set; }
        public string PermanentAddress { get; set; }
        public bool Status { get; set; } = false;
    }
}
