using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallShopFrame.Models
{
  /*  public class CartList
    {
       // private List<CartItem> items { get; set; }
       // private int id { get; set; }
        
        Cart(int x)
        {
            items = new List<CartItem>();
       //     id = x;
        }

        public void AddCartItem(CartItem i)
        {
            items.Add (i);
        }

        public void DeleteCartItem(CartItem i)
        {
            items.Add(i);
        }
    }*/

    public class CartItem
    {
        private Product product { get; set; }
        private int quantity { get; set; }

        CartItem(Product p, int q)
        {
            this.product = p;
            this.quantity = q;
        }
    }
}