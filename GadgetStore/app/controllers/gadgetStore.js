angular.module("gadgetStore")
    .constant("gadgetsUrl", "/api/gadgets")
    .constant("ordersUrl", "/api/orders")
    .constant("categoriesUrl","/api/categories")
    .constant("tempOrderUrl", "/api/sessions/temporders")
    .constant("tokenUrl", '/Token')
    .constant("tokenKey", 'accessToken')
    .controller("gadgetStoreCtrl", 
    ["$scope","$http","$location", "gadgetsUrl", "categoriesUrl", "ordersUrl", "tempOrderUrl","tokenUrl","tokenKey" "cart", 
    function($scope, $http, $location, gadgetsUrl, categoriesUrl, ordersUrl, tempOrderUrl, tokenUrl, tokenKey,cart){
        $scope.data = {};

        $http.get(gadgetsUrl).then(function(result){
                $scope.data.gadgets = result.data;
            }, function(error){
                $scope.data.error = error;
            });
        
        $http.get(categoriesUrl).then(function(result) {
                $scope.data.categories = result.data;
            }, function(error){
                $scope.data.error = error;
            });
        
        $scope.sendOrder = function (shippingDetails){
        	var token = sessionStore.getItem(tokenKey);
        	console.log(token);
        	var headers = {};
        	if (token) {
        		headers.Authorization = "Bearer" + token;
        	}

            var order = angular.copy(shippingDetails);
            order.gadgets = cart.getProducts();
            $http.post(ordersUrl, order, {headers: { 'Authorization': 'Bearer' + token}}).then(function(response){
                $scope.data.OrderLocation = response.headers('Location');
                $scope.data.OrderID = response.data.OrderID;
                cart.getProducts().length = 0;
                $scope.saveOrder();
                $location.path("/complete");
            }, function(error){
            	if (error.status != 401)
                	$scope.data.orderError = error;
				else
					$location.path("/login");
            });
        }

        $scope.showFilter = function() {
            return $location.path() == '';
        }
        $scope.checkoutComplete = function() {
            return $location.path() == '/complete';
        }

        $scope.saveOrder = function () {
        	var currentProducts = cart.getProducts();

        	$http.post(tempOrderUrl, currentProducts);
        }

        $scope.checkSessionGadgets = function() {
        	$http.get(tempOrderUrl).then(function(response){
        		if(response.data) {
        			for(var index = 0; index < response.data.length; index++) {
        			  var item = response.data[index];
        			  cart.pushItem(item);
        			}
        		}
        	}, function(error){
        		console.log('error checking session:' + error);
        	});
        }

        $scope.logout = function() {
        	sessionStorage.removeItem(tokenKey);
        }
        $scope.createAccount = function() {
        	$location.path("/register");
        }
    }]);