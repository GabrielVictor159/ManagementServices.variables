using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServices.variables
{
    public class ManagementServicesVariablesException : Exception
    {
        public ManagementServicesVariablesException(string businessMessage)
             : base(businessMessage)
        {
        }

    }
}
