/*global angular, confirm*/
(function () {
    angular
        .module('simplAdmin.core')
        .controller('WidgetInstanceListCtrl', WidgetInstanceListCtrl);

    /* @ngInject */
    function WidgetInstanceListCtrl(widgetService) {
        var vm = this;
        vm.widgets = [];
        vm.widgetInstances = [];

        vm.deleteWidgetInstance = function deleteWidgetInstance(widgetInstance) {
            bootbox.confirm('Are you sure you want to delete this widget: ' + widgetInstance.name, function (result) {
                if (result) {
                    widgetService.deleteWidgetInstance(widgetInstance.id)
                       .then(function (result) {
                           getWidgetInstances();
                           toastr.success(widgetInstance.name + ' has been deleted')
                       })
                       .catch(function (error) {
                           toastr.error(error.data.error);
                       });
                }
            });
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