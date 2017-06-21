using MVCShop.Models;
using MVCShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MVCShop.Controllers
{
    public class StockItemController : Controller
    {
        private ItemRepository repo;

        public StockItemController()
        {
            repo = new ItemRepository();
        }


        public ActionResult Autocomplete(string term)
        {
            var AutocompleteList = repo.GetAllItems();

            var query = (from i in AutocompleteList
                         where i.Name.StartsWith(term)
                         select new { label = i.Name }).Take(10);

            return Json(query, JsonRequestBehavior.AllowGet);
        }
        // GET: StockItem
        public ActionResult Index(string searchTerm = null)
        {
        
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Items", repo.SearchByPriceOrName(searchTerm));
            }
            return View(repo.SearchByPriceOrName(searchTerm));

        }

        public ActionResult Details(int id)
        {
            return View(repo.DetailsByArtNum(id));
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem item = repo.DetailsByArtNum(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            StockItem item = repo.DetailsByArtNum(id);
            repo.RemoveItem(item);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteSelected(int[] deleteInputs)
        {
            if (deleteInputs == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<StockItem> removeList = repo.GetByArtNum(deleteInputs);
            if (deleteInputs == null)
            {
                return HttpNotFound();
            }
            return View(removeList);
        }

        [HttpPost, ActionName("DeleteSelected")]
        public ActionResult DeleteSelectedConfirm(int[] deleteInputs)
        {
            List<StockItem> removeList = repo.GetByArtNum(deleteInputs);
            if (removeList != null)
            {
                foreach (var item in removeList)
                {
                    repo.RemoveItem(item);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Create([Bind(Include = "ArticleNumber, Name, Price, ShelfPosition, Quantity, Description")] StockItem item)
        //{
        //    if (ModelState.IsValid && repo.CheckShelfPosition(item) == false)
        //    {
        //        repo.AddNewItem(item);
        //        return RedirectToAction("Index");
        //    }
        //    return View(item);
        //}

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem item = repo.DetailsByArtNum(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "ArticleNumber, Name, Price, ShelfPosition, Quantity, Description")] StockItem item)
        {
            if (ModelState.IsValid)
            {
                repo.Edit(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }
    }   
}