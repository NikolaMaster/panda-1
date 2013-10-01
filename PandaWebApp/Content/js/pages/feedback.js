function initFeedbackCreate() {
    var recalcStars = function() {
        var red = $('.user .rating_editor img[checked=checked].red_stars').length;
        var green = $('.user .rating_editor img[checked=checked].green_stars').length;
        var orange = $('.user .rating_editor img[checked=checked].orange_stars').length;
        $('#Rating').val(red + 10 * green + 100 * orange);
    };
    $('.user .rating_editor img').hover(function () {
        var isRed = $(this).hasClass('red_stars');
        var isOrange = $(this).hasClass('orange_stars');
        var isGreen = $(this).hasClass('green_stars');

        if (isRed) {
            $(this).attr('src', '/Content/img/light_red_star.png');
        }
        else if (isOrange) {
            $(this).attr('src', '/Content/img/light_orange_star.png');
        }
        else if (isGreen) {
            $(this).attr('src', '/Content/img/light_green_star.png');
        }
        
        $(this).prevAll('.red_stars').attr('src', '/Content/img/light_red_star.png');
        $(this).prevAll('.orange_stars').attr('src', '/Content/img/light_orange_star.png');
        $(this).prevAll('.green_stars').attr('src', '/Content/img/light_green_star.png');
    },
    function () {
        $(this).parent().find('img[checked!=checked]').attr('src', '/Content/img/light_gray_star.png');
    });
    $('.user .rating_editor img').click(function() {
        $(this).attr('checked', 'true');
        $(this).prevAll().attr('checked', 'true');
        $(this).nextAll().removeAttr('checked');
        $(this).nextAll().attr('src', '/Content/img/light_gray_star.png');
        recalcStars();
    });
}