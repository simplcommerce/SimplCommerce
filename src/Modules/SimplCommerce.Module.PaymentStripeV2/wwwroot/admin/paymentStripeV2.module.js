/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.paymentStripeV2', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('payments-stripev2-config', {
                        url: '/payments/stripev2/config',
                        templateUrl: '_content/SimplCommerce.Module.PaymentStripeV2/admin/stripev2/stripev2-config-form.html',
                        controller: 'StripeV2ConfigFormCtrl as vm'
                    })
                ;
            }
        ]);
})();
