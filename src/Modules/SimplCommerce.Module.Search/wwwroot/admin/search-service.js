/*global angular*/
(function () {
    angular
        .module('simplAdmin.search')
        .factory('searchService', ['$http', searchService]);

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
