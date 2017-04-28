using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FitnessClassRegistration.CustomValidation
{
    public class GreaterThan : ValidationAttribute//, IClientModelValidator
    {
        private const string DefaultErrorMessage = "{0} cannot be less than {1}";
        public string OtherProperty { get; private set; }

        public GreaterThan(string otherProperty) : base(DefaultErrorMessage)
        {
            if (string.IsNullOrEmpty(otherProperty))
            {
                throw new ArgumentNullException("otherProperty");
            }
            OtherProperty = otherProperty;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, OtherProperty);
        }

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext
        )
        {
            if (value != null)
            {
                var otherProperty =
                    validationContext.ObjectInstance.GetType().GetProperty(OtherProperty);

                var otherPropertyValue =
                    otherProperty.GetValue(validationContext.ObjectInstance, null);

                if (Int32.Parse(value.ToString()).CompareTo(Int32.Parse(otherPropertyValue.ToString())) > 0)
                {
                    return new ValidationResult(
                        FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return ValidationResult.Success;
        }

        //public void AddValidation(ClientModelValidationContext context)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
