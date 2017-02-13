using SmallShopFrame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallShopFrame.Controllers
{
   public class Cookie
    {
        public HttpCookie cookie { get; private set; }
        private CartRepository dbc;
        public string name { get; private set; }

        public Cookie()
        {
            name = "cart";
            cookie = new HttpCookie(name);
            dbc = new CartRepository();
        }

        public void makeCookie()
        {
            Guid id = Guid.NewGuid(); //Test if guid already exists in database

            while(!dbc.IdExist(id.ToString()))
            {
                id = Guid.NewGuid();
            }

            cookie["id"] = id.ToString(); 
            cookie.Expires = DateTime.Now.AddDays(5);
        }

        public HttpCookie returnNewCookie()
        {
            Guid id = Guid.NewGuid(); //Test if guid already exists in database

            while (!dbc.IdExist(id.ToString()))
            {
                id = Guid.NewGuid();
            }

            cookie["id"] = id.ToString();
            cookie.Expires = DateTime.Now.AddDays(5);

            return cookie;
        }


    }
}