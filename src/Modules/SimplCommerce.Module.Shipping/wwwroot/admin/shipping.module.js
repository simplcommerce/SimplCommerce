/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.shippings', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider.state('shipping-providers', {
                url: '/shipping-providers',
                templateUrl: "_content/SimplCommerce.Module.Shipping/admin/provider/shipping-provider-list.html",
                controller: 'ShippingProviderListCtrl as vm'
            });
        }]);
})();
