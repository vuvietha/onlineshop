(function (app) {
    app.controller('productEditController', productEditController);
    productEditController.$inject = ['$scope', 'apiService', 'notificationService', '$stateParams', '$state', 'commonService'];
    function productEditController($scope, apiService, notificationService, $stateParams, $state, commonService) {
        $scope.product = {
            UpdatedDate: new Date()
        };
        $scope.UpdateProduct = UpdateProduct;
        $scope.GetSeoTitle = GetSeoTitle;
        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    if ($scope.moreImage != null) {
                        $scope.moreImage.push(fileUrl);
                    } else {
                        $scope.moreImage = [];
                        $scope.moreImage.push(fileUrl);
                    }
                    
                });

            }
            finder.popup();
        }
        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);

        }
        function LoadProductDetail() {
           
            apiService.get('api/product/edit/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
                $scope.moreImage = JSON.parse($scope.product.MoreImage);
            }, function (error) {
                notificationService.displayError(error.data);
            })


        };
        function LoadProductCategories() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;

            }, function () {
                console.log('Load category fail');
            })
        }
        function UpdateProduct() {
            $scope.product.MoreImage = JSON.stringify($scope.moreImage);
            apiService.put('api/product/update', $scope.product, function (result) {
                notificationService.displaySuccess('Cập nhật ' + $scope.product.Name + ' thành công');
                $state.go('products');
            }, function (error) {
                notificationService.displayError(error);
            });


        };
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                });

            }
            finder.popup();
        }
        LoadProductCategories();
        LoadProductDetail();


    }

})(angular.module('onlineshop.products'));