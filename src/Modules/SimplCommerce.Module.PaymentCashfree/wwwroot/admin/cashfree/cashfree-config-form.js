/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.paymentCashfree')
        .controller('CashfreeConfigFormCtrl', CashfreeConfigFormCtrl);

    /* @ngInject */
    function CashfreeConfigFormCtrl($state, paymentCashfreeService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.cashfreeConfig = {};

        vm.save = function save() {
            vm.validationErrors = [];
            paymentCashfreeService.updateSetting(vm.cashfreeConfig)
                .then(function (result) {
                    toastr.success('Application settings have been saved');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not save Cashfree settings.');
                    }
                });
        };

        function init() {
            paymentCashfreeService.getSettings().then(function (result) {
                vm.cashfreeConfig = result.data;
            });
        }

        init();
    }
})(jQuery);
