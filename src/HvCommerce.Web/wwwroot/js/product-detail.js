(function () {
    $(window).load(function () {
        $('.sp-wrap').smoothproducts();

        $('.product-attrs li').on('click', function () {
            jQuery(this).find('input').prop('checked', true);
        });
    });
})();