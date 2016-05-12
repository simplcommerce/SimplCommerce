/*global angular, confirm*/
(function () {
    angular
        .module('shopAdmin.productOption')
        .controller('ProductOptionListCtrl', ProductOptionListCtrl);

    /* @ngInject */
    function ProductOptionListCtrl(productOptionService) {
        var vm = this;
        vm.productOptions = [];

        vm.getProductOptions = function getProductOptions() {
            productOptionService.getProductOptions().then(function (result) {
                vm.productOptions = result.data;
            });
        };

        vm.deleteProductOption = function deleteProductOption(productOption) {
            if (confirm("Are you sure?")) {
                productOptionService.deleteProductOption(productOption)
                    .success(function (result) {
                        vm.getProductOptions();
                    });
            }
        };

        vm.getProductOptions();
    }
})();