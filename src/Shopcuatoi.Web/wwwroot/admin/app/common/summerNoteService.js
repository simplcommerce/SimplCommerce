(function () {
    angular
        .module('shopAdmin.common')
        .factory('summerNoteService', [
            '$http',
            function ($http) {
                function upload(file) {
                    var data = new FormData();
                    data.append("file", file);
                    return $http.post('Common/UploadFile', data, {
                        transformRequest: angular.identity,
                        headers: { 'Content-Type': undefined }
                    })
                }

                return {
                    upload: upload
                };
            }
        ]);
})();