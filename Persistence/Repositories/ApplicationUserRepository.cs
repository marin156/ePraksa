﻿using System.Collections.Generic;
using System.Linq;
using PracticeManagement.Core.Dto;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;
using PracticeManagement.Core.ViewModel;

namespace PracticeManagement.Persistence.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserViewModel> GetUsers()
        {
            return (from user in _context.Users
                    from userRole in user.Roles
                    join role in _context.Roles
                        on userRole.RoleId equals role.Id
                    select new UserViewModel()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Role = role.Name,
                        IsActive = user.IsActive
                    }).ToList();
        }

        public ApplicationUser GetUser(string id)
        {
            return _context.Users.Find(id);
        }

    }
}