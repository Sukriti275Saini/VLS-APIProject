using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using VLS_APIProject.Data.Entities;
using VLS_APIProject.Models;

namespace VLS_APIProject.Data
{
    public class VLSProfile : Profile
    {
        public VLSProfile()
        {
            this.CreateMap<Video, VideoModel>()
                .ReverseMap();

            this.CreateMap<User, UserModel>()
                .ReverseMap();

            this.CreateMap<User, LoginRequestModel>()
                .ReverseMap();

            this.CreateMap<Record, RecordModel>()
                .ReverseMap();
                //.ForMember(t => t.User, option => option.Ignore())
                //.ForMember(t => t.Video, option => option.Ignore());
        }
    }
}
