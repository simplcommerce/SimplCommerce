/*global angular*/
(function () {
    angular
        .module('shopAdmin.productTemplate')
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
            return $http.get('Admin/ProductTemplate/Get/' + id);
        }

        function getProductTemplates() {
            return $http.get('Admin/ProductTemplate/List');
        }

        function createProductTemplate(productTemplate) {
            return $http.post('Admin/ProductTemplate/Create', productTemplate);
        }

        function editProductTemplate(productTemplate) {
            return $http.post('Admin/ProductTemplate/Edit/' + productTemplate.id, productTemplate);
        }

        function deleteProductTemplate(productTemplate) {
            return $http.post('Admin/ProductTemplate/Delete/' + productTemplate.id, null);
        }
    }
})();