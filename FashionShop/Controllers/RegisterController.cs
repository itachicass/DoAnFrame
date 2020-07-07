using FashionShop.Models.Dao;
using FashionShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop.Controllers
{
    public class RegisterController : Controller
    {
        QlbhDbContext context = new QlbhDbContext();
        // GET: Register
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string ten, DateTime nsinh, string dchi, string gtinh, string username, string password, string password1,string sdt)
        {
         if(password != password1)
            {
                ViewData["thongbao"] = "error";
                return View();
            }
            else
            {
                KhachhangDao khdao = new KhachhangDao();
                khachhang kh = new khachhang();
                kh.HOTEN = ten;
                kh.NGSINH = nsinh.Date;
                kh.GIOITINH = gtinh;
                kh.DCHI = dchi;
                kh.NGDK = DateTime.Now.Date;
                kh.SODT = sdt;
                int check = khdao.ThemKhachHang(kh);
                if(check != 0)
                {
                    taikhoan tk = new taikhoan();
                    tk.USERNAME = username;
                    tk.PASSWORD = password;
                    tk.MAKH = kh.MAKH;
                    tk.LOAITK = 1;
                    context.taikhoans.Add(tk);
                    int check2 = context.SaveChanges();
                    if(check2 != 0)
                    {
                        Response.Redirect("/Register/Login");
                    }
                    else
                    {
                        ViewData["thongbao"] = "error";
                        return View();
                    }
                }
                else
                {
                    ViewData["thongbao"] = "error";
                    return View();
                }
                return View();
                
                
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            
            ViewBag.returnUrl = System.Web.HttpContext.Current.Request.UrlReferrer;
            return View();
        }
        public void SignOut()
        {
            Session.Clear();
            Response.Redirect("/Home/Index");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            
            Models.Dao.KhachhangDao dao = new Models.Dao.KhachhangDao();
            int check = dao.CheckLogin(username, password);
            //Response.Write(check);
            if (check != 0)
            {
                Session.Add("dangnhap", check);
                //Response.Write(Session["dangnhap"].ToString());
                return Redirect("/Home/Index");
            }
            else
            {
                string a = "sai";
                //Response.Redirect("/Register/Login/" + a);
                ViewData["thongbao"] = "error";
                return View();
            }
        }
    }
}