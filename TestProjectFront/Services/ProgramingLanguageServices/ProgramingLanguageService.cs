using TestProject.DTO;
using TestProject.Models;

namespace TestProjectFront.Services.ProgramingLanguageServices
{
    public class ProgramingLanguageService : IProgramingLanguageService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;

        public ProgramingLanguageService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _httpClient = _clientFactory.CreateClient("client");
        }

        public List<ProgramingLanguage> ProgramingLanguages { get; set; } = new();

        public async Task<ProgramingLanguageDTO> CreateAsync(ProgramingLanguageDTO programingLanguageDto)
        {
            try
            {
                var response =
                    await _httpClient.PostAsJsonAsync<ProgramingLanguageDTO>(
                        "/api/ProgramingLanguage/AddProgramingLanguage", programingLanguageDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ProgramingLanguageDTO);
                    }

                    return await response.Content.ReadFromJsonAsync<ProgramingLanguageDTO>();
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

        public async Task<List<ProgramingLanguage>> DeleteAsync(int id)
        {
            try
            {
                var response =
                    await _httpClient.DeleteAsync($"api/ProgramingLanguage/DeleteProgramingLanguage?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ProgramingLanguage>>();
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

        public async Task<List<ProgramingLanguage>> GetAllAsync()
        {
            try
            {
                var response =
                    await _httpClient.GetAsync(
                        "api/ProgramingLanguage/ProgramingLanguages");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return new List<ProgramingLanguage>();
                    }

                    ProgramingLanguages = await response.Content.ReadFromJsonAsync<List<ProgramingLanguage>>();
                    return ProgramingLanguages;
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

        public async Task<ProgramingLanguage> GetByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"api/ProgramingLanguage/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ProgramingLanguage);
                    }

                    return await response.Content.ReadFromJsonAsync<ProgramingLanguage>();
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


        public async Task<ProgramingLanguage> UpdateAsync(ProgramingLanguage programingLanguage)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<ProgramingLanguage>("/api/ProgramingLanguage/UpdateProgramingLanguage",
                    programingLanguage);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ProgramingLanguage);
                    }

                    return await response.Content.ReadFromJsonAsync<ProgramingLanguage>();
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
