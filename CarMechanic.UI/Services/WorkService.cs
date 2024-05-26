using System.Net.Http.Json;
using CarMechanic;
using CarMechanic.Shared;

namespace CarMechanic.UI.Services
{
    public class WorkService : IWorkService
    {
        private readonly HttpClient _httpClient;
        
        public WorkService(HttpClient httpClient)
        {
            _httpClient = httpClient;;
        }

        public async Task CreateWorkAsync(Work work)
        {
            await _httpClient.PostAsJsonAsync("/Work", work);
        }

        public async Task DeleteWorkAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"/Work/{id}");
        }

        public async Task<Work> GetWorkAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Work>($"Work/{id}");
        }

        public async Task<IEnumerable<Work>> GetAllWorksAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Work>>("/Work");
        }

        public async Task UpdateWorkAsync(Guid id, Work work)
        {
            await _httpClient.PutAsJsonAsync($"/Work/{id}", work);
        }
    }
}