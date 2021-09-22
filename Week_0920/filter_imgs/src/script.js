
$(function() {
    var $filter = $('.filter');
    var $tab = $('.filter a');
    var $offers = $('.boxGroup .box');

    $filter.on('click touch', '.all', function(e) {
        e.preventDefault();
        $tab.removeClass('current');
        $(this).addClass('current');

        $offers.hide();
        $offers.fadeIn( 700 );
    });

    $filter.on('click touch', '.one', function(e) {
        e.preventDefault();
        $tab.removeClass('current');
        $(this).addClass('current');

        $offers.show();
        $offers.fadeOut();
        $offers.filter('.one').fadeIn( 400 );
    });

    $filter.on('click touch', '.two', function(e) {
        e.preventDefault();
        $tab.removeClass('current');
        $(this).addClass('current');

        $offers.show();
        $offers.fadeOut();
        $offers.filter('.two').fadeIn( 400 );
    });

    $filter.on('click touch', '.three', function(e) {
        e.preventDefault();
        $tab.removeClass('current');
        $(this).addClass('current');

        $offers.show();
        $offers.fadeOut();
        $offers.filter('.three').fadeIn( 400 );
    });
})