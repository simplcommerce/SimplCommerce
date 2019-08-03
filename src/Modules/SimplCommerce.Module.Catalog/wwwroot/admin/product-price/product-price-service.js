/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .factory('productPriceService', ['$http', productPriceService]);

    function productPriceService($http) {
        var service = {
            getProducts: getProducts,
            updateProductPrices: updateProductPrices
        };
        return service;

        function getProducts(params) {
            return $http.post('api/product-prices/grid', params);
        }

        function updateProductPrices(products) {
            return $http.put('api/product-prices', products);
        }
    }
})();
