/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .factory('categoryWidgetService', categoryWidgetService);

    /* @ngInject */
    function categoryWidgetService($http) {
        var service = {
            getWidgetZones: getWidgetZones,
            getCategories: getCategories,
            getCategoryWidget: getCategoryWidget,
            createCategoryWidget: createCategoryWidget,
            editCategoryWidget: editCategoryWidget,
        };
        return service;

        function getWidgetZones() {
            return $http.get('api/widget-zones');
        }

        function getCategoryWidget(id) {
            return $http.get('api/category-widgets/' + id);
        }

        function createCategoryWidget(widgetInstance) {
            return $http.post('api/category-widgets', widgetInstance);
        }

        function editCategoryWidget(widgetInstance) {
            return $http.put('api/category-widgets/' + widgetInstance.id, widgetInstance);
        }

        function getCategories() {
            return $http.get('api/categories');
        }
    }
})();