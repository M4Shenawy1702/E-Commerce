using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidPictureFormatException()
        : Exception("Invalid Picture Format , only jpg , jpeg and png are allowed");

}
