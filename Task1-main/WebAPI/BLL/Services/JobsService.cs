using Common.DTOs;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class JobsService : IJobsService
    {
        private readonly IJobsRepository _jobRepository;

        public JobsService(IJobsRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public Task<bool> DeleteJobs(Guid IdJobs)
        {
            return _jobRepository.DeleteJobs(IdJobs);
        }

        public Task<IEnumerable<Jobs>> GetAllJobs()
        {
            return _jobRepository.GetAllJobs();
        }

        public Task<Jobs?> GetJobs(Guid IdJobs)
        {
            return _jobRepository.GetJobsById(IdJobs);
        }

        public Task<Jobs> InsertJobs(JobsModel _job)
        {
            Jobs jobs = new Jobs()
            {
                Id = Guid.NewGuid(),
                OrderDetailID = _job.OrderDetailID,
                Deadline = _job.Deadline,
                UserID = _job.UserID
            };

            return _jobRepository.InsertJobs(jobs);
        }

        public Task<Jobs> UpdateJobs(Guid id, JobsModel _job)
        {
            Jobs jobs = new Jobs()
            {
                Id = id,
                OrderDetailID = _job.OrderDetailID,
                Deadline = _job.Deadline,
                UserID = _job.UserID
            };

            return _jobRepository.UpdateJobs(jobs);
        }
    }
}
