using TestProject.DTO;
using TestProject.Models;

namespace TestProjectFront.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;

        public EmployeeService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _httpClient = _clientFactory.CreateClient("client");
        }

        public List<Employee> Employees { get; set; } = new();

        public async Task<EmployeeDTO> CreateAsync(EmployeeDTO employeeDto)
        {
            try
            {
                var response =
                    await _httpClient.PostAsJsonAsync<EmployeeDTO>(
                        "/api/Employee/add", employeeDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(EmployeeDTO);
                    }

                    return await response.Content.ReadFromJsonAsync<EmployeeDTO>();
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

        public async Task<List<Employee>> DeleteAsync(int id)
        {
            try
            {
                var response =
                    await _httpClient.DeleteAsync($"api/Employee/delete?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<Employee>>();
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

        public async Task<List<Employee>> GetAllAsync()
        {
            try
            {
                var response =
                    await _httpClient.GetAsync(
                        "/api/Employee");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return new List<Employee>();
                    }

                    Employees = await response.Content.ReadFromJsonAsync<List<Employee>>();
                    return Employees;
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

        public async Task<Employee> GetByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"api/Employee/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(Employee);
                    }

                    return await response.Content.ReadFromJsonAsync<Employee>();
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


        public async Task<Employee> UpdateAsync(Employee employee)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<Employee>("/api/Employee/edit",
                    employee);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(Employee);
                    }

                    return await response.Content.ReadFromJsonAsync<Employee>();
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
