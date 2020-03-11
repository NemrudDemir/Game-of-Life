using System;

namespace GameOfLifeModel
{
    public class GridHelper
    {
        /// <summary>
        /// Gets specific neighbor cell
        /// </summary>
        /// <param name="neighborCell">neighborCell enum</param>
        /// <param name="cell">actual cell</param>
        /// <param name="fieldSize"></param>
        /// <returns>Gets specific neighbor cell</returns>
        public static Point GetNeighborCellPoint(GridNeighborCell neighborCell, Cell cell, int fieldSize)
        {
            var x = cell.X;
            var y = cell.Y;
            var s = fieldSize;
            switch (neighborCell) {
                //The game field is defined as toroidal array aka periodic boundary
                case GridNeighborCell.TopLeft:
                    return new Point((x + s - 1) % s, (y + s - 1) % s);
                case GridNeighborCell.TopMid:
                    return new Point(x, (y + s - 1) % s);
                case GridNeighborCell.TopRight:
                    return new Point((x+1)%s, (y + s - 1) % s);
                case GridNeighborCell.MidLeft:
                    return new Point((x + s - 1) % s, y);
                case GridNeighborCell.MidRight:
                    return new Point((x+1)%s, y);
                case GridNeighborCell.BottomLeft:
                    return new Point((x + s - 1) % s, (y+1)%s);
                case GridNeighborCell.BottomMid:
                    return new Point(x, (y+1)%s);
                case GridNeighborCell.BottomRight:
                    return new Point((x+1)%s, (y+1)%s);
                default:
                    throw new ArgumentOutOfRangeException(nameof(neighborCell), neighborCell, null);
            }
        }
    }

    public enum GridNeighborCell
    {
        TopLeft,
        TopMid,
        TopRight,
        MidLeft,
        MidRight,
        BottomLeft,
        BottomMid,
        BottomRight
    }
}
