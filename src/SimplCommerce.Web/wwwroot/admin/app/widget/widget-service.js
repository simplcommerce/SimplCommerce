/*global angular*/
(function () {
    angular
        .module('shopAdmin.widget')
        .factory('widgetService', widgetService);

    /* @ngInject */
    function widgetService($http) {
        var service = {
            getWidgets : getWidgets,
            getWidgetInstances : getWidgetInstances,
            getCarousel : getCarousel,
            createCarousel : createCarousel,
            editCarousel : editCarousel
        };
        return service;

        function getWidgets() {
            return $http.get('Admin/Widget/List');
        }

        function getWidgetInstances() {
            return $http.get('Admin/WidgetInstance/List');
        }

        function getCarousel(id) {
            return $http.get('Admin/CarouselWidget/Get/' + id);
        }

        function createCarousel(widgetInstance) {
            return $http.post('Admin/CarouselWidget/Create', widgetInstance);
        }

        function editCarousel(widgetInstance) {
            return $http.post('Admin/CarouselWidget/Edit/' + widgetInstance.id, widgetInstance);
        }
    }
})();