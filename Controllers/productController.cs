using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class productController : Controller
    {
        Inventory_SystemEntities db = new Inventory_SystemEntities();
        // GET: product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List<product> productList = new List<product>();
            productList = db.products.OrderByDescending(x => x.ID).ToList();

            return View(productList);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(product pro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.products.Add(pro);
                    db.SaveChanges();
                    TempData["successmessage"] = "Product saved successfully..";
                }
                else
                {
                    TempData["errormessage"] = "Product not saved..";
                }


            }
            catch (Exception ex)
            {
                TempData["errormessage"] = ex.Message;
            }

            return RedirectToAction("DisplayProduct");
        }
        //Update product
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            product pr = new product();
            try
            {

                pr = db.products.Where(x => x.ID == id).SingleOrDefault();
            }
            catch (Exception ex)
            {

                TempData["errormessage"] = ex.Message;
            }

            return View(pr);
        }
        [HttpPost]
        public ActionResult UpdateProduct(product pro)
        {
            try
            {
                product pr = new product();
                pr = db.products.Where(x => x.ID == pro.ID).SingleOrDefault();
                if (ModelState.IsValid)
                {
                    pr.Product_Name = pro.Product_Name;
                    pr.Product_Qnty = pro.Product_Qnty;
                    db.SaveChanges();
                    TempData["successmessage"] = "Product Updated successfully..";
                }
                else
                {
                    TempData["errormessage"] = "Product not Updated..";
                }


            }
            catch (Exception ex)
            {
                TempData["errormessage"] = ex.Message;
            }

            return RedirectToAction("DisplayProduct");
        }
        //Details product
        [HttpGet]
        public ActionResult DetailsProduct(int id)
        {
            product pr = new product();
            try
            {

                pr = db.products.Where(x => x.ID == id).SingleOrDefault();
            }
            catch (Exception ex)
            {

                TempData["errormessage"] = ex.Message;
            }

            return View(pr);
        }
        //Delete product
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            product pr = new product();
            try
            {

                pr = db.products.Where(x => x.ID == id).SingleOrDefault();
            }
            catch (Exception ex)
            {

                TempData["errormessage"] = ex.Message;
            }

            return View(pr);
        }

        [HttpPost]

        public ActionResult DeleteProduct(int id, product pro)
        {
            try
            {

                product pr = new product();

                pr = db.products.Remove(db.products.Where(x => x.ID == id).SingleOrDefault());
                db.products.Remove(pr);
                db.SaveChanges();
                TempData["successmessage"] = "Product deleted successfully..";
            }
            catch (Exception ex)
            {
                TempData["errormessage"] = ex.Message;
            }

            return RedirectToAction("DisplayProduct");

        }
    }
}