using Microsoft.Graph;
using System.Text.Json.Serialization;

namespace BlazorServerCalendarToInvoice.Model
{
    /// <summary>
    /// Same story as MyDriveItemFolder.
    /// </summary>
    public class MyDriveItemFile
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("file")]
        public Microsoft.Graph.File? File { get; set; }
    }
}
