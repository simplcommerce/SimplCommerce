/*global angular*/
(function () {
    angular
        .module('simplAdmin.cms')
        .factory('htmlWidgetService', widgetService);

    /* @ngInject */
    function widgetService($http) {
        var service = {
            getWidgetZones: getWidgetZones,
            getHtmlWidget: getHtmlWidget,
            createHtmlWidget: createHtmlWidget,
            editHtmlWidget: editHtmlWidget
        };
        return service;

        function getWidgetZones() {
            return $http.get('api/widget-zones');
        }

        function getHtmlWidget(id) {
            return $http.get('api/html-widgets/' + id);
        }

        function createHtmlWidget(widgetInstance) {
            return $http.post('api/html-widgets', widgetInstance);
        }

        function editHtmlWidget(widgetInstance) {
            return $http.put('api/html-widgets/' + widgetInstance.id, widgetInstance);
        }
    }
})();