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
    public class ChildController : ControllerBase
    {
        private readonly IChildService _childService;

        public ChildController(IChildService childService)
        {
            _childService = childService;
        }

        [HttpGet]
        public async Task<IEnumerable<ChildDTO>> Get()
        {
            return await _childService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ChildDTO> Get(int id)
        {
            return await _childService.GetByIdAsync(id);
        }

        [HttpPost]//add
        public async Task<ChildDTO> Post([FromBody] ChildModel model)
        {
            return await _childService.AddAsync(new ChildDTO()
            {
                Name = model.Name,
                TZ=model.TZ,
                DateOfBirth=model.DateOfBirth,
                IdParent1=model.IdParent1,
                IdParent2=model.IdParent2
            });
        }

        [HttpPut("{id}")]//update
        public async Task<ChildDTO> Put(int id, [FromBody] ChildModel model)
        {
            return await _childService.UpdateAsync(new ChildDTO()
            {
                Id = id,
                Name = model.Name,
                TZ = model.TZ,
                DateOfBirth = model.DateOfBirth,
                IdParent1 = model.IdParent1,
                IdParent2 = model.IdParent2
            });
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _childService.DeleteAsync(id);
        }
    }
}
