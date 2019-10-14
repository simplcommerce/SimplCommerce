/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .controller('ProductTranslationFormCtrl', ['$state', '$stateParams', 'summerNoteService', 'productService', 'translateService', ProductTranslationFormCtrl]);

    function ProductTranslationFormCtrl($state, $stateParams, summerNoteService, productService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.product = {};
        vm.productId = $stateParams.id;
        vm.culture = $stateParams.culture;

        vm.shortDescUpload = function (files) {
            summerNoteService.upload(files[0])
                .then(function (response) {
                    $(vm.shortDescEditor).summernote('insertImage', response.data);
                });
        };

        vm.descUpload = function (files) {
            summerNoteService.upload(files[0])
                .then(function (response) {
                    $(vm.descEditor).summernote('insertImage', response.data);
                });
        };

        vm.specUpload = function (files) {
            summerNoteService.upload(files[0])
                .then(function (response) {
                    $(vm.specEditor).summernote('insertImage', response.data);
                });
        };

        vm.save = function save() {
            productService.editProductTranslation(vm.productId, vm.culture, vm.product)
                .then(function (result) {
                    $state.go('product');
                    })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add product translation.');
                    }
                });
        };

        function init() {
            productService.getProductTranslation(vm.productId, vm.culture).then(function (result) {
                vm.product = result.data;
            });
        }

        init();
    }
})();
