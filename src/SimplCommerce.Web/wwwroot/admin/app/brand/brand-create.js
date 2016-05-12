/*global angular*/
(function () {
    angular
        .module('shopAdmin.brand')
        .controller('BrandCreateCtrl', BrandCreateCtrl);

    /* @ngInject */
    function BrandCreateCtrl($state, brandService) {
        var vm = this;

        vm.brand = {};

        vm.save = function save() {
            brandService.createBrand(vm.brand)
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
    }
})();