using RulesEnginePoCRockScissors.Enums;
using RulesEnginePoCRockScissors.RulesFactory;

namespace TestProject
{
  

    [TestFixture]
    public class RSPRuleTests
    {
        // Define test cases as a static property or method.
        private static IEnumerable<TestCaseData> GameModeTestCases
        {
            get
            {
                yield return new TestCaseData(GameMode.Classic, 3).SetName("DiscoverRules_ClassicGameMode_Returns3");
                yield return new TestCaseData(GameMode.LizardSpockVariant, 7).SetName("DiscoverRules_LizardSpockVariantGameMode_Returns6");
            }
        }

        [TestCaseSource("GameModeTestCases")]
        public void DiscoverRules_ShouldReturnCorrectCount(GameMode gameMode, int expectedCount)
        {
            // Act
            var result = RulesFactory.GetRules(gameMode);

            // Assert
            Assert.AreEqual(expectedCount, result.Count(), $"DiscoverRules did not return the expected count for {gameMode} game mode.");
        }
    }

}