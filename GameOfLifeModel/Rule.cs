using System;
using System.Linq;

namespace GameOfLifeModel
{
    public class Rule
    {
        private bool[] AliveRules { get; } = new bool[9];
        private bool[] DeadRules { get; } = new bool[9];

        public Rule(string aliveRule, string deadRule) //We have to handle it as string because '0' can be at the first position of the rules followed by other digits
        {
            var error = string.Empty;
            if(IsInvalidRule(aliveRule, ref error) || IsInvalidRule(deadRule, ref error))
                throw new Exception(error);
            foreach (var digit in aliveRule.ToCharArray().Select(x => x - '0'))
                AliveRules[digit] = true;
            foreach (var digit in deadRule.ToCharArray().Select(x => x - '0'))
                DeadRules[digit] = true;
        }

        private static bool IsInvalidRule(string rule, ref string error)
        {
            if (rule.ToCharArray().All(x => x >= '0' && x <= '8'))
                return false;
            error = "Rules have to be digits between 0 and 8!";
            return true;
        }

        public bool WillCellBeAlive(bool isAlive, int neighbors)
        {
            return isAlive ? AliveRules[neighbors] : DeadRules[neighbors];
        }
    }
}
