using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Exceptions
{
    public class CustomerrNotFoundException:ApplicationException
    {
        public CustomerrNotFoundException()
        {
            
        }
        public CustomerrNotFoundException(string msg):base(msg)
        {
            
        }
    }
}
