/*global angular*/
(function () {
    'use strict';

    angular.module('simplAdmin.shipment', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('shipment-create', {
                    url: '/orders/:orderId/create-shipment',
                    templateUrl: 'modules/shipments/admin/shipment/shipment-form.html',
                    controller: 'ShipmentFormCtrl as vm'
                })
                .state('shipments', {
                    url: '/shipments',
                    templateUrl: 'modules/shipments/admin/shipment/shipment-list.html',
                    controller: 'ShipmentListCtrl as vm'
                });
        }]);
})();