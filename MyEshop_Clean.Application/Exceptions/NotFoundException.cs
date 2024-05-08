using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEshop_Clean.Domain;

namespace MyEshop_Clean.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message,object key)
        :base($"{message} {key} was not found")
        {
            
        }
    }
}
