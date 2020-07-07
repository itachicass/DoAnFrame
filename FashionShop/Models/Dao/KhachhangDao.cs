using FashionShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionShop.Models.Dao
{
    public class KhachhangDao
    {
        QlbhDbContext context ;
        public KhachhangDao()
        {
            context = new QlbhDbContext();
        }
        public khachhang GetInforCustom(int id)
        {
            khachhang khachhang = (from kh in context.khachhangs
                            where kh.MAKH == id
                            select kh).ToList().FirstOrDefault();
            return khachhang; 
        }
        public int CheckLogin(string user, string pass)
        {
            int check = -1;
            check = (from tk in context.taikhoans
                            where tk.USERNAME == user && tk.PASSWORD == pass
                            select tk.MAKH).FirstOrDefault();
            return check;
        }

        public int ThemKH(string ten, string sdt, string diachi, DateTime nsinh, string gioitinh)
        {
            DateTime ngSinh = nsinh.Date;
            ngSinh.ToString("yyyy-MM-dd");
            DateTime ngdk = DateTime.Now.Date;
            ngdk.ToString("yyyy-MM-dd");
            khachhang kh = new khachhang();
            kh.HOTEN = ten;
            kh.SODT = sdt;
            kh.NGSINH = ngSinh;
            kh.GIOITINH = gioitinh;
            kh.NGDK = ngdk;
            kh.DCHI = diachi;
            context.khachhangs.Add(kh);
           
            return context.SaveChanges();
        }

        public int ThemKhachHang(khachhang kh)
        {
            context.khachhangs.Add(kh);
            return context.SaveChanges();
        }

        public int LayKHVuaThem()
        {
            int makh = (from kh in context.khachhangs
                        orderby kh.MAKH descending
                        select kh.MAKH).ToList().FirstOrDefault();
            return makh;
        }

        public void CapnhaththongtinKH(int makh, string sdt, string diachi)
        {
            
            context.khachhangs.Where(kh => kh.MAKH == makh)
                .ToList().ForEach(x => { x.DCHI = diachi; x.SODT = sdt; });
            context.SaveChanges();
        }
    }
}