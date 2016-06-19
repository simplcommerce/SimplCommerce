/*global angular, confirm*/
(function () {
    angular
        .module('shopAdmin.productAttributeGroup')
        .controller('ProductAttributeGroupListCtrl', ProductAttributeGroupListCtrl);

    /* @ngInject */
    function ProductAttributeGroupListCtrl(productAttributeGroupService) {
        var vm = this;
        vm.productAttributeGroups = [];

        vm.getProductAttributeGroups = function getProductAttributeGroups() {
            productAttributeGroupService.getProductAttributeGroups().then(function (result) {
                vm.productAttributeGroups = result.data;
            });
        };

        vm.deleteProductAttributeGroup = function deleteProductAttributeGroup(productAttributeGroup) {
            if (confirm("Are you sure?")) {
                productAttributeGroupService.deleteProductAttributeGroup(productAttributeGroup)
                    .success(function (result) {
                        vm.getProductAttributeGroups();
                    });
            }
        };

        vm.getProductAttributeGroups();
    }
})();