/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .controller('StateProvinceListCtrl', ['countryService', 'stateProvinceService', 'translateService', '$stateParams', StateProvinceListCtrl]);

    function StateProvinceListCtrl(countryService, stateProvinceService, translateService, $stateParams) {
        var vm = this;
        vm.tableStateRef = {};

        vm.countries = [];
        vm.stateOrProvinces = [];
        vm.countryId = $stateParams.countryId;
        vm.translate = translateService;

        vm.onCountrySelected = function () {
            vm.getStateOrProvinces(vm.tableStateRef);
        };

        vm.getStateOrProvinces = function (tableState) {
            vm.tableStateRef = tableState;
            vm.isLoading = true;
            stateProvinceService.getStateOrProvinces(vm.countryId, tableState).then(function (result) {
                vm.stateOrProvinces = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                tableState.pagination.totalItemCount = result.data.totalRecord;
                vm.isLoading = false;
            });
        };

        vm.deleteStateOrProvince = function deleteStateOrProvince(stateOrProvince) {
            bootbox.confirm('Are you sure you want to delete this state or province: ' + stateOrProvince.name, function (result) {
                if (result) {
                    stateProvinceService.deleteStateProvince(stateOrProvince)
                        .then(function (result) {
                            vm.getStateOrProvinces(vm.tableStateRef);
                            toastr.success(stateOrProvince.name + ' has been deleted');
                        })
                        .catch(function (response) {
                            toastr.error(response.data.error);
                        });
                }
            });
        };

        function init() {
            countryService.getAllCountries().then(function (result) {
                vm.countries = result.data;
                vm.countryId = vm.countryId || vm.countries[0].id.toString();
            });
        }

        init();
    }
})();
