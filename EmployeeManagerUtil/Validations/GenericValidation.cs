using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EmployeeManagerUtil.Validations
{
    public class GenericValidation
    {
        public static void StringIsNullOrEmpty(string stringValue, string message)
        {
            if (string.IsNullOrEmpty(stringValue)) throw new ArgumentNullException(message + ": " + stringValue);
        }
    }
}