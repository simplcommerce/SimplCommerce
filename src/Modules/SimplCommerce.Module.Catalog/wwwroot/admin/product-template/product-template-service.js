/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .factory('productTemplateService', productTemplateService);

    /* @ngInject */
    function productTemplateService($http) {
        var service = {
            getProductTemplate: getProductTemplate,
            createProductTemplate: createProductTemplate,
            editProductTemplate: editProductTemplate,
            deleteProductTemplate: deleteProductTemplate,
            getProductTemplates: getProductTemplates
        };
        return service;

        function getProductTemplate(id) {
            return $http.get('api/product-templates/' + id);
        }

        function getProductTemplates() {
            return $http.get('api/product-templates');
        }

        function createProductTemplate(productTemplate) {
            return $http.post('api/product-templates', productTemplate);
        }

        function editProductTemplate(productTemplate) {
            return $http.put('api/product-templates/' + productTemplate.id, productTemplate);
        }

        function deleteProductTemplate(productTemplate) {
            return $http.delete('api/product-templates/' + productTemplate.id, null);
        }
    }
})();