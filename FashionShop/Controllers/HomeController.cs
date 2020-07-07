
using FashionShop.Models.Dao;
using FashionShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FashionShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProductDao dao = new ProductDao();
            ViewData["bestseller"] = dao.BestSeller();
            ViewData["newproduct"] = dao.NewProduct();
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public int themkh()
        {
            khachhang kh = new khachhang();
            kh.HOTEN = "Thanh";
            kh.DCHI = "TP HCM";
            kh.NGDK = DateTime.Now.Date;
            kh.NGSINH = DateTime.Now.Date;
            kh.SODT = "01234";
            kh.GIOITINH = "Nam";
            KhachhangDao khachhangDao = new KhachhangDao();
            return khachhangDao.ThemKhachHang(kh);
        }

        public ActionResult Account()
        {
           khachhang kh = new khachhang();
            if (Session["dangnhap"]!=null &&!string.IsNullOrEmpty(Session["dangnhap"].ToString()))
            {
                KhachhangDao dao = new KhachhangDao();
                kh = dao.GetInforCustom((int)Session["dangnhap"]);
                ViewData["kh"]= kh;
            }
            return View();
        }

        public void CapnhatThongTinKH(string phone, string address)
        {
            KhachhangDao khdao = new KhachhangDao();
            khdao.CapnhaththongtinKH((int)Session["dangnhap"], phone, address);
        }
        
        public ActionResult XemDonHang()
        {
            HoadonDao dao = new HoadonDao();
            List<cthd> listcthd = new List<cthd>();
           
            hoadon hd = new hoadon();
            if(Session["dangnhap"] != null || !string.IsNullOrEmpty(Session["dangnhap"].ToString()))
            {
                hd = dao.HoaDonGanNhatCuaKH((int)Session["dangnhap"]);
                listcthd = dao.LayCTHD((int)Session["dangnhap"]);
            }
            
            ViewData["hoadon"] = hd;
            ViewData["listorder"] = listcthd;
            return View();
        }
        public ActionResult LichSuMuaHang()
        {
            HoadonDao hoadonDao = new HoadonDao();
            int makh = (int)Session["dangnhap"];
            List<hoadon> listhd = hoadonDao.laydanhsachhoadon(makh);
            ViewData["listhd"] = listhd;
            return View();
        }
        
        public ActionResult ChiTietDH(int sohd)
        {
            HoadonDao hoadonDao = new HoadonDao();
            List<cthd> listcthd = hoadonDao.LayCTHD(sohd);
            ViewData["listcthd"] = listcthd;
            return View();
        }

    }
}