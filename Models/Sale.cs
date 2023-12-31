//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Sale
    {
        public int ID { get; set; }
        [DisplayName("Sale Product")]
        [Required(ErrorMessage = "Enter Sale Product..")]
        public string Sale_Prod { get; set; }
        [DisplayName("Sale Quantity")]
        [Required(ErrorMessage = "Enter Sale Quantity..")]
        public string Sale_Qnty { get; set; }
        [DisplayName("Sale Date")]
        [Required(ErrorMessage = "Enter Sale Date..")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime Sale_Date { get; set; }
    }
}
