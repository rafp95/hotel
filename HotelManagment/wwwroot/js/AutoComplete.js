(function ($) {

    let setupAutoComplete = function () {
        let input = $("#searchQuery");

        let options = {
            source: input.attr("data-autocomplete-source"),
            select: function (event, ui) {
                input.val(ui.item.id);
            },
            appendTo: '.sugestion'
        };

        input.autocomplete(options);
    };

    setupAutoComplete();
})(jQuery);