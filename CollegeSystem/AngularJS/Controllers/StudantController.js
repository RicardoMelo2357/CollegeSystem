MyApp.controller('StudantController', function ($scope, $http) {
    $scope.title = "studant";
    $scope.Object = {};
    $scope.ListStudant = {};
    $scope.ListTeacher = {};

    $scope.AddStudant = function () {
        $http({
            url: "Studant/AddStudant",
            method: "POST",
            data: $scope.Object
        }).then(function (response) {
            $scope.Message = response.data;
            $scope.Object = {};
            $scope.AddStudant();
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

    $scope.ListStudant= $http({
        method: 'GET',
        url: 'Studant/ListStudant',
    }).then(function (response) {
        $scope.ListStudant = response.data;
    }, function (response) {
        $scope.Message = response.data;
    });

    this.ListStudant;
});