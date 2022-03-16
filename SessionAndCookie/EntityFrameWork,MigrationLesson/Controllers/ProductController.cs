using EntityFrameWork_MigrationLesson.Data;
using EntityFrameWork_MigrationLesson.Models;
using EntityFrameWork_MigrationLesson.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameWork_MigrationLesson.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public  ProductController(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
        List<Product> products = await _context.Products.Where(m => m.IsDeleted == false)
                .Include(m => m.Catagory)
                .Include(m => m.Images)
                .OrderByDescending(m => m.Id)
                .Take(8)
                .ToListAsync();
        return View(products);
        }


        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id is null) return NotFound();
            Product dbproduct = await _context.Products.FindAsync(id);
            if (dbproduct is null) return BadRequest();

            List<BasketVM> basket;

            if(Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            else
            {
                basket = new List<BasketVM>();
            }

            var existProduct = basket.Find(m => m.Id == dbproduct.Id);
            if(existProduct == null){
                basket.Add(new BasketVM
                {
                    Id = dbproduct.Id,
                    Count = 1
                });
            }
            else
            {
                existProduct.Count++;
            }

          

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
            return RedirectToAction("Index","Home");
        }
        public IActionResult Test()
        {
            return Json(JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]));
        }
    }
}
