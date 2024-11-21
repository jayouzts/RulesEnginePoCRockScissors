using RulesEnginePoCRockScissors.Rules;

namespace RulesEnginePoCRockScissors.RulesEngine
{
    public class RulesEngine
    {
        private readonly List<RSPRule> _rules;
        public RulesEngine(IEnumerable<RSPRule> rules)
        {
            _rules = rules.ToList();
        }

        public string Evaluate(string player1Choice, string player2Choice)
        {
            // TODO needs exception in the even more than one winner is found
            var rule = _rules.FirstOrDefault(r => r.Applies(player1Choice, player2Choice));
            if (rule != null)
                return $"Player 1 wins! {rule.Winner} {rule.Action} {rule.Loser}.";

            rule = _rules.FirstOrDefault(r => r.Applies(player2Choice, player1Choice));
            if (rule != null)
                return $"Player 2 wins! {rule.Winner} {rule.Action} {rule.Loser}.";

            return "It's a tie!";
        }

     
    }
}
