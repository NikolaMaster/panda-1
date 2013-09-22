function updateUserInfo() {
    return $.ajax({
        url: '/UserInfo',
        dataType: 'json',
        error: function() {
        },
        success: function(data) {
            $('.header__offers-selected+span').html('(' + data.FavoritesCount + ')');
            $('.header__coins-count-number').html(data.Coins);
        }
    });
}

function updateFrom(urlToGet, control) {
    var $control = $(control);
    return $.ajax({
        url: urlToGet,
        error: function() {
        },
        success: function(data) {
            $control.html(data);
        }
    })
}

function initializeDateTime() {
    $(".datePicker").datepicker({ dateFormat: "dd.mm.yy" });
    $(".timePicker").timepicker();
}

$(function () {
    initializeDateTime();
    $('#registerForm').dialog({
        autoOpen: false,
        width: 'auto',
        height: 'auto',
        resizable: false,
        modal: true,
        position: { my: 'top', at: 'top', of: window }
    });

    $("#registerButton").click(function (e) {
        e.preventDefault();
        $("#registerForm").dialog("open");
        $("#registerForm").tabs({ active: 1 });
    });

    $("#loginButton").click(function (e) {
        e.preventDefault();
        $("#registerForm").dialog("open");
        $("#registerForm").tabs({ active: 0 });
    });

});