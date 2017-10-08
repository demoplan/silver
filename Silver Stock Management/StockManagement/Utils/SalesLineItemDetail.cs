using System;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Utils
{
    public class SalesLineItemDetail
    {
        int tid;

        public int Tid
        {
            get { return tid; }
            set { tid = value; }
        }

        string itemDesc;

        public string ItemDesc
        {
            get { return itemDesc; }
            set { itemDesc = value; }
        }
        string metalType;

        public string MetalType
        {
            get { return metalType; }
            set { metalType = value; }
        }
        int tagNo;

        public int TagNo
        {
            get { return tagNo; }
            set { tagNo = value; }
        }
        int pcs;

        public int Pcs
        {
            get { return pcs; }
            set { pcs = value; }
        }
        double grossWeight;

        public double GrossWeight
        {
            get { return grossWeight; }
            set { grossWeight = value; }
        }
        double netWeight;

        public double NetWeight
        {
            get { return netWeight; }
            set { netWeight = value; }
        }
        double diamondWeight;

        public double DiamondWeight
        {
            get { return diamondWeight; }
            set { diamondWeight = value; }
        }
        double diamondValue;

        public double DiamondValue
        {
            get { return diamondValue; }
            set { diamondValue = value; }
        }
        double stoneWeight;

        public double StoneWeight
        {
            get { return stoneWeight; }
            set { stoneWeight = value; }
        }
        double stoneValue;

        public double StoneValue
        {
            get { return stoneValue; }
            set { stoneValue = value; }
        }
        double metalRate;

        public double MetalRate
        {
            get { return metalRate; }
            set { metalRate = value; }
        }
        double metalValue;

        public double MetalValue
        {
            get { return metalValue; }
            set { metalValue = value; }
        }
        string makingOn;

        public string MakingOn
        {
            get { return makingOn; }
            set { makingOn = value; }
        }
        double makingRate;

        public double MakingRate
        {
            get { return makingRate; }
            set { makingRate = value; }
        }
        double makingAmt;

        public double MakingAmt
        {
            get { return makingAmt; }
            set { makingAmt = value; }
        }
        string otheChgOn;

        public string OtheChgOn
        {
            get { return otheChgOn; }
            set { otheChgOn = value; }
        }
        double otheChgRate;

        public double OtheChgRate
        {
            get { return otheChgRate; }
            set { otheChgRate = value; }
        }
        double otheChgAmt;

        public double OtheChgAmt
        {
            get { return otheChgAmt; }
            set { otheChgAmt = value; }
        }
        double totalAmt;

        public double TotalAmt
        {
            get { return totalAmt; }
            set { totalAmt = value; }
        }

        string picPath;

        public string PicPath
        {
            get { return picPath; }
            set { picPath = value; }
        }


    }
}
