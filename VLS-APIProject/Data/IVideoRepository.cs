using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VLS_APIProject.Data.Entities;

namespace VLS_APIProject.Data
{
    public interface IVideoRepository
    {
        public Task<Video[]> GetAllVideos();

        public Task<Video> GetByVideoName(string VideoName);

        public Video GetVideosById(int videoId);

        public string Add(Video newVideo);

        public Video Delete(int VideoId);

        public Task<bool> SaveChangesAsync();
    }
}
