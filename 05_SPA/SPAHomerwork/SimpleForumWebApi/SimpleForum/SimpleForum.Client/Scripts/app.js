/// <reference path="app/postsViewModel.js" />
/// <reference path="app/userModels.js" />
/// <reference path="lib/kendo/kendo.web.js" />
var app = app || {};

app.config = (function () {
    // layouts
    var layout = new kendo.Layout("main-layout-template");

    // views
    var postsListView = new kendo.View("posts-listing", { model: postsViewModel });
    var createPostView = new kendo.View("create-post-view", { model: postsViewModel });
    var loginView = new kendo.View("login-template");
    var registerView = new kendo.View("register-template");

    // Models
    
    // routes
    var router = new kendo.Router({
        init: function () {
            layout.render("#application");
        }
    });

    router.route("/", function () {
        layout.showIn("#body", postsListView);
    });

    router.route("/posts", function () {
        layout.showIn("#body", postsListView);
    });

    router.route("/posts/create", function () {
        layout.showIn("#body", createPostView);
    });

    router.route("/posts/tags", function () {
        layout.showIn("#body", postsListView);
    });

    router.route("/post/:id", function () {
        layout.showIn("#body", postView);
    });

    router.route("/post/:id/comment", function () {
        layout.showIn("#body", commentView);
    });

    router.start();
    //router.navigate("/posts");
});

$(function () {
    app.config();
});