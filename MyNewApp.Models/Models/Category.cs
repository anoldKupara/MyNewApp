using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyNewApp.Models.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Income> Incomes { get; set; }   // navigation property
        public ICollection<Expense> Expenses { get; set; }   // navigation property
        [DisplayName("DisplayOrder")]
        [Range(1, int.MaxValue, ErrorMessage = "Display order for category must be greater than 0")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
