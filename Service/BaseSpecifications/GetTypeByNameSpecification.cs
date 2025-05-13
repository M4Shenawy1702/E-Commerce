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
    internal class GetTypeByNameSpecification : BaseSpecifications<ProductType>
    {
        public GetTypeByNameSpecification(string typeName)
            : base(type => type.Name.ToLower().Trim() == typeName.ToLower().Trim())
        {
        }
    }
}
