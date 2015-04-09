app.factory('TaskFactory', ['$http', '$q', function ($http, $q) {
    var tasks = [];

    var GetUserTasks = function () {
        var deferred = $q.defer();
        $http({
            method: 'GET',
            url: '/api/apiToDo',
            contentType: 'application/json',
            headers: { Authorization: "Bearer " + localStorage.getItem('token') }
        }).success(function (data) {
            tasks.length = 0;
            for (var i = 0; i < data.length; i++) {
                tasks.push(data[i]);
            }
            deferred.resolve(data);
        }).error(function (data) {
            deferred.reject(data);
        });
        return deferred.promise;
    }

    var deleteTask = function (id) {
        var deferred = $q.defer();
        $http({
            method: 'DELETE',
            url: '/api/apiToDo/' + id
        }).success(function (data) {
            for (var i = 0; i < tasks.length; i++) {
                if (tasks[i].ToDoId == id) {
                    tasks.splice(i, 1);
                    break;
                }
            }
            deferred.resolve(data);
        }).error(function (data) {
            deferred.reject(data);
        });
        return deferred.promise;
    };

    var editTask = function (task) {
        var deferred = $q.defer();
        $http({
            method: 'PUT',
            url: '/api/apiToDo/' + task.ToDoId,
            data: task
        }).success(function (data) {
            for (var i = 0; i < tasks.length; i++) {
                if (tasks[i].ToDoId == data.ToDoId) {
                    tasks[i].Description = data.Description;
                    tasks[i].UserId = data.UserId;
                    break;
                }
            }
            deferred.resolve(data);
        }).error(function () {
            deferred.reject();
        });
        return deferred.promise;
    };

    return {
        GetUserTasks: GetUserTasks,
        tasks: tasks,
        deleteTask: deleteTask,
        editTask: editTask
    }
}]);