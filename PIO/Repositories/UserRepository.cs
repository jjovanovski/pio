using PIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIO.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser GetUser(string userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }
    }
}