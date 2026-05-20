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

        public Player()
        {
            Layer = ELayer.Middle;
            Sprite = new Sprite(new Texture("Data/Textures/Player_normal.png"));
            Center();
            ResetearPosicion();
            
            Forward = new Vector2f(0, -1);
        }

        private void ResetearPosicion()
        {
            FloatRect limitesFondo = MyGame.Get.background.Sprite.GetGlobalBounds();


            float x = limitesFondo.Width / 2f;
            
            float y = limitesFondo.Height - (Sprite.GetGlobalBounds().Height / 2f);
            
            Position = new Vector2f(x, y);
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
            
            if (Position.Y <= 0)
            { 
                ResetearPosicion();
                MyGame.Get.AvanzarNivel();
            }
        }
    }
}