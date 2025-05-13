using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class BrandNotFoundException(int id)
        : Exception($"Brand with id : {id} not found");
}
