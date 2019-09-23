using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misfit.CORE.Domains;
using Misfit.CORE.Interfaces;
using Misfit.CORE.ViewModels;
using Misfit.SERVICE.Services;

namespace Misfit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository _userRepo;
        UserService userService;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
            userService = new UserService();
        }

        [HttpPost, Route("getforlist")]
        public IActionResult GetForList(UserListingProperty listingProperty)
        {
            return Ok(userService.GetAllForList(listingProperty));
        }

        [HttpGet]
        public IActionResult Get()
        {
            //return Ok(userService.GetAll());
            return Ok(userService.GetAllForList(new UserListingProperty()));
        }

        [HttpPost]
        public IActionResult Post([FromBody]  CEUserCalculationVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<bool>()
                {
                    Success = false,
                    Data = false,
                    ErrorMessage = "Model is not valid"
                });
            }
            return Ok(userService.CreateUserWithNumbers(model));
        }

        [HttpGet, Route("getuserbyname")]
        public IActionResult GetUserByName(string userName)
        {
            //return Ok(userService.GetAll());
            return Ok(userService.GetUserByName(userName));
        }
    }
}