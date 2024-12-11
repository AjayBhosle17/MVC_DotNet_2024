using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _12_MetaData_WithDatabaseFirstApproch.Models
{
    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category
    {
        public string Passoword { get; set; }
    }

    public class CategoryMetaData {

        [Required(ErrorMessage ="Plz Enter Category Name")]
        [StringLength(20,MinimumLength =5,ErrorMessage ="Category name should br grter than 5 and less than 20")]
        public string Category_Name { get; set; }

        [Required(ErrorMessage ="Plz Enter Rating")]
        [Range(1,10,ErrorMessage ="Plz Enter Rating between 1 to 10")]
        public int Rating { get; set; }
    }
}