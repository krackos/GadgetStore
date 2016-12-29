angular.module("gadgetsStore")
    .controller('accountController', ["$http", "$location", "registerUrl", "tokenUrl", "tokenKey", function ($http, $location, registerUrl, tokenUrl, tokenKey) {
 
        $scope.hasLoginError = false;
        $scope.hasRegistrationError = false;
 
        // Registration
        $scope.register = function () {
 
            $scope.hasRegistrationError = false;
            $scope.result = '';
 
            var data = {
                Email: $scope.registerEmail,
                Password: $scope.registerPassword,
                ConfirmPassword: $scope.registerPassword2
            };
 
            $http.post(registerUrl, JSON.stringify(data))
                    .then(function (data) {
                        $location.path("/login");
                    }, function (error) {
                        $scope.hasRegistrationError = true;
                        var errorMessage = error.data.Message;
                        console.log(error);
                        $scope.registrationErrorDescription = errorMessage;
 
                        if (data.ModelState['model.Email'])
                            $scope.registrationErrorDescription += error.data.ModelState['model.Email'];
 
                        if (data.ModelState['model.Password'])
                            $scope.registrationErrorDescription += error.data.ModelState['model.Password'];
 
                        if (data.ModelState['model.ConfirmPassword'])
                            $scope.registrationErrorDescription += error.data.ModelState['model.ConfirmPassword'];
 
                        if (data.ModelState[''])
                            $scope.registrationErrorDescription +=  error.data.ModelState[''];
 
                    });
        }
 
        var successLoginCallback = function (result) {
            console.log(result);
            $location.path("/submitorder");
            sessionStorage.setItem(tokenKey, result.data.access_token);
            $scope.hasLoginError = false;
            $scope.isAuthenticated = true;
        }
 
      var errorLoginCallback = function (error) {
            console.log(error);
            $scope.hasLoginError = true;
            $scope.loginErrorDescription = error.data.error_description;
        }

        $scope.login = function () {
            $scope.result = '';
 
            var loginData = {
                grant_type: 'password',
                username: $scope.loginEmail,
                password: $scope.loginPassword
            };
 
            accountService.generateAccessToken(loginData)
                .then(successLoginCallback, errorLoginCallback);
        }

 
    }]);