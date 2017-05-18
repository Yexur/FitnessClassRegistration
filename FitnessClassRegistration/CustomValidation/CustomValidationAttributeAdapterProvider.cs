using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations.Internal;
using Microsoft.Extensions.Localization;

namespace FitnessClassRegistration.CustomValidation
{
    public class CustomValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {

        IValidationAttributeAdapterProvider baseProvider = 
            new ValidationAttributeAdapterProvider();

        public IAttributeAdapter GetAttributeAdapter(
            ValidationAttribute attribute, 
            IStringLocalizer stringLocalizer
        )
        {
            if (attribute is NotEqualToAttribute)
            {
                return new NotEqualToAttributeAdapter(
                    attribute as NotEqualToAttribute, 
                    stringLocalizer
                );
            }

            if (attribute is TimeSpanIsAfterAttribute)
            {
                return new TimeSpanIsAfterAttributeAdapter(
                    attribute as TimeSpanIsAfterAttribute,
                    stringLocalizer
                );
            }

            if (attribute is GreaterThanAttribute)
            {
                return new GreaterThanAttributeAdapter(
                    attribute as GreaterThanAttribute,
                    stringLocalizer
                );
            }

            return baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
