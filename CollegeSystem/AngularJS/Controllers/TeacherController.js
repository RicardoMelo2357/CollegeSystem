MyApp.controller('TeacherController', function ($scope, $http) {
    $scope.title = "Teacher";
    $scope.Object = {};
    $scope.ListTeacher = {};

    $scope.AddTeacher = function () {
        $http({
            url: "Teacher/AddTeacher",
            method: "POST",
            data: $scope.Object
        }).then(function (response) {
            $scope.Message = response.data;
            $scope.Object = {};
            $scope.ListTeacher();
        }, function (response) {
            $scope.Message = response.data;
        });
    }

    $scope.ListTeacher = $http({
        method: 'GET',
        url: 'Teacher/ListTeacher',
    }).then(function (response) {
        $scope.ListTeacher = response.data;
    }, function (response) {
        $scope.Message = response.data;
    });

    this.ListTeacher;

    $scope.ListSubject = $http({
        method: 'GET',
        url: 'Subject/ListSubject',
    }).then(function (response) {
        $scope.ListSubject = response.data;
    }, function (response) {
        $scope.Message = response.data;
    });

    this.ListSubject;
});