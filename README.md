# NotificationsExtensions

Generate tile, toast, and badge notifications for Windows via code, with the help of IntelliSense, instead of directly using XML.

**Supports adaptive tiles and adaptive/interactive toast notifications for Windows 10!**

There are three *main goals* of NotificationsExtensions
* Make it easy to create tile, toast, and badge notifications from your code
* Ensure notification payloads are correctly formatted
* Ensure payloads consume as little space as possible (helping you stay under the 5 KB payload size limit)

NotificationsExtensions does the following...
* Automatically XML encodes string values
* Generates a minimal XML payload to keep payload size low (doesn't unnecessary write values that already match with default value)
* Provides IntelliSense support for all the supported properties/values of adaptive Tiles and adaptive/interactive toasts
* Supports some verification to ensure that your payload is valid


# How To: Tile Notifications

Here's a quick example of generating a basic notification. First, you'll need to add the namespace delcaration for Tiles...

    using NotificationsExtensions.Tiles;
  
Then create a new *TileContent* object...

    TileContent content = new TileContent()
    {
       Visual = new TileVisual()
       {
          Branding = TileBranding.Name,
          DisplayName = "My notification",
          
          TileMedium = new TileBinding()
          {
             Branding = TileBranding.Logo,
             
             Content = new TileBindingContentAdaptive()
             {
                Children =
                {
                    new TileText()
                    {
                        Text = "Hello world",
                        Style = TileTextStyle.Body
                    }
                }
            }
          }
       }
    };
    
    TileNotification notification = new TileNotification(content.GetXml());
    
    // Use typical WinRT API's now
