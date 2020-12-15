using Alkalmazas;
using NUnit.Framework;
using System.Xml;
using System.IO;
using System;

namespace UnitTest
{
    public class XmlParserTestFixture
    {
        [Test,
           TestCase("Input/sample.xml"), 
           TestCase("Input/test.txt"),
           TestCase("Input/test2.rtf"),
            ]
        public void TestLoadXml(string path)
        {
            //Arrange
            //mivel static ezért nincs

            //Act
            var result = XmlParser.LoadXml(path);

            //Assert
            Assert.IsNotNull(result);
            
        }

    }

    [SetUpFixture]
    public class MySetUpClass //interneten talált megoldás a fájl útvonal miatti hiba kiküszöbölésére
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var dir = Path.GetDirectoryName(typeof(MySetUpClass).Assembly.Location);
            Environment.CurrentDirectory = dir; 
        }
    }
}
