using CRM.Data.Interfaces;
using CRM.Models;
using Newtonsoft.Json;
using System.Text;

namespace CRM.Data
{
    public class DiaryApiStore : IDiary 
    {
        private readonly HttpClient _httpClient;
        private const string _apiUrl = @"https://localhost:7007/api/diary";

        public DiaryApiStore()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Application>> AllNotes()
        {
            string json = await _httpClient.GetStringAsync(_apiUrl);
            return JsonConvert.DeserializeObject<IEnumerable<Application>>(json);
        }

        public async Task<Application> GetNoteById(int id)
        {
            string json = await _httpClient.GetStringAsync(_apiUrl + $"/{id}");
            return JsonConvert.DeserializeObject<Application>(json);
        }

        public async Task AddNote(Application note)
        {
            var json = JsonConvert.SerializeObject(note);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync(_apiUrl, content);
        }

        public async Task DeleteNote(int id)
        {
            await _httpClient.DeleteAsync(_apiUrl + $"/{id}");
        }

        public async Task UpdateNote(Application note)
        {
            var json = JsonConvert.SerializeObject(note);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _httpClient.PutAsync(_apiUrl, content);
        }

        public async Task<IEnumerable<Author>> GetWorker()
        {
            string json = await _httpClient.GetStringAsync(_apiUrl + "application/GetWorker");

            return JsonConvert.DeserializeObject<IEnumerable<Author>>(json);
        }
    }
}
