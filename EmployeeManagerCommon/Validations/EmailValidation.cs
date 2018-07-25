using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerCommon.Validations
{
    public class EmailValidation
    {
        public const string EXCEPTION_MESSAGE_EMAIL_IS_NOT_VALID = "E-mail is not valid";

        public static void IsValid(string emailValue)
        {
            if (!string.IsNullOrEmpty(emailValue))
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(emailValue);
                }
                catch
                {
                    throw new ArgumentException(EXCEPTION_MESSAGE_EMAIL_IS_NOT_VALID);
                }
            }
        }
    }
}
