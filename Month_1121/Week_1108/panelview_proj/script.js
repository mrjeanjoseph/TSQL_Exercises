
        $(document).ready(function () {
            //To remove add and remove the active class within the tabs

            $('.tab-panels .tabs li').on('click', function () {
                var $panel = $(this).closest('.tab-panels');

                $panel.find('.tabs li.active').removeClass('active');
                $(this).addClass('active');

                //figure out which panel to show
                var panelToShow = $(this).attr('rel');

                $panel.find('.panel.active').slideUp(100, showNextPanel);

                function showNextPanel() {
                    $(this).removeClass('active');

                    $('#' + panelToShow).slideDown(100, function () {
                        $(this).addClass('active');
                    });
                }
            });
        });