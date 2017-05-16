using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_22.Models;

namespace Lab_22.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Inventory()
        {
            List<Item> ItemList = GetItemList();

            ViewBag.Items = ItemList;

            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult AddItem(Item newItem)
        {
            Lab22Entities DB = new Lab22Entities();

            DB.Items.Add(newItem);

            try
            {
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Oops! Something odd just happened...";
                ViewBag.ErrorDetails = ex.StackTrace;
                return View("Error");
            }

            return RedirectToAction("Inventory");
        }

        public ActionResult Update(int itemID)
        {
            Lab22Entities DB = new Lab22Entities();

            Item ToFind = DB.Items.Find(itemID);

            if (ToFind == null)
            {
                ViewBag.ErrorMessage = "Unable to update item.";
                ViewBag.ErrorDetails = "ItemID not found.";
                return View("Error");
            }

            return View(ToFind);
        }

        public ActionResult UpdateItem(Item updatedItem)
        {
            Lab22Entities DB = new Lab22Entities();

            Item originalItem = DB.Items.Find(updatedItem.ItemID);

            if (originalItem == null)
            {
                ViewBag.ErrorMessage = "Unable to update item.";
                ViewBag.ErrorDetails = "ItemID not found.";
                return View("Error");
            }

            DB.Entry(originalItem).CurrentValues.SetValues(updatedItem);

            //DB.Entry(originalItem).State = System.Data.Entity.EntityState.Modified; 
            try
            {
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Oops! Something odd just happened...";
                ViewBag.ErrorDetails = ex.StackTrace;
                return View("Error");
            }

            return RedirectToAction("Inventory");
        }

        public ActionResult Delete(int itemID)
        {

            Lab22Entities DB = new Lab22Entities();

            Item ToDelete = DB.Items.Find(itemID);

            if (ToDelete == null)
            {
                ViewBag.ErrorMessage = "Unable to delete.";
                ViewBag.ErrorDetails = "ItemID not found.";
                return View("Error");
            }

            DB.Items.Remove(ToDelete);

            try
            {
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Oops! Something odd just happened...";
                ViewBag.ErrorDetails = ex.StackTrace;
                return View("Error");
            }

            return RedirectToAction("Inventory");
        }

        public List<Item> GetItemList()
        {
            Lab22Entities DB = new Lab22Entities();
            return DB.Items.ToList();
        }

    }
}