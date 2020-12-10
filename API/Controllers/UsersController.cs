using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TenantDTO>>> GetUsers()
        {
            var users = await _userRepository.GetTenantsAsync();
            var usersToReturn = _mapper.Map<IEnumerable<TenantDTO>>(users);
            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<TenantDTO>> GetUser(string username)
        {
            var user = await _userRepository.GetTenantAsync(username);
            return _mapper.Map<TenantDTO>(user);
        }
    }


}