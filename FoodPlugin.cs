using System.ComponentModel;
using System.Text.Json.Serialization;
using Microsoft.SemanticKernel;

namespace fridgeEcosystem
{
    //We will define the get/put/delete functions for our fridge here
    public class FoodsPlugin
    {
        private readonly List<FoodModel> foods = [];

        [KernelFunction("get_food")]
        [Description("Seeing whats in the fridge")]
        public async Task<List<FoodModel>> GetFoodAsync()
        {
            await Task.CompletedTask;
            return foods;
        }

        [KernelFunction("add_food")]
        [Description("Add a food to the fridge")]
        public async Task<FoodModel> AddFoodAsync(int id, string name, int qty)
        {
            await Task.CompletedTask;

            var food = foods.FirstOrDefault(f => f.Id == id);

            if (food != null)
            {
                food.Qty += qty;
            }
            else
            {
                food = new FoodModel { Id = id, Name = name, Qty = qty };
                foods.Add(food);
            }
            return food;
        }

        [KernelFunction("eat_food")]
        [Description("Eating a food from fridge")]
        public async Task<FoodModel?> EatFoodAsync(int id, int qty)
        {
            await Task.CompletedTask;
            var food = foods.FirstOrDefault(f => f.Id == id);

            if (food == null)
            {
                return null;
            }

            // Prevent our food from getting below 0
            food.Qty = Math.Max(0, food.Qty - qty);

            return food;
        }
    }

    public class FoodModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("qty")]
        public int Qty { get; set; }
    }
}