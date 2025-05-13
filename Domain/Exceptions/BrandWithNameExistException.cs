using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class BrandWithNameExistException(string name)
        : Exception($"Brand with name : {name} already exist")
    {
    }
}
