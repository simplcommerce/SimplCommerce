/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .factory('themeService', themeService);

    /* @ngInject */
    function themeService($http) {
        var service = {
            getThemes: getThemes,
            useTheme: useTheme
        };
        return service;

        function getThemes() {
            return $http.get('api/themes');
        }

        function useTheme(theme) {
            return $http.post('api/themes/use-theme', theme);
        }
    }
})();