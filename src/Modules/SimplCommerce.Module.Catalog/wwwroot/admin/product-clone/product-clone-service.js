/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .factory('productCloneService', productCloneService);

    /* @ngInject */
    function productCloneService($http) {
        var service = {
            getProductName: getProductName,
            cloneProduct: cloneProduct
    };
        return service;

        function getProductName(productId) {
            return $http.get('api/product-clone/' + productId);
        }
        function cloneProduct(productClone) {
            return $http.post('api/product-clone', productClone);
        }

    }
})();
