using Microsoft.AspNetCore.Mvc.DataAnnotations.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;

namespace FitnessClassRegistration.CustomValidation
{
    public class NotEqualToAttributeAdapter : AttributeAdapterBase<NotEqualToAttribute>
    {
        public NotEqualToAttributeAdapter(
            NotEqualToAttribute attribute, 
            IStringLocalizer stringLocalizer
        ) : base(attribute, stringLocalizer)
        {
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-notequalto", GetErrorMessage(context));
            MergeAttribute(
                context.Attributes, 
                "data-val-notequalto-otherproperty", 
                Attribute.OtherProperty
            );
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return GetErrorMessage(
                validationContext.ModelMetadata, 
                validationContext.ModelMetadata.GetDisplayName()
            );
        }
    }
}
