function initReselect() {
    $('select').each(function(index, item) {
        reselect($(item));
    });
}

function reselect(select, addclass) {

    addclass = typeof (addclass) != 'undefined' ? addclass : '';

    $(select).wrap('<div class="sel_wrap ' + addclass + '"/>');

    var sel_options = '';
    $(select).children('option').each(function () {
        sel_options = sel_options + '<div class="sel_option" value="' + $(this).val() + '">' + $(this).html() + '</div>';

    });

    var sel_imul = '<div class="sel_imul">\
                <div class="sel_selected">\
                    <div class="selected-text">' + $(select).children('option').first().html() + '</div>\
                    <div class="sel_arraw"></div>\
                </div>\
                <div class="sel_options">' + sel_options + '</div>\
            </div>';

    $(select).before(sel_imul);
    var $newSelect = $(select).prev();
    $newSelect.bind('click', function () {

        $('.sel_imul').removeClass('act');
        $(this).addClass('act');

        if ($(this).children('.sel_options').is(':visible')) {

            $('.sel_options').hide();

        }
        else {

            $('.sel_options').hide();
            $(this).children('.sel_options').show();

        }

    });

    $newSelect.find('.sel_option').bind('click', function () {

        //меняем значение на выбранное
        var tektext = $(this).html();
        $(this).parent('.sel_options').parent('.sel_imul').children('.sel_selected').children('.selected-text').html(tektext);

        //активируем текущий
        $(this).parent('.sel_options').children('.sel_option').removeClass('sel_ed');
        $(this).addClass('sel_ed');

        //устанавливаем значение для селекта
        var tekval = $(this).attr('value');
        tekval = typeof (tekval) != 'undefined' ? tekval : tektext;
        $(this).parent('.sel_options').parent('.sel_imul').parent('.sel_wrap').children('select').children('option').removeAttr('selected').each(function () {
            if ($(this).val() == tekval) {
                $(this).attr('selected', 'select');
            }
        });
    });

    var selenter = false;
    $newSelect.bind('mouseenter', function () {
        selenter = true;
    });
    $newSelect.bind('mouseleave', function () {
        selenter = false;
    });
    $(document).click(function () {
        if (!selenter) {
            $newSelect.find('.sel_options').hide();
            $newSelect.removeClass('act');
        }
    });
}
