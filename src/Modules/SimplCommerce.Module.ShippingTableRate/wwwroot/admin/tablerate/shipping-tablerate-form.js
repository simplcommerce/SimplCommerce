/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.shipping-tablerate')
        .controller('ShippingTableRateFormCtrl', ShippingTableRateFormCtrl);

    /* @ngInject */
    function ShippingTableRateFormCtrl($state, shippingTableRateService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.settings = [];
        vm.pricesAndDestinations = [];
        vm.countries = [];
        vm.statesOrProvinces = [];
        vm.addingPriceAndDestination = { country : '*' };

        vm.save = function save() {
            shippingTableRateService.updateSetting(vm.settings)
                .then(function (result) {
                    $state.go('shipping-providers');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not html widget.');
                    }
                });
        };

        vm.startEditingPriceAndDestination = function startEditingPriceAndDestination(priceAndDestination) {
            priceAndDestination.isEditing = true;
            vm.onCountrySelected(priceAndDestination.countryId);
        };

        vm.onCountrySelected = function onCountrySelected(countryId) {
            vm.statesOrProvinces = [];
            if (countryId) {
                shippingTableRateService.getStatesOrProvinces(countryId).then(function (result) {
                    vm.statesOrProvinces = result.data;
                });
            }
        };

        vm.addPriceAndDestination = function addPriceAndDestination() {
            shippingTableRateService.addPriceAndDestination(vm.addingPriceAndDestination).then(function (result) {
                vm.pricesAndDestinations.push(result.data);
                vm.addingPriceAndDestination = {};
            });
        };

        vm.updatePriceAndDestination = function updatePriceAndDestination(priceAndDestination) {
            shippingTableRateService.updatePriceAndDestination(priceAndDestination).then(function (result) {
                priceAndDestination.countryName = result.data.countryName;
                priceAndDestination.stateOrProvinceName = result.data.stateOrProvinceName;
                priceAndDestination.isEditing = false;
            });
        };

        vm.deletePriceAndDestination = function deletePriceAndDestination(priceAndDestination) {
            shippingTableRateService.deletePriceAndDestination(priceAndDestination.id).then(function () {
                var index = vm.pricesAndDestinations.indexOf(priceAndDestination);
                vm.pricesAndDestinations.splice(index, 1);
            });
        };

        function getPricesAndDestinations() {
            shippingTableRateService.getPricesAndDestinations().then(function (result) {
                vm.pricesAndDestinations = result.data;
            });
        }

        function getCountries() {
            shippingTableRateService.getCountries().then(function (result) {
                vm.countries = result.data;
            });
        }

        function init() {
            getPricesAndDestinations();
            getCountries();
        }

        init();
    }
})(jQuery);