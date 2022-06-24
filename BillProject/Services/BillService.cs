using BillProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillProject.Services
{
    public class BillService : IBillService
    {
        public double? GetBill(Basket basket)
        {
            // Test pour basket null
            if(basket != null)
            {
                // Test pour BasketItems null
                if (basket.BasketItems != null)
                {
                    // cast total on double
                    var total = 0d;
                    foreach (var bsi in basket.BasketItems)
                    {
                        if (bsi != null)
                        {
                            // Test Item is null
                            total += (bsi.Item != null ? bsi.Item.Price : 0) * bsi.Quantity;
                        }
                    }
                    return total;
                }
            }
            return null;
        }
    }
}
