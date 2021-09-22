/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.paymentPaystack', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('payments-paystack-config', {
                        url: '/payments/paystack/config',
                        templateUrl: '_content/SimplCommerce.Module.PaymentPaystack/admin/config/config-form.html',
                        controller: 'PaystackConfigFormCtrl as vm'
                    })
                    ;
            }
        ]);
})();
