/*global angular*/
(function () {
    angular
        .module('simplAdmin.search')
        .factory('searchService', searchService);

    /* @ngInject */
    function searchService($http) {
        var service = {
            getMostSearchKeywords: getMostSearchKeywords
        };
        return service;

        function getMostSearchKeywords() {
            return $http.get('api/search/most-search-keywords');
        }
    }
})();