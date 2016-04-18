/*global jQuery, window, currentSearchOption*/
(function ($, currentSearchOption) {
    $(window).load(function () {
        function createUrl() {
            var key,
                value,
                newUrl,
                params = [],
                baseUrl = window.location.href.split('?')[0];

            for (key in currentSearchOption) {
                if (currentSearchOption.hasOwnProperty(key) && currentSearchOption[key]) {
                    value = $.isArray(currentSearchOption[key]) ? currentSearchOption[key].join('--') : currentSearchOption[key];
                    params.push(key + '=' + value);
                }
            }

            if (params.length > 0) {
                newUrl = baseUrl + '?' + params.join('&');
            } else {
                newUrl = baseUrl;
            }

            return newUrl;
        }

        $('#collapse-brand input:checkbox').on('change', function () {
            var index,
                checkbox = $(this),
                brand = checkbox.val(),
                brands = currentSearchOption.brand ? currentSearchOption.brand.split('--') :[];
            if (checkbox.prop("checked") === true) {
                brands.push(brand);
            } else {
                index = brands.indexOf(brand);
                brands.splice(index, 1);
            }
            currentSearchOption.brand = brands.join('--');

            window.location = createUrl();
        });

        $('.sort-by select').on('change', function () {
            currentSearchOption.sortBy = $(this).val();
            window.location = createUrl();
        });
    });
})(jQuery, currentSearchOption);