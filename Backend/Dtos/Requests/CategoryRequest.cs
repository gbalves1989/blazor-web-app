using System.Text.Json.Serialization;

namespace Backend.Dtos.Requests
{
    public class CategoryRequest
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;
    }
}
