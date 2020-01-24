using PIO.Models;
using PIO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIO.Services
{
    public class UserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ApplicationUser GetUser(string userId)
        {
            return _userRepository.GetUser(userId);
        }

    }
}