using BusinessLogic.Data;
using BusinessLogic.Models.Enums;
using BusinessLogic.Services;

namespace BusinessLogic.Test
{
    [TestClass]
    public class OrderServiceTest
    {
        const string USER_NAME = "Tessa Tester";

        private readonly TestDatabase _db = new TestDatabase();
        private FoodDeliveryDbContext _context;

        [TestInitialize]
        public void Initialize()
        {
            _context = _db.Context;
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await _context.DisposeAsync();
        }

        [TestMethod]
        public async Task CurrentOrder_EnsureOrderExists()
        {
            // Arrange
            var orderService = new OrderService(_context);

            // Act
            var result = await orderService.CurrentOrder(USER_NAME);

            // Assert
            Assert.AreEqual(USER_NAME, result.UserName);
            Assert.AreEqual(OrderStatus.Pending, result.Status);
        }

        [TestMethod]
        public async Task AddSingleOrder_CreatesItem()
        {
            // Arrange
            var recipeService = new RecipeService(_context);
            var orderService = new OrderService(_context);

            // Act
            var recipe = await recipeService.GetRecipeById(1);
            await orderService.UpdateOrder(USER_NAME,  recipe, 3);

            var result = await orderService.CurrentOrder(USER_NAME);
            var item = result.OrderItems.SingleOrDefault();

            // Assert
            Assert.AreEqual(USER_NAME, result.UserName);
            Assert.AreEqual(OrderStatus.Pending, result.Status);
            Assert.IsNotNull(item, "Expected single order item");
            Assert.AreEqual(3, item.Quantity);
            Assert.AreEqual(recipe.Name, item.Recipe.Name);
        }

        [TestMethod]
        public async Task FinishOrder_SetsStatusDone()
        {
            // Arrange
            var orderService = new OrderService(_context);
            var result = await orderService.CurrentOrder(USER_NAME);

            // Act
            var done = await orderService.FinishOrder(USER_NAME, 5);

            // Assert
            Assert.IsTrue(done, "Expected order to be marked as done");

        }
    }
}