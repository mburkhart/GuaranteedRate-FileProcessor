namespace FileProcessorUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FileProcessor;

    [TestClass]
    public class ProcessorTests
    {
        [TestMethod]
        public void TestFileProcessor()
        {
            // Create a file
            string filename = "good.txt";
            var records = Processor.GetRecords(filename);
            Assert.AreEqual(30, records.Count);
        }

        [TestMethod]
        public void TestGetRecordsWithInvalidFile()
        {
            var filename = "doesnotexist.txt";
            try
            {
                Processor.GetRecords(filename);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(string.Format("File '{0}' does not exist", filename), ex.Message);
            }
        }

        [TestMethod]
        public void TestGetRecordsWithBadRecord()
        {
            string filename = "bad.txt";
            var unsorted = Processor.GetRecords(filename);
            Assert.AreEqual(27, unsorted.Count);
        }

        [TestMethod]
        public void TestSortByGender()
        {
            // Create a file
            string filename = "good.txt";
            var unsorted = Processor.GetRecords(filename);
            Assert.AreEqual(30, unsorted.Count);

            var sorted = Processor.SortByGenderAndLastName(unsorted, true);
            Assert.AreEqual(sorted[0], unsorted[18]);

            sorted = Processor.SortByGenderAndLastName(unsorted, false);
            Assert.AreEqual(sorted[0], unsorted[4]);
        }

        [TestMethod]
        public void TestSortByDateOfBirth()
        {
            // Create a file
            string filename = "good.txt";
            var unsorted = Processor.GetRecords(filename);
            Assert.AreEqual(30, unsorted.Count);

            var sorted = Processor.SortByDateOfBirth(unsorted, true);
            Assert.AreEqual(sorted[0], unsorted[22]);

            sorted = Processor.SortByDateOfBirth(unsorted, false);
            Assert.AreEqual(sorted[0], unsorted[28]);
        }

        [TestMethod]
        public void TestSortByLastName()
        {
            // Create a file
            string filename = "good.txt";
            var unsorted = Processor.GetRecords(filename);
            Assert.AreEqual(30, unsorted.Count);

            var sorted = Processor.SortByLastName(unsorted, true);
            Assert.AreEqual(sorted[0], unsorted[4]);

            sorted = Processor.SortByLastName(unsorted, false);
            Assert.AreEqual(sorted[0], unsorted[2]);
        }
    }
}
