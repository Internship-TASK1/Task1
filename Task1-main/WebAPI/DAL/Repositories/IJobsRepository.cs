using DAL.Entities;

namespace DAL.Repositories
{
    public interface IJobsRepository
    {
        //lấy tất cả các jobs
        Task<IEnumerable<Jobs>?> GetAllJobs();

        // lấy job bằng id
        Task<Jobs?> GetJobsById(Guid idOrderDetail);

        // cập nhật lại Jobs
        Task<Jobs?> UpdateJobs(Jobs job);

        // xóa jobs với idJobs
        Task<bool> DeleteJobs(Guid idJob);

        // thêm 1 jobs mới
        Task<Jobs> InsertJobs(Jobs job);
    }
}
