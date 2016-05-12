/*global angular, jQuery*/
(function ($) {
    angular
        .module('shopAdmin.page')
        .controller('PageEditCtrl', PageEditCtrl);

    /* @ngInject */
    function PageEditCtrl($state, $stateParams, summerNoteService, pageService) {
        var vm = this;
        vm.page = {};
        vm.isEditMode = true;

        vm.imageUpload = function (files) {
            summerNoteService.upload(files[0])
                .success(function (url) {
                    $(vm.body).summernote('insertImage', url);
                });
        };

        vm.save = function save() {
            pageService.editPage(vm.page)
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

        function init() {
            pageService.getPage($stateParams.id).then(function (result) {
                vm.page = result.data;
            });
        }

        init();
    }
})(jQuery);