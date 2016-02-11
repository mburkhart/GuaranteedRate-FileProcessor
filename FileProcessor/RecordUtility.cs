using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor
{
    public class RecordUtility
    {
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
