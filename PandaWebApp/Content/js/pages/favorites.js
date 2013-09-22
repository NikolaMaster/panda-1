function favoritesAction(action, id) {
    var url = '/Favorite/' + action;
    if (id) {
        url += '/' + id;
    }
    $.ajax({
        type: 'POST',
        url: url,
        dataType: 'json',
        error: function () {
            //alert('Что то пошло не так, обратитесь к администратору!');
        },
        statusCode: {
            401: function() {
                $('#loginButton').click();
            }
        },
        success: function (data) {
            if (!data.NextStep) {
                alert(data.Text);
            } else {
                if (confirm(data.Text)) {
                    favoritesAction(data.NextStep, data.NextStepArg);
                }
            }
            //console.log(data.Code);
        }
    });
}

function addToFavorite(userId) {
    favoritesAction('AddToFavorite', userId);
}

function removeFromFavorite(userId) {
    favoritesAction('DeleteFromFavorite', userId);
}

function reloadFavoritesContent() {
    $.ajax({
        type: 'GET',
        url: '/Favorite/_UserIndex',
        success: function(data) {
            $('.favorites').html(data);
        }
    });
}