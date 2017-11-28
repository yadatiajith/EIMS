$(function () {
    $(".dropdown").hover(
            function () {
                $('.dropdown-menu', this).stop(true, true).show();
                $(this).toggleClass('open');
                $('b', this).toggleClass("caret caret-up");
            },
            function () {
                $('.dropdown-menu', this).stop(true, true).hide();
                $(this).toggleClass('open');
                $('b', this).toggleClass("caret caret-up");
            });
});
