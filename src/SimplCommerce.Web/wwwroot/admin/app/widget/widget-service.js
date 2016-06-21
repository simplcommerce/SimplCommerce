/*global angular*/
(function () {
    angular
        .module('shopAdmin.widget')
        .factory('widgetService', widgetService);

    /* @ngInject */
    function widgetService($http, Upload) {
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
            widgetInstance.numberOfItems = widgetInstance.items.length;
            return Upload.upload({
                url: 'Admin/CarouselWidget/Create',
                data: widgetInstance
            });
        }

        function editCarousel(widgetInstance) {
            widgetInstance.numberOfItems = widgetInstance.items.length;
            return Upload.upload({
                url: 'Admin/CarouselWidget/Edit/' + widgetInstance.id,
                data: widgetInstance
            });
        }
    }
})();