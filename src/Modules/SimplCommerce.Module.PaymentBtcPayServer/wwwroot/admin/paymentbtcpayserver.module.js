/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.paymentBtcPayServer', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('payments-btcpayserver-config', {
                        url: '/payments/btcpayserver/config',
                        templateUrl: 'modules/paymentBtcPayServer/admin/btcpayserver/btcpayserver-config-form.html',
                        controller: 'BtcPayServerConfigFormCtrl as vm'
                    })
                ;
            }
        ]);
})();
