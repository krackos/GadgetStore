angular.module('gadgetStore',['storeFilters', 'storeCart', 'ngRoute'])
.config(function($routeProvider, $locationProvider) {
    $routeProvider.when('/', {
        templateUrl: "app/views/gadgets.html"
    })
    .when('/gadgets', {
        templateUrl: "app/views/gadgets.html"
    })
    .when('/checkout', {
        templateUrl: "app/views/checkout.html"
    })
    .when('/submitorder', {
        templateUrl: "app/views/submitOrder.html"
    })
    .when('/complete', {
        templateUrl: "app/views/orderSubmitted.html"
    })
    .when('/login', {
        templateUrl: "app/views/login.html"
    })
    .when('/complete', {
        templateUrl: "app/views/register.html"
    })
    .otherwise({
        templateUrl: "app/views/gadgets.html"
    });

    $locationProvider.html5Mode({enabled: true,requireBase: false});
});