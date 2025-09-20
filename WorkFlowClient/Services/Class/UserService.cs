

using Domain.Databases;
using Domain.DataTransfareObject;
using System;
using System.Net.Http.Json;
using WorkFlowClient.Services.Interfaces;

namespace WorkFlowClient.Services.Class
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;

        public UserService(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient("Server");
        }

        public async Task<ApiResponse<bool>> AddUserAsync(AddUserDto dto)
        {
            var res = await _http.PostAsJsonAsync("user", dto);
            if (res.IsSuccessStatusCode)
                return new ApiResponse<bool> { IsSucceeded = true, Value = true };

            return new ApiResponse<bool>
            {
                IsSucceeded = false,
                ErrorMessage = $"Failed with status {res.StatusCode}"
            };
        }

        public async Task<ApiResponse<VerfyStatus>> GetUserStatusByPhonNumberAsync(string phonNumber)
        {
            var res = await _http.GetAsync($"user/GetUserStatusbyphonnumber/{Uri.EscapeDataString(phonNumber)}");
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadFromJsonAsync<VerfyStatus>();
                return new ApiResponse<VerfyStatus> { IsSucceeded = true, Value = data };
            }

            return new ApiResponse<VerfyStatus>
            {
                IsSucceeded = false,
                ErrorMessage = $"Failed with status {res.StatusCode}"
            };
        }

        public async Task<ApiResponse<bool>> ChangeStatusAsync(ChangeStatusDto dto)
        {
            var res = await _http.PutAsJsonAsync("user", dto);
            if (res.IsSuccessStatusCode)
                return new ApiResponse<bool> { IsSucceeded = true, Value = true };

            return new ApiResponse<bool>
            {
                IsSucceeded = false,
                ErrorMessage = $"Failed with status {res.StatusCode}"
            };
        }

        public async Task<ApiResponse<UserModel>> GetUserByIdAsync(int id)
        {
            var res = await _http.GetAsync($"user/{id}");
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadFromJsonAsync<UserModel>();
                return new ApiResponse<UserModel> { IsSucceeded = true, Value = data };
            }

            return new ApiResponse<UserModel>
            {
                IsSucceeded = false,
                ErrorMessage = $"Failed with status {res.StatusCode}"
            };
        }

        public async Task<ApiResponse<List<UserModel>>> GetUsersAsync()
        {
            var res = await _http.GetAsync("user");
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadFromJsonAsync<List<UserModel>>();
                return new ApiResponse<List<UserModel>> { IsSucceeded = true, Value = data ?? new() };
            }

            return new ApiResponse<List<UserModel>>
            {
                IsSucceeded = false,
                ErrorMessage = $"Failed with status {res.StatusCode}"
            };
        }

        public async Task<ApiResponse<UserModel>> GetUserByPhonNumber(string phonNumber)
        {
            var res = await _http.GetAsync($"user/GetUserByPhonNumber/{phonNumber}");
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadFromJsonAsync<UserModel>();
                return new ApiResponse<UserModel> { IsSucceeded = true, Value = data};
            }

            return new ApiResponse<UserModel>
            {
                IsSucceeded = false,
                ErrorMessage = $"Failed with status {res.StatusCode}"
            };
        }

        public async Task<ApiResponse<bool>> CheckCode(CheckVerfyCode dto)
        {
            var res = await _http.PostAsJsonAsync("user/CheckVerfyCode", dto);
            if (res.IsSuccessStatusCode)
                return new ApiResponse<bool> { IsSucceeded = true, Value = true };

            return new ApiResponse<bool>
            {
                IsSucceeded = false,
                ErrorMessage = $"Failed with status {res.StatusCode}"
            };
        }

        public async Task<ApiResponse<bool>> SendVerfyCode(SendVerfyCodeDto dto)
        {
            var res = await _http.PostAsJsonAsync("user/SendVerfyCode", dto);
            if (res.IsSuccessStatusCode)
                return new ApiResponse<bool> { IsSucceeded = true, Value = true };

            return new ApiResponse<bool>
            {
                IsSucceeded = false,
                ErrorMessage = $"Failed with status {res.StatusCode}"
            };
        }
    }
}
