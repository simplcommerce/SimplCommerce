/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.paymentStripe', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('payments-stripe-config', {
                        url: '/payments/stripe/config',
                        templateUrl: '_content/SimplCommerce.Module.PaymentStripe/admin/stripe/stripe-config-form.html',
                        controller: 'StripeConfigFormCtrl as vm'
                    })
                ;
            }
        ]);
})();
