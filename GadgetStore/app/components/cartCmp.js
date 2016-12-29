var storeCart = angular.module('storeCart', []);
storeCart.factory('cart', function(){
    var cartData = [];
    return {
        addProduct: function(id, name, price, category) {
            var addedToExistingItem = false;
            cartData.forEach((cart) => {
                if( cart.GadgetID == id){
                    cart.count++;
                    addedToExistingItem = true;
                }
            });
            if(!addedToExistingItem) {
                cartData.push({
                    count: 1, GadgetID: id, Price: price, Name: name, CategoryID: category
                });
            }
        },
        removeProduct: function(id) {
            for(var index = 0; index < cartData.length; index++) {
                if(cartData[index].GadgetID == id) {
                    cartData.splice(index, 1);
                }
            }
        },
        getProducts: function(){
            return cartData;
        },
        pushItem: function(item) {
        	cartData.push({
        	  count: item.Count, GadgetID: item.GadgetID, Price: item.Price, Name: item.Name 
        	});
        }
    };
});

storeCart.directive("cartDetails", function(cart){
    return {
        restrict: 'E',
        templateUrl: "/app/components/cartDetails.html",
        controller: ['$scope', function($scope) {
            var cartData = cart.getProducts();
            $scope.total = function() {
                var total=0;
                for(var i = 0; i < cartData.length; i++) {
                    total += (cartData[i].Price * cartData[i].count);
                }
                return total;
            }
            $scope.itemCount = function() {
                var total=0;
                for (var i = 0; i < cartData.length; i++) {
                    total += cartData[i].count;
                }
                return total;
            }
        }]
    };
});