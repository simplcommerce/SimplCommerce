/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.paymentBtcPayServer')
        .controller('BtcPayServerConfigFormCtrl', BtcPayServerConfigFormCtrl);

    /* @ngInject */
    function BtcPayServerConfigFormCtrl($state, paymentBtcPayServerService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.btcPayServerConfig = {};

        vm.save = function save() {
            vm.validationErrors = [];
            paymentBtcPayServerService.updateSetting(vm.btcPayServerConfig)
                .then(function (result) {
                    vm.btcPayServerConfig = result.data;
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
                        vm.validationErrors.push('Could not save btcpayserver settings.');
                    }
                });
        };
        
        vm.unpair = function unpair(){
            paymentBtcPayServerService.unpair().then(function (result) {
                vm.btcPayServerConfig = result.data;
            });
        };

        function init() {
            paymentBtcPayServerService.getSettings().then(function (result) {
                vm.btcPayServerConfig = result.data;
            });
        }

        init();
    }
})(jQuery);
