using RulesEnginePoCRockScissors.Enums;
using RulesEnginePoCRockScissors.Rules;
using System.Reflection;


namespace RulesEnginePoCRockScissors.RulesFactory
{
    public static class RulesFactory
    {
        public static IEnumerable<RSPRule>GetRules(GameMode gameMode)
        {
            // Use reflection to find all subclasses of Rule
            var ruleType = typeof(RSPRule);
            var ruleTypes = Assembly.GetExecutingAssembly()
                                    .GetTypes()
                                    .Where(t => t.IsSubclassOf(ruleType) && !t.IsAbstract);
            //TODO More robust error handling is needed
            //
            // check for classes which lack a parameterless constructor and either
            // exclude or throw exception as appropriate.
            //
            foreach (var type in ruleTypes)
            {
                if (Activator.CreateInstance(type) is RSPRule rule && rule.Applicable(gameMode))
                {
                    // use yield return to get the next
                    yield return rule;
                }
            }
        }
    }
}
