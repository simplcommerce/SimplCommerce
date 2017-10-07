/*global angular*/
(function () {
    angular
        .module('simplAdmin.contacts')
        .factory('contactService', contactService);

    /* @ngInject */
    function contactService($http) {
        var service = {
            getContact: getContact,
            deleteContact: deleteContact,
            getContacts: getContacts
        };
        return service;

        function getContact(id) {
            return $http.get('api/contacts/' + id);
        }

        function getContacts(params) {
            return $http.post('api/contacts/grid',params);
        }        

        function deleteContact(contact) {
            return $http.delete('api/contacts/' + contact.id, null);
        }
    }
})();