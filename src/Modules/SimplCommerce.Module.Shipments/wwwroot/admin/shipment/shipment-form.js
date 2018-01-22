/*global angular*/
(function () {
    angular
        .module('simplAdmin.shipment')
        .controller('ShipmentFormCtrl', ShipmentFormCtrl);

    /* @ngInject */
    function ShipmentFormCtrl($state, $stateParams, shipmentService, translateService) {
        var vm = this;
        vm.orderId = $stateParams.orderId;
        vm.translate = translateService;
        vm.warehouses = [];
        vm.shipmentForm = { items : [] };

        vm.save = function save() {
            shipmentService.createShipment(vm.shipmentForm)
                .then(function () {
                    $state.go('order-detail', { id: vm.orderId });
                    toastr.success('Shipment is created');
                })
                .catch(function (response) {
                    toastr.error(response.data);
                });
        };

        vm.getShipmentItems = function getShipmentItems() {
            shipmentService.getItemsToShip(vm.orderId, vm.selectedWarehouseId).then(function (result) {
                vm.shipmentForm = result.data;
            });
        };

        function getWarehouses() {
            shipmentService.getWarehouses().then(function (result) {
                vm.warehouses = result.data;
                if (vm.warehouses.length >= 1) {
                    vm.selectedWarehouseId = vm.warehouses[0].id;
                    vm.getShipmentItems();
                }
            });
        }

        function init() {
            getWarehouses();
        }

        init();
    }
})();