using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace restWithASPNET10Study.Model
{
    [Table("books")]
    public class Books
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [Column("title", TypeName = "varchar(MAX)")]
        [MaxLength]
        public string title { get; set; }
        [Required]
        [Column("author", TypeName = "varchar(MAX)")]
        [MaxLength(80)]
        public string author { get; set; }
        [Required]
        [Column("address", TypeName = "varchar(100)")]
        public Double Price { get; set; }
        [Required]
        [Column("gender", TypeName = "varchar(6)")]
        [MaxLength(6)]
        public string Gender { get; set; }
    }
}
