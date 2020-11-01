using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Kooboos.API.AutomapperProfiles;
using Kooboos.API.Models;
using Kooboos.API.IngredientsLists;

namespace Kooboos.Tests
{
    [TestFixture]
    public class IngredientsListControllerTest
    {
        private IngredientsListController ingredientsListController;

        private Mock<IIngredientsListService> ingredientsListServiceMock;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var mapperConfiguration = new MapperConfiguration(c => c.AddProfile<IngredientsListProfile>());
        }

        [Test]
        public void GetIngredientsList_ValidRecipeId_ReturnsOk()
        {
            // Arrange
            int validRecipeId = 1;
            ingredientsListServiceMock = new Mock<IIngredientsListService>();
            ingredientsListServiceMock
                .Setup(m => m.GetByRecipeId(validRecipeId))
                .Returns(new IngredientsListDto());
            ingredientsListController = new IngredientsListController(ingredientsListServiceMock.Object);

            // Act
            var result = ingredientsListController.GetIngredientsList(validRecipeId);

            // Assert
            Assert.IsTrue(result.GetType() == typeof(OkObjectResult));
        }

        [Test]
        public void GetIngredientsList_InvalidRecipeId_ReturnsNotFound()
        {
            // Arrange
            int invalidRecipeId = 1;
            ingredientsListServiceMock = new Mock<IIngredientsListService>();
            ingredientsListServiceMock
                .Setup(m => m.GetByRecipeId(invalidRecipeId))
                .Returns(null as IngredientsListDto);
            ingredientsListController = new IngredientsListController(ingredientsListServiceMock.Object);

            // Act
            var result = ingredientsListController.GetIngredientsList(invalidRecipeId);

            // Assert
            Assert.IsTrue(result.GetType() == typeof(NotFoundResult));
        }


        [Test]
        public void AddIngredientsListItem_WithValidationError_ReturnsBadRequestResult()
        {
            // Arrange
            ingredientsListServiceMock = new Mock<IIngredientsListService>();
            ingredientsListController = new IngredientsListController(ingredientsListServiceMock.Object);
            ingredientsListController.ModelState.AddModelError("Some Key", "Some Error Message");
            int validRecipeId = 1;

            // Act
            var result = ingredientsListController.AddIngredientsListItem(validRecipeId, new IngredientsListItemForCreationDto());

            // Assert
            Assert.IsTrue(result.GetType() == typeof(BadRequestObjectResult));
        }

        [Test]
        public void AddIngredientsListItem_InvalidUnitId_ReturnsBadRequestResult()
        {
            // Arrange
            int validRecipeId = 1;
            int invalidUnitId = 5;
            ingredientsListServiceMock = new Mock<IIngredientsListService>();
            ingredientsListServiceMock
                .Setup(m => m.UnitExists(invalidUnitId))
                .Returns(false);
            ingredientsListController = new IngredientsListController(ingredientsListServiceMock.Object);

            // Act
            var result = ingredientsListController.AddIngredientsListItem(validRecipeId, new IngredientsListItemForCreationDto() { UnitId = invalidUnitId });

            // Assert
            Assert.IsTrue(result.GetType() == typeof(BadRequestObjectResult));
        }

        [Test]
        public void AddIngredientsListItem_InvalidIngredientId_ReturnsBadRequestResult()
        {
            // Arrange
            int validRecipeId = 1;
            int invalidIngredientId = 5;
            ingredientsListServiceMock = new Mock<IIngredientsListService>();
            ingredientsListServiceMock
                .Setup(m => m.IngredientExists(invalidIngredientId))
                .Returns(false);
            ingredientsListController = new IngredientsListController(ingredientsListServiceMock.Object);

            // Act
            var result = ingredientsListController.AddIngredientsListItem(validRecipeId, new IngredientsListItemForCreationDto() { IngredientId = invalidIngredientId });

            // Assert
            Assert.IsTrue(result.GetType() == typeof(BadRequestObjectResult));
        }

        [Test]
        public void AddIngredientsListItem_ValidInput_ReturnsCreatedResult()
        {
            // Arrange
            int validRecipeId = 1;
            ingredientsListServiceMock = new Mock<IIngredientsListService>();
            ingredientsListServiceMock
                .Setup(m => m.RecipeExists(validRecipeId))
                .Returns(true);
            ingredientsListServiceMock
                .Setup(m => m.UnitExists(It.IsAny<int>()))
                .Returns(true);
            ingredientsListServiceMock
                .Setup(m => m.IngredientExists(It.IsAny<int>()))
                .Returns(true);
            ingredientsListServiceMock
                .Setup(m => m.InsertIngredientsListItem(validRecipeId, It.IsAny<IngredientsListItemForCreationDto>()))
                .Returns(1);
            ingredientsListController = new IngredientsListController(ingredientsListServiceMock.Object);

            // Act
            var result = ingredientsListController.AddIngredientsListItem(validRecipeId, new IngredientsListItemForCreationDto());

            // Assert
            Assert.IsTrue(result.GetType() == typeof(CreatedAtRouteResult));
        }

        [Test]
        public void AddIngredientsListItem_InvalidRecipeId_ReturnsNotFoundResult()
        {
            // Arrange
            int invalidRecipeId = 2;
            ingredientsListServiceMock = new Mock<IIngredientsListService>();
            ingredientsListServiceMock
                .Setup(m => m.RecipeExists(invalidRecipeId))
                .Returns(false);
            ingredientsListServiceMock
                .Setup(m => m.UnitExists(It.IsAny<int>()))
                .Returns(true);
            ingredientsListServiceMock
                .Setup(m => m.IngredientExists(It.IsAny<int>()))
                .Returns(true);
            ingredientsListController = new IngredientsListController(ingredientsListServiceMock.Object);

            // Act
            var result = ingredientsListController.AddIngredientsListItem(invalidRecipeId, new IngredientsListItemForCreationDto());

            // Assert
            Assert.IsTrue(result.GetType() == typeof(NotFoundResult));
        }

        [Test]
        public void DeleteIngredient_ValidId_ReturnsNoContent()
        {
            // Arrange
            int recipeId = 1;
            int validIngredientsListItemId = 1;
            ingredientsListServiceMock = new Mock<IIngredientsListService>();
            ingredientsListServiceMock
                .Setup(m => m.IngredientsListItemExists(validIngredientsListItemId))
                .Returns(true);

            ingredientsListController = new IngredientsListController(ingredientsListServiceMock.Object);

            // Act
            var result = ingredientsListController.DeleteIngredientsListItem(recipeId, validIngredientsListItemId);

            // Assert
            Assert.IsTrue(result.GetType() == typeof(NoContentResult));
        }

        [Test]
        public void DeleteIngredient_InvalidId_ReturnsNotFound()
        {
            // Arrange
            int recipeId = 1;
            int invalidIngredientsListItemId = 2;
            ingredientsListServiceMock = new Mock<IIngredientsListService>();
            ingredientsListServiceMock
                .Setup(m => m.IngredientsListItemExists(invalidIngredientsListItemId))
                .Returns(false);

            ingredientsListController = new IngredientsListController(ingredientsListServiceMock.Object);

            // Act
            var result = ingredientsListController.DeleteIngredientsListItem(recipeId, invalidIngredientsListItemId);

            // Assert
            Assert.IsTrue(result.GetType() == typeof(NotFoundResult));
        }
    }
}