using System.Threading.Tasks;

namespace CarMechanic
{
    public interface IWorkEstimationService
    {
        Task<int> EstimateWorkHoursAsync(string category, int carAge, int severity);
    }
}