using Raylib_cs;
using System.Numerics;

namespace Greed
{
    class Game
    {
        Player player = new Player();
        GameSquare gameSquare = new GameSquare(Color.RED, 10);
        Score score = new Score();
        

        public void Start()
        {
            //Create Board Display
            var ScreenHeight = 480;
            var ScreenWidth = 800;
            var Objects = new List<GameObject>();
            var Random = new Random();
            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Greed");
            Raylib.SetTargetFPS(50);

            //Game Loop
            while (!Raylib.WindowShouldClose())
            {
                int newScore = score.getScore();
                Raylib.DrawText($"{newScore}", 12, 34, 25, Color.WHITE);
                player.movePlayer();

                // Add a new random object to the screen every iteration of our game loop
                var whichType = Random.Next(20);

                // Generate a random velocity for this object
                var randomY = 2;
                var randomX = Random.Next(0);

                //Get random position for Object
                List<int> ypositions = new List<int>();
                for (int i = 1; i <= 800; i++)
                {
                    ypositions.Add(i);
                }
                int randIndexPosition = Random.Next(ypositions.Count);
                int randomPosition = ypositions[randIndexPosition];
                var position = new Vector2(randomPosition, 0);

                
                //Get random color for Object
                List<Color> colors = new List<Color>()
                {
                    Color.YELLOW, Color.GOLD, Color.ORANGE, Color.PINK, Color.RED, Color.GREEN, Color.LIME, Color.BLUE, Color.PURPLE, Color.VIOLET, Color.SKYBLUE
                };
                int randIndexColor = Random.Next(colors.Count);
                Color randomColor = colors[randIndexColor];


                switch (whichType)
                {
                    case 0:
                        Console.WriteLine("Creating a square");
                        var square = new GameSquare(randomColor, 10);
                        square.Position = position;
                        square.Velocity = new Vector2(randomX, randomY);
                        Objects.Add(square);
                        break;
                    
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
                foreach (var obj in Objects.ToList())
                {
                    obj.Draw();

                    if (Raylib.CheckCollisionCircleRec(player.playerPosition, player.playerRadius, obj.HitBox))
                    {
                        if (obj is GameText) {
                            score.addScore();
                            Objects.Remove(obj);                           
                        }
                        else if (obj is GameSquare) {
                            score.removeScore();
                            Objects.Remove(obj);
                        }
                    }
                    obj.Move();
                    
                }
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}

