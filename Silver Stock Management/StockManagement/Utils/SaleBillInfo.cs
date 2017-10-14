using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Utils
{
    public class SaleBillInfo
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        DateTime vDate;

        public DateTime VDate
        {
            get { return vDate; }
            set { vDate = value; }
        }
        int vno;

        public int Vno
        {
            get { return vno; }
            set { vno = value; }
        }
        int cid;

        public int Cid
        {
            get { return cid; }
            set { cid = value; }
        }
        double grossAmt;

        public double GrossAmt
        {
            get { return grossAmt; }
            set { grossAmt = value; }
        }
        double vatRate;

        public double VatRate
        {
            get { return vatRate; }
            set { vatRate = value; }
        }
        double vatAmt;

        public double VatAmt
        {
            get { return vatAmt; }
            set { vatAmt = value; }
        }
        double roundOff;

        public double RoundOff
        {
            get { return roundOff; }
            set { roundOff = value; }
        }
        double totalAmt;

        public double TotalAmt
        {
            get { return totalAmt; }
            set { totalAmt = value; }
        }
        string pancard;

        public string Pancard
        {
            get { return pancard; }
            set { pancard = value; }
        }

    }
}
