using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Resources.DTOs;
using MyProject.Services.Interfaces;
using MyProject.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.WebAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> Get()
        {
            return await _userService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<UserDTO> Get(int id)
        {
            return await _userService.GetByIdAsync(id);
        }

        [HttpPost]//add
        public async Task<UserDTO> Post([FromBody] UserModel model)
        {
            return await _userService.AddAsync(new UserDTO()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                TZ = model.TZ,
                DateOfBirth = model.DateOfBirth,
                Kind=model.Kind,
                HMO=model.HMO
            });
        }

        [HttpPut("{id}")]//update
        public async Task<UserDTO> Put(int id, [FromBody] UserModel model)
        {
            return await _userService.UpdateAsync(new UserDTO()
            {
                Id = id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                TZ = model.TZ,
                DateOfBirth = model.DateOfBirth,
                Kind = model.Kind,
                HMO = model.HMO
            });
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _userService.DeleteAsync(id);
        }
    }
}
