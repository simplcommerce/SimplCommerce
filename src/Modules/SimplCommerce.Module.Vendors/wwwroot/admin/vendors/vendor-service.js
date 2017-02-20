/*global angular*/
(function () {
    angular
        .module('simplAdmin.vendors')
        .factory('vendorService', vendorService);

    /* @ngInject */
    function vendorService($http) {
        var service = {
            getVendors: getVendors
        };
        return service;

        function getVendors(params) {
            return $http.post('api/vendors/grid', params);
        }
    }
})();