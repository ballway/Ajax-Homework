using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prjMSIT133Web_Core_.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace prjMSIT133Web_Core_.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;

        public ApiController(DemoContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;   //取得路徑用
        }


        //public IActionResult Index(string name, string age)
        public IActionResult Index(User user)
        {
            string name = user.name;
            string age = user.age;
            //return Content("<h2>Hello Ajax</h2>", "text/plain");  //content type "text/plain"
            //return Content("<h2>Hello Ajax</h2>", "text/html");  //content type "text/html"

            if (string.IsNullOrEmpty(name))
            {
                name = "Ajax";
            }

            if (string.IsNullOrEmpty(age))
            {
                age = "25";
            }

            //return Content($"Hello {name}, you are {age} years old.", "text/plain");
            return Content($"Hello {name}, you are {age} years old.", "text/plain", System.Text.Encoding.UTF8);  //避免中文亂碼
        }



        //==========================================================
        //作業用
        public IActionResult CheckName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Content("不能輸入空值喔!", "text/plain", System.Text.Encoding.UTF8);
            }
            Member mem = _context.Members.FirstOrDefault(m => m.Name == name);
            if (mem != null)
            {
                return Content("此名稱已經存在", "text/plain", System.Text.Encoding.UTF8);
            }
            return Content("資料庫裡沒有這個名稱，可以註冊~", "text/plain", System.Text.Encoding.UTF8);
        }
        //==========================================================

        public IActionResult Register(Member member, IFormFile photo)
        {
            //string info = $"{photo.FileName} - {photo.Length} - {photo.ContentType}";
            //string info = $"{_host.WebRootPath} - {_host.ContentRootPath}";

            //C:\Users\User\Desktop\Restful_API\codes\slnMSIT133Web(Core)\prjMSIT133Web(Core)\wwwroot
            //C:\Users\User\Desktop\Restful_API\codes\slnMSIT133Web(Core)\prjMSIT133Web(Core)

            //結合 {根目錄路徑} + {上傳檔案用的資料夾} + {上傳檔案名稱}
            string uploadFolder = Path.Combine(_host.WebRootPath, "uploads", photo.FileName);
            //將檔案儲存到uploads資料夾
            using (var fileStream = new FileStream(uploadFolder,FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }

            //將圖檔轉成二進位 memoryStream
            byte[] imgByte = null;
            using(MemoryStream stream = new MemoryStream())
            {
                photo.CopyTo(stream);
                imgByte= stream.ToArray();
            }

            //寫進資料庫
            member.FileName = photo.FileName;
            member.FileData = imgByte;

            _context.Members.Add(member);
            _context.SaveChanges();

            string info = uploadFolder;

            return Content(info, "text/plain", System.Text.Encoding.UTF8);  //避免中文亂碼
            //return Content($"Hello {user.name}, you are {user.age} years old. 電子郵件: {user.email}", "text/plain", System.Text.Encoding.UTF8);  //避免中文亂碼
        }

        public IActionResult City()
        {
            var cities = _context.Addresses.Select(c => new { c.City }).Distinct().OrderBy(c => c.City);
            return Json(cities);
        }
    }
}
