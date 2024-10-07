using BusinessLogic.Data;

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
    }
}