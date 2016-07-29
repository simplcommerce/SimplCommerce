/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .factory('userService', userService);

    /* @ngInject */
    function userService($http) {
        var service = {
            getUsers : getUsers
        };
        return service;

        function getUsers(params) {
            return $http.post('api/users/grid', params);
        }
    }
})();