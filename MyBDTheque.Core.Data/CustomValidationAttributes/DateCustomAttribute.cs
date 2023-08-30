using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBDTheque.Core.Data.CustomValidationAttributes
{
    public class DateCustomAttribute : ValidationAttribute
    {
        public string Minimum { get; set; }
        public string Maximum { get; set; }


        public override bool IsValid(object value)
        {
            DateTime dateValue;
            DateTime min = DateTime.Parse(Minimum);
            DateTime max;
            if (Maximum != "")
            {
                max = DateTime.Parse(Maximum);
            }
            else
            {
                max = DateTime.Now;
            }

            if (DateTime.TryParse(value.ToString(),out dateValue))
            {
                ErrorMessage = "La date de naissance doit être comprise entre le premier janvier 1900 et la date du jour.";
                return dateValue >= min && dateValue <= max;
                
            }

            ErrorMessage = "La date saisie n'est pas une date valide.";
            return false;
        }
    }
}
