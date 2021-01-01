using SeliseTest.Data.Core.Domain;
using SeliseTest.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeliseTest.Data.Persistence.Repositories
{
    public class UserGroupRepository : Repository<UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
