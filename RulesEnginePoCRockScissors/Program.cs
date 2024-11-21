using RulesEnginePoCRockScissors.Enums;
using RulesEnginePoCRockScissors.RulesEngine;
using RulesEnginePoCRockScissors.RulesFactory;

// inspired by the Big Bang theory https://bigbangtheory.fandom.com/wiki/Rock,_Paper,_Scissors,_Lizard,_Spock
// uses the Rules pattern to implement instead of nested Switch/If statements.  See https://www.michael-whelan.net/rules-design-pattern/
class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Rock, Scissors, Paper, Lizard, Spock!");

        do
        {
            Console.WriteLine("Do you want to play classic Rock, Scissors, Paper (type '1') or the Lizard-Spock variant (type '2')?");

            if (!Enum.TryParse(Console.ReadLine()?.Trim(), out GameMode gameMode))
            {
                Console.WriteLine("Invalid input. Defaulting to classic mode.");
                gameMode = GameMode.Classic;
            }
           //uses reflection to determine which rules apply based on game mode
            var allRules = RulesFactory.GetRules(gameMode);

            // Create the rules engine with only applicable rules
            var engine = new RulesEngine(allRules);

            //TODO add validation of the player choices
            Console.WriteLine("Enter Player 1 choice:");
            var player1Choice = Console.ReadLine();
            Console.WriteLine("Enter Player 2 choice:");
            var player2Choice = Console.ReadLine();

            var result = engine.Evaluate(player1Choice, player2Choice);
            Console.WriteLine(result);

            Console.WriteLine("Do you want to play again? (y/n)");
        } while (Console.ReadLine()?.Trim().ToLower() == "y");

        Console.WriteLine("Thanks for playing!");
    }
}
