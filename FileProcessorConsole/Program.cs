namespace FileProcessorConsole
{
    using System;
    using System.Collections.Generic;
    using FileProcessor;

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Usage();
            }
            else
            {
                string filename = args[0];

                if (!System.IO.File.Exists(filename))
                    throw new Exception(string.Format("File '{0}' does not exist", filename));

                var processor = new Processor();
                var records = processor.GetRecords(filename);

                Console.WriteLine("Sorted by Gender/LastName (ascending):");
                Print(RecordUtility.SortByGenderAndLastName(records, true));

                Console.WriteLine("Sorted by DateOfBirth (ascending):");
                Print(RecordUtility.SortByDateOfBirth(records, true));

                Console.WriteLine("Sorted by LastName (descending):");
                Print(RecordUtility.SortByLastName(records, false));
            }

            Console.Read();
        }

        static void Print(List<Record> records)
        {
            foreach (var record in records)
            {
                Console.Write("\t");
                Console.WriteLine(record.ToString());
            }
        }

        static void Usage()
        {
            Console.WriteLine("Usage: \n\rFileProcessorConsole.exe <filename>");
        }
    }
}
