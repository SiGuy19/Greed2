using Raylib_cs;
using System.Numerics;
namespace Greed
{
    class GameObject {
    public Vector2 Position { get; set; } = new Vector2(0, 0);
    public Vector2 Velocity { get; set; } = new Vector2(0, 0);
    public Rectangle HitBox;

    virtual public void Draw() {
        // Base game objects do not have anything to draw
        HitBox = new Rectangle((int)Position.X, (int)Position.Y, 15, 15);
    }

    public void Move() {
        Vector2 NewPosition = this.Position;
        NewPosition.X += Velocity.X;
        NewPosition.Y += Velocity.Y;
        this.Position = NewPosition;
        HitBox.x = NewPosition.X;
        HitBox.y = NewPosition.Y;
    }

}

class ColoredObject: GameObject {
    public Color Color { get; set; }

    public ColoredObject(Color color) {
        Color = color;
    }

}

class GameSquare: ColoredObject {
    public int Size { get; set; }



    public GameSquare(Color color, int size): base(color) {
        Size = size;
    }

    override public void Draw() {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, Size, Size, Color);
        
    }

    
}

// class GameCircle: ColoredObject {

//     public int Radius { get; set; }

//     public GameCircle(Color color, int radius): base(color) {
//         Radius = radius;
//     }
//     override public void Draw()
//     {
//         Raylib.DrawCircle((int)Position.X, (int)Position.Y, Radius, Color);
//     }
// }

class GameText: ColoredObject {
    public string Text { get; set;}

    public GameText(Color color, string text): base(color) {
        Text = text;
        
    }
    public override void Draw()
    {
        Raylib.DrawText(Text, (int)Position.X, (int)Position.Y, 20, Color);
    }


}

}