using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallShopFrame.Models
{
    public class CartViewModel
    {
        public List<Product> cart { get; }
        public List<int> quantity { get; }
        public decimal total { get; set; }

        public CartViewModel()
        {
            cart = new List<Product>();
            quantity = new List<int>();
            total = 0;
        }

        public CartViewModel(string id)
        {
            cart = new List<Product>();
            quantity = new List<int>();
            total = 0;

            getShoppingCart(id);
            CalculateTotal();
        }


        List<Product> getShoppingCart(string id)
        {
            ProductRepository db = new ProductRepository();
            CartRepository dbc = new CartRepository();

            List<Cart> x = dbc.GetUserCart(id).ToList();

            foreach(var z in x)
            {
                cart.Add(db.GetProduct(z.ProductId));
                quantity.Add(z.Quantity);
            }

            return cart;
        }

        decimal CalculateTotal()
        {
            foreach(var x in cart)
            {
                total += x.Price;
            }

            return total;
        }
    }
}