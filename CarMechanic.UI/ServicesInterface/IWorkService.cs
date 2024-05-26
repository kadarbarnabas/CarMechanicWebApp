using CarMechanic.Shared;

namespace CarMechanic.UI.Services;

public interface IWorkService
{
    Task CreateWorkAsync(Work work);
    Task DeleteWorkAsync(Guid id);
    Task<Work> GetWorkAsync(Guid id);
    Task<IEnumerable<Work>> GetAllWorksAsync();
    Task UpdateWorkAsync(Guid id, Work work);
    Task<int> EstimateWorkHoursAsync(string category, int carAge, int severity);
}