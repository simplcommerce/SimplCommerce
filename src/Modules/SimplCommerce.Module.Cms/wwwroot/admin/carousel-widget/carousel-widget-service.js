/*global angular*/
(function () {
    angular
        .module('simplAdmin.cms')
        .factory('carouselWidgetService', widgetService);

    /* @ngInject */
    function widgetService($http, Upload) {
        var service = {
            getWidgetZones: getWidgetZones,
            getCarouselWidget: getCarouselWidget,
            createCarouselWidget: createCarouselWidget,
            editCarouselWidget: editCarouselWidget
        };
        return service;

        function getWidgetZones() {
            return $http.get('api/widget-zones');
        }

        function getCarouselWidget(id) {
            return $http.get('api/carousel-widgets/' + id);
        }

        function createCarouselWidget(widgetInstance) {
            widgetInstance.numberOfItems = widgetInstance.items.length;
            return Upload.upload({
                url: 'api/carousel-widgets',
                data: widgetInstance
            });
        }

        function editCarouselWidget(widgetInstance) {
            widgetInstance.numberOfItems = widgetInstance.items.length;
            return Upload.upload({
                url: 'api/carousel-widgets/' + widgetInstance.id,
                data: widgetInstance,
                method: 'PUT'
            });
        }
    }
})();