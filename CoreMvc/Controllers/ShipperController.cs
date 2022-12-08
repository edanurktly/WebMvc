using CoreMvc.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvc.Controllers
{
    public class ShipperController : Controller
    {
        private readonly NorthwindContext context;

        public ShipperController(NorthwindContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {

            var result = context.Shippers.ToList();
            return View(result);
        }

        public IActionResult ShipperorOrders()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var shipper = new Shipper();
            return View(shipper);
        }

        [HttpPost]
        public IActionResult Create(Shipper shipper)
        {
            if (!ModelState.IsValid)
            {
                return View(shipper);
            }

            context.Shippers.Add(shipper);

            int sonuc = context.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("Index");
            }
            return View(shipper);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var shipper = context.Shippers.Find(id);
            return View(shipper);
        }

        [HttpPost]
        public IActionResult Update(Shipper? shipper)
        {

            if (!ModelState.IsValid)
            {
                return View(shipper);

            }
            context.Shippers.Update(shipper);
            int sonuc = context.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Shipper");
            }
            return View(shipper);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var shipper = context.Shippers.Find(id);
            return View(shipper);
        }
        [HttpPost]
        public IActionResult Delete(Shipper? shipper)
        {


            context.Shippers.Remove(shipper);
            int sonuc = context.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Shipper");
            }
            return View(shipper);
        }

    }
}
