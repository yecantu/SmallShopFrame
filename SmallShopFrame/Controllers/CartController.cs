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
            return View("NotFound");
        }
    }
}