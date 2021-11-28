/*global angular*/
(function () {
    'use strict';

    angular.module('simplAdmin.shipment', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('shipment-create', {
                    url: '/orders/:orderId/create-shipment',
                    templateUrl: '_content/SimplCommerce.Module.Shipments/admin/shipment/shipment-form.html',
                    controller: 'ShipmentFormCtrl as vm'
                })
                .state('shipments', {
                    url: '/shipments',
                    templateUrl: '_content/SimplCommerce.Module.Shipments/admin/shipment/shipment-list.html',
                    controller: 'ShipmentListCtrl as vm'
                })
                .state('shipment-details', {
                    url: '/shipment/:id',
                    templateUrl: '_content/SimplCommerce.Module.Shipments/admin/shipment/shipment-details.html',
                    controller: 'ShipmentDetailsCtrl as vm'
                });
        }]);
})();
