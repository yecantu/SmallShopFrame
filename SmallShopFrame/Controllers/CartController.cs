using SmallShopFrame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallShopFrame.Controllers
{
    public class CartController : Controller
    {
        private CartRepository db = new CartRepository();

        // GET: Cart
        public ActionResult Index()
        {
            //Take to user cart
            // Make this it's own method or file    
            HttpCookie cartId = Request.Cookies["cart"];
            if (cartId == null)
            {
                //assign cookie
            }

            // var x = db.GetUserCart(cartId["id"]).ToList() ;
            CartViewModel x = new CartViewModel(cartId["id"]);

            return View(x);
            //return View("NotFound");
        }
    }
}