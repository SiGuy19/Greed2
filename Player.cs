using Raylib_cs;
using System.Numerics;

namespace Greed
{
    class Player
    {
        Vector2 playerPosition = new Vector2(150, 375);

        public void movePlayer()
        {
            
            var playerSpeed = 4;
            int playerRadius = 10;
                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {
                    playerPosition.X += playerSpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {
                    playerPosition.X -= playerSpeed;
                }

                // if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) {
                //     playerPosition.Y -= playerSpeed;
                // }

                // if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) {
                //     playerPosition.Y  += playerSpeed;
                // }

                Raylib.DrawCircleV(playerPosition, playerRadius, Color.BLUE);
            
            
        }
    }
}