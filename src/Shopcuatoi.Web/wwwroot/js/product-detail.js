/*global jQuery, window*/
(function ($) {
    $(window).load(function () {
        $('.sp-wrap').smoothproducts();

        $('.product-attrs li').on('click', function () {
            var $variationPrice,
                variationNames = [],
                $form = $(this).closest("form"),
                $attrOptions = $form.find('.product-attr-options');

            $(this).find('input').prop('checked', true);

            $attrOptions.each(function () {
                variationNames.push($(this).find('input[type=radio]:checked').val());
            });

            $variationPrice = $form.find('input[name=' + variationNames.join('-') + ']');

            $('.product-price h3').text($variationPrice.val() || "Not available");
        });
    });
})(jQuery);