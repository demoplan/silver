using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Utils
{
    class GroupInfo
    {
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
        int pcs;

        public int Pcs
        {
            get { return pcs; }
            set { pcs = value; }
        }
        double netwt;

        public double Netwt
        {
            get { return netwt; }
            set { netwt = value; }
        }
        double diamond;

        public double Diamond
        {
            get { return diamond; }
            set { diamond = value; }
        }

    }
}
