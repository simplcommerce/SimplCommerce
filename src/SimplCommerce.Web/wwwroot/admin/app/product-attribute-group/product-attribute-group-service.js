/*global angular*/
(function () {
    angular
        .module('shopAdmin.productAttributeGroup')
        .factory('productAttributeGroupService', productAttributeGroupService);

    /* @ngInject */
    function productAttributeGroupService($http) {
        var service = {
            getProductAttributeGroup: getProductAttributeGroup,
            createProductAttributeGroup: createProductAttributeGroup,
            editProductAttributeGroup: editProductAttributeGroup,
            deleteProductAttributeGroup: deleteProductAttributeGroup,
            getProductAttributeGroups: getProductAttributeGroups
        };
        return service;

        function getProductAttributeGroup(id) {
            return $http.get('Admin/ProductAttributeGroup/Get/' + id);
        }

        function getProductAttributeGroups() {
            return $http.get('Admin/ProductAttributeGroup/List');
        }

        function createProductAttributeGroup(productAttributeGroup) {
            return $http.post('Admin/ProductAttributeGroup/Create', productAttributeGroup);
        }

        function editProductAttributeGroup(productAttributeGroup) {
            return $http.post('Admin/ProductAttributeGroup/Edit/' + productAttributeGroup.id, productAttributeGroup);
        }

        function deleteProductAttributeGroup(productAttributeGroup) {
            return $http.post('Admin/ProductAttributeGroup/Delete/' + productAttributeGroup.id, null);
        }
    }
})();