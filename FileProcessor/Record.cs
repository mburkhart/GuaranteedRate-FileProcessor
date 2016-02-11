namespace FileProcessor
{
    using System;

    public class Record
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string FavoriteColor { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Record()
        {

        }

        public Record(string line)
        {
            if (string.IsNullOrEmpty(line)) throw new Exception("Invalid record data: no data");

            char delimiter;
            if (line.Contains(",")) delimiter = ',';
            else if (line.Contains("|")) delimiter = '|';
            else if (line.Contains(" ")) delimiter = ' ';
            else throw new Exception("Invalid record data: delimiter not found");

            string[] items = line.Split(delimiter);
            if (items.Length != 5) throw new Exception("Invalid record data: expected 5 fields");

            // Validate Gender is 'M' or 'F'
            if (items[2] != "M" && items[2] != "F") throw new Exception("Invalid record data: expected 'M' or 'F' for Gender");

            // Validate that the DOB is a date
            DateTime dob;
            if (!DateTime.TryParse(items[4], out dob)) throw new Exception("Invalid record data: invalid DateTime value for DateOfBirth");

            LastName = items[0];
            FirstName = items[1];
            Gender = items[2];
            FavoriteColor = items[3];
            DateOfBirth = dob;
        }
        
        public override string ToString()
        {
            return ToString(',');
        }

        public string ToString(char delimiter)
        {
            return string.Format("{0}{5}{1}{5}{2}{5}{3}{5}{4}", LastName, FirstName, Gender, FavoriteColor, DateOfBirth.ToString("M/d/yyyy"), delimiter);
        }
    }
}
