﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLifeModel
{
    public class GameOfLife
    {
        Dictionary<int, Cell> _aliveCells = new Dictionary<int, Cell>();
        public IEnumerable<Cell> Cells => _aliveCells.Values;
        public int GenerationCount { get; private set; }
        private Rule Rule { get; }
        public int FieldSize { get; } //TODO make it 2 seperate dimensions
        
        public GameOfLife(int fieldSize, string aliveRule, string deadRule) : this(fieldSize, new Rule(aliveRule, deadRule)) { }

        public GameOfLife(int fieldSize, Rule rule)
        {
            FieldSize = fieldSize;
            Rule = rule;
        }

        public void AddCell(int x, int y)
        {
            var coordinateHash = GetCoordinateHash(x, y);
            if (_aliveCells.ContainsKey(coordinateHash))
                return;
            _aliveCells.Add(coordinateHash, new Cell(x, y, true));
        }

        public void RemoveCell(int x, int y)
        {
            var coordinateHash = GetCoordinateHash(x, y);
            if (!_aliveCells.ContainsKey(coordinateHash))
                return;
            _aliveCells.Remove(coordinateHash);
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
            GenerationCount++;
            var newRelevantCells = new Dictionary<int, Cell>(_aliveCells); //base of the new relevant cells are the current (alive) cells
            foreach (var aliveCell in _aliveCells.Values) {
                foreach (var point in aliveCell.GetNeighborCellPoints(FieldSize)) {
                    var coordinateHash = GetCoordinateHash(point);
                    if (!newRelevantCells.ContainsKey(coordinateHash))
                        newRelevantCells.Add(coordinateHash, new Cell(point, false));
                    newRelevantCells[coordinateHash].NeighborsCount++;
                }
            }

            foreach (var relevantCell in newRelevantCells.Values) {
                relevantCell.UpdateAliveStatus(Rule);
            }
            _aliveCells = newRelevantCells.Where(x => x.Value.IsAlive).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
