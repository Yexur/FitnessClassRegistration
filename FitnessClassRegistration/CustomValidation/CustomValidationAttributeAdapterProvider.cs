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
            return (attribute is NotEqualToAttribute) ? 
                new NotEqualToAttributeAdapter(attribute as NotEqualToAttribute, stringLocalizer) : 
                baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
