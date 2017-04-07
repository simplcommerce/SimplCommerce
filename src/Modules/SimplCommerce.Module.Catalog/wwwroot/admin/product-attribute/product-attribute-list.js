/*global angular, confirm*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .controller('ProductAttributeListCtrl', ProductAttributeListCtrl);

    /* @ngInject */
    function ProductAttributeListCtrl(productAttributeService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.productAttributes = [];

        vm.getProductAttributes = function getProductAttributes() {
            productAttributeService.getProductAttributes().then(function (result) {
                vm.productAttributes = result.data;
            });
        };

        vm.deleteProductAttribute = function deleteProductAttribute(productAttribute) {
            if (confirm("Are you sure?")) {
                productAttributeService.deleteProductAttribute(productAttribute)
                    .then(function (result) {
                        vm.getProductAttributes();
                    });
            }
        };

        vm.getProductAttributes();
    }
})();