/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .factory('productOptionService', productOptionService);

    /* @ngInject */
    function productOptionService($http) {
        var service = {
            getProductOption: getProductOption,
            createProductOption: createProductOption,
            editProductOption: editProductOption,
            deleteProductOption: deleteProductOption,
            getProductOptions: getProductOptions
        };
        return service;

        function getProductOption(id) {
            return $http.get('api/product-options/' + id);
        }

        function getProductOptions() {
            return $http.get('api/product-options');
        }

        function createProductOption(productOption) {
            return $http.post('api/product-options', productOption);
        }

        function editProductOption(productOption) {
            return $http.put('api/product-options/' + productOption.id, productOption);
        }

        function deleteProductOption(productOption) {
            return $http.delete('admin/product-options/' + productOption.id);
        }
    }
})();