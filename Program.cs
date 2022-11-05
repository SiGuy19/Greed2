using Raylib_cs;
using System.Numerics;

namespace Greed
{
    static class Program
    {
        static Player player = new Player();
        static GameSquare gameSquare = new GameSquare(Color.RED, 10);
        public static void Main()
        {

            var ScreenHeight = 480;
            var ScreenWidth = 800;
            var Objects = new List<GameObject>();
            var Random = new Random();

            

            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Greed");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                player.movePlayer();
                // Add a new random object to the screen every iteration of our game loop
                var whichType = Random.Next(3);

                // Generate a random velocity for this object
                var randomY = Random.Next(2);
                var randomX = Random.Next(0);

                List<int> ypositions = new List<int>();
                for (int i = 1; i <= 800; i++)
                {
                    ypositions.Add(i);
                }
                Random random = new Random();
                int randIndexPosition = random.Next(ypositions.Count);
                int randomPosition = ypositions[randIndexPosition];
                // Each object will start about the center of the screen
                var position = new Vector2(randomPosition, 0);

                var rock = new Rectangle((int)gameSquare.Position.X, (int)gameSquare.Position.Y, gameSquare.Size, gameSquare.Size);

                List<Color> colors = new List<Color>()
                {
                    Color.YELLOW, Color.GOLD, Color.ORANGE, Color.PINK, Color.RED, Color.GREEN, Color.LIME, Color.BLUE, Color.PURPLE, Color.VIOLET, Color.SKYBLUE
                };
                int randIndexColor = random.Next(colors.Count);
                Color randomColor = colors[randIndexColor];
                

                switch (whichType) {
                    case 0:
                        Console.WriteLine("Creating a square");
                        var square = new GameSquare(randomColor, 10);
                        square.Position = position;
                        square.Velocity = new Vector2(randomX, randomY);
                        Objects.Add(square);
                        break;
                    // case 1:
                    //     Console.WriteLine("Creating a circle");
                    //     var circle = new GameCircle(Color.RED, 20);
                    //     circle.Position = position;
                    //     circle.Velocity = new Vector2(randomX, randomY);
                    //     Objects.Add(circle);
                    //     break;
                    case 1:
                        Console.WriteLine("Creating some text");
                        var text = new GameText(randomColor, "*");
                        text.Position = position;
                        text.Velocity = new Vector2(randomX, randomY);
                        Objects.Add(text);
                        break;
                    default:
                        break;
                
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                

                // Draw all of the objects in their current location
                foreach (var obj in Objects) {
                    obj.Draw();
                }
                if (Raylib.CheckCollisionCircleRec(player.playerPosition, player.playerRadius, rock))
                {
                    Raylib.DrawText("You did it!!!!", 12, 34, 100, Color.WHITE);
                }  

                Raylib.EndDrawing();

                // Move all of the objects to their next location
                foreach (var obj in Objects) {
                    obj.Move();
                }
            }

            Raylib.CloseWindow();
        }
    }
}

