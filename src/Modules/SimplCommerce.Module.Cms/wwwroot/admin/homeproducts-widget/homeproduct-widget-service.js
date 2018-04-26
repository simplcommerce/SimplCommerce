/*global angular*/
(function () {
    angular
        .module('simplAdmin.cms')
        .factory('homeproductWidgetService', homeproductWidgetService);

    /* @ngInject */
    function homeproductWidgetService($http, Upload) {
        var service = {
            getWidgetZones: getWidgetZones,
            getHomeProductWidget: getHomeProductWidget,
            createHomeProductWidget: createHomeProductWidget,
            editHomeProductWidget: editHomeProductWidget,
            getNumberOfWidgets: getNumberOfWidgets
        };

        return service;

        function getWidgetZones() {
            return $http.get('api/widget-zones');
        }

        function getHomeProductWidget(id) {
            return $http.get('api/homeproduct-widgets/' + id);
        }
        
        function createHomeProductWidget(widgetInstance) {
            widgetInstance.numberOfItems = widgetInstance.settings.productIds.length;
            return Upload.upload({
                url: 'api/homeproduct-widgets',
                data: widgetInstance
            });
        }

        function editHomeProductWidget(widgetInstance) {
            widgetInstance.numberOfItems = widgetInstance.settings.productIds.length;

            return Upload.upload({
                url: 'api/homeproduct-widgets/' + widgetInstance.id,
                data: widgetInstance,
                method: 'PUT'
            });
        }

        function getNumberOfWidgets() {
            return $http.get('api/widget-instances/number-of-widgets');
        }
    }
})();