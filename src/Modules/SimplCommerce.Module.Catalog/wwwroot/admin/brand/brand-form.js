 /*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .controller('BrandFormCtrl', ['$state', '$stateParams', 'brandService', 'translateService', BrandFormCtrl]);

    function BrandFormCtrl($state, $stateParams, brandService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.brand = {};
        vm.brandId = $stateParams.id;
        vm.isEditMode = vm.brandId > 0;

        vm.updateSlug = function () {
            vm.brand.slug = slugify(vm.brand.name);
        };

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = brandService.editBrand(vm.brand);
            } else {
                promise = brandService.createBrand(vm.brand);
            }

            promise
                .then(function (result) {
                    $state.go('brand');
                })
                .catch(function (response) {
                    var error = response.data;
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
