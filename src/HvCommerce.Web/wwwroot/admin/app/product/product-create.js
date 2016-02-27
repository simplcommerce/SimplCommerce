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
                this.thumbnailImage = null;
                this.productImages = [];

                this.create = function create(productForm) {
                    if (productForm.$valid) {
                        productService.createProduct(vm.product, vm.thumbnailImage, vm.productImages)
                            .success(function (result) {
                                $state.go('product');
                            });
                    }
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