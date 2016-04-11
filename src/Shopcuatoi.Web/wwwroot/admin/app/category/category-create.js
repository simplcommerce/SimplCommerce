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
            categoryService.createCategory(vm.category)
                .success(function (result) {
                        $state.go('category');
                    })
                .error(function (error) {
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

        vm.getCategories = function getCategories() {
            categoryService.getCategories().then(function (result) {
                vm.categories = result.data;
            });
        };

        vm.getCategories();
    }
})();