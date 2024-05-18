using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;
using test.ViewModels;

namespace test.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }


    public async Task<IActionResult>Index()
    {
        List<Slider> sliders = await _context.Sliders.ToListAsync();
        SliderInfo sliderInfo = await _context.SlidersInfo.FirstOrDefaultAsync();
        List<Category> categories = await _context.Categories.Include(m=>m.Products).Where(m => !m.SoftDeleted && m.Products.Count !=0).ToListAsync();
        List<Product> products = await _context.Products.Include(m => m.ProductImages).ToListAsync();
        Surprise surprise = await _context.Surprises.FirstOrDefaultAsync();
        List<SurpriseBulletPoints> surpriseBulletPoints = await  _context.SurpriseBulletPoints.ToListAsync();
        ExpertPanel expertPanel = await _context.ExpertPanel.FirstOrDefaultAsync();
        List<Expert> experts = await _context.Experts.ToListAsync();
        List<Blog> blogs = await _context.Blogs.Where(m=>!m.SoftDeleted).ToListAsync();

        HomeVM model = new()
        {
            Sliders = sliders,
            SliderInfo = sliderInfo,
            Categories = categories,
            Products = products,
            Surprise = surprise,
            SurpriseBulletPoints = surpriseBulletPoints,
            ExpertPanel = expertPanel,
            Experts = experts,
            Blogs = blogs

        };

        return View(model);
    }

}



