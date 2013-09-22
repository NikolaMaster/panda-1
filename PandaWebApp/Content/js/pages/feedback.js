function initFeedbackCreate() {
    var recalcStars = function() {
        var red = $('.user .rating_editor .red_stars img[checked=checked]').length;
        var green = $('.user .rating_editor .green_stars img[checked=checked]').length;
        var orange = $('.user .rating_editor .orange_stars img[checked=checked]').length;
        $('#Rating').val(red + 10 * green + 100 * orange);
    };
    $('.user .rating_editor img').hover(function () {
        var picture_class = $(this).parent().attr('class');
        switch (picture_class) {
            case 'red_stars':
                $(this).attr('src', '/Content/img/light_red_star.png');
                $(this).prevAll().attr('src', '/Content/img/light_red_star.png');
                break;
            case 'orange_stars':
                $(this).attr('src', '/Content/img/light_orange_star.png');
                $(this).prevAll().attr('src', '/Content/img/light_orange_star.png');
                break;
            case 'green_stars':
                $(this).attr('src', '/Content/img/light_green_star.png');
                $(this).prevAll().attr('src', '/Content/img/light_green_star.png');
                break;
        }
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