var app = angular.module("umbraco");

app.controller("mindrevolution.ContentTracking.TrackingController", ["$scope", "assetsService", function ($scope, assetsService) {
    $scope.model.config.ContentCategories =
    [
        {
            Name: "Wissen und Bildung",
            Formats: [
                "Forschungseinblicke",
                "Technikpraxis",
                "Checklisten und Grafiken"
            ]
        },
        {
            Name: "Tipps und Informationen",
            Formats: [
                "tipps foo",
                "Mood Gallery",
                "Checklisten und Grafiken"
            ]
        },
        {
            Name: "Unterhaltung",
            Formats: [
                "unterhaltung bar",
                "Technikpraxis",
                "Checklisten und Grafiken"
            ]
        },
        {
            Name: "Inspiration",
            Formats: [
                "inspiration dummy",
                "Tutorial",
                "E-Book/Guide",
                "Reisebericht",
                "Landesimpressionen"
            ]
        }
    ];

    $scope.model.config.ContentFunnelStages =
    [
        {
            Stage: "Attention",
            Label: "Aufmerksamkeit (Attention)"
        },
        {
            Stage: "Interest",
            Label: "Interesse (Interest)"
        },
        {
            Stage: "Desire",
            Label: "Abwägung (Desire)"
        },
        {
            Stage: "Action",
            Label: "Handlung (Action)"
        },
        {
            Stage: "Retention",
            Label: "Bindung (Retention)"
        },
    ];

    $scope.getCategories = function () {
        var list = [];

        angular.forEach($scope.model.config.ContentCategories, function (category) {
            list.push(category.Name);
        });

        return list;
    };

    $scope.getFormats = function (cat) {
        var list;

        if (cat != undefined && cat != null && cat != "") {
            angular.forEach($scope.model.config.ContentCategories, function (category) {
                if (cat.toLowerCase() == category.Name.toLowerCase()) {
                    list = category.Formats;
                }
            });
        }

        return list;
    };

    $scope.getFunnelStages = function () {
        var list = [];

        angular.forEach($scope.model.config.ContentFunnelStages, function (stage) {
            list.push(stage);
        });

        return list;
    };

    $scope.requireTrackingSettings = $scope.model.config.requireTrackingSettings;
    //$scope.model.value = {};

    //if ($scope.model.value == undefined || $scope.model.value == null) {
    //    $scope.model.value = {
    //        category: "",
    //        format: ""
    //    };
    //}
    
}]);