/*global angular*/
(function () {
    angular
        .module('simplAdmin.cms')
        .factory('spacebarWidgetService', spacebarWidgetService);

    /* @ngInject */
    function spacebarWidgetService($http, Upload) {
        var service = {
            getWidgetZones: getWidgetZones,
            getSpaceBarWidget: getSpaceBarWidget,
            createSpaceBarWidget: createSpaceBarWidget,
            editSpaceBarWidget: editSpaceBarWidget,
            getNumberOfWidgets: getNumberOfWidgets
        };

        return service;

        function getWidgetZones() {
            return $http.get('api/widget-zones');
        }

        function getSpaceBarWidget(id) {
            return $http.get('api/spacebar-widgets/' + id);
        }

        function createSpaceBarWidget(widgetInstance) {
            widgetInstance.numberOfItems = widgetInstance.items.length;
            return Upload.upload({
                url: 'api/spacebar-widgets',
                data: widgetInstance
            });
        }

        function editSpaceBarWidget(widgetInstance) {
            widgetInstance.numberOfItems = widgetInstance.items.length;
            return Upload.upload({
                url: 'api/spacebar-widgets/' + widgetInstance.id,
                data: widgetInstance,
                method: 'PUT'
            });
        }

        function getNumberOfWidgets() {
            return $http.get('api/widget-instances/number-of-widgets');
        }
    }
})();