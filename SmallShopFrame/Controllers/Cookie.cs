using SmallShopFrame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallShopFrame.Controllers
{
   public class Cookie
    {
        HttpCookie cookie;
        CartRepository dbc;

        Cookie()
        {
            cookie = new HttpCookie("cart");
            dbc = new CartRepository();
        }

        void makeCookie()
        {
            //Make Cookie
         //   cookie = new HttpCookie("cart");
            Guid id = Guid.NewGuid(); //Test if guid already exists in database

            while(!dbc.IdExist(id.ToString()))
            {
                id = Guid.NewGuid();
            }

            cookie["id"] = id.ToString(); //Use Guid() to generate a unique id, check if guid will be unique in database if so then store this id
            cookie.Expires = DateTime.Now.AddDays(5);
          /*  if (dbc.IdExist(id.ToString()))
            {

            }
            else
            {

            }*/
        
            //  Response.Cookies.Add(cartId);
        }
    }
}