using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeModel.Test
{
    [TestClass]
    public class GameOfLifeTest
    {
        [TestMethod]
        public void ConstructorTests_ShouldntThrow()
        {
            var gameOfLife = new GameOfLife(10, "23", "3");
        }

        [TestMethod]
        public void Constructor_WithInvalidRules_ShouldThrow()
        {
            Assert.ThrowsException<Exception>(() => new GameOfLife(10, "9", "9"));
        }

        [TestMethod]
        public void AddCells_NotExisting_ShouldAddCells()
        {
            const int cellsCount = 5;
            var gameOfLife = new GameOfLife(cellsCount*2, "23", "3");
            for(var i = 0; i<cellsCount; i++)
                gameOfLife.AddCell(i, i);
            Assert.AreEqual(cellsCount, gameOfLife.Cells.Count());
        }

        [TestMethod]
        public void AddCells_Existing_ShouldAddOnlyOnce()
        {
            const int cellsCount = 5;
            var gameOfLife = new GameOfLife(cellsCount * 2, "23", "3");
            for (var i = 0; i < cellsCount; i++)
                gameOfLife.AddCell(0, 0);
            Assert.AreEqual(1, gameOfLife.Cells.Count());
        }

        [TestMethod]
        public void RemoveCells_NotExisting_ShouldntRemoveCell()
        {
            const int cellsCount = 5;
            var gameOfLife = new GameOfLife(cellsCount * 2, "23", "3");
            for (var i = 0; i < cellsCount; i++)
            {
                gameOfLife.AddCell(0, i);
                gameOfLife.RemoveCell(5, i);
            }

            Assert.AreEqual(cellsCount, gameOfLife.Cells.Count());
        }

        [TestMethod]
        public void RemoveCells_Existing_ShouldRemoveCells()
        {
            const int cellsCount = 5;
            var gameOfLife = new GameOfLife(cellsCount * 2, "23", "3");
            for (var i = 0; i < cellsCount; i++)
                gameOfLife.AddCell(i, i);

            Assert.AreEqual(5, gameOfLife.Cells.Count());

            for(var i = 0; i<cellsCount; i++)
                gameOfLife.RemoveCell(i, i);

            Assert.AreEqual(0, gameOfLife.Cells.Count());
        }

        [TestMethod]
        public void NextGeneration_ShouldBehaveAsExpected()
        {
            // ----- >> -----
            // --*-- >> -----
            // --*-- >> -***-
            // --*-- >> -----
            // ----- >> -----
            var gameOfLife = new GameOfLife(5, "23", "3");
            gameOfLife.AddCell(2, 1);
            gameOfLife.AddCell(2, 2);
            gameOfLife.AddCell(2, 3);

            gameOfLife.NextGeneration();

            Assert.AreEqual(3, gameOfLife.Cells.Count());
            foreach(var cell in gameOfLife.Cells)
                Assert.AreEqual(2, cell.Y);
        }

        [TestMethod]
        public void NextGeneration_LongSequenceShouldBeAsExpected() //see https://de.wikipedia.org/wiki/Conways_Spiel_des_Lebens#Andere_Objekte
        {
            var gameOfLife = new GameOfLife(50, "23", "3");
            gameOfLife.AddCell(24, 20);
            gameOfLife.AddCell(25, 20);
            gameOfLife.AddCell(26, 20);

            gameOfLife.AddCell(24, 21);
            gameOfLife.AddCell(24, 22);
            gameOfLife.AddCell(26, 21);
            gameOfLife.AddCell(26, 22);


            gameOfLife.AddCell(24, 26);
            gameOfLife.AddCell(25, 26);
            gameOfLife.AddCell(26, 26);

            gameOfLife.AddCell(24, 25);
            gameOfLife.AddCell(24, 24);
            gameOfLife.AddCell(26, 25);
            gameOfLife.AddCell(26, 24);

            var loopLength = 54;
            for (int i = 0; i < loopLength; i++)
            {
                Assert.IsTrue(gameOfLife.Cells.Any());
                gameOfLife.NextGeneration();
            }
            Assert.AreEqual(0, gameOfLife.Cells.Count());
        }
    }
}
