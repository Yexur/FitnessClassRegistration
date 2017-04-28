using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FitnessClassRegistration.CustomValidation
{
    public class NotEqualTo : ValidationAttribute //, IClientModelValidator
    {
        private const string DefaultErrorMessage = "{0} cannot be the same as {1}.";

        public string OtherProperty { get; private set; }

        public NotEqualTo(string otherProperty) : base(DefaultErrorMessage)
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

                if (value.Equals(otherPropertyValue))
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
