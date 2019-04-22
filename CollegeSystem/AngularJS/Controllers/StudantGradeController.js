MyApp.controller('StudantGradeController', function ($scope, $http) {
    $scope.title = "Grade";
    $scope.Object = {};
    $scope.ListStudant = {};
    $scope.ListTeacher = {};

    $scope.AddStudantGrade = function () {
        $http({
            url: "StudantGrade/AddStudantGrade",
            method: "POST",
            data: $scope.Object
        }).then(function (response) {
            $scope.Message = response.data;
            $scope.Object = {};
            $scope.AddStudantGrade();
        }, function (response) {
            $scope.Message = response.data;
        });
    }

    $scope.ListStudantGrade = $http({
        method: 'GET',
        url: 'StudantGrade/ListStudantGrade',
    }).then(function (response) {
        $scope.ListStudantGrade= response.data;
    }, function (response) {
        $scope.Message = response.data;
    });

    this.ListStudantGrade;

    $scope.ListSubject= $http({
        method: 'GET',
        url: 'Subject/ListSubject',
    }).then(function (response) {
        $scope.ListSubject= response.data;
    }, function (response) {
        $scope.Message = response.data;
    });

    this.ListSubject;

    $scope.ListStudant = $http({
        method: 'GET',
        url: 'Studant/ListStudant',
    }).then(function (response) {
        $scope.ListStudant = response.data;
    }, function (response) {
        $scope.Message = response.data;
    });

    this.ListStudant;
});