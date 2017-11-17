/*global angular, confirm*/
(function () {
    angular
        .module('simplAdmin.shippings')
        .controller('ShippingProviderListCtrl', ShippingProviderListCtrl);

    /* @ngInject */
    function ShippingProviderListCtrl(shippingProviderService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.shippingProviders = [];

        function getShippingProviders() {
            shippingProviderService.getShippingProviders().then(function (result) {
                vm.shippingProviders = result.data;
            });
        }

        function init() {
            getShippingProviders();
        }

        init();
    }
})();