using System.Text.Json.Serialization;

using MyCookBookApp.Models;
using MyCookBookApp.Services;

namespace MyCookBookApp.Models{
    public class Recipe{
        public required string RecipeId { get; set; } // Auto-generated unique ID
        public required string Name{get; set;}
        public required string TagLine { get; set; }
        public required string Summary { get; set; }
        public required List<string> Instructions { get; set; } = new List<string>();
        public required List<string> Ingredients { get; set; } = new List<string>();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<CategoryType>? Categories { get; set; } = new List<CategoryType>();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<RecipeMedia>? Media { get; set; } = new List<RecipeMedia>();
        public Recipe() {}
    }
}