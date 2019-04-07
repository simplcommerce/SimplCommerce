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
                        templateUrl: 'modules/paymentmomo/admin/momo/momo-config-form.html',
                        controller: 'MomoConfigFormCtrl as vm'
                    })
                ;
            }
        ]);
})();
