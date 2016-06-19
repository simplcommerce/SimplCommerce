/*global angular, confirm*/
(function () {
    angular
        .module('shopAdmin.widget')
        .controller('WidgetInstanceListCtrl', WidgetInstanceListCtrl);

    /* @ngInject */
    function WidgetInstanceListCtrl(widgetService) {
        var vm = this;
        vm.widgets = [];
        vm.widgetInstances = [];

        vm.deleteWidgetInstance = function deleteWidgetInstance(widgetInstance) {
            if (confirm("Are you sure?")) {
                widgetService.deleteWidgetInstance(widgetInstance).then(function (result) {
                    getWidgetInstances();
                });
            }
        };

        function getWidgets() {
            widgetService.getWidgets().then(function (result) {
                vm.widgets = result.data;
            });
        }

        function getWidgetInstances() {
            widgetService.getWidgetInstances().then(function (result) {
                vm.widgetInstances = result.data;
            });
        }

        function init() {
            getWidgets();
            getWidgetInstances();
        }

        init();
    }
})();