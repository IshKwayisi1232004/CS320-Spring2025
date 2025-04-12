using System.ComponentModel.DataAnnotations;

public class RecipeAnnotated
{
    [Required(ErrorMessage = "Name is required.")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters.")]
    [MaxLength(30, ErrorMessage = "Name must be at most 30 characters.")]
    [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Name can only contain letters, numbers, and spaces.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Summary is required.")]
    [MaxLength(100, ErrorMessage = "Summary cannot exceed 100 characters.")]
    public string Summary { get; set; }
    // etc...
}