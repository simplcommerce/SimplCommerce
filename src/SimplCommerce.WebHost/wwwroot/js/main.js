/*global jQuery, window*/
(function ($) {
    $(window).load(function () {
        $('.lang-selector li').on('click', function (e) {
            var lang = $(this).find('a').attr('data-value'),
                $langForm = $('#lang-form'),
                $cultureInput = $langForm.find('input[name=culture]');

            if ($cultureInput.val() === lang) {
                e.preventDefault();
                return;
            }
            else {
                $cultureInput.val(lang);
                $langForm.submit();
            }
        });

        $('.product-list .thumbnail').matchHeight({
            byRow: true,
            property: 'height',
            target: null,
            remove: false
        });
    });
})(jQuery);