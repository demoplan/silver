using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Utils
{
    public class ItemInfo 
    {
        private string itemCode;

        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }
        private int pcs;

        public int Pcs
        {
            get { return pcs; }
            set { pcs = value; }
        }
        private double grossWeight;

        public double GrossWeight
        {
            get { return grossWeight; }
            set { grossWeight = value; }
        }
        private double netWeight;

        public double NetWeight
        {
            get { return netWeight; }
            set { netWeight = value; }
        }
        private List<StoneInfo> diamondList;

        internal List<StoneInfo> DiamondList
        {
            get { return diamondList; }
            set { diamondList = value; }
        }
        private List<StoneInfo> stoneList;

        internal List<StoneInfo> StoneList
        {
            get { return stoneList; }
            set { stoneList = value; }
        }

        private int tagNo;

        public int TagNo
        {
            get { return tagNo; }
            set { tagNo = value; }
        }

        private DateTime saleDate;

        public DateTime SaleDate
        {
            get { return saleDate; }
            set { saleDate = value; }
        }

        private int tid;

        public int Tid
        {
            get { return tid; }
            set { tid = value; }
        }

    }
}
