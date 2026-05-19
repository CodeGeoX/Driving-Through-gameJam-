using TcGame;

namespace Driving_Through_GameJam;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

public class Player : StaticActor
{
    public Player()
    {
        Sprite = new Sprite(new Texture("Data/Player_normal"));
        Position = (Vector2f) Engine.Get.Window.Size / 2;
        Speed = 0;
        Center();
        Forward = new Vector2f(0, -1);
    }
    
    public override void Update(float dt)
    {
        if (Keyboard.IsKeyPressed(Keyboard.Key.W))
        {
            Forward = new Vector2f(1, 0);
        }
        if (Keyboard.IsKeyPressed(Keyboard.Key.S))
        {
            Forward = new Vector2f(0, 1);
        }
    }
}