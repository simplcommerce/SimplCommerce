/*global angular, jQuery*/
(function ($) {
    angular
        .module('shopAdmin.page')
        .controller('PageCreateCtrl', PageCreateCtrl);

    /* @ngInject */
    function PageCreateCtrl($state, summerNoteService, pageService) {
        var vm = this;

        vm.page = {};

        vm.imageUpload = function (files) {
            summerNoteService.upload(files[0])
                .success(function (url) {
                    $(vm.body).summernote('insertImage', url);
                });
        };

        vm.save = function save() {
            pageService.createPage(vm.page)
                .success(function (result) {
                    $state.go('page');
                })
                .error(function (error) {
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add page.');
                    }
                });
        };
    }
})(jQuery);