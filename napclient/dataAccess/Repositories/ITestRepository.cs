using models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface ITestRepository
    {
        Task<string> AddAsync(Test test);
        Task<IEnumerable<Test>> GetBySubjectAsync(string subject);
        Task<string> UpdateAsync(Test test);
    }
}
