(function ($) {
    $(window).load(function () {
        function createUrl() {
            var newUrl,
                params = '',
                baseUrl = window.location.href.split('?')[0];

            if (currentSearchOption.brands.length > 0) {
                params = params + 'brand=' + currentSearchOption.brands.join('--');
            }
            if (params !== '') {
                newUrl = baseUrl + '?' + params;
            } else {
                newUrl = baseUrl;
            }

            return newUrl;
        }

        $('#collapse-brand input:checkbox').on('change', function () {
            var index,
                checkbox = $(this),
                brand = checkbox.val();
            if (checkbox.prop("checked") === true) {
                currentSearchOption.brands.push(brand);
            } else {
                index = currentSearchOption.brands.indexOf(brand);
                currentSearchOption.brands.splice(index, 1);
            }

            window.location = createUrl();
        });
    });
})(jQuery);