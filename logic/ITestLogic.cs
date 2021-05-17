using models;
using System;
using System.Threading.Tasks;

namespace logic
{
    public interface ITestLogic
    {
        Task<bool> UpdateStatus(Guid testId, string status);
    }
}
