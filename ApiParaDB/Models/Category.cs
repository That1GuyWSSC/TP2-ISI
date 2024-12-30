namespace testebasic2swagger.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

        [Table("category", Schema = "public")]
        public class Category
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
        }
    }


