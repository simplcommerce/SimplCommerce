/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.recentlyViewed')
        .controller('RecentlyViewedWidgetFormCtrl', ['$state', '$stateParams', 'recentlyViewedWidgetService', 'translateService', RecentlyViewedWidgetFormCtrl]);

    function RecentlyViewedWidgetFormCtrl($state, $stateParams, recentlyViewedWidgetService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.widgetZones = [];
        vm.widgetInstance = { widgetZoneId: 1, publishStart : new Date() };
        vm.widgetInstanceId = $stateParams.id;
        vm.isEditMode = vm.widgetInstanceId > 0;

        vm.datePickerPublishStart = {};
        vm.datePickerPublishEnd = {};
        vm.numberOfWidgets = [];

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = recentlyViewedWidgetService.editRecentlyViewedWidget(vm.widgetInstance);
            } else {
                promise = recentlyViewedWidgetService.createRecentlyViewedWidget(vm.widgetInstance);
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
                        vm.validationErrors.push('Could not html widget.');
                    }
                });
        };

        function init() {
            recentlyViewedWidgetService.getWidgetZones().then(function (result) {
                vm.widgetZones = result.data;
            });

            recentlyViewedWidgetService.getNumberOfWidgets().then(function (result) {
                var count = parseInt(result.data);
                if (!vm.isEditMode) {
                    count = count + 1;
                }

                for (var i = 1; i <= count; i++)
                    vm.numberOfWidgets.push(i);
            });

            if (vm.isEditMode) {
                recentlyViewedWidgetService.getRecentlyViewedWidget(vm.widgetInstanceId).then(function (result) {
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
