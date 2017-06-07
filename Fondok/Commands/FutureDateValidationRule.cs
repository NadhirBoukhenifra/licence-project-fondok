using System;
using System.Globalization;
using System.Windows.Controls;

namespace Fondok.Commands
{
    public class FutureDateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime time;

            if (!DateTime.TryParse((value ?? "").ToString(),
                CultureInfo.CurrentCulture,
                DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                out time)) return new ValidationResult(false, "Invalid date");

            /* return time.Date < DateTime.Now.AddYears(-1) && time.Date > DateTime.Now.AddYears(1) && time.Date < DateTime.Now*/
            return time.Date >= DateTime.Now.Date.AddYears(-10) || time.Date <= DateTime.Now.Date.AddYears(-50)
                ? new ValidationResult(false, "Enter valide date between:" + DateTime.Now.Date.AddYears(-50).ToString() + " & "+ DateTime.Now.Date.AddYears(-10).ToString())
                : ValidationResult.ValidResult;
        }
    }
}
