define(["sitecore", "jquery"], function (Sitecore, $) {
  var model = Sitecore.Definitions.Models.ControlModel.extend({
    initialize: function (options) {
        this._super();
        var app = this;
        app.set("jobitems", '{Name: "" }');
        $.when(app.getJobs(app)).done();
    },
    getJobs: function (app) {
        var dfd = $.Deferred();
        $.ajax({
            type: "GET",
            dataType: "json",
            url: "/api/sitecore/SitecoreJobs/GetJobs",
            cache: false,
            success: function (data) {
                app.set("jobitems", data);
            },
            error: function () {
                console.log("getJobs: error fetching data");
            }
        });
        return dfd.promise();
    }
  });

  var view = Sitecore.Definitions.Views.ControlView.extend({
    initialize: function (options) {
      this._super();
    }
  });

  Sitecore.Factories.createComponent("ViewJobs", model, view, ".sc-ViewJobs");
});
