(function() {
    angular
        .module('simplAdmin.payments')
        .directive('paymentListByOrder', paymentListByOrder);

    function paymentListByOrder() {
        var directive = {
            restrict: 'E',
            templateUrl: 'modules/payments/admin/payment/payment-list-by-order.directive.html',
            scope: {},
            bindToController: {
                orderId: '='
            },
            controller: PaymentListByOrderCtrl,
            controllerAs: 'vm'
        };

        return directive;
    }

    /* @ngInject */
    function PaymentListByOrderCtrl(paymentService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.payments = [];

        vm.$onInit = function () {
            paymentService.getPaymentsByOrder(vm.orderId).then(function (result) {
                vm.payments = result.data;
            });
        };
    }
})();
