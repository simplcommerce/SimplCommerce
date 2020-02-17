/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.paymentMomo')
        .controller('MomoConfigFormCtrl', ['paymentMomoService', 'translateService', MomoConfigFormCtrl]);

    function MomoConfigFormCtrl(paymentMomoService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.momoConfig = {};

        vm.save = function save() {
            vm.validationErrors = [];
            paymentMomoService.updateSetting(vm.momoConfig)
                .then(function (result) {
                    toastr.success('Momo settings have been saved');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not save Momo settings.');
                    }
                });
        };

        function init() {
            paymentMomoService.getSettings().then(function (result) {
                vm.momoConfig = result.data;
            });
        }

        init();
    }
})(jQuery);
