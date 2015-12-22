namespace FileProcessorUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FileProcessor;

    [TestClass]
    public class RecordTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            try
            {
                var record = new Record("");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Invalid record data: no data", ex.Message);
            }
            
            try
            {
                var record = new Record("Dickson*Ian*F*red*08/15/2015");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Invalid record data: delimiter not found", ex.Message);
            }

            try
            {
                var record = new Record("Dickson|Ian|F|red");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Invalid record data: expected 5 fields", ex.Message);
            }

            try
            {
                var record = new Record("Dickson|Ian|A|red|08/15/2015");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Invalid record data: expected 'M' or 'F' for Gender", ex.Message);
            }

            try
            {
                var record = new Record("Dickson|Ian|M|red|08/1F/2015");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Invalid record data: invalid DateTime value for DateOfBirth", ex.Message);
            }
        }


        [TestMethod]
        public void TestToString()
        {
            var record = new Record("A,B,M,C,1/1/1900");
            Assert.AreEqual("A,B,M,C,1/1/1900", record.ToString());
            
            Assert.AreEqual("A,B,M,C,1/1/1900", record.ToString(','));
            Assert.AreEqual("A|B|M|C|1/1/1900", record.ToString('|'));
            Assert.AreEqual("A B M C 1/1/1900", record.ToString(' '));

        }
    }
}
