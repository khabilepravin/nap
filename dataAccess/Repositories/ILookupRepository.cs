using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataAccess.Repositories
{
    public interface ILookupRepository
    {
        Task<LookupValue> AddValueAsync(LookupValue lookupValue);
        Task<IEnumerable<LookupValue>> GetValuesByGroupAsync(Guid groupId);
        Task<LookupGroup> AddGroupAsync(LookupGroup lookupGroup);
        Task<IEnumerable<LookupGroup>> GetGroupsAsync();
        Task<IEnumerable<LookupValue>> GetValuesByGroupCodeAsync(string groupCode);

    }
}
