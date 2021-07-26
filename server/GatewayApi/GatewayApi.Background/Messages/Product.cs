using System;
using System.Collections.Generic;
using System.Text;

namespace GatewayApi.Background.Messages
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public double PriceWithReduction { get; set; }
    }
}
