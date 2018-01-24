/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .factory('stateProvinceService', stateProvinceService);

    /* @ngInject */
    function stateProvinceService($http) {
        var service = {
            editStateProvince: editStateProvince,
            getStateProvince: getStateProvince,
            createStateProvince: createStateProvince,
            deleteStateProvince: deleteStateProvince,
            getStateOrProvinces: getStateOrProvinces
        };
        return service;

        function getStateOrProvinces(countryId, params) {
            return $http.post('api/states-provinces/grid?countryId=' + countryId, params);
        }

        function getStateProvince(id) {
            return $http.get('api/states-provinces/' + id, null);
        }

        function editStateProvince(stateProvince) {
            return $http.put('api/states-provinces/' + stateProvince.id, stateProvince);
        }

        function createStateProvince(stateProvince) {
            return $http.post('api/states-provinces/', stateProvince);
        }

        function deleteStateProvince(stateProvince) {
            return $http.delete('api/states-provinces/' + stateProvince.id, null);
        }
    }
})();