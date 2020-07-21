using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VLS_APIProject.Data.Entities;

namespace VLS_APIProject.Data
{
    public class RecordRepository : IRecordRepository
    {
        private readonly VLSDbContext db;

        public RecordRepository(VLSDbContext db)
        {
            this.db = db;
        }

        public async Task<Record[]> GetAllRecords()
        {
            IQueryable<Record> allrecords = from rec in db.Records.Include("User").Include("Video")
                                        orderby rec.IssueDate
                                        select rec;
            return await allrecords.ToArrayAsync();
        }

        public Record GetRecordById(int recordId)
        {
            var query = from r in db.Records.Include("Video").Include("User")
                        where r.RecordId.Equals(recordId)
                        select r;
            return query.FirstOrDefault();
        }

        public async Task<Record[]> GetRecordsByUserName(string UserName)
        {
            IQueryable<Record> userRecord = from urecord in db.Records.Include("Video").Include("User")
                                            where urecord.User.UserName.Equals(UserName)
                                            orderby urecord.IssueDate
                                            select urecord;
            return await userRecord.ToArrayAsync();
        }

        public string Add(Record newRecord)
        {
            db.Records.Add(newRecord);
            return "New Record Added";
        }

        public Record Delete(int recordId)
        {
            var delete = GetRecordById(recordId);
            if (delete != null)
            {
                db.Records.Remove(delete);
            }
            return delete;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await db.SaveChangesAsync()) > 0;
        }

    }
}
