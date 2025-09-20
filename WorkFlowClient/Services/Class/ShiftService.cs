using Domain.Databases;
using Domain.DataTransfareObject;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using WorkFlowClient.Services.Interfaces;

namespace WorkFlowClient.Services.Class
{
    public class ShiftService : IShiftService
    {
        private readonly HttpClient _http;

        public ShiftService(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient("Server");
        }

        public async Task<ApiResponse<List<shiftModel>>> GetAllShiftsAsync()
        {
            var res = await _http.GetAsync("shift");
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadFromJsonAsync<List<shiftModel>>();
                return new ApiResponse<List<shiftModel>> { IsSucceeded = true, Value = data ?? new() };
            }
            return new ApiResponse<List<shiftModel>> { IsSucceeded = false, ErrorMessage = res.ReasonPhrase };
        }

        public async Task<ApiResponse<shiftModel>> GetShiftAsync(int id)
        {
            var res = await _http.GetAsync($"shift/{id}");
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadFromJsonAsync<shiftModel>();
                return new ApiResponse<shiftModel> { IsSucceeded = true, Value = data };
            }
            return new ApiResponse<shiftModel> { IsSucceeded = false, ErrorMessage = res.ReasonPhrase };
        }

        public async Task<ApiResponse<bool>> AddShiftAsync(int userId, FileResult file)
        {
            using var stream = await file.OpenReadAsync();
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms);

            var dto = new AddShiftDto
            {
                UserId = userId,
                ImageBytes = ms.ToArray(),
                Extention = Path.GetExtension(file.FileName).TrimStart('.')
            };

            // حوّل DTO إلى JSON
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _http.PostAsync("shift", content);

            return new ApiResponse<bool>
            {
                IsSucceeded = res.IsSuccessStatusCode,
                Value = res.IsSuccessStatusCode,
                ErrorMessage = res.IsSuccessStatusCode ? null : res.ReasonPhrase
            };
        }

        public async Task<ApiResponse<bool>> EndShiftAsync(EndShiftDto dto)
        {
            var res = await _http.PutAsJsonAsync("shift/EndShift", dto);
            return new ApiResponse<bool> { IsSucceeded = res.IsSuccessStatusCode, Value = res.IsSuccessStatusCode, ErrorMessage = res.ReasonPhrase };
        }

        public async Task<ApiResponse<bool>> ModfiyStatusAsync(ModfiyShiftStatusDto dto)
        {
            var res = await _http.PutAsJsonAsync("shift/ModfyStatus", dto);
            return new ApiResponse<bool> { IsSucceeded = res.IsSuccessStatusCode, Value = res.IsSuccessStatusCode, ErrorMessage = res.ReasonPhrase };
        }

        public async Task<ApiResponse<List<shiftModel>>> GetUserShiftsAsync(int userId)
        {
            var res = await _http.GetAsync($"shift/GetUserShift/{userId}");
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadFromJsonAsync<List<shiftModel>>();
                return new ApiResponse<List<shiftModel>> { IsSucceeded = true, Value = data ?? new() };
            }
            return new ApiResponse<List<shiftModel>> { IsSucceeded = false, ErrorMessage = res.ReasonPhrase };
        }

    
        
    }

}
