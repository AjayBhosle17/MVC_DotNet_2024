using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _10_Code_First_Approch.Models.Entity
{
    [Table("Product")]
    public class Product
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [Required]
        [Column(TypeName ="varchar")]
        [StringLength(10)]
        public string Name { get; set; }

        public int Price { get; set; }

        [NotMapped]  // it is not create column in databse
        public string Description { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }  // navigation Property
    }
}