using System.ComponentModel;
using System.Text.Json.Serialization;
using Microsoft.SemanticKernel;

namespace fridgeEcosystem
{
    //We will define the get/put/delete functions for our fridge here
    public class FoodsPlugin
    {
        private readonly Dictionary<string,Queue<int>> foods = [];
        //Keep track of food first in first out => queue structure

        [KernelFunction("get_food")]
        [Description("Seeing whats in the fridge")]
        public async Task<Dictionary<string, Queue<int>>> GetFoodAsync()
        {
            await Task.CompletedTask;
            return foods;
        }

        [KernelFunction("add_food")]
        [Description("Add a food to the fridge")]
        public async Task<bool> AddFoodAsync(string name, int id)
        {
            await Task.CompletedTask;

            if (foods.ContainsKey(name))
            {
                foods[name].Enqueue(id);
            }
            else
            {
                foods[name] = new Queue<int>(id);
            }
            return true;
        }

        [KernelFunction("remove_food")]
        [Description("Removing a food from fridge")]
        public async Task<bool> RemoveFoodAsync(string name)
        {
            await Task.CompletedTask;

            if (foods.TryGetValue(name, out Queue<int>? val))
            {
                // Prevent our food from getting below 0
                int id = val.Dequeue();
                return true;
            }

            return false;
        }
    }
}