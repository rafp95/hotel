// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {

    //$("#fromDate").shieldDateTimePicker({
    //    openOnFocus: false,
    //    showButton: true,
    //    editable: true,
    //    messages: { calendarIconTooltip: "open" },
    //    value: new Date(1900, 1, 1, 12, 0)
    //});

    //let dateFormat = "dd.mm.yy",
    //    from = $("#fromDate")
    //        .datepicker({
    //            defaultDate: "+1w",
    //            changeMonth: true,
    //            numberOfMonths: 2,
    //            defaultDate: new Date(),
    //            dateFormat: "dd.mm.yy",
    //        })
    //        .on("change", function () {
    //            to.datepicker("option", "minDate", getDate(this));
    //        }),
    //    to = $("#toDate").datepicker({
    //        defaultDate: "+1w",
    //        changeMonth: true,
    //        numberOfMonths: 2,
    //        dateFormat: "dd.mm.yy",
    //        defaultDate: new Date(),
    //    })
    //        .on("change", function () {
    //            from.datepicker("option", "maxDate", getDate(this));
    //        });

    //function getDate(element) {
    //    var date;
    //    try {
    //        date = $.datepicker.parseDate(dateFormat, element.value);
    //    } catch (error) {
    //        date = null;
    //    }

    //    return date;
    //}
    $('#fromDate,#toDate')
        .datetimepicker({
            format: 'd.m.y H:i',
        });
    $.datetimepicker.setLocale('pl');

    $('div.main-loader').fadeOut('slow');
    $("alert").fadeIn();

    $('#searchInput').on('keyup', function () {
        let val = $(this).val().toLowerCase();
        $('tbody tr').filter(function () {
            console.log($(this).text());
            $(this).toggle($(this).text().toLowerCase().indexOf(val) > -1);
            $('div.main-loader').fadeIn(30).fadeOut(30);
        });
        return false;
    });

    $("div.alert>a.close").off('click').on('click', function () {
        $(this).parent().fadeOut('slow');
        return false;
    });

});