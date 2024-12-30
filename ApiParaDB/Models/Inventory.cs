using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace testebasic2swagger.Models
{
    [Table("inventory", Schema = "public")]
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("machine_id")]
        public required long Machine_Id { get; set; }

        [Required]
        [Column("product_id")]
        public required long Product_id { get; set; }

        [Required]
        [Column("quantity")]
        public required int Quantity { get; set; }
    }
}
