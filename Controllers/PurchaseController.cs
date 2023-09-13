using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class PurchaseController : Controller
    {
        Inventory_SystemEntities db = new Inventory_SystemEntities();

        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayPurchase()
        {
            List<purchase> purchaselist = new List<purchase>();
            purchaselist = db.purchases.OrderByDescending(x => x.ID).ToList();
            return View(purchaselist);
        }
        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            List<string> productnamelist = new List<string>();
            productnamelist = db.products.Select(x => x.Product_Name).ToList();
            ViewBag.productname = new SelectList(productnamelist);
            return View();
        }
        [HttpPost]
        public ActionResult PurchaseProduct(purchase pur)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.purchases.Add(pur);
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

            return RedirectToAction("DisplayPurchase");
        }
        //Update product
        [HttpGet]
        public ActionResult UpdatePurchaseProduct(int id)
        {
            purchase pr = new purchase();
            try
            {

                pr = db.purchases.Where(x => x.ID == id).SingleOrDefault();
            }
            catch (Exception ex)
            {

                TempData["errormessage"] = ex.Message;
            }

            return View(pr);
        }
        [HttpPost]
        public ActionResult UpdatePurchaseProduct(int id, purchase pro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    purchase objpr = new purchase();
                    objpr = db.purchases.Where(x => x.ID == id).SingleOrDefault();
                    objpr.Purchase_Prod = pro.Purchase_Prod;
                    objpr.Purchase_Qnty = pro.Purchase_Qnty;
                    objpr.Purchase_Date = pro.Purchase_Date;
                    db.SaveChanges();
                    TempData["successmessage"] = "Record Updated successfully..";
                }
                else
                {
                    TempData["errormessage"] = "Record not Updated..";
                }


            }
            catch (Exception ex)
            {
                TempData["errormessage"] = ex.Message;
            }

            return RedirectToAction("DisplayPurchase");
        }
        //Details product
        [HttpGet]
        public ActionResult DetailsPurchaseProduct(int id)
        {
            purchase pr = new purchase();
            try
            {

                pr = db.purchases.Where(x => x.ID == id).SingleOrDefault();
            }
            catch (Exception ex)
            {

                TempData["errormessage"] = ex.Message;
            }

            return View(pr);
        }
        //Delete product
        [HttpGet]
        public ActionResult DeletePurchaseProduct(int id)
        {
            purchase pr = new purchase();
            try
            {

                pr = db.purchases.Where(x => x.ID == id).SingleOrDefault();
            }
            catch (Exception ex)
            {

                TempData["errormessage"] = ex.Message;
            }

            return View(pr);
        }

        [HttpPost]

        public ActionResult DeletePurchaseProduct(int id, purchase pro)
        {
            try
            {

                purchase pr = new purchase();

                pr = db.purchases.Remove(db.purchases.Where(x => x.ID == id).SingleOrDefault());
                db.purchases.Remove(pr);
                db.SaveChanges();
                TempData["successmessage"] = "Record deleted successfully..";
            }
            catch (Exception ex)
            {
                TempData["errormessage"] = ex.Message;
            }

            return RedirectToAction("DisplayPurchase");

        }
    }
}