﻿using Microsoft.AspNetCore.Mvc;
using PyrvoZadanie.Data;
using PyrvoZadanie.Models;

namespace PyrvoZadanie.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> items = _db.Items;

            return View(items);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _db.Items.Find(id);
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Item item)
        {
            _db.Update(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var item = _db.Items.Find(id);
            _db.Items.Remove(item);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
