using kanban.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace kanban.Views
{
    public class ItemsController : Controller
    {
        //private KanbanDbContext db = new KanbanDbContext();

        // GET: Items
        public ActionResult Index()
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Items").Result;
            IEnumerable<Item> itemList = response.Content.ReadAsAsync<IEnumerable<Item>>().Result;

            IEnumerable<Item> toDo      = itemList.Where(x => x.Column == 0);
            IEnumerable<Item> inProcess = itemList.Where(x => x.Column == 1);
            IEnumerable<Item> finished  = itemList.Where(x => x.Column == 2);

            ViewBag.Todo      = toDo;
            ViewBag.InProcess = inProcess;
            ViewBag.Finished  = finished;

            return View(itemList.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Items\\"+id).Result;
            Item item = response.Content.ReadAsAsync<Item>().Result;
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,DateCreated,Column")] Item item)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Items\\Create", item).Result;
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Items\\" + id).Result;
            Item item = response.Content.ReadAsAsync<Item>().Result;
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,DateCreated,Column")] Item item)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Items\\"+item.ID, item).Result;
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Items\\" + id).Result;
            Item item = response.Content.ReadAsAsync<Item>().Result;
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Items\\" + id).Result;
            return RedirectToAction("Index");
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
