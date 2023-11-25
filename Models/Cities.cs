using Newtonsoft.Json;

namespace StudyingProcedures.Models
{
    public class Cities
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("city_name")]
        public string CityName { get; set; }
        [JsonProperty("population")]
        public long Population { get; set; }

    }
}
