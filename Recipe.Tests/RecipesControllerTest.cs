using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
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
        public void GetRecipes_Empty_ReturnsOk()
        {
            // Arrange
            recipesServiceMock = new Mock<IRecipesService>();
            recipesServiceMock
                .Setup(m => m.GetRecipes())
                .Returns(new List<RecipeDto>());

            recipesController = new RecipesController(recipesServiceMock.Object);

            // Act
            var result = recipesController.GetRecipes();

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
        public void GetRecipe_InvalidId_ReturnsNotFound()
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

        [Test]
        public void CreateRecipe_WithValidationError_ReturnsBadRequestResult()
        {
            // Arrange
            recipesServiceMock = new Mock<IRecipesService>();
            recipesController = new RecipesController(recipesServiceMock.Object);
            recipesController.ModelState.AddModelError("Some Key", "Some Error Message");

            // Act
            var result = recipesController.CreateRecipe(new RecipeForCreationDto());

            // Assert
            Assert.IsTrue(result.GetType() == typeof(BadRequestObjectResult));
        }

        [Test]
        public void CreateRecipe_WithTitleAndInstructions_ReturnsCreatedResult()
        {
            // Arrange
            recipesServiceMock = new Mock<IRecipesService>();
            recipesServiceMock
                .Setup(m => m.InsertRecipe(It.IsAny<RecipeDto>()))
                .Returns(1);
            recipesController = new RecipesController(recipesServiceMock.Object);

            var recipeForCreation = new RecipeForCreationDto
            {
                Title = "Cooking is fun",
                Instruction = "You should cook the meal"
            };

            // Act
            var result = recipesController.CreateRecipe(recipeForCreation);

            // Assert
            Assert.IsTrue(result.GetType() == typeof(CreatedAtRouteResult));
        }

        [Test]
        public void CreateRecipe_SomethinWentWrongWhileInserting_Returns500InternalServerError()
        {
            // Arrange
            recipesServiceMock = new Mock<IRecipesService>();
            recipesServiceMock
                .Setup(m => m.InsertRecipe(It.IsAny<RecipeDto>()))
                .Returns(0);
            recipesController = new RecipesController(recipesServiceMock.Object);

            var recipeForCreation = new RecipeForCreationDto
            {
                Title = "Cooking is fun",
                Instruction = "You should cook the meal"
            };

            // Act
            var result = recipesController.CreateRecipe(recipeForCreation);

            // Assert
            Assert.IsTrue(result.GetType() == typeof(StatusCodeResult));
            Assert.IsTrue(((StatusCodeResult)result).StatusCode == StatusCodes.Status500InternalServerError);
        }

        [Test]
        public void DeleteRecipe_ValidRecipeId_ReturnsNoContent()
        {
            // Arrange
            int validRecipeId = 1;
            recipesServiceMock = new Mock<IRecipesService>();
            recipesServiceMock
                .Setup(m => m.GetRecipe(validRecipeId))
                .Returns(new RecipeDto());

            recipesController = new RecipesController(recipesServiceMock.Object);

            // Act
            var result = recipesController.DeleteRecipe(validRecipeId);

            // Assert
            Assert.IsTrue(result.GetType() == typeof(NoContentResult));
        }

        [Test]
        public void DeleteRecipe_InvalidRecipeId_ReturnsNotFound()
        {
            // Arrange
            int invalidRecipeId = 2;
            recipesServiceMock = new Mock<IRecipesService>();
            recipesServiceMock
                .Setup(m => m.GetRecipe(invalidRecipeId))
                .Returns(null as RecipeDto);

            recipesController = new RecipesController(recipesServiceMock.Object);

            // Act
            var result = recipesController.DeleteRecipe(invalidRecipeId);

            // Assert
            Assert.IsTrue(result.GetType() == typeof(NotFoundResult));
        }

        [Test]
        public void FullyUpdateRecipe_ValidRecipeIdAndValidData_ReturnsNoContent()
        {
            // Arrange
            int validRecipeId = 1;
            var recipeForUpdateDto = new RecipeForUpdateDto();
            recipesServiceMock = new Mock<IRecipesService>();
            recipesServiceMock
                .Setup(m => m.GetRecipe(validRecipeId))
                .Returns(new RecipeDto());
            recipesController = new RecipesController(recipesServiceMock.Object);

            // Act
            var result = recipesController.FullyUpdateRecipe(validRecipeId, recipeForUpdateDto);

            // Assert
            Assert.IsTrue(result.GetType() == typeof(NoContentResult));
        }

        [Test]
        public void FullyUpdateRecipe_ValidRecipeIdAndInvalidData_ReturnsBadRequest()
        {
            // Arrange
            int validRecipeId = 1;
            var recipeForUpdateDto = new RecipeForUpdateDto();
            recipesServiceMock = new Mock<IRecipesService>();
            recipesServiceMock
                .Setup(m => m.GetRecipe(validRecipeId))
                .Returns(new RecipeDto());
            recipesController = new RecipesController(recipesServiceMock.Object);
            recipesController.ModelState.AddModelError("Some Key", "Some Error Message");

            // Act
            var result = recipesController.FullyUpdateRecipe(validRecipeId, recipeForUpdateDto);

            // Assert
            Assert.IsTrue(result.GetType() == typeof(BadRequestObjectResult));
        }

        [Test]
        public void FullyUpdateRecipe_InvalidRecipeId_ReturnsNotFound()
        {
            // Arrange
            int invalidRecipeId = 2;
            var recipeForUpdateDto = new RecipeForUpdateDto();
            recipesServiceMock = new Mock<IRecipesService>();
            recipesServiceMock
                .Setup(m => m.GetRecipe(invalidRecipeId))
                .Returns(null as RecipeDto);
            recipesController = new RecipesController(recipesServiceMock.Object);

            // Act
            var result = recipesController.FullyUpdateRecipe(invalidRecipeId, recipeForUpdateDto);

            // Assert
            Assert.IsTrue(result.GetType() == typeof(NotFoundResult));
        }
    }
}