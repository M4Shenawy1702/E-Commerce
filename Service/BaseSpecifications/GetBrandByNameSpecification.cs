using Domain.Models.Product;
using Service.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.BaseSpecifications
{
    public class GetBrandByNameSpecification : BaseSpecifications<ProductBrand>
    {
        public GetBrandByNameSpecification(string brandName)
            : base(b=>b.Name.ToLower().Trim() == brandName.ToLower().Trim())
        {
        }
    }
}
