using FashionShop.Models;
using FashionShop.Models.Dao;
using FashionShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public int ThemVaoGio(int masp, int soluong)
        {   
            if(Session["giohang"] == null)
            {
                List<CartItem> giohang = new List<CartItem>();
                Session.Add("giohang", giohang);
            }
            
            if (((List<CartItem>)Session["giohang"]).FirstOrDefault(m => m.MASP == masp) == null)
            {
                ProductDao dao = new ProductDao();
                sanpham sp = dao.GetItemByID(masp).FirstOrDefault();
                double ptkm = 1;
                SaleDao saledao = new SaleDao();
                ptkm = saledao.phantramKM(sp.MAKM) / 100.0;

                CartItem newItem = new CartItem();
                {
                    newItem.MASP = masp;
                    newItem.TENSP = sp.TENSP;
                    newItem.HINHANH = sp.HINHANH;
                    newItem.SoLuong = soluong;
                    newItem.GIA = sp.GIA;
                    newItem.ThanhTien = sp.GIA * (1 - ptkm) * soluong;

                }
                ((List<CartItem>)Session["giohang"]).Add(newItem);
                return 1;
            }
            else
            {
                ((List<CartItem>)Session["giohang"]).FirstOrDefault(m => m.MASP == masp).SoLuong += soluong;
                ((List<CartItem>)Session["giohang"]).FirstOrDefault(m => m.MASP == masp).ThanhTien =
                    ((List<CartItem>)Session["giohang"]).FirstOrDefault(m => m.MASP == masp).SoLuong * ((List<CartItem>)Session["giohang"]).FirstOrDefault(m => m.MASP == masp).GIA;
                return 1;
            }
           

        }

        public ActionResult ThanhToan()
        {
            KhachhangDao khdao = new KhachhangDao();
            khachhang kh = new khachhang();
            if (Session["dangnhap"] == null || string.IsNullOrEmpty(Session["dangnhap"].ToString()))
            {
                
            }else
            {
                int makh = (int)Session["dangnhap"];
                kh = khdao.GetInforCustom(makh);
            }
            ViewData["CustomInfor"] = kh;
            return View();
        }  

        [HttpPost]
        public ActionResult ThanhToan(string ten, string sdt, string diachi, DateTime nsinh, string gioitinh)
        {
            KhachhangDao khdao = new KhachhangDao();

            HoadonDao hddao = new HoadonDao();
            int makh = 0; 
            khachhang kh = new khachhang();
            kh.HOTEN = ten;
            kh.DCHI = diachi;
            kh.GIOITINH = gioitinh;
            kh.NGSINH = nsinh.Date;
            kh.NGDK = DateTime.Now.Date;
            kh.SODT = sdt;
            
            if (Session["dangnhap"] != null)
            {
                makh = (int)Session["dangnhap"];
               
            }  else
            {
                //int kiemtra = khdao.ThemKhachHang(kh);
                //if(kiemtra != 0)
                //{
                //    makh = khdao.LayKHVuaThem();
                //}
                int kiemtra = khdao.ThemKH(ten, sdt, diachi, nsinh, gioitinh);
                if(kiemtra != 0)
                    makh = khdao.LayKHVuaThem();
            }
           
            
            int kt = hddao.ThemHoaDon(makh, 0, (List<CartItem>)Session["giohang"], diachi);
            if (kt != 0) ViewData["thongbao"] = "ok";
            else ViewData["thongbao"] = "error";
            {
                if (Session["dangnhap"] == null || string.IsNullOrEmpty(Session["dangnhap"].ToString()))
                {

                }
                else
                {
                    makh = (int)Session["dangnhap"];
                    kh = khdao.GetInforCustom(makh);
                }
                ViewData["CustomInfor"] = kh;
            }
            Session.Remove("giohang");
            return View();

        }
        
        public string XoaKhoiGio(int SanPhamID)
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemXoa = giohang.FirstOrDefault(m => m.MASP == SanPhamID);
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            Session.Remove("giohang");
            Session.Add("giohang", giohang);
            return itemXoa.ToString();
            //return RedirectToAction("/Index");
        }
    }
}