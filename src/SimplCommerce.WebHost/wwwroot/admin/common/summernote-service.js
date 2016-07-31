/*global angular, FormData*/
(function () {
    angular
        .module('simplAdmin.common')
        .factory('summerNoteService', summerNoteService);

    /* @ngInject */
    function summerNoteService($http) {
        var service = {
            upload : upload
        };
        return service;

        function upload(file) {
            var data = new FormData();
            data.append("file", file);
            return $http.post('Common/UploadFile', data, {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            });
        }
    }
})();