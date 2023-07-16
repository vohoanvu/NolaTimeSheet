using System;
using NolaTimeSheet.Data;
using NolaTimeSheet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace NolaTimeSheet.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationUser>> GetApplicationUsers()
        {
            try
            {
                var appUsers = await _context.AspNetUsers.ToListAsync();
                return appUsers;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<ApplicationUser> GetApplicationUser(string id)
        {
            var existingUser = await _context.AspNetUsers.FirstOrDefaultAsync(u => u.Id == id);
            if (existingUser == null)
            {
                throw new Exception("[BAD REQUEST] This user does not exist");
            }

            return existingUser;
        }
    }
}
