/*global angular, confirm*/
(function () {
    angular
        .module('shopAdmin.category')
        .controller('CategoryListCtrl', CategoryLitsCtrl);

    /* @ngInject */
    function CategoryLitsCtrl(categoryService) {
        var vm = this;
        this.categories = [];

        this.getCategories = function getCategories() {
            categoryService.getCategories().then(function (result) {
                vm.categories = result.data;
            });
        };

        this.deleteCategory = function deleteCategory(category) {
            if (confirm("Are you sure?")) {
                categoryService.deleteCategory(category).then(function (result) {
                    vm.getCategories();
                });
            }
        };

        this.getCategories();
    }
})();