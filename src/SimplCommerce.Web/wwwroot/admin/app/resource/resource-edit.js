/*global angular, jQuery*/
(function ($) {
    angular
        .module('shopAdmin.resource')
        .controller('ResourceEditCtrl', ResourceEditCtrl);

    /* @ngInject */
    function ResourceEditCtrl($state, $stateParams, resourceService) {
        var vm = this;
        vm.resource = {};
        vm.isEditMode = true;

        vm.save = function save() {
            resourceService.editResource(vm.resource)
                .success(function (result) {
                    $state.go('resource');
                })
                .error(function (error) {
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not update resource.');
                    }
                });
        };

        function init() {
            resourceService.getResource($stateParams.id).then(function (result) {
                vm.resource = result.data;
            });
        }

        init();
    }
})(jQuery);