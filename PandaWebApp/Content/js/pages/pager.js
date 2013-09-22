function initPager($parent) {
    var currentPage = function () {
        return parseInt($parent.find('#Pager_Page').val());
    }

    var setPage = function (pg) {
        $parent.find('#Pager_Page').val(pg);
    }

    var setPagePost = function (pg) {
        setPage(pg);
        $parent.find('form').trigger('submit');
    }
    
    $parent.find('[rel=pager_prev]').bind('click', function () { setPagePost(currentPage() - 1); return false; });
    $parent.find('[rel=pager_next]').bind('click', function () { setPagePost(currentPage() + 1); return false; });
    $parent.find('.pager-link').bind('click', function () { setPagePost(parseInt($(this).html())); return false; });
}