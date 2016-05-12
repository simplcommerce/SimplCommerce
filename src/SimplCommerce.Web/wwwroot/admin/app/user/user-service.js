/*global angular*/
(function () {
    angular
        .module('shopAdmin.user')
        .factory('userService', userService);

    /* @ngInject */
    function userService($http) {
        var service = {
            getUsers : getUsers
        };
        return service;

        function getUsers(params) {
            return $http.post('Admin/User/List', params);
        }
    }
})();