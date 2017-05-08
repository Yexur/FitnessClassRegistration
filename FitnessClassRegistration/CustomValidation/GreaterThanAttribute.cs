using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FitnessClassRegistration.CustomValidation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GreaterThanAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "{0} cannot be less than {1}";

        public string OtherPropertyGreaterThan { get; }

        public GreaterThanAttribute(string otherPropertyGreaterThan) : base(DefaultErrorMessage)
        {
            if (string.IsNullOrEmpty(otherPropertyGreaterThan))
            {
                throw new ArgumentNullException("otherProperty");
            }
            OtherPropertyGreaterThan = otherPropertyGreaterThan;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, OtherPropertyGreaterThan);
        }

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext
        )
        {
            if (value != null)
            {
                var otherProperty =
                    validationContext.ObjectInstance.GetType().GetProperty(OtherPropertyGreaterThan);

                var otherPropertyValue =
                    otherProperty.GetValue(validationContext.ObjectInstance, null);

                if (Int32.Parse(value.ToString()).CompareTo(Int32.Parse(otherPropertyValue.ToString())) < 0)
                {
                    return new ValidationResult(
                        FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return ValidationResult.Success;
        }
    }
}
