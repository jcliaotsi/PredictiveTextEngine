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
    }
}
