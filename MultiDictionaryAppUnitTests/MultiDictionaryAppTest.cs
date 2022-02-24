using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using MultiDictionaryConsoleApp;

namespace MultiDictionaryAppUnitTests
{
    [TestClass]
    public class MultiDictionaryAppTest
    {
        Program MainObj = new Program();
        [TestMethod]
        public void getKeysTestCase()
        {
            //Arrange
            Dictionary<string, List<string>> demoDict = new Dictionary<string, List<string>>();

            demoDict.Add("foo", new List<string> { "bar","boo","baz"} );
            demoDict.Add("far", new List<string> { "bar","boo"} );
            
            //Act
            Dictionary<string, List<string>> expecteddemoDict = new Dictionary<string, List<string>>();
            expecteddemoDict = Program.getKeys(demoDict);

            //Assert
            Assert.AreEqual(expecteddemoDict.Keys, demoDict.Keys);
        }

        [TestMethod]
        public void getmembersTestCase()
        {
            //Arrange
            var sw = new StringWriter();
            Console.SetOut(sw);
            Dictionary<string, List<string>> demoDict = new Dictionary<string, List<string>>();
            demoDict.Add("foo", new List<string> { "bar", "boo", "baz" });
            demoDict.Add("far", new List<string> { "bar", "boo" });
            
            //Act
            Dictionary<string, List<string>> expecteddemoDict = new Dictionary<string, List<string>>();
            expecteddemoDict = Program.getMembers(demoDict,"foo");

            //Assert
            Assert.AreEqual("1) bar\r\n2) boo\r\n3) baz", sw.ToString().Trim());
        }

        [TestMethod]
        public void AddDictdataTestCase()
        {
            //Arrange
            var sw = new StringWriter();
            Console.SetOut(sw);
            Dictionary<string, List<string>> demoDict = new Dictionary<string, List<string>>();

            demoDict.Add("foo", new List<string> { "bar", "boo", "baz" });
            demoDict.Add("far", new List<string> { "bar", "boo" });
            
            //Act
            Dictionary<string, List<string>> expecteddemoDict = new Dictionary<string, List<string>>();
            expecteddemoDict = Program.AddDictdata(demoDict, "far","bat");

            //Assert
            Assert.AreEqual(") Added.", sw.ToString().TrimEnd());
        }

        [TestMethod]
        public void RemoveDictdataTestCase()
        {
            //Arrange
            var sw = new StringWriter();
            Console.SetOut(sw);
            Dictionary<string, List<string>> demoDict = new Dictionary<string, List<string>>();

            demoDict.Add("foo", new List<string> { "bar", "boo", "baz" });
            demoDict.Add("far", new List<string> { "bar", "boo", "bat" });

            //Act
            Dictionary<string, List<string>> expecteddemoDict = new Dictionary<string, List<string>>();
            expecteddemoDict = Program.RemoveDictdata(demoDict, "far", "bat");

            //Assert
            Assert.AreEqual("bat Removed.", sw.ToString().TrimEnd());
        }

        [TestMethod]
        public void checkMemberExistsTestCase()
        {
            //Arrange
            var sw = new StringWriter();
            Console.SetOut(sw);
            Dictionary<string, List<string>> demoDict = new Dictionary<string, List<string>>();

            demoDict.Add("foo", new List<string> { "bar", "boo", "baz" });
            demoDict.Add("far", new List<string> { "bar", "boo", "bat" });

            //Act
            Program.checkMemberExists(demoDict, "far", "bat");

            //Assert
            Assert.AreEqual("True",sw.ToString().TrimEnd());
        }

        [TestMethod]
        public void RemoveAllDictdataTestCase()
        {
            //Arrange
            var sw = new StringWriter();
            Console.SetOut(sw);
            Dictionary<string, List<string>> demoDict = new Dictionary<string, List<string>>();
            demoDict.Add("foo", new List<string> { "bar", "boo", "baz" });
            demoDict.Add("far", new List<string> { "bar", "boo", "bat" });

            //Act
            Dictionary<string, List<string>> expecteddemoDict = new Dictionary<string, List<string>>();
            expecteddemoDict = Program.RemoveAllDictdata(demoDict, "far");

            //Assert
            Assert.IsFalse(expecteddemoDict.ContainsKey("far"));
        }

        [TestMethod]
        public void ClearedDictTestCase()
        {
            //Arrange
            var sw = new StringWriter();
            Console.SetOut(sw);
            Dictionary<string, List<string>> demoDict = new Dictionary<string, List<string>>();
            demoDict.Add("foo", new List<string> { "bar", "boo", "baz" });
            demoDict.Add("far", new List<string> { "bar", "boo", "bat" });

            //Act
            Dictionary<string, List<string>> expecteddemoDict = new Dictionary<string, List<string>>();
            expecteddemoDict = Program.DictionaryMain(demoDict, "CLEAR");

            //Assert
            Assert.AreEqual(") Cleared", sw.ToString().TrimEnd());
        }
        
        [TestMethod]
        public void DictionaryMainTestCase()
        {
            //Arrange
            var sw = new StringWriter();
            Console.SetOut(sw);
            Dictionary<string, List<string>> demoDict = new Dictionary<string, List<string>>();
            demoDict.Add("foo", new List<string> { "bar", "boo", "baz" });
            demoDict.Add("far", new List<string> { "bar", "boo", "bat" });

            //Act
            Dictionary<string, List<string>> expecteddemoDict = new Dictionary<string, List<string>>();
            expecteddemoDict = Program.DictionaryMain(demoDict, "sdfg fdh fyh dfh");

            //Assert
            Assert.AreEqual("Error: Invalid Data", sw.ToString().TrimEnd());
        }
    }
}
