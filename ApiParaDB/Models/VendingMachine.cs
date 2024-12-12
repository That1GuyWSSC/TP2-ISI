using System.ComponentModel.DataAnnotations;

namespace ApiParaDB.Models
{
    // Vending Machine Model
    public class VendingMachine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Location { get; set; }

        public string Description { get; set; }
    }
}
