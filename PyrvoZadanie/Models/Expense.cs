using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PyrvoZadanie.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Expense Name")]
        public string ExpenseName { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number!")]
        public double Amount { get; set; }
        public int ExpenseTypeId { get; set; }
        [ForeignKey("ExpenseTypeId")]
        public virtual ExpenseType ExpenseType { get; set; }
    }
}
