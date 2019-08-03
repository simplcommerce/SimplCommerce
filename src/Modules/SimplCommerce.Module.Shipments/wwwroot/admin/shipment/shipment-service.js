/*global angular*/
(function () {
    angular
        .module('simplAdmin.shipment')
        .factory('shipmentService', ['$http', shipmentService]);

    function shipmentService($http) {
        var service = {
            getWarehouses: getWarehouses,
            getShipments: getShipments,
            getItemsToShip: getItemsToShip,
            createShipment: createShipment,
            getShipment: getShipment,
            getShipmentsByOrder: getShipmentsByOrder
        };
        return service;

        function getWarehouses() {
            return $http.get('api/warehouses/');
        }

        function getShipments(params) {
            return $http.post('api/shipments/grid', params);
        }

        function getItemsToShip(orderId, warehouseId) {
            return $http.get('api/orders/' + orderId + '/items-to-ship?warehouseId=' + warehouseId);
        }

        function createShipment(shipment) {
            return $http.post('api/shipments', shipment);
        }

        function getShipment(id) {
            return $http.get('api/shipments/' + id);
        }

        function getShipmentsByOrder(orderId) {
            return $http.get('api/orders/' + orderId + '/shipments');
        }
    }
})();
