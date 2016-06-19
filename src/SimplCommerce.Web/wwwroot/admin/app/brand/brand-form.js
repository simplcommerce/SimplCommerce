 /*global angular*/
(function () {
    angular
        .module('shopAdmin.brand')
        .controller('BrandFormCtrl', BrandFormCtrl);

    /* @ngInject */
    function BrandFormCtrl($state, $stateParams, brandService) {
        var vm = this;
        vm.brand = {};
        vm.brandId = $stateParams.id;
        vm.isEditMode = vm.brandId > 0;

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = brandService.editBrand(vm.brand);
            } else {
                promise = brandService.createBrand(vm.brand);
            }

            promise
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
            if (vm.isEditMode) {
                brandService.getBrand(vm.brandId).then(function (result) {
                    vm.brand = result.data;
                });
            }
        }

        init();
    }
})();