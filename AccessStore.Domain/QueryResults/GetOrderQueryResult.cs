using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessStore.Domain.QueryResults
{
    public class GetOrderQueryResult
    {
        public string Number { get; set; }
        public decimal Discount { get; set; }
        public decimal DeliveryFee { get; set; }
        public DateTime CreateDate { get; set; }
        public string Customer { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
    }
}
