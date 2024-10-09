using BusinessLogic.Data;
using BusinessLogic.Services;

namespace BusinessLogic.Test
{
    [TestClass]
    public class RecipeServiceTest
    {
        [TestMethod]
        public void LoadFromJsonFile_ReturnsListOfRecipes()
        {
            var result = RecipeReader.FromJsonFile();

            // Assert
            Assert.IsNotNull(result, "Die Liste mit Rezepten sollte nicht null sein.");
            Assert.IsTrue(result.Any(), "Die Liste sollte mindestens ein Rezept enthalten.");
            Assert.IsTrue(result[0].MealType.Length > 0, "Das Rezept sollte eine MealType besitzen.");
        }

        [TestMethod]
        public async Task LoadFromDatabase_ReturnsListOfRecipes()
        {
            // Arrange
            using var context = new TestDatabase().Context;
            var service = new RecipeService(context);

            // Act
            var result = await service.GetAllRecipes(1);

            // Assert
            Assert.IsNotNull(result, "Die Liste mit Rezepten sollte nicht null sein.");
            Assert.IsTrue(result.Any(), "Die Liste sollte mindestens ein Rezept enthalten.");
            Assert.IsTrue(result[0].MealType.Length > 0, "Das Rezept sollte eine MealType besitzen.");
        }
    }
}