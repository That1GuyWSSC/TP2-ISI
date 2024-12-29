using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using testebasic.Models;

public class CategoryApiClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "https://localhost:7193/api/Category"; // Replace with your API's base URL

    public CategoryApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        var response = await _httpClient.GetAsync(_baseUrl);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Category>>(json);
    }

    public async Task<Category> GetCategoryByIdAsync(long id)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");
        if (!response.IsSuccessStatusCode)
            return null;

        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Category>(json);
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        var json = JsonConvert.SerializeObject(category);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(_baseUrl, content);
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Category>(responseJson);
    }

    public async Task<bool> UpdateCategoryAsync(long id, Category category)
    {
        var json = JsonConvert.SerializeObject(category);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync($"{_baseUrl}/{id}", content);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteCategoryAsync(long id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        return response.IsSuccessStatusCode;
    }
}
