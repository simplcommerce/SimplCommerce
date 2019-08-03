/*global angular*/
(function () {
    angular
        .module('simplAdmin.shipment')
        .controller('ShipmentListCtrl', ['shipmentService', 'translateService', ShipmentListCtrl]);

    function ShipmentListCtrl(shipmentService, translateService) {
        var vm = this;
        vm.tableStateRef = {};
        vm.shipments = [];
        vm.translate = translateService;

        vm.getShipments = function getShipments(tableState) {
            vm.tableStateRef = tableState;
            vm.isLoading = true;
            shipmentService.getShipments(tableState).then(function (result) {
                vm.shipments = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                tableState.pagination.totalItemCount = result.data.totalRecord;
                vm.isLoading = false;
            });
        };
    }
})();
