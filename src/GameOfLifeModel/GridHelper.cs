using System;
using System.Collections.Generic;

namespace GameOfLifeModel
{
    public static class GridHelper
    {
        /// <summary>
        /// Gets specific neighbor cell
        /// </summary>
        /// <param name="cell">actual cell</param>
        /// <param name="fieldSize"></param>
        /// <returns>Gets specific neighbor cell</returns>
        public static IEnumerable<Point> GetNeighborCellPoints(this Cell cell, int fieldSize)
        {
            var x = cell.X;
            var y = cell.Y;
            var s = fieldSize;
            //The game field is defined as toroidal array aka periodic boundary
            return new List<Point>
            {
                new Point((x + s - 1) % s, (y + s - 1) % s), //TopLeft
                new Point(x, (y + s - 1) % s), //TopMid
                new Point((x + 1) % s, (y + s - 1) % s), //TopRight
                new Point((x + s - 1) % s, y), //MidLeft
                new Point((x + 1) % s, y), //MidRight
                new Point((x + s - 1) % s, (y + 1) % s), //BottomLeft
                new Point(x, (y + 1) % s), //BottomMid
                new Point((x + 1) % s, (y + 1) % s) //BottomRight
            };
        }
    }
}
