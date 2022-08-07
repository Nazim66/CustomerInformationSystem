using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DataServices;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class CustomerService
    {
        public List<Customer>  GetAll()
        {
            Database db = new Database();
            var customerList = db.CustomerDataService.GetAll();
            return customerList;
        }

        public void AddCustomer(Customer customer)
        {
            Database db = new Database();
            db.CustomerDataService.Insert(customer);
        }

        public Customer GetById(int id)
        {
            Database db = new Database();
            var update = db.CustomerDataService.GetById(id);
            return update;
        }

        public void UpdateCustomer(Customer customer)
        {
            Database db = new Database();
            db.CustomerDataService.Update(customer);
        }

        public  void UpdateStatus(int id)
        {
            Database db = new Database();
            db.CustomerDataService.UpdateStatus(id);
        }
    }
}
