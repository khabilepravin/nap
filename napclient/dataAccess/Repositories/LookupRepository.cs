using dataModel.Repositories;
using models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace dataAccess.Repositories
{
    public class LookupRepository : BaseRepository, ILookupRepository
    {
        public LookupRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<LookupGroup> AddGroupAsync(LookupGroup lookupGroup)
        {
            using (var db = base._dbContextFactory.Create())
            {               
                await db.LookupGroup.AddAsync(lookupGroup);
                await db.SaveChangesAsync();
                return lookupGroup;
            }
        }

        public async Task<LookupValue> AddValueAsync(LookupValue lookupValue)
        {
            using (var db = base._dbContextFactory.Create())
            {
                await db.LookupValue.AddAsync(lookupValue);
                await db.SaveChangesAsync();
                return lookupValue;
            }
        }

        public async Task<IEnumerable<LookupGroup>> GetGroupsAsync()
        {
            using (var db = base._dbContextFactory.Create())
            {
                return await(from q in db.LookupGroup                             
                             select q).ToListAsync<LookupGroup>();
            }
        }

        public async Task<IEnumerable<LookupValue>> GetValuesByGroupAsync(Guid groupId)
        {
            using (var db = base._dbContextFactory.Create())
            {
                return await (from v in db.LookupValue
                              where v.GroupId == groupId
                              select v).ToListAsync<LookupValue>();
            }
        }
    }
}
