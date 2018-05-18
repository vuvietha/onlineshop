(function (app) {
    app.controller('productAddController', productAddController)
   productAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state', 'commonService'];
    function productAddController($scope, apiService, notificationService, $state, commonService) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true


        };
        $scope.AddProduct = AddProduct;
        $scope.GetSeoTitle = GetSeoTitle;
        $scope.ckeditorOptions = {
            language: 'vi',
            height:'200px'

        }
        function LoadProductCategories() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;

            }, function () {
                console.log('Load category fail');
            })
        }
        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);

        }
        function AddProduct() {
            $scope.product.moreImage = JSON.stringify($scope.moreImage);
            apiService.post('api/product/create', $scope.product, function (result) {
                notificationService.displaySuccess("Thêm mới " + $scope.product.Name + " thành công");
                $state.go('products');
            }, function (error) {
                notificationService.displayError("Thêm mới không thành công");
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
        $scope.moreImage = [];
        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImage.push(fileUrl);
                });
             
            }
            finder.popup();
        }
      

    }

})(angular.module('onlineshop.products'));