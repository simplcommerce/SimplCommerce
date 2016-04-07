/*global angular*/
(function () {
    angular
        .module('shopAdmin.manufacturer')
        .factory('manufacturerService', manufacturerService);

    /* @ngInject */
    function manufacturerService($http) {
        var service = {
            getManufacturer: getManufacturer,
            createManufacturer: createManufacturer,
            editManufacturer: editManufacturer,
            deleteManufacturer: deleteManufacturer,
            getManufacturers: getManufacturers
        };
        return service;

        function getManufacturer(id) {
            return $http.get('Admin/Manufacturer/Get/' + id);
        }

        function getManufacturers() {
            return $http.get('Admin/Manufacturer/List');
        }

        function createManufacturer(manufacturer) {
            return $http.post('Admin/Manufacturer/Create', manufacturer);
        }

        function editManufacturer(manufacturer) {
            return $http.post('Admin/Manufacturer/Edit/' + manufacturer.id, manufacturer);
        }

        function deleteManufacturer(manufacturer) {
            return $http.post('Admin/Manufacturer/Delete/' + manufacturer.id, null);
        }
    }
})();