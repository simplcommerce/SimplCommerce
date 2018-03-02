/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .controller('CountryListCtrl', CountryListCtrl);

    /* @ngInject */
    function CountryListCtrl(countryService, translateService, $state) {
        var vm = this,
            tableStateRef;
        vm.countries = [];
        vm.translate = translateService;

        vm.getCountries = function getCountries(tableState) {
            tableStateRef = tableState;
            vm.isLoading = true;
            countryService.getCountries(tableState).then(function (result) {
                vm.countries = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
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
                            vm.getCountries(tableStateRef);
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