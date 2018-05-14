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
        function GetProductCategories() {
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
            apiService.post('api/product/create', $scope.product, function (result) {
                notificationService.displaySuccess("Thêm mới " + $scope.product.Name + " thành công");
                $state.go('products');
            }, function (error) {
                notificationService.diplayError("Thêm mới không thành công");
            });

        };
        GetProductCategories();
      

    }

})(angular.module('onlineshop.products'));