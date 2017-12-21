/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.payments', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider.state('payment-providers', {
                url: '/payment-providers',
                templateUrl: "modules/payments/admin/provider/payment-provider-list.html",
                controller: 'PaymentProviderListCtrl as vm'
            });
        }]);
})();