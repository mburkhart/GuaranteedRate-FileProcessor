namespace FileProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Processor
    {
        private List<Record> _records = new List<Record>();

        public List<Record> Records
        {
            get
            {
                return _records;
            }
        }

        public Processor()
        {

        }

        public Processor(string filename)
        {
            GetRecords(filename);
        }

        public List<Record> GetRecords(string filename)
        {
            if (!System.IO.File.Exists(filename))
                throw new Exception(string.Format("File '{0}' does not exist", filename));

            using (var sr = new System.IO.StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    // TODO: Is there a header row that needs to be skipped?
                    try
                    {
                        string line = sr.ReadLine();
                        AddRecord(line);
                    }
                    catch
                    {
                        // Skip lines with bad input
                    }
                }
            }

            return _records;
        }

        public void AddRecord(string data)
        {
            Record record = new Record(data);
            AddRecord(record);
        }

        public void AddRecord(Record record)
        {
            if (record != null) _records.Add(record);
        }
    }
}
