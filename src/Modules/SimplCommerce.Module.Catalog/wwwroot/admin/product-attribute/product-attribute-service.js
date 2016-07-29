/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .factory('productAttributeService', productAttributeService);

    /* @ngInject */
    function productAttributeService($http) {
        var service = {
            getProductAttribute: getProductAttribute,
            createProductAttribute: createProductAttribute,
            editProductAttribute: editProductAttribute,
            deleteProductAttribute: deleteProductAttribute,
            getProductAttributes: getProductAttributes
        };
        return service;

        function getProductAttribute(id) {
            return $http.get('api/product-attributes/' + id);
        }

        function getProductAttributes() {
            return $http.get('api/product-attributes');
        }

        function createProductAttribute(productAttribute) {
            return $http.post('api/product-attributes', productAttribute);
        }

        function editProductAttribute(productAttribute) {
            return $http.put('api/product-attributes/' + productAttribute.id, productAttribute);
        }

        function deleteProductAttribute(productAttribute) {
            return $http.delete('api/product-attributes/' + productAttribute.id, null);
        }
    }
})();