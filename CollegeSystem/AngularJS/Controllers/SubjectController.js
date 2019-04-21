MyApp.controller('SubjectController', function ($scope, $http) {
    $scope.title = "Subject";
    $scope.Object = {};
    $scope.ListSubject = {};
    $scope.ListCourse = {};

    $scope.AddSubject = function () {
        $http({
            url: "Subject/AddSubject",
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

    //$scope.DeleteSubject= $http({
    //    url: 'Subject/DeleteSubject',
    //    method: 'POST',
    //    data: $scope.Object
    //}).then(function (response) {
    //    $scope.ListCourse = response.data;
    //}, function (response) {
    //    $scope.Message = response.data;
    //});

    $scope.ListSubject = $http({
        method: 'GET',
        url: 'Subject/ListSubject',
    }).then(function (response) {
        $scope.ListSubject = response.data;
    }, function (response) {
        $scope.Message = response.data;
    });

    this.ListSubject;

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