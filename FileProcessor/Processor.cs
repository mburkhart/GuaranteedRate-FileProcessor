namespace FileProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Processor
    {
        public static List<Record> GetRecords(string filename)
        {
            var records = new List<Record>();

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
                        Record record = new Record(line);
                        if (record != null) records.Add(record);
                    }
                    catch
                    {
                        // Skip lines with bad input
                    }
                }
            }

            return records;
        }
        
        public static List<Record> SortByGenderAndLastName(List<Record> records, bool ascending = true)
        {
            // TODO: Probably should also sub-sort by FirstName, but the requirements aren't clear on this
            if (ascending)
                return records.OrderBy(x => x.Gender).ThenBy(x => x.LastName).ToList();
            else
                return records.OrderByDescending(x => x.Gender).ThenBy(x => x.LastName).ToList();
        }

        public static List<Record> SortByDateOfBirth(List<Record> records, bool ascending = true)
        {
            // TODO: Probably should also sub-sort by LastName, but the requirements aren't clear on this
            if (ascending)
                return records.OrderBy(x => x.DateOfBirth).ToList();
            else
                return records.OrderByDescending(x => x.DateOfBirth).ToList();
        }

        public static List<Record> SortByLastName(List<Record> records, bool ascending = true)
        {
            // TODO: Probably should also sub-sort by FirstName, but the requirements aren't clear on this
            if (ascending)
                return records.OrderBy(x => x.LastName).ToList();
            else
                return records.OrderByDescending(x => x.LastName).ToList();
        }
    }
}
