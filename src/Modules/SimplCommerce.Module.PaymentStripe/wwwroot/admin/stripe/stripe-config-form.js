/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.paymentStripe')
        .controller('StripeConfigFormCtrl', ['paymentSripeService', 'translateService', StripeConfigFormCtrl]);

    function StripeConfigFormCtrl(paymentSripeService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.stripeConfig = {};

        vm.save = function save() {
            vm.validationErrors = [];
            paymentSripeService.updateSetting(vm.stripeConfig)
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
                        vm.validationErrors.push('Could not save settings.');
                    }
                });
        };

        function init() {
            paymentSripeService.getSettings().then(function (result) {
                vm.stripeConfig = result.data;
            });
        }

        init();
    }
})(jQuery);
