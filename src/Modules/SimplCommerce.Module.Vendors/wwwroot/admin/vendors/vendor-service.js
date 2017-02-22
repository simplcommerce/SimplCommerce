/*global angular*/
(function () {
    angular
        .module('simplAdmin.vendors')
        .factory('vendorService', vendorService);

    /* @ngInject */
    function vendorService($http) {
        var service = {
            getVendors: getVendors,
            getVendor: getVendor,
            createVendor: createVendor,
            editVendor: editVendor,
            deleteVendor: deleteVendor
        };
        return service;

        function getVendors(params) {
            return $http.post('api/vendors/grid', params);
        }

        function getVendor(id) {
            return $http.get('api/vendors/' + id);
        }

        function createVendor(vendor) {
            return $http.post('api/vendors', vendor);
        }

        function editVendor(vendor) {
            return $http.put('api/vendors/' + vendor.id, vendor);
        }

        function deleteVendor(vendor) {
            return $http.delete('api/vendors/' + vendor.id, null);
        }
    }
})();