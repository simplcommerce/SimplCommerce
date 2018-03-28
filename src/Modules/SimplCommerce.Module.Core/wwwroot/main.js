/*global jQuery, window*/
$(function () {
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

        $('.product-list .card').matchHeight({
            byRow: true,
            property: 'height',
            target: null,
            remove: false
        });

        $('input.rating-loading').rating({
            language: window.simplGlobalSetting.lang,
            filledStar: '<i class="fa fa-star"></i>',
            emptyStar: '<i class="fa fa-star-o"></i>'
        });
});