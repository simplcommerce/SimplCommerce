/*global angular*/
(function () {
    angular
        .module('shopAdmin.product')
        .controller('ProductListCtrl', ProductListCtrl);

    /* @ngInject */
    function ProductListCtrl(productService) {
        var vm = this;
        vm.products = [];

        vm.getProducts = function getProducts(tableState) {
            vm.isLoading = true;
            productService.getProducts(tableState).then(function (result) {
                vm.products = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };
    }
})();