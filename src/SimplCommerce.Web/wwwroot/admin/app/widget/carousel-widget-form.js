/*global angular, jQuery*/
(function ($) {
    angular
        .module('shopAdmin.widget')
        .controller('CarouselWidgetFormCtrl', CarouselWidgetFormCtrl);

    /* @ngInject */
    function CarouselWidgetFormCtrl($state, $stateParams, widgetService) {
        var vm = this;
        vm.widgetInstance = {zone : 1, items: [{}] };
        vm.widgetZones = [];
        vm.widgetInstanceId = $stateParams.id;
        vm.isEditMode = vm.widgetInstanceId > 0;

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
                promise = widgetService.editCarouselWidget(vm.widgetInstance);
            } else {
                promise = widgetService.createCarouselWidget(vm.widgetInstance);
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

            widgetService.getWidgetZones().then(function (result) {
                vm.widgetZones = result.data;
            });

            if (vm.isEditMode) {
                widgetService.getCarouselWidget(vm.widgetInstanceId).then(function (result) {
                    vm.widgetInstance = result.data;
                });
            }
        }

        init();
    }
})(jQuery);