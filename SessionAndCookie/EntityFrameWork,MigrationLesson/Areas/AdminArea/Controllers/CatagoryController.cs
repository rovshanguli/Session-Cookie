using EntityFrameWork_MigrationLesson.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameWork_MigrationLesson.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CatagoryController : Controller
    {
        
        private readonly AppDbContext _context;
        public CatagoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _context.Catagories.Where(m => !m.IsDeleted).ToListAsync();
            return View(result);
        }

        public  IActionResult Detail(int id)
        {
            var catagory = _context.Catagories.FirstOrDefault(m => m.Id == id);
            return View(catagory);
        }
    }
}
