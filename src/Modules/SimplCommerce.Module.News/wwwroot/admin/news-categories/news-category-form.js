 /*global angular*/
(function () {
    angular
        .module('simplAdmin.news')
        .controller('NewsCategoryFormCtrl', NewsCategoryFormCtrl);

    /* @ngInject */
    function NewsCategoryFormCtrl($state, $stateParams, newsCategoryService) {
        var vm = this;
        vm.newsCategory = {};
        vm.newsCategoryId = $stateParams.id;
        vm.isEditMode = vm.newsCategoryId > 0;

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = newsCategoryService.editNewsCategory(vm.newsCategory);
            } else {
                promise = newsCategoryService.createNewsCategory(vm.newsCategory);
            }

            promise
                .then(function (result) {
                    $state.go('news-categories');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add news category.');
                    }
                });
        };

        function init() {
            if (vm.isEditMode) {
                newsCategoryService.getNewsCategory(vm.newsCategoryId).then(function (result) {
                    vm.newsCategory = result.data;
                });
            }
        }

        init();
    }
})();