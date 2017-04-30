(function () {
    'use strict';

    angular
        .module('app')
        .factory('recentlyviewedproducts_service', recentlyviewedproducts_service);

    recentlyviewedproducts_service.$inject = ['$http'];

    function recentlyviewedproducts_service($http) {
        var service = {
            getData: getData
        };

        return service;

        function getData() { }
    }
})();