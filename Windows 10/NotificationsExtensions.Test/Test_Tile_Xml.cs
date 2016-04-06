using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotificationsExtensions.Tiles;

namespace NotificationsExtensions.Win10.Test
{
    [TestClass]
    public class Test_Tile_Xml
    {

        #region Tile
        
        [TestMethod]
        public void Test_Tile_Xml_Tile_Default()
        {
            TileContent tile = new TileContent();

            AssertPayload("<tile/>", tile);
        }
        
        [TestMethod]
        public void Test_Tile_Xml_Visual_Default()
        {
            // Assert the defaults
            AssertVisual("<visual/>", new TileVisual());
        }
        
        [TestMethod]
        public void Test_Tile_Xml_Visual_AddImageQuery_False()
        {
            AssertVisual(
            
                "<visual/>",
                    
                new TileVisual()
                {
                    AddImageQuery = false
                });
        }
        
        [TestMethod]
        public void Test_Tile_Xml_Visual_AddImageQuery_True()
        {
            AssertVisual(
                
                "<visual addImageQuery='true'/>",
                
                new TileVisual()
                {
                    AddImageQuery = true
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_BaseUri_Null()
        {
            AssertVisual(

                "<visual />",

                new TileVisual()
                {
                    BaseUri = null
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_BaseUri_Value()
        {
            AssertVisual(

                "<visual baseUri='http://msn.com/'/>",

                new TileVisual()
                {
                    BaseUri = new Uri("http://msn.com")
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_Branding_Auto()
        {
            AssertVisual(

                "<visual />",

                new TileVisual()
                {
                    Branding = TileBranding.Auto
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_Branding_Name()
        {
            AssertVisual(

                "<visual branding='name'/>",

                new TileVisual()
                {
                    Branding = TileBranding.Name
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_Branding_Logo()
        {
            AssertVisual(

                "<visual branding='logo'/>",

                new TileVisual()
                {
                    Branding = TileBranding.Logo
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_Branding_NameAndLogo()
        {
            AssertVisual(

                "<visual branding='nameAndLogo'/>",

                new TileVisual()
                {
                    Branding = TileBranding.NameAndLogo
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_Branding_None()
        {
            AssertVisual(

                "<visual branding='none'/>",

                new TileVisual()
                {
                    Branding = TileBranding.None
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_ContentId_Null()
        {
            AssertVisual(

                "<visual />",

                new TileVisual()
                {
                    ContentId = null
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_ContentId_Value()
        {
            AssertVisual(

                "<visual contentId='tsla'/>",

                new TileVisual()
                {   
                    ContentId = "tsla"
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_DisplayName_Null()
        {
            AssertVisual(

                "<visual />",

                new TileVisual()
                {
                    DisplayName = null
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_DisplayName_Value()
        {
            AssertVisual(

                "<visual displayName='My name'/>",

                new TileVisual()
                {
                    DisplayName = "My name"
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_Language_Null()
        {
            AssertVisual(

                "<visual />",

                new TileVisual()
                {
                    Language = null
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_Language_Value()
        {
            AssertVisual(

                "<visual lang='en-US'/>",

                new TileVisual()
                {
                    Language = "en-US"
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_Version_Null()
        {
            AssertVisual(

                "<visual />",

                new TileVisual()
                {
                    Version = null
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_Version_Value()
        {
            AssertVisual(

                "<visual version='3'/>",

                new TileVisual()
                {
                    Version = 3
                });
        }


        [TestMethod]
        public void Test_Tile_Xml_Visual_Arguments_Null()
        {
            AssertVisual(

                "<visual />",

                new TileVisual()
                {
                    Arguments = null
                });
        }


        [TestMethod]
        public void Test_Tile_Xml_Visual_Arguments_EmptyString()
        {
            AssertVisual(

                "<visual arguments=''/>",

                new TileVisual()
                {
                    Arguments = ""
                });
        }


        [TestMethod]
        public void Test_Tile_Xml_Visual_Arguments_Value()
        {
            AssertVisual(

                "<visual arguments='action=viewStory&amp;story=53'/>",

                new TileVisual()
                {
                    Arguments = "action=viewStory&story=53"
                });
        }


        [TestMethod]
        public void Test_Tile_Xml_Visual_LockDetailedStatus1_NoMatchingText()
        {
            AssertVisual(

                "<visual><binding template='TileWide' hint-lockDetailedStatus1='Status 1'><text>Awesome</text><text>Cool</text></binding></visual>",

                new TileVisual()
                {
                    LockDetailedStatus1 = "Status 1",

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new TileText() { Text = "Awesome" },
                                new TileText() { Text = "Cool" }
                            }
                        }
                    }
                }

                );
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_LockDetailedStatus1_MatchingText_InBinding()
        {
            AssertVisual(

                "<visual><binding template='TileWide'><text>Awesome</text><text>Cool</text><text id='1'>Status 1</text><text>Blah</text></binding></visual>",

                new TileVisual()
                {
                    LockDetailedStatus1 = "Status 1",

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new TileText() { Text = "Awesome" },
                                new TileText() { Text = "Cool" },
                                new TileText() { Text = "Status 1" },
                                new TileText() { Text = "Blah" }
                            }
                        }
                    }
                }

                );
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_LockDetailedStatus1_MatchingText_InSubgroup()
        {
            /// The lockscreen only looks at ID's in the immediate binding children. So anything in the groups/subgroups are
            /// ignored. Thus, if text matches there, it still has to be placed as a hint.

            AssertVisual(

                "<visual><binding template='TileWide' hint-lockDetailedStatus1='Status 1'><text>Awesome</text><group><subgroup><image src='Fable.jpg' /><text>Status 1</text><text>Cool</text></subgroup></group><text>Blah</text></binding></visual>",

                new TileVisual()
                {
                    LockDetailedStatus1 = "Status 1",

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new TileText() { Text = "Awesome" },
                                new TileGroup()
                                {
                                    Children =
                                    {
                                        new TileSubgroup()
                                        {
                                            Children =
                                            {
                                                new TileImage()
                                                {
                                                    Source = new TileImageSource("Fable.jpg")
                                                },
                                                new TileText() { Text = "Status 1" },
                                                new TileText() { Text = "Cool" }
                                            }
                                        }
                                    }
                                },
                                new TileText() { Text = "Blah" }
                            }
                        }
                    }
                }

                );
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_LockDetailedStatus2_NoMatchingText()
        {
            AssertVisual(

                "<visual><binding template='TileWide' hint-lockDetailedStatus2='Status 2'><text>Awesome</text><text>Cool</text></binding></visual>",

                new TileVisual()
                {
                    LockDetailedStatus2 = "Status 2",

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new TileText() { Text = "Awesome" },
                                new TileText() { Text = "Cool" }
                            }
                        }
                    }
                }

                );
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_LockDetailedStatus2_MatchingText_InBinding()
        {
            AssertVisual(

                "<visual><binding template='TileWide'><text>Awesome</text><text>Cool</text><text id='2'>Status 2</text><text>Blah</text></binding></visual>",

                new TileVisual()
                {
                    LockDetailedStatus2 = "Status 2",

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new TileText() { Text = "Awesome" },
                                new TileText() { Text = "Cool" },
                                new TileText() { Text = "Status 2" },
                                new TileText() { Text = "Blah" }
                            }
                        }
                    }
                }

                );
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_LockDetailedStatus2_MatchingText_InSubgroup()
        {
            AssertVisual(

                "<visual><binding template='TileWide' hint-lockDetailedStatus2='Status 2'><text>Awesome</text><group><subgroup><image src='Fable.jpg' /><text>Status 2</text><text>Cool</text></subgroup></group><text>Blah</text></binding></visual>",

                new TileVisual()
                {
                    LockDetailedStatus2 = "Status 2",

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new TileText() { Text = "Awesome" },
                                new TileGroup()
                                {
                                    Children =
                                    {
                                        new TileSubgroup()
                                        {
                                            Children =
                                            {
                                                new TileImage()
                                                {
                                                    Source = new TileImageSource("Fable.jpg")
                                                },
                                                new TileText() { Text = "Status 2" },
                                                new TileText() { Text = "Cool" }
                                            }
                                        }
                                    }
                                },
                                new TileText() { Text = "Blah" }
                            }
                        }
                    }
                }

                );
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_LockDetailedStatus3_NoMatchingText()
        {
            AssertVisual(

                "<visual><binding template='TileWide' hint-lockDetailedStatus3='Status 3'><text>Awesome</text><text>Cool</text></binding></visual>",

                new TileVisual()
                {
                    LockDetailedStatus3 = "Status 3",

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new TileText() { Text = "Awesome" },
                                new TileText() { Text = "Cool" }
                            }
                        }
                    }
                }

                );
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_LockDetailedStatus3_MatchingText_InBinding()
        {
            AssertVisual(

                "<visual><binding template='TileWide'><text>Awesome</text><text>Cool</text><text id='3'>Status 3</text><text>Blah</text></binding></visual>",

                new TileVisual()
                {
                    LockDetailedStatus3 = "Status 3",

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new TileText() { Text = "Awesome" },
                                new TileText() { Text = "Cool" },
                                new TileText() { Text = "Status 3" },
                                new TileText() { Text = "Blah" }
                            }
                        }
                    }
                }

                );
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Visual_LockDetailedStatus3_MatchingText_InSubgroup()
        {
            AssertVisual(

                "<visual><binding template='TileWide' hint-lockDetailedStatus3='Status 3'><text>Awesome</text><group><subgroup><image src='Fable.jpg' /><text>Status 3</text><text>Cool</text></subgroup></group><text>Blah</text></binding></visual>",

                new TileVisual()
                {
                    LockDetailedStatus3 = "Status 3",

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new TileText() { Text = "Awesome" },
                                new TileGroup()
                                {
                                    Children =
                                    {
                                        new TileSubgroup()
                                        {
                                            Children =
                                            {
                                                new TileImage()
                                                {
                                                    Source = new TileImageSource("Fable.jpg")
                                                },
                                                new TileText() { Text = "Status 3" },
                                                new TileText() { Text = "Cool" }
                                            }
                                        }
                                    }
                                },
                                new TileText() { Text = "Blah" }
                            }
                        }
                    }
                }

                );
        }

        #endregion




        #region Binding

        [TestMethod]
        public void Test_Tile_Xml_Binding_Default()
        {
            AssertBindingMedium("<binding template='TileMedium'/>", new TileBinding());
        }

        [TestMethod]
        public void Test_Tile_Xml_Binding_AddImageQuery_False()
        {
            AssertBindingMedium(

                "<binding template='TileMedium'/>",

                new TileBinding()
                {
                    AddImageQuery = false
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Binding_AddImageQuery_True()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' addImageQuery='true'/>",

                new TileBinding()
                {
                    AddImageQuery = true
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Binding_BaseUri_Null()
        {
            AssertBindingMedium(

                "<binding template='TileMedium'/>",

                new TileBinding()
                {
                    BaseUri = null
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Binding_BaseUri_Value()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' baseUri='http://msn.com/'/>",

                new TileBinding()
                {
                    BaseUri = new Uri("http://msn.com")
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Binding_Branding_Auto()
        {
            AssertBindingMedium(
                
                "<binding template='TileMedium'/>",

                new TileBinding()
                {
                    Branding = TileBranding.Auto
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Binding_Branding_None()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' branding='none'/>",

                new TileBinding()
                {
                    Branding = TileBranding.None
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Binding_Branding_Name()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' branding='name'/>",

                new TileBinding()
                {
                    Branding = TileBranding.Name
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Binding_Branding_Logo()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' branding='logo'/>",

                new TileBinding()
                {
                    Branding = TileBranding.Logo
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Binding_Branding_NameAndLogo()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' branding='nameAndLogo'/>",

                new TileBinding()
                {
                    Branding = TileBranding.NameAndLogo
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Binding_ContentId_Null()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' />",

                new TileBinding()
                {
                    ContentId = null
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Binding_ContentId_Value()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' contentId='myId'/>",

                new TileBinding()
                {
                    ContentId = "myId"
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Binding_DisplayName_Null()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' />",

                new TileBinding()
                {
                    DisplayName = null
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Binding_DisplayName_Value()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' displayName='My name'/>",

                new TileBinding()
                {
                    DisplayName = "My name"
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Binding_Language_Null()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' />",

                new TileBinding()
                {
                    Language = null
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Binding_Language_Value()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' lang='en-US'/>",

                new TileBinding()
                {
                    Language = "en-US"
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Binding_Arguments_Null()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' />",

                new TileBinding()
                {
                    Arguments = null
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Binding_Arguments_EmptyString()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' arguments='' />",

                new TileBinding()
                {
                    Arguments = ""
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Binding_Arguments_Value()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' arguments='action=viewStory&amp;storyId=52' />",

                new TileBinding()
                {
                    Arguments = "action=viewStory&storyId=52"
                });
        }

        #endregion





        #region Adaptive


        #region Root

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Root_Defaults()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' />",

                new TileBinding()
                {
                    Content = new TileBindingContentAdaptive()
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Root_BackgroundImage_Value()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' hint-overlay='20'><image src='http://msn.com/image.png' placement='background' /></binding>",

                new TileBinding()
                {
                    Content = new TileBindingContentAdaptive()
                    {
                        BackgroundImage = new TileBackgroundImage()
                        {
                            Source = new TileImageSource("http://msn.com/image.png")
                        }
                    }
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Root_Overlay_Default()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' hint-overlay='20'><image src='Fable.jpg' placement='background' /></binding>",

                new TileBinding()
                {
                    Content = new TileBindingContentAdaptive()
                    {
                        BackgroundImage = new TileBackgroundImage()
                        {
                            Overlay = 20,
                            Source = new TileImageSource("Fable.jpg")
                        }
                    }
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Root_Overlay_Min()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' hint-overlay='0'><image src='Fable.jpg' placement='background' /></binding>",

                new TileBinding()
                {
                    Content = new TileBindingContentAdaptive()
                    {
                        BackgroundImage = new TileBackgroundImage()
                        {
                            Overlay = 0,
                            Source = new TileImageSource("Fable.jpg")
                        }
                    }
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Root_Overlay_Max()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' hint-overlay='100'><image src='Fable.jpg' placement='background' /></binding>",

                new TileBinding()
                {
                    Content = new TileBindingContentAdaptive()
                    {
                        BackgroundImage = new TileBackgroundImage()
                        {
                            Overlay = 100,
                            Source = new TileImageSource("Fable.jpg")
                        }
                    }
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Root_Overlay_AboveDefault()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' hint-overlay='40'><image src='Fable.jpg' placement='background' /></binding>",

                new TileBinding()
                {
                    Content = new TileBindingContentAdaptive()
                    {
                        BackgroundImage = new TileBackgroundImage()
                        {
                            Overlay = 40,
                            Source = new TileImageSource("Fable.jpg")
                        }
                    }
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Root_Overlay_BelowDefault()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' hint-overlay='10'><image src='Fable.jpg' placement='background' /></binding>",

                new TileBinding()
                {
                    Content = new TileBindingContentAdaptive()
                    {
                        BackgroundImage = new TileBackgroundImage()
                        {
                            Overlay = 10,
                            Source = new TileImageSource("Fable.jpg")
                        }
                    }
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_BackgroundImage_Overlay_BelowMin()
        {
            try
            {
                new TileBackgroundImage()
                {
                    Overlay = -1,
                    Source = new TileImageSource("Fable.jpg")
                };
            }

            catch { return; }

            Assert.Fail("Exception should have been thrown.");
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Root_Overlay_AboveMax()
        {
            try
            {
                new TileBackgroundImage()
                {
                    Overlay = 101,
                    Source = new TileImageSource("Fable.jpg")
                };
            }

            catch { return; }

            Assert.Fail("Exception should have been thrown.");
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Root_PeekImage_Value()
        {
            AssertBindingMedium(

                "<binding template='TileMedium'><image src='http://msn.com' alt='alt' addImageQuery='true' placement='peek'/></binding>",

                new TileBinding()
                {
                    Content = new TileBindingContentAdaptive()
                    {
                        PeekImage = new TilePeekImage()
                        {
                            Source = new TileImageSource("http://msn.com")
                            {
                                Alt = "alt",
                                AddImageQuery = true
                            }
                        }
                    }
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Root_TextStacking_Top()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' />",

                new TileBinding()
                {
                    Content = new TileBindingContentAdaptive()
                    {
                        TextStacking = TileTextStacking.Top
                    }
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Root_TextStacking_Center()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' hint-textStacking='center'/>",

                new TileBinding()
                {
                    Content = new TileBindingContentAdaptive()
                    {
                        TextStacking = TileTextStacking.Center
                    }
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Root_TextStacking_Bottom()
        {
            AssertBindingMedium(

                "<binding template='TileMedium' hint-textStacking='bottom'/>",

                new TileBinding()
                {
                    Content = new TileBindingContentAdaptive()
                    {
                        TextStacking = TileTextStacking.Bottom
                    }
                });
        }

        #endregion


        #region Text


        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_AllStyles()
        {
            AssertTextStyle("base", TileTextStyle.Base);
            AssertTextStyle("baseSubtle", TileTextStyle.BaseSubtle);
            AssertTextStyle("body", TileTextStyle.Body);
            AssertTextStyle("bodySubtle", TileTextStyle.BodySubtle);
            // Omit caption since it's default and is not written to XML
            AssertTextStyle("captionSubtle", TileTextStyle.CaptionSubtle);
            AssertTextStyle("header", TileTextStyle.Header);
            AssertTextStyle("headerNumeral", TileTextStyle.HeaderNumeral);
            AssertTextStyle("headerSubtle", TileTextStyle.HeaderSubtle);
            AssertTextStyle("subheader", TileTextStyle.Subheader);
            AssertTextStyle("subheaderNumeral", TileTextStyle.SubheaderNumeral);
            AssertTextStyle("subheaderSubtle", TileTextStyle.SubheaderSubtle);
            AssertTextStyle("subtitle", TileTextStyle.Subtitle);
            AssertTextStyle("subtitleSubtle", TileTextStyle.SubtitleSubtle);
            AssertTextStyle("title", TileTextStyle.Title);
            AssertTextStyle("titleNumeral", TileTextStyle.TitleNumeral);
            AssertTextStyle("titleSubtle", TileTextStyle.TitleSubtle);
        }
        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_Defaults()
        {
            AssertAdaptiveText("<text/>", new TileText());
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_Align_Auto()
        {
            AssertAdaptiveText(

                "<text/>",

                new TileText()
                {
                    Align = TileTextAlign.Auto
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_Align_Left()
        {
            AssertAdaptiveText(

                "<text hint-align='left'/>",

                new TileText()
                {
                    Align = TileTextAlign.Left
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_Align_Center()
        {
            AssertAdaptiveText(

                "<text hint-align='center'/>",

                new TileText()
                {
                    Align = TileTextAlign.Center
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_Align_Right()
        {
            AssertAdaptiveText(

                "<text hint-align='right'/>",

                new TileText()
                {
                    Align = TileTextAlign.Right
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_Lang_Value()
        {
            AssertAdaptiveText(

                "<text lang='en-US'/>",

                new TileText()
                {
                    Lang = "en-US"
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_MaxLines_Min()
        {
            AssertAdaptiveText(

                "<text hint-maxLines='1'/>",

                new TileText()
                {
                    MaxLines = 1
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_MaxLines_Normal()
        {
            AssertAdaptiveText(

                "<text hint-maxLines='5'/>",

                new TileText()
                {
                    MaxLines = 5
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_MaxLines_Max()
        {
            AssertAdaptiveText(

                $"<text />",

                new TileText()
                {
                    MaxLines = int.MaxValue
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_MaxLines_BelowMin()
        {
            try
            {
                new TileText()
                {
                    MaxLines = 0
                };
            }

            catch { return; }

            Assert.Fail("Exception should have been thrown.");
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_MinLines_Min()
        {
            AssertAdaptiveText(

                "<text />",

                new TileText()
                {
                    MinLines = 1
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_MinLines_Normal()
        {
            AssertAdaptiveText(

                "<text hint-minLines='5'/>",

                new TileText()
                {
                    MinLines = 5
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_MinLines_Max()
        {
            AssertAdaptiveText(

                $"<text hint-minLines='{int.MaxValue}'/>",

                new TileText()
                {
                    MinLines = int.MaxValue
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_MinLines_BelowMin()
        {
            try
            {
                new TileText()
                {
                    MinLines = 0
                };
            }

            catch { return; }

            Assert.Fail("Exception should have been thrown.");
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_Style_Caption()
        {
            AssertAdaptiveText(

                "<text />",

                new TileText()
                {
                    Style = TileTextStyle.Caption
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_Style_HeaderSubtle()
        {
            AssertAdaptiveText(

                "<text hint-style='headerSubtle'/>",

                new TileText()
                {
                    Style = TileTextStyle.HeaderSubtle
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_Value()
        {
            AssertAdaptiveText(

                "<text>Hello world</text>",

                new TileText()
                {
                    Text = "Hello world"
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_Wrap_False()
        {
            AssertAdaptiveText(

                "<text />",

                new TileText()
                {
                    Wrap = false
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Text_Wrap_True()
        {
            AssertAdaptiveText(

                "<text hint-wrap='true'/>",

                new TileText()
                {
                    Wrap = true
                });
        }

        #endregion


        #region Image

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Image_Defaults()
        {
            AssertAdaptiveImage("<image src='Fable.jpg'/>", new TileImage()
            {
                Source = new TileImageSource("Fable.jpg")
            });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Image_Align_Stretch()
        {
            AssertAdaptiveImage(

                "<image src='Fable.jpg'/>",

                new TileImage()
                {
                    Align = TileImageAlign.Stretch,
                    Source = new TileImageSource("Fable.jpg")
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Image_Align_Left()
        {
            AssertAdaptiveImage(

                "<image hint-align='left' src='Fable.jpg'/>",

                new TileImage()
                {
                    Align = TileImageAlign.Left,
                    Source = new TileImageSource("Fable.jpg")
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Image_Align_Center()
        {
            AssertAdaptiveImage(

                "<image hint-align='center' src='Fable.jpg'/>",

                new TileImage()
                {
                    Align = TileImageAlign.Center,
                    Source = new TileImageSource("Fable.jpg")
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Image_Align_Right()
        {
            AssertAdaptiveImage(

                "<image hint-align='right' src='Fable.jpg'/>",

                new TileImage()
                {
                    Align = TileImageAlign.Right,
                    Source = new TileImageSource("Fable.jpg")
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Image_Crop_None()
        {
            AssertAdaptiveImage(

                "<image src='Fable.jpg'/>",

                new TileImage()
                {
                    Crop = TileImageCrop.None,
                    Source = new TileImageSource("Fable.jpg")
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Image_Crop_Circle()
        {
            AssertAdaptiveImage(

                "<image hint-crop='circle' src='Fable.jpg'/>",

                new TileImage()
                {
                    Crop = TileImageCrop.Circle,
                    Source = new TileImageSource("Fable.jpg")
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Image_RemoveMargin_False()
        {
            AssertAdaptiveImage(

                "<image src='Fable.jpg'/>",

                new TileImage()
                {
                    RemoveMargin = false,
                    Source = new TileImageSource("Fable.jpg")
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Image_RemoveMargin_True()
        {
            AssertAdaptiveImage(

                "<image hint-removeMargin='true' src='Fable.jpg'/>",

                new TileImage()
                {
                    RemoveMargin = true,
                    Source = new TileImageSource("Fable.jpg")
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Image_Source_Value()
        {
            AssertAdaptiveImage(

                "<image src='http://msn.com' addImageQuery='true' alt='alt'/>",

                new TileImage()
                {
                    Source = new TileImageSource("http://msn.com")
                    {
                        AddImageQuery = true,
                        Alt = "alt"
                    }
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Image_Source_Defaults()
        {
            AssertAdaptiveImage(

                "<image src='http://msn.com'/>",

                new TileImage()
                {
                    Source = new TileImageSource("http://msn.com")
                });
        }

        #endregion


        #region BackgroundImage

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_BackgroundImage_Defaults()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium' hint-overlay='20'><image src='http://msn.com' placement='background'/></binding>",

                new TileBindingContentAdaptive()
                {
                    BackgroundImage = new TileBackgroundImage()
                    {
                        Source = new TileImageSource("http://msn.com")
                    }
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_BackgroundImage_Source()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium' hint-overlay='20'><image src='http://msn.com' placement='background' addImageQuery='true' alt='MSN Image'/></binding>",

                new TileBindingContentAdaptive()
                {
                    BackgroundImage = new TileBackgroundImage()
                    {
                        Source = new TileImageSource("http://msn.com")
                        {
                            AddImageQuery = true,
                            Alt = "MSN Image"
                        }
                    }
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_BackgroundImage_Crop_None()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium' hint-overlay='20'><image src='http://msn.com' placement='background'/></binding>",

                new TileBindingContentAdaptive()
                {
                    BackgroundImage = new TileBackgroundImage()
                    {
                        Source = new TileImageSource("http://msn.com"),
                        Crop = TileImageCrop.None
                    }
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_BackgroundImage_Crop_Circle()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium' hint-overlay='20'><image src='http://msn.com' placement='background' hint-crop='circle'/></binding>",

                new TileBindingContentAdaptive()
                {
                    BackgroundImage = new TileBackgroundImage()
                    {
                        Source = new TileImageSource("http://msn.com"),
                        Crop = TileImageCrop.Circle
                    }
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_BackgroundImage_Overlay_0()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium' hint-overlay='0'><image src='http://msn.com' placement='background'/></binding>",

                new TileBindingContentAdaptive()
                {
                    BackgroundImage = new TileBackgroundImage()
                    {
                        Source = new TileImageSource("http://msn.com"),
                        Overlay = 0
                    }
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_BackgroundImage_Overlay_20()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium' hint-overlay='20'><image src='http://msn.com' placement='background'/></binding>",

                new TileBindingContentAdaptive()
                {
                    BackgroundImage = new TileBackgroundImage()
                    {
                        Source = new TileImageSource("http://msn.com"),
                        Overlay = 20
                    }
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_BackgroundImage_Overlay_80()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium' hint-overlay='80'><image src='http://msn.com' placement='background'/></binding>",

                new TileBindingContentAdaptive()
                {
                    BackgroundImage = new TileBackgroundImage()
                    {
                        Source = new TileImageSource("http://msn.com"),
                        Overlay = 80
                    }
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_BackgroundImage_NoImageSource()
        {
            try
            {
                TileContent c = new TileContent()
                {
                    Visual = new TileVisual()
                    {
                        TileMedium = new TileBinding()
                        {
                            Content = new TileBindingContentAdaptive()
                            {
                                BackgroundImage = new TileBackgroundImage()
                                {
                                    // No source, which should throw exception
                                }
                            }
                        }
                    }
                };

                c.GetContent();
            }

            catch (NullReferenceException)
            {
                return;
            }

            Assert.Fail("Exception should have been thrown");
        }

        #endregion

        #region PeekImage

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_PeekImage_Defaults()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium'><image src='http://msn.com' placement='peek'/></binding>",

                new TileBindingContentAdaptive()
                {
                    PeekImage = new TilePeekImage()
                    {
                        Source = new TileImageSource("http://msn.com")
                    }
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_PeekImage_Source()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium'><image src='http://msn.com' placement='peek' addImageQuery='true' alt='MSN Image'/></binding>",

                new TileBindingContentAdaptive()
                {
                    PeekImage = new TilePeekImage()
                    {
                        Source = new TileImageSource("http://msn.com")
                        {
                            AddImageQuery = true,
                            Alt = "MSN Image"
                        }
                    }
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_PeekImage_Crop_None()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium'><image src='http://msn.com' placement='peek'/></binding>",

                new TileBindingContentAdaptive()
                {
                    PeekImage = new TilePeekImage()
                    {
                        Source = new TileImageSource("http://msn.com"),
                        Crop = TileImageCrop.None
                    }
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_PeekImage_Crop_Circle()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium'><image src='http://msn.com' placement='peek' hint-crop='circle'/></binding>",

                new TileBindingContentAdaptive()
                {
                    PeekImage = new TilePeekImage()
                    {
                        Source = new TileImageSource("http://msn.com"),
                        Crop = TileImageCrop.Circle
                    }
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_PeekImage_Overlay_0()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium'><image src='http://msn.com' placement='peek'/></binding>",

                new TileBindingContentAdaptive()
                {
                    PeekImage = new TilePeekImage()
                    {
                        Source = new TileImageSource("http://msn.com"),
                        Overlay = 0
                    }
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_PeekImage_Overlay_20()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium'><image src='http://msn.com' placement='peek' hint-overlay='20'/></binding>",

                new TileBindingContentAdaptive()
                {
                    PeekImage = new TilePeekImage()
                    {
                        Source = new TileImageSource("http://msn.com"),
                        Overlay = 20
                    }
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_PeekImage_Overlay_80()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium'><image src='http://msn.com' placement='peek' hint-overlay='80'/></binding>",

                new TileBindingContentAdaptive()
                {
                    PeekImage = new TilePeekImage()
                    {
                        Source = new TileImageSource("http://msn.com"),
                        Overlay = 80
                    }
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_PeekImage_NoImageSource()
        {
            try
            {
                TileContent c = new TileContent()
                {
                    Visual = new TileVisual()
                    {
                        TileMedium = new TileBinding()
                        {
                            Content = new TileBindingContentAdaptive()
                            {
                                PeekImage = new TilePeekImage()
                                {
                                    // No source, which should throw exception when content retrieved
                                }
                            }
                        }
                    }
                };

                c.GetContent();
            }

            catch (NullReferenceException)
            {
                return;
            }

            Assert.Fail("Exception should have been thrown");
        }

        #endregion



        [TestMethod]
        public void Test_Tile_Xml_Adaptive_BackgroundAndPeekImage_Defaults()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium' hint-overlay='20'><image src='Background.jpg' placement='background'/><image src='Peek.jpg' placement='peek' hint-overlay='0'/></binding>",

                new TileBindingContentAdaptive()
                {
                    BackgroundImage = new TileBackgroundImage()
                    {
                        Source = new TileImageSource("Background.jpg")
                    },

                    PeekImage = new TilePeekImage()
                    {
                        Source = new TileImageSource("Peek.jpg")
                    }
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_BackgroundAndPeekImage_Overlay_0and0()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium' hint-overlay='0'><image src='Background.jpg' placement='background'/><image src='Peek.jpg' placement='peek'/></binding>",

                new TileBindingContentAdaptive()
                {
                    BackgroundImage = new TileBackgroundImage()
                    {
                        Source = new TileImageSource("Background.jpg"),
                        Overlay = 0
                    },

                    PeekImage = new TilePeekImage()
                    {
                        Source = new TileImageSource("Peek.jpg"),
                        Overlay = 0
                    }
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_BackgroundAndPeekImage_Overlay_20and20()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium' hint-overlay='20'><image src='Background.jpg' placement='background'/><image src='Peek.jpg' placement='peek'/></binding>",

                new TileBindingContentAdaptive()
                {
                    BackgroundImage = new TileBackgroundImage()
                    {
                        Source = new TileImageSource("Background.jpg"),
                        Overlay = 20
                    },

                    PeekImage = new TilePeekImage()
                    {
                        Source = new TileImageSource("Peek.jpg"),
                        Overlay = 20
                    }
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_BackgroundAndPeekImage_Overlay_20and30()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium' hint-overlay='20'><image src='Background.jpg' placement='background'/><image src='Peek.jpg' placement='peek' hint-overlay='30'/></binding>",

                new TileBindingContentAdaptive()
                {
                    BackgroundImage = new TileBackgroundImage()
                    {
                        Source = new TileImageSource("Background.jpg"),
                        Overlay = 20
                    },

                    PeekImage = new TilePeekImage()
                    {
                        Source = new TileImageSource("Peek.jpg"),
                        Overlay = 30
                    }
                });
        }

        [TestMethod]
        public void Test_Tile_Xml_Adaptive_BackgroundAndPeekImage_Overlay_30and20()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium' hint-overlay='30'><image src='Background.jpg' placement='background'/><image src='Peek.jpg' placement='peek' hint-overlay='20'/></binding>",

                new TileBindingContentAdaptive()
                {
                    BackgroundImage = new TileBackgroundImage()
                    {
                        Source = new TileImageSource("Background.jpg"),
                        Overlay = 30
                    },

                    PeekImage = new TilePeekImage()
                    {
                        Source = new TileImageSource("Peek.jpg"),
                        Overlay = 20
                    }
                });
        }


        [TestMethod]
        public void Test_Tile_Xml_Adaptive_BackgroundAndPeekImage_Overlay_0and20()
        {
            AssertBindingMediumAdaptive(

                "<binding template='TileMedium' hint-overlay='0'><image src='Background.jpg' placement='background'/><image src='Peek.jpg' placement='peek' hint-overlay='20'/></binding>",

                new TileBindingContentAdaptive()
                {
                    BackgroundImage = new TileBackgroundImage()
                    {
                        Source = new TileImageSource("Background.jpg"),
                        Overlay = 0
                    },

                    PeekImage = new TilePeekImage()
                    {
                        Source = new TileImageSource("Peek.jpg"),
                        Overlay = 20
                    }
                });
        }

        #region Group


        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Group_Defaults()
        {
            AssertBindingMedium(

                "<binding template='TileMedium'><group/></binding>",

                new TileBinding()
                {
                    Content = new TileBindingContentAdaptive()
                    {
                        Children =
                        {
                            new TileGroup()
                        }
                    }
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Group_Multiple()
        {
            AssertBindingMedium(

                "<binding template='TileMedium'><group/><group/><group/></binding>",

                new TileBinding()
                {
                    Content = new TileBindingContentAdaptive()
                    {
                        Children =
                        {
                            new TileGroup(),
                            new TileGroup(),
                            new TileGroup()
                        }
                    }
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Group_WithSubgroups()
        {
            AssertBindingMedium(

                "<binding template='TileMedium'><group><subgroup /><subgroup /></group></binding>",

                new TileBinding()
                {
                    Content = new TileBindingContentAdaptive()
                    {
                        Children =
                        {
                            new TileGroup()
                            {
                                Children =
                                {
                                    new TileSubgroup(),
                                    new TileSubgroup()
                                }
                            }
                        }
                    }
                });
        }

        #endregion



        #region Subgroup

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Subgroup_Defaults()
        {
            AssertSubgroup("<subgroup/>", new TileSubgroup());
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Subgroup_TextStacking_Top()
        {
            AssertSubgroup(

                "<subgroup />",

                new TileSubgroup()
                {
                    TextStacking = TileTextStacking.Top
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Subgroup_TextStacking_Center()
        {
            AssertSubgroup(

                "<subgroup hint-textStacking='center'/>",

                new TileSubgroup()
                {
                    TextStacking = TileTextStacking.Center
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Subgroup_TextStacking_Bottom()
        {
            AssertSubgroup(

                "<subgroup hint-textStacking='bottom'/>",

                new TileSubgroup()
                {
                    TextStacking = TileTextStacking.Bottom
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Subgroup_Weight_Min()
        {
            AssertSubgroup(

                "<subgroup hint-weight='1'/>",

                new TileSubgroup()
                {
                    Weight = 1
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Subgroup_Weight_Normal()
        {
            AssertSubgroup(

                "<subgroup hint-weight='30'/>",

                new TileSubgroup()
                {
                    Weight = 30
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Subgroup_Weight_Larger()
        {
            AssertSubgroup(

                "<subgroup hint-weight='200'/>",

                new TileSubgroup()
                {
                    Weight = 200
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Subgroup_Weight_Max()
        {
            AssertSubgroup(

                $"<subgroup hint-weight='{int.MaxValue}'/>",

                new TileSubgroup()
                {
                    Weight = int.MaxValue
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Subgroup_Weight_BelowMin()
        {
            try
            {
                new TileSubgroup()
                {
                    Weight = 0
                };
            }

            catch { return; }

            Assert.Fail("Exception should have been thrown.");
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Subgroup_WithChildren()
        {
            AssertSubgroup(

                "<subgroup><text/><image src='Fable.jpg'/></subgroup>",

                new TileSubgroup()
                {
                    Children =
                    {
                        new TileText(),
                        new TileImage()
                        {
                            Source = new TileImageSource("Fable.jpg")
                        }
                    }
                });
        }

        
        [TestMethod]
        public void Test_Tile_Xml_Adaptive_Subgroup_AllProperties()
        {
            AssertSubgroup(

                "<subgroup hint-weight='10' hint-textStacking='center'><text>Hello</text><image src='Image.jpg'/></subgroup>",

                new TileSubgroup()
                {
                    Weight = 10,
                    TextStacking = TileTextStacking.Center,
                    Children =
                    {
                        new TileText() { Text = "Hello" },
                        new TileImage()
                        {
                            Source = new TileImageSource("Image.jpg")
                        }
                    }
                });
        }

        #endregion



        #endregion



        #region Special

        #region Photos

        [TestMethod]
        public void Test_Tile_Xml_Special_Photos_Default()
        {
            TileBindingContentPhotos content = new TileBindingContentPhotos()
            {
            };

            AssertBindingMedium("<binding template='TileMedium' hint-presentation='photos'/>", new TileBinding()
            {
                Content = content
            });
        }

        [TestMethod]
        public void Test_Tile_Xml_Special_Photos_OneImage()
        {
            TileBindingContentPhotos content = new TileBindingContentPhotos()
            {
                Images =
                {
                    new TileImageSource("http://msn.com/1.jpg")
                    {
                        AddImageQuery = true,
                        Alt = "alternate"
                    }
                }
            };

            AssertBindingMedium("<binding template='TileMedium' hint-presentation='photos'><image src='http://msn.com/1.jpg' addImageQuery='true' alt='alternate'/></binding>", new TileBinding()
            {
                Content = content
            });
        }

        [TestMethod]
        public void Test_Tile_Xml_Special_Photos_TwoImages()
        {
            TileBindingContentPhotos content = new TileBindingContentPhotos()
            {
                Images =
                {
                    new TileImageSource("Assets/1.jpg"),
                    new TileImageSource("Assets/2.jpg")
                }
            };

            AssertBindingMedium("<binding template='TileMedium' hint-presentation='photos'><image src='Assets/1.jpg'/><image src='Assets/2.jpg'/></binding>", new TileBinding()
            {
                Content = content
            });
        }

        [TestMethod]
        public void Test_Tile_Xml_Special_Photos_MaxImages()
        {
            TileBindingContentPhotos content = new TileBindingContentPhotos()
            {
                Images =
                {
                    new TileImageSource("1.jpg"),
                    new TileImageSource("2.jpg"),
                    new TileImageSource("3.jpg"),
                    new TileImageSource("4.jpg"),
                    new TileImageSource("5.jpg"),
                    new TileImageSource("6.jpg"),
                    new TileImageSource("7.jpg"),
                    new TileImageSource("8.jpg"),
                    new TileImageSource("9.jpg")
                }
            };

            AssertBindingMedium(@"<binding template='TileMedium' hint-presentation='photos'>
                <image src='1.jpg'/>
                <image src='2.jpg'/>
                <image src='3.jpg'/>
                <image src='4.jpg'/>
                <image src='5.jpg'/>
                <image src='6.jpg'/>
                <image src='7.jpg'/>
                <image src='8.jpg'/>
                <image src='9.jpg'/>
            </binding>", new TileBinding()
            {
                Content = content
            });
        }

        [TestMethod]
        public void Test_Tile_Xml_Special_Photos_TooManyImages()
        {
            try
            {
                new TileBindingContentPhotos()
                {
                    Images =
                    {
                        new TileImageSource("1.jpg"),
                        new TileImageSource("2.jpg"),
                        new TileImageSource("3.jpg"),
                        new TileImageSource("4.jpg"),
                        new TileImageSource("5.jpg"),
                        new TileImageSource("6.jpg"),
                        new TileImageSource("7.jpg"),
                        new TileImageSource("8.jpg"),
                        new TileImageSource("9.jpg"),
                        new TileImageSource("10.jpg")
                    }
                };
            }

            catch { return; }

            Assert.Fail("Exception should have been thrown, adding more than 9 images isn't supported.");
        }

        #endregion

        #region People

        [TestMethod]
        public void Test_Tile_Xml_Special_People_Defaults()
        {
            TileBindingContentPeople content = new TileBindingContentPeople();

            AssertBindingMedium("<binding template='TileMedium' hint-presentation='people'/>", new TileBinding()
            {
                Content = content
            });
        }

        [TestMethod]
        public void Test_Tile_Xml_Special_People_OneImage()
        {
            TileBindingContentPeople content = new TileBindingContentPeople()
            {
                Images =
                {
                    new TileImageSource("http://msn.com/1.jpg")
                    {
                        AddImageQuery = true,
                        Alt = "alternate"
                    }
                }
            };

            AssertBindingMedium("<binding template='TileMedium' hint-presentation='people'><image src='http://msn.com/1.jpg' addImageQuery='true' alt='alternate'/></binding>", new TileBinding()
            {
                Content = content
            });
        }

        [TestMethod]
        public void Test_Tile_Xml_Special_People_TwoImages()
        {
            TileBindingContentPeople content = new TileBindingContentPeople()
            {
                Images =
                {
                    new TileImageSource("Assets/1.jpg"),
                    new TileImageSource("Assets/2.jpg")
                }
            };

            AssertBindingMedium("<binding template='TileMedium' hint-presentation='people'><image src='Assets/1.jpg'/><image src='Assets/2.jpg'/></binding>", new TileBinding()
            {
                Content = content
            });
        }

        [TestMethod]
        public void Test_Tile_Xml_Special_People_ManyImages()
        {
            string payload = "<binding template='TileMedium' hint-presentation='people'>";

            TileBindingContentPeople content = new TileBindingContentPeople();

            // Add 30 images
            for (int i = 1; i <= 30; i++)
            {
                string src = i + ".jpg";

                content.Images.Add(new TileImageSource(src));
                payload += $"<image src='{src}'/>";
            }

            payload += "</binding>";

            AssertBindingMedium(payload, new TileBinding()
            {
                Content = content
            });
        }

        #endregion

        #region Contact

        [TestMethod]
        public void Test_Tile_Xml_Special_Contact_Defaults()
        {
            TileBindingContentContact content = new TileBindingContentContact();

            AssertBindingMedium("<binding template='TileMedium' hint-presentation='contact'/>", new TileBinding()
            {
                Content = content
            });
        }

        [TestMethod]
        public void Test_Tile_Xml_Special_Contact_Text()
        {
            TileBindingContentContact content = new TileBindingContentContact()
            {
                Text = new TileBasicText()
                {
                    Text = "Hello world",
                    Lang = "en-US"
                }
            };

            AssertBindingMedium("<binding template='TileMedium' hint-presentation='contact'><text lang='en-US'>Hello world</text></binding>", new TileBinding()
            {
                Content = content
            });
        }

        [TestMethod]
        public void Test_Tile_Xml_Special_Contact_Image()
        {
            TileBindingContentContact content = new TileBindingContentContact()
            {
                Image = new TileImageSource("http://msn.com/img.jpg")
                {
                    AddImageQuery = true,
                    Alt = "John Smith"
                }
            };

            AssertBindingMedium("<binding template='TileMedium' hint-presentation='contact'><image src='http://msn.com/img.jpg' addImageQuery='true' alt='John Smith'/></binding>", new TileBinding()
            {
                Content = content
            });
        }

        [TestMethod]
        public void Test_Tile_Xml_Special_Contact_Both_Small()
        {
            TileBindingContentContact content = new TileBindingContentContact()
            {
                Text = new TileBasicText()
                {
                    Text = "Hello world"
                },

                Image = new TileImageSource("Assets/img.jpg")
            };

            // Small doesn't support the text, so it doesn't output the text element when rendered for small
            AssertVisual("<visual><binding template='TileSmall' hint-presentation='contact'><image src='Assets/img.jpg'/></binding></visual>", new TileVisual()
            {
                TileSmall = new TileBinding() { Content = content }
            });
        }

        [TestMethod]
        public void Test_Tile_Xml_Special_Contact_Both_Medium()
        {
            TileBindingContentContact content = new TileBindingContentContact()
            {
                Text = new TileBasicText()
                {
                    Text = "Hello world"
                },

                Image = new TileImageSource("Assets/img.jpg")
            };

            // Text is written before the image element
            AssertVisual("<visual><binding template='TileMedium' hint-presentation='contact'><text>Hello world</text><image src='Assets/img.jpg'/></binding></visual>", new TileVisual()
            {
                TileMedium = new TileBinding() { Content = content }
            });
        }

        #endregion

        #region Iconic

        [TestMethod]
        public void Test_Tile_Xml_Special_Iconic_Small()
        {
            AssertVisual("<visual><binding template='TileSquare71x71IconWithBadge'/></visual>", new TileVisual()
            {
                TileSmall = new TileBinding() { Content = new TileBindingContentIconic() }
            });
        }

        [TestMethod]
        public void Test_Tile_Xml_Special_Iconic_Medium()
        {
            AssertVisual("<visual><binding template='TileSquare150x150IconWithBadge'/></visual>", new TileVisual()
            {
                TileMedium = new TileBinding() { Content = new TileBindingContentIconic() }
            });
        }

        [TestMethod]
        public void Test_Tile_Xml_Special_Iconic_Image()
        {
            AssertVisual("<visual><binding template='TileSquare150x150IconWithBadge'><image id='1' src='Assets/Iconic.png' alt='iconic'/></binding></visual>", new TileVisual()
            {
                TileMedium = new TileBinding() { Content = new TileBindingContentIconic()
                    {
                        Icon = new TileImageSource("Assets/Iconic.png")
                        {
                            Alt = "iconic"
                        }
                    }
                }
            });
        }

        #endregion

        #endregion









        private static void AssertTextStyle(string expectedStyle, TileTextStyle style)
        {
            AssertAdaptiveText($"<text hint-style='{expectedStyle}'>Hello world</text>", new TileText()
            {
                Style = style,
                Text = "Hello world"
            });
        }

        private static void AssertSubgroup(string expectedSubgroupXml, TileSubgroup subgroup)
        {
            AssertBindingMedium("<binding template='TileMedium'><group>" + expectedSubgroupXml + "</group></binding>", new TileBinding()
            {
                Content = new TileBindingContentAdaptive()
                {
                    Children =
                    {
                        new TileGroup()
                        {
                            Children = { subgroup }
                        }
                    }
                }
            });
        }

        private static void AssertAdaptiveImage(string expectedImageXml, TileImage image)
        {
            AssertBindingMedium("<binding template='TileMedium'>" + expectedImageXml + "</binding>", new TileBinding()
            {
                Content = new TileBindingContentAdaptive()
                {
                    Children =
                    {
                        image
                    }
                }
            });
        }

        private static void AssertAdaptiveText(string expectedTextXml, TileText text)
        {
            AssertBindingMedium("<binding template='TileMedium'>" + expectedTextXml + "</binding>", new TileBinding()
            {
                Content = new TileBindingContentAdaptive()
                {
                    Children =
                    {
                        text
                    }
                }
            });
        }

        private static void AssertBindingMediumAdaptive(string expectedBindingXml, TileBindingContentAdaptive content)
        {
            AssertBindingMedium(expectedBindingXml, new TileBinding() { Content = content });
        }

        private static void AssertBindingMedium(string expectedBindingXml, TileBinding binding)
        {
            AssertVisual("<visual>" + expectedBindingXml + "</visual>", new TileVisual()
            {
                TileMedium = binding
            });
        }

        private static void AssertVisual(string expectedVisualXml, TileVisual visual)
        {
            AssertPayload("<tile>" + expectedVisualXml + "</tile>", new TileContent()
            {
                Visual = visual
            });
        }

        private static void AssertPayload(string expectedXml, TileContent tile)
        {
            AssertHelper.AssertXml(expectedXml, tile.GetContent());
        }
    }
    

}