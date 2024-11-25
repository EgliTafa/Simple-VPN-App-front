using Newtonsoft.Json;
using Simple_VPN_App_front_.Dto;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Simple_VPN_App_front_.Data.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string apiURL = "https://localhost:7214";

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        // User Registration
        public async Task<string> RegisterUser(UserRegistrationDto user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(apiURL + "/Register", content);

            return await response.Content.ReadAsStringAsync();
        }

        // User Login
        public async Task<string> LoginUser(UserLoginDto user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(apiURL + "/Login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var tokenObject = JsonConvert.DeserializeObject<TokenResponse>(responseString);
                var token = tokenObject.Token;
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                return token;
            }

            return "";
        }

        // User Logout
        public async Task<bool> LogoutUser()
        {
            var response = await _httpClient.PostAsync(apiURL + "/Logout", null);

            if (response.IsSuccessStatusCode)
            {
                _httpClient.DefaultRequestHeaders.Authorization = null;
                return true;
            }

            return false;
        }

        // Set Token for Authorization
        public void SetToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        // Connect to VPN
        public async Task<bool> ConnectVpn(bool useTcp)
        {
            var content = new StringContent(JsonConvert.SerializeObject(useTcp), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{apiURL}/Vpn/connect", content);

            return response.IsSuccessStatusCode;
        }

        // Disconnect from VPN
        public async Task<bool> DisconnectVpn()
        {
            var response = await _httpClient.PostAsync($"{apiURL}/Vpn/disconnect", null);

            return response.IsSuccessStatusCode;
        }

        // Get VPN Status
        public async Task<string> GetVpnStatus()
        {
            var response = await _httpClient.GetAsync($"{apiURL}/Vpn/status");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return "Unable to retrieve status.";
        }
    }
}
