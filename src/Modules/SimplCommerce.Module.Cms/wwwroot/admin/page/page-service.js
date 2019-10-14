/*global angular*/
(function () {
    angular
        .module('simplAdmin.cms')
        .factory('pageService', ['$http', pageService]);

    function pageService($http) {
        var service = {
            getPage: getPage,
            createPage: createPage,
            editPage: editPage,
            deletePage: deletePage,
            getPages: getPages,
            getPageTranslation: getPageTranslation,
            editPageTranslation: editPageTranslation
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

        function getPageTranslation(id, culture) {
            return $http.get('api/page-translations/' + id + '?culture=' + culture);
        }

        function editPageTranslation(id, culture, model) {
            return $http.put('api/page-translations/' + id + '?culture=' + culture, model);
        }
    }
})();
