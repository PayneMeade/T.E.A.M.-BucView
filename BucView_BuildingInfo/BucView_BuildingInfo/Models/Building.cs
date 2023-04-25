namespace BucView_BuildingInfo.Models
{
    public class Building
    {
        public string? buildingName { get; set; }
        public string? buildingType { get; set; }
        public string? directionsTo { get; set; }
        public buildingInfo? buildingInfo { get; set; }
    }
}