using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NotificationsExtensions.Win10.Test
{
    [TestClass]
    public class TestAssertHelper
    {
        [TestMethod]
        public void TestAssertXmlElement()
        {
            AssertHelper.AssertXml("<tile>  <visual version='2'><text>Hello world</text></visual></tile>", "<tile><visual version=\"2\" > <text>Hello world</text></visual> </tile>");
        }

        [TestMethod]
        public void TestAssertXmlElement_002()
        {
            try
            {
                AssertHelper.AssertXml("<tile>  <visual version='2'><text>Hello world</text></visual></tile>", "<Tile><visual version=\"2\" > <text>Hello world</text></visual> </tile>");
            }

            catch { return; }

            Assert.Fail("tile element name was different, should have thrown exception");
        }

        [TestMethod]
        public void TestAssertXmlElement_003()
        {
            try
            {
                AssertHelper.AssertXml("<tile>  <visual version='2'><text>Hello world</text></visual></tile>", "<tile><visuals version=\"2\" > <text>Hello world</text></visual> </tile>");
            }

            catch { return; }

            Assert.Fail("visual element name was incorrect, should have thrown exception");
        }

        [TestMethod]
        public void TestAssertXmlElement_004()
        {
            try
            {
                AssertHelper.AssertXml("<tile>  <visual version='2'><text>Hello world</text></visual></tile>", "<tile><visual version=\"3\" > <text>Hello world</text></visual> </tile>");
            }

            catch { return; }

            Assert.Fail("visual version number was incorrect, should have thrown exception");
        }

        [TestMethod]
        public void TestAssertXmlElement_005()
        {
            try
            {
                AssertHelper.AssertXml("<tile>  <visual version='2'><text>Hello world</text></visual></tile>", "<Tile><visual version=\"2\" > <text>Hello world!</text></visual> </tile>");
            }

            catch { return; }

            Assert.Fail("text content was different, should have thrown exception");
        }

        [TestMethod]
        public void TestAssertXmlElement_006()
        {
            AssertHelper.AssertXml("<tile id='2' version='3'/>", "<tile version='3' id='2'/>");
        }

        [TestMethod]
        public void TestAssertXmlElement_007()
        {
            AssertHelper.AssertXml("<tile></tile>", "<tile />");
        }

        [TestMethod]
        public void TestAssertXmlElement_008()
        {
            AssertHelper.AssertXml("<tile><visual/></tile>", "<tile><visual/></tile>");

            try
            {
                AssertHelper.AssertXml("<tile><visual/></tile>", "<tile/>");
            }

            catch { return; }

            Assert.Fail("Visual element was missing, should have thrown exception");
        }

        [TestMethod]
        public void TestAssertXmlElement_009()
        {
            AssertHelper.AssertXml("<tile><image/><text/></tile>", "<tile><image/><text/></tile>");

            try
            {
                AssertHelper.AssertXml("<tile><image/><text/></tile>", "<tile><text/><image/></tile>");
            }

            catch { return; }

            Assert.Fail("Child elements were different order, should have thrown exception");
        }

        [TestMethod]
        public void TestAssertXmlElement_010()
        {
            try
            {
                AssertHelper.AssertXml("<tile version='3' id='2'/>", "<tile version='3' id='5'/>");
            }

            catch { return; }

            Assert.Fail("id attribute value wasn't the same, should have thrown exception");
        }

        [TestMethod]
        public void TestAssertXmlElement_011()
        {
            try
            {
                AssertHelper.AssertXml("<tile id='2' version='3'/>", "<tile version='3'/>");
            }

            catch { return; }

            Assert.Fail("id attribute was missing, should have thrown exception");
        }
    }

    public static class AssertHelper
    {
        private class XmlElementHelper
        {

        }

        public static void AssertXml(string expected, string actual)
        {
            XmlDocument expectedDoc = new XmlDocument();
            expectedDoc.LoadXml(expected);

            XmlDocument actualDoc = new XmlDocument();
            actualDoc.LoadXml(actual);

            AssertXmlElement(expectedDoc.DocumentElement, actualDoc.DocumentElement);
        }

        private static void AssertXmlElement(XmlElement expected, XmlElement actual)
        {
            // If both null, good, done
            if (expected == null && actual == null)
                return;

            // If one is null and other isn't, bad
            if (expected == null)
                Assert.Fail("Expected XML element was null, while actual was initialized");

            if (actual == null)
                Assert.Fail("Actual XML element was null, while expected was initialized");


            // If name doesn't match
            Assert.AreEqual(expected.Name, actual.Name, "Element names did not match.");


            // If attribute count doesn't match
            Assert.AreEqual(expected.Attributes.Count, actual.Attributes.Count, "Element attributes counts didn't match");


            // Make sure attributes match (order does NOT matter)
            foreach (XmlAttribute expectedAttr in expected.Attributes)
            {
                var actualAttr = actual.Attributes.GetNamedItem(expectedAttr.Name);

                // If didn't find the attribute
                if (actualAttr == null)
                    Assert.Fail("Expected element to have attribute " + expectedAttr.Name + " but it didn't.");

                // Make sure value matches
                Assert.AreEqual(expectedAttr.Value, actualAttr.Value, $@"Attribute values for ""{expectedAttr.Name}"" didn't match.");
            }


            // Make sure children elements match (order DOES matter)

            // Obtain the child elements (ignore any comments, w
            XmlElement[] expectedChildren = expected.ChildNodes.OfType<XmlElement>().ToArray();
            XmlElement[] actualChildren = actual.ChildNodes.OfType<XmlElement>().ToArray();

            Assert.AreEqual(expectedChildren.Length, actualChildren.Length, "Number of child elements did not match.");


            // If no elements, compare inner text
            if (expectedChildren.Length == 0)
            {
                Assert.AreEqual(expected.InnerText, actual.InnerText, "Inner text did not match.");
            }

            // Otherwise compare elements
            else
            {
                for (int i = 0; i < expectedChildren.Length; i++)
                {
                    AssertXmlElement(expectedChildren[i], actualChildren[i]);
                }
            }
        }
    }
}
