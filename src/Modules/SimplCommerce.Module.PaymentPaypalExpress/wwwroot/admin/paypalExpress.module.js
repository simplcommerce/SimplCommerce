/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.paymentPaypalExpress', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('payments-paypalExpress-config', {
                        url: '/payments/paypal-express/config',
                        templateUrl: '_content/SimplCommerce.Module.PaymentPaypalExpress/admin/config/config-form.html',
                        controller: 'PaypalExpressConfigFormCtrl as vm'
                    })
                    ;
            }
        ]);
})();
