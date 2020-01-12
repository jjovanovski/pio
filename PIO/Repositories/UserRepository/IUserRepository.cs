using PIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIO.Repositories
{
    public interface IUserRepository
    {
        ApplicationUser GetUser(string userId);
    }
}
