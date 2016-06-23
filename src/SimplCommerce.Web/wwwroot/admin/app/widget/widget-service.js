/*global angular*/
(function () {
    angular
        .module('shopAdmin.widget')
        .factory('widgetService', widgetService);

    /* @ngInject */
    function widgetService($http, Upload) {
        var service = {
            getWidgets: getWidgets,
            getWidgetZones: getWidgetZones,
            getWidgetInstances: getWidgetInstances,
            deleteWidgetInstance: deleteWidgetInstance,
            getCarouselWidget: getCarouselWidget,
            createCarouselWidget: createCarouselWidget,
            editCarouselWidget: editCarouselWidget,
            getHtmlWidget: getHtmlWidget,
            createHtmlWidget: createHtmlWidget,
            editHtmlWidget: editHtmlWidget
        };
        return service;

        function getWidgets() {
            return $http.get('Admin/Widget/List');
        }

        function getWidgetZones() {
            return $http.get('Admin/WidgetZone/List');
        }

        function getWidgetInstances() {
            return $http.get('Admin/WidgetInstance/List');
        }

        function deleteWidgetInstance(id) {
            return $http.post('Admin/WidgetInstance/Delete/' + id)
        }

        function getCarouselWidget(id) {
            return $http.get('Admin/CarouselWidget/Get/' + id);
        }

        function createCarouselWidget(widgetInstance) {
            widgetInstance.numberOfItems = widgetInstance.items.length;
            return Upload.upload({
                url: 'Admin/CarouselWidget/Create',
                data: widgetInstance
            });
        }

        function editCarouselWidget(widgetInstance) {
            widgetInstance.numberOfItems = widgetInstance.items.length;
            return Upload.upload({
                url: 'Admin/CarouselWidget/Edit/' + widgetInstance.id,
                data: widgetInstance
            });
        }

        function getHtmlWidget(id) {
            return $http.get('Admin/HtmlWidget/Get/' + id);
        }

        function createHtmlWidget(widgetInstance) {
            return $http.post('Admin/HtmlWidget/Create', widgetInstance);
        }

        function editHtmlWidget(widgetInstance) {
            return $http.post('Admin/HtmlWidget/Edit/' + widgetInstance.id, widgetInstance);
        }
    }
})();