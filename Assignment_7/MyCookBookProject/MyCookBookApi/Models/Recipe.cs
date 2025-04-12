using Google.Cloud.Firestore;
using System.Text.Json.Serialization;

using MyCookBookApi.Models;
using MyCookBookApi.Services;

namespace MyCookBookApi.Models{

    [FirestoreData] // 🔥 Marks the class as Firestore-compatible
    public class Recipe{
        [FirestoreProperty] public string RecipeId { get; set; } // Auto-generated unique ID
        [FirestoreProperty] public string Name{get; set;}
        [FirestoreProperty] public string TagLine { get; set; }
        [FirestoreProperty] public string Summary { get; set; }
        [FirestoreProperty] public List<string> Instructions { get; set; } = new List<string>();
        [FirestoreProperty] public List<string> Ingredients { get; set; } = new List<string>();

        [FirestoreProperty(ConverterType = typeof(CategoryTypeConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<CategoryType>? Categories { get; set; } = new List<CategoryType>();

        [FirestoreProperty(ConverterType = typeof(RecipeMediaConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<RecipeMedia>? Media { get; set; } = new List<RecipeMedia>();

        //public bool IsValid()
        public Recipe() {}
    }
}