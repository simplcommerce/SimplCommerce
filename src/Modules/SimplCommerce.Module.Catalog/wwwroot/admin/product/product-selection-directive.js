/*global angular confirm*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .directive('productSelectionDirective', productSelectionDirective);

    function productSelectionDirective() {
        var directive = {
            restrict: 'E',
            templateUrl: '_content/SimplCommerce.Module.Catalog/admin/product/product-selection-directive.html',
            scope: {
                selectedProducts: '=selectedProducts',
                modelId: '@modelId',
                title: '@title',
                isVisibleIndividually: '@isVisibleIndividually'
            },
            controller: ['productService', ProductSelectionCtrl],
            controllerAs: 'vm',
            bindToController: true
        };

        return directive;
    }

    /* @ngInject */
    function ProductSelectionCtrl(productService) {
        var vm = this,
            tableStateRef;
        vm.products = [];

        vm.getProducts = function getProducts(tableState) {
            tableStateRef = tableState;
            tableStateRef.search = tableStateRef.search || {};
            tableStateRef.search.predicateObject = tableStateRef.search.predicateObject || {};
            tableStateRef.search.predicateObject.IsVisibleIndividually = vm.isVisibleIndividually;
            tableStateRef.search.predicateObject.IsPublished = "true";
            vm.isLoading = true;
            productService.getProducts(tableState).then(function (result) {
                vm.products = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };

        vm.checkSelected = function checkSelected(product) {
            var selected = vm.selectedProducts.find(function (item) { return item.id === product.id; });
            if (selected) {
                return true;
            }

            return false;
        };

        vm.toggleSelectedProducts = function toggleSelectedProducts(product) {
            var selectedProductIds, index;
            selectedProductIds = vm.selectedProducts.map(function (item) { return item.id; });
            index = selectedProductIds.indexOf(product.id);
            if (index > -1) {
                vm.selectedProducts.splice(index, 1);
            } else {
                vm.selectedProducts.push({ id: product.id, name: product.name, isPublished: product.isPublished });
            }
        };
    }
})();
