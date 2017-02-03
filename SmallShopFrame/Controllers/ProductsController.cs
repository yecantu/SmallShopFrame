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

        // GET: Products
        public ActionResult Index()
        {
            var products = db.FindAllProducts();
            return View();
        }

        //GET: Products/Details/Id
        public ActionResult Details (int id)
        {
            Product product = db.GetProduct(id);

            return View();
        }
    }
}