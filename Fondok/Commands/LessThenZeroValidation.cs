using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Fondok.Commands
{
    public class LessThenZeroValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int i;
            if (int.TryParse(value.ToString(), out i))
                return new ValidationResult(true, null);

            //return new ValidationResult(false, "Please enter a valid value > 0.");

            return i <= 0 
                ? new ValidationResult(false, "Enter valide > 0 between:")
                : ValidationResult.ValidResult;

            //DateTime time;

            //if (!DateTime.TryParse((value ?? "").ToString(),
            //    CultureInfo.CurrentCulture,
            //    DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
            //    out time)) return new ValidationResult(false, "Invalid date");

            //return time.Date >= DateTime.Now.Date.AddYears(-10) || time.Date <= DateTime.Now.Date.AddYears(-50)
            //    ? new ValidationResult(false, "Enter valide date between:" + DateTime.Now.Date.AddYears(-50).ToString() + " & " + DateTime.Now.Date.AddYears(-10).ToString())
            //    : ValidationResult.ValidResult;

        }
    }
}
