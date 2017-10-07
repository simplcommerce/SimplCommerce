/*global angular, confirm*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .controller('ProductAttributeGroupListCtrl', ProductAttributeGroupListCtrl);

    /* @ngInject */
    function ProductAttributeGroupListCtrl(productAttributeGroupService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.productAttributeGroups = [];

        vm.getProductAttributeGroups = function getProductAttributeGroups() {
            productAttributeGroupService.getProductAttributeGroups().then(function (result) {
                vm.productAttributeGroups = result.data;
            });
        };

        vm.deleteProductAttributeGroup = function deleteProductAttributeGroup(productAttributeGroup) {
            if (confirm("Are you sure?")) {
                productAttributeGroupService.deleteProductAttributeGroup(productAttributeGroup)
                    .then(function (result) {
                        vm.getProductAttributeGroups();
                    });
            }
        };

        vm.getProductAttributeGroups();
    }
})();