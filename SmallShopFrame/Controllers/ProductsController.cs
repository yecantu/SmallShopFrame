using SmallShopFrame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallShopFrame.Controllers
{
    public class ProductsController : Controller
    {
        private ProductRepository db = new ProductRepository();
        private CartRepository dbC = new CartRepository();
        private Cookie cookie = new Cookie();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.FindAllProducts().ToList();

            if (Request.Cookies[cookie.name] == null)
                Response.Cookies.Add(cookie.returnNewCookie());

            return View("Index", products);
        }

        //GET: Products/Details/Id
        public ActionResult Details (int id)
        {
            Product product = db.GetProduct(id);
            return View("Details", product);
        }

        //POST: Products/Details/Id
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Details(int id, FormCollection formValues)
        { 
            // Add Item to cart
            Product product = db.GetProduct(id);

            // Make this it's own method or file    
            HttpCookie cartId;

            if (Request.Cookies[cookie.name] == null)
                Response.Cookies.Add(cookie.returnNewCookie());

            cartId = Request.Cookies[cookie.name];

            //Add item to cart
            Cart x = new Cart();
            x.CartId = cartId["id"];
            x.ProductId = product.Id;
            x.Quantity = 3;
            dbC.AddCart(x);
            dbC.Save();
            
            // Do some Javascript confirmation
            return View(product);
        }
    }
}