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
        public ActionResult Index()
        {
            return View(_customerBL.GetAll().Select(cust => new CustomerVM(cust)).ToList());
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

        public ActionResult Search(int p_custId)
        {
            if(_customerBL.CustExists(p_custId))
            {
                Customer c = _customerBL.GetCustomer(p_custId);
                CustomerVM result = new CustomerVM
                {
                    CustId = c.CustID,
                    Name = c.Name,
                    Address = c.Address,
                    PhoneNumber = c.PhoneNumber,
                    Email = c.Email
                };
                return View(result);
            }
            return View();
        }
    }
}
