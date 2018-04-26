/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.catalog')
        .controller('SimpleProductWidgetFormCtrl', SimpleProductWidgetFormCtrl);

    /* @ngInject */
    function SimpleProductWidgetFormCtrl($state, $stateParams, simpleProductWidgetService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.widgetInstance = { widgetZoneId: 2, displayOrder : 0, setting: { products: [] }, publishStart: new Date() };
        vm.widgetZones = [];
        vm.widgetInstanceId = $stateParams.id;
        vm.isEditMode = vm.widgetInstanceId > 0;
        vm.datePickerPublishStart = {};
        vm.datePickerPublishEnd = {};
        vm.openCalendar = function (e, picker) {
            vm[picker].open = true;
        };

        vm.save = function save() {
            var promise;

            if (vm.isEditMode) {
                console.log(vm.widgetInstance)
                promise = simpleProductWidgetService.editSimpleProductWidget(vm.widgetInstance);
            } else {
                promise = simpleProductWidgetService.createSimpleProductWidget(vm.widgetInstance);
            }
            promise
                .then(function (result) {
                    $state.go('widget');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not create or edit simple product widget.');
                    }
                });
        };

        function init() {
            simpleProductWidgetService.getWidgetZones().then(function (result) {
                vm.widgetZones = result.data;
            });

            if (vm.isEditMode) {
                simpleProductWidgetService.getSimpleProductWidget(vm.widgetInstanceId).then(function (result) {
                    vm.widgetInstance = result.data;
                    if (vm.widgetInstance.publishStart) {
                        vm.widgetInstance.publishStart = new Date(vm.widgetInstance.publishStart);
                    }
                    if (vm.widgetInstance.publishEnd) {
                        vm.widgetInstance.publishEnd = new Date(vm.widgetInstance.publishEnd);
                    }
                });
            }
        }

        init();
    }
})(jQuery);