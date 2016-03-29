(function() {
    angular
        .module('shopAdmin.product')
        .controller('productListCtrl', [
            'productService',
            function(productService) {
                var vm = this;
                this.products = [];

                this.getProducts = function getProducts(tableState) {
                    vm.isLoading = true;
                    productService.getProducts(tableState).then(function(result) {
                        vm.products = result.data.items;
                        tableState.pagination.numberOfPages = result.data.numberOfPages;
                        vm.isLoading = false;
                    });
                };
            }
        ]);
})();