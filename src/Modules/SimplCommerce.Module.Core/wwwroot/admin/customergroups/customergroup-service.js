/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .factory('customergroupService', ['$http', customergroupService]);

    function customergroupService($http) {
        var service = {
            getCustomerGroups: getCustomerGroups,
            getCustomerGroup: getCustomerGroup,
            createCustomerGroup: createCustomerGroup,
            editCustomerGroup: editCustomerGroup,
            deleteCustomerGroup: deleteCustomerGroup
        };
        return service;

        function getCustomerGroups(params) {
            return $http.post('api/customergroups/grid', params);
        }

        function getCustomerGroup(id) {
            return $http.get('api/customergroups/' + id);
        }

        function createCustomerGroup(customergroup) {
            return $http.post('api/customergroups', customergroup);
        }

        function editCustomerGroup(customergroup) {
            return $http.put('api/customergroups/' + customergroup.id, customergroup);
        }

        function deleteCustomerGroup(customergroup) {
            return $http.delete('api/customergroups/' + customergroup.id, null);
        }
    }
})();
