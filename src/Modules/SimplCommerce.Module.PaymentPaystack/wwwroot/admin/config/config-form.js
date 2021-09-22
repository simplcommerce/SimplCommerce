/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.paymentPaystack')
        .controller('PaystackConfigFormCtrl', ['paystackService', 'translateService', PaystackConfigFormCtrl]);

    function PaystackConfigFormCtrl(paystackService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.paystackConfig = {};

        vm.save = function save() {
            vm.validationErrors = [];
            paystackService.updateSetting(vm.paystackConfig)
                .then(function (result) {
                    toastr.success(vm.translate.get('Settings have been saved.'));
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push(vm.translate.get('Could not save settings.'));
                    }
                });
        };

        function init() {
            paystackService.getSettings().then(function (result) {
                vm.paystackConfig = result.data;
            });
        }

        init();
    }
})(jQuery);
