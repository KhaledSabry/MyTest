var app = angular.module("app", []);


app.controller("ctrl", function ($scope) {
    $scope.categories = [];
    $scope.NewCat = {};
    $scope.items = [];
    $scope.NewItem = {};
    $scope.getTotal = function (CatId) {
        var total = 0;

        for (var i = 0; i < $scope.items.length; i++) {
            if (CatId && CatId != null) {
                if ($scope.items[i].cat.id === CatId)
                    total += $scope.items[i].value;
            }
            else
                total += $scope.items[i].value;
        }
        return total;
    };
    function LoadData() {
        SetBusy($(".DataPanel"), false);
        SendGet('/api/items/all/',
            function (result) {
                $scope.items = result;
                $scope.$apply();
                SetBusy($(".DataPanel"), true);
            });
        SendGet('/api/categories/all/',
            function (result) {
                $scope.categories = result;
                $scope.$apply();
                SetBusy($(".DataPanel"), true);
            });
    }
    LoadData();


    $scope.SaveItem = function () {
        SetBusy($(".addnewform"), false);
        var NewItem = $scope.NewItem;
        SendPost('/api/items/add/', NewItem,
            function (result) {
                console.log(result);

                $scope.items.push(result);
                $scope.NewItem = {};
                $scope.$apply();
                SetBusy($(".addnewform"), true);
            });

    };
    $scope.deleteItem = function (index) {
        var itm = this.itm;
        Confirm("You are about to delete this Item!",
            function () {
                SetBusy($(".itemForm" + itm.id), false);
                SendDelete('/api/items/delete/' + itm.id,
                    function (result) {
                        if (result) {
                            $scope.items.splice(index, 1);
                            $scope.$apply();
                        }
                        SetBusy($(".itemForm" + itm.id), true);
                    });
            });

    };
    $scope.UpdateCat = function (index) {
        var cat = this.cat;
        SetBusy($(".CatForm" + index), false);
        SendPost('/api/categories/update/', cat,
            function (result) {
                $scope.categories[index] = result;
                cat.editMode = false;
                $scope.$apply();
                SetBusy($(".CatForm" + index), true);
            });
    }
    $scope.AddCat = function () {
        var cat = $scope.NewCat;
        SetBusy($(".CatFormNew"), false);
        SendPost('/api/categories/add/', cat,
            function (result) {
                $scope.categories.push(result);
                $scope.NewCat = {};
                $scope.$apply();
                SetBusy($(".CatFormNew"), true);
            });
    }
});