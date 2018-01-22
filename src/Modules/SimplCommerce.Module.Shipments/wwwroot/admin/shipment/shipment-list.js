/*global angular*/
(function () {
    angular
        .module('simplAdmin.shipment')
        .controller('ShipmentListCtrl', ShipmentListCtrl);

    /* @ngInject */
    function ShipmentListCtrl(shipmentService, translateService) {
        var vm = this,
            tableStateRef;
        vm.shipments = [];
        vm.translate = translateService;

        vm.getShipments = function getShipments(tableState) {
            tableStateRef = tableState;
            vm.isLoading = true;
            shipmentService.getShipments(tableState).then(function (result) {
                vm.shipments = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };
    }
})();