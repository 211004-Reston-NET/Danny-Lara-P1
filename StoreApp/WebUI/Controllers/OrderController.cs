using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly StoreBL _storeBL;
        private readonly CustomerBL _customerBL;
        public OrderController(StoreBL p_storeBL, CustomerBL p_customerBL)
        {
            _storeBL = p_storeBL;
            _customerBL = p_customerBL;
        }
        // GET: OrderController
        public ActionResult Index(int p_storeId=0, int p_custId=0)
        {
            if (p_storeId == 0 && p_custId == 0)
            {
                List<OrderVM> orders = new List<OrderVM>();
                orders.Add(new OrderVM
                {
                    CustId = 0,
                    OrderNumber = 0,
                    StoreId = 0,
                    TotalPrice = 0
                });
                ViewBag.Name = "NOT FOUND";
                return View(orders);
            }
            else if (p_storeId != 0)
            {
                ViewBag.Name = _storeBL.GetStore(p_storeId).Name;
                return View(_storeBL.GetOrdersByStoreID(p_storeId).Select(o => new OrderVM(o)).ToList());
            }
            else
            {
                ViewBag.Name = _customerBL.GetCustomer(p_custId).Name;
                return View(_customerBL.GetOrdersByCustId(p_custId).Select(o => new OrderVM(o)).ToList());
            }
        }

        [HttpGet]
        public ActionResult StoreDetails(int p_storeId)
        {
            ViewBag.Name = _storeBL.GetStore(p_storeId).Name;
            ViewBag.Id = p_storeId;
            List<OrderVM> orders = _storeBL.GetOrdersByStoreID(p_storeId).Select(o => new OrderVM(o)).ToList();
            if (orders.Count == 0 || orders == null)
            {
                orders = new List<OrderVM>();
                orders.Add(new OrderVM
                {
                    CustId = 0,
                    OrderNumber = 0,
                    StoreId = 0,
                    TotalPrice = 0
                });
            }
            return View(orders);
        }
        [HttpPost]
        public ActionResult StoreDetails(int p_storeId, IFormCollection collection)
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
        [HttpGet]
        public ActionResult CustDetails(int p_id)
        {
            ViewBag.Name = _customerBL.GetCustomer(p_id).Name;
            ViewBag.Id = p_id;
            List<OrderVM> orders = _customerBL.GetOrdersByCustId(p_id).Select(o => new OrderVM(o)).ToList();
            if (orders.Count == 0 || orders == null)
            {
                orders = new List<OrderVM>();
                orders.Add(new OrderVM
                {
                    CustId = 0,
                    OrderNumber = 0,
                    StoreId = 0,
                    TotalPrice = 0
                });
            }
            return View(orders);
        }
        [HttpPost]
        public ActionResult CustDetails(int p_id, IFormCollection collection)
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

        [HttpGet]
        public ActionResult Create(int custId)
        {
            CustomerVM cust = new CustomerVM(_customerBL.GetCustomer(custId));
            return View(cust);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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
