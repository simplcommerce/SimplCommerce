/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.paymentIyzico')
        .controller('paymentIyzicoConfigFormCtrl', paymentIyzicoConfigFormCtrl);

    /* @ngInject */
    function paymentIyzicoConfigFormCtrl($state, iyzicoService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.paymentIyzicoConfig = {};

        vm.save = function save() {
            vm.validationErrors = [];
            iyzicoService.updateSetting(vm.paymentIyzicoConfig)
                .then(function (result) {
                    toastr.success('Settings have been saved');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not save settings.');
                    }
                });
        };

        function init() {
            iyzicoService.getSettings().then(function (result) {
                vm.paymentIyzicoConfig = result.data;
            });
        }

        init();
    }
})(jQuery);