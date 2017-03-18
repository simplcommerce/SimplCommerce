/*global angular, confirm*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .controller('CategoryListCtrl', CategoryLitsCtrl);

    /* @ngInject */
    function CategoryLitsCtrl(categoryService) {
        var vm = this;
        vm.categories = [];

        vm.getCategories = function getCategories() {
            categoryService.getCategories().then(function (result) {
                vm.categories = result.data;
            });
        };

        vm.deleteCategory = function deleteCategory(category) {
            bootbox.confirm('Are you sure you want to delete this ' + category.name, function (result) {
                if (result) {
                    categoryService.deleteCategory(category)
                       .then(function (result) {
                           vm.getCategories();
                           toastr.success(category.name + 'Have been deleted');
                        })
                        .catch(function (response) {
                            toastr.error(response.data.error);
                        });
                }
            });
        };

        vm.getCategories();
    }
})();