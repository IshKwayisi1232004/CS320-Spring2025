namespace MyCookBookApi.Models{
    public class RecipeSearchRequest{
        public required string Keyword { get; set; }
        public List<CategoryType> Categories { get; set; } = new List<CategoryType>();
    }
}