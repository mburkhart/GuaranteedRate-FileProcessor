using FileProcessor;
using FileProcessorWebService.Models;
using FileProcessorWebService.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;


namespace FileProcessorWebService.Controllers
{
    public class RecordController : ApiController
    {
        private static RecordRepository _recordRepository = new RecordRepository();

        // POST /records
        [Route("records")]
        public HttpResponseMessage Post(RecordModel recordModel)
        {
            _recordRepository.AddRecord(Convert(recordModel));

            var response = Request.CreateResponse<RecordModel>(System.Net.HttpStatusCode.Created, recordModel);

            return response;
        }

        // GET /records/gender
        [Route("records/gender")]
        public IEnumerable<RecordModel> GetRecordsByGender()
        {
            var sorted = RecordUtility.SortByGenderAndLastName(_recordRepository.GetRecords());

            return Convert(sorted);
        }

        // GET /records/birthdate
        [Route("records/birthdate")]
        public IEnumerable<RecordModel> GetRecordsByBirthDate()
        {
            var sorted = RecordUtility.SortByDateOfBirth(_recordRepository.GetRecords());

            return Convert(sorted);
        }

        // GET /records/name
        [Route("records/name")]
        public IEnumerable<RecordModel> GetRecordsByName()
        {
            var sorted = RecordUtility.SortByLastName(_recordRepository.GetRecords());

            return Convert(sorted);
        }

        #region Conversion Helpers

        private Record Convert(RecordModel recordModel)
        {
            return new Record
            {
                LastName = recordModel.LastName,
                FirstName = recordModel.FirstName,
                Gender = recordModel.Gender,
                FavoriteColor = recordModel.FavoriteColor,
                DateOfBirth = recordModel.DateOfBirth
            };
        }

        private RecordModel Convert(Record record)
        {
            return new RecordModel
            {
                LastName = record.LastName,
                FirstName = record.FirstName,
                Gender = record.Gender,
                FavoriteColor = record.FavoriteColor,
                DateOfBirth = record.DateOfBirth
            };
        }

        private IEnumerable<RecordModel> Convert(List<Record> records)
        {
            var recordModels = new List<RecordModel>();

            foreach (var record in records)
            {
                recordModels.Add(Convert(record));
            }

            return recordModels;
        }

        #endregion Conversion Helpers
    }
}
