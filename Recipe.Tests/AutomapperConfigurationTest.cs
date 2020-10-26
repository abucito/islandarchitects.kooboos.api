using System.Linq;
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
        public void Automapper_IngredientProfile_HasNoUnmappedProperties()
        {
            var configuration = new MapperConfiguration(
                c => c.AddProfile<IngredientProfile>()
            );

            var mapper = configuration.CreateMapper();
            var unmappedPropertyNames = mapper.ConfigurationProvider.GetAllTypeMaps().SelectMany(m => m.GetUnmappedPropertyNames());

            Assert.AreEqual(0, unmappedPropertyNames.Count(), $"There are {unmappedPropertyNames.Count()} unmapped properties in {typeof(IngredientProfile).Name}");
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
        public void Automapper_RecipeProfile_HasNoUnmappedProperties()
        {
            var configuration = new MapperConfiguration(
                c => c.AddProfile<RecipeProfile>()
            );

            var mapper = configuration.CreateMapper();
            var unmappedPropertyNames = mapper.ConfigurationProvider.GetAllTypeMaps().SelectMany(m => m.GetUnmappedPropertyNames());

            Assert.AreEqual(0, unmappedPropertyNames.Count(), $"There are {unmappedPropertyNames.Count()} unmapped properties");
        }
    }
}