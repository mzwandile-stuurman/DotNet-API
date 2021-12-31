using Microsoft.AspNetCore.Mvc;
using Practice_API.Data;
using Practice_API.IRepository;
using Practice_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practice_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase


    {
        private readonly IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }




        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetUsers(int id)
        {
            var result = await unitOfWork.Users.GetAll();
            return Ok(result);
        }
        [HttpGet("greater")]
        public async Task<IActionResult> GetUsersGreaterThan30(int id)
        {
            var result = await unitOfWork.Users.GetAll(user => user.Age > 20);
            return Ok(result);
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await unitOfWork.Users.GetT(q => q.Id == id);
            return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task CreateUser([FromBody] User newUser )
        {
            await unitOfWork.Users.Insert(newUser);
            await unitOfWork.Save();

          
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User value)
        {
            var result = await unitOfWork.Users.GetT(user => user.Id == id);
            result.Name = value.Name;
            result.Age = value.Age;
            unitOfWork.Users.Update(result);
            await unitOfWork.Save();
           
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await unitOfWork.Users.Delete(id);
            await unitOfWork.Save();
        }
    }
}
