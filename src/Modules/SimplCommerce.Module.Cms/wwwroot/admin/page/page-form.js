/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.cms')
        .controller('PageFormCtrl', PageFormCtrl);

    /* @ngInject */
    function PageFormCtrl($state, $stateParams, summerNoteService, pageService) {
        var vm = this;
        vm.page = {};
        vm.pageId = $stateParams.id;
        vm.isEditMode = vm.pageId > 0;

        vm.imageUpload = function (files) {
            summerNoteService.upload(files[0])
                .success(function (url) {
                    $(vm.body).summernote('insertImage', url);
                });
        };

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = pageService.editPage(vm.page);
            } else {
                promise = pageService.createPage(vm.page);
            }

            promise
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
            if (vm.isEditMode) {
                pageService.getPage(vm.pageId).then(function (result) {
                    vm.page = result.data;
                });
            }
        }

        init();
    }
})(jQuery);