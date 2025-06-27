using JewelryStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace JewelryStore.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var cart = Session["cart"] as List<CartItem> ?? new List<CartItem>();
            return View(cart);
        }

        public ActionResult Add(int id)
        {
            var item = db.Jewelries.Find(id);
            if (item == null) return HttpNotFound();

            var cart = Session["cart"] as List<CartItem> ?? new List<CartItem>();

            var existingItem = cart.FirstOrDefault(c => c.Jewelry.Id == id);
            if (existingItem != null)
                existingItem.Quantity++;
            else
                cart.Add(new CartItem { Jewelry = item, Quantity = 1 });

            Session["cart"] = cart;

            return RedirectToAction("Index");
        }

        public ActionResult Clear()
        {
            Session["cart"] = null;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            var cart = Session["cart"] as List<CartItem> ?? new List<CartItem>();

            if (!cart.Any())
            {
                TempData["Message"] = "Корзина порожня.";
                return RedirectToAction("Index");
            }

            return View(new CheckoutViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckoutSuccess(CheckoutViewModel model)
        {
            var cart = Session["cart"] as List<CartItem> ?? new List<CartItem>();

            if (!cart.Any())
            {
                TempData["Message"] = "Корзина порожня.";
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                return View("Checkout", model);
            }

            // TODO: Зберегти замовлення в БД
            // (model.CustomerName, model.Phone, model.Address)
            // + товари з Cart

            Session["cart"] = null;

            return View();
        }
    }
}
