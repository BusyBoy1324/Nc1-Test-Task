using TestProject.DTO;
using TestProject.Models;

namespace TestProjectFront.Services.DepartmentServices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;

        public DepartmentService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _httpClient = _clientFactory.CreateClient("client");
        }

        public List<Department> Departments { get; set; } = new();

        public async Task<DepartmentDTO> CreateAsync(DepartmentDTO departmentDto)
        {
            try
            {
                var response =
                    await _httpClient.PostAsJsonAsync<DepartmentDTO>(
                        "/api/Department/add", departmentDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(DepartmentDTO);
                    }

                    return await response.Content.ReadFromJsonAsync<DepartmentDTO>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Department>> DeleteAsync(int id)
        {
            try
            {
                var response =
                    await _httpClient.DeleteAsync($"api/Department/delete?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<Department>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Department>> GetAllAsync()
        {
            try
            {
                var response =
                    await _httpClient.GetAsync(
                        "/api/Department/all");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return new List<Department>();
                    }

                    Departments = await response.Content.ReadFromJsonAsync<List<Department>>();
                    return Departments;
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"api/Department/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(Department);
                    }

                    return await response.Content.ReadFromJsonAsync<Department>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Department> UpdateAsync(Department department)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<Department>("/api/Department/edit",
                    department);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(Department);
                    }

                    return await response.Content.ReadFromJsonAsync<Department>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
