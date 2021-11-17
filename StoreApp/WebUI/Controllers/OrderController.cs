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
    public class OrderController : Controller
    {
        private readonly StoreBL _storeBL;
        private readonly CustomerBL _customerBL;
        static List<LineItems> lineItems = new List<LineItems>();
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
                ViewBag.Name = "ALL ORDERS";
                return View(_storeBL.GetAllOrders().Select(o => new OrderVM(o)).ToList());
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
        public ActionResult Create(int custId)
        {
            ViewBag.CustId = custId;
            return View(_storeBL.GetAll().Select(s => new StoreVM(s)).ToList());
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int custId, List<LineItemVM> orderList, IFormCollection collection)
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

        public ActionResult ChosenStore(int storeId, int custId)
        {
            ViewBag.CustId = custId;
            ViewBag.StoreName = _storeBL.GetStore(storeId).Name;
            ViewBag.StoreId = storeId;
            return View(_storeBL.GetStoreProducts(storeId).Select(p => new ProductVM(p)).ToList());
        }

        public ActionResult AddToOrder(int productId, int storeId, int quantity, int custId)
        {
            ViewBag.CustId = custId;
            ViewBag.StoreName = _storeBL.GetStore(storeId).Name;
            ViewBag.StoreId = storeId;
            lineItems.Add(new LineItems(_storeBL.GetProduct(productId), productId, quantity));
            return RedirectToAction("Cart", "Order", new { custId, storeId });
        }

        public ActionResult Cart(int custId, int storeId)
        {
            ViewBag.CustId = custId;
            ViewBag.StoreId = storeId;
            List<LineItemVM> items = new();
            double total = 0;
            foreach (LineItems item in lineItems)
            {
                total += item.Quantity * _storeBL.GetProduct(item.ProductID).Price;
                items.Add(new LineItemVM {
                    ProductID = item.ProductID,
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity,
                    Price = item.Product.Price});
            }
            ViewBag.TotalPrice = total;
            return View(items);
        }

        public ActionResult PlaceOrder(int custId, int storeId)
        {
            Store s = _storeBL.GetStore(storeId);
            Order order = new Order(lineItems, s);
            order.CustID = custId;
            _storeBL.AddOrder(order);
            return RedirectToAction("Index", "Customer");
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
    }
}
