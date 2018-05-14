(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox','$filter'];
    function productCategoryListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.getProductCategories = getProductCategories;
        $scope.search = search;
        $scope.deleteProductCategory = deleteProductCategory;
        $scope.selectAll = selectAll;
        $scope.isAll = false;
        $scope.deleteMultiple = deleteMultiple;
        function deleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i,item) {
                listId.push(item.ID);
            });
            $ngBootbox.confirm('Bạn có chắc muốn xóa').then(function () {
                var config = {
                    params: {
                        checkedProductCategory: JSON.stringify(listId)

                    }
                }
                apiService.del('api/productcategory/deletemultiple', config, function (result) {
                    notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                });
            });
        }
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;

                
            } else {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;

            }

        }
        $scope.$watch("productCategories", function (n, o) {
            var checked = $filter("filter")(n,{checked:true});
            if(checked.length){
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            }else{
                $('#btnDelete').attr('disabled', 'disabled');
            }
        },true);
        function deleteProductCategory(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa').then(function () {
                var config = {
                    params: {
                        id:id
                    }
                }
                apiService.del('api/productcategory/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                });
            });

        }
        function search() {
            getProductCategories();

        }
        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    page: page,
                    pageSize: 4,
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