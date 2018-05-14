(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope','apiService','notificationService']
    function productCategoryListController($scope, apiService, notificationService) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.getProductCategories = getProductCategories;
        $scope.search = search;
        function search() {
            getProductCategories();

        }
        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    page: page,
                    pageSize: 2,
                    keyword : $scope.keyword

                }  

            };
            apiService.get('api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning("khong tim thay ban ghi nao");
                }
                //else {
                //    notificationService.displaySuccess("Tim thay "+result.data.TotalCount+" ban ghi");
                //}
                 $scope.productCategories = result.data.Items;
                 $scope.page = result.data.Page;
                 $scope.pagesCount = result.data.TotalPages;
                 $scope.totalCount = result.data.TotalCount;

            }, function () {
                console.log("Load product category failed");

            });
        }
        $scope.getProductCategories();

    }

})(angular.module('onlineshop.product_categories'));