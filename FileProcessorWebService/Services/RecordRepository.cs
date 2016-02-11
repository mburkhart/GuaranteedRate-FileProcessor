using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileProcessor;

namespace FileProcessorWebService.Services
{
    public class RecordRepository
    {
        private Processor _processor;

        public RecordRepository()
        {
            _processor = new Processor();
            _processor.AddRecord("Dickson,Ian,F,red,8/15/2015");
            _processor.AddRecord("Kent,Rhona,M,yellow,3/24/2016");
            _processor.AddRecord("Yang,Dawn,F,yellow,4/21/2016");
            _processor.AddRecord("Newman,Stephen,M,yellow,12/15/2015");
            _processor.AddRecord("Adams,Cody,M,blue,8/7/2016");
            _processor.AddRecord("Sullivan,Leila,F,green,9/23/2015");
            _processor.AddRecord("Gardner,Gretchen,M,yellow,8/17/2016");
            _processor.AddRecord("Dean,Zahir,M,indigo,7/10/2015");
            _processor.AddRecord("Simon,Serena,M,indigo,2/7/2016");
            _processor.AddRecord("Edwards,Ryder,M,blue,3/25/2016");
            _processor.AddRecord("Day,Burton,M,violet,6/15/2016");
            _processor.AddRecord("Gallagher,Dane,M,violet,12/24/2015");
            _processor.AddRecord("Barlow,September,F,green,5/27/2015");
            _processor.AddRecord("Rosa,Lara,F,orange,9/12/2015");
            _processor.AddRecord("Ruiz,Aubrey,F,indigo,1/12/2015");
            _processor.AddRecord("Hardy,Cherokee,F,green,10/4/2015");
            _processor.AddRecord("Knight,Daryl,M,orange,11/25/2015");
            _processor.AddRecord("Freeman,Fatima,F,blue,12/14/2015");
            _processor.AddRecord("Baldwin,William,F,violet,9/19/2015");
            _processor.AddRecord("Durham,Nicholas,M,yellow,2/27/2016");
            _processor.AddRecord("Hobbs,Ruth,M,red,5/7/2016");
            _processor.AddRecord("Booth,Murphy,M,orange,6/13/2015");
            _processor.AddRecord("Orr,Gloria,F,orange,12/22/2014");
            _processor.AddRecord("Cleveland,Erica,F,yellow,9/27/2015");
            _processor.AddRecord("Aguirre,Lillian,M,green,11/21/2015");
            _processor.AddRecord("Britt,Stewart,M,blue,11/9/2015");
            _processor.AddRecord("Briggs,Samson,M,blue,12/19/2015");
            _processor.AddRecord("Lambert,Cynthia,F,blue,10/18/2016");
            _processor.AddRecord("Bullock,Flynn,M,blue,12/19/2016");
            _processor.AddRecord("Waters,Germaine,M,blue,5/9/2015");
        }
        public List<Record> GetRecords()
        {
            return _processor.Records;
        }

        public bool AddRecord(Record record)
        {
            try
            {
                _processor.AddRecord(record);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
