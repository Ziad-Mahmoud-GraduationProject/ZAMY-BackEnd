﻿namespace ZAMY.Api.Dtos.meals
{
    public class CreateMealDTO
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public double Rating { get; set; }
        public DateTime PreparationTime { get; set; }
        public string Ingredients { get; set; } = string.Empty;
        public int KitchenId { get; set; }
        public int MainCategoryId { get; set; }
        public int SubCategoryId { get; set; }
    }
}
