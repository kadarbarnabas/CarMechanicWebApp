using System.Runtime.CompilerServices;
using CarMechanic.Shared;
using Microsoft.EntityFrameworkCore;

namespace CarMechanic;

public class WorkService : IWorkService
{
    private readonly CarMechanicContext _context;
    private readonly ILogger<WorkService> _logger;
    //private readonly  WorkHouresCalculator workHouresCalculator;

    public WorkService(ILogger<WorkService> logger, CarMechanicContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task CreateWork(Work work)
    {   
        var whc = new WorkHouresCalculator();
        work.BecsultOra = whc.CalculateWorkHours(work.Kategoria, work.GyartasiEv, work.HibaSulyossag);

        await _context.Works.AddAsync(work);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Work added");
    }

    public async Task DeleteWork(Guid id)
    {
        var work = await GetWork(id);

        _context.Works.Remove(work);

        await _context.SaveChangesAsync();
    }

    public async Task<Work> GetWork(Guid id)
    {
        var work = await _context.Works.FindAsync(id);
        _logger.LogInformation("Work retrieved: {@Work}", work);
        return work;
    }

    public async Task<List<Work>> GetAllWorks()
    {
        return await _context.Works.ToListAsync();
    }
    
    public async Task UpdateWork(Work newWork)
    {
        var work = await GetWork(newWork.MunkaId);
        work.Ugyfelszam = newWork.Ugyfelszam;
        work.Rendszam = newWork.Rendszam;
        work.GyartasiEv = newWork.GyartasiEv;
        work.Kategoria = newWork.Kategoria;
        work.HibakLeirasa = newWork.HibakLeirasa;
        work.HibaSulyossag = newWork.HibaSulyossag;
        work.Allapot = newWork.Allapot;
        
        var whc = new WorkHouresCalculator();
        work.BecsultOra = whc.CalculateWorkHours(work.Kategoria, work.GyartasiEv, work.HibaSulyossag);

        await _context.SaveChangesAsync();
    }

}