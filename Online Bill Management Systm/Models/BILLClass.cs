using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Bill_Management_Systm.Models
{
    public class BILLClass
    {
        public int BILLID { get; set; }
        public string SHOPNAME { get; set; }
        public string ADDRESS { get; set; }
        public string DATE { get; set; }
        public Nullable<int> AMOUNT { get; set; }
        public string ITEM { get; set; }
    }
}