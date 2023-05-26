using CRM.Models;

namespace CRM.Data.Interfaces
{
    public interface IDiary
    {
        Task<IEnumerable<Application>> AllNotes();

        Task<Application> GetNoteById(int id);

        Task AddNote(Application note);

        Task DeleteNote(int id);

        Task UpdateNote(Application note);
    }
}
