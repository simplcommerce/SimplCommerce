/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.payments', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider.state('payment-providers', {
                url: '/payment-providers',
                templateUrl: "_content/SimplCommerce.Module.Payments/admin/provider/payment-provider-list.html",
                controller: 'PaymentProviderListCtrl as vm'
            });
        }]);
})();
