using FashionShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionShop.Models.Dao
{
    public class SaleDao
    {
        QlbhDbContext qlbhContext = null;

        public SaleDao()
        {
            qlbhContext = new QlbhDbContext();
        }
        public int phantramKM(int makm)
        {
            var list = (from km in qlbhContext.khuyenmais
                        where km.MAKM == makm
                        select km).FirstOrDefault();
            int phantramkm = list.PHANTRAMKM;
            return phantramkm;
        }
    }
}