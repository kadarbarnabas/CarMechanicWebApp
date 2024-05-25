using CarMechanic.Shared;

namespace CarMechanic;

public interface IWorkService
{
    Task CreateWork(Work work);
    Task DeleteWork(Guid id);
    Task<Work> GetWork(Guid id);
    Task<List<Work>> GetAllWorks();
    Task UpdateWork(Work work);

    Task<int> EstimateWorkHoursAsync(string category, int carAge, int severity);
}