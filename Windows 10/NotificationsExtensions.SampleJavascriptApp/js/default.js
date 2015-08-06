// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
	"use strict";

	var app = WinJS.Application;
	var activation = Windows.ApplicationModel.Activation;

	app.onactivated = function (args) {
		if (args.detail.kind === activation.ActivationKind.launch) {
			if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
				// TODO: This application has been newly launched. Initialize your application here.
			} else {
				// TODO: This application has been reactivated from suspension.
				// Restore application state here.
			}
			args.setPromise(WinJS.UI.processAll());

			var buttonUpdateTile = document.getElementById("buttonUpdateTile");
			buttonUpdateTile.addEventListener("click", updateTile, false);

		}
	};

	app.oncheckpoint = function (args) {
		// TODO: This application is about to be suspended. Save any state that needs to persist across suspensions here.
		// You might use the WinJS.Application.sessionState object, which is automatically saved and restored across suspension.
		// If you need to complete an asynchronous operation before your application is suspended, call args.setPromise().
	};


	function updateTile(eventInfo) {
	    

	    //var tileContent = NotificationsExtensions.TileContent.TileContentFactory.createTileSquareText02();
	    //tileContent.textHeading.text = "Notification";
	    //tileContent.textBodyWrap.text = Date().toString();

	    //Windows.UI.Notifications.TileUpdateManager.createTileUpdaterForApplication().update(new Windows.UI.Notifications.TileNotification(tileContent.getXml()));



	    var small = NotificationsExtensions.TileContentFactory.adaptive.createSmall();

	    var text = new NotificationsExtensions.TileText();
	    text.source = new NotificationsExtensions.TileTextSource("Hello world");
	    text.wrap = true;
	    text.minLines = 2;
	    text.maxLines = 2;

	    small.children.append(text);



	    var tile = new NotificationsExtensions.TileContent();

	    tile.visual.largeTile = "What the fuck";

	    var messageDialog = new Windows.UI.Popups.MessageDialog("Success");
	    messageDialog.showAsync();
	}

	app.start();
})();



