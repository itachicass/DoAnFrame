using FashionShop.Models.Dao;
using FashionShop.Models.EF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductDao productDao = new ProductDao();
            ViewData["listProduct"] = productDao.GetSanphamAll();
            
            return View();
        }

        [HttpGet]
        public ActionResult ProductByGender(string gender)
        {
            ProductDao productDao = new ProductDao();
            //List<sanpham> list = new List<sanpham>();
            //list = productDao.GetItemByGender(gender);
            ViewData["listgender"] = productDao.GetItemByGender(gender);
            return View();
            //return JsonConvert.SerializeObject(list);
        }
        [HttpGet]
        public ActionResult ProductByGenderAndType(string gender, string type)
        {
            ProductDao productDao = new ProductDao();
            ViewData["listgenderandtype"] = productDao.GetItemByGenderAndType(gender, type);
            return View();
        }
        [HttpGet]
        public ActionResult Product_Detail(int ID)
        {
            ProductDao productDao = new ProductDao();
            ViewData["detail"] = productDao.GetItemByID(ID);
            ViewData["listph"] = (new PhanHoiDao()).LayPHTheoSP(ID);
            return View();
        }

        [HttpGet]
        public ActionResult ProductByType(string type)
        {
            ProductDao productDao = new ProductDao();
            ViewData["listtype"] = productDao.GetItemByType(type);
            List<sanpham> list = new List<sanpham>();
            list = productDao.GetItemByType(type);
            
            return View();
        }


        [HttpPost]
        public ActionResult Search(string search)
        {
            ProductDao productDao = new ProductDao();
            ViewData["listProduct"] = productDao.Search(search);
            return View();
        }
        [HttpGet]
        public ActionResult Search()
        {
            
            return View();
        }
    }
}