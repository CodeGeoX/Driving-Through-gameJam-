using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System;

namespace Driving_Through_GameJam.Game
{
    public class Player : StaticActor
    {
        private bool wAnterior = false;
        private bool sAnterior = false;
        private bool GameOver = false;
        public Player()
        {
            Layer = ELayer.Middle;
            Sprite = new Sprite(new Texture("Data/Textures/Player_normal.png"));
            Position = (Vector2f) Engine.Get.Window.Size / 2;
            Center();
            Forward = new Vector2f(0, -1);

        }

        public override void Update(float dt)
        {
            bool wAhora = Keyboard.IsKeyPressed(Keyboard.Key.W);
            bool sAhora = Keyboard.IsKeyPressed(Keyboard.Key.S);
            
            base.Update(dt);
            if (wAnterior && !wAhora)
            {
                Forward = new Vector2f(0, -1);
                Position = Position + Forward * 200 * dt;
            }
            if (sAnterior && !sAhora)
            {
                Forward = new Vector2f(0, 1);
                Position = Position + Forward * 200 * dt;
            }
            wAnterior = wAhora;
            sAnterior = sAhora;
            CheckCollision();
        }

        private void CheckCollision()
        {
            foreach (Actor actor in Engine.Get.Scene.GetAll<Actor>())
            {
                if (actor is Cars car)
                {
                    if (Sprite.GetGlobalBounds().Intersects(car.Sprite.GetGlobalBounds()))
                    {
                        GameOver = true;

                        Console.WriteLine("DERROTA");
                    }
                }
            }
        }
    }
}