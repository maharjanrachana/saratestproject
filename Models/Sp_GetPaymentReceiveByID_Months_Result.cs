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
    
    public partial class Sp_GetPaymentReceiveByID_Months_Result
    {
        public string Studentid { get; set; }
        public Nullable<System.DateTime> Datevalue { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> DuePayment { get; set; }
        public Nullable<decimal> BalanceDue { get; set; }
        public string SelectMonths { get; set; }
        public int TranNo { get; set; }
    }
}
