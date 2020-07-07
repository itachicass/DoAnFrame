using FashionShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop.Controllers
{
    public class PhanHoiController : Controller
    {
        QlbhDbContext context = new QlbhDbContext();
        
        // GET: PhanHoi
        public ActionResult Index()
        {
            return View();
        }
        public int XoaPH(int maph)
        {
            //Response.Write(maph);
            phanhoi ph = new phanhoi();
            ph = context.phanhois.Where(p => p.MAPH == maph).ToList().LastOrDefault();
            context.phanhois.Remove(ph);
            int check = context.SaveChanges();
            Response.Redirect("/Product/Product_Detail/" + ph.MASP);
            return check;
        }
        public int ThemPH(int masp, string nd)
        {
            //Response.Write(masp);
            //Response.Write(nd);
            phanhoi ph = new phanhoi();
            ph.MASP = masp;
            ph.MAKH = (int)Session["dangnhap"];
            ph.NOIDUNG = nd;
            ph.THOIGIANPH = DateTime.Now.Date;
            context.phanhois.Add(ph);
            int check = context.SaveChanges();
            if (check != 0)
                Response.Redirect("/Product/Product_Detail/" + ph.MASP);
            else
                Response.Write("Khong them duoc");
            return check;
        }
    }
}