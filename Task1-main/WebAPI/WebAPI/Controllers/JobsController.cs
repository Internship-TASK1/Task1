using BLL.Services;
using Common.DTOs;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobsService jobsService;

        public JobsController(IJobsService jobsService)
        {
            this.jobsService = jobsService;
        }

        [HttpGet("Get All Jobs")]
        public async Task<ActionResult<IEnumerable<Jobs>>> GetAllJobs()
        {
            var jobs = await jobsService.GetAllJobs();
            return Ok(jobs);
        }

        [HttpGet("Get Job By Id")]
        public async Task<ActionResult<Jobs>> GetJobById(Guid idJobs)
        {
            var job = await jobsService.GetJobs(idJobs);

            if (job == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(job);
        }

        [HttpPost]
        public async Task<ActionResult<Jobs>> InsertJobs(JobsModel jobs)
        {
            if(jobs == null)
            {
                return BadRequest();
            }

            return await jobsService.InsertJobs(jobs);
        }

        [HttpPut]
        public async Task<ActionResult<Jobs>> UpdateJobs(Guid id, JobsModel jobs)
        {
            if (jobs == null)
            {
                return BadRequest();
            }

            return await jobsService.UpdateJobs(id, jobs);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteJobs(Guid job)
        {
            bool result = await jobsService.DeleteJobs(job);

            if(result == false)
            {
                return BadRequest("Delete Not Success!!");
            }

            return Ok("Delete Success!!");
        }
    }
}
