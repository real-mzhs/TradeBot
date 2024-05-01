using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models;
    public class Order
    {
        public string Symbol { get; set; }
        public long OrderId { get; set; }
        public long OrderListId { get; set; }
        public string ClientOrderId { get; set; }
        public long TransactTime { get; set; }
        public decimal Price { get; set; }
        public decimal OrigQty { get; set; }
        public decimal ExecutedQty { get; set; }
        public decimal CumulativeQuoteQty { get; set; }
        public string Status { get; set; }
        public string TimeInForce { get; set; }
        public string Type { get; set; }
        public string Side { get; set; }
        public long WorkingTime { get; set; }
        public string SelfTradePreventionMode { get; set; }
    }

