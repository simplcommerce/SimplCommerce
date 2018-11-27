/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .factory('widgetService', widgetService);

    /* @ngInject */
    function widgetService($http) {
        var service = {
            getWidgets: getWidgets,
            getWidgetInstances: getWidgetInstances,
            deleteWidgetInstance: deleteWidgetInstance
        };
        return service;

        function getWidgets() {
            return $http.get('api/widgets');
        }

        function getWidgetInstances() {
            return $http.get('api/widget-instances');
        }

        function deleteWidgetInstance(id) {
            return $http.delete('api/widget-instances/' + id);
        }
    }
})();
