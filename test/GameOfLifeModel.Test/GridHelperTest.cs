using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeModel.Test
{
    [TestClass]
    public class GridHelperTest
    {
        [TestMethod]
        public void GetNeighborCell_WithInvalid_ShouldThrow()
        {
            var fieldSize = 10;
            var cell = new Cell(0, 0, fieldSize, false);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GridHelper.GetNeighborCellPoint((GridNeighborCell) (-1), cell, fieldSize));
        }
    }
}
