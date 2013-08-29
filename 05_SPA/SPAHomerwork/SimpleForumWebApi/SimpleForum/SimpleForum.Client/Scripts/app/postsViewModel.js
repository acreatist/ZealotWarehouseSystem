/// <reference path="../lib/kendo/kendo.web.js" />
var postsDataSource = new kendo.data.DataSource({
    transport: {
        read: {
            url: 'http://localhost:51067/api/posts',
            dataType: 'json'
        },
        create: {
            url: 'http://localhost:51067/api/posts',
            dataType: 'json'
        },
    },
    batch: true,
    schema: {
        model: { id: "Id" }
    }
});

var postsViewModel = new kendo.observable({
    model: postsDataSource,
    title: "",
    content: "",
    postsCount: 0,

    allPosts: function () {
        var self = this;    
        var postsData;
        
        self.model.fetch(function () {
            postsData = self.model.data();
            var tempList = [];

            for (var i = 0; i < postsData.length; i++) {
                tempList.push(
                    { id: postsData[i].Id, title: postsData[i].Title, content: postsData[i].Content }
                );
            }
            self.set("postsCount", postsData.length);
            self.set("allPosts", tempList);
        });

        return [];
    },

    createPost: function () {
        var self = this;

        self.model.add(self.generatePostObject());
        self.model.sync();

        console.log(self.generatePostObject());
    },

    generatePostObject: function () {
        return {
            title: this.get("title"),
            content: this.get("content"),
            id: this.get("postsCount")
        }
    }


});