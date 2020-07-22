/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.paymentStripeV2')
        .controller('StripeV2ConfigFormCtrl', ['paymentStripeV2Service', 'translateService', StripeV2ConfigFormCtrl]);

    function StripeV2ConfigFormCtrl(paymentStripeV2Service, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.stripeConfig = {};

        vm.save = function save() {
            vm.validationErrors = [];
            paymentStripeV2Service.updateSetting(vm.stripeConfig)
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
            paymentStripeV2Service.getSettings().then(function (result) {
                vm.stripeConfig = result.data;
            });
        }

        init();
    }
})(jQuery);
