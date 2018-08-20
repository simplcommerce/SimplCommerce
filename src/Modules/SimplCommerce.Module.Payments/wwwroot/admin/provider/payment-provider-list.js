/*global angular, confirm*/
(function () {
    angular
        .module('simplAdmin.payments')
        .controller('PaymentProviderListCtrl', PaymentProviderListCtrl);

    /* @ngInject */
    function PaymentProviderListCtrl(paymentProviderService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.paymentProviders = [];

        function getPaymentProviders() {
            paymentProviderService.getPaymentProviders().then(function (result) {
                vm.paymentProviders = result.data;
            });
        }

        vm.enableProvider = function enableProvider(provider) {
            bootbox.confirm('Are you sure you want to enable this ' + provider.name + ' provider', function (result) {
                if (result) {
                    paymentProviderService.enableProvider(provider)
                        .then(function (result) {
                            provider.isEnabled = true;
                            toastr.success(provider.name + 'Have been enabled');
                        })
                        .catch(function (response) {
                            toastr.error(response.data.error);
                        });
                }
            });
        };

        vm.disableProvider = function disableProvider(provider) {
            bootbox.confirm('Are you sure you want to disable this ' + provider.name + ' provider', function (result) {
                if (result) {
                    paymentProviderService.disableProvider(provider)
                        .then(function (result) {
                            provider.isEnabled = false;
                            toastr.success(provider.name + ' has been disabled');
                        })
                        .catch(function (response) {
                            toastr.error(response.data.error);
                        });
                }
            });
        };

        function init() {
            getPaymentProviders();
        }

        init();
    }
})();