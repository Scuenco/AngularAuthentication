app.factory('LoginFactory', ['$http', '$q', function ($http, $q) {
    var status = {
        isLoggedIn: false
    }

    //isLoggedIn login for loading the webpage
    if (localStorage.getItem('token')) status.isLoggedIn = true;

    var login = function (user) {
        var deferred = $q.defer();
        $http({
            method: 'POST',
            url: '/Token',
            contentType: 'application/x-www-form-urlencoded',
            data: 'username=' + user.username + '&password=' + user.password + '&grant_type=password'
        }).success(function (data) {
            localStorage.setItem('token', data.access_token);
            status.isLoggedIn = true;
            deferred.resolve(data);
        }).error(function (data) {
            status.isLoggedIn = false;
            localStorage.removeItem('token');
            deferred.reject(data);
        });
        return deferred.promise;
    };

    var logout = function () {
        status.isLoggedIn = false;
        localStorage.removeItem('token');
    }

    return {
        status: status,
        login: login,
        logout: logout
    }
}]);