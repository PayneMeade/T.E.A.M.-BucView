namespace BucView.Models
{
    /// <summary>
    /// This class is a model for the 'Building Info.json' file
    /// </summary>
    public class Building
    {
        public string? buildingName { get; set; }
        public string? buildingType { get; set; }
        public string? directionsTo { get; set; }
        public buildingInfo? buildingInfo { get; set; }
    }   
}
