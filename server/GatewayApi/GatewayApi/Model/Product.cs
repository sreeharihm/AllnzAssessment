using GatewayApi.Background.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayApi.Model
{
    public class Product
    {
  
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public double PriceWithReduction { get; set; }
    }
}
