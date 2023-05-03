﻿using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete;
using MezuniyetSistemi.DataAccess.Abstract;
using MezuniyetSistemi.DataAccess.Concrete.EntityFramework.Contexts;
using MezuniyetSistemi.Entities.Concrete;
using MezuniyetSistemi.Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.DataAccess.Concrete.EntityFramework.Repositories
{
    public class ProfileRepository : RepositoryBase<UserProfile>, IProfileRepository
    {
        public ProfileRepository(DbContext context) : base(context)
        {
        }

        public IList<UserProfile> GetAllWithPagination(UserProfileParameters userProfileParameters, bool trackChanges) =>
            FindAll(trackChanges)
            .Skip((userProfileParameters.CurrentPage - 1) * userProfileParameters.PageSize)
            .Take(userProfileParameters.PageSize)
            .ToList();
    }
}
