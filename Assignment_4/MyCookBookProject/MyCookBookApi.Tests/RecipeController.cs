using Microsoft.AspNetCore.Mvc;
using MyCookBookApi.Controllers;
using MyCookBookApi.Models;
using MyCookBookApi.Services;
//using MyCookBookApi.Controllers;
using Xunit;
using Moq;
using System.Collections.Generic;
public class RecipeControllerTests
{
    private readonly RecipeController _controller;
    private readonly Mock<IRecipeService> _mockService;
    public RecipeControllerTests()
    {
        _mockService = new Mock<IRecipeService>();
        _controller = new RecipeController(_mockService.Object);
    }
    [Fact]
    public void GetAllRecipes_ReturnsOkResult()
    {
        // Arrange
        var fakeRecipes = new List<Recipe> { new Recipe { RecipeId = "1",
        Name = "Test Recipe" } };
        _mockService.Setup(s => s.GetAllRecipes()).Returns(fakeRecipes);
        // Act
        var result = _controller.GetAllRecipes();
        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedRecipes =
        Assert.IsType<List<Recipe>>(actionResult.Value);
        Assert.Single(returnedRecipes);
    }
    [Fact]
    public void GetRecipeById_WhenRecipeExists_ReturnsOk()
    {
        // Arrange
        var fakeRecipe = new Recipe { RecipeId = "123", Name = "Pasta" };
        _mockService.Setup(s => s.GetRecipeById("123")).Returns(fakeRecipe);
        // Act
        var result = _controller.GetRecipeById("123");
        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedRecipe = Assert.IsType<Recipe>(actionResult.Value);
        Assert.Equal("123", returnedRecipe.RecipeId);
    }
    [Fact]
    public void GetRecipeById_WhenRecipeDoesNotExist_ReturnsNotFound()
    {
        // Arrange
        _mockService.Setup(s =>
        s.GetRecipeById("999")).Returns((Recipe)null);
        // Act
        var result = _controller.GetRecipeById("999");
        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
}