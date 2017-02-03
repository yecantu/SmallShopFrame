using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallShopFrame.Models
{
    public class ProductRepository
    {
        private SmallShopFrameDataContext db = new SmallShopFrameDataContext();

        //Query Methods
        public IQueryable<Product> FindAllProducts()
        {
            return db.Products;
        }

        public IQueryable<Product> FindAllInStockProducts()
        {
            return from Product in db.Products
                   where Product.Quantity != 0
                   select Product;
        }

        public IQueryable<Product> FindAllOutStockProducts()
        {
            return from Product in db.Products
                   where Product.Quantity == 0
                   select Product;
        }

        public IQueryable<Product> GetProductsByType(string type)
        {
            return from Product in db.Products
                   where Product.Quantity != 0 && Product.ProductType == type
                   select Product;
        }

        public Product GetProduct(int id)
        {
            return db.Products.SingleOrDefault(p => p.Id == id);
        }

        //Add and Delete Methods
        public void AddProduct(Product x)
        {
            db.Products.InsertOnSubmit(x);
        }

        public void DeleteProduct(Product x)
        {
            db.Products.DeleteOnSubmit(x);
        }

        //Persistance
        public void Save()
        {
            db.SubmitChanges();
        }
    }
}