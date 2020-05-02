/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.paymentMomo', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('payments-momo-config', {
                        url: '/payments/momo/config',
                        templateUrl: '_content/SimplCommerce.Module.PaymentMomo/admin/momo/momo-config-form.html',
                        controller: 'MomoConfigFormCtrl as vm'
                    })
                ;
            }
        ]);
})();
