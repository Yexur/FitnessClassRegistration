﻿(function ($) {
    $.validator.addMethod("timespanisafter", function (value, element, params) {
        if (!this.optional(element)) {
            var otherProp = $('#' + params);
            return (otherProp.val() > value);
        }
        return true;
    });
    $.validator.unobtrusive.adapters.addSingleVal("timespanisafter", "othertime");
}(jQuery));