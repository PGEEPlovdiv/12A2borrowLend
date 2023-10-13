using PyrvoZadanie.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PyrvoZadanie.ViewModels
{
    public class ExpenseViewModel
    {
        public Expense Expense { get; set; }
        public IEnumerable<SelectListItem> TypeDropDown { get; set; }
    }
}
