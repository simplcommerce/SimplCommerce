/*global angular, jQuery*/
(function ($) {
    angular
        .module('shopAdmin.product')
        .controller('ProductFormCtrl', ProductFormCtrl);

    /* @ngInject */
    function ProductFormCtrl($state, $stateParams, $http, categoryService, productService, summerNoteService, brandService) {
        var vm = this;
        // declare shoreDescription and description for summernote
        vm.product = { shortDescription: '', description: '', specification: '' };
        vm.product.categoryIds = [];
        vm.product.options = [];
        vm.product.variations = [];
        vm.product.attributes = [];
        vm.categories = [];
        vm.thumbnailImage = null;
        vm.productImages = [];
        vm.options = [];
        vm.productTemplates = [];
        vm.addingOption = null;
        vm.attributes = [];
        vm.addingAttribute = null;
        vm.productId = $stateParams.id;
        vm.isEditMode = vm.productId > 0;
        vm.addingVariation = { priceOffset: 0 };
        vm.brands = [];

        vm.shortDescUpload = function (files) {
            summerNoteService.upload(files[0])
                .success(function (url) {
                    $(vm.shortDescEditor).summernote('insertImage', url);
                });
        };

        vm.descUpload = function (files) {
            summerNoteService.upload(files[0])
                .success(function (url) {
                    $(vm.descEditor).summernote('insertImage', url);
                });
        };

        vm.specUpload = function (files) {
            summerNoteService.upload(files[0])
                .success(function (url) {
                    $(vm.specEditor).summernote('insertImage', url);
                });
        };

        vm.addOption = function addOption() {
            vm.addingOption.values = [];
            var index = vm.options.indexOf(vm.addingOption);
            vm.product.options.push(vm.addingOption);
            vm.options.splice(index, 1);
            vm.addingOption = null;
        };

        vm.deleteOption = function deleteOption(option) {
            var index = vm.product.options.indexOf(option);
            vm.product.options.splice(index, 1);
            vm.options.push(option);
        };

        vm.generateOptionCombination = function generateOptionCombination() {
            var maxIndexOption = vm.product.options.length - 1;
            vm.product.variations = [];

            function getItemValue(item) {
                return item.value;
            }

            function helper(arr, optionIndex) {
                var j, l, variation, optionCombinations, optionValue;

                for (j = 0, l = vm.product.options[optionIndex].values.length; j < l; j = j + 1) {
                    optionCombinations = arr.slice(0);
                    optionValue = {
                        optionName: vm.product.options[optionIndex].name,
                        optionId: vm.product.options[optionIndex].id,
                        value: vm.product.options[optionIndex].values[j]
                    };
                    optionCombinations.push(optionValue);

                    if (optionIndex === maxIndexOption) {
                        variation = {
                            name: optionCombinations.map(getItemValue).join('-'),
                            optionCombinations: optionCombinations,
                            priceOffset : 0
                        };
                        vm.product.variations.push(variation);
                    } else {
                        helper(optionCombinations, optionIndex + 1);
                    }
                }
            }

            helper([], 0);
        };

        vm.deleteVariation = function deleteVariation(variation) {
            var index = vm.product.variations.indexOf(variation);
            vm.product.variations.splice(index, 1);
        };

        vm.removeMedia = function removeMedia(media) {
            var index = vm.product.productMedias.indexOf(media);
            vm.product.productMedias.splice(index, 1);
            vm.product.deletedMediaIds.push(media.id);
        };

        vm.addVariation = function addVariation() {
            var variation,
                optionCombinations = [];

            vm.product.options.forEach(function (option) {
                var optionValue = {
                    optionName: option.name,
                    optionId: option.id,
                    value: vm.addingVariation[option.name]
                };
                optionCombinations.push(optionValue);
            });

            variation = {
                name: optionCombinations.map(function (item) {
                    return item.value;
                }).join('-'),
                optionCombinations: optionCombinations,
                priceOffset: vm.addingVariation.priceOffset || 0
            };

            if (!vm.product.variations.find(function (item) { return item.name === variation.name; })) {
                vm.product.variations.push(variation);
                vm.addingVariation = { priceOffset: 0 };
            }
        };

        vm.applyTemplate = function applyTemplate() {
            var template, i, index, workingAttr;
            productService.getProductTemplate(vm.product.template.id).success(function (result) {
                template = result;

                for (i = 0; i < vm.product.attributes.length; i = i + 1) {
                    vm.attributes.push(vm.product.attributes[i]);
                }

                vm.product.attributes = [];

                for (i = 0; i < template.attributes.length; i = i + 1) {
                    workingAttr = vm.attributes.find(function (item) { return item.id = template.attributes[i].id; });
                    index = vm.attributes.indexOf(workingAttr);
                    vm.attributes.splice(index, 1);
                    vm.product.attributes.push(workingAttr);
                }
            });
        };

        vm.addAttribute = function addAttribute() {
            var index = vm.attributes.indexOf(vm.addingAttribute);
            vm.product.attributes.push(vm.addingAttribute);
            vm.attributes.splice(index, 1);
            vm.addingAttribute = null;
        };

        vm.deleteAttribute = function deleteAttribute(attribute) {
            var index = vm.product.attributes.indexOf(attribute);
            vm.product.attributes.splice(index, 1);
            vm.attributes.push(attribute);
        };

        vm.toggleCategories = function toggleCategories(categoryId) {
            var index = vm.product.categoryIds.indexOf(categoryId);
            if (index > -1) {
                vm.product.categoryIds.splice(index, 1);
            } else {
                vm.product.categoryIds.push(categoryId);
            }
        };

        vm.filterAddedOptionValue = function filterAddedOptionValue(item) {
            if (vm.product.options.length > 1) {
                return true;
            }
            var optionValueAdded = false;
            vm.product.variations.forEach(function (variation) {
                var optionValues = variation.optionCombinations.map(function (item) {
                    return item.value;
                });
                if (optionValues.indexOf(item) > -1) {
                    optionValueAdded = true;
                }
            });

            return !optionValueAdded;
        };

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = productService.editProduct(vm.product, vm.thumbnailImage, vm.productImages);
            } else {
                promise = productService.createProduct(vm.product, vm.thumbnailImage, vm.productImages);
            }

            promise.success(function (result) {
                    $state.go('product');
                })
                .error(function (error) {
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add product.');
                    }
                });
        };

        function getProduct() {
            productService.getProduct($stateParams.id).then(function (result) {
                var i, index, optionIds, attributeIds;
                vm.product = result.data;
                optionIds = vm.options.map(function (item) { return item.id; });
                for (i = 0; i < vm.product.options.length; i = i + 1) {
                    index = optionIds.indexOf(vm.product.options[i].id);
                    optionIds.splice(index, 1);
                    vm.options.splice(index, 1);
                }

                attributeIds = vm.attributes.map(function (item) { return item.id; });
                for (i = 0; i < vm.product.attributes.length; i = i + 1) {
                    index = attributeIds.indexOf(vm.product.attributes[i].id);
                    attributeIds.splice(index, 1);
                    vm.attributes.splice(index, 1);
                }
            });
        }

        function getCategories() {
            categoryService.getCategories().then(function (result) {
                vm.categories = result.data;
            });
        }

        function getProductOptions() {
            productService.getProductOptions().then(function (result) {
                vm.options = result.data;
            });
        }

        function getProductTemplates() {
            productService.getProductTemplates().then(function (result) {
                vm.productTemplates = result.data;
            });
        }

        function getAttributes() {
            productService.getProductAttrs().then(function (result) {
                vm.attributes = result.data;
            });
        }

        function getBrands() {
            brandService.getBrands().then(function (result) {
                vm.brands = result.data;
            });
        }

        function init() {
            if (vm.isEditMode) {
                getProduct();
            }
            getProductOptions();
            getProductTemplates();
            getAttributes();
            getCategories();
            getBrands();
        }

        init();
    }
})(jQuery);