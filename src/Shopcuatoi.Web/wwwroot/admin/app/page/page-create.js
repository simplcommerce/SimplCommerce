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
            pageService.createPage(vm.page).then(function (result) {
                $state.go('page');
            });
        };
    }
})(jQuery);