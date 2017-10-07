/*global angular*/
(function () {
    angular
        .module('simplAdmin.localization')
        .factory('localizationService', localizationService);

    /* @ngInject */
    function localizationService($http) {
        var service = {
            getCultures: getCultures,
            getResources: getResources,
            updateResources: updateResources
        };
        return service;

        function getCultures() {
            return $http.get('api/localization/get-cultures');
        }

        function getResources(cultureId) {
            return $http.get('api/localization/get-resources?cultureId=' + cultureId);
        }

        function updateResources(cultureId, resources) {
            return $http.post('api/localization/update-resources?cultureId=' + cultureId, resources);
        }
    }
})();