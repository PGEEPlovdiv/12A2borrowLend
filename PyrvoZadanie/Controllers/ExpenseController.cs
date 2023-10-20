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
            return View(_db.Expenses);
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseViewModel expenseVM)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(expenseVM.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseVM);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var expense = _db.Expenses.Find(id);
            ExpenseViewModel viewModel = new ExpenseViewModel
            {
                Expense = expense,
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.ExpenseTypeName,
                    Value = i.Id.ToString()
                })
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(ExpenseViewModel expenseVm)
        {
            _db.Update(expenseVm.Expense);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _db.Expenses.Remove(_db.Expenses.Find(id));
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
