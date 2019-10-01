using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Media;

namespace MemoryGame.Test
{
    /// <summary>
    /// Testing the SoundManager class
    /// </summary>
    [TestClass]
    public class SoundManagerTest
    {

        MainWindow window = new MainWindow();

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        [DataRow("background_music.mp3")]
        [DataRow("SoundEffects\\correct_match.mp3")]

        public void SoundFileFound(string filename)
        {
            string filepath = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, SoundManager.CorrectRelativeProjectDirectory, filename);
            Console.WriteLine(filepath);
            //Sees if the PlayBackgroundMusic finds the file to play music from.
            Assert.IsTrue(File.Exists(filepath),("File path searched for:" + filepath));
            
        }



    }
}
