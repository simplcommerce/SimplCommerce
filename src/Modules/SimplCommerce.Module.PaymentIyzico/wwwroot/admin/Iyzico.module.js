/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.paymentIyzico', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('payments-paymentIyzico-config', {
                        url: '/payments/payment-iyzico/config',
                        templateUrl: 'modules/paymentIyzico/admin/config/config-form.html',
                        controller: 'paymentIyzicoConfigFormCtrl as vm'
                    });
            }
        ]);
})();