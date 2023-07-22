using Microsoft.EntityFrameworkCore;
using NolaTimeSheet.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NolaTimeSheet.Models;
using NolaTimeSheet.ViewModels;

namespace NolaTimeSheet.Services
{
    public class TimeSheetService : ITimeSheetService
    {
        private readonly ApplicationDbContext _context;

        public TimeSheetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Time>> GetAllTimeEntries()
        {
            return await _context.Times.ToListAsync();
        }

        public async Task<List<Time>> GetTimeEntriesByUserId(string userId)
        {
            return await _context.Times
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<Time>> GetEditableTimeSheetByUserId(string userId)
        {
            return await _context.Times
                .Where(t => t.UserId == userId && !t.Closed)
                .ToListAsync();
        }

        public async Task<List<Time>> GetTimeEntriesByProjectId(int projectId)
        {
            return await _context.Times
                .Where(t => t.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<List<Time>> GetTimeEntriesByUserProject(int projectId, string userId)
        {
            return await _context.Times
                .Where(t => t.ProjectId == projectId && t.UserId == userId)
                .ToListAsync();
        }

        public async Task<Time> CreateNewTimeEntry(Time time)
        {
            try
            {
                _context.Times.Add(time);
                await _context.SaveChangesAsync();
                return time;
            }
            catch (Exception e)
            {
                Debug.WriteLine($" Vu Debug:... {e}");
                throw;
            }
        }

        public async Task<Time> UpdateTimeEntry(Time time)
        {
            var existingTime = _context.Times.Local.FirstOrDefault(t => t.Id == time.Id);
            if (existingTime != null)
            {
                _context.Entry(existingTime).CurrentValues.SetValues(time);
            }
            else
            {
                _context.Times.Attach(time);
                _context.Entry(time).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
            return time;
        }


        public async Task<bool> DeleteTimeEntry(long timeId)
        {
            try
            {
                var existingTime = await _context.Times.FindAsync(timeId);
                if (existingTime == null) return false;

                _context.Times.Remove(existingTime);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Vu debugging... {e}");
                throw;
            }
        }

        public async Task<bool> CloseTimeEntry(Time time)
        {
            time.Closed = true;
            await UpdateTimeEntry(time);
            return true;
        }

        public async Task<List<Time>> FilterTimeSheet(TimeSheetFilterViewModel filter)
        {
            var times = await _context.Times.Where(t => t.Closed
                                                        && (filter.UserId == null || t.UserId == filter.UserId)
                                                        && (filter.ProjectId == null || t.ProjectId == filter.ProjectId))
            .Include(t => t.Project).ToListAsync();

            if (filter.StartDate != DateTime.MinValue)
            {
                times = times.Where(t => t.WorkingDate >= filter.StartDate).ToList();
            }

            if (filter.EndDate != DateTime.MaxValue)
            {
                times = times.Where(t => t.WorkingDate <= filter.EndDate).ToList();
            }

            return times;
        }

        public async Task UpdateTimeEntryByField(Time time, string propertyName)
        {
            var entry = _context.Entry(time);
            entry.Property(propertyName).IsModified = true;
            await _context.SaveChangesAsync();
        }
    }
}
