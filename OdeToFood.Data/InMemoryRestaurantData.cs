using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant() {Id = 1, Name = "V Pizza", Location = "Texas", Cuisine = CuisineType.Italian},
                new Restaurant() {Id = 2, Name = "A Tacos", Location = "California", Cuisine = CuisineType.Mexican},
                new Restaurant() {Id = 3, Name = "Fifth Element", Location = "Florida", Cuisine = CuisineType.Indian},
                new Restaurant() {Id = 4, Name = "Amrit Palace", Location = "Texas", Cuisine = CuisineType.Indian},
                new Restaurant() {Id = 5, Name = "Chopstix Bistro", Location = "Florida", Cuisine = CuisineType.Chinese},
                new Restaurant() {Id = 6, Name = "Bangkok Square", Location = "New York", Cuisine = CuisineType.Thai},
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }
    }
}