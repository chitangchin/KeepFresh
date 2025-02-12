using System.ComponentModel;
using System.Text.Json.Serialization;
using Microsoft.SemanticKernel;

public class FoodsPlugin
{
    private readonly List<FoodModel> foods = 
    [
        new FoodModel { Id = 1, Name = "Banana", Qty = 10 },
        new FoodModel { Id = 2, Name = "Apple", Qty = 12},
        new FoodModel { Id = 3, Name = "Strawberry", Qty = 5}
    ];
    
    [KernelFunction("get_food")]
    [Description("Seeing whats in the fridge")]
    public async Task<List<FoodModel>> GetFoodAsync()
    {
        await Task.CompletedTask;
        return foods;
    }

    [KernelFunction("eat_food")]
    [Description("Eating a food from fridge")]
    public async Task<FoodModel?> EatFoodAsync(int id, int qty)
    {
        await Task.CompletedTask;
        var food = foods.FirstOrDefault(food => food.Id == id);
        if (food == null)
        {
            return null;
        }
        food.Qty = qty - 1;
        return food;
    }
}

public class FoodModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("is_on")]
    public int Qty { get; set; }
}