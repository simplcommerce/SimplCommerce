 /*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .controller('CountryFormCtrl', CountryFormCtrl);

    /* @ngInject */
    function CountryFormCtrl($state, $stateParams, countryService, stateProvinceService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.country = {};
        vm.countryId = $stateParams.id;
        vm.isEditMode = vm.countryId;


        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = countryService.editCountry(vm.country);
            } else {
                promise = countryService.createCountry(vm.country);
            }

            promise
                .then(function (result) {
                    $state.go('countries');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else { 
                        vm.validationErrors.push(translateService.get('Could not add country.'));
                    }
                });
        };

        function init() {
            if (vm.isEditMode) {
                countryService.getCountry(vm.countryId).then(function (result) {
                    vm.country = result.data;
                });
            }
        }

        init();
    }
})();