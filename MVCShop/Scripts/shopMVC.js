$(function () {

    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.atte("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-shopMVC-target"));
            $target.replaceWith(data);
        });

        return false;
    };

    var createAutocomplete = function () {
        var $input = $(this);
        var options = {
            source: $input.attr("data-shopMVC-autocomplete")
        };

        $input.autocomplete(options);

    };

    $("form[data-shopMVC-ajax='true']").submit(ajaxFormSubmit);
    $("form[data-shopMVC-autocomplete]").each(createAutocomplete);

});