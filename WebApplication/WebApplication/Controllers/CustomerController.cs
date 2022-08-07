using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class CustomerController : Controller
    {

        CustomerService _customer = new CustomerService();
        public CustomerController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetAll()
        {
           
            var customerList = _customer.GetAll();
            return Json(customerList);
        }

        [HttpPost]
        public JsonResult AddCustomer(Customer prm)
        {      
                _customer.AddCustomer(prm);
                return new JsonResult(new { Status = "Successfully Added to the Databse" });
        }

        [HttpPost]
        public JsonResult UpdateCustomer(Customer prm)
        {
            _customer.UpdateCustomer(prm);
            return new JsonResult(new { Status = "Successfully Added to the Databse" });

        }

        public IActionResult GetById(int id)
        {
            var customerInfo = _customer.GetById(id);
            return Json(customerInfo);
        }

        public IActionResult UpdateStatus(int id)
        {
             _customer.UpdateStatus(id);
            return new JsonResult(new { Status = "Successfully Updated" });
        }

        public IActionResult UploadImage(int id)
        {
            return null;
        }

    }
}
