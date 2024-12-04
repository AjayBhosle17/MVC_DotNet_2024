using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _10_Code_First_Approch.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Category_Name",TypeName ="varchar")]
        [StringLength(20)]
        public string Name { get; set; }
        public int? Rating { get; set; }
    }
}