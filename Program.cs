using Raylib_cs;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace SarsaMaze;

class Program
{
    public static void Main()
    {

        int windowSize = 900;
        int gridSize = 3;
        int cellSize = windowSize / gridSize;

        int chanceForObstacle = 10;

        Raylib.InitWindow(windowSize, windowSize, "SARSA");

        Environment world = new Environment(gridSize, chanceForObstacle, cellSize, true);
        SarsaAgent agent = new SarsaAgent(new Vector2(2, 0), cellSize);
        
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            world.DrawWorld();
            agent.DrawAgent();

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}