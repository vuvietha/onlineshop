(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);
    productCategoryAddController.$inject = ['$scope','apiService','notificationService','$state'];
    function productCategoryAddController($scope, apiService, notificationService, $state) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status : true


        };
        $scope.AddProductCategory = AddProductCategory;
        function LoadParentCategories() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;

            }, function () {
                console.log('Load category fail');
            })
           

        }
        function AddProductCategory() {
            apiService.post('api/productcategory/create', $scope.productCategory, function (result) {
                notificationService.displaySuccess("Thêm mới " + $scope.productCategory.Name + "thành công");
                $state.go('product_categories');
            }, function (error) {
                notificationService.diplayError("Thêm mới không thành công");
            });

        };
        LoadParentCategories();
        //AddProductCategory();

    }

})(angular.module('onlineshop.product_categories'));