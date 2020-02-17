/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .factory('productWidgetService', ['$http', productWidgetService]);

    /* @ngInject */
    function productWidgetService($http) {
        var service = {
            getWidgetZones: getWidgetZones,
            getProductWidget: getProductWidget,
            createProductWidget: createProductWidget,
            editProductWidget: editProductWidget,
            getProductWidgetAvailableOrderBy: getProductWidgetAvailableOrderBy,
            getNumberOfWidgets: getNumberOfWidgets
        };
        return service;

        function getWidgetZones() {
            return $http.get('api/widget-zones');
        }

        function getProductWidget(id) {
            return $http.get('api/product-widgets/' + id);
        }

        function createProductWidget(widgetInstance) {
            return $http.post('api/product-widgets', widgetInstance);
        }

        function editProductWidget(widgetInstance) {
            return $http.put('api/product-widgets/' + widgetInstance.id, widgetInstance);
        }

        function getProductWidgetAvailableOrderBy() {
            return $http.get('api/product-widgets/available-orderby');
        }

        function getNumberOfWidgets() {
            return $http.get('api/widget-instances/number-of-widgets');
        }
    }
})();
