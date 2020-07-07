using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FashionShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapRoute(
                name: "GetItemByGender",
                url: "Product/ProductByGender/{gender}",
                defaults: new { controller = "Product", action = "ProductByGender", gender = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "GetItemByType",
                url: "Product/ProductByType/{type}",
                defaults: new { controller = "Product", action = "ProductByType", type = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Checkout",
               url: "Home/XemDonHang",
               defaults: new { controller = "Home", action = "XemDonHang"}
           );
            routes.MapRoute(
              name: "XoaKhoiGio",
              url: "Cart/XoaKhoiGio/{id}",
              defaults: new { controller = "Cart", action = "XoaKhoiGio" , id = UrlParameter.Optional}
          );
            routes.MapRoute(
                name: "ThemVaoGio",
                url: "Cart/Themvaogio/{id}/{soluong}",
                defaults: new { controller = "Cart", action = "ThemVaoGio", id = UrlParameter.Optional, soluong = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "GetItemByID",
               url: "Product/Product_Detail/{id}",
               defaults: new { controller = "Product", action = "Product_Detail", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
                name: "Product",
                url: "{controller}/{action}",
                defaults: new { controller = "Product", action = "Index" }
            );
            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}/{a}",
                defaults: new { controller = "Register", action = "Login", a = "no"}
            );
            routes.MapRoute(
                name: "SignUp",
                url: "{controller}/{action}",
                defaults: new { controller = "Register", action = "SignUp" }
            );
            routes.MapRoute(
                name: "CheckLogin",
                url: "{controller}/{action}",
                defaults: new { controller = "Register", action = "SignUp", username = UrlParameter.Optional, password = UrlParameter.Optional}
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
