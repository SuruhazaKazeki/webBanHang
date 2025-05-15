using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebBanHang.Models;

namespace webBanHang.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _db;
        private IWebHostEnvironment _hosting;

        public ProductController(ApplicationDbContext db, IWebHostEnvironment host)
        {
            _db = db;
            _hosting = host;
        }
        public IActionResult Index()
        {
            var dsSanPham = _db.Products.Include(x => x.Category).ToList();
            return View(dsSanPham);
        }
        [HttpGet]
        public IActionResult add()
        {
            ViewBag.TL = _db.Categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
            return View();
        }
        [HttpPost]
        public IActionResult add(Product p, IFormFile ImageUrl)
        {
            if (ModelState.IsValid)
            {
                if (ImageUrl != null)
                {
                    //xử lý upload ảnh sản phẩm
                    p.ImageUrl = SaveImage(ImageUrl);
                }
                // thêm vào csdl
                _db.Products.Add(p);
                _db.SaveChanges();
                TempData["success"] = "Thêm 1 SP thành công!";
                //ĐIều hường về action index
                return RedirectToAction("index");

            }
            ViewBag.TL = _db.Categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
            return View();
        }

            public IActionResult update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult update(Product q)
        {
            return View();
        }
        public IActionResult delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult delete (Product q)
        {
            return View();
        }
        private string SaveImage(IFormFile image)
        {
            //đặt lại tên file cần lưu
            var filename = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            //lay duong dan luu tru wwwroot tren server
            var path = Path.Combine(_hosting.WebRootPath, @"images/products");
            var saveFile = Path.Combine(path, filename);
            using (var filestream = new FileStream(saveFile, FileMode.Create))
            {
                image.CopyTo(filestream);
            }
            return @"images/products/" + filename;
        }
    }
}
