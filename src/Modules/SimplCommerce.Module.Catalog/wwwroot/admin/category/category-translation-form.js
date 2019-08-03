/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .controller('CategoryTranslationFormCtrl', ['$state', '$stateParams', 'categoryService', 'translateService', CategoryTranslationFormCtrl]);

    function CategoryTranslationFormCtrl($state, $stateParams, categoryService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.category = { isPublished: true };
        vm.categoryId = $stateParams.id;
        vm.culture = $stateParams.culture;

        vm.save = function save() {
            categoryService.editCategoryTranslation(vm.categoryId, vm.culture, vm.category)
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
                        vm.validationErrors.push('Could not add category translation.');
                    }
                });
        };

        function init() {
            categoryService.getCategoryTranslation(vm.categoryId, vm.culture).then(function (result) {
                vm.category = result.data;
            });
        }

        init();
    }
})();
