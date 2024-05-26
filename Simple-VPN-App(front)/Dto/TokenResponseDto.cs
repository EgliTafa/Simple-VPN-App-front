using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_VPN_App_front_.Dto
{
    public class TokenResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; } = string.Empty;
    }
}
