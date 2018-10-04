using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeModel
{
    public class Rule
    {
        bool[] aliveRules = new bool[9];
        bool[] deadRules = new bool[9];

        public Rule(string aliveRule, string deadRule) //We have to handle it as string because '0' can be at the first position of the rules followed by other digits
        {
            string error = string.Empty;
            if(IsInvalidRule(aliveRule, ref error) || IsInvalidRule(deadRule, ref error))
                throw new Exception(error);
            foreach (var digit in aliveRule.ToCharArray().Select(x => x - '0'))
                aliveRules[digit] = true;
            foreach (var digit in deadRule.ToCharArray().Select(x => x - '0'))
                deadRules[digit] = true;
        }

        private bool IsInvalidRule(string rule, ref string error)
        {
            if(rule.ToCharArray().Any(x => x > '8' || x < '0')) {
                error = "Rules have to be digits between 0 and 8!";
                return true;
            }

            return false;
        }

        public bool WillCellBeAlive(bool isAlive, int neighbours)
        {
            return isAlive ? aliveRules[neighbours] : deadRules[neighbours];
        }
    }
}
