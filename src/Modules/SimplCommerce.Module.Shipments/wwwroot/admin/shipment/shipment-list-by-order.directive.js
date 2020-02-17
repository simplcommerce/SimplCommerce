(function() {
    angular
        .module('simplAdmin.shipment')
        .directive('shipmentListByOrder', shipmentListByOrder);

    function shipmentListByOrder() {
        var directive = {
            restrict: 'E',
            templateUrl: 'modules/shipments/admin/shipment/shipment-list-by-order.directive.html',
            scope: {},
            bindToController: {
                orderId: '='
            },
            controller: ['shipmentService', 'translateService', ShipmentListByOrderCtrl],
            controllerAs: 'vm'
        };

        return directive;
    }

    function ShipmentListByOrderCtrl(shipmentService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.shipments = [];

        vm.$onInit = function () {
            shipmentService.getShipmentsByOrder(vm.orderId).then(function (result) {
                vm.shipments = result.data;
            });
        };
    }
})();
