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

        private IMapper mapper;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var mapperConfiguration = new MapperConfiguration(c => c.AddProfile<IngredientsListProfile>());
            mapper = mapperConfiguration.CreateMapper();
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
            ingredientsListController = new IngredientsListController(ingredientsListServiceMock.Object, mapper);

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
            ingredientsListController = new IngredientsListController(ingredientsListServiceMock.Object, mapper);

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
            ingredientsListController = new IngredientsListController(ingredientsListServiceMock.Object, mapper);
            ingredientsListController.ModelState.AddModelError("Some Key", "Some Error Message");
            int validRecipeId = 1;

            // Act
            var result = ingredientsListController.AddIngredientsListItem(validRecipeId, new IngredientsListItemForCreationDto());

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
                .Setup(m => m.GetByRecipeId(validRecipeId))
                .Returns(new IngredientsListDto());
            ingredientsListServiceMock
                .Setup(m => m.InsertIngredientsListItem(validRecipeId, It.IsAny<IngredientsListItemDto>()))
                .Returns(1);
            ingredientsListController = new IngredientsListController(ingredientsListServiceMock.Object, mapper);

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
                .Setup(m => m.GetByRecipeId(invalidRecipeId))
                .Returns(null as IngredientsListDto);
            ingredientsListController = new IngredientsListController(ingredientsListServiceMock.Object, mapper);

            // Act
            var result = ingredientsListController.AddIngredientsListItem(invalidRecipeId, new IngredientsListItemForCreationDto());

            // Assert
            Assert.IsTrue(result.GetType() == typeof(NotFoundResult));
        }
    }
}