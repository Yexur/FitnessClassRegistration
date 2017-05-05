using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FitnessClassRegistration.CustomValidation
{
    public class DateIsAfter : ValidationAttribute //, IClientModelValidator
    {
        private const string DefaultErrorMessage = "{0} cannot be before than {1}";
        public string OtherDate { get; }

        public DateIsAfter(string otherDate) : base(DefaultErrorMessage)
        {
            if (string.IsNullOrEmpty(otherDate))
            {
                throw new ArgumentNullException("otherDate");
            }
            OtherDate = otherDate;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, OtherDate);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var otherDate =
                    validationContext.ObjectInstance.GetType().GetProperty(OtherDate);

                var otherDateValue =
                    otherDate.GetValue(validationContext.ObjectInstance, null);

                if (TimeSpan.Parse(value.ToString()).CompareTo(TimeSpan.Parse(otherDateValue.ToString())) < 0)
                {
                    return new ValidationResult(
                        FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return ValidationResult.Success;
        }
    }
}
