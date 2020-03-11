namespace GameOfLifeModel
{
    public class Cell
    {
        public bool IsAlive { get; private set; }

        public int NeighborsCount { get; set; }

        public int X { get; }

        public int Y { get; }

        private int FieldSize { get; }

        public Cell(Point point, int fieldSize, bool isAlive, int neighborsCount = 0) : this(point.X, point.Y, fieldSize, isAlive, neighborsCount) {}

        public Cell(int x, int y, int fieldSize, bool isAlive, int neighborsCount = 0)
        {
            X = x;
            Y = y;
            FieldSize = fieldSize;
            IsAlive = isAlive;
            NeighborsCount = neighborsCount;
        }

        public void UpdateAliveStatus(Rule rule)
        {
            IsAlive = rule.WillCellBeAlive(IsAlive, NeighborsCount);
            NeighborsCount = 0;
        }

        public override int GetHashCode()
        {
            return Y * FieldSize + X;
        }

        public override bool Equals(object obj) {
            return obj != null && GetHashCode() == obj.GetHashCode();
        }
    }
}
