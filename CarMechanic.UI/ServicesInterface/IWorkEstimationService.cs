using System.Threading.Tasks;

namespace CarMechanic.UI.Services;

public interface IWorkEstimationService
{
    Task<int> EstimateWorkHoursAsync(string category, int carAge, int severity);
}
