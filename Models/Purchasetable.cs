//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SaraPabson.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Purchasetable
    {
        public int Sn { get; set; }
        public Nullable<System.DateTime> DateField { get; set; }
        public string PurchaseHeading { get; set; }
        public string PurchaseCode { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Total { get; set; }
        public string Narration { get; set; }
        public Nullable<decimal> newstock { get; set; }
        public Nullable<decimal> PreAmount { get; set; }
        public Nullable<decimal> NewAmount { get; set; }
    }
}
