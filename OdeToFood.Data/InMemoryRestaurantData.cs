using System;
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
                new Restaurant() {Id = 2, Name = "Amazing Tacos", Location = "California", Cuisine = CuisineType.Mexican},
                new Restaurant() {Id = 3, Name = "Fifth Element", Location = "Florida", Cuisine = CuisineType.Indian},
                new Restaurant() {Id = 4, Name = "Amrit Palace", Location = "Texas", Cuisine = CuisineType.Indian},
                new Restaurant() {Id = 5, Name = "Chopstix Bistro", Location = "Florida", Cuisine = CuisineType.Chinese},
                new Restaurant() {Id = 6, Name = "Bangkok Square", Location = "New York", Cuisine = CuisineType.Thai},
                new Restaurant() {Id = 6, Name = "Olive Garden", Location = "New York", Cuisine = CuisineType.Italian},
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

    }
}