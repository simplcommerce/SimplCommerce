/*global angular*/
(function () {
    angular
        .module('simplAdmin.contact')
        .factory('contactCategoryService', contactCategoryService);

    /* @ngInject */
    function contactCategoryService($http) {
        var service = {
            getContactCategory: getContactCategory,
            createContactCategory: createContactCategory,
            editContactCategory: editContactCategory,
            deleteContactCategory: deleteContactCategory,
            getContactCategories: getContactCategories
        };
        return service;

        function getContactCategory(id) {
            return $http.get('api/contact-categories/' + id);
        }

        function getContactCategories() {
            return $http.get('api/contact-categories');
        }

        function createContactCategory(contactCategory) {
            return $http.post('api/contact-categories', contactCategory);
        }

        function editContactCategory(contactCategory) {
            return $http.put('api/contact-categories/' + contactCategory.id, contactCategory);
        }

        function deleteContactCategory(contactCategory) {
            return $http.delete('api/contact-categories/' + contactCategory.id, null);
        }
    }
})();