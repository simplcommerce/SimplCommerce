/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .factory('themeService', ['$http', themeService]);

    function themeService($http) {
        var service = {
            getThemes: getThemes,
            useTheme: useTheme,
            deleteTheme: deleteTheme,
            getOnlineThemes: getOnlineThemes,
            getThemeDetails: getThemeDetails,
            installTheme: installTheme
        };
        return service;

        function getThemes() {
            return $http.get('api/themes');
        }

        function useTheme(theme) {
            return $http.post('api/themes/use-theme', theme);
        }

        function deleteTheme(themeName) {
            return $http.delete('api/themes/' + themeName);
        }

        function getOnlineThemes() {
            return $http.get('api/online-themes');
        }

        function getThemeDetails(name) {
            return $http.get('api/online-themes/' + name);
        }

        function installTheme(name) {
            return $http.put('/api/online-themes/' + name + '/install');
        }
    }
})();
