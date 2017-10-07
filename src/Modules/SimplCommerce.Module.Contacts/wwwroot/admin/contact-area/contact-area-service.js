/*global angular*/
(function () {
    angular
        .module('simplAdmin.contacts')
        .factory('contactAreaService', contactAreaService);

    /* @ngInject */
    function contactAreaService($http) {
        var service = {
            getContactArea: getContactArea,
            createContactArea: createContactArea,
            editContactArea: editContactArea,
            deleteContactArea: deleteContactArea,
            getContactAreas: getContactAreas
        };
        return service;

        function getContactArea(id) {
            return $http.get('api/contact-area/' + id);
        }

        function getContactAreas() {
            return $http.get('api/contact-area');
        }

        function createContactArea(contactArea) {
            return $http.post('api/contact-area', contactArea);
        }

        function editContactArea(contactArea) {
            return $http.put('api/contact-area/' + contactArea.id, contactArea);
        }

        function deleteContactArea(contactArea) {
            return $http.delete('api/contact-area/' + contactArea.id, null);
        }
    }
})();