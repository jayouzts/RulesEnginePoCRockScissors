using RulesEnginePoCRockScissors.Enums;

namespace RulesEnginePoCRockScissors.Rules
{
    // Base class for a rule
    public abstract class RSPRule
    {
        public abstract string Winner { get; }
        public abstract string Loser { get; }
        public abstract string Action { get; }
        public abstract GameMode ApplicableModes { get; }

        public bool Applicable(GameMode currentGameMode) => (ApplicableModes & currentGameMode) != 0;

        public bool Applies(string player1Choice, string player2Choice) =>
            Winner.Trim().ToLower() == player1Choice.Trim().ToLower() && Loser.Trim().ToLower() == player2Choice.Trim().ToLower();
        
    }

    // Classic Rules
    public class RockCrushesScissors : RSPRule
    {
        public override string Winner => "Rock";
        public override string Loser => "Scissors";
        public override string Action => "crushes";
        public override GameMode ApplicableModes => GameMode.Classic | GameMode.LizardSpockVariant; // Both modes
    }

    public class ScissorsCutPaper : RSPRule
    {
        public override string Winner => "Scissors";
        public override string Loser => "Paper";
        public override string Action => "cut";
        public override GameMode ApplicableModes => GameMode.Classic | GameMode.LizardSpockVariant; // Both modes
    }

    public class PaperCoversRock : RSPRule
    {
        public override string Winner => "Paper";
        public override string Loser => "Rock";
        public override string Action => "covers";
        public override GameMode ApplicableModes => GameMode.Classic | GameMode.LizardSpockVariant; // Both modes
    }

    // Lizard-Spock Rules
    public class RockCrushesLizard : RSPRule
    {
        public override string Winner => "Rock";
        public override string Loser => "Lizard";
        public override string Action => "crushes";
        public override GameMode ApplicableModes => GameMode.LizardSpockVariant; // LizardSpock only
    }

    public class LizardPoisonsSpock : RSPRule
    {
        public override string Winner => "Lizard";
        public override string Loser => "Spock";
        public override string Action => "poisons";
        public override GameMode ApplicableModes => GameMode.LizardSpockVariant; // LizardSpock only
    }

    public class SpockSmashesScissors : RSPRule
    {
        public override string Winner => "Spock";
        public override string Loser => "Scissors";
        public override string Action => "smashes";
        public override GameMode ApplicableModes => GameMode.LizardSpockVariant; // LizardSpock only
    }

    public class ScissorsDecapitateLizard : RSPRule
    {
        public override string Winner => "Scissors";
        public override string Loser => "Lizard";
        public override string Action => "decapitate";
        public override GameMode ApplicableModes => GameMode.LizardSpockVariant; // LizardSpock only
    }

    public class LizardEatsPaper : RSPRule
    {
        public override string Winner => "Lizard";
        public override string Loser => "Paper";
        public override string Action => "eats";
        public override GameMode ApplicableModes => GameMode.LizardSpockVariant; // LizardSpock only
    }

    public class PaperDisprovesSpock : RSPRule
    {
        public override string Winner => "Paper";
        public override string Loser => "Spock";
        public override string Action => "disproves";
        public override GameMode ApplicableModes => GameMode.LizardSpockVariant; // LizardSpock only
    }

    public class SpockVaporizesRock : RSPRule
    {
        public override string Winner => "Spock";
        public override string Loser => "Rock";
        public override string Action => "vaporizes";
        public override GameMode ApplicableModes => GameMode.LizardSpockVariant; // LizardSpock only
    }
}
