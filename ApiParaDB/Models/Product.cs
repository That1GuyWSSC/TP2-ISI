using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testebasic2swagger.Models
{
    [Table("category", Schema = "public")]

    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("name")]
        [StringLength(50)]
        public required string Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Required]
        [Column("price")]
        public double Price { get; set; }

        [Required]
        [Column("category_id")]
        public required long Category_Id { get; set; }

        [Required]
        [Column("is_active")]
        public required bool Is_Active { get; set; }
    }
}
