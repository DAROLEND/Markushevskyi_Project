using JewelryStore.Models;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace JewelryStore.Controllers
{
    public class JewelryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int page = 1, int pageSize = 6)
        {
            var jewelries = db.Jewelries
                              .OrderBy(j => j.Name)
                              .ToPagedList(page, pageSize);

            return View(jewelries);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Jewelry jewelry)
        {
            if (ModelState.IsValid)
            {
                db.Jewelries.Add(jewelry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jewelry);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var item = db.Jewelries.Find(id);
            return View(item);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Jewelry jewelry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jewelry).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jewelry);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var item = db.Jewelries.Find(id);
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            var item = db.Jewelries.Find(id);
            db.Jewelries.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
