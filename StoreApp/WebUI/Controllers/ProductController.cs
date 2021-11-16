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
    public class ProductController : Controller
    {
        private StoreBL _storeBL;
        public ProductController(StoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public ActionResult Index(int storeId=0, int productId=0)
        {
            if (storeId == 0)
            {
                ViewBag.StoreName = "Store";
                return View(_storeBL.GetAllProducts().Select(p => new ProductVM(p)).ToList());
            }
            else
            {
                ViewBag.StoreName = _storeBL.GetStore(storeId).Name;
                return View(_storeBL.GetStoreProducts(storeId).Select(p => new ProductVM(p)).ToList());
            }
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
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

        // GET: ProductController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id, int addThis)
        {
            ViewBag.AddThis = addThis;
            ViewBag.Product = id;
            return View(new ProductVM(_storeBL.GetProduct(id)));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, int addThis, IFormCollection collection)
        {
            try
            {
                Product p = _storeBL.GetProduct(id);
                p.Quantity += addThis;
                _storeBL.UpdateProduct(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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
