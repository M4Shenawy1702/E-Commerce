using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class TypeNotFoundException(int id)
        : Exception($"Type with id : {id} not found");
    
}
