using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VLS_APIProject.Data;
using VLS_APIProject.Data.Entities;
using VLS_APIProject.Models;

namespace VLS_APIProject.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly IVideoRepository repository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public VideosController(IVideoRepository repository,
                                IMapper mapper,
                                LinkGenerator linkGenerator)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        //Get all videos
        [HttpGet]
        public async Task<ActionResult<VideoModel[]>> Get()
        {
            try
            {
                var videos = await repository.GetAllVideos();
                if (videos == null) return NotFound("No video found in database");

                return mapper.Map<VideoModel[]>(videos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


        //Get video by id
        [Route("VideoDetails")]
        [HttpGet("{VideoId:int}")]
        public ActionResult<VideoModel> Get([FromQuery]int VideoId)
        {
            try
            {
                var video = repository.GetVideosById(VideoId);

                if (video == null) return NotFound("Video not found");

                return mapper.Map<VideoModel>(video);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


        [HttpGet("{VideoName}")]
        public async Task<ActionResult<VideoModel[]>> Get(string VideoName)
        {
            try
            {
                var videoName = await repository.GetByVideoName(VideoName);

                if (videoName == null) return NotFound("Video not found with this name");

                return mapper.Map<VideoModel[]>(videoName);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


        [HttpPost]
        public async Task<ActionResult<VideoModel>> Post(VideoModel model)
        {
            try
            {
                var evideo = await repository.GetByVideoName(model.VideoName);
                if (evideo != null) return BadRequest("This video already exists");

                var newvideo = mapper.Map<Video>(model);

                repository.Add(newvideo);

                if (await repository.SaveChangesAsync())
                {
                    var url = linkGenerator.GetPathByAction(HttpContext,
                        "Get",
                        values: new { VideoId = newvideo.VideoId });

                    return Created(url, mapper.Map<VideoModel>(newvideo));
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest();
        }


        [HttpPut("{VideoId:int}")]
        public async Task<ActionResult<VideoModel>> Put(int VideoId, VideoModel model)
        {
            try
            {
                var editVideo = repository.GetVideosById(VideoId);
                if (editVideo == null) return NotFound("Could not find video");

                mapper.Map(model, editVideo);

                if(await repository.SaveChangesAsync())
                {
                    return mapper.Map<VideoModel>(editVideo);
                }
            }
            catch(Exception exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest();
        }



        [HttpDelete("{VideoId:int}")]
        public async Task<IActionResult> Delete(int VideoId)
        {
            try
            {
                var delete = repository.GetVideosById(VideoId);
                if (delete == null) return NotFound("Video not found");

                repository.Delete(VideoId);

                if (await repository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Failed to delete record");
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


    }
}
