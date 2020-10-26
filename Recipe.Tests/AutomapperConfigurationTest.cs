using AutoMapper;
using NUnit.Framework;
using Recipe.API.AutomapperProfiles;
using Recipe.API.Models;

namespace Recipe.Tests
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
    }
}