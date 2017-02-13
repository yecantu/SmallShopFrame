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
        private Cookie cookie = new Cookie();

        // GET: Cart
        public ActionResult Index()
        {
            //Take to user cart
            HttpCookie cartId;

            if (Request.Cookies[cookie.name] == null)
                Response.Cookies.Add(cookie.returnNewCookie());

            cartId = Request.Cookies[cookie.name];

            CartViewModel x = new CartViewModel(cartId["id"]);

            return View(x);
        }
    }
}