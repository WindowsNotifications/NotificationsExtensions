using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace NotificationsExtensions.Win10.Test
{
    [TestClass]
    public class TestXmlSerialization
    {
        [TestMethod]
        public void TestXmlSerialization_Defaults_Tile()
        {
            Element_Tile tile = new Element_Tile();

            AssertPayload("<tile />", tile);
        }

        [TestMethod]
        public void TestXmlSerialization_Defaults_Visual()
        {
            Element_Tile tile = new Element_Tile();
            tile.Visual = new Element_TileVisual();

            AssertPayload("<tile><visual /></tile>", tile);
        }

        [TestMethod]
        public void TestXmlSerialization_Defaults_BindingSingle()
        {
            Element_Tile tile = new Element_Tile()
            {
                Visual = new Element_TileVisual()
                {
                    Bindings =
                    {
                        new Element_TileBinding(TileTemplateNameV3.TileSmall)
                    }
                }
            };

            AssertPayload(@"<tile><visual><binding template=""TileSmall"" /></visual></tile>", tile);
        }

        [TestMethod]
        public void TestXmlSerialization_Defaults_BindingMultiple()
        {
            Element_Tile tile = new Element_Tile()
            {
                Visual = new Element_TileVisual()
                {
                    Bindings =
                    {
                        new Element_TileBinding(TileTemplateNameV3.TileSmall),
                        new Element_TileBinding(TileTemplateNameV3.TileMedium),
                        new Element_TileBinding(TileTemplateNameV3.TileWide)
                    }
                }
            };

            AssertPayload(@"<tile><visual><binding template=""TileSmall"" /><binding template=""TileMedium"" /><binding template=""TileWide"" /></visual></tile>", tile);
        }

        [TestMethod]
        public void TestXmlSerialization_Defaults_Text()
        {
            Element_Tile tile = new Element_Tile()
            {
                Visual = new Element_TileVisual()
                {
                    Bindings =
                    {
                        new Element_TileBinding(TileTemplateNameV3.TileSmall)
                        {
                            Children =
                            {
                                new Element_TileText()
                            }
                        }
                    }
                }
            };

            AssertPayload(@"<tile><visual><binding template=""TileSmall""><text /></binding></visual></tile>", tile);
        }

        [TestMethod]
        public void TestXmlSerialization_Defaults_Image()
        {
            Element_Tile tile = new Element_Tile()
            {
                Visual = new Element_TileVisual()
                {
                    Bindings =
                    {
                        new Element_TileBinding(TileTemplateNameV3.TileSmall)
                        {
                            Children =
                            {
                                new Element_TileImage()
                            }
                        }
                    }
                }
            };

            AssertPayload(@"<tile><visual><binding template=""TileSmall""><image /></binding></visual></tile>", tile);
        }

        [TestMethod]
        public void TestXmlSerialization_Defaults_Group()
        {
            Element_Tile tile = new Element_Tile()
            {
                Visual = new Element_TileVisual()
                {
                    Bindings =
                    {
                        new Element_TileBinding(TileTemplateNameV3.TileSmall)
                        {
                            Children =
                            {
                                new Element_TileGroup()
                            }
                        }
                    }
                }
            };

            AssertPayload(@"<tile><visual><binding template=""TileSmall""><group /></binding></visual></tile>", tile);
        }

        [TestMethod]
        public void TestXmlSerialization_Defaults_SubgroupSingle()
        {
            Element_Tile tile = new Element_Tile()
            {
                Visual = new Element_TileVisual()
                {
                    Bindings =
                    {
                        new Element_TileBinding(TileTemplateNameV3.TileSmall)
                        {
                            Children =
                            {
                                new Element_TileGroup()
                                {
                                    Children =
                                    {
                                        new Element_TileSubgroup()
                                    }
                                }
                            }
                        }
                    }
                }
            };

            AssertPayload(@"<tile><visual><binding template=""TileSmall""><group><subgroup /></group></binding></visual></tile>", tile);
        }

        [TestMethod]
        public void TestXmlSerialization_Defaults_SubgroupMultiple()
        {
            Element_Tile tile = new Element_Tile()
            {
                Visual = new Element_TileVisual()
                {
                    Bindings =
                    {
                        new Element_TileBinding(TileTemplateNameV3.TileSmall)
                        {
                            Children =
                            {
                                new Element_TileGroup()
                                {
                                    Children =
                                    {
                                        new Element_TileSubgroup(),
                                        new Element_TileSubgroup(),
                                        new Element_TileSubgroup()
                                    }
                                }
                            }
                        }
                    }
                }
            };

            AssertPayload(@"<tile><visual><binding template=""TileSmall""><group><subgroup /><subgroup /><subgroup /></group></binding></visual></tile>", tile);
        }

        [TestMethod]
        public void TestXmlSerialization_Defaults_SubgroupWithSingleText()
        {
            Element_Tile tile = new Element_Tile()
            {
                Visual = new Element_TileVisual()
                {
                    Bindings =
                    {
                        new Element_TileBinding(TileTemplateNameV3.TileSmall)
                        {
                            Children =
                            {
                                new Element_TileGroup()
                                {
                                    Children =
                                    {
                                        new Element_TileSubgroup()
                                        {
                                            Children =
                                            {
                                                new Element_TileText()
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            AssertPayload(@"<tile><visual><binding template=""TileSmall""><group><subgroup><text /></subgroup></group></binding></visual></tile>", tile);
        }

        [TestMethod]
        public void TestXmlSerialization_Defaults_SubgroupWithSingleImage()
        {
            Element_Tile tile = new Element_Tile()
            {
                Visual = new Element_TileVisual()
                {
                    Bindings =
                    {
                        new Element_TileBinding(TileTemplateNameV3.TileSmall)
                        {
                            Children =
                            {
                                new Element_TileGroup()
                                {
                                    Children =
                                    {
                                        new Element_TileSubgroup()
                                        {
                                            Children =
                                            {
                                                new Element_TileImage()
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            AssertPayload(@"<tile><visual><binding template=""TileSmall""><group><subgroup><image /></subgroup></group></binding></visual></tile>", tile);
        }

        [TestMethod]
        public void TestXmlSerialization_Defaults_SubgroupWithMultipleText()
        {
            Element_Tile tile = new Element_Tile()
            {
                Visual = new Element_TileVisual()
                {
                    Bindings =
                    {
                        new Element_TileBinding(TileTemplateNameV3.TileSmall)
                        {
                            Children =
                            {
                                new Element_TileGroup()
                                {
                                    Children =
                                    {
                                        new Element_TileSubgroup()
                                        {
                                            Children =
                                            {
                                                new Element_TileText(),
                                                new Element_TileText(),
                                                new Element_TileText()
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            AssertPayload(@"<tile><visual><binding template=""TileSmall""><group><subgroup><text /><text /><text /></subgroup></group></binding></visual></tile>", tile);
        }

        [TestMethod]
        public void TestXmlSerialization_Defaults_SubgroupWithMultipleImages()
        {
            Element_Tile tile = new Element_Tile()
            {
                Visual = new Element_TileVisual()
                {
                    Bindings =
                    {
                        new Element_TileBinding(TileTemplateNameV3.TileSmall)
                        {
                            Children =
                            {
                                new Element_TileGroup()
                                {
                                    Children =
                                    {
                                        new Element_TileSubgroup()
                                        {
                                            Children =
                                            {
                                                new Element_TileImage(),
                                                new Element_TileImage(),
                                                new Element_TileImage()
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            AssertPayload(@"<tile><visual><binding template=""TileSmall""><group><subgroup><image /><image /><image /></subgroup></group></binding></visual></tile>", tile);
        }

        [TestMethod]
        public void TestXmlSerialization_Defaults_SubgroupWithMultipleTextAndImages()
        {
            Element_Tile tile = new Element_Tile()
            {
                Visual = new Element_TileVisual()
                {
                    Bindings =
                    {
                        new Element_TileBinding(TileTemplateNameV3.TileSmall)
                        {
                            Children =
                            {
                                new Element_TileGroup()
                                {
                                    Children =
                                    {
                                        new Element_TileSubgroup()
                                        {
                                            Children =
                                            {
                                                new Element_TileImage(),
                                                new Element_TileText(),
                                                new Element_TileText(),
                                                new Element_TileImage()
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            AssertPayload(@"<tile><visual><binding template=""TileSmall""><group><subgroup><image /><text /><text /><image /></subgroup></group></binding></visual></tile>", tile);
        }


        [TestMethod]
        public void TestXmlSerialization_Visual_BaseUri()
        {
            var visual = new Element_TileVisual()
            {
                BaseUri = new Uri("http://msn.com/images/")
            };

            AssertVisualPayload(@"<visual baseUri=""http://msn.com/images/"" />", visual);
        }

        [TestMethod]
        public void TestXmlSerialization_Visual_Branding_Auto()
        {
            var visual = new Element_TileVisual()
            {
                Branding = TileBranding.Auto
            };

            AssertVisualPayload(@"<visual />", visual);
        }

        [TestMethod]
        public void TestXmlSerialization_Visual_Branding_Name()
        {
            var visual = new Element_TileVisual()
            {
                Branding = TileBranding.Name
            };

            AssertVisualPayload(@"<visual branding=""name"" />", visual);
        }

        [TestMethod]
        public void TestXmlSerialization_Visual_Branding_Logo()
        {
            var visual = new Element_TileVisual()
            {
                Branding = TileBranding.Logo
            };

            AssertVisualPayload(@"<visual branding=""logo"" />", visual);
        }

        [TestMethod]
        public void TestXmlSerialization_Visual_Branding_NameAndLogo()
        {
            var visual = new Element_TileVisual()
            {
                Branding = TileBranding.NameAndLogo
            };

            AssertVisualPayload(@"<visual branding=""nameAndLogo"" />", visual);
        }

        [TestMethod]
        public void TestXmlSerialization_Visual_Branding_None()
        {
            var visual = new Element_TileVisual()
            {
                Branding = TileBranding.None
            };

            AssertVisualPayload(@"<visual branding=""none"" />", visual);
        }

        [TestMethod]
        public void TestXmlSerialization_Visual_Language()
        {
            var visual = new Element_TileVisual()
            {
                Language = "en-US"
            };

            AssertVisualPayload(@"<visual lang=""en-US"" />", visual);
        }

        [TestMethod]
        public void TestXmlSerialization_Visual_Version()
        {
            var visual = new Element_TileVisual()
            {
                Version = 3
            };

            AssertVisualPayload(@"<visual version=""3"" />", visual);
        }

        [TestMethod]
        public void TestXmlSerialization_Visual_AddImageQuery_False()
        {
            var visual = new Element_TileVisual()
            {
                AddImageQuery = false
            };

            AssertVisualPayload(@"<visual />", visual);
        }

        [TestMethod]
        public void TestXmlSerialization_Visual_AddImageQuery_True()
        {
            var visual = new Element_TileVisual()
            {
                AddImageQuery = true
            };

            AssertVisualPayload(@"<visual addImageQuery=""True"" />", visual);
        }

        [TestMethod]
        public void TestXmlSerialization_Visual_ContentId()
        {
            var visual = new Element_TileVisual()
            {
                ContentId = "myId"
            };

            AssertVisualPayload(@"<visual contentId=""myId"" />", visual);
        }

        [TestMethod]
        public void TestXmlSerialization_Visual_DisplayName()
        {
            var visual = new Element_TileVisual()
            {
                DisplayName = "My Name"
            };

            AssertVisualPayload(@"<visual displayName=""My Name"" />", visual);
        }

        [TestMethod]
        public void TestXmlSerialization_Visual_AllProperties()
        {
            var visual = new Element_TileVisual()
            {
                BaseUri = new Uri("http://msn.com/images/"),
                Branding = TileBranding.Name,
                Version = 3,
                AddImageQuery = true,
                ContentId = "myId",
                DisplayName = "My Name",
                Language = "en-US"
            };

            AssertVisualPayload(@"<visual addImageQuery=""True"" baseUri=""http://msn.com/images/"" branding=""name"" contentId=""myId"" displayName=""My Name"" lang=""en-US"" version=""3"" />", visual);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Template_TileMedium()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium);

            AssertBindingPayload(@"<binding template=""TileMedium"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Template_TileSquare150x150Image()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileSquare150x150Image);

            AssertBindingPayload(@"<binding template=""TileSquare150x150Image"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_AddImageQuery_False()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                AddImageQuery = false
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_AddImageQuery_True()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                AddImageQuery = true
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" addImageQuery=""True"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_BaseUri()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                BaseUri = new Uri("http://msn.com/images/")
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" baseUri=""http://msn.com/images/"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Branding_Auto()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Branding = TileBranding.Auto
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Branding_None()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Branding = TileBranding.None
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" branding=""none"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Branding_Name()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Branding = TileBranding.Name
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" branding=""name"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Branding_Logo()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Branding = TileBranding.Logo
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" branding=""logo"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Branding_NameAndLogo()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Branding = TileBranding.NameAndLogo
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" branding=""nameAndLogo"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_ContentId_Null()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                ContentId = null
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_ContentId_Value()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                ContentId = "myId"
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" contentId=""myId"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_DisplayName_Null()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                DisplayName = null
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_DisplayName_Value()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                DisplayName = "My Name"
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" displayName=""My Name"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_DisplayName_ValueWithEscapedCharacters()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                DisplayName = "In & Out"
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" displayName=""In &amp; Out"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Fallback_TileSquareBlock()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Fallback = TileTemplateNameV1.TileSquareBlock
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" fallback=""TileSquareBlock"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Language_Null()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Language = null
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Language_Value()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Language = "en-US"
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" lang=""en-US"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_LockDetailedStatus1_Null()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                LockDetailedStatus1 = null
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_LockDetailedStatus1_Value()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                LockDetailedStatus1 = "Detailed status"
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" hint-lockDetailedStatus1=""Detailed status"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_LockDetailedStatus2_Null()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                LockDetailedStatus2 = null
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_LockDetailedStatus2_Value()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                LockDetailedStatus2 = "Detailed status"
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" hint-lockDetailedStatus2=""Detailed status"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_LockDetailedStatus3_Null()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                LockDetailedStatus3 = null
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_LockDetailedStatus3_Value()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                LockDetailedStatus3 = "Detailed status"
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" hint-lockDetailedStatus3=""Detailed status"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Overlay_Default()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Overlay = 20
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Overlay_BeneathDefault()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Overlay = 10
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" hint-overlay=""10"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Overlay_AboveDefault()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Overlay = 40
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" hint-overlay=""40"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Overlay_Min()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Overlay = 0
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" hint-overlay=""0"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Overlay_Max()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Overlay = 100
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" hint-overlay=""100"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Overlay_BeneathMin()
        {
            try
            {
                var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
                {
                    Overlay = -1
                };
            }

            catch { return; }

            Assert.Fail("Exception should have been thrown for assigning invalid value to Overlay");
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Overlay_AboveMax()
        {
            try
            {
                var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
                {
                    Overlay = 101
                };
            }

            catch { return; }

            Assert.Fail("Exception should have been thrown for assigning invalid value to Overlay");
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Presentation_Null()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Presentation = null
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Presentation_Contact()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Presentation = TilePresentation.Contact
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" hint-presentation=""contact"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Presentation_Photos()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Presentation = TilePresentation.Photos
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" hint-presentation=""photos"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_Presentation_People()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Presentation = TilePresentation.People
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" hint-presentation=""people"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_TextStacking_Top()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                TextStacking = TileTextStacking.Top
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_TextStacking_Center()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                TextStacking = TileTextStacking.Center
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" hint-textStacking=""center"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_TextStacking_Bottom()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                TextStacking = TileTextStacking.Bottom
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" hint-textStacking=""bottom"" />", binding);
        }

        [TestMethod]
        public void TestXmlSerialization_Binding_AllProperties()
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                AddImageQuery = true,
                BaseUri = new Uri("http://msn.com/images/"),
                Branding = TileBranding.Name,
                ContentId = "myId",
                DisplayName = "My Name",
                Fallback = TileTemplateNameV1.TileSquareText01,
                Language = "en-US",
                Overlay = 50,
                Presentation = TilePresentation.People,
                TextStacking = TileTextStacking.Center,
                LockDetailedStatus1 = "Detailed status 1",
                LockDetailedStatus2 = "Detailed status 2",
                LockDetailedStatus3 = "Detailed status 3"
            };

            AssertBindingPayload(@"<binding template=""TileMedium"" fallback=""TileSquareText01"" addImageQuery=""True"" baseUri=""http://msn.com/images/"" branding=""name"" contentId=""myId"" displayName=""My Name"" lang=""en-US"" hint-lockDetailedStatus1=""Detailed status 1"" hint-lockDetailedStatus2=""Detailed status 2"" hint-lockDetailedStatus3=""Detailed status 3"" hint-overlay=""50"" hint-presentation=""people"" hint-textStacking=""center"" />", binding);
        }






        [TestMethod]
        public void TestXmlSerialization_Text_Align_Auto()
        {
            var text = new Element_TileText()
            {
                Align = TileTextAlign.Auto
            };

            AssertTextPayload(@"<text />", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_Align_Left()
        {
            var text = new Element_TileText()
            {
                Align = TileTextAlign.Left
            };

            AssertTextPayload(@"<text hint-align=""left"" />", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_Align_Center()
        {
            var text = new Element_TileText()
            {
                Align = TileTextAlign.Center
            };

            AssertTextPayload(@"<text hint-align=""center"" />", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_Align_Right()
        {
            var text = new Element_TileText()
            {
                Align = TileTextAlign.Right
            };

            AssertTextPayload(@"<text hint-align=""right"" />", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_Lang_Null()
        {
            var text = new Element_TileText()
            {
                Lang = null
            };

            AssertTextPayload(@"<text />", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_Lang_Value()
        {
            var text = new Element_TileText()
            {
                Lang = "en-US"
            };

            AssertTextPayload(@"<text lang=""en-US"" />", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_MaxLines_Max()
        {
            var text = new Element_TileText()
            {
                MaxLines = int.MaxValue
            };

            AssertTextPayload(@"<text />", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_MaxLines_Normal()
        {
            var text = new Element_TileText()
            {
                MaxLines = 5
            };

            AssertTextPayload(@"<text hint-maxLines=""5"" />", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_MaxLines_Min()
        {
            var text = new Element_TileText()
            {
                MaxLines = 1
            };

            AssertTextPayload(@"<text hint-maxLines=""1"" />", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_MaxLines_BelowMin()
        {
            try
            {
                var text = new Element_TileText()
                {
                    MaxLines = 0
                };
            }

            catch { return; }

            Assert.Fail("Assigning MaxLines to 0 should throw exception since valid numbers are only 1 - int.MaxValue");
        }

        [TestMethod]
        public void TestXmlSerialization_Text_MinLines_Max()
        {
            var text = new Element_TileText()
            {
                MinLines = int.MaxValue
            };

            AssertTextPayload($@"<text hint-minLines=""{int.MaxValue}"" />", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_MinLines_Normal()
        {
            var text = new Element_TileText()
            {
                MinLines = 5
            };

            AssertTextPayload(@"<text hint-minLines=""5"" />", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_MinLines_Min()
        {
            var text = new Element_TileText()
            {
                MinLines = 1
            };

            AssertTextPayload(@"<text />", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_MinLines_BelowMin()
        {
            try
            {
                var text = new Element_TileText()
                {
                    MinLines = 0
                };
            }

            catch { return; }

            Assert.Fail("Assigning MinLines to 0 should throw exception since valid numbers are only 1 - int.MaxValue");
        }

        [TestMethod]
        public void TestXmlSerialization_Text_Style()
        {
            // Default is caption, so should be blank
            var text = new Element_TileText()
            {
                Style = TileTextStyle.Caption
            };

            AssertTextPayload(@"<text />", text);


            // And then check all the other styles
            AssertTextStyle("captionSubtle", TileTextStyle.CaptionSubtle);

            AssertTextStyle("body", TileTextStyle.Body);
            AssertTextStyle("bodySubtle", TileTextStyle.BodySubtle);

            AssertTextStyle("base", TileTextStyle.Base);
            AssertTextStyle("baseSubtle", TileTextStyle.BaseSubtle);

            AssertTextStyle("subtitle", TileTextStyle.Subtitle);
            AssertTextStyle("subtitleSubtle", TileTextStyle.SubtitleSubtle);

            AssertTextStyle("title", TileTextStyle.Title);
            AssertTextStyle("titleSubtle", TileTextStyle.TitleSubtle);
            AssertTextStyle("titleNumeral", TileTextStyle.TitleNumeral);

            AssertTextStyle("subheader", TileTextStyle.Subheader);
            AssertTextStyle("subheaderSubtle", TileTextStyle.SubheaderSubtle);
            AssertTextStyle("subheaderNumeral", TileTextStyle.SubheaderNumeral);

            AssertTextStyle("header", TileTextStyle.Header);
            AssertTextStyle("headerSubtle", TileTextStyle.HeaderSubtle);
            AssertTextStyle("headerNumeral", TileTextStyle.HeaderNumeral);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_Text()
        {
            var text = new Element_TileText()
            {
                Text = "Hello"
            };

            AssertTextPayload(@"<text>Hello</text>", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_TextWithSpaces()
        {
            var text = new Element_TileText()
            {
                Text = "Hello there.  My name is Andrew."
            };

            AssertTextPayload(@"<text>Hello there.  My name is Andrew.</text>", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_TextWithLeadingSpaces()
        {
            var text = new Element_TileText()
            {
                Text = "   Hello  "
            };

            AssertTextPayload(@"<text>   Hello  </text>", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_TextWithEscapedCharacters()
        {
            var text = new Element_TileText()
            {
                Text = "Desktop & Phone < HoloLens"
            };

            AssertTextPayload(@"<text>Desktop &amp; Phone &lt; HoloLens</text>", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_Wrap_False()
        {
            var text = new Element_TileText()
            {
                Wrap = false
            };

            AssertTextPayload(@"<text />", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_Wrap_True()
        {
            var text = new Element_TileText()
            {
                Wrap = true
            };

            AssertTextPayload(@"<text hint-wrap=""True"" />", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Text_AllProperties()
        {
            var text = new Element_TileText()
            {
                Align = TileTextAlign.Center,
                Lang = "en-US",
                MaxLines = 5,
                MinLines = 3,
                Style = TileTextStyle.CaptionSubtle,
                Text = "Hello world",
                Wrap = true
            };

            AssertTextPayload(@"<text lang=""en-US"" hint-align=""center"" hint-maxLines=""5"" hint-minLines=""3"" hint-style=""captionSubtle"" hint-wrap=""True"">Hello world</text>", text);
        }

        [TestMethod]
        public void TestXmlSerialization_Image_AddImageQuery_False()
        {
            var image = new Element_TileImage()
            {
                AddImageQuery = false
            };

            AssertImagePayload(@"<image />", image);
        }

        [TestMethod]
        public void TestXmlSerialization_Image_AddImageQuery_True()
        {
            var image = new Element_TileImage()
            {
                AddImageQuery = true
            };

            AssertImagePayload(@"<image addImageQuery=""True"" />", image);
        }

        [TestMethod]
        public void TestXmlSerialization_Image_Align_Stretch()
        {
            var image = new Element_TileImage()
            {
                Align = TileImageAlign.Stretch
            };

            AssertImagePayload(@"<image />", image);
        }

        [TestMethod]
        public void TestXmlSerialization_Image_Align_Left()
        {
            var image = new Element_TileImage()
            {
                Align = TileImageAlign.Left
            };

            AssertImagePayload(@"<image hint-align=""left"" />", image);
        }

        [TestMethod]
        public void TestXmlSerialization_Image_Align_Center()
        {
            var image = new Element_TileImage()
            {
                Align = TileImageAlign.Center
            };

            AssertImagePayload(@"<image hint-align=""center"" />", image);
        }

        [TestMethod]
        public void TestXmlSerialization_Image_Align_Right()
        {
            var image = new Element_TileImage()
            {
                Align = TileImageAlign.Right
            };

            AssertImagePayload(@"<image hint-align=""right"" />", image);
        }

        [TestMethod]
        public void TestXmlSerialization_Image_Alt_Null()
        {
            var image = new Element_TileImage()
            {
                Alt = null
            };

            AssertImagePayload(@"<image />", image);
        }

        [TestMethod]
        public void TestXmlSerialization_Image_Alt_Value()
        {
            var image = new Element_TileImage()
            {
                Alt = "alternative"
            };

            AssertImagePayload(@"<image alt=""alternative"" />", image);
        }

        [TestMethod]
        public void TestXmlSerialization_Image_Crop_None()
        {
            var image = new Element_TileImage()
            {
                Crop = TileImageCrop.None
            };

            AssertImagePayload(@"<image />", image);
        }

        [TestMethod]
        public void TestXmlSerialization_Image_Crop_Circle()
        {
            var image = new Element_TileImage()
            {
                Crop = TileImageCrop.Circle
            };

            AssertImagePayload(@"<image hint-crop=""circle"" />", image);
        }

        [TestMethod]
        public void TestXmlSerialization_Image_Placement_Inline()
        {
            var image = new Element_TileImage()
            {
                Placement = TileImagePlacement.Inline
            };

            AssertImagePayload(@"<image />", image);
        }

        [TestMethod]
        public void TestXmlSerialization_Image_Placement_Background()
        {
            var image = new Element_TileImage()
            {
                Placement = TileImagePlacement.Background
            };

            AssertImagePayload(@"<image placement=""background"" />", image);
        }

        [TestMethod]
        public void TestXmlSerialization_Image_Placement_Peek()
        {
            var image = new Element_TileImage()
            {
                Placement = TileImagePlacement.Peek
            };

            AssertImagePayload(@"<image placement=""peek"" />", image);
        }

        [TestMethod]
        public void TestXmlSerialization_Image_RemoveMargin_False()
        {
            var image = new Element_TileImage()
            {
                RemoveMargin = false
            };

            AssertImagePayload(@"<image />", image);
        }

        [TestMethod]
        public void TestXmlSerialization_Image_RemoveMargin_True()
        {
            var image = new Element_TileImage()
            {
                RemoveMargin = true
            };

            AssertImagePayload(@"<image hint-removeMargin=""True"" />", image);
        }

        [TestMethod]
        public void TestXmlSerialization_Image_Src_Null()
        {
            var image = new Element_TileImage()
            {
                Src = null
            };

            AssertImagePayload(@"<image />", image);
        }

        [TestMethod]
        public void TestXmlSerialization_Image_Src_Value()
        {
            var image = new Element_TileImage()
            {
                Src = "ms-appx:///Assets/image.jpg"
            };

            AssertImagePayload(@"<image src=""ms-appx:///Assets/image.jpg"" />", image);
        }

        [TestMethod]
        public void TestXmlSerialization_Image_AllProperties()
        {
            var image = new Element_TileImage()
            {
                AddImageQuery = true,
                Align = TileImageAlign.Center,
                Alt = "alternative",
                Crop = TileImageCrop.Circle,
                Placement = TileImagePlacement.Peek,
                RemoveMargin = true,
                Src = "ms-appx:///Assets/image.jpg"
            };

            AssertImagePayload(@"<image src=""ms-appx:///Assets/image.jpg"" alt=""alternative"" addImageQuery=""True"" placement=""peek"" hint-align=""center"" hint-crop=""circle"" hint-removeMargin=""True"" />", image);
        }





        [TestMethod]
        public void TestXmlSerialization_Subgroup_TextStacking_Top()
        {
            var subgroup = new Element_TileSubgroup()
            {
                TextStacking = TileTextStacking.Top
            };

            AssertSubgroupPayload(@"<subgroup />", subgroup);
        }

        [TestMethod]
        public void TestXmlSerialization_Subgroup_TextStacking_Center()
        {
            var subgroup = new Element_TileSubgroup()
            {
                TextStacking = TileTextStacking.Center
            };

            AssertSubgroupPayload(@"<subgroup hint-textStacking=""center"" />", subgroup);
        }

        [TestMethod]
        public void TestXmlSerialization_Subgroup_TextStacking_Bottom()
        {
            var subgroup = new Element_TileSubgroup()
            {
                TextStacking = TileTextStacking.Bottom
            };

            AssertSubgroupPayload(@"<subgroup hint-textStacking=""bottom"" />", subgroup);
        }

        [TestMethod]
        public void TestXmlSerialization_Subgroup_Weight_Null()
        {
            var subgroup = new Element_TileSubgroup()
            {
                Weight = null
            };

            AssertSubgroupPayload(@"<subgroup />", subgroup);
        }

        [TestMethod]
        public void TestXmlSerialization_Subgroup_Weight_Min()
        {
            var subgroup = new Element_TileSubgroup()
            {
                Weight = 1
            };

            AssertSubgroupPayload(@"<subgroup hint-weight=""1"" />", subgroup);
        }

        [TestMethod]
        public void TestXmlSerialization_Subgroup_Weight_Max()
        {
            var subgroup = new Element_TileSubgroup()
            {
                Weight = int.MaxValue
            };

            AssertSubgroupPayload($@"<subgroup hint-weight=""{int.MaxValue}"" />", subgroup);
        }

        [TestMethod]
        public void TestXmlSerialization_Subgroup_Weight_Normal()
        {
            var subgroup = new Element_TileSubgroup()
            {
                Weight = 5
            };

            AssertSubgroupPayload(@"<subgroup hint-weight=""5"" />", subgroup);
        }

        [TestMethod]
        public void TestXmlSerialization_Subgroup_Weight_BelowMin()
        {
            try
            {
                var subgroup = new Element_TileSubgroup()
                {
                    Weight = 0
                };
            }

            catch { return; }

            Assert.Fail("Assigning weight to non-positive number should throw exception");
        }

        [TestMethod]
        public void TestXmlSerialization_Subgroup_AllPropertiesWithChildren()
        {
            var subgroup = new Element_TileSubgroup()
            {
                TextStacking = TileTextStacking.Center,
                Weight = 10,
                Children =
                {
                    new Element_TileText()
                    {
                        Text = "Hello"
                    },

                    new Element_TileImage()
                    {
                        Src = "Assets/image.jpg"
                    }
                }
            };

            AssertSubgroupPayload(@"<subgroup hint-textStacking=""center"" hint-weight=""10""><text>Hello</text><image src=""Assets/image.jpg"" /></subgroup>", subgroup);
        }







        private static void AssertTextStyle(string expectedStyleString, TileTextStyle style)
        {
            var text = new Element_TileText()
            {
                Style = style
            };

            AssertTextPayload($@"<text hint-style=""{expectedStyleString}"" />", text);
        }


        private static void AssertPayload(string expectedXml, Element_Tile tile)
        {
            AssertHelper.AssertXml(expectedXml, tile.GetContent());

            //Assert.AreEqual("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + expectedXml, tile.GetXml());
        }

        private static void AssertVisualPayload(string expectedVisualXml, Element_TileVisual visual)
        {
            if (visual == null)
                throw new ArgumentNullException("visual cannot be null");

            Element_Tile tile = new Element_Tile()
            {
                Visual = visual
            };

            AssertPayload("<tile>" + expectedVisualXml + "</tile>", tile);
        }

        private static void AssertBindingPayload(string expectedBindingXml, Element_TileBinding binding)
        {
            if (binding == null)
                throw new ArgumentNullException("binding cannot be null");

            var visual = new Element_TileVisual()
            {
                Bindings =
                {
                    binding
                }
            };

            AssertVisualPayload("<visual>" + expectedBindingXml + "</visual>", visual);
        }

        private static void AssertTextPayload(string expectedTextXml, Element_TileText text)
        {
            if (text == null)
                throw new ArgumentNullException("text cannot be null");

            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Children =
                {
                    text
                }
            };

            AssertBindingPayload(@"<binding template=""TileMedium"">" + expectedTextXml + "</binding>", binding);
        }

        private static void AssertImagePayload(string expectedImageXml, Element_TileImage image)
        {
            if (image == null)
                throw new ArgumentNullException("image cannot be null");

            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Children =
                {
                    image
                }
            };

            AssertBindingPayload(@"<binding template=""TileMedium"">" + expectedImageXml + "</binding>", binding);
        }

        private static void AssertSubgroupPayload(string expectedSubgroupXml, Element_TileSubgroup subgroup)
        {
            var binding = new Element_TileBinding(TileTemplateNameV3.TileMedium)
            {
                Children =
                {
                    new Element_TileGroup()
                    {
                        Children =
                        {
                            subgroup
                        }
                    }
                }
            };

            AssertBindingPayload(@"<binding template=""TileMedium""><group>" + expectedSubgroupXml + "</group></binding>", binding);
        }
    }
}
