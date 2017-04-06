/*global angular confirm*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .controller('ProductListCtrl', ProductListCtrl);

    /* @ngInject */
    function ProductListCtrl(productService, translateService) {
        var vm = this,
            tableStateRef;
        vm.translate = translateService;
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
            bootbox.confirm('Are you sure you want to delete this product: ' + product.name, function (result) {
                if (result) {
                    productService.deleteProduct(product)
                       .then(function (result) {
                           vm.getProducts(tableStateRef);
                           toastr.success(product.name + ' has been deleted');
                       })
                        .catch(function (response) {
                            toastr.error(response.data.error);
                       });
                }
            });
        };
    }
})();