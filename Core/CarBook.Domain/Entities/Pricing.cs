using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Pricing : IEntity
    {
        public string Name { get; set; }
        public List<CarPricing> CarPricings { get; set; }
    }
}
