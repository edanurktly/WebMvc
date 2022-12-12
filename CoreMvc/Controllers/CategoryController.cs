using CoreMvc.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public IActionResult Create()
        {
            var category = new CoreMvc.Entities.Category();
            return View(category);
        }

        [HttpPost]
        public IActionResult Create(CoreMvc.Entities.Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            context.Categories.Add(category);

            int sonuc = context.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var category = context.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(CoreMvc.Entities.Category? category)
        {

            if (!ModelState.IsValid)
            {
                return View(category);

            }
            context.Categories.Update(category);
            int sonuc = context.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Category");
            }
            return View(category);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(CoreMvc.Entities.Category? category)
        {


            context.Categories.Remove(category);
            int sonuc = context.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("Index", "category");
            }
            return View(category);
        }

        public IActionResult GetOrderDetails(int id)
        {
            var result = context.OrderDetails
                        .Include(p => p.Product)
                        .ThenInclude(p => p.Category)
                        .Where(p => p.OrderId == id)
                        .ToList();


            return View(result);
        }



    }
}
