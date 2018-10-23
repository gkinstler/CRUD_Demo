using System;
using System.Collections.Generic;
using System.Text;

namespace Oct15sandbox
{
    public class Products
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public object CategoryID { get; internal set; }
        public object ProductID { get; internal set; }
    }
}
