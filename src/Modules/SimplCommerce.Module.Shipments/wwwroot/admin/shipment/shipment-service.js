/*global angular*/
(function () {
    angular
        .module('simplAdmin.shipment')
        .factory('shipmentService', shipmentService);

    /* @ngInject */
    function shipmentService($http) {
        var service = {
            getWarehouses: getWarehouses,
            getItemsToShip: getItemsToShip,
            createShipment: createShipment
        };
        return service;

        function getWarehouses() {
            return $http.get('api/warehouses/');
        }

        function getItemsToShip(orderId, warehouseId) {
            return $http.get('api/orders/' + orderId + '/items-to-ship?warehouseId=' + warehouseId);
        }

        function createShipment(shipment) {
            return $http.post('api/shipments', shipment);
        }
    }
})();