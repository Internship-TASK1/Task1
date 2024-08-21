using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class JobsRepository : IJobsRepository
    {
        private readonly MyDbContext _context;

        public JobsRepository(MyDbContext context)
        {
            _context = context;
        }

        // xóa jobs với idJobs
        public async Task<bool> DeleteJobs(Guid idJob)
        {
            var job = _context.Jobs.FirstOrDefault(j => j.Id == idJob);

            if (job != null) {
                return false;            
            }

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();

            return true;

        }

        //lấy tất cả các jobs
        public async Task<IEnumerable<Jobs>?> GetAllJobs()
        {
            return await _context.Jobs.ToListAsync();
        }

        // lấy job bằng id
        public async Task<Jobs?> GetJobsById(Guid idOrderDetail)
        {
            return await _context.Jobs.FirstOrDefaultAsync(j => j.Id == idOrderDetail);
        }
         
        // thêm 1 jobs mới
        public async Task<Jobs?> InsertJobs(Jobs job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();

            return await GetJobsById(job.Id);
        }

        // cập nhật lại Jobs
        public async Task<Jobs?> UpdateJobs(Jobs job)
        {
            try
            {
                if (job != null)
                {
                    _context.Jobs.Update(job);
                    await _context.SaveChangesAsync();
                }

                return await GetJobsById(job.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error: {ex.Message}");
                throw;
            }
        }
    }
}
