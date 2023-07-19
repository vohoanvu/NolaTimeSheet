using System.Collections.Generic;
using System.Threading.Tasks;
using NolaTimeSheet.Models;
using NolaTimeSheet.ViewModels;

namespace NolaTimeSheet.Services
{
    public interface ITimeSheetService
    {
        Task<List<Time>> GetAllTimeEntries();

        Task<List<Time>> GetTimeEntriesByUserId(string userId);

        Task<List<Time>> GetEditableTimeSheetByUserId(string userId);

        Task<List<Time>> GetTimeEntriesByProjectId(int projectId);

        Task<List<Time>> GetTimeEntriesByUserProject(int projectId, string userId);

        Task<List<Time>> FilterTimeSheet(TimeSheetFilterViewModel filter);

        Task<Time> CreateNewTimeEntry(Time time);

        Task<Time> UpdateTimeEntry(Time time);

        Task UpdateTimeEntryByField(Time time, string propertyName);

        Task<bool> DeleteTimeEntry(Time time);

        Task<bool> CloseTimeEntry(Time time);
    }
}
