using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }

        public IActionResult Index()
        {
            List<Item> items = _context.Items.ToList();
            return View(items);
        }

        [HttpGet]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == Id);
            if (item != null)
            {
                _context.Items.Remove(item);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
