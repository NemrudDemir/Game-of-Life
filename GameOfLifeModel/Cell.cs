using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeModel
{
    public class Cell
    {
        private bool isAlive;
        public bool IsAlive {
            get {
                return isAlive;
            }
        }

        public int NeighboursCount {
            get; set;
        }

        public int X {
            get; set;
        }

        public int Y {
            get; set;
        }

        private int FieldSize {
            get;
        }

        public Cell(Point point, int fieldSize, bool isAlive, int neighboursCount = 0) : this(point.X, point.Y, fieldSize, isAlive, neighboursCount) {}

        public Cell(int x, int y, int fieldSize, bool isAlive, int neighboursCount = 0)
        {
            X = x;
            Y = y;
            FieldSize = fieldSize;
            this.isAlive = isAlive;
            NeighboursCount = neighboursCount;
        }

        public void UpdateAliveStatus(Rule rule)
        {
            this.isAlive = rule.WillCellBeAlive(IsAlive, NeighboursCount);
            NeighboursCount = 0;
        }

        public override int GetHashCode()
        {
            return Y * FieldSize + X;
        }

        public override bool Equals(object obj) {
            return this.GetHashCode() == obj.GetHashCode();
        }
    }
}
