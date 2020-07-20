using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VLS_APIProject.Data.Entities;

namespace VLS_APIProject.Data
{
    public class VideoRepository : IVideoRepository
    {

        private readonly VLSDbContext db;

        public VideoRepository(VLSDbContext db)
        {
            this.db = db;
        }


        public async Task<Video[]> GetAllVideos()
        {
            IQueryable<Video> allvideos = from vids in db.Videos
                            orderby vids.VideoName
                            select vids;
            return await allvideos.ToArrayAsync();
        }


        public async Task<Video[]> GetByVideoName(string VideoName)
        {
            IQueryable<Video> videoname = from vids in db.Videos
                            where vids.VideoName.StartsWith(VideoName) || string.IsNullOrEmpty(VideoName)
                            orderby vids.VideoName
                            select vids;
            return await videoname.ToArrayAsync();
        }


        public Video GetVideosById(int videoId)
        {
            return db.Videos.Find(videoId);
        }
        
        
        public string Add(Video newVideo)
        {
            var checkvideo = from vids in db.Videos
                             where vids.VideoName.Equals(newVideo.VideoName)
                             select vids;
            if(checkvideo.Count() > 0)
            {
                return "Video with the same name already exists";
            }

            db.Add(newVideo);
            return "New Video Added";
        }
        
        
        public Video Delete(int VideoId)
        {
            var deletevideo = GetVideosById(VideoId);
            if(deletevideo != null)
            {
                db.Videos.Remove(deletevideo);
            }
            return deletevideo;
        }
        
        
        public async Task<bool> SaveChangesAsync()
        {
            return (await db.SaveChangesAsync()) > 0;
        }

    }
}
