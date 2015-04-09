app.controller('HomeController', ['$scope', 'TaskFactory', 'LoginFactory', function ($scope, TaskFactory, LoginFactory) {
    $scope.status = LoginFactory.status,
    $scope.user = {},
    $scope.tasks = TaskFactory.tasks;

    $scope.isEditing = false;
    $scope.editTask = {};

    $scope.login = function () {
        LoginFactory.login($scope.user).then(function () {
            $scope.user.username = $scope.user.password = '';
            TaskFactory.GetUserTasks();
        })
    }
    $scope.logout = function () {
        LoginFactory.logout();
    }

    if ($scope.status.isLoggedIn) {
        TaskFactory.GetUserTasks();
    }

    $scope.deleteTask = function (id) {
        TaskFactory.deleteTask(id).then(function(data){
            alert("Task was successfully deleted.");
        }, function (data) {
            alert("Delete failed.")
        });
    };
   
    $scope.editTask = function (id) {
        TaskFactory.editTask($scope.editTask(id)).then(function (data) {
            $scope.isEditing = false;
            $scope.editTask = {};
            alert("Task was successfully updated.");
        }, function (data) {
            alert("Update task failed.");
        });
    };
}]);