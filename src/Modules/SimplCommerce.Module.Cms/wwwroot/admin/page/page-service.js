/*global angular*/
(function () {
    angular
        .module('simplAdmin.cms')
        .factory('pageService', pageService);

    /* @ngInject */
    function pageService($http) {
        var service = {
            getPage: getPage,
            createPage: createPage,
            editPage: editPage,
            deletePage: deletePage,
            getPages: getPages
        };
        return service;

        function getPage(id) {
            return $http.get('api/pages/' + id);
        }

        function getPages() {
            return $http.get('api/pages');
        }

        function createPage(page) {
            return $http.post('api/pages', page);
        }

        function editPage(page) {
            return $http.put('api/pages/' + page.id, page);
        }

        function deletePage(page) {
            return $http.delete('api/pages/' + page.id, null);
        }
    }
})();