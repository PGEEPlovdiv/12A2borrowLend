using Microsoft.AspNetCore.Mvc;
using PyrvoZadanie.Data;
using PyrvoZadanie.Models;

namespace PyrvoZadanie.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.ExpenseTypes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ExpenseType expenseT)
        {
            _db.ExpenseTypes.Add(expenseT);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var expenseT = _db.ExpenseTypes.Find(id);

            return View(expenseT);
        }
        [HttpPost]
        public IActionResult Edit(ExpenseType expenseT)
        {
            _db.ExpenseTypes.Update(expenseT);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var removedExpenses = _db.Expenses.Where(x => x.ExpenseTypeId == id).ToList();
            foreach (var x in removedExpenses)
            {
                _db.Expenses.Remove(x);
            }

            _db.ExpenseTypes.Remove(_db.ExpenseTypes.Find(id));
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
