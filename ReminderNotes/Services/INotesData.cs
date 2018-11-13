using System.Collections.Generic;
using System.Threading.Tasks;
using ReminderNotes.Models;

namespace ReminderNotes.Services
{
    public interface INotesData
    {
        IEnumerable<Note> GetAll();
        Note Get(int id);
        Task<Note> GetAsync(int id);
        Task<Note> GetAsNoTrackingAsync(int id);
        void Add(Note note);
        Note Remove(Note note);
        Note Update(Note note);
    }
}
