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
                new Restaurant() {Id = 1, Name = "Vishal's Pizza", Location = "Texas", Cuisine = CuisineType.Italian},
                new Restaurant() {Id = 2, Name = "Aparna's Tacos", Location = "California", Cuisine = CuisineType.Mexican},
                new Restaurant() {Id = 3, Name = "Kavya's Dhaba", Location = "Florida", Cuisine = CuisineType.Indian},
                new Restaurant() {Id = 4, Name = "Sid's Cafe", Location = "Texas", Cuisine = CuisineType.None},
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                orderby r.Name
                select r;
        }
    }
}