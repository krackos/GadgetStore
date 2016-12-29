angular.module("gadgetStore")
    .constant('gadgetsActiveClass', 'btn-primary')
    .constant('gadgetsPageCount',3)
    .controller("gadgetsCtrl", ['$scope', '$filter', 'gadgetsActiveClass', 'gadgetsPageCount','cart', function($scope, $filter, gadgetsActiveClass, gadgetsPageCount, cart){
        var selectedCategory = null;

        $scope.selectedPage = 1;
        $scope.pageSize = gadgetsPageCount;

        $scope.selectPage = function (newPage) {
            $scope.selectedPage = newPage;
        }

        $scope.selectCategory = function(newCategory) {
            selectedCategory = newCategory;
            $scope.selectedPage = 1;
        }

        $scope.categoryFilterFn = function (product) {
            return selectedCategory == null || product.CategoryID == selectedCategory;
        }

        $scope.getCategoryClass = function (category) {
            return selectedCategory == category ? gadgetsActiveClass : "" ;
        }

        $scope.getPageClass = function(page) {
            return $scope.selectedPage == page ? gadgetsActiveClass : "";
        }

        $scope.addProductToCart = function(item) {
            cart.addProduct(item.GadgetID, item.Name, item.Price, item.CategoryID);
            $scope.saveOrder();
        }
    }]);