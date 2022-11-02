using Raylib_cs;
using System.Numerics;

namespace Greed
{
    class Board
    {
        static Player player = new Player();

        public static void Main()
        {
            var screenHeight = 300;
            var screenWidth = 500;
            Raylib.InitWindow(screenHeight, screenWidth, "Greed");
            Raylib.SetTargetFPS(60);
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                player.movePlayer();
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}
