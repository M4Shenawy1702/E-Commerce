using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidPictureSizeException()
        :Exception("Picture size must be less than 2MB")
    {
    }
}
