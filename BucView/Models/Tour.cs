using System.Collections.Generic;

namespace BucView.Models
{
    public class Tour
    {
        public List<string> Tour1Order { get; set; } = new List<string>() {
            "Ada Earnest House","Alumni Plaza/Carillon","B. Carroll Reece Museum","Ball Hall","Basler Center for Physical Activity","Brooks Gymnasium","Brown Hall","Burgin E. Dossett Hall","Campus Center Building","Carter Hall","Centennial Hall","Charles C. Sherrod Library","D.P. Culp Student Center","Davis Apartments","ETSU Athletic Center (Mini-Dome)","ETSU Family Medicine Associates","Garage C-Store","Gilbreath Hall","Governors Hall","Hutcheson Hall","Lamb Hall (Currently under construction)","Lucille Clement Hall","Luntsford Apartments","Lyle House","Martin Center for the Arts","Mathes Hall","Millennium Center","National Alumni Association","Nell Dossett Hall","Nicks Hall","Niswonger Digital Media Center","Parking Services","Powell Hall","Rogers-Stout Hall","Ross Hall","Sam Wilson Hall","Stone Hall","Summers-Taylor Soccer Complex","Tennis Complex","The Quad-Veterans Memorial","University School","Warf-Pickel Hall","West Hall","William B. Greene Jr. Football Stadium","Wilson-Wallis Hall","Yoakley Hall","Treehouse Takeout"
        };

        public string getNext(string tour,string currentBuilding)
        {
            if (tour == "tour1")
            {
                return Tour1Order.SkipWhile(x => x != currentBuilding).Skip(1).DefaultIfEmpty(Tour1Order[0]).FirstOrDefault()!;
            }
            return Tour1Order.SkipWhile(x => x != currentBuilding).Skip(1).DefaultIfEmpty(Tour1Order[0]).FirstOrDefault()!;
        }

    }
}
