using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace testebasic2swagger.Models
{
    [Table("users", Schema = "public")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("username")]
        [StringLength(50)]
        public required string Username { get; set; }


        [Required]
        [Column("password")]
        [StringLength(50)]
        public required string Password { get; set; }

        [Required]
        [Column("role")]
        [StringLength(50)]
        public required string Role { get; set; }
    }
}
