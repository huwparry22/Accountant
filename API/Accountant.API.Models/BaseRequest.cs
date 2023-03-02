using System.Text.Json.Serialization;

namespace Accountant.API.Models
{
    public class BaseRequest
    {
        [JsonIgnore]
        public User AuthenticatedUser { get; set; }
    }
}
