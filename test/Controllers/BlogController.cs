using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.ViewModels;
using test.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            int count = await _context.Blogs.CountAsync();
            ViewBag.count = count;
            return View(await _context.Blogs.Where(m => !m.SoftDeleted).ToListAsync());
        }


        [HttpGet]
        public async Task<IActionResult> ShowMore(int skip)
        {
            List<Blog> blogs = await _context.Blogs.Skip(skip).Take(3).ToListAsync();
            
            return PartialView("_BlogsPartial", blogs);
        }
        
    }
}

