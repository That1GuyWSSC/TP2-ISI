using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiParaDB.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public string description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal price { get; set; }

        [ForeignKey("Category")]
        public int category_Id { get; set; }

        public bool is_active { get; set; } = true;

        public Category Category { get; set; }
    }

}
