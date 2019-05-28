/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.paymentNganLuong')
        .controller('NganLuongConfigFormCtrl', NganLuongConfigFormCtrl);

    /* @ngInject */
    function NganLuongConfigFormCtrl($state, paymentNganLuongService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.nganLuongConfig = {};

        vm.save = function save() {
            vm.validationErrors = [];
            paymentNganLuongService.updateSetting(vm.nganLuongConfig)
                .then(function (result) {
                    toastr.success('Ngan luong settings have been saved');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not save Ngan luong settings.');
                    }
                });
        };

        function init() {
            paymentNganLuongService.getSettings().then(function (result) {
                vm.nganLuongConfig = result.data;
            });
        }

        init();
    }
})(jQuery);
