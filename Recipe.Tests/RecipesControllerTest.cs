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
                .Setup(m => m.GetRecipies())
                .Returns(new List<RecipeDTO>());

            recipesController = new RecipesController(recipesServiceMock.Object);

            // Act
            var result = recipesController.GetRecipies();

            // Assert
            Assert.IsTrue(result.GetType() == typeof(OkObjectResult));
        }
    }
}