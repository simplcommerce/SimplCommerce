/*global angular, confirm*/
(function () {
    angular
        .module('shopAdmin.productAttribute')
        .controller('ProductAttributeListCtrl', ProductAttributeListCtrl);

    /* @ngInject */
    function ProductAttributeListCtrl(productAttributeService) {
        var vm = this;
        vm.productAttributes = [];

        vm.getProductAttributes = function getProductAttributes() {
            productAttributeService.getProductAttributes().then(function (result) {
                vm.productAttributes = result.data;
            });
        };

        vm.deleteProductAttribute = function deleteProductAttribute(productAttribute) {
            if (confirm("Are you sure?")) {
                productAttributeService.deleteProductAttribute(productAttribute)
                    .success(function (result) {
                        vm.getProductAttributes();
                    });
            }
        };

        vm.getProductAttributes();
    }
})();