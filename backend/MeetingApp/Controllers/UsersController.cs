using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeetingApp.Data;
using MeetingApp.DTOs;
using MeetingApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeetingApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;

        public IMeetingRepository _repo { get; set;  }

        public UsersController(IMeetingRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers() {
            var users = await _repo.GetAllUsers();
            var UsersList = _mapper.Map<IEnumerable<UserForListDTO>>(users);
            return Ok(UsersList);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> GetUser(int id) {
            var user = await _repo.GetUser(id);
            var UsertoReturn = _mapper.Map<Users,UserForDetailsDTO>(user);
            return Ok(UsertoReturn);
        }
    }
}
