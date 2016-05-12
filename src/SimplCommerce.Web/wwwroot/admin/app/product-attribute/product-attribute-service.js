/*global angular*/
(function () {
    angular
        .module('shopAdmin.productAttribute')
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
            return $http.get('Admin/ProductAttribute/Get/' + id);
        }

        function getProductAttributes() {
            return $http.get('Admin/ProductAttribute/List');
        }

        function createProductAttribute(productAttribute) {
            return $http.post('Admin/ProductAttribute/Create', productAttribute);
        }

        function editProductAttribute(productAttribute) {
            return $http.post('Admin/ProductAttribute/Edit/' + productAttribute.id, productAttribute);
        }

        function deleteProductAttribute(productAttribute) {
            return $http.post('Admin/ProductAttribute/Delete/' + productAttribute.id, null);
        }
    }
})();