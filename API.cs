
using System.Text;
using System.Text.Json;


namespace IromDomeSystem
{
    public static class Http
    {
        public static async Task<LocationData> SendToServer(double lat, double lon)
        {
            string key = "pk.96535233081b2bb0fc3a30f3308e99eb";
            string Message = await Connection(key, Convert.ToString(lat), Convert.ToString(lon));
            LocationData location = JsonSerializer.Deserialize<LocationData>(Message);
            return location;
        }

        public static async Task<string> Connection(string key, string lat, string lon)
        {
            HttpClient Client = new();
            Client.BaseAddress = new Uri("https://us1.locationiq.com/v1/");
            string Key = $"key={key}";
            string Lat = $"lat={lat}";
            string Lon = $"lon={lon}";

            HttpResponseMessage RequestMessage = await Client.GetAsync($"reverse?{Key}&{Lat}&{Lon}&format=json&");

            if (RequestMessage.IsSuccessStatusCode) 
            {

                return await RequestMessage.Content.ReadAsStringAsync();
            }
            else
            {
                return $"Error: {RequestMessage.StatusCode}, {await RequestMessage.Content.ReadAsStringAsync()}";

            }
        }
    }

}
