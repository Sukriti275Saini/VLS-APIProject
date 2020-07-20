using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VLS_APIProject.Data.Entities;

namespace VLS_APIProject.Data
{
    public interface IRecordRepository
    {

        public Task<Record[]> GetAllRecords();

        public Record GetRecordById(int recordId);

        public Task<Record[]> GetRecordsByUserName(string UserName);

        public string Add(Record newRecord);

        public Record Delete(int recordId);

        public Task<bool> SaveChangesAsync();
    }
}
