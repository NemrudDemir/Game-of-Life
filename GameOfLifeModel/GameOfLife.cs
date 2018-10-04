using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeModel
{
    public class GameOfLife
    {
        Dictionary<int, Cell> aliveCells = new Dictionary<int, Cell>();
        public IEnumerable<Cell> Cells {
            get { return aliveCells.Values; }
        }
        int generation;
        public int Generation {
            get { return generation; }
        }
        Rule rule;
        private int fieldSize;
        public int FieldSize {
            get { return fieldSize; }
        }

        public GameOfLife(int fieldSize, string rule) : this(fieldSize, rule.Split('/')) { }
        public GameOfLife(int fieldSize, string[] rule) : this(fieldSize, new Rule(rule[0], rule[1])) { }
        public GameOfLife(int fieldSize, string aliveRule, string deadRule) : this(fieldSize, new Rule(aliveRule, deadRule)) { }

        public GameOfLife(int fieldSize, Rule rule)
        {
            this.fieldSize = fieldSize;
            this.rule = rule;
        }

        public void AddCell(int x, int y)
        {
            var coordinateHash = GetCoordinateHash(x, y);
            if (aliveCells.ContainsKey(coordinateHash))
                return;
            aliveCells.Add(coordinateHash, new Cell(x, y, fieldSize, true));
        }

        public void RemoveCell(int x, int y)
        {
            var coordinateHash = GetCoordinateHash(x, y);
            if (!aliveCells.ContainsKey(coordinateHash))
                return;
            aliveCells.Remove(coordinateHash);
        }

        private int GetCoordinateHash(Point p)
        {
            return GetCoordinateHash(p.X, p.Y);
        }

        private int GetCoordinateHash(int x, int y)
        {
            return y * FieldSize + x;
        }

        public void NextGeneration()
        {
            generation++;
            var newRelevantCells = new Dictionary<int, Cell>(aliveCells); //base of the new relevant cells are the current (alive) cells
            foreach (var aliveCell in aliveCells.Values) {
                foreach (var neighbourCell in Enum.GetValues(typeof(GridNeighbourCell))) {
                    var point = GridHelper.GetNeighbourCell((GridNeighbourCell)neighbourCell, aliveCell, FieldSize);
                    var coordinateHash = GetCoordinateHash(point);
                    if (!newRelevantCells.ContainsKey(coordinateHash))
                        newRelevantCells.Add(coordinateHash, new Cell(point, FieldSize, false));
                    newRelevantCells[coordinateHash].NeighboursCount++;
                }
            }

            foreach (var relevantCell in newRelevantCells.Values) {
                relevantCell.UpdateAliveStatus(rule);
            }
            aliveCells = newRelevantCells.Where(x => x.Value.IsAlive).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
