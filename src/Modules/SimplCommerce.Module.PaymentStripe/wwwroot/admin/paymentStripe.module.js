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
                        templateUrl: 'modules/paymentStripe/admin/stripe/stripe-config-form.html',
                        controller: 'StripeConfigFormCtrl as vm'
                    })
                ;
            }
        ]);
})();