$(document).ready(function () {
    $("#btnAjaxCall").on("click", function () {
        AjaxCall();
    });

    $("#btnPostCall").on("click", function () {
        AjaxPost();
    });

    $("#btnGetCall").on("click", function () {
        AjaxGet();
    });

    $("#btnPostCookieCall").on("click", function () {
        AjaxPostCookie();
    });
    
});

function AjaxCall() {
    $.ajax({
        type: "POST",
        //contentType: "application/json",
        contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        url: "home/AjaxCall",
        //data: JSON.stringify({ Id: 2, Name: "Gert"}),
        data: { Id: 2, Name: "Gert", __RequestVerificationToken: GetToken() },
        success: function (data) {
            $("#result").html(data);
        },
        dataType: "text"
    });
}

function AjaxPost() {
    var jqxhr = $.post("home/PostCall", { id: 1, name: "Jean", "__RequestVerificationToken": GetToken() }, function (data) {
    //var jqxhr = $.post("home/PostCall", { Id: 1, Name: "Jean"}, function (data) {
        $("#result").html(data);
    }, "text");

    jqxhr.done(function () {
        alert("post done");
    });

    jqxhr.fail(function () {
        alert("post error");
    });

    jqxhr.always(function () {
    });
}

function AjaxGet() {
    var jqxhr = $.get("home/GetCall", function (data) {
        alert("get success");
        $("#result").html(data);
    })
    .done(function () {
    })
    .fail(function () {
        alert("get error");
    })
    .always(function () {
    });
}

function AjaxPostCookie() {
    $.ajax("home/PostCall", {
        type: "POST",
        contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        data: { Id: 1, Name: "Jean" },
        dataType: "text",
        headers: {
            'RequestVerificationToken': GetTokenCookie()
        }
    }).done(function (data) {
        $("#result").html(data);
    });
}
