/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .controller('ProductPriceFormCtrl', ['productPriceService', 'translateService', ProductPriceFormCtrl]);

    function ProductPriceFormCtrl(productPriceService, translateService) {
        var vm = this;
        vm.tableStateRef = {};
        vm.translate = translateService;
        vm.products = [];

        vm.getProducts = function getProducts(tableState) {
            vm.tableStateRef = tableState;
            vm.isLoading = true;
            productPriceService.getProducts(tableState).then(function (result) {
                vm.products = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                tableState.pagination.totalItemCount = result.data.totalRecord;
                vm.isLoading = false;
            });
        };

        vm.save = function save() {
            productPriceService.updateProductPrices(vm.products).then(function (result) {
                vm.getProducts(vm.tableStateRef);
                toastr.success('Product prices have been updated');
            })
                .catch(function (response) {
                    toastr.error(response.data.error);
                });
        };
    }
})();
