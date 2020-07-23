using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VLS_APIProject.Data;
using VLS_APIProject.Data.Entities;
using VLS_APIProject.Models;

namespace VLS_APIProject.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public AuthController(IUserRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        { 
            this.repository = repository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        //[AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<UserModel[]>> Get()
        {
            try
            {
                var allusers = await repository.GetAllUsers();
                return mapper.Map<UserModel[]>(allusers);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        //[AllowAnonymous]
        [Route("GetUser")]
        [HttpGet("{UserName}")]
        public ActionResult<UserModel> Get([FromQuery] string UserName)
        {
            try
            {
                var user = repository.GetByUserName(UserName);

                if (user == null) return NotFound("User not found");

                return mapper.Map<UserModel>(user);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UserModel>> PostRegisterUser(UserModel model)
        {
            try
            {
                var existinguser = repository.GetByUserName(model.UserName);
                if (existinguser != null) return BadRequest("User with this username already exists");

                var newuser = mapper.Map<User>(model);

                var response = repository.Add(newuser);

                if (await repository.SaveChangesAsync())
                {
                    //
                    var url = linkGenerator.GetPathByAction(HttpContext,
                        "Get",
                        values: new { UserName = model.UserName });

                    //
                    return Ok(response);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest();
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]LoginRequestModel model)
        {
            var response = repository.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }


    }
}
