/*global angular*/
(function () {
    angular
        .module('simplAdmin.contacts')
        .controller('ContactAreaTranslationFormCtrl', ['$state', '$stateParams', 'contactAreaService', 'translateService', ContactAreaTranslationFormCtrl]);

    function ContactAreaTranslationFormCtrl($state, $stateParams, contactAreaService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.contactArea = { isPublished: true };
        vm.contactAreaId = $stateParams.id;
        vm.culture = $stateParams.culture;

        vm.save = function save() {
            contactAreaService.editContactAreaTranslation(vm.contactAreaId, vm.culture, vm.contactArea)
                .then(function (result) {
                    $state.go('contact-area');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add contactArea translation.');
                    }
                });
        };

        function init() {
            contactAreaService.getContactAreaTranslation(vm.contactAreaId, vm.culture).then(function (result) {
                vm.contactArea = result.data;
            });
        }

        init();
    }
})();
