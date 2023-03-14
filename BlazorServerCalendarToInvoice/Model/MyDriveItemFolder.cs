using Microsoft.Graph;
using System.Text.Json.Serialization;

namespace BlazorServerCalendarToInvoice.Model
{
    /// <summary>
    /// This class is a substitute for DriveItem. As soon as I used DriveItem in a BatchRequest to create a folder
    /// it complained with BadRequest that I should set 'workbook' later. I didn't set workbook. So I made this class.
    /// </summary>
    public class MyDriveItemFolder
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("folder")]
        public Folder? Folder { get; set; }
    }
}
