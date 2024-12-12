using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiParaDB.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("VendingMachine")]
        public int MachineId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; } = 0;

        public VendingMachine VendingMachine { get; set; }

        public Product Product { get; set; }
    }
}
