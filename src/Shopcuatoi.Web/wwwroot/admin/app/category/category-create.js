/*global angular*/
(function () {
    angular
        .module('shopAdmin.category')
        .controller('CategoryCreateCtrl', CategoryCreateCtrl);

    /* @ngInject */
    function CategoryCreateCtrl($state, categoryService) {
        var vm = this;

        vm.category = {};
        vm.categories = [];

        vm.save = function save() {
            categoryService.createCategory(vm.category).then(function (result) {
                $state.go('category');
            });
        };

        vm.getCategories = function getCategories() {
            categoryService.getCategories().then(function (result) {
                vm.categories = result.data;
            });
        };

        vm.getCategories();
    }
})();