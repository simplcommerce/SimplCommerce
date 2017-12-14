/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.cms')
        .controller('SpaceBarWidgetFormCtrl', SpaceBarWidgetFormCtrl);
    /* @ngInject */
    function SpaceBarWidgetFormCtrl($state, $stateParams, spacebarWidgetService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.widgetInstance = { widgetZoneId: 2, items: [{}], publishStart: new Date() };
        vm.widgetZones = [];
        vm.widgetInstanceId = $stateParams.id;
        vm.isEditMode = vm.widgetInstanceId > 0;
        vm.datePickerPublishStart = {};
        vm.datePickerPublishEnd = {};
        vm.openCalendar = function (e, picker) {
            vm[picker].open = true;
        };
        vm.addItem = function addItem() {
            vm.widgetInstance.items.push({});
        }
        vm.removeItem = function removeItem(item) {
            var index = vm.widgetInstance.items.indexOf(item);
            vm.widgetInstance.items.splice(index, 1);
        }
        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = spacebarWidgetService.editSpaceBarWidget(vm.widgetInstance);
            } else {
                promise = spacebarWidgetService.createSpaceBarWidget(vm.widgetInstance);
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
                        vm.validationErrors.push('Could not carousel widget.');
                    }
                });
               };
        function init() {
            spacebarWidgetService.getWidgetZones().then(function (result) {
                vm.widgetZones = result.data;
            });
            if (vm.isEditMode) {
                spacebarWidgetService.getSpaceBarWidget(vm.widgetInstanceId).then(function (result) {
                    vm.widgetInstance = result.data;
                    console.log(vm.widgetInstance)
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