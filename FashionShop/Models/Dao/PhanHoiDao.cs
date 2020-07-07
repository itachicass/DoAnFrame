using FashionShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionShop.Models.Dao
{
    public class PhanHoiDao
    {
        QlbhDbContext context = new QlbhDbContext();
        public phanhoi LayPHTheoId(int maph)
        {
            phanhoi ph = new phanhoi();
            ph = (from p in context.phanhois
                  where p.MAPH == maph
                  select p).ToList().FirstOrDefault();
            return ph;
        }
        public List<phanhoi> LayPHTheoSP(int masp)
        {
            List<phanhoi> ph = new List<phanhoi>();
            ph = (from p in context.phanhois
                  where p.MASP == masp
                  orderby p.MAPH descending
                  select p).ToList();
            return ph;
        }
        public void XoaPH(int maph)
        {
            phanhoi ph = new phanhoi();
            ph = LayPHTheoId(maph);
            context.phanhois.Remove(ph);
            context.SaveChanges();
        }
        public void ThemPH(int makh, int masp, string noidung)
        {
            phanhoi ph = new phanhoi();
            ph.MAKH = makh;
            ph.MASP = masp;
            ph.NOIDUNG = noidung;
            ph.THOIGIANPH = DateTime.Now.Date;
            context.phanhois.Add(ph);
            context.SaveChanges();
            
        }
    }
}