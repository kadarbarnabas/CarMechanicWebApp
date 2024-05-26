using System.Net.Http.Json;
using CarMechanic;
using CarMechanic.Shared;

namespace CarMechanic.UI.Services
{
    public class WorkService : IWorkService
    {
        private readonly HttpClient _httpClient;
        private readonly WorkEstimationService _workEstimationService;
        
        public WorkService(HttpClient httpClient, WorkEstimationService workEstimationService)
        {
            _httpClient = httpClient;
            _workEstimationService = workEstimationService;
        }

        public async Task CreateWorkAsync(Work work)
        {
            await _httpClient.PostAsJsonAsync("/Works", work);
        }

        public async Task DeleteWorkAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"/Works/{id}");
        }

        public async Task<Work> GetWorkAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Work>($"Works/{id}");
        }

        public async Task<IEnumerable<Work>> GetAllWorksAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Work>>("/Works");
        }

        public async Task UpdateWorkAsync(Guid id, Work work)
        {
            await _httpClient.PutAsJsonAsync($"/Works/{id}", work);
        }

        public async Task<int> EstimateWorkHoursAsync(string category, int carAge, int severity)
        {
            return await Task.Run(() => _workEstimationService.EstimateWorkHours(category, carAge, severity));
        }
    }
}