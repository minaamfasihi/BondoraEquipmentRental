using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frontend.Abstract;
using Frontend.Helpers;
using Frontend.Models;
using Frontend.Services;
using Frontend.Views.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Frontend.Controllers
{
    public class CartController : Controller
    {
        public IEquipmentRepository repository;

        public CartController(IEquipmentRepository equipmentRepository)
        {
            repository = equipmentRepository;
        }
        public ActionResult AddToCart(int id, int days, string returnUrl)
        {
            Models.Equipment equipment = repository.GetEquipments().
                FirstOrDefault(e => e.id == id);
            if (equipment != null)
            {
                Cart cart = GetCart().AddItem(equipment, days);
                SessionExtensions.Set(HttpContext.Session, "Cart", cart);
            }
            return RedirectToAction("Index", "Equipment", new { returnUrl });
        }

        public ActionResult RemoveFromCart(int id, string returnUrl)
        {
            Models.Equipment equipment = repository.GetEquipments().
                                             FirstOrDefault(e => e.id == id);
            if (equipment != null)
            {
                //GetCart().RemoveItem(equipment);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = SessionExtensions.Get(HttpContext.Session, "Cart");
            if (cart == null)
            {
                cart = new Cart();
                SessionExtensions.Set(HttpContext.Session, "Cart", cart);
            }
            return cart;
        }
        public IActionResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
        public IActionResult GenerateInvoice()
        {
            string json = SessionExtensions.GetRawJSON(HttpContext.Session, "Cart");
            new CartInfoSender().SendMessage(json);
            HttpContext.Session.Clear();
            return View("InvoiceGenerated");
        }
    }
}
