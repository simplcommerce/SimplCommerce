/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .controller('StateProvinceListCtrl', StateProvinceListCtrl);

    /* @ngInject */
    function StateProvinceListCtrl(countryService, stateProvinceService, translateService, $state, $stateParams) {
        var vm = this,
            tableStateRef;

        vm.countries = [];
        vm.stateOrProvinces = [];
        vm.translate = translateService;

        vm.onCountrySelected = function (countryId) {
            if (countryId) {
                vm.isCountrySelected = true;
                vm.getStateOrProvinces(tableStateRef);
            }
        };


        vm.getStateOrProvinces = function (tableState) {
            if (!vm.isCountrySelected || !tableState ) return;

            tableStateRef = tableState;
            vm.isLoading = true;
            stateProvinceService.getStateOrProvinces(vm.countryId, tableState).then(function (result) {
                vm.stateOrProvinces = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };

        function init() {
            countryService.getAllCountries().then(function (result) {
                vm.countries = result.data;
                vm.countryId = $stateParams.countryId;
                vm.isCountrySelected = vm.countryId > 0;
            });
        }

        init();
    }
})();