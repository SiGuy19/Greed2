using Raylib_cs;
using System.Numerics;

namespace Greed
{
    class Player
    {
        public Vector2 playerPosition = new Vector2(240, 400);
        public int playerRadius = 5;

        public void movePlayer()
        {
            
            var playerSpeed = 4;
            
                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {
                    playerPosition.X += playerSpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {
                    playerPosition.X -= playerSpeed;
                }

                Raylib.DrawCircleV(playerPosition, playerRadius, Color.BLUE);
                //Raylib.DrawTextEx("#", 240, 800, 20, Color.WHITE);
                
            
        }
    }
}