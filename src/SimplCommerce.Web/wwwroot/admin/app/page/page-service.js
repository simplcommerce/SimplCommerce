/*global angular*/
(function () {
    angular
        .module('shopAdmin.page')
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
            return $http.get('Admin/Page/Get/' + id);
        }

        function getPages() {
            return $http.get('Admin/Page/List');
        }

        function createPage(page) {
            return $http.post('Admin/Page/Create', page);
        }

        function editPage(page) {
            return $http.post('Admin/Page/Edit/' + page.id, page);
        }

        function deletePage(page) {
            return $http.post('Admin/Page/Delete/' + page.id, null);
        }
    }
})();