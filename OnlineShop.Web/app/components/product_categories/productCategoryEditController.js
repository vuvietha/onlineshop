(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);
    productCategoryEditController.$inject = ['$scope', 'apiService', 'notificationService', '$stateParams', '$state', 'commonService'];
    function productCategoryEditController($scope, apiService, notificationService, $stateParams, $state, commonService) {
        $scope.productCategory = {
            UpdatedDate: new Date()
        };
        $scope.UpdateProductCategory = UpdateProductCategory;
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);

        }
        function LoadProductCategoryDetail() {
            apiService.get('api/productcategory/edit/' + $stateParams.id, null, function (result) {
                $scope.productCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            })


        };
        function LoadParentCategories() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;

            }, function () {
                console.log('Load category fail');
            })


        };
        function UpdateProductCategory() {
            apiService.put('api/productcategory/update', $scope.productCategory, function (result) {
                notificationService.displaySuccess('Cập nhật ' + $scope.productCategory.Name + ' thành công');
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError(error);
            });
           
        };
        LoadProductCategoryDetail();
        LoadParentCategories();

    }

})(angular.module('onlineshop.product_categories'));