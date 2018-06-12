var currenList = {};


function createUsersList() {
    currenList.name = $("#UsersListsName").val();
    currenList.items = new Array();

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "api/UserList/",
        data: currenList,
        success: function (result) {

            showUserList();


        },
        error: function () {
            console.error("something bad happened:(");

        }

    });



    //  showUserList();
}

function showUserList() {
    //webs services call

    $("#usersListTitle").html(currenList.name);
    $("#usersListItems").empty();

    $("#createListDiv").hide();
    $("#usersListDiv").show();

    $("#newItemName").focus();
    $("#newItemName").keyup(function (event) {
        if (event.keycode === 13) {

            addItem();
        }

    });
}

function addItem() {
    var newItem = {};
    newItem.name = $("#newItemName").val();
    newItem.UserListId = currenList.id;

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "api/Item/",
        data: newItem,
        success: function (result) {

            currenList = result;
            drawUsers();
            $("#newItemName").val("");

        }

    });
    //currenList.items.push(newItem);
    //console.info(currenList);
    //drawUsers();
    //$("#newItemName").val("");
}


function drawUsers() {

    var $list = $("#usersListItems").empty();

    for (var i = 0; i < currenList.items.length; i++) {

        var currentUser = currenList.items[i];


        var $li = $("<li>").html(currentUser.name).attr("id", "item_" + i);

        var $deleteBtn = $("<button onClick='deleteItem(" + currentUser.id + ")'>D</button>").appendTo($li);
        //var $checkBtn = $("<button onClick='checkItem(" + currentUser.id + ")'>C</button>").appendTo($li);


        //if (currentUser.checked) {
        //    $li.addClass("checked");
        //}
        $li.appendTo($list);

    }



}


function deleteItem(itemId) {

    $.ajax({
        type: "DELETE",
        dataType: "json",
        url: "api/Item/" + itemId,

        success: function (result) {
            currenList = result;
            drawUsers();
        }
    });
    //currenList.items.splice(index, 1);
    //drawUsers();
}

function checkItem(itemId) {
    var changedItem = {};

    for (var i = 0; i < currenList.items.length; i++) {

        if (currenList.items[i].id === itemId) {
            changedItem = currenList.items[i];
        }
    }

    changedItem.checked = !changedItem.checked;
    $.ajax({
        type: "PUT",
        dataType: "json",
        url: "api/Item/" + itemId,
        data: changedItem,
        success: function (result) {

            currenList = result;
            drawUsers();
            // $("#newItemName").val("");

        }

    });

    //if ($("#item_" + index).hasClass("checked")) {

    //    $("#item_" + index).removeClass("checked");

    //}
    //else {
    //    $("#item_" + index).addClass("checked");
    //}

}

function getUserListByID(id) {
    //console.info(id);
    //currenList.name = "mock users list";
    //currenList.items = [
    //    { name: "Esteban"},
    //    { name:"Francisco"},
    //    { name:"Andzia"}
    //]
    //showUserList();
    //drawUsers();
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "api/UserList/" + id,
        success: function (result) {
            currenList = result;
            showUserList();
            drawUsers();

        },
        error: function () {
            console.error("something bad happened:(");

        }

    });


}

$(document).ready(function () {

    console.info("ready");
    $("#UsersListsName").focus();
    $("#UsersListsName").keyup(function (event) {
        if (event.keycode === 13) {

            createUsersList();
        }

    });
    var pageurl = window.location.href;
    var idIndex = pageurl.indexOf("?id=");
    if (idIndex !== -1) {

        // WE HAVE 4 CARACTERS
        getUserListByID(pageurl.substr(idIndex + 4));

    }

});