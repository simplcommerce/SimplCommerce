/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .controller('CategoryFormCtrl', CategoryFormCtrl);

    /* @ngInject */
    function CategoryFormCtrl($q, $state, $stateParams, categoryService, translateService) {
        var vm = this,
            tableStateRef;
        vm.translate = translateService;
        vm.category = { isPublished: true };
        vm.categories = [];
        vm.products = [];
        vm.categoryId = $stateParams.id;
        vm.isEditMode = vm.categoryId > 0;

        vm.save = function save() {
            var promise;
            // ng-upload will post null as text
            vm.category.parentId = vm.category.parentId === null ? '' : vm.category.parentId;
            vm.category.description = vm.category.description === null ? '' : vm.category.description;

            if (vm.isEditMode) {
                promise = categoryService.editCategory(vm.category);
            } else {
                promise = categoryService.createCategory(vm.category);
            }

            promise
                .then(function (result) {
                        $state.go('category');
                    })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add category.');
                    }
                });
        };

        vm.getProducts = function getProducts(tableState) {
            if (!vm.categoryId) {
                return;
            }

            tableStateRef = tableState;
            vm.isLoading = true;
            categoryService.getProducts(vm.categoryId, tableState).then(function (result) {
                vm.products = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };

        vm.editProduct = function editProduct(product) {
            product.isEditing = true;
            product.editingIsFeaturedProduct = product.isFeaturedProduct;
            product.editingDisplayOrder = product.displayOrder;
        }

        vm.saveProduct = function saveProduct(product) {
            var productCategory = {
                'id' : product.id,
                'isFeaturedProduct' : product.editingIsFeaturedProduct,
                'displayOrder' : product.displayOrder
            };
            categoryService.saveProduct(productCategory).then(function () {
                product.isEditing = false;
                product.isFeaturedProduct = product.editingIsFeaturedProduct;
                product.displayOrder = product.editingDisplayOrder;
            });
        }

        function init() {
            if (vm.isEditMode) {
                $q.all([
                        categoryService.getCategories(),
                        categoryService.getCategory(vm.categoryId)
                    ])
                    .then(function (result) {
                        var index;
                        vm.categories = result[0].data;
                        vm.category = result[1].data;

                        index = vm.categories.map(function (item) {
                            return item.id;
                        }).indexOf(vm.category.id);
                        vm.categories.splice(index, 1);
                    });
            }
            else {
                categoryService.getCategories().then(function (result) {
                    vm.categories = result.data;
                });
            }
        }

        init();
    }
})();