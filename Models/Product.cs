//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Product
    {
        public Product()
        {
            Images = "/Content/images/addimg.png";
        }
        public class NullReferenceException : SystemException { };
        public int IDProduct { get; set; }
        public string NameProduct { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public Nullable<decimal> UnitPrice { get; set; }
        public string Images { get; set; }
        public Nullable<System.DateTime> ProductDate { get; set; }
        public string Available { get; set; }
        public Nullable<int> IDCategory { get; set; }
        public string Descriptions { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}