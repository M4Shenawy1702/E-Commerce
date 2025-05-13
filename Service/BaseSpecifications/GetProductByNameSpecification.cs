using Domain.Models.Product;
using Service.Specifications;
using System;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Service.BaseSpecifications
{
    internal class GetProductByNameSpecification : BaseSpecifications<Product>
    {
        public GetProductByNameSpecification(string productName)
            : base(p => p.Name.ToLower().Trim() == productName.ToLower().Trim())
        {
        }
    }
}
