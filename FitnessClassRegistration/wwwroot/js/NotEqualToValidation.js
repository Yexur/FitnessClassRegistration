$(function ()
{
    jQuery.validator.addMethod("notequalto", function (value, element, params) {
        if (!this.optional(element)) {
            var otherProp = $('#' + params)
            return (otherProp.val() != value);
        }
        return true;
    });
    jQuery.validator.unobtrusive.adapters.addSingleVal("notequalto", "otherpropertynotequal");
}(jQuery));