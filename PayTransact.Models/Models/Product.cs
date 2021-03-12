using System;
using System.Collections.Generic;
using System.Text;

namespace PayTransact.Models.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}
