(function () {
    angular
        .module('simplAdmin.recentlyViewedProducts')
        .factory('recentlyViewedProductsService', recentlyViewedProductsService);

    /* @ngInject */
    function recentlyViewedProductsService($http) {
        var service = {
            getRecentlyViewedEntities: getRecentlyViewedEntities
        };
        return service;

        function getRecentlyViewedEntities(entityTypeId) {
            return $http.get('api/recentlyviewedproducts/recently-viewed-entities/' + entityTypeId);
        }
    }
})();