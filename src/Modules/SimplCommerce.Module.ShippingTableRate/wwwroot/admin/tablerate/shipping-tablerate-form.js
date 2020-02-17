/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.shipping-tablerate')
        .controller('ShippingTableRateFormCtrl', ['shippingTableRateService', 'translateService', ShippingTableRateFormCtrl]);

    /* @ngInject */
    function ShippingTableRateFormCtrl(shippingTableRateService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.pricesAndDestinations = [];
        vm.countries = [];
        vm.statesOrProvinces = [];
        vm.districts = [];
        vm.addingPriceAndDestination = { country : '*' };

        vm.startEditingPriceAndDestination = function startEditingPriceAndDestination(priceAndDestination) {
            priceAndDestination.isEditing = true;
            vm.onCountrySelected(priceAndDestination.countryId);
            vm.onStateOrProvinceSelected(priceAndDestination.stateOrProvinceId);
        };

        vm.onCountrySelected = function onCountrySelected(countryId) {
            vm.statesOrProvinces = [];
            if (countryId) {
                shippingTableRateService.getStatesOrProvinces(countryId).then(function (result) {
                    vm.statesOrProvinces = result.data;
                });
            }
        };

        vm.onStateOrProvinceSelected = function onStateOrProvinceSelected(stateOrProvinceId) {
            vm.districts = [];
            if (stateOrProvinceId) {
                shippingTableRateService.getDistricts(stateOrProvinceId).then(function (result) {
                    vm.districts = result.data;
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
                priceAndDestination.districtName = result.data.districtName;
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
