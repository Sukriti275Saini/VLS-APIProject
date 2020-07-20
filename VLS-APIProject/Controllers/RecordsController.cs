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
    public class RecordsController : ControllerBase
    {
        private readonly IRecordRepository repository;
        private readonly IUserRepository userRepository;
        private readonly IVideoRepository videoRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public RecordsController(IRecordRepository repository, 
                                 IUserRepository userRepository,
                                 IVideoRepository videoRepository,
                                 IMapper mapper,
                                 LinkGenerator linkGenerator)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.videoRepository = videoRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<RecordModel[]>> Get()
        {
            try
            {
                var records = await repository.GetAllRecords();

                return mapper.Map<RecordModel[]>(records);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


        [HttpGet("{RecordId:int}")]
        public ActionResult<RecordModel> Get(int recordId)
        {
            try
            {
                var record = repository.GetRecordById(recordId);

                if (record == null) return NotFound("Record not found");

                return mapper.Map<RecordModel>(record);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


        [HttpGet("{UserName}")]
        public async Task<ActionResult<RecordModel[]>> Get(string userName)
        {
            try
            {
                var record = await repository.GetRecordsByUserName(userName);

                if (record == null) return NotFound("Record not found for this user");

                return mapper.Map<RecordModel[]>(record);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


        [HttpPost]
        public async Task<ActionResult<RecordModel>> Post(RecordModel model)
        {
            try
            {

                var user = userRepository.GetByUserName(model.User.UserName);
                if (user == null) return BadRequest("User not found");

                var video = videoRepository.GetVideosById(model.Video.VideoId);
                if (video == null) return BadRequest("Video not found");

                var record = mapper.Map<Record>(model);
                record.User = user;
                record.Video = video;

                repository.Add(record);

                if (await repository.SaveChangesAsync())
                {
                    var url = linkGenerator.GetPathByAction(HttpContext,
                        "Get",
                        values: new { recordId = record.RecordId });
                    return Created(url, mapper.Map<RecordModel>(record));
                }
                else
                {
                    return BadRequest("Failed to save new record");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add new record");
            }

        }




        [HttpDelete("{RecordId:int}")]
        public async Task<IActionResult> Delete(int recordId)
        {
            try
            {
                var delete = repository.GetRecordById(recordId);
                if (delete == null) return NotFound("Record not found");

                repository.Delete(recordId);

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
