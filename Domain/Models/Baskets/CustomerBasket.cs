using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Baskets
{
    public class CustomerBasket
    {
        public string Id { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; } = [];
    }
}
