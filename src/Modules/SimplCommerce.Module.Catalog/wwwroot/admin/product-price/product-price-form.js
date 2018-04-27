/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .controller('ProductPriceFormCtrl', ProductPriceFormCtrl);

    /* @ngInject */
    function ProductPriceFormCtrl(productPriceService, translateService) {
        var vm = this,
            tableStateRef;
        vm.translate = translateService;
        vm.products = [];

        vm.getProducts = function getProducts(tableState) {
            tableStateRef = tableState;
            vm.isLoading = true;
            productPriceService.getProducts(tableState).then(function (result) {
                vm.products = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };

        vm.save = function save() {
            productPriceService.updateProductPrices(vm.products).then(function (result) {
                vm.getProducts(tableStateRef);
                toastr.success('Product prices have been updated');
            })
                .catch(function (response) {
                    toastr.error(response.data.error);
                });
        };
    }
})();