using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiParaDB.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("VendingMachine")]
        public int MachineId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal TotalPrice { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public VendingMachine VendingMachine { get; set; }

        public Product Product { get; set; }
    }

}
