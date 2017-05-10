using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FitnessClassRegistration.CustomValidation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class TimeSpanIsAfterAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "{0} cannot be before than {1}";

        public string OtherTime { get; }

        public TimeSpanIsAfterAttribute(string otherTime) : base(DefaultErrorMessage)
        {
            if (string.IsNullOrEmpty(otherTime))
            {
                throw new ArgumentNullException("otherTime");
            }
            OtherTime = otherTime;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, OtherTime);
        }

        protected override ValidationResult IsValid(
            object value, 
            ValidationContext validationContext
        )
        {
            if (value != null)
            {
                var otherTime =
                    validationContext.ObjectInstance.GetType().GetProperty(OtherTime);

                var otherTimeValue =
                    otherTime.GetValue(validationContext.ObjectInstance, null);

                if (TimeSpan.Parse(value.ToString()).CompareTo(TimeSpan.Parse(otherTimeValue.ToString())) < 0)
                {
                    return new ValidationResult(
                        FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return ValidationResult.Success;
        }
    }
}
