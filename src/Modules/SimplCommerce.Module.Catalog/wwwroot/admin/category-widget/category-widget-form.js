/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.catalog')
        .controller('CategoryWidgetFormCtrl', CategoryWidgetFormCtrl);

    /* @ngInject */
    function CategoryWidgetFormCtrl($state, $stateParams, categoryWidgetService , translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.widgetZones = [];
        vm.categories = [];
        vm.widgetInstance = { widgetZoneId: 1, settings: { categoryId: 1 }, publishStart: new Date() };
        vm.widgetInstanceId = $stateParams.id;
        vm.isEditMode = vm.widgetInstanceId > 0;
        vm.numberOfWidgets = [];

        vm.datePickerPublishStart = {};
        vm.datePickerPublishEnd = {};

        vm.openCalendar = function (e, picker) {
            vm[picker].open = true;
        };

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = categoryWidgetService.editCategoryWidget(vm.widgetInstance);
            } else {
                promise = categoryWidgetService.createCategoryWidget(vm.widgetInstance);
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
                        vm.validationErrors.push('Could not product display widget.');
                    }
                });
        };

        function init() {
            categoryWidgetService.getWidgetZones().then(function (result) {
                vm.widgetZones = result.data;
            });
            categoryWidgetService.getCategories().then(function (result) {
                vm.categories = result.data;
            });

            categoryWidgetService.getNumberOfWidgets().then(function (result) {
                var count = parseInt(result.data);
                if (!vm.isEditMode) {
                    count = count + 1;
                }

                for (var i = 1; i <= count; i++)
                    vm.numberOfWidgets.push(i);
            });

            if (vm.isEditMode) {
                categoryWidgetService.getCategoryWidget(vm.widgetInstanceId).then(function (result) {
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