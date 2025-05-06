using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SarsaMaze
{
    public class Environment
    {

        public int[,] Grid { get; set; }
        public Vector2 startPos { get; set; }
        public Vector2 endPos { get; set; }
        public int CellSize { get; set; }
        public bool DebugMode { get; set; }


        public Environment(int size, int chanceForObstacle, int cellSize, bool debugMode)
        {

            Grid = new int[size, size];
            PopulateGrid();
            
            SetRandomObstacles(chanceForObstacle);

            startPos = new Vector2(0, 0);
            Grid[0, 0] = -1;

            endPos = new Vector2(size - 1, size - 1);
            Grid[size - 1, size - 1] = 100;


            CellSize = cellSize;
            DebugMode = debugMode;
        }

        /// <summary>
        /// Sets all grid cells as -1 → base cell.
        /// </summary>
        private void PopulateGrid()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {

                    Grid[i, j] = -1;

                }
            }
        }


        private Random random = new Random();
        private void SetRandomObstacles(int chanceForObstacle)
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    if (chanceForObstacle > random.Next(100))
                    {
                        Grid[i, j] = -100;
                    }
                }
            }
        }


        public void DrawWorld()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Color cellColor;
                    Color borderColor;

                    switch (Grid[i, j])
                    {
                        case -1:
                            cellColor = Color.Black;
                            borderColor = Color.White; 
                            break;
                        case 100:
                            cellColor = Color.Green;
                            borderColor = Color.Red; 
                            break;
                        case -100:
                            cellColor = Color.Gray;
                            borderColor = Color.White;
                            break;
                        default:
                            cellColor = Color.White;
                            borderColor = Color.Gray;
                            break;
                    }

                    Raylib.DrawRectangle(i * CellSize, j * CellSize, CellSize, CellSize, cellColor);
                    Raylib.DrawRectangleLines(i * CellSize, j * CellSize, CellSize, CellSize, borderColor);

                    if(DebugMode)
                    {
                        Raylib.DrawText(Grid[i, j].ToString(), i * CellSize, j * CellSize, CellSize / 2, borderColor);
                    }
                }
            }
        }

    }
}
