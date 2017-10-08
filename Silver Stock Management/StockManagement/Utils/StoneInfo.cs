using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Utils
{
    class StoneInfo
    {
        public StoneInfo()
        { 
        }

        public StoneInfo(string detail,double value)
        {
            desc = detail;
            weight = value;
        }

        public StoneInfo(string detail, double value,double rate,double amt)
        {
            desc = detail;
            weight = value;
            srate = rate;
            samount = amt;
        }

        private string desc;

        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }
        private double weight;

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private double srate;

        public double Srate
        {
            get { return srate; }
            set { srate = value; }
        }

        private double samount;

        public double Samount
        {
            get { return samount; }
            set { samount = value; }
        }
    }
}
