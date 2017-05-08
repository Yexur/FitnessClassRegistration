using Microsoft.AspNetCore.Mvc.DataAnnotations.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;

namespace FitnessClassRegistration.CustomValidation
{
    public class GreaterThanAttributeAdapter : AttributeAdapterBase<GreaterThanAttribute>
    {
        public GreaterThanAttributeAdapter(
            GreaterThanAttribute attribute, 
            IStringLocalizer stringLocalizer
        ) : base(attribute, stringLocalizer)
        {
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-greaterthan", GetErrorMessage(context));
            MergeAttribute(
                context.Attributes,
                "data-val-greaterthan-otherpropertygreaterthan",
                Attribute.OtherPropertyGreaterThan
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
