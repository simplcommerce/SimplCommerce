/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.cms')
        .controller('MenuFormCreateCtrl', MenuFormCreateCtrl);

    /* @ngInject */
    function MenuFormCreateCtrl($state, menuService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.menu = {};

        vm.save = function save() {
            menuService.createMenu(vm.menu)
                .then(function (result) {
                    $state.go('menus-edit', { id: result.data.id });
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add menu.');
                    }
            });
        };
    }
})(jQuery);