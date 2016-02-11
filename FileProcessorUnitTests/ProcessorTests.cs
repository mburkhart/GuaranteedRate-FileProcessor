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
            var processor = new Processor();
            var records = processor.GetRecords(filename);
            Assert.AreEqual(30, records.Count);
        }

        [TestMethod]
        public void TestGetRecordsWithInvalidFile()
        {
            var filename = "doesnotexist.txt";
            try
            {
                var processor = new Processor();
                processor.GetRecords(filename);
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
            var processor = new Processor();
            var unsorted = processor.GetRecords(filename);
            Assert.AreEqual(27, unsorted.Count);
        }

        [TestMethod]
        public void TestSortByGender()
        {
            var processor = new Processor();

            // Create a file
            string filename = "good.txt";
            var unsorted = processor.GetRecords(filename);
            Assert.AreEqual(30, unsorted.Count);

            var sorted = RecordUtility.SortByGenderAndLastName(unsorted, true);
            Assert.AreEqual(sorted[0], unsorted[18]);

            sorted = RecordUtility.SortByGenderAndLastName(unsorted, false);
            Assert.AreEqual(sorted[0], unsorted[4]);
        }

        [TestMethod]
        public void TestSortByDateOfBirth()
        {
            var processor = new Processor();

            // Create a file
            string filename = "good.txt";
            var unsorted = processor.GetRecords(filename);
            Assert.AreEqual(30, unsorted.Count);

            var sorted = RecordUtility.SortByDateOfBirth(unsorted, true);
            Assert.AreEqual(sorted[0], unsorted[22]);

            sorted = RecordUtility.SortByDateOfBirth(unsorted, false);
            Assert.AreEqual(sorted[0], unsorted[28]);
        }

        [TestMethod]
        public void TestSortByLastName()
        {
            var processor = new Processor();

            // Create a file
            string filename = "good.txt";
            var unsorted = processor.GetRecords(filename);
            Assert.AreEqual(30, unsorted.Count);

            var sorted = RecordUtility.SortByLastName(unsorted, true);
            Assert.AreEqual(sorted[0], unsorted[4]);

            sorted = RecordUtility.SortByLastName(unsorted, false);
            Assert.AreEqual(sorted[0], unsorted[2]);
        }
    }
}
