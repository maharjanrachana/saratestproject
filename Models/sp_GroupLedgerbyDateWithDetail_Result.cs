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
    
    public partial class sp_GroupLedgerbyDateWithDetail_Result
    {
        public int TransNo { get; set; }
        public Nullable<System.DateTime> Datefield { get; set; }
        public string AccountCode { get; set; }
        public string AccountHeading { get; set; }
        public Nullable<decimal> PreAmount { get; set; }
        public Nullable<decimal> NewAmount { get; set; }
        public Nullable<decimal> BalanceAmount { get; set; }
        public string Remarks { get; set; }
        public string customer { get; set; }
        public Nullable<int> Sc_1 { get; set; }
        public Nullable<int> Sc_2 { get; set; }
    }
}
