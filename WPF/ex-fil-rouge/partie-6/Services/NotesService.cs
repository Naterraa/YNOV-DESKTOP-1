using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application_wpf.Models;

namespace Application_wpf.Services;

public class NotesService
{
    private readonly NotesDbContext _context;

    public NotesService()
    {
        _context = new NotesDbContext();
    }

    public async Task<List<Note>> GetNotesAsync()
    {
        return await _context.Notes.ToListAsync();
    }

    public async Task AddNoteAsync(Note note)
    {
        _context.Notes.Add(note);
        await _context.SaveChangesAsync();
    }

    public async Task<Appreciation?> GetAppreciationAsync()
    {
        return await _context.Appreciations.FirstOrDefaultAsync();
    }

    public async Task SaveAppreciationAsync(Appreciation appreciation)
    {
        if (appreciation.Id == 0) // Nouvelle appréciation
        {
            _context.Appreciations.Add(appreciation);
        }
        else
        {
            _context.Appreciations.Update(appreciation);
        }
        
        await _context.SaveChangesAsync();
    }
}
