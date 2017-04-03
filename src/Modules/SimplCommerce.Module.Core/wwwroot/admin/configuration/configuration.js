/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.core')
        .controller('ConfigurationCtrl', ConfigurationCtrl);

    /* @ngInject */
    function ConfigurationCtrl($state, configurationService) {
        var vm = this;
        vm.settings = {};

        vm.save = function save() {
            vm.validationErrors = [];
            configurationService.updateSetting(vm.settings)
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
            configurationService.getSettings().then(function (result) {
                vm.settings = result.data;
            });
        }

        init();
    }
})(jQuery);