using CoreMvc.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly NorthwindContext context;
        public CategoryController(NorthwindContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Categories.ToList();
            return View(result);
        }
        public IActionResult CategoryorProducts()
        {


            return View();
        }
    }
}
