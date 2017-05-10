using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FitnessClassRegistration.CustomValidation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NotEqualToAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "{0} cannot be the same as {1}.";

        public string OtherPropertyNotEqual { get; }

        public NotEqualToAttribute(string otherPropertyNotEqual) : base(DefaultErrorMessage)
        {
            if (string.IsNullOrEmpty(otherPropertyNotEqual))
            {
                throw new ArgumentNullException("otherProperty");
            }

            OtherPropertyNotEqual = otherPropertyNotEqual;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, OtherPropertyNotEqual);
        }

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext
        )
        {
            if (value != null)
            {
                var otherProperty =
                    validationContext.ObjectInstance.GetType().GetProperty(OtherPropertyNotEqual);

                var otherPropertyValue =
                    otherProperty.GetValue(validationContext.ObjectInstance, null);

                if (value.Equals(otherPropertyValue))
                {
                    return new ValidationResult(
                        FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return ValidationResult.Success;
        }
    }
}
