using DAL.Entities;
using Common.DTOs;

namespace BLL.Services
{
    public interface IJobsService
    {
        //lấy tất cả các jobs
        Task<IEnumerable<Jobs>> GetAllJobs();

        // lấy job bằng id
        Task<Jobs?> GetJobs(Guid IdJobs);

        // thêm 1 jobs mới
        Task<Jobs> InsertJobs(JobsModel _job);

        // cập nhật lại Jobs
        Task<Jobs> UpdateJobs(Guid id, JobsModel _job);

        Task<bool> DeleteJobs(Guid IdJobs);
    }
}
