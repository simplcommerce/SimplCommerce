/*global angular*/
(function () {
    angular
        .module('simplAdmin.cms')
        .controller('PageTranslationFormCtrl', PageTranslationFormCtrl);

    /* @ngInject */
    function PageTranslationFormCtrl($state, $stateParams, summerNoteService, pageService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.page = {};
        vm.pageId = $stateParams.id;
        vm.culture = $stateParams.culture;

        vm.imageUpload = function (files) {
            summerNoteService.upload(files[0])
                .then(function (response) {
                    $(vm.body).summernote('insertImage', response.data);
                });
        };

        vm.save = function save() {
            pageService.editPageTranslation(vm.pageId, vm.culture, vm.page)
                .then(function (result) {
                    $state.go('page');
                    })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add page translation.');
                    }
                });
        };

        function init() {
            pageService.getPageTranslation(vm.pageId, vm.culture).then(function (result) {
                vm.page = result.data;
            });
        }

        init();
    }
})();
