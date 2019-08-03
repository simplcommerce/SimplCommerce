/*global angular*/
(function () {
    angular
        .module('simplAdmin.shipment')
        .controller('ShipmentDetailsCtrl', ['$stateParams', 'shipmentService', 'translateService', ShipmentDetailsCtrl]);

    function ShipmentDetailsCtrl($stateParams, shipmentService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.shipmentId = $stateParams.id;
        vm.shipment = {};

        function getShipment() {
            shipmentService.getShipment(vm.shipmentId).then(function (result) {
                vm.shipment = result.data;
            });
        }

        function init() {
            getShipment();
        }

        init();
    }
})();
