/*global angular*/
(function () {
    angular
        .module('shopAdmin.brand')
        .controller('BrandEditCtrl', BrandEditCtrl);

    /* @ngInject */
    function BrandEditCtrl($state, $stateParams, brandService) {
        var vm = this;
        vm.brand = {};
        vm.isEditMode = true;

        vm.save = function save() {
            brandService.editBrand(vm.brand)
                .success(function (result) {
                    $state.go('brand');
                })
                .error(function (error) {
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add brand.');
                    }
                });
        };

        function init() {
            brandService.getBrand($stateParams.id).then(function (result) {
                vm.brand = result.data;
            });
        }

        init();
    }
})();