//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StockManagement.DAL.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Purchase
    {
        public int ID { get; set; }
        public Nullable<int> VNo { get; set; }
        public Nullable<System.DateTime> VDate { get; set; }
        public string CustType { get; set; }
        public string LCode { get; set; }
        public Nullable<decimal> GrossWt { get; set; }
        public Nullable<decimal> NetWt { get; set; }
        public Nullable<decimal> MakingTotal { get; set; }
        public Nullable<decimal> MetalTotal { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> SGST { get; set; }
        public Nullable<decimal> CGST { get; set; }
        public Nullable<decimal> NetTotal { get; set; }
        public string Remarks { get; set; }
    }
}
