(function() {
    angular
        .module('simplAdmin.orders')
        .directive('orderWidget', mostSearchKeyword);

    function mostSearchKeyword() {
        var directive = {
            restrict: 'E',
            templateUrl: 'orders/admin/order/order-widget.directive.html',
            scope: {
                status: '=',
                numRecords: '='
            },
            controller: OrderWidgetCtrl,
            controllerAs: 'vm',
            bindToController: true
        };

        return directive;
    }

    /* @ngInject */
    function OrderWidgetCtrl(orderService) {
        var vm = this;
        vm.orders = [];

        orderService.getOrders(vm.status, vm.numRecords).then(function (result) {
            vm.orders = result.data;
        });
    }
})();
