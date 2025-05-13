using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class TypeWithNameExistException(string typeName)
        : Exception($"Type with name : {typeName} already exist")
    {
    }
}
