// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    /*fade between page*/
    (function ($) {
        $("div.container").hide().fadeIn('slow');
    })(jQuery);
    /*----*/

    tableOnSmallScreen();
    $(window).resize(function () {
        tableOnSmallScreen();
    });
    dateTimePickerSettings();
    mainSettings($);
    tableFilter();

});

function mainSettings() {

    /*loader*/
    $('div.main-loader').fadeOut('slow');
    $("alert").fadeIn();
    $("div.alert>a.close").off('click').on('click', function () {
        $(this).parent().fadeOut('slow');
        return false;
    });
    /*---*/
}

function dateTimePickerSettings() {
    $('#fromDate,#toDate')
        .datetimepicker({
            format: 'd.m.y H:i',
        });
    $.datetimepicker.setLocale('pl');
}

function tableOnSmallScreen() {

    let thead = $('thead>tr>th');
    let tbody = $('tbody>tr');

    if (thead.length > 0 && tbody.length > 0) {
        $('div.main-loader').fadeIn();
        $('.table').hide().fadeIn(() => {
            $('div.main-loader').fadeOut('slow');
        });

        if ($(this).width() <= 1200) {
            showHideDetailsTd(tbody, thead);
        } else {
            showHideDetailsTd(tbody, thead);
        }
    }

}


function showHideDetailsTd(tbody, thead) {
    for (let i = 0; i < tbody.length; i++) {
        let td = tbody.eq(i).children('td');
        for (let j = 0; j < td.length; j++) {
            this.console.log(td.length);
            let pom = td.eq(j).find('span');
            if (!pom.hasClass('content') && $(window).width() <= 1200) {
                td.eq(j).prepend(`
                    <span class="content">
                      <b> ${thead.eq(j).text().length > 0 ? thead.eq(j).text() + ':' : ''}  </b>
                    </span>`);
            } else {
                if (pom.hasClass('content') && $(window).width() > 1200) {
                    pom.remove('span.content');
                }
            }
        }
    }
}

function tableFilter() {
    $('#searchInput').on('keyup', function () {
        let val = $(this).val().toLowerCase();
        clearInputSearch(val);
        filter(val, 'tbody tr');
        return false;
    });

    function filter(val, nameElement) {
        $(nameElement).filter(function () {
            console.log($(this).text());
            let isElement = $(this).text().toLowerCase().indexOf(val) > -1;
            if (!isElement) {
                $(this).fadeOut();
            }
            else {
                $(this).fadeIn();
            }
            $('div.main-loader').fadeIn(30).fadeOut(30);
        });
    }
}

function clearInputSearch(val) {
    let remove = $("div>i.fa");
    if (val.length > 0) {
        remove.css({ 'display': 'flex' });
        remove.off('click').on('click', function (e) {
            e.preventDefault();
            $('#searchInput').val('');
            remove.css({ 'display': 'none' });
            $('tbody tr').fadeIn();
        });
    }
    else {
        remove.css({ 'display': 'none' });
    }
}
