using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Drawing;

namespace StockManagement.DAL.Model
{
    public class ReceiptModel
    {
        // Stock Info        
        public int TID { get; set; }

        
        public int SeqNo { get; set; }

        
        public Nullable<System.DateTime> TDate { get; set; }

        
        public string PCode { get; set; }

        
        public string BarCode { get; set; }

        
        public string MetalType { get; set; }

        
        public string InType { get; set; }

        
        public Nullable<int> RefVNo { get; set; }

        
        public Nullable<int> JobNo { get; set; }

        
        public Nullable<int> OrderNo { get; set; }

        
        public Nullable<decimal> Pcs { get; set; }

        
        public Nullable<decimal> GrossWt { get; set; }

        
        public Nullable<decimal> NetWt { get; set; }

        
        public Nullable<decimal> MakingRate { get; set; }

        
        public Nullable<decimal> TotalRate { get; set; }

        
        public Nullable<decimal> SellingRate { get; set; }

        
        public string Photo { get; set; }

        public Image ProdImage {
            //get {
            //    if (File.Exists(Photo))
            //    {
            //        return Image.FromFile(Photo);
            //    }
            //    else
            //        return null;
            //}
            //set
            //{
            //    ProdImage = value;
            //}
            get;set;
        }

        public Nullable<System.DateTime> OutDate { get; set; }
        public Nullable<int> OutBillNo { get; set; }
        public string OutType { get; set; }

        //InOut Info  
        public string StockInOut { get; set; }
    }
}
