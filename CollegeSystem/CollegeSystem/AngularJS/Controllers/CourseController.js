MyApp.controller('CourseController', function ($scope, $http) {
    $scope.title = "Course";
    $scope.Object = {};
    $scope.ListCourse = {};
    $scope.DeleteCourse = {};

    $scope.AddCourse = function () {
        $http({
            url: "Course/AddCourse",
            method: "POST",
            data: $scope.Object
        }).then(function (response) {
            $scope.Message = response.data;
            $scope.Object = {};
            $scope.ListCourse();
        }, function (response) {
            $scope.Message = response.data;
         });
    }

    $scope.DeleteCourse = $http({
        url: 'Course/DeleteCourse',
        method: 'POST',
        data: $scope.Object
    }).then(function (response) {
        $scope.ListCourse = response.data;
    }, function (response) {
        $scope.Message = response.data;
    });

    $scope.ListCourse = $http({
        method: 'GET',
        url: 'Course/ListCourse',
    }).then(function (response) {
        $scope.ListCourse = response.data;
    }, function (response) {
        $scope.Message = response.data;
    });

    this.ListCourse;
});