/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.cms')
        .controller('CarouselWidgetFormCtrl', CarouselWidgetFormCtrl);

    /* @ngInject */
    function CarouselWidgetFormCtrl($state, $stateParams, carouselWidgetService) {
        var vm = this;
        vm.widgetInstance = { widgetZoneId: 1, items: [{}], publishStart: new Date() };
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

            // ng-upload will post null as text
            angular.forEach(vm.widgetInstance.items, function (item) {
                item.caption = item.caption === null ? '' : item.caption;
            });

            if (vm.isEditMode) {
                promise = carouselWidgetService.editCarouselWidget(vm.widgetInstance);
            } else {
                promise = carouselWidgetService.createCarouselWidget(vm.widgetInstance);
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
                        vm.validationErrors.push('Could not carousel widget.');
                    }
                });
        };

        function init() {

            carouselWidgetService.getWidgetZones().then(function (result) {
                vm.widgetZones = result.data;
            });

            if (vm.isEditMode) {
                carouselWidgetService.getCarouselWidget(vm.widgetInstanceId).then(function (result) {
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