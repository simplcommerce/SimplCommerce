/*global angular*/
(function () {
    angular
        .module('simplAdmin.activityLog')
        .factory('activityLogService', ['$http', activityLogService]);

    function activityLogService($http) {
        var service = {
            getMostViewedEntities: getMostViewedEntities
        };
        return service;

        function getMostViewedEntities(entityTypeId) {
            return $http.get('api/activitylog/most-viewed-entities/' + entityTypeId);
        }
    }
})();
