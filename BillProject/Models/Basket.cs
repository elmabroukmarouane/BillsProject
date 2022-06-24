using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillProject.Models
{
    public class Basket
    {
        public IList<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}
