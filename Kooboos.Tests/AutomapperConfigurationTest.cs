using AutoMapper;
using NUnit.Framework;
using Kooboos.API.Units.AutomapperProfile;
using Kooboos.API.Ingredients.AutomapperProfile;
using Kooboos.API.IngredientsLists.AutomapperProfile;
using Kooboos.API.Recipes.AutomapperProfile;

namespace Kooboos.Tests
{
    [TestFixture]
    public class AutomapperConfigurationTest
    {
        [Test]
        public void Automapper_IngredientProfile_IsValid()
        {
            var configuration = new MapperConfiguration(
                c => c.AddProfile<IngredientProfile>()
            );

            configuration.AssertConfigurationIsValid();
        }

        [Test]
        public void Automapper_RecipeProfile_IsValid()
        {
            var configuration = new MapperConfiguration(
                c => c.AddProfile<RecipeProfile>()
            );

            configuration.AssertConfigurationIsValid();
        }

        [Test]
        public void Automapper_UnitProfile_IsValid()
        {
            var configuration = new MapperConfiguration(
                c => c.AddProfile<UnitProfile>()
            );

            configuration.AssertConfigurationIsValid();
        }

        [Test]
        public void Automapper_IngredientsListProfile_IsValid()
        {
            var configuration = new MapperConfiguration(
                c => c.AddProfile<IngredientsListProfile>()
            );

            configuration.AssertConfigurationIsValid();
        }
    }
}