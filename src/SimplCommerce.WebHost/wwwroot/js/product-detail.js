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

            $variationPrice = $form.find('input[name=' + variationNames.join('-') + 'Price]');
            if ($variationPrice.length > 0) {
                $('.product-price h3').text($variationPrice.val());
                $('.btn-add-cart').prop('disabled', false);
            } else {
                $('.product-price h3').text("Not available");
                $('.btn-add-cart').prop('disabled', true);
            }
        });

        $('.quantity-button').on('click', function () {
            var quantityInput = $('.quantity-field');
            if ($(this).val() === '+')
            {
                quantityInput.val(parseInt(quantityInput.val(), 10) + 1);
            }
            else if (quantityInput.val() > 1) {
                quantityInput.val(quantityInput.val() - 1);
            }
        });
    });
})(jQuery);