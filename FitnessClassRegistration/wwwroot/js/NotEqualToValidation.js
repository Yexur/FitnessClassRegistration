$(function ()
{
    jQuery.validator.addMethod("notequalto", function (value, element, params) {
        if (!this.optional(element)) {
            var otherProp = $(params[0]).val();
            return (otherProp != value);
        }
        return true;
    });
    jQuery.validator.unobtrusive.adapters.addSingleVal("notequalto", "otherpropertynotequal", "notequalto");
}(jQuery));