(function() {
    angular
        .module('hvAdmin.product')
        .controller('productCreateCtrl', [
            '$state', 'categoryService', 'productService',
            function($state, categoryService, productService) {
                var vm = this;
                this.product = {};
                this.product.categoryIds = [];
                this.categories = [];

                this.create = function create() {
                    productService.createProduct(vm.product).then(function (result) {
                        $state.go('product');
                    });
                };

                this.getCategories = function getCategories() {
                    categoryService.getCategories().then(function(result) {
                        vm.categories = result.data;
                    });
                };

                this.toggleCategories = function toggleCategories(categoryId) {
                    var idx = vm.product.categoryIds.indexOf(categoryId);
                    if (idx > -1) {
                        vm.product.categoryIds.splice(idx, 1);
                    } else {
                        vm.product.categoryIds.push(categoryId);
                    }
                }

                this.getCategories();
            }
        ]);
})();