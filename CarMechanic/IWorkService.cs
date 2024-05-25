using CarMechanic.Shared;

namespace CarMechanic;

public interface IWorkService
{
    Task CreateWork(Work work);
    Task DeleteWork(Guid id);
    Task<Work> GetWork(Guid id);
    Task<List<Work>> GetAllWorks();
    Task<int> CalculateWorkEstimation(string category, int carAge, int severity);
    Task UpdateWork(Work work);
}