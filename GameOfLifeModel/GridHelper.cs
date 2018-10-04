using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeModel
{
    public class GridHelper
    {
        /// <summary>
        /// Gets specific neighbour cell
        /// </summary>
        /// <param name="neighbourCell"></param>
        /// <param name="cell"></param>
        /// <param name="fieldSize"></param>
        /// <returns></returns>
        public static Point GetNeighbourCell(GridNeighbourCell neighbourCell, Cell cell, int fieldSize)
        {
            int x = cell.X;
            int y = cell.Y;
            int s = fieldSize;
            switch (neighbourCell) {
                //The gamefield is defined as toroidal array aka periodic boundary
                case GridNeighbourCell.TopLeft:
                    return new Point((x + s - 1) % s, (y + s - 1) % s);
                case GridNeighbourCell.TopMid:
                    return new Point(x, (y + s - 1) % s);
                case GridNeighbourCell.TopRight:
                    return new Point((x+1)%s, (y + s - 1) % s);
                case GridNeighbourCell.MidLeft:
                    return new Point((x + s - 1) % s, y);
                case GridNeighbourCell.MidRight:
                    return new Point((x+1)%s, y);
                case GridNeighbourCell.BottomLeft:
                    return new Point((x + s - 1) % s, (y+1)%s);
                case GridNeighbourCell.BottomMid:
                    return new Point(x, (y+1)%s);
                case GridNeighbourCell.BottomRight:
                    return new Point((x+1)%s, (y+1)%s);
            }
            return new Point(-1, -1);
        }
    }

    public enum GridNeighbourCell
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
