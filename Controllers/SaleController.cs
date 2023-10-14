using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale

        Inventory_SystemEntities db = new Inventory_SystemEntities();

        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplaySaleProduct()
        {
            List<Sale> Saleslist = new List<Sale>();
            Saleslist = db.Sales.OrderByDescending(x => x.ID).ToList();
            return View(Saleslist);
        }
        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<string> list = new List<string>();
            list = db.products.Select(x => x.Product_Name).ToList();
            ViewBag.productname = new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult SaleProduct(Sale sal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Sales.Add(sal);
                    db.SaveChanges();
                    TempData["successmessage"] = "Record saved successfully..";
                }
                else
                {
                    TempData["errormessage"] = "Record not saved..";
                }


            }
            catch (Exception ex)
            {
                TempData["errormessage"] = ex.Message;
            }

            return RedirectToAction("DisplaySaleProduct");
        }
        //Update product
        [HttpGet]
        public ActionResult UpdateSaleProduct(int id)
        {
            Sale sal = new Sale();
            try
            {

                sal = db.Sales.Where(x => x.ID == id).SingleOrDefault();
            }
            catch (Exception ex)
            {

                TempData["errormessage"] = ex.Message;
            }

            return View(sal);
        }
        [HttpPost]
        public ActionResult UpdateSaleProduct(Sale sal)
        {
            try
            {

                Sale s = new Sale();
                s = db.Sales.Where(x => x.ID == sal.ID).SingleOrDefault();
                if (s != null)
                {
                    s.Sale_Prod = sal.Sale_Prod;
                    s.Sale_Qnty = sal.Sale_Qnty;
                    s.Sale_Date = sal.Sale_Date;
                    db.SaveChanges();
                    TempData["successmessage"] = "Record Updated successfully..";
                }
                else
                {
                    TempData["successmessage"] = "Record Not Updated..";
                }

            }
            catch (Exception ex)
            {
                TempData["errormessage"] = ex.Message;
            }

            return RedirectToAction("DisplaySaleProduct");
        }
        //Details product
        [HttpGet]
        public ActionResult DetailsSaleProduct(int id)
        {
            Sale sal = new Sale();
            try
            {

                sal = db.Sales.Where(x => x.ID == id).SingleOrDefault();
            }
            catch (Exception ex)
            {

                TempData["errormessage"] = ex.Message;
            }

            return View(sal);
        }
        //Delete product
        [HttpGet]
        public ActionResult DeleteSaleProduct(int id)
        {
            Sale sal = new Sale();
            try
            {

                sal = db.Sales.Where(x => x.ID == id).SingleOrDefault();
            }
            catch (Exception ex)
            {

                TempData["errormessage"] = ex.Message;
            }

            return View(sal);
        }

        [HttpPost]
        public ActionResult DeleteSaleProduct(int id, Sale sal)
        {
            try
            {

                Sale sa = new Sale();
                sa = db.Sales.Remove(db.Sales.Where(x => x.ID == id).SingleOrDefault());
                db.Sales.Remove(sa);
                db.SaveChanges();
                TempData["successmessage"] = "Record deleted successfully..";
            }
            catch (Exception ex)
            {
                TempData["errormessage"] = ex.Message;
            }

            return RedirectToAction("DisplaySaleProduct");

        }
    }
}