/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .controller('ProductOptionFormCtrl', ProductOptionFormCtrl);

    /* @ngInject */
    function ProductOptionFormCtrl($state, $stateParams, productOptionService) {
        var vm = this;
        vm.productOptionId = $stateParams.id;
        vm.isEditMode = vm.productOptionId > 0;

        vm.productOption = {};

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = productOptionService.editProductOption(vm.productOption);
            } else {
                promise = productOptionService.createProductOption(vm.productOption);
            }

            promise
                .success(function (result) {
                    $state.go('product-option');
                })
                .error(function (error) {
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add create product option.');
                    }
                });
        };

        function getProductOption() {
            productOptionService.getProductOption(vm.productOptionId).then(function (result) {
                vm.productOption = result.data;
            });
        }

        function init() {
            if (vm.isEditMode) {
                getProductOption();
            }
        }

        init();
    }
})();