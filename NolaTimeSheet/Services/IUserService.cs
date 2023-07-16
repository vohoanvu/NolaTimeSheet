using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NolaTimeSheet.Models;

namespace NolaTimeSheet.Services
{
    public interface IUserService
    {
        Task<List<ApplicationUser>> GetApplicationUsers();

        Task<ApplicationUser> GetApplicationUser(string id);
    }
}
