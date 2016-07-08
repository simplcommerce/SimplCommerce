/*global angular, jQuery*/
(function ($) {
    angular
        .module('shopAdmin.widget')
        .controller('ProductDisplayWidgetFormCtrl', ProductDisplayWidgetFormCtrl);

    /* @ngInject */
    function ProductDisplayWidgetFormCtrl($state, $stateParams, widgetService) {
        var vm = this;
        vm.widgetZones = [];
        vm.widgetInstance = { widgetZoneId: 1 };
        vm.widgetInstanceId = $stateParams.id;
        vm.isEditMode = vm.widgetInstanceId > 0;

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = widgetService.editProductDisplayWidget(vm.widgetInstance);
            } else {
                promise = widgetService.createProductDisplayWidget(vm.widgetInstance);
            }

            promise
                .success(function (result) {
                    $state.go('widget');
                })
                .error(function (error) {
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not product display widget.');
                    }
                });
        };

        function init() {
            widgetService.getWidgetZones().then(function (result) {
                vm.widgetZones = result.data;
            });

            if (vm.isEditMode) {
                widgetService.getProductDisplayWidget(vm.widgetInstanceId).then(function (result) {
                    vm.widgetInstance = result.data;
                });
            }
        }

        init();
    }
})(jQuery);