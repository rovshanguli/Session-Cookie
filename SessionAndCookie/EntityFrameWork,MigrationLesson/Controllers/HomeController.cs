using EntityFrameWork_MigrationLesson.Data;
using EntityFrameWork_MigrationLesson.Models;
using EntityFrameWork_MigrationLesson.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameWork_MigrationLesson.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            //HttpContext.Session.SetString("name", "Esger");
            //Response.Cookies.Append("surname", "Asgerov", new CookieOptions { MaxAge = TimeSpan.FromDays(5) });
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            SliderDetail detail = await _context.SliderDetails.FirstOrDefaultAsync();
            List<Catagory> catagories = await _context.Catagories.ToListAsync();
            List<Product> products = await _context.Products
                .Include(m=>m.Catagory)
                .Include(m=>m.Images)
                .OrderByDescending(m=>m.Id)
                .Take(8)
                .ToListAsync();
            HomeAbout about = await _context.HomeAbouts.FirstOrDefaultAsync();
            List<Expert> experts = await _context.Experts.ToListAsync();
            List<Blog> blogs = await _context.Blogs.ToListAsync();
            List<Instagram> instagrams = await _context.Instagrams.ToListAsync();

            HomeVM homeVM = new HomeVM
            {
                Sliders = sliders,
                Detail = detail,
                Catagories = catagories,
                Products = products,
                About = about,
                Experts = experts,
                Blogs = blogs,
                Instagrams = instagrams
            };
            return View(homeVM);
        }

        public IActionResult Test()
        {
            
            var cookie =Request.Cookies["basket"];
            return Json(cookie);
        }
    }
}
