 /*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .controller('StateProvinceFormCtrl', StateProvinceFormCtrl);

    /* @ngInject */
    function StateProvinceFormCtrl($state, $stateParams, stateProvinceService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.stateProvince = {};
        vm.stateProvinceId = $stateParams.id;
        vm.countryId = $stateParams.countryId;
        vm.isEditMode = vm.stateProvinceId > 0;

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = stateProvinceService.editStateProvince(vm.stateProvince);
            } else {
                vm.stateProvince.countryId = vm.countryId;
                promise = stateProvinceService.createStateProvince(vm.stateProvince);
            }

            promise
                .then(function (result) {
                    $state.go('country-states-provinces', {countryId: vm.countryId});
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else { 
                        vm.validationErrors.push(translateService.get('Could not add State or Province.'));
                    }
                });
        };

        function init() {
            if (vm.isEditMode) {
                stateProvinceService.getStateProvince(vm.stateProvinceId).then(function (result) {
                    vm.stateProvince = result.data;
                });
            }
        }

        init();
    }
})();