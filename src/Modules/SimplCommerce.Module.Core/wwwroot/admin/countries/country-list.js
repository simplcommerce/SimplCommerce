/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .controller('CountryListCtrl', ['countryService', 'translateService', CountryListCtrl]);

    function CountryListCtrl(countryService, translateService) {
        var vm = this;
        vm.tableStateRef = {};
        vm.countries = [];
        vm.translate = translateService;

        vm.getCountries = function getCountries(tableState) {
            vm.tableStateRef = tableState;
            vm.isLoading = true;
            countryService.getCountries(tableState).then(function (result) {
                vm.countries = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                tableState.pagination.totalItemCount = result.data.totalRecord;
                vm.isLoading = false;
            });
        };

        vm.update = function (country) {
            countryService.editCountry(country)
                .then(function (result) {
                    toastr.success(country.name + ' has been updated');
                })
                .catch(function (response) {
                    toastr.error(response.data.error);
                });
        };

        vm.deleteCountry = function (country) {
            bootbox.confirm('Are you sure you want to delete this country: ' + country.name, function (result) {
                if (result) {
                    countryService.deleteCountry(country)
                        .then(function (result) {
                            vm.getCountries(vm.tableStateRef);
                            toastr.success(country.name + ' has been deleted');
                        })
                        .catch(function (response) {
                            toastr.error(response.data.error);
                        });
                }
            });
        };
    }
})();
