using System.Collections.Generic;

namespace WeatherApp.WebSite.Models
{
    public class FavoriteContext
    {
        public ISet<string> FavoriteSet;
        public FavoriteContext()
        {
            FavoriteSet = new HashSet<string>();
        }
    }
}
