//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _9_Task_Bind_Fetch.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Nullable<int> SubCategoryId { get; set; }
    
        public virtual SubCategory SubCategory { get; set; }
    }
}