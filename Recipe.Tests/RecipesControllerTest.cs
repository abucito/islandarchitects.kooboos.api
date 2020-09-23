using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Recipe.API;
using Recipe.API.Models;

namespace Recipe.Tests
{
    [TestFixture]
    public class RecipesControllerTest
    {
        private Mock<IRecipesService> recipesServiceMock;

        private RecipesController recipesController;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void EverythingSetupCorrectly()
        {
            // Arrange
            recipesServiceMock = new Mock<IRecipesService>();
            recipesController = new RecipesController(recipesServiceMock.Object);

            // Act
            var result = recipesController.Test();

            // Assert
            Assert.IsTrue(result.GetType() == typeof(OkResult));
        }

        [Test]
        public void GetRecipes_Empty_ReturnsOk()
        {
            // Arrange
            recipesServiceMock = new Mock<IRecipesService>();
            recipesServiceMock
                .Setup(m => m.GetRecipes())
                .Returns(new List<RecipeDto>());

            recipesController = new RecipesController(recipesServiceMock.Object);

            // Act
            var result = recipesController.GetRecipies();

            // Assert
            Assert.IsTrue(result.GetType() == typeof(OkObjectResult));
        }

        [Test]
        public void GetRecipe_ValidId_ReturnsOk()
        {
            // Arrange
            int validRecipeId = 1;
            recipesServiceMock = new Mock<IRecipesService>();
            recipesServiceMock
                .Setup(m => m.GetRecipe(validRecipeId))
                .Returns(new RecipeDto());

            recipesController = new RecipesController(recipesServiceMock.Object);

            // Act
            var result = recipesController.GetRecipe(validRecipeId);

            // Assert
            Assert.IsTrue(result.GetType() == typeof(OkObjectResult));
        }

        [Test]
        public void GetRecipe_InvalidId_ReturnNotFound()
        {
            // Arrange
            int invalidRecipeId = 2;
            recipesServiceMock = new Mock<IRecipesService>();
            recipesServiceMock
                .Setup(m => m.GetRecipe(invalidRecipeId))
                .Returns(null as RecipeDto);

            recipesController = new RecipesController(recipesServiceMock.Object);

            // Act
            var result = recipesController.GetRecipe(invalidRecipeId);

            // Assert
            Assert.IsTrue(result.GetType() == typeof(NotFoundResult));
        }
    }
}