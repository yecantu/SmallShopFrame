using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallShopFrame.Models
{
    public class CartRepository
    {
        private SmallShopFrameDataContext db = new SmallShopFrameDataContext();

        //Query Methods
        public IQueryable<Cart> GetCart(int id)
        {
            return from Cart in db.Carts
                   where Cart.CartId == id
                   select Cart;
        }

        //Add and Delete Methods
        public void AddCart(Cart x)
        {
            db.Carts.InsertOnSubmit(x);
        }

        public void DeleteCart(Cart x)
        {
            db.Carts.DeleteOnSubmit(x);
        }

        //Persistance
        public void Save()
        {
            db.SubmitChanges();
        }
    }
}