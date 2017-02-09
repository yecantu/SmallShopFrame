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

        // GET: Products
        public ActionResult Index()
        {
            var products = db.FindAllProducts().ToList();
          /*   //Make Cookie
            HttpCookie cartId = new HttpCookie("cart");
            Guid id = Guid.NewGuid(); //Test if guid already exists in database
            cartId["id"] = id.ToString(); //Use Guid() to generate a unique id, check if guid will be unique in database if so then store this id
            cartId.Expires = DateTime.Now.AddDays(5);
            Response.Cookies.Add(cartId); */
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
            HttpCookie cartId = Request.Cookies["cart"];
            if(cartId == null)
            {
                //assign cookie
            }
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