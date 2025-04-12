namespace MyCookBookApi.Models{
    public class RecipeMedia
    {
        public required string Url { get; set; } // Firebase Storage URL
        public required string Type { get; set; } // "image" or "video"
        public required int Order { get; set; } // Display order
    }
}