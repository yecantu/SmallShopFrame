﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallShopFrame.Models
{
    public class CartRepository
    {
        private SmallShopFrameDataContext db = new SmallShopFrameDataContext();

        //Query Methods
        public IQueryable<Cart> GetUserCart(string id)
        {
            return from Cart in db.Carts
                   where Cart.CartId == id
                   select Cart;
        }

        public bool IdExist(string id)
        {
            return ((from Cart in db.Carts
                   where Cart.CartId == id
                   select Cart).Count() == 0) ? true : false;
        }

        public int GetCartSize(string id)
        {
            return (from Cart in db.Carts
                     where Cart.CartId == id
                     select Cart).Count();
        }

        /* public Cart GetItemInCart(int id)
         {
             //Get one particular item in cart
         } */

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