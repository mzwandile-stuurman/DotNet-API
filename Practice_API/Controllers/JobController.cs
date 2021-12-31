using Microsoft.AspNetCore.Mvc;
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
    public class JobController : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;

        public JobController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/<JobController>
        [HttpGet]
        public async Task<IActionResult> GetJobs(int id)
        {
            var result = await unitOfWork.Jobs.GetAll();
            return Ok(result);
        }
        [HttpGet("greater")]
        public async Task<IActionResult> GetUsersGreaterThan30(int id)
        {
            var result = await unitOfWork.Jobs.GetAll(job => job.Name =="string1");
            return Ok(result);
        }

        // GET api/<JobController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult > GetJob(int id)
        {
            var result = await unitOfWork.Jobs.GetT(q => q.Id == id);
            return Ok(result);
        }

        // POST api/<JobController>
        [HttpPost]
        public async Task CreateJob([FromBody] Job newJob)
        {
            await unitOfWork.Jobs.Insert(newJob);
            await unitOfWork.Save();
        }

        // PUT api/<JobController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Job jobUpdate)
        {
            //var originalJob = await unitOfWork.Jobs.GetT(q => q.Id == id);
            //unitOfWork.Jobs.Update(originalJob);
            //await unitOfWork.Save();
            //var newJob =  unitOfWork.Jobs.Update(jobUpdate);
            //return Ok(newJob);
            //return NoContent(); 

        }

        // DELETE api/<JobController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await unitOfWork.Jobs.GetT(q => q.Id == id);
            return null;
        }
    }
}
