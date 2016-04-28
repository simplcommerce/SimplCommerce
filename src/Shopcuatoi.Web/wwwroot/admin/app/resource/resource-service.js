/*global angular*/
(function () {
    angular
        .module('shopAdmin.resource')
        .factory('resourceService', resourceService);

    /* @ngInject */
    function resourceService($http) {
        var service = {
            getResource: getResource,
            editResource: editResource,
            getResources: getResources
        };
        return service;

        function getResource(id) {
            return $http.get('Admin/Resource/Get/' + id);
        }

        function getResources(params) {
            return $http.post('Admin/Resource/List', params);
        }

        function editResource(resource) {
            return $http.post('Admin/Resource/Edit/' + resource.id, resource);
        }
    }
})();