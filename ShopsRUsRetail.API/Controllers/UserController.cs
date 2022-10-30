using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopsRUsRetail.Core.Entities;
using ShopsRUsRetail.Core.Entities.DTOs;
using ShopsRUsRetail.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopsRUs.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public UserController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var customers = await _serviceManager.UserService.GetUsers();
            var customerDto = _mapper.Map<IEnumerable<CustomerUsersDto>>(customers);
            return Ok(customerDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsers([FromBody] CreateCustomerUserDto userDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userEntity = _mapper.Map<Users>(userDto);
            await _serviceManager.UserService.CreateUsers(userEntity); 
          

            var customerToReturn = _mapper.Map<CustomerUsersDto>(userEntity);
            return CreatedAtRoute("UserId", new { Id = customerToReturn.UserId }, customerToReturn); 
        }

        [HttpGet("{Id:int}", Name = "UserId")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            var customer = await _serviceManager.UserService.GetUserById(Id);
            if (customer == null) return NotFound();
            var customerDto = _mapper.Map<CustomerUsersDto>(customer);
            return Ok(customerDto);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            var customer = await _serviceManager.UserService.GetUserByName(name.Trim().ToLower());
            if (customer == null) return NotFound();
            var customerDto = _mapper.Map<CustomerUsersDto>(customer);
            return Ok(customerDto);
        }

        [HttpDelete("{Id:int}", Name = "UserId")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var customer = await _serviceManager.UserService.GetUserById(Id);
            if (customer == null) return NotFound();

            var userDto = _mapper.Map<Users>(customer);
            await _serviceManager.UserService.DeleteUser(userDto);

            return Ok(Id);
        }
    }
}
