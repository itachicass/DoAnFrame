using FashionShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionShop.Models.Dao
{
    public class HoadonDao
    {
        QlbhDbContext context;

        public HoadonDao()
        {
            context = new QlbhDbContext();
        }
        public hoadon layhoadonvuathem()
        {
            return (from hd in context.hoadons
                           orderby hd.SOHD descending
                         select hd).FirstOrDefault();
        }
        public int ThemHoaDon(int makh,int thanhtoan, List<CartItem> list, string ghichu)
        {
            hoadon a = new hoadon();
            a.MAKH = null;
            if(makh !=0)
            {
                a.MAKH = makh;
            }
           
            a.NGHD = DateTime.Now.Date;
            a.THANHTOAN = thanhtoan;
            a.TINHTRANG = "cho xu ly";
            a.TRIGIA = 0 ;
            a.GHICHU = ghichu;
            context.hoadons.Add(a);
            context.SaveChanges();
            //a = layhoadonvuathem();
            double thanhtien = 0;
            foreach(var item in list)
            {
                cthd ct = new cthd();
                ct.SOHD = a.SOHD;
                ct.MASP = item.MASP;
                ct.SL = item.SoLuong;
                ct.HINHANH = item.HINHANH;
                ct.THANHTIEN = item.ThanhTien;
                thanhtien += ct.THANHTIEN;
                context.cthds.Add(ct);               
                context.SaveChanges();
            }
            //context.hoadons.Where(hd => hd.SOHD == a.SOHD)
            //    .ToList().ForEach(x => x.TRIGIA = thanhtien);
            context.hoadons.Where(x => x.SOHD == a.SOHD).FirstOrDefault().TRIGIA = thanhtien;

            return context.SaveChanges();
        }
        public List<hoadon> laydanhsachhoadon(int makh)
        {
            List<hoadon> list = new List<hoadon>();
           
            list = (from hd in context.hoadons
                    where hd.MAKH == makh 
                    select hd).ToList();
            return list;
        }
        public hoadon HoaDonGanNhatCuaKH(int makh)
        {
            hoadon list = new hoadon();
            list = (from hd in context.hoadons
                    where hd.MAKH == makh 
                    orderby hd.SOHD descending
                    select hd).ToList().FirstOrDefault();
            return list;
        }
        public List<cthd> LayCTHD(int mahd)
        {
            List<cthd> list = new List<cthd>();
            list = (from hd in context.cthds
                    where hd.SOHD == mahd
                    select hd).ToList();
            return list;
        }
    }
}