using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotificationsExtensions.Badges;

namespace NotificationsExtensions.Win10.Test.Portable
{
    [TestClass]
    public class Test_Badge_Xml
    {
        [TestMethod]
        public void Test_Badge_Xml_Numeric_0()
        {
            AssertBadgeValue("0", new BadgeNumericNotificationContent(0));
        }

        [TestMethod]
        public void Test_Badge_Xml_Numeric_1()
        {
            AssertBadgeValue("1", new BadgeNumericNotificationContent(1));
        }

        [TestMethod]
        public void Test_Badge_Xml_Numeric_2()
        {
            AssertBadgeValue("2", new BadgeNumericNotificationContent(2));
        }

        [TestMethod]
        public void Test_Badge_Xml_Numeric_546()
        {
            AssertBadgeValue("546", new BadgeNumericNotificationContent(546));
        }

        [TestMethod]
        public void Test_Badge_Xml_Numeric_Max()
        {
            AssertBadgeValue(uint.MaxValue.ToString(), new BadgeNumericNotificationContent(uint.MaxValue));
        }

        [TestMethod]
        public void Test_Badge_Xml_Glyph_None()
        {
            AssertBadgeValue("none", new BadgeGlyphNotificationContent(GlyphValue.None));
        }

        [TestMethod]
        public void Test_Badge_Xml_Glyph_Alert()
        {
            AssertBadgeValue("alert", new BadgeGlyphNotificationContent(GlyphValue.Alert));
        }

        [TestMethod]
        public void Test_Badge_Xml_Glyph_Error()
        {
            AssertBadgeValue("error", new BadgeGlyphNotificationContent(GlyphValue.Error));
        }

        private static void AssertBadgeValue(string expectedValue, INotificationContent notificationContent)
        {
            AssertPayload("<badge version='1' value='" + expectedValue + "'/>", notificationContent);
        }

        private static void AssertPayload(string expectedXml, INotificationContent notificationContent)
        {
            AssertHelper.AssertXml(expectedXml, notificationContent.GetContent());
        }
    }
}
