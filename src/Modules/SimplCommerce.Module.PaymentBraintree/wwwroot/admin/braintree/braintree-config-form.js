/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.paymentBraintree')
        .controller('BraintreeConfigFormCtrl', ['paymentBraintreeService', 'translateService', BraintreeConfigFormCtrl]);

    function BraintreeConfigFormCtrl(paymentBraintreeService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.braintreeConfig = {};

        vm.save = function save() {
            vm.validationErrors = [];
            paymentBraintreeService.updateSetting(vm.braintreeConfig)
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
                        vm.validationErrors.push('Could not save braintree settings.');
                    }
                });
        };

        function init() {
            paymentBraintreeService.getSettings().then(function (result) {
                vm.braintreeConfig = result.data;
            });
        }

        init();
    }
})(jQuery);
