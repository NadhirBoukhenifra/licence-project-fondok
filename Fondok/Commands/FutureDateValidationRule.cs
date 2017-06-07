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

            return time.Date > DateTime.Now.AddYears(-1) && time.Date < DateTime.Now.AddYears(1) && time.Date < DateTime.Now
                ? new ValidationResult(false, "Enter valide date between:" + DateTime.Now.AddYears(-1).ToString() +
                " and "+ DateTime.Now.AddYears(1).ToString())
                : ValidationResult.ValidResult;
        }
    }
}
