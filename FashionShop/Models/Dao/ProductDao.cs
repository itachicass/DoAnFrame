using FashionShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionShop.Models.Dao
{
    public class ProductDao
    {
        QlbhDbContext qlbhContext = null;

        public ProductDao()
        {
            qlbhContext = new QlbhDbContext();
        }

        public List<sanpham> GetSanphamAll()
        {
            var query = from sp in qlbhContext.sanphams
                        select sp;
            return query.ToList();
        }
        public List<sanpham> Search(string text)          
        {
            List<sanpham> listsp = new List<sanpham>();
            if (!String.IsNullOrEmpty(text))
            {
                listsp = (from sp in qlbhContext.sanphams
                     where sp.TENSP.Contains(text) || sp.LOAISP.Contains(text) 
                     select sp).ToList();
            }
            else
            {
                listsp = (from sp in qlbhContext.sanphams
                          select sp).ToList();
            }        
            return listsp;

        }
        public List<sanpham> GetItemByGender(string gender)
        {
            var query = from sp in qlbhContext.sanphams
                        where sp.GIOITINH == gender
                        select sp;
            return query.ToList();
        }
        public List<sanpham> GetItemByGenderAndType(string gender, string type)
        {
            var query = from sp in qlbhContext.sanphams
                        where sp.GIOITINH == gender && sp.LOAISP.Contains(type)
                        select sp;
            return query.ToList();
        }

        public List<sanpham> GetItemByType(string type)
        {
            List<sanpham> list = new List<sanpham>();
            if (type == "quanao")
            {
                list = (from sp in qlbhContext.sanphams
                        where sp.LOAISP.Contains("ao") || sp.LOAISP.Contains("quan")
                        select sp).ToList();
            }
            if (type == "giay")
            {
                list= (from sp in qlbhContext.sanphams
                        where sp.LOAISP.Contains("giay") 
                        select sp).ToList();
            }
            if (type == "tui")
            {
                list = (from sp in qlbhContext.sanphams
                        where sp.LOAISP.Contains("tui")
                        select sp).ToList();
            }

            return list;
        }

        public List<sanpham> BestSeller()
        {
            var query = (from sp in qlbhContext.sanphams                                              
                         orderby sp.cthds.Count() descending
                         select sp).Take(9);
            return query.ToList();
        }
        public List<sanpham> NewProduct()
        {
            var query = (from sp in qlbhContext.sanphams
                         orderby sp.MASP descending
                         select sp).Take(9);
            return query.ToList();
        }
        public List<sanpham> GetItemByID(int ID)
        {
            var query = from sp in qlbhContext.sanphams
                        where sp.MASP == ID
                        select sp;
            return query.ToList();
        }
        public double GetPrice(int masp)
        {
            List<sanpham> item = (from sp in qlbhContext.sanphams
                       where sp.MASP == masp
                       select sp).ToList();
            double gia = item[0].GIA;
            return gia;
        }
    }
}