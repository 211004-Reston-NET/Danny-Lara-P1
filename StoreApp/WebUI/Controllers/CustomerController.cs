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

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
