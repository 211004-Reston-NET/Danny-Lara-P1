using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerBL _customerBL;
        public CustomerController(CustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        // GET: CustomerController
        public ActionResult Index(string search_name=null)
        {
            if(search_name == null)
                return View(_customerBL.GetAll().Select(cust => new CustomerVM(cust)).ToList());
            List<Customer> customers = _customerBL.GetAll();
            List<CustomerVM> result = new List<CustomerVM>();
            foreach (Customer customer in customers)
            {
                if (customer.Name.ToLower().Contains(search_name.ToLower()) || customer.Address.ToLower().Contains(search_name.ToLower()) || 
                    customer.Email.ToLower().Contains(search_name.ToLower()))
                    result.Add(new CustomerVM
                    {
                        CustId = customer.CustID,
                        Name = customer.Name,
                        Address = customer.Address,
                        PhoneNumber = customer.PhoneNumber,
                        Email = customer.Email
                    });
            }
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CustomerVM p_cust)
        {
            if(ModelState.IsValid)
            {
                _customerBL.Add(new Customer()
                {
                    Name = p_cust.Name,
                    Address = p_cust.Address,
                    PhoneNumber = p_cust.PhoneNumber,
                    Email = p_cust.Email
                });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
