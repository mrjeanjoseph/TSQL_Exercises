'use strict';

$(document).ready(function () {
    //setInterval
    //animate margin-left
    var width = 720,
        speed = 1000,
        pause = 3000,
        currentSlide = 1;
    var interval;

    //cache the DOM
    var $slider = $('#slider'),
        $slideContainer = $slider.find('.slides'),
        $slides = $slideContainer.find('.slide');

    function startSlider() {
        interval = setInterval(function () {
            $slideContainer.animate({ 'margin-left': '-=' + width }, speed,
                function () {
                    //if it's last slide, go to position 1 (0px);
                    //listen for mouseenter and pause
                    currentSlide++;
                    if (currentSlide === $slides.length) {
                        currentSlide = 1;
                        $slideContainer.css('margin-left', 0);
                    }
                });
        }, pause);
    }

    //start slider
    function stopSlider(){
        clearInterval(interval);
    }

    //resume on mouseleave
    $slider.on('mouseenter', stopSlider).on('mouseleave', startSlider);
    startSlider();

});