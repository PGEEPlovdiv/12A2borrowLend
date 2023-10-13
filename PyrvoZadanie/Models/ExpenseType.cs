using System.ComponentModel.DataAnnotations;

namespace PyrvoZadanie.Models
{
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Expense Type Name")]
        public string ExpenseTypeName { get; set; }
    }
}
