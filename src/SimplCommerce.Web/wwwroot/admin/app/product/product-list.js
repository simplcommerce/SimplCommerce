/*global angular confirm*/
(function () {
    angular
        .module('shopAdmin.product')
        .controller('ProductListCtrl', ProductListCtrl);

    /* @ngInject */
    function ProductListCtrl(productService) {
        var vm = this,
            tableStateRef;
        vm.products = [];

        vm.getProducts = function getProducts(tableState) {
            tableStateRef = tableState;
            vm.isLoading = true;
            productService.getProducts(tableState).then(function (result) {
                vm.products = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };

        vm.changeStatus = function changeStatus(product) {
            productService.changeStatus(product).then(function () {
                product.isPublished = !product.isPublished;
            });
        };

        vm.deleteProduct = function deleteProduct(product) {
            if (confirm("Are you sure?")) {
                productService.deleteProduct(product).then(function (result) {
                    vm.getProducts(tableStateRef);
                });
            }
        };
    }
})();