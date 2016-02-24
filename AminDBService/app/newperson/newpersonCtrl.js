app.controller('NewPersonCtrl', function ($scope, personService, $location, $routeParams, $timeout) {

    $scope.addPerson = function () {

        if ($scope.newPerson.firstName != "" && $scope.newPerson.lastName != "" &&
                $scope.newPerson.mother != "" && $scope.newPerson.gender != "") {

            var gender = ($scope.newPerson.gender == "male" ? "בן" : "בת");

            var person = $scope.newPerson.firstName + " " + $scope.newPerson.lastName + " " +
                gender + " " + $scope.newPerson.mother;
                
            personService.addPerson(person)
                .then(
                    loadData,
                    function (errorMessage) {
                        console.warn(errorMessage);
                    }
                );
        }
        else {
            alert('נא מלא את כל הפרטים');
        }
    };

    function loadData(data) {
        if (data != null) {
            $scope.isAlertSuccess = true;
            $timeout(function () { $scope.alertTimeout(); }, 1500);
        }
        else {
            $scope.isAlertDanger = true;
            $timeout(function () { $scope.alertDangrTimeout(); }, 2500);
        }
    };

    $scope.alertTimeout = function () {
        $location.url('/');
    };

    $scope.alertDangrTimeout = function () {
        $scope.isAlertDanger = false;
    };

    $scope.isAlertSuccess = false;
    $scope.isAlertDanger = false;

    $scope.newPerson = {};
    $scope.newPerson.firstName = "";
    $scope.newPerson.lastName = "";
    $scope.newPerson.mother = "";
    $scope.newPerson.gender = "";

   // $scope.user = userDataService.getUserData();

});
