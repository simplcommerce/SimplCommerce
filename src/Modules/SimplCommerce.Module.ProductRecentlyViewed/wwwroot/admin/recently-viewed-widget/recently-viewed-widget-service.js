/*global angular*/
(function () {
    angular
        .module('simplAdmin.recentlyViewed')
        .factory('recentlyViewedWidgetService', recentlyViewedWidgetService);

    /* @ngInject */
    function recentlyViewedWidgetService($http) {
        var service = {
            getWidgetZones: getWidgetZones,
            getRecentlyViewedWidget: getRecentlyViewedWidget,
            createRecentlyViewedWidget: createRecentlyViewedWidget,
            editRecentlyViewedWidget: editRecentlyViewedWidget,
            getNumberOfWidgets: getNumberOfWidgets
        };
        return service;

        function getWidgetZones() {
            return $http.get('api/widget-zones');
        }

        function getRecentlyViewedWidget(id) {
            return $http.get('api/recently-viewed-widgets/' + id);
        }

        function createRecentlyViewedWidget(widgetInstance) {
            return $http.post('api/recently-viewed-widgets', widgetInstance);
        }

        function editRecentlyViewedWidget(widgetInstance) {
            return $http.put('api/recently-viewed-widgets/' + widgetInstance.id, widgetInstance);
        }

        function getNumberOfWidgets() {
            return $http.get('api/widget-instances/number-of-widgets');
        }
    }
})();