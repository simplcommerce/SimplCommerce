/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .factory('simpleProductWidgetService', simpleProductWidgetService);

    /* @ngInject */
    function simpleProductWidgetService($http, Upload) {
        var service = {
            getWidgetZones: getWidgetZones,
            getSimpleProductWidget: getSimpleProductWidget,
            createSimpleProductWidget: createSimpleProductWidget,
            editSimpleProductWidget: editSimpleProductWidget
        };

        return service;

        function getWidgetZones() {
            return $http.get('api/widget-zones');
        }

        function getSimpleProductWidget(id) {
            return $http.get('api/simple-product-widgets/' + id);
        }
        
        function createSimpleProductWidget(widgetInstance) {
            return $http.post('api/simple-product-widgets', widgetInstance);
        }

        function editSimpleProductWidget(widgetInstance) {
            return $http.put('api/simple-product-widgets/' + widgetInstance.id, widgetInstance);
        }
    }
})();