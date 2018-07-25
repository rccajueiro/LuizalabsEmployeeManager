using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerCommon.Validations
{
    public class GenericValidation
    {
        public static void StringIsNullOrEmpty(string stringValue, string message)
        {
            if (string.IsNullOrEmpty(stringValue)) throw new ArgumentNullException(message + ": " + stringValue);
        }

        public static void ObjectIsNull(object objectValue, string message)
        {
            if (objectValue == null) throw new ArgumentNullException(message + ": null");
        }
    }
}
