using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PyrvoZadanie.Data;
using PyrvoZadanie.Models;
using PyrvoZadanie.ViewModels;

namespace PyrvoZadanie.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            ExpenseViewModel viewModel = new ExpenseViewModel 
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.ExpenseTypeName,
                    Value = i.Id.ToString()
                })
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(Expense expense)
        {
            _db.Expenses.Add(expense);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var expense = _db.Expenses.Find(id);

            return View(expense);
        }
        [HttpPost]
        public IActionResult Edit(Expense expense)
        {
            _db.Expenses.Update(expense);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _db.Expenses.Remove(_db.Expenses.Find(id));

            return RedirectToAction("Index");
        }
    }
}
