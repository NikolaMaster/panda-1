function favoritesAction(action, id) {
    $.ajax({
        type: 'POST',
        url: '/Favorite/' + action + '/' + id,
        error: function() {
        },
        success: function (data) {
            alert(data);
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