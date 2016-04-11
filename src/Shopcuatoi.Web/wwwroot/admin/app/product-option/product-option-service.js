/*global angular*/
(function () {
    angular
        .module('shopAdmin.productOption')
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
            return $http.get('Admin/ProductOption/Get/' + id);
        }

        function getProductOptions() {
            return $http.get('Admin/ProductOption/List');
        }

        function createProductOption(productOption) {
            return $http.post('Admin/ProductOption/Create', productOption);
        }

        function editProductOption(productOption) {
            return $http.post('Admin/ProductOption/Edit/' + productOption.id, productOption);
        }

        function deleteProductOption(productOption) {
            return $http.post('Admin/ProductOption/Delete/' + productOption.id, null);
        }
    }
})();