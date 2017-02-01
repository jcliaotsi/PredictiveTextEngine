using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PredictiveTextEngine;

namespace PredictiveTextEngine.Tests
{
    [TestClass]
    public class SentenceObjectTests
    {
        [TestMethod]
        public void TestMinimumLength()
        {
            // Arrange
            SentenceObject sentence = new SentenceObject();
            sentence.AddWord(new WordObject("HelloMyNameIs"));
            sentence.AddWord(new WordObject("Slim"));
            sentence.AddWord(new WordObject("Shady"));

            // Act
            string complete = sentence.ReturnSentence();

            // Assert
            Assert.AreEqual("HelloMyNameIs Slim Shady.", complete);

            // Cleanup
        }

        [TestMethod]
        public void TestInterrogative()
        {
            // Arrange
            SentenceObject sentence = new SentenceObject();
            sentence.AddWord(new WordObject("What"));
            sentence.AddWord(new WordObject("is"));
            sentence.AddWord(new WordObject("this"));

            // Act
            string complete = sentence.ReturnSentence();

            // Assert
            Assert.AreEqual("What is this?", complete);

            // Cleanup
        }
    }
}
