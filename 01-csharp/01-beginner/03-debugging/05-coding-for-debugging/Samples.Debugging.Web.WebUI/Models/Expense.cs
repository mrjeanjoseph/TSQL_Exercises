using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Samples.Debugging.Web.WebUI.Models
{
    // [DebuggerDisplay("ID:{ID}, Date:{DateIncurred.ToString(\"d\")}, Desc:{Description}, Type:{ExpenseType.Name}")]
    [DebuggerDisplay("{DebugDisplay, nq}")]
    public class Expense
    {
        public int ID { get; set; }
        public string Description { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime DateIncurred { get; set; }

        public string Location { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName="decimal(18,2)")]
        public double Price { get; set; }

        // Expense Type ID (foreign key)
        [Display(Name = "Expense Type")]
        public int ExpenseTypeID { get; set; }

        // Expense Type
        public ExpenseType ExpenseType { get; set; }

        // User ID
        public int UserID { get; set; }

        private string DebugDisplay
        {
            get
            {
                return string.Format("ID: {0}, Date: {1:d}, Desc:{2}, Type:{3}", ID, DateIncurred, Description, ExpenseType.Name);
            }
        }
    }
}
