namespace GameOfLifeModel
{
    public class Cell
    {
        public bool IsAlive { get; private set; }

        public int NeighborsCount { get; set; }

        public int X { get; }

        public int Y { get; }

        public Cell(Point point, bool isAlive, int neighborsCount = 0) : this(point.X, point.Y, isAlive, neighborsCount) {}

        public Cell(int x, int y, bool isAlive, int neighborsCount = 0)
        {
            X = x;
            Y = y;
            IsAlive = isAlive;
            NeighborsCount = neighborsCount;
        }

        public void UpdateAliveStatus(Rule rule)
        {
            IsAlive = rule.WillCellBeAlive(IsAlive, NeighborsCount);
            NeighborsCount = 0;
        }
    }
}
