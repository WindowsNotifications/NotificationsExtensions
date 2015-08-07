using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.Collections.Generic;

namespace NotificationsExtensions.Win10.Test
{
    [TestClass]
    public class TestConversions
    {
        [TestMethod]
        public void TestConversion_Tile_Default()
        {
            TileContent tile = new TileContent();

            Element_Tile tileElement = tile.ConvertToElement();

            Assert.IsNotNull(tileElement);
            Assert.IsNull(tileElement.Visual);
        }

        [TestMethod]
        public void TestConversion_Visual_Default()
        {
            // Assert the defaults
            AssertSpecificallyVisual(new Element_TileVisual(), new TileVisual());
        }

        [TestMethod]
        public void TestConversion_Visual_AddImageQuery_False()
        {
            AssertSpecificallyVisual(
            
                new Element_TileVisual()
                {
                    AddImageQuery = false
                },
                    
                new TileVisual()
                {
                    AddImageQuery = false
                });
        }

        [TestMethod]
        public void TestConversion_Visual_AddImageQuery_True()
        {
            AssertSpecificallyVisual(
                
                new Element_TileVisual()
                {
                    AddImageQuery = true
                },
                
                new TileVisual()
                {
                    AddImageQuery = true
                });
        }

        [TestMethod]
        public void TestConversion_Visual_BaseUri_Null()
        {
            AssertSpecificallyVisual(
                
                new Element_TileVisual()
                {
                    BaseUri = null
                },

                new TileVisual()
                {
                    BaseUri = null
                });
        }

        [TestMethod]
        public void TestConversion_Visual_BaseUri_Value()
        {
            AssertSpecificallyVisual(
                
                new Element_TileVisual()
                {
                    BaseUri = new Uri("http://msn.com/")
                },
                
                new TileVisual()
                {
                    BaseUri = new Uri("http://msn.com/")
                });
        }

        [TestMethod]
        public void TestConversion_Visual_Branding_Auto()
        {
            AssertSpecificallyVisual(
                
                new Element_TileVisual()
                {
                    Branding = TileBranding.Auto
                },
                
                new TileVisual()
                {
                    Branding = TileBranding.Auto
                });
        }

        [TestMethod]
        public void TestConversion_Visual_Branding_Name()
        {
            AssertSpecificallyVisual(
                
                new Element_TileVisual()
                {
                    Branding = TileBranding.Name
                },

                new TileVisual()
                {
                    Branding = TileBranding.Name
                });
        }

        [TestMethod]
        public void TestConversion_Visual_Branding_Logo()
        {
            AssertSpecificallyVisual(
                
                new Element_TileVisual()
                {
                    Branding = TileBranding.Logo
                },
                
                new TileVisual()
                {
                    Branding = TileBranding.Logo
                });
        }

        [TestMethod]
        public void TestConversion_Visual_Branding_NameAndLogo()
        {
            AssertSpecificallyVisual(

                new Element_TileVisual()
                {
                    Branding = TileBranding.NameAndLogo
                },

                new TileVisual()
                {
                    Branding = TileBranding.NameAndLogo
                });
        }

        [TestMethod]
        public void TestConversion_Visual_Branding_None()
        {
            AssertSpecificallyVisual(

                new Element_TileVisual()
                {
                    Branding = TileBranding.None
                },

                new TileVisual()
                {
                    Branding = TileBranding.None
                });
        }

        [TestMethod]
        public void TestConversion_Visual_ContentId_Null()
        {
            AssertSpecificallyVisual(

                new Element_TileVisual()
                {
                    ContentId = null
                },

                new TileVisual()
                {
                    ContentId = null
                });
        }

        [TestMethod]
        public void TestConversion_Visual_ContentId_Value()
        {
            AssertSpecificallyVisual(

                new Element_TileVisual()
                {
                    ContentId = "tsla"
                },

                new TileVisual()
                {   
                    ContentId = "tsla"
                });
        }

        [TestMethod]
        public void TestConversion_Visual_DisplayName_Null()
        {
            AssertSpecificallyVisual(

                new Element_TileVisual()
                {
                    DisplayName = null
                },

                new TileVisual()
                {
                    DisplayName = null
                });
        }

        [TestMethod]
        public void TestConversion_Visual_DisplayName_Value()
        {
            AssertSpecificallyVisual(

                new Element_TileVisual()
                {
                    DisplayName = "My name"
                },

                new TileVisual()
                {
                    DisplayName = "My name"
                });
        }

        [TestMethod]
        public void TestConversion_Visual_Language_Null()
        {
            AssertSpecificallyVisual(

                new Element_TileVisual()
                {
                    Language = null
                },

                new TileVisual()
                {
                    Language = null
                });
        }

        [TestMethod]
        public void TestConversion_Visual_Language_Value()
        {
            AssertSpecificallyVisual(

                new Element_TileVisual()
                {
                    Language = "en-US"
                },

                new TileVisual()
                {
                    Language = "en-US"
                });
        }

        [TestMethod]
        public void TestConversion_Visual_Version_Null()
        {
            AssertSpecificallyVisual(

                new Element_TileVisual()
                {
                    Version = null
                },

                new TileVisual()
                {
                    Version = null
                });
        }

        [TestMethod]
        public void TestConversion_Visual_Version_Value()
        {
            AssertSpecificallyVisual(

                new Element_TileVisual()
                {
                    Version = 3
                },

                new TileVisual()
                {
                    Version = 3
                });
        }

        [TestMethod]
        public void TestConversion_Visual_LockScreenDetailedStatus1_NoMatchingText()
        {
            AssertSpecificallyVisual(

                new Element_TileVisual()
                {
                    Bindings =
                    {
                        new Element_TileBinding(TileTemplateNameV3.TileWide)
                        {
                            LockDetailedStatus1 = "Status 1",
                            Children =
                            {
                                new Element_TileText() { Text = "Awesome" },
                                new Element_TileText() { Text = "Cool" }
                            }
                        }
                    }
                },

                new TileVisual()
                {
                    LockDetailedStatus1 = "Status 1",

                    TileWide = new TileBinding()
                    {
                        Content = new TileContentAdaptive()
                        {
                            Children =
                            {
                                new TileAdaptiveText() { Text = "Awesome" },
                                new TileAdaptiveText() { Text = "Cool" }
                            }
                        }
                    }
                }

                );
        }

        [TestMethod]
        public void TestConversion_Visual_LockScreenDetailedStatus1_MatchingText_InBinding()
        {
            AssertSpecificallyVisual(

                new Element_TileVisual()
                {
                    Bindings =
                    {
                        new Element_TileBinding(TileTemplateNameV3.TileWide)
                        {
                            Children =
                            {
                                new Element_TileText() { Text = "Awesome" },
                                new Element_TileText() { Text = "Cool" },
                                new Element_TileText() { Text = "Status 1", Id = 1 },
                                new Element_TileText() { Text = "Blah" }
                            }
                        }
                    }
                },

                new TileVisual()
                {
                    LockDetailedStatus1 = "Status 1",

                    TileWide = new TileBinding()
                    {
                        Content = new TileContentAdaptive()
                        {
                            Children =
                            {
                                new TileAdaptiveText() { Text = "Awesome" },
                                new TileAdaptiveText() { Text = "Cool" },
                                new TileAdaptiveText() { Text = "Status 1" },
                                new TileAdaptiveText() { Text = "Blah" }
                            }
                        }
                    }
                }

                );
        }

        [TestMethod]
        public void TestConversion_Visual_LockScreenDetailedStatus1_MatchingText_InSubgroup()
        {
            AssertSpecificallyVisual(

                new Element_TileVisual()
                {
                    Bindings =
                    {
                        new Element_TileBinding(TileTemplateNameV3.TileWide)
                        {
                            Children =
                            {
                                new Element_TileText() { Text = "Awesome" },
                                new Element_TileGroup()
                                {
                                    Children =
                                    {
                                        new Element_TileSubgroup()
                                        {
                                            Children =
                                            {
                                                new Element_TileImage(),
                                                new Element_TileText() { Text = "Status 1", Id = 1 },
                                                new Element_TileText() { Text = "Cool" }
                                            }
                                        }
                                    }
                                },
                                new Element_TileText() { Text = "Blah" }
                            }
                        }
                    }
                },

                new TileVisual()
                {
                    LockDetailedStatus1 = "Status 1",

                    TileWide = new TileBinding()
                    {
                        Content = new TileContentAdaptive()
                        {
                            Children =
                            {
                                new TileAdaptiveText() { Text = "Awesome" },
                                new TileAdaptiveGroup()
                                {
                                    Children =
                                    {
                                        new TileAdaptiveSubgroup()
                                        {
                                            Children =
                                            {
                                                new TileAdaptiveImage(),
                                                new TileAdaptiveText() { Text = "Status 1" },
                                                new TileAdaptiveText() { Text = "Cool" }
                                            }
                                        }
                                    }
                                },
                                new TileAdaptiveText() { Text = "Blah" }
                            }
                        }
                    }
                }

                );
        }

        [TestMethod]
        public void TestConversion_Visual_LockScreenDetailedStatus2_NoMatchingText()
        {
            AssertSpecificallyVisual(

                new Element_TileVisual()
                {
                    Bindings =
                    {
                        new Element_TileBinding(TileTemplateNameV3.TileWide)
                        {
                            LockDetailedStatus2 = "Status 2",
                            Children =
                            {
                                new Element_TileText() { Text = "Awesome" },
                                new Element_TileText() { Text = "Cool" }
                            }
                        }
                    }
                },

                new TileVisual()
                {
                    LockDetailedStatus2 = "Status 2",

                    TileWide = new TileBinding()
                    {
                        Content = new TileContentAdaptive()
                        {
                            Children =
                            {
                                new TileAdaptiveText() { Text = "Awesome" },
                                new TileAdaptiveText() { Text = "Cool" }
                            }
                        }
                    }
                }

                );
        }

        [TestMethod]
        public void TestConversion_Visual_LockScreenDetailedStatus2_MatchingText_InBinding()
        {
            AssertSpecificallyVisual(

                new Element_TileVisual()
                {
                    Bindings =
                    {
                        new Element_TileBinding(TileTemplateNameV3.TileWide)
                        {
                            Children =
                            {
                                new Element_TileText() { Text = "Awesome" },
                                new Element_TileText() { Text = "Cool" },
                                new Element_TileText() { Text = "Status 2", Id = 2 },
                                new Element_TileText() { Text = "Blah" }
                            }
                        }
                    }
                },

                new TileVisual()
                {
                    LockDetailedStatus2 = "Status 2",

                    TileWide = new TileBinding()
                    {
                        Content = new TileContentAdaptive()
                        {
                            Children =
                            {
                                new TileAdaptiveText() { Text = "Awesome" },
                                new TileAdaptiveText() { Text = "Cool" },
                                new TileAdaptiveText() { Text = "Status 2" },
                                new TileAdaptiveText() { Text = "Blah" }
                            }
                        }
                    }
                }

                );
        }

        [TestMethod]
        public void TestConversion_Visual_LockScreenDetailedStatus2_MatchingText_InSubgroup()
        {
            AssertSpecificallyVisual(

                new Element_TileVisual()
                {
                    Bindings =
                    {
                        new Element_TileBinding(TileTemplateNameV3.TileWide)
                        {
                            Children =
                            {
                                new Element_TileText() { Text = "Awesome" },
                                new Element_TileGroup()
                                {
                                    Children =
                                    {
                                        new Element_TileSubgroup()
                                        {
                                            Children =
                                            {
                                                new Element_TileImage(),
                                                new Element_TileText() { Text = "Status 2", Id = 2 },
                                                new Element_TileText() { Text = "Cool" }
                                            }
                                        }
                                    }
                                },
                                new Element_TileText() { Text = "Blah" }
                            }
                        }
                    }
                },

                new TileVisual()
                {
                    LockDetailedStatus2 = "Status 2",

                    TileWide = new TileBinding()
                    {
                        Content = new TileContentAdaptive()
                        {
                            Children =
                            {
                                new TileAdaptiveText() { Text = "Awesome" },
                                new TileAdaptiveGroup()
                                {
                                    Children =
                                    {
                                        new TileAdaptiveSubgroup()
                                        {
                                            Children =
                                            {
                                                new TileAdaptiveImage(),
                                                new TileAdaptiveText() { Text = "Status 2" },
                                                new TileAdaptiveText() { Text = "Cool" }
                                            }
                                        }
                                    }
                                },
                                new TileAdaptiveText() { Text = "Blah" }
                            }
                        }
                    }
                }

                );
        }

        [TestMethod]
        public void TestConversion_Binding_Default()
        {
            AssertSpecificallyBinding(new Element_TileBinding(TileTemplateNameV3.TileMedium), new TileBinding());
        }

        [TestMethod]
        public void TestConversion_Binding_AddImageQuery_False()
        {
            AssertSpecificallyBinding(

                new Element_TileBinding(TileTemplateNameV3.TileMedium)
                {
                    AddImageQuery = false
                },
                
                new TileBinding()
                {
                    AddImageQuery = false
                });
        }

        [TestMethod]
        public void TestConversion_Binding_AddImageQuery_True()
        {
            AssertSpecificallyBinding(

                new Element_TileBinding(TileTemplateNameV3.TileMedium)
                {
                    AddImageQuery = true
                },

                new TileBinding()
                {
                    AddImageQuery = true
                });
        }

        [TestMethod]
        public void TestConversion_Binding_BaseUri_Null()
        {
            AssertSpecificallyBinding(

                new Element_TileBinding(TileTemplateNameV3.TileMedium)
                {
                    BaseUri = null
                },

                new TileBinding()
                {
                    BaseUri = null
                });
        }

        [TestMethod]
        public void TestConversion_Binding_BaseUri_Value()
        {
            AssertSpecificallyBinding(

                new Element_TileBinding(TileTemplateNameV3.TileMedium)
                {
                    BaseUri = new Uri("http://msn.com/")
                },

                new TileBinding()
                {
                    BaseUri = new Uri("http://msn.com/")
                });
        }

        [TestMethod]
        public void TestConversion_Binding_Branding_Auto()
        {
            AssertSpecificallyBinding(

                new Element_TileBinding(TileTemplateNameV3.TileMedium)
                {
                    Branding = TileBranding.Auto
                },

                new TileBinding()
                {
                    Branding = TileBranding.Auto
                });
        }

        [TestMethod]
        public void TestConversion_Binding_Branding_None()
        {
            AssertSpecificallyBinding(

                new Element_TileBinding(TileTemplateNameV3.TileMedium)
                {
                    Branding = TileBranding.None
                },

                new TileBinding()
                {
                    Branding = TileBranding.None
                });
        }

        [TestMethod]
        public void TestConversion_Binding_Branding_Name()
        {
            AssertSpecificallyBinding(

                new Element_TileBinding(TileTemplateNameV3.TileMedium)
                {
                    Branding = TileBranding.Name
                },

                new TileBinding()
                {
                    Branding = TileBranding.Name
                });
        }

        [TestMethod]
        public void TestConversion_Binding_Branding_Logo()
        {
            AssertSpecificallyBinding(

                new Element_TileBinding(TileTemplateNameV3.TileMedium)
                {
                    Branding = TileBranding.Logo
                },

                new TileBinding()
                {
                    Branding = TileBranding.Logo
                });
        }

        [TestMethod]
        public void TestConversion_Binding_Branding_NameAndLogo()
        {
            AssertSpecificallyBinding(

                new Element_TileBinding(TileTemplateNameV3.TileMedium)
                {
                    Branding = TileBranding.NameAndLogo
                },

                new TileBinding()
                {
                    Branding = TileBranding.NameAndLogo
                });
        }

        [TestMethod]
        public void TestConversion_Binding_ContentId_Null()
        {
            AssertSpecificallyBinding(

                new Element_TileBinding(TileTemplateNameV3.TileMedium)
                {
                    ContentId = null
                },

                new TileBinding()
                {
                    ContentId = null
                });
        }

        [TestMethod]
        public void TestConversion_Binding_ContentId_Value()
        {
            AssertSpecificallyBinding(

                new Element_TileBinding(TileTemplateNameV3.TileMedium)
                {
                    ContentId = "myId"
                },

                new TileBinding()
                {
                    ContentId = "myId"
                });
        }

        [TestMethod]
        public void TestConversion_Binding_DisplayName_Null()
        {
            AssertSpecificallyBinding(

                new Element_TileBinding(TileTemplateNameV3.TileMedium)
                {
                    DisplayName = null
                },

                new TileBinding()
                {
                    DisplayName = null
                });
        }

        [TestMethod]
        public void TestConversion_Binding_DisplayName_Value()
        {
            AssertSpecificallyBinding(

                new Element_TileBinding(TileTemplateNameV3.TileMedium)
                {
                    DisplayName = "My name"
                },

                new TileBinding()
                {
                    DisplayName = "My name"
                });
        }

        [TestMethod]
        public void TestConversion_Binding_Language_Null()
        {
            AssertSpecificallyBinding(

                new Element_TileBinding(TileTemplateNameV3.TileMedium)
                {
                    Language = null
                },

                new TileBinding()
                {
                    Language = null
                });
        }

        [TestMethod]
        public void TestConversion_Binding_Language_Value()
        {
            AssertSpecificallyBinding(

                new Element_TileBinding(TileTemplateNameV3.TileMedium)
                {
                    Language = "en-US"
                },

                new TileBinding()
                {
                    Language = "en-US"
                });
        }


        private static void AssertSpecificallyVisual(Element_TileVisual expected, TileVisual visual)
        {
            AssertTile(new Element_Tile()
            {
                Visual = expected
            }, new TileContent()
            {
                Visual = visual
            });
        }

        private static void AssertTile(Element_Tile expected, TileContent initialContent)
        {
            AssertTile(expected, initialContent.ConvertToElement());
        }

        private static void AssertTile(Element_Tile expected, Element_Tile actual)
        {
            if (expected == null && actual == null)
                return;

            if (expected == null && actual != null)
                Assert.Fail("Expected tile to be null, but it wasn't.");

            if (expected != null && actual == null)
                Assert.Fail("Expected tile to be initialized, but it was null.");

            AssertVisual(expected.Visual, actual.Visual);
        }

        /// <summary>
        /// Asserts the property values on the visual element. If any parameters aren't provided, it defaults to their default value, and checks that the default value is correct.
        /// </summary>
        /// <param name="visualElement"></param>
        /// <param name="addImageQuery"></param>
        /// <param name="baseUri"></param>
        /// <param name="bindingsCount"></param>
        /// <param name="branding"></param>
        /// <param name="contentId"></param>
        /// <param name="displayName"></param>
        /// <param name="language"></param>
        /// <param name="version"></param>
        private static void AssertVisual(Element_TileVisual expected, Element_TileVisual actual)
        {
            if (expected == null && actual == null)
                return;

            if (expected == null && actual != null)
                Assert.Fail("Expected visual to be null, but it wasn't.");

            if (expected != null && actual == null)
                Assert.Fail("Expected visual to be initialized, but it was null.");

            Assert.AreEqual(expected.AddImageQuery, actual.AddImageQuery, "AddImageQuery wasn't expected value.");
            Assert.AreEqual(expected.BaseUri, actual.BaseUri, "BaseUri wasn't expected value.");
            Assert.AreEqual(expected.Branding, actual.Branding, "Branding was not expected value.");
            Assert.AreEqual(expected.ContentId, actual.ContentId, "ContentId wasn't expected value.");
            Assert.AreEqual(expected.DisplayName, actual.DisplayName, "DisplayName wasn't expected value.");
            Assert.AreEqual(expected.Language, actual.Language, "Language wasn't expected value.");
            Assert.AreEqual(expected.Version, actual.Version, "Version wasn't expected value.");

            Assert.AreEqual(expected.Bindings.Count, actual.Bindings.Count, "Binding count wasn't expected value.");

            for (int i = 0; i < expected.Bindings.Count; i++)
                AssertBinding(expected.Bindings[i], actual.Bindings[i]);
        }


        private static void AssertSpecificallyBinding(Element_TileBinding expected, TileBinding binding)
        {
            AssertTile(new Element_Tile()
            {
                Visual = new Element_TileVisual()
                {
                    Bindings =
                    {
                        expected
                    }
                }
            }, 
            
            new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = binding
                }
            });
        }


        private static void AssertBinding(Element_TileBinding expected, Element_TileBinding actual)
        {
            if (expected == null && actual == null)
                return;

            if (expected == null && actual != null)
                Assert.Fail("Expected binding to be null, but it wasn't.");

            if (expected != null && actual == null)
                Assert.Fail("Expected binding to be initialized, but it was null.");

            Assert.AreEqual(expected.AddImageQuery, actual.AddImageQuery, "AddImageQuery wasn't expected value.");
            Assert.AreEqual(expected.BaseUri, actual.BaseUri, "BaseUri wasn't expected value.");
            Assert.AreEqual(expected.Branding, actual.Branding, "Branding wasn't expected value.");
            Assert.AreEqual(expected.ContentId, actual.ContentId, "ContentId wasn't expected value.");
            Assert.AreEqual(expected.DisplayName, actual.DisplayName, "DisplayName wasn't expected value.");
            Assert.AreEqual(expected.Fallback, actual.Fallback, "Fallback wasn't expected value.");
            Assert.AreEqual(expected.Language, actual.Language, "Language wasn't expected value.");
            Assert.AreEqual(expected.LockDetailedStatus1, actual.LockDetailedStatus1, "LockDetailedStatus1 wasn't expected value.");
            Assert.AreEqual(expected.LockDetailedStatus2, actual.LockDetailedStatus2, "LockDetailedStatus2 wasn't expected value.");
            Assert.AreEqual(expected.LockDetailedStatus3, actual.LockDetailedStatus3, "LockDetailedStatus3 wasn't expected value.");
            Assert.AreEqual(expected.Overlay, actual.Overlay, "Overlay wasn't expected value.");
            Assert.AreEqual(expected.Presentation, actual.Presentation, "Presentation wasn't expected value.");
            Assert.AreEqual(expected.Template, actual.Template, "Template wasn't expected value.");
            Assert.AreEqual(expected.TextStacking, actual.TextStacking, "TextStacking wasn't expected value.");


            Assert.AreEqual(expected.Children.Count, actual.Children.Count, "Count of children didn't match.");

            for (int i = 0; i < expected.Children.Count; i++)
                AssertBindingChild(expected.Children[i], actual.Children[i]);
        }

        private static void AssertBindingChild(IElement_TileBindingChild expected, IElement_TileBindingChild actual)
        {
            if (expected == null && actual == null)
                return;

            if (expected == null && actual != null)
                Assert.Fail("Expected child to be null, but it wasn't.");

            if (expected != null && actual == null)
                Assert.Fail("Expected child to be initialized, but it was null.");

            Assert.AreEqual(expected.GetType(), actual.GetType(), "Expected child to be the same type, but wasn't.");

            if (expected is Element_TileText)
                AssertText(expected as Element_TileText, actual as Element_TileText);

            else if (expected is Element_TileImage)
                AssertImage(expected as Element_TileImage, actual as Element_TileImage);

            else if (expected is Element_TileGroup)
                AssertGroup(expected as Element_TileGroup, actual as Element_TileGroup);

            else
                throw new NotImplementedException();
        }

        private static void AssertText(Element_TileText expected, Element_TileText actual)
        {
            Assert.AreEqual(expected.Align, actual.Align, "Align wasn't expected value.");
            Assert.AreEqual(expected.Id, actual.Id, "Id wasn't expected value.");
            Assert.AreEqual(expected.Language, actual.Language, "Lang wasn't expected value.");
            Assert.AreEqual(expected.MaxLines, actual.MaxLines, "MaxLines wasn't expected value.");
            Assert.AreEqual(expected.MinLines, actual.MinLines, "MinLines wasn't expected value.");
            Assert.AreEqual(expected.Style, actual.Style, "Style wasn't expected value.");
            Assert.AreEqual(expected.Text, actual.Text, "Text wasn't expected value.");
            Assert.AreEqual(expected.Wrap, actual.Wrap, "Wrap wasn't expected value.");
        }

        private static void AssertImage(Element_TileImage expected, Element_TileImage actual)
        {
            Assert.AreEqual(expected.AddImageQuery, actual.AddImageQuery, "AddImageQuery wasn't expected value.");
            Assert.AreEqual(expected.Align, actual.Align, "Align wasn't expected value.");
            Assert.AreEqual(expected.Alt, actual.Alt, "Alt wasn't expected value.");
            Assert.AreEqual(expected.Crop, actual.Crop, "Crop wasn't expected value.");
            Assert.AreEqual(expected.Id, actual.Id, "Id wasn't expected value.");
            Assert.AreEqual(expected.Placement, actual.Placement, "Placement wasn't expected value.");
            Assert.AreEqual(expected.RemoveMargin, actual.RemoveMargin, "RemoveMargin wasn't expected value.");
            Assert.AreEqual(expected.Src, actual.Src, "Src wasn't expected value.");
        }

        private static void AssertGroup(Element_TileGroup expected, Element_TileGroup actual)
        {
            Assert.AreEqual(expected.Children.Count, actual.Children.Count, "Expected vs actual number of children didn't match.");

            for (int i = 0; i < expected.Children.Count; i++)
                AssertSubgroup(expected.Children[i], actual.Children[i]);
        }

        private static void AssertSubgroup(Element_TileSubgroup expected, Element_TileSubgroup actual)
        {
            Assert.AreEqual(expected.TextStacking, actual.TextStacking, "TextStacking wasn't expected value.");
            Assert.AreEqual(expected.Weight, actual.Weight, "Weight wasn't expected value.");

            Assert.AreEqual(expected.Children.Count, actual.Children.Count, "Expected vs actual number of children didn't match.");

            for (int i = 0; i < expected.Children.Count; i++)
                AssertSubgroupChild(expected.Children[i], actual.Children[i]);
        }

        private static void AssertSubgroupChild(IElement_TileSubgroupChild expected, IElement_TileSubgroupChild actual)
        {
            Assert.AreEqual(expected.GetType(), actual.GetType(), "Expected child to be the same type, but wasn't.");

            if (expected is Element_TileText)
                AssertText(expected as Element_TileText, actual as Element_TileText);

            else if (expected is Element_TileImage)
                AssertImage(expected as Element_TileImage, actual as Element_TileImage);

            else
                throw new NotImplementedException();
        }
    }

}