using System.Collections.Generic;

namespace BucView.Models
{
    public class Tour
    {
        public List<string> Tour1Order { get; set; } = new List<string>() {
            "D.P. Culp Center","Stone Hall","Carter Hall","Lamb Hall","Hutcheson Hall","Powell Hall","Wilson-Wallis Hall","Ross Hall","West Hall","Ada Earnest House","Lucille Clement Hall","Luntsford Apartments","William B. Greene Jr. Football Stadium","Basler Center for Physical Activity","Warf-Pickel Hall","ETSU Athletic Center","Brooks Gymnasium","Sam Wilson Hall","Campus Center Building","Tree House","Ball Hall","Gilbreath Hall","Brown Hall","Carillon and Alumni Plaza","Rogers-Stout Hall","Charles C. Sherod Library"
        };      //Order of Tour 1
        /// <summary>
        /// Gets the next building in the tour passing the building the user is coming from
        /// </summary>
        /// <param name="tour"></param>
        /// <param name="currentBuilding"></param>
        /// <returns></returns>
        public string getNext(string tour,string currentBuilding)
        {
            if (tour == "tour1")
            {
                var building = Tour1Order.SkipWhile(x => x != currentBuilding).Skip(1).DefaultIfEmpty(Tour1Order[0]).FirstOrDefault()!;
                if (currentBuilding == Tour1Order.Last())
                {
                    building = null;
                }
                return building!;
            }
            return Tour1Order.SkipWhile(x => x != currentBuilding).Skip(1).DefaultIfEmpty(Tour1Order[0]).FirstOrDefault()!;
        }  


    }
}
