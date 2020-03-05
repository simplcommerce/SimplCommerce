/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.paymentBraintree', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('payments-braintree-config', {
                        url: '/payments/braintree/config',
                        templateUrl: '_content/SimplCommerce.Module.PaymentBraintree/admin/braintree/braintree-config-form.html',
                        controller: 'BraintreeConfigFormCtrl as vm'
                    })
                ;
            }
        ]);
})();
