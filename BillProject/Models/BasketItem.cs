using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillProject.Models
{
    public class BasketItem
    {
        public int Quantity { get; set; }
        public Item Item { get; set; }
    }
}
